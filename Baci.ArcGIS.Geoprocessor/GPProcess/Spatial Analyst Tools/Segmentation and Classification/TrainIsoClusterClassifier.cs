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
	/// <para>Train ISO Cluster Classifier</para>
	/// <para>训练 ISO 聚类分类器</para>
	/// <para>使用 Iso 聚类分类定义生成 Esri 分类器定义文件 (.ecd)。</para>
	/// </summary>
	public class TrainIsoClusterClassifier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待分类的栅格数据集。</para>
		/// </param>
		/// <param name="MaxClasses">
		/// <para>Max Number Of Classes / Clusters</para>
		/// <para>分组像素或分割影像时所需的最大类数。此参数应设置为大于图例中类的数量。</para>
		/// <para>您获取的要素类可能会少于此参数中指定的数量。如果需要更多要素类，可在训练过程结束后增加此值并聚集类。</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>包含属性信息、统计数据、超平面矢量和分类器所需的其他信息的输出 JSON 格式文件。 将创建 .ecd 文件。</para>
		/// </param>
		public TrainIsoClusterClassifier(object InRaster, object MaxClasses, object OutClassifierDefinition)
		{
			this.InRaster = InRaster;
			this.MaxClasses = MaxClasses;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练 ISO 聚类分类器</para>
		/// </summary>
		public override string DisplayName() => "训练 ISO 聚类分类器";

		/// <summary>
		/// <para>Tool Name : TrainIsoClusterClassifier</para>
		/// </summary>
		public override string ToolName() => "TrainIsoClusterClassifier";

		/// <summary>
		/// <para>Tool Excute Name : sa.TrainIsoClusterClassifier</para>
		/// </summary>
		public override string ExcuteName() => "sa.TrainIsoClusterClassifier";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, MaxClasses, OutClassifierDefinition, InAdditionalRaster!, MaxIterations!, MinSamplesPerCluster!, SkipFactor!, UsedAttributes!, MaxMergePerIter!, MaxMergeDistance! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待分类的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Max Number Of Classes / Clusters</para>
		/// <para>分组像素或分割影像时所需的最大类数。此参数应设置为大于图例中类的数量。</para>
		/// <para>您获取的要素类可能会少于此参数中指定的数量。如果需要更多要素类，可在训练过程结束后增加此值并聚集类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MaxClasses { get; set; }

		/// <summary>
		/// <para>Output Classifier Definition File</para>
		/// <para>包含属性信息、统计数据、超平面矢量和分类器所需的其他信息的输出 JSON 格式文件。 将创建 .ecd 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>将对其他栅格数据集（如多光谱影像或 DEM）进行整合，从而为分类生成属性和其他所需信息。 设置此参数属于可选操作。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Maximum Number Of Iterations</para>
		/// <para>聚类过程将运行的最大迭代次数。</para>
		/// <para>推荐迭代次数范围为 10 到 20 之间。 增加此值将会使处理时间呈线性增加。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxIterations { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Number of Samples Per Cluster</para>
		/// <para>一个有效聚类或类中的最小像素数或分割数。</para>
		/// <para>默认值 20 对于创建具有统计显著性的类有效。 您可以增加此数字以获得更大的聚类和更少的狭长面；但是，它可能会限制创建的类的总数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinSamplesPerCluster { get; set; } = "20";

		/// <summary>
		/// <para>Skip Factor</para>
		/// <para>像素影像输入所需跳过的像素数。如果输入是分割影像，则请指定要跳过的分割数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SkipFactor { get; set; } = "10";

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// <para>指定要包括在与输出栅格相关联的属性表中的属性。</para>
		/// <para>聚合颜色—RGB 颜色值将基于每个分割从输入栅格获取。 这也称为平均色度。</para>
		/// <para>平均数字值—基于每个分割，将从可选像素图像中获取的平均数字值 (DN)。</para>
		/// <para>标准差—基于每个分割，将从可选像素影像中获取的标准差。</para>
		/// <para>像素计数—基于每个分割，构成分割的像素数。</para>
		/// <para>紧密度—基于每个分割，决定分割为紧凑型还是圆形的度数。 值的范围从 0 到 1，1 表示圆形。</para>
		/// <para>垂直度—基于每个分割，决定分割为矩形的度数。 值的范围从 0 到 1，1 表示矩形。</para>
		/// <para>仅当在输入栅格上将分割关键属性设置为 true 时，此参数才会激活。 如果该工具中的唯一输入是分割影像，则默认属性为聚合颜色、像素计数、紧密度和垂直度。 如果将附加输入栅格值作为输入与分割影像一起添加进来，则还可以使用平均数字值和标准差属性。</para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object? UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Maximum Number Of Cluster Merges per Iteration</para>
		/// <para>每个迭代的最大聚类合并数。 增加合并的数量将减少所创建的类。 较小值将生成较多的类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxMergePerIter { get; set; } = "5";

		/// <summary>
		/// <para>Maximum Merge Distance</para>
		/// <para>要素空间中聚类中心间的最大距离。 增加距离将允许更多的聚类合并，从而生成较少的类。 较小值将生成较多的类。 使用值 0 到 5 通常可获得最佳结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxMergeDistance { get; set; } = "0.5";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainIsoClusterClassifier SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>聚合颜色—RGB 颜色值将基于每个分割从输入栅格获取。 这也称为平均色度。</para>
			/// </summary>
			[GPValue("COLOR")]
			[Description("聚合颜色")]
			Converged_color,

			/// <summary>
			/// <para>平均数字值—基于每个分割，将从可选像素图像中获取的平均数字值 (DN)。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均数字值")]
			Mean_digital_number,

			/// <summary>
			/// <para>标准差—基于每个分割，将从可选像素影像中获取的标准差。</para>
			/// </summary>
			[GPValue("STD")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>像素计数—基于每个分割，构成分割的像素数。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("像素计数")]
			Count_of_pixels,

			/// <summary>
			/// <para>紧密度—基于每个分割，决定分割为紧凑型还是圆形的度数。 值的范围从 0 到 1，1 表示圆形。</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("紧密度")]
			Compactness,

			/// <summary>
			/// <para>垂直度—基于每个分割，决定分割为矩形的度数。 值的范围从 0 到 1，1 表示矩形。</para>
			/// </summary>
			[GPValue("RECTANGULARITY")]
			[Description("垂直度")]
			Rectangularity,

		}

#endregion
	}
}
