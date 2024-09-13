using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Train Maximum Likelihood Classifier</para>
	/// <para>训练最大似然法分类器</para>
	/// <para>使用最大似然法分类器 (MLC) 分类定义生成 Esri 分类器定义文件 (.ecd)。</para>
	/// </summary>
	public class TrainMaximumLikelihoodClassifier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待分类的栅格数据集。</para>
		/// </param>
		/// <param name="InTrainingFeatures">
		/// <para>Input Training Sample File</para>
		/// <para>用于描绘训练场的训练样本文件或图层。</para>
		/// <para>它们可以是包含训练样本的 shapefile 或要素类。 训练样本文件中需要以下字段名称：</para>
		/// <para>classname- 指示类类别名称的文本字段</para>
		/// <para>classvalue- 包含每个类类别的整数值的长整型字段</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>包含属性信息、统计数据、超平面矢量和分类器所需的其他信息的输出 JSON 格式文件。 将创建 .ecd 文件。</para>
		/// </param>
		public TrainMaximumLikelihoodClassifier(object InRaster, object InTrainingFeatures, object OutClassifierDefinition)
		{
			this.InRaster = InRaster;
			this.InTrainingFeatures = InTrainingFeatures;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练最大似然法分类器</para>
		/// </summary>
		public override string DisplayName() => "训练最大似然法分类器";

		/// <summary>
		/// <para>Tool Name : TrainMaximumLikelihoodClassifier</para>
		/// </summary>
		public override string ToolName() => "TrainMaximumLikelihoodClassifier";

		/// <summary>
		/// <para>Tool Excute Name : ia.TrainMaximumLikelihoodClassifier</para>
		/// </summary>
		public override string ExcuteName() => "ia.TrainMaximumLikelihoodClassifier";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InTrainingFeatures, OutClassifierDefinition, InAdditionalRaster, UsedAttributes, DimensionValueField };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待分类的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Training Sample File</para>
		/// <para>用于描绘训练场的训练样本文件或图层。</para>
		/// <para>它们可以是包含训练样本的 shapefile 或要素类。 训练样本文件中需要以下字段名称：</para>
		/// <para>classname- 指示类类别名称的文本字段</para>
		/// <para>classvalue- 包含每个类类别的整数值的长整型字段</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTrainingFeatures { get; set; }

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
		/// <para>整合辅助栅格数据集，例如分割影像或 DEM。设置此参数属于可选操作。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// <para>指定要包括在与输出栅格相关联的属性表中的属性。</para>
		/// <para>聚合颜色—RGB 颜色值将基于每个分割从输入栅格获取。</para>
		/// <para>平均数字值—基于每个分割，将从可选像素图像中获取的平均数字值 (DN)。</para>
		/// <para>标准差—基于每个分割，将从可选像素影像中获取的标准差。</para>
		/// <para>像素计数—基于每个分割，构成分割的像素数。</para>
		/// <para>紧密度—基于每个分割，决定分割为紧凑型还是圆形的度数。 值的范围从 0 到 1，1 表示圆形。</para>
		/// <para>垂直度—基于每个分割，决定分割为矩形的度数。 值的范围从 0 到 1，1 表示矩形。</para>
		/// <para>仅当在输入栅格上将分割关键属性设置为 true 时，此参数才会激活。 如果该工具中的唯一输入是分割影像，则默认属性为平均色度、像素计数、紧密度和垂直度。 如果将附加输入栅格值作为输入与分割影像一起添加进来，则还可以使用平均数字值和标准差属性。</para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Dimension Value Field</para>
		/// <para>在输入训练样本要素类中包含尺寸值。</para>
		/// <para>使用使用 CCDC 分析变化工具的变化分析栅格输出来分类栅格数据的时间序列时，需要使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double", "Date")]
		public object DimensionValueField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainMaximumLikelihoodClassifier SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>聚合颜色—RGB 颜色值将基于每个分割从输入栅格获取。</para>
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
