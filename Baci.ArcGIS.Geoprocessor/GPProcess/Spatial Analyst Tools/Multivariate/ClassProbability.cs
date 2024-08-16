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
	/// <para>Class Probability</para>
	/// <para>Creates a multiband raster of probability bands, with one band being created for each class represented in the input signature file.</para>
	/// </summary>
	public class ClassProbability : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>Input signature file whose class signatures are used to generate the a priori probability bands.</para>
		/// <para>A .gsg extension is required.</para>
		/// </param>
		/// <param name="OutMultibandRaster">
		/// <para>Output multiband raster</para>
		/// <para>The output multiband raster dataset.</para>
		/// <para>It will be of integer type.</para>
		/// <para>If the output is an Esri Grid, the filename cannot have more than 9 characters.</para>
		/// </param>
		public ClassProbability(object InRasterBands, object InSignatureFile, object OutMultibandRaster)
		{
			this.InRasterBands = InRasterBands;
			this.InSignatureFile = InSignatureFile;
			this.OutMultibandRaster = OutMultibandRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Class Probability</para>
		/// </summary>
		public override string DisplayName => "Class Probability";

		/// <summary>
		/// <para>Tool Name : ClassProbability</para>
		/// </summary>
		public override string ToolName => "ClassProbability";

		/// <summary>
		/// <para>Tool Excute Name : sa.ClassProbability</para>
		/// </summary>
		public override string ExcuteName => "sa.ClassProbability";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasterBands, InSignatureFile, OutMultibandRaster, MaximumOutputValue, APrioriProbabilities, InAPrioriFile };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
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
		/// <para>Input signature file whose class signatures are used to generate the a priori probability bands.</para>
		/// <para>A .gsg extension is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Output multiband raster</para>
		/// <para>The output multiband raster dataset.</para>
		/// <para>It will be of integer type.</para>
		/// <para>If the output is an Esri Grid, the filename cannot have more than 9 characters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultibandRaster { get; set; }

		/// <summary>
		/// <para>Maximum output value</para>
		/// <para>Factor for scaling the range of values in the output probability bands.</para>
		/// <para>By default, the values range from 0 to 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MaximumOutputValue { get; set; } = "100";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassProbability SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
