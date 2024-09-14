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
	/// <para>Iso 聚类非监督分类</para>
	/// <para>使用 Iso 聚类工具和最大似然法分类工具对一系列输入栅格波段执行非监督分类。</para>
	/// </summary>
	public class IsoClusterUnsupervisedClassification : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasterBands">
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="NumberOfClasses">
		/// <para>Number of classes</para>
		/// <para>要将像元划分成的类数目。</para>
		/// </param>
		/// <param name="OutputClassifiedRaster">
		/// <para>Output classified raster</para>
		/// <para>输出分类的栅格。</para>
		/// </param>
		public IsoClusterUnsupervisedClassification(object InputRasterBands, object NumberOfClasses, object OutputClassifiedRaster)
		{
			this.InputRasterBands = InputRasterBands;
			this.NumberOfClasses = NumberOfClasses;
			this.OutputClassifiedRaster = OutputClassifiedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Iso 聚类非监督分类</para>
		/// </summary>
		public override string DisplayName() => "Iso 聚类非监督分类";

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
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasterBands { get; set; }

		/// <summary>
		/// <para>Number of classes</para>
		/// <para>要将像元划分成的类数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfClasses { get; set; }

		/// <summary>
		/// <para>Output classified raster</para>
		/// <para>输出分类的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutputClassifiedRaster { get; set; }

		/// <summary>
		/// <para>Minimum class size</para>
		/// <para>一个有效类中的最小像元数。</para>
		/// <para>默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MinimumClassSize { get; set; } = "20";

		/// <summary>
		/// <para>Sample interval</para>
		/// <para>采样所使用的间隔。</para>
		/// <para>默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object SampleInterval { get; set; } = "10";

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gsg")]
		public object OutputSignatureFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IsoClusterUnsupervisedClassification SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
