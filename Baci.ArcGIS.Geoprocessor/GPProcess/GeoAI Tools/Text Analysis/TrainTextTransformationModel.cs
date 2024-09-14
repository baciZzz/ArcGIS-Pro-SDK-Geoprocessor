using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAITools
{
	/// <summary>
	/// <para>Train Text Transformation Model</para>
	/// <para>训练文本转换模型</para>
	/// <para>训练文本转换模型以转换、翻译或汇总文本。</para>
	/// </summary>
	public class TrainTextTransformationModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要素类或表，其中包含带有模型输入文本的文本字段和包含目标转换文本的标注字段。</para>
		/// </param>
		/// <param name="TextField">
		/// <para>Text Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含将按模型转换的输入文本。</para>
		/// </param>
		/// <param name="LabelField">
		/// <para>Label Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含用于训练模型的目标转换文本。</para>
		/// </param>
		/// <param name="OutModel">
		/// <para>Output Model</para>
		/// <para>将存储经训练模型的输出文件夹位置。</para>
		/// </param>
		public TrainTextTransformationModel(object InTable, object TextField, object LabelField, object OutModel)
		{
			this.InTable = InTable;
			this.TextField = TextField;
			this.LabelField = LabelField;
			this.OutModel = OutModel;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练文本转换模型</para>
		/// </summary>
		public override string DisplayName() => "训练文本转换模型";

		/// <summary>
		/// <para>Tool Name : TrainTextTransformationModel</para>
		/// </summary>
		public override string ToolName() => "TrainTextTransformationModel";

		/// <summary>
		/// <para>Tool Excute Name : geoai.TrainTextTransformationModel</para>
		/// </summary>
		public override string ExcuteName() => "geoai.TrainTextTransformationModel";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAI Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAI Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoai</para>
		/// </summary>
		public override string ToolboxAlise() => "geoai";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "gpuID", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, TextField, LabelField, OutModel, PretrainedModelFile!, MaxEpochs!, ModelBackbone!, BatchSize!, ModelArguments!, LearningRate!, ValidationPercentage!, StopTraining!, MakeTrainable!, RemoveHtmlTags!, RemoveUrls! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要素类或表，其中包含带有模型输入文本的文本字段和包含目标转换文本的标注字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Text Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含将按模型转换的输入文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object TextField { get; set; }

		/// <summary>
		/// <para>Label Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含用于训练模型的目标转换文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LabelField { get; set; }

		/// <summary>
		/// <para>Output Model</para>
		/// <para>将存储经训练模型的输出文件夹位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutModel { get; set; }

		/// <summary>
		/// <para>Pretrained Model File</para>
		/// <para>将用于微调新模型的预训练模型。 输入可以是 Esri 模型定义文件 (.emd) 或深度学习包文件 (.dlpk)。</para>
		/// <para>可以对执行类似任务的预训练模型进行微调以适应训练数据。 预训练模型必须已使用将用于训练新模型的相同模型类型和骨干模型进行了训练。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object? PretrainedModelFile { get; set; }

		/// <summary>
		/// <para>Max Epochs</para>
		/// <para>将用于训练模型的最大时期数。 最大时期值为 1 意味着数据集将通过神经网络向前和向后传递一次。 默认值为 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxEpochs { get; set; } = "5";

		/// <summary>
		/// <para>Model Backbone</para>
		/// <para>指定要用作训练新模型的架构的、预先配置的神经网络。</para>
		/// <para>t5-small—该新模型将使用 T5 神经网络进行训练。 T5 是一个统一的框架，可以将每个语言问题转换为文本到文本格式。t5-small 是 T5 的小型变体。</para>
		/// <para>t5-base—该新模型将使用 T5 神经网络进行训练。 T5 是一个统一的框架，可以将每个语言问题转换为文本到文本格式。t5-base 是 T5 的中型变体。</para>
		/// <para>t5-large—该新模型将使用 T5 神经网络进行训练。 T5 是一个统一的框架，可以将每个语言问题转换为文本到文本格式。t5-large 是 T5 的大型变体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Model Parameters")]
		public object? ModelBackbone { get; set; } = "t5-base";

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>一次需要处理的训练样本数。 默认值为 2。</para>
		/// <para>增加批处理大小可以提高工具性能；但是，随着批处理大小的增加，会占用更多内存。 如果发生内存不足错误，请使用较小的批处理大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Model Parameters")]
		public object? BatchSize { get; set; } = "2";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>用于初始化模型的其他参数（例如，用于训练数据的最大序列长度的 seq_len）将被考虑用于训练模型。</para>
		/// <para>有关可以使用的受支持模型参数列表，请参阅 SequenceToSequence 文档中的关键字参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Model Parameters")]
		public object? ModelArguments { get; set; } = "sequence_length 512";

		/// <summary>
		/// <para>Learning Rate</para>
		/// <para>指示在训练过程中将调整多少模型权重的步长。 如果未指定值，将自动推断出最佳学习率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? LearningRate { get; set; }

		/// <summary>
		/// <para>Validation Percentage</para>
		/// <para>将用于验证模型的训练样本的百分比。 默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? ValidationPercentage { get; set; } = "10";

		/// <summary>
		/// <para>Stop when model stops improving</para>
		/// <para>指定模型训练是在模型不再改进时停止还是直至达到最大时期参数值时才停止。</para>
		/// <para>选中 - 当模型不再改进时，无论所指定的最大时期参数值是什么，模型训练都将停止。 这是默认设置。</para>
		/// <para>未选中 - 模型训练将一直持续，直至达到最大时期参数值为止。</para>
		/// <para><see cref="StopTrainingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? StopTraining { get; set; } = "true";

		/// <summary>
		/// <para>Make model backbone trainable</para>
		/// <para>指定是否冻结预训练模型中的骨干层，以使权重和偏差保持原始设计。</para>
		/// <para>选中 - 不会冻结骨干图层，模型骨干参数值的权重和偏差可能会进行更改以更好地适合您的训练样本。 这将需要花费更多的时间来处理，但通常会产生更好的结果。 这是默认设置。</para>
		/// <para>未选中 - 将冻结骨干图层，在训练过程中不会更改预定义的模型骨干参数值的权重和偏差。</para>
		/// <para><see cref="MakeTrainableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? MakeTrainable { get; set; } = "true";

		/// <summary>
		/// <para>Remove HTML Tags</para>
		/// <para>指定是否将从输入文本中移除 HTML 标签。</para>
		/// <para>选中 - 输入文本中的 HTML 标签将被移除。 这是默认设置。</para>
		/// <para>未选中 - 输入文本中的 HTML 标签不会被移除。</para>
		/// <para><see cref="RemoveHtmlTagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? RemoveHtmlTags { get; set; } = "true";

		/// <summary>
		/// <para>Remove URLs</para>
		/// <para>指定是否将从输入文本中移除 URL。</para>
		/// <para>选中 - 输入文本中的 URL 将被移除。 这是默认设置。</para>
		/// <para>未选中 - 输入文本中的 URL 不会被移除。</para>
		/// <para><see cref="RemoveUrlsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? RemoveUrls { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainTextTransformationModel SetEnviroment(object? processorType = null)
		{
			base.SetEnv(processorType: processorType);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Stop when model stops improving</para>
		/// </summary>
		public enum StopTrainingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("STOP_TRAINING")]
			STOP_TRAINING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONTINUE_TRAINING")]
			CONTINUE_TRAINING,

		}

		/// <summary>
		/// <para>Make model backbone trainable</para>
		/// </summary>
		public enum MakeTrainableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRAIN_MODEL_BACKBONE")]
			TRAIN_MODEL_BACKBONE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FREEZE_MODEL_BACKBONE")]
			FREEZE_MODEL_BACKBONE,

		}

		/// <summary>
		/// <para>Remove HTML Tags</para>
		/// </summary>
		public enum RemoveHtmlTagsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_HTML_TAGS")]
			REMOVE_HTML_TAGS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REMOVE_HTML_TAGS")]
			DO_NOT_REMOVE_HTML_TAGS,

		}

		/// <summary>
		/// <para>Remove URLs</para>
		/// </summary>
		public enum RemoveUrlsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_URLS")]
			REMOVE_URLS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REMOVE_URLS")]
			DO_NOT_REMOVE_URLS,

		}

#endregion
	}
}
