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
	/// <para>Train Entity Recognition Model</para>
	/// <para>训练实体识别模型</para>
	/// <para>训练指定实体识别模型以从原始文本中提取一组预定义的实体。</para>
	/// </summary>
	public class TrainEntityRecognitionModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Input Folder</para>
		/// <para>包含 NER 任务标准数据集形式的训练数据的文件夹。 训练数据必须为 .json 或 .csv 文件。 文件格式将决定输入的数据集类型。</para>
		/// <para>受支持的数据集类型如下：</para>
		/// <para>ner_json - 训练数据文件夹应包含一个 .json 文件，其中包含使用 spaCy JSON 训练格式格式的文本和标注实体。</para>
		/// <para>IOB——Ramshaw 和 Marcus 在论文 Text Chunking using Transformation-Based Learning 中提出的 IOB（I - 内部，O - 外部，B - 开始标签）格式。训练数据文件夹应包含以下两个 .csv 文件：</para>
		/// <para>token.csv - 包含作为输入区段的文本。</para>
		/// <para>tags.csv - 包含文本区段的 IOB 标签。</para>
		/// <para>BILUO - IOB 格式的扩展名，另外包含“&apos;L - 最后”和“U - 单位”标签。训练数据文件夹应包含以下两个 .csv 文件：</para>
		/// <para>token.csv - 包含作为输入区段的文本。</para>
		/// <para>tags.csv - 包含文本区段的 BILUO 标签。</para>
		/// </param>
		/// <param name="OutModel">
		/// <para>Output Model</para>
		/// <para>将存储经训练模型的输出文件夹位置。</para>
		/// </param>
		public TrainEntityRecognitionModel(object InFolder, object OutModel)
		{
			this.InFolder = InFolder;
			this.OutModel = OutModel;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练实体识别模型</para>
		/// </summary>
		public override string DisplayName() => "训练实体识别模型";

		/// <summary>
		/// <para>Tool Name : TrainEntityRecognitionModel</para>
		/// </summary>
		public override string ToolName() => "TrainEntityRecognitionModel";

		/// <summary>
		/// <para>Tool Excute Name : geoai.TrainEntityRecognitionModel</para>
		/// </summary>
		public override string ExcuteName() => "geoai.TrainEntityRecognitionModel";

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
		public override object[] Parameters() => new object[] { InFolder, OutModel, PretrainedModelFile!, AddressEntity!, MaxEpochs!, ModelBackbone!, BatchSize!, ModelArguments!, LearningRate!, ValidationPercentage!, StopTraining!, MakeTrainable! };

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>包含 NER 任务标准数据集形式的训练数据的文件夹。 训练数据必须为 .json 或 .csv 文件。 文件格式将决定输入的数据集类型。</para>
		/// <para>受支持的数据集类型如下：</para>
		/// <para>ner_json - 训练数据文件夹应包含一个 .json 文件，其中包含使用 spaCy JSON 训练格式格式的文本和标注实体。</para>
		/// <para>IOB——Ramshaw 和 Marcus 在论文 Text Chunking using Transformation-Based Learning 中提出的 IOB（I - 内部，O - 外部，B - 开始标签）格式。训练数据文件夹应包含以下两个 .csv 文件：</para>
		/// <para>token.csv - 包含作为输入区段的文本。</para>
		/// <para>tags.csv - 包含文本区段的 IOB 标签。</para>
		/// <para>BILUO - IOB 格式的扩展名，另外包含“&apos;L - 最后”和“U - 单位”标签。训练数据文件夹应包含以下两个 .csv 文件：</para>
		/// <para>token.csv - 包含作为输入区段的文本。</para>
		/// <para>tags.csv - 包含文本区段的 BILUO 标签。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

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
		/// <para>可以对具有相似实体的预训练模型进行微调以适应新模型。 预训练模型必须已使用将用于训练新模型的相同模型类型和骨干模型进行了训练。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object? PretrainedModelFile { get; set; }

		/// <summary>
		/// <para>Address Entity</para>
		/// <para>地址实体将被视为一个位置。 在推断过程中，将使用指定的定位器对此类实体进行地理编码，并且将生成实体提取过程的结果要素类。 如果未提供定位器或训练模型未提取地址实体，则会生成包含提取实体的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AddressEntity { get; set; }

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
		/// <para>bert-base-cased—该模型将使用 BERT 神经网络进行训练。 BERT 将使用已掩膜语言建模目标和下一句预测进行预训练。</para>
		/// <para>roberta-base—该模型将使用 RoBERTa 神经网络进行训练。 RoBERTa 将修改 BERT 的关键超参数，并消除预训练目标以及小批量和更高学习率的下一句训练。</para>
		/// <para>albert-base-v1—该模型将使用 ALBERT 神经网络进行训练。 ALBERT 将使用一种专注于对句子间一致性进行建模的自监督损失，因而比 BERT 具有更好的可扩展性。</para>
		/// <para>xlnet-base-cased—该模型将使用 XLNet 神经网络进行训练。 XLNet 是一种广义自回归预训练方法。 该方法允许通过最大限度提升分解顺序的所有排列的预期概率来学习双向上下文，从而克服了 BERT 的缺点。</para>
		/// <para>xlm-roberta-base—该模型将使用 XLM-RoBERTa 神经网络进行训练。 XLM-RoBERTa 是一种针对 100 种不同语言训练的多语言模型。 与某些 XLM 多语言模型不同，该模型不需要依靠语言张量来了解所使用的是哪种语言，并可根据输入 ID 来识别正确的语言。</para>
		/// <para>distilroberta-base—DistilRoBERTa 是一种英语语言模型，仅在 OpenWebTextCorpus 上由 roberta-base 监督进行预训练（OpenWebTextCorpus 是 OpenAI 的 WebText 数据集的复制品）。</para>
		/// <para>distilbert-base-cased—该模型将使用 DistilBERT 神经网络进行训练。 DistilBERT 是一种较小的通用语言表示模型。</para>
		/// <para>spacy—该模型将使用 SpaCy 神经网络进行训练。 SpaCy 是一个用于高级自然语言处理的开源库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Model Parameters")]
		public object? ModelBackbone { get; set; } = "spacy";

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>一次需要处理的训练样本数。 此参数不适用于具有 spaCy 骨干的模型。 默认值为 2。</para>
		/// <para>增加批处理大小可以提高工具性能；但是，随着批处理大小的增加，会占用更多内存。 如果发生内存不足错误，请使用较小的批处理大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Model Parameters")]
		public object? BatchSize { get; set; } = "2";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>用于初始化模型的其他参数（例如，用于训练数据的最大序列长度的 seq_len）将被考虑用于训练模型。</para>
		/// <para>有关可以使用的受支持模型参数列表，请参阅 EntityRecognizer 文档中的关键字参数。</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainEntityRecognitionModel SetEnviroment(object? processorType = null )
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

#endregion
	}
}
