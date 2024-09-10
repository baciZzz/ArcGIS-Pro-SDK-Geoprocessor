using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Maximum Likelihood Classification</para>
	/// <para>Performs a maximum likelihood classification on a set of raster bands and creates a classified raster as output.</para>
	/// </summary>
	public class MLClassify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>While the bands can be integer or floating point type, the signature file only allows integer class values.</para>
		/// </param>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>The input signature file whose class signatures are used by the maximum likelihood classifier.</para>
		/// <para>A .gsg extension is required.</para>
		/// </param>
		/// <param name="OutClassifiedRaster">
		/// <para>Output classified raster</para>
		/// <para>The output classified raster.</para>
		/// <para>It will be of integer type.</para>
		/// </param>
		public MLClassify(object InRasterBands, object InSignatureFile, object OutClassifiedRaster)
		{
			this.InRasterBands = InRasterBands;
			this.InSignatureFile = InSignatureFile;
			this.OutClassifiedRaster = OutClassifiedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Maximum Likelihood Classification</para>
		/// </summary>
		public override string DisplayName() => "Maximum Likelihood Classification";

		/// <summary>
		/// <para>Tool Name : MLClassify</para>
		/// </summary>
		public override string ToolName() => "MLClassify";

		/// <summary>
		/// <para>Tool Excute Name : sa.MLClassify</para>
		/// </summary>
		public override string ExcuteName() => "sa.MLClassify";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, InSignatureFile, OutClassifiedRaster, RejectFraction, APrioriProbabilities, InAPrioriFile, OutConfidenceRaster };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>While the bands can be integer or floating point type, the signature file only allows integer class values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Input signature file</para>
		/// <para>The input signature file whose class signatures are used by the maximum likelihood classifier.</para>
		/// <para>A .gsg extension is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Output classified raster</para>
		/// <para>The output classified raster.</para>
		/// <para>It will be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutClassifiedRaster { get; set; }

		/// <summary>
		/// <para>Reject fraction</para>
		/// <para>Select a reject fraction, which determines whether a cell will be classified based on its likelihood of being correctly assigned to one of the classes. Cells whose likelihood of being correctly assigned to any of the classes is lower than the reject fraction will be given a value of NoData in the output classified raster.</para>
		/// <para>The default value is 0.0, which means that every cell will be classified.</para>
		/// <para>Valid entries are:</para>
		/// <para>0.0</para>
		/// <para>0.005</para>
		/// <para>0.01</para>
		/// <para>0.025</para>
		/// <para>0.05</para>
		/// <para>0.1</para>
		/// <para>0.25</para>
		/// <para>0.5</para>
		/// <para>0.75</para>
		/// <para>0.9</para>
		/// <para>0.95</para>
		/// <para>0.975</para>
		/// <para>0.99</para>
		/// <para>0.995</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RejectFraction { get; set; } = "0.0";

		/// <summary>
		/// <para>A priori probability weighting</para>
		/// <para>Specifies how a priori probabilities will be determined.</para>
		/// <para>Equal— All classes will have the same a priori probability.</para>
		/// <para>Sample— A priori probabilities will be proportional to the number of cells in each class relative to the total number of cells sampled in all classes in the signature file.</para>
		/// <para>File—The a priori probabilities will be assigned to each class from an input ASCII a priori probability file.</para>
		/// <para><see cref="APrioriProbabilitiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object APrioriProbabilities { get; set; } = "EQUAL";

		/// <summary>
		/// <para>Input a priori probability file</para>
		/// <para>A text file containing a priori probabilities for the input signature classes.</para>
		/// <para>An input for the a priori probability file is only required when the File option is used.</para>
		/// <para>The extension for the a priori file can be .txt or .asc.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InAPrioriFile { get; set; }

		/// <summary>
		/// <para>Output confidence raster</para>
		/// <para>The output confidence raster dataset shows the certainty of the classification in 14 levels of confidence, with the lowest values representing the highest reliability. If there are no cells classified at a particular confidence level, that confidence level will not be present in the output confidence raster.</para>
		/// <para>It will be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutConfidenceRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MLClassify SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>A priori probability weighting</para>
		/// </summary>
		public enum APrioriProbabilitiesEnum 
		{
			/// <summary>
			/// <para>Equal— All classes will have the same a priori probability.</para>
			/// </summary>
			[GPValue("EQUAL")]
			[Description("Equal")]
			Equal,

			/// <summary>
			/// <para>Sample— A priori probabilities will be proportional to the number of cells in each class relative to the total number of cells sampled in all classes in the signature file.</para>
			/// </summary>
			[GPValue("SAMPLE")]
			[Description("Sample")]
			Sample,

			/// <summary>
			/// <para>File—The a priori probabilities will be assigned to each class from an input ASCII a priori probability file.</para>
			/// </summary>
			[GPValue("FILE")]
			[Description("File")]
			File,

		}

#endregion
	}
}
