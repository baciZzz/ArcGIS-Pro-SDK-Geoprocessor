using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Train Point Cloud Classification Model</para>
	/// <para>训练点云分类模型</para>
	/// <para>使用 PointCNN 架构为点云分类训练深度学习模型。</para>
	/// </summary>
	public class TrainPointCloudClassificationModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTrainingData">
		/// <para>Input Training Data</para>
		/// <para>点云训练数据（*.pctd 文件）不能用于训练分类模型。</para>
		/// </param>
		/// <param name="OutModelLocation">
		/// <para>Output Model Location</para>
		/// <para>现有文件夹将存储包含深度学习模型的新目录。</para>
		/// </param>
		/// <param name="OutModelName">
		/// <para>Output Model Name</para>
		/// <para>输出 Esri 模型定义文件的名称 (*.emd)、深度学习包 (*.dlpk) 以及将被创建以用于存储它们的新目录名称。</para>
		/// </param>
		public TrainPointCloudClassificationModel(object InTrainingData, object OutModelLocation, object OutModelName)
		{
			this.InTrainingData = InTrainingData;
			this.OutModelLocation = OutModelLocation;
			this.OutModelName = OutModelName;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练点云分类模型</para>
		/// </summary>
		public override string DisplayName() => "训练点云分类模型";

		/// <summary>
		/// <para>Tool Name : TrainPointCloudClassificationModel</para>
		/// </summary>
		public override string ToolName() => "TrainPointCloudClassificationModel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TrainPointCloudClassificationModel</para>
		/// </summary>
		public override string ExcuteName() => "3d.TrainPointCloudClassificationModel";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "gpuID", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTrainingData, OutModelLocation, OutModelName, PretrainedModel!, Attributes!, MinPoints!, ClassRemap!, TargetClasses!, BackgroundClass!, ClassDescriptions!, ModelSelectionCriteria!, MaxEpochs!, EpochIterations!, LearningRate!, BatchSize!, EarlyStop!, OutModel!, OutModelStats!, LearningRateStrategy!, OutEpochStats! };

		/// <summary>
		/// <para>Input Training Data</para>
		/// <para>点云训练数据（*.pctd 文件）不能用于训练分类模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pctd")]
		public object InTrainingData { get; set; }

		/// <summary>
		/// <para>Output Model Location</para>
		/// <para>现有文件夹将存储包含深度学习模型的新目录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutModelLocation { get; set; }

		/// <summary>
		/// <para>Output Model Name</para>
		/// <para>输出 Esri 模型定义文件的名称 (*.emd)、深度学习包 (*.dlpk) 以及将被创建以用于存储它们的新目录名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutModelName { get; set; }

		/// <summary>
		/// <para>Pre-trained Model</para>
		/// <para>将优化的预训练模型。 提供预训练的模型时，输入训练数据的属性、类代码和最大点数必须与生成此模型的训练数据所使用的相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object? PretrainedModel { get; set; }

		/// <summary>
		/// <para>Attribute Selection</para>
		/// <para>指定训练模型时将与分类代码配合使用的点属性。 仅点云训练数据中存在的属性可用。 默认情况下，不包含其他属性。</para>
		/// <para>强度—将使用激光雷达脉冲返回幅度的测量值。</para>
		/// <para>回波编号—将使用从给定的激光雷达脉冲获得的点顺序位置。</para>
		/// <para>回波数—将使用在与给定点关联的脉冲中被识别为点的激光雷达回波总数。</para>
		/// <para>红色波段—将使用来自具有颜色信息的点云的红色波段值。</para>
		/// <para>绿色波段—将使用来自具有颜色信息的点云的绿色波段值。</para>
		/// <para>蓝色波段—将使用来自具有颜色信息的点云的蓝色波段值。</para>
		/// <para>近红外波段—将使用来自具有近红外信息的点云的近红外波段值。</para>
		/// <para>相对高度—每个点相对于参考表面的相对高度，参考表面通常是裸露地表 DEM。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Attributes { get; set; }

		/// <summary>
		/// <para>Minimum Points Per Block</para>
		/// <para>训练模型时，给定块中必须存在的最小点数。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinPoints { get; set; } = "0";

		/// <summary>
		/// <para>Class Remapping</para>
		/// <para>定义在训练深度学习模型前类代码值将如何映射到新值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Manage Classes")]
		public object? ClassRemap { get; set; }

		/// <summary>
		/// <para>Class Codes Of Interest</para>
		/// <para>将用于过滤训练数据中的块的类代码。 指定了感兴趣区域的类代码后，所有其他类代码都将重新映射为背景类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Manage Classes")]
		public object? TargetClasses { get; set; }

		/// <summary>
		/// <para>Background Class Code</para>
		/// <para>指定了感兴趣内容的类代码后，将用于所有其他类代码的类代码值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("Manage Classes")]
		public object? BackgroundClass { get; set; }

		/// <summary>
		/// <para>Class Description</para>
		/// <para>有关训练数据中每个类代码代表内容的描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Manage Classes")]
		public object? ClassDescriptions { get; set; }

		/// <summary>
		/// <para>Model Selection Criteria</para>
		/// <para>指定将用于确定最终模型的统计基础。</para>
		/// <para>验证损失—使用将熵损失函数应用于验证数据时可以获得最低结果的模型。</para>
		/// <para>召回率—将使用针对所有类代码均能获得召回率的最佳宏平均值的模型。 每个类代码的召回率值均由正确分类的点（正确）占所有使用该值进行分类的点（预期正确）的比率确定。 这是默认设置。</para>
		/// <para>F1 得分—将使用针对所有类代码均能获得精度和召回率宏平均值的最佳谐波均值的模型。 这样可以在精度和召回率之间取得平衡，从而有利于提高整体性能。</para>
		/// <para>精度—将使用针对所有类代码均能获得精度的最佳宏平均值的模型。 每个类代码的精度均由正确分类的点（正确）占所有被分类点（正确和误报）的比率确定。</para>
		/// <para>准确性—将使用可以在验证数据的所有点之间获得最高正确分类点比率的模型。</para>
		/// <para><see cref="ModelSelectionCriteriaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Training Parameters")]
		public object? ModelSelectionCriteria { get; set; } = "RECALL";

		/// <summary>
		/// <para>Maximum Number of Epochs</para>
		/// <para>每个数据块通过神经网络向前和向后传递的次数。 默认值为 25。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Training Parameters")]
		public object? MaxEpochs { get; set; } = "25";

		/// <summary>
		/// <para>Iterations Per Epoch (%)</para>
		/// <para>在每个训练时期中处理的数据的百分比。 默认值为 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 100)]
		[Category("Training Parameters")]
		public object? EpochIterations { get; set; } = "100";

		/// <summary>
		/// <para>Learning Rate</para>
		/// <para>现有信息将被新信息覆盖的比率。 如果未指定任何值，则系统将在训练过程中从学习曲线中提取最佳学习率。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 0.99999999989999999)]
		[Category("Training Parameters")]
		public object? LearningRate { get; set; }

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>在任何给定时间将要处理的训练数据块的数量。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		[Category("Training Parameters")]
		public object? BatchSize { get; set; } = "2";

		/// <summary>
		/// <para>Stop training when model no longer improves</para>
		/// <para>指定为模型选择标准参数指定的指标在连续 5 个时期未记录任何改进后，模型训练是否将停止。</para>
		/// <para>选中 - 当模型不再改进时，模型训练将停止。 这是默认设置。</para>
		/// <para>未选中 - 模型训练将一直持续，直至达到最大时期数为止。</para>
		/// <para><see cref="EarlyStopEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Training Parameters")]
		public object? EarlyStop { get; set; } = "true";

		/// <summary>
		/// <para>Output Model</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutModel { get; set; }

		/// <summary>
		/// <para>Output Model Statistics</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutModelStats { get; set; }

		/// <summary>
		/// <para>Learning Rate Strategy</para>
		/// <para>指定在训练期间修改学习率的方式。</para>
		/// <para>单周期学习率—学习率将在每个时期中循环，使用 1cycle 技术的 Fast.AI 实施来训练神经网络，从而帮助改进卷积神经网络的训练。 这是默认设置。</para>
		/// <para>固定学习率—在整个训练过程中将使用相同的学习率。</para>
		/// <para><see cref="LearningRateStrategyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Training Parameters")]
		public object? LearningRateStrategy { get; set; } = "ONE_CYCLE";

		/// <summary>
		/// <para>Output Epoch Statistics</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutEpochStats { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainPointCloudClassificationModel SetEnviroment(object? processorType = null)
		{
			base.SetEnv(processorType: processorType);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attribute Selection</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>强度—将使用激光雷达脉冲返回幅度的测量值。</para>
			/// </summary>
			[GPValue("INTENSITY")]
			[Description("强度")]
			Intensity,

			/// <summary>
			/// <para>回波编号—将使用从给定的激光雷达脉冲获得的点顺序位置。</para>
			/// </summary>
			[GPValue("RETURN_NUMBER")]
			[Description("回波编号")]
			Return_Number,

			/// <summary>
			/// <para>回波数—将使用在与给定点关联的脉冲中被识别为点的激光雷达回波总数。</para>
			/// </summary>
			[GPValue("NUMBER_OF_RETURNS")]
			[Description("回波数")]
			Number_of_Returns,

			/// <summary>
			/// <para>红色波段—将使用来自具有颜色信息的点云的红色波段值。</para>
			/// </summary>
			[GPValue("RED")]
			[Description("红色波段")]
			Red_Band,

			/// <summary>
			/// <para>绿色波段—将使用来自具有颜色信息的点云的绿色波段值。</para>
			/// </summary>
			[GPValue("GREEN")]
			[Description("绿色波段")]
			Green_Band,

			/// <summary>
			/// <para>蓝色波段—将使用来自具有颜色信息的点云的蓝色波段值。</para>
			/// </summary>
			[GPValue("BLUE")]
			[Description("蓝色波段")]
			Blue_Band,

			/// <summary>
			/// <para>近红外波段—将使用来自具有近红外信息的点云的近红外波段值。</para>
			/// </summary>
			[GPValue("NEAR_INFRARED")]
			[Description("近红外波段")]
			Near_Infrared_Band,

			/// <summary>
			/// <para>相对高度—每个点相对于参考表面的相对高度，参考表面通常是裸露地表 DEM。</para>
			/// </summary>
			[GPValue("RELATIVE_HEIGHT")]
			[Description("相对高度")]
			Relative_Height,

		}

		/// <summary>
		/// <para>Model Selection Criteria</para>
		/// </summary>
		public enum ModelSelectionCriteriaEnum 
		{
			/// <summary>
			/// <para>验证损失—使用将熵损失函数应用于验证数据时可以获得最低结果的模型。</para>
			/// </summary>
			[GPValue("VALIDATION_LOSS")]
			[Description("验证损失")]
			Validation_Loss,

			/// <summary>
			/// <para>准确性—将使用可以在验证数据的所有点之间获得最高正确分类点比率的模型。</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("准确性")]
			Accuracy,

			/// <summary>
			/// <para>召回率—将使用针对所有类代码均能获得召回率的最佳宏平均值的模型。 每个类代码的召回率值均由正确分类的点（正确）占所有使用该值进行分类的点（预期正确）的比率确定。 这是默认设置。</para>
			/// </summary>
			[GPValue("RECALL")]
			[Description("召回率")]
			Recall,

			/// <summary>
			/// <para>F1 得分—将使用针对所有类代码均能获得精度和召回率宏平均值的最佳谐波均值的模型。 这样可以在精度和召回率之间取得平衡，从而有利于提高整体性能。</para>
			/// </summary>
			[GPValue("F1_SCORE")]
			[Description("F1 得分")]
			F1_Score,

			/// <summary>
			/// <para>精度—将使用针对所有类代码均能获得精度的最佳宏平均值的模型。 每个类代码的精度均由正确分类的点（正确）占所有被分类点（正确和误报）的比率确定。</para>
			/// </summary>
			[GPValue("PRECISION")]
			[Description("精度")]
			Precision,

		}

		/// <summary>
		/// <para>Stop training when model no longer improves</para>
		/// </summary>
		public enum EarlyStopEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EARLY_STOP")]
			EARLY_STOP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EARLY_STOP")]
			NO_EARLY_STOP,

		}

		/// <summary>
		/// <para>Learning Rate Strategy</para>
		/// </summary>
		public enum LearningRateStrategyEnum 
		{
			/// <summary>
			/// <para>单周期学习率—学习率将在每个时期中循环，使用 1cycle 技术的 Fast.AI 实施来训练神经网络，从而帮助改进卷积神经网络的训练。 这是默认设置。</para>
			/// </summary>
			[GPValue("ONE_CYCLE")]
			[Description("单周期学习率")]
			One_Cycle_Learning_Rate,

			/// <summary>
			/// <para>固定学习率—在整个训练过程中将使用相同的学习率。</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("固定学习率")]
			Fixed_Learning_Rate,

		}

#endregion
	}
}
