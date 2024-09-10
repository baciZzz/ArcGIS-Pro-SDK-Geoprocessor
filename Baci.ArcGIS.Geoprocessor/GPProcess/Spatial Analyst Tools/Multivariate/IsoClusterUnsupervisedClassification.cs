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
	/// <para>Iso Cluster Unsupervised Classification</para>
	/// <para>Performs unsupervised classification on a series of input raster bands using the Iso Cluster and Maximum Likelihood Classification tools.</para>
	/// </summary>
	public class IsoClusterUnsupervisedClassification : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="NumberOfClasses">
		/// <para>Number of classes</para>
		/// <para>Number of classes into which to group the cells.</para>
		/// </param>
		/// <param name="OutputClassifiedRaster">
		/// <para>Output classified raster</para>
		/// <para>The output classified raster.</para>
		/// </param>
		public IsoClusterUnsupervisedClassification(object InputRasterBands, object NumberOfClasses, object OutputClassifiedRaster)
		{
			this.InputRasterBands = InputRasterBands;
			this.NumberOfClasses = NumberOfClasses;
			this.OutputClassifiedRaster = OutputClassifiedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Iso Cluster Unsupervised Classification</para>
		/// </summary>
		public override string DisplayName() => "Iso Cluster Unsupervised Classification";

		/// <summary>
		/// <para>Tool Name : IsoClusterUnsupervisedClassification</para>
		/// </summary>
		public override string ToolName() => "IsoClusterUnsupervisedClassification";

		/// <summary>
		/// <para>Tool Excute Name : sa.IsoClusterUnsupervisedClassification</para>
		/// </summary>
		public override string ExcuteName() => "sa.IsoClusterUnsupervisedClassification";

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
		public override object[] Parameters() => new object[] { InputRasterBands, NumberOfClasses, OutputClassifiedRaster, MinimumClassSize, SampleInterval, OutputSignatureFile };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasterBands { get; set; }

		/// <summary>
		/// <para>Number of classes</para>
		/// <para>Number of classes into which to group the cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfClasses { get; set; }

		/// <summary>
		/// <para>Output classified raster</para>
		/// <para>The output classified raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutputClassifiedRaster { get; set; }

		/// <summary>
		/// <para>Minimum class size</para>
		/// <para>Minimum number of cells in a valid class.</para>
		/// <para>The default is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MinimumClassSize { get; set; } = "20";

		/// <summary>
		/// <para>Sample interval</para>
		/// <para>The interval to be used for sampling.</para>
		/// <para>The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object SampleInterval { get; set; } = "10";

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gsg")]
		public object OutputSignatureFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IsoClusterUnsupervisedClassification SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
