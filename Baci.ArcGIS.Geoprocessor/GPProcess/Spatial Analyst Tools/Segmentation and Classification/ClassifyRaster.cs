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
	/// <para>Classify Raster</para>
	/// <para>分类栅格</para>
	/// <para>根据 Esri 分类器定义文件 (.ecd) 和栅格数据集输入对栅格数据集进行分类。</para>
	/// </summary>
	public class ClassifyRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待分类的栅格数据集。</para>
		/// </param>
		/// <param name="InClassifierDefinition">
		/// <para>Input Classifier Definition File</para>
		/// <para>包含分类器选定属性的统计数据的输入 Esri 分类器定义文件 (.ecd)。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Classified Raster</para>
		/// <para>您正在创建的分类影像的路径和名称。</para>
		/// <para>输出分类栅格由输入栅格数据集和 .ecd 文件输入进行定义。</para>
		/// </param>
		public ClassifyRaster(object InRaster, object InClassifierDefinition, object OutRasterDataset)
		{
			this.InRaster = InRaster;
			this.InClassifierDefinition = InClassifierDefinition;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 分类栅格</para>
		/// </summary>
		public override string DisplayName() => "分类栅格";

		/// <summary>
		/// <para>Tool Name : ClassifyRaster</para>
		/// </summary>
		public override string ToolName() => "ClassifyRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.ClassifyRaster</para>
		/// </summary>
		public override string ExcuteName() => "sa.ClassifyRaster";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InClassifierDefinition, OutRasterDataset, InAdditionalRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待分类的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Classifier Definition File</para>
		/// <para>包含分类器选定属性的统计数据的输入 Esri 分类器定义文件 (.ecd)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// <para>您正在创建的分类影像的路径和名称。</para>
		/// <para>输出分类栅格由输入栅格数据集和 .ecd 文件输入进行定义。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>将对其他栅格数据集（如多光谱影像或 DEM）进行整合，从而为分类器生成属性和其他所需信息。 计算平均值或标准差等属性时需要使用此栅格。 设置此参数属于可选操作。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyRaster SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
