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
	/// <para>Inspect Training Samples</para>
	/// <para>检查训练样本</para>
	/// <para>估计个人训练样本的精度。 交叉验证精度是使用 .ecd 文件中先前生成的分类训练结果及训练样本进行计算的。 输出包括以下内容：包含误分类类值的栅格数据集，包含每个训练样本精度得分的训练样本数据集。</para>
	/// </summary>
	public class InspectTrainingSamples : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要进行分类的输入栅格。</para>
		/// </param>
		/// <param name="InTrainingFeatures">
		/// <para>Input Training Sample File</para>
		/// <para>在训练样本管理器窗格中创建的训练样本要素类。</para>
		/// </param>
		/// <param name="InClassifierDefinition">
		/// <para>Input Classifier Definition File</para>
		/// <para>任意训练分类器工具中的 .ecd 输出分类器文件。.ecd 文件是包含属性信息、统计数据或分类器所需的其他信息的 JSON 文件。</para>
		/// </param>
		/// <param name="OutTrainingFeatureClass">
		/// <para>Output Training Sample Feature Class with Score</para>
		/// <para>另存为要素类的单个输出训练样本。关联的属性表包含列出精度得分的添加字段。</para>
		/// </param>
		/// <param name="OutMisclassifiedRaster">
		/// <para>Output Misclassified Raster</para>
		/// <para>在训练样本外部具有 NoData 的输出误分类栅格。在训练样本中，正确分类的像素表示为 NoData，误分类像素由其类值表示。结果为误分类类值的索引地图。</para>
		/// </param>
		public InspectTrainingSamples(object InRaster, object InTrainingFeatures, object InClassifierDefinition, object OutTrainingFeatureClass, object OutMisclassifiedRaster)
		{
			this.InRaster = InRaster;
			this.InTrainingFeatures = InTrainingFeatures;
			this.InClassifierDefinition = InClassifierDefinition;
			this.OutTrainingFeatureClass = OutTrainingFeatureClass;
			this.OutMisclassifiedRaster = OutMisclassifiedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 检查训练样本</para>
		/// </summary>
		public override string DisplayName() => "检查训练样本";

		/// <summary>
		/// <para>Tool Name : InspectTrainingSamples</para>
		/// </summary>
		public override string ToolName() => "InspectTrainingSamples";

		/// <summary>
		/// <para>Tool Excute Name : sa.InspectTrainingSamples</para>
		/// </summary>
		public override string ExcuteName() => "sa.InspectTrainingSamples";

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
		public override object[] Parameters() => new object[] { InRaster, InTrainingFeatures, InClassifierDefinition, OutTrainingFeatureClass, OutMisclassifiedRaster, InAdditionalRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要进行分类的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Training Sample File</para>
		/// <para>在训练样本管理器窗格中创建的训练样本要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTrainingFeatures { get; set; }

		/// <summary>
		/// <para>Input Classifier Definition File</para>
		/// <para>任意训练分类器工具中的 .ecd 输出分类器文件。.ecd 文件是包含属性信息、统计数据或分类器所需的其他信息的 JSON 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Output Training Sample Feature Class with Score</para>
		/// <para>另存为要素类的单个输出训练样本。关联的属性表包含列出精度得分的添加字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Misclassified Raster</para>
		/// <para>在训练样本外部具有 NoData 的输出误分类栅格。在训练样本中，正确分类的像素表示为 NoData，误分类像素由其类值表示。结果为误分类类值的索引地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMisclassifiedRaster { get; set; }

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
		public InspectTrainingSamples SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
