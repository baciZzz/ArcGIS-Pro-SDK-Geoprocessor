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
	/// <para>Train Text Classification Model</para>
	/// <para>Train Text Classification Model</para>
	/// <para>Trains a text classification model to assign a predefined category or label to  unstructured text.</para>
	/// </summary>
	public class TrainTextClassificationModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>A feature class or table containing a text field with the input text for the model and a label field containing the target class labels.</para>
		/// </param>
		/// <param name="TextField">
		/// <para>Text Field</para>
		/// <para>A text field in the input feature class or table that contains the input text that will be classified by the model.</para>
		/// </param>
		/// <param name="LabelField">
		/// <para>Label Field</para>
		/// <para>A text field in the input feature class or table that contains the target class labels for training the model.</para>
		/// </param>
		/// <param name="OutModel">
		/// <para>Output Model</para>
		/// <para>The output folder location that will store the trained model.</para>
		/// </param>
		public TrainTextClassificationModel(object InTable, object TextField, object LabelField, object OutModel)
		{
			this.InTable = InTable;
			this.TextField = TextField;
			this.LabelField = LabelField;
			this.OutModel = OutModel;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Text Classification Model</para>
		/// </summary>
		public override string DisplayName() => "Train Text Classification Model";

		/// <summary>
		/// <para>Tool Name : TrainTextClassificationModel</para>
		/// </summary>
		public override string ToolName() => "TrainTextClassificationModel";

		/// <summary>
		/// <para>Tool Excute Name : geoai.TrainTextClassificationModel</para>
		/// </summary>
		public override string ExcuteName() => "geoai.TrainTextClassificationModel";

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
		/// <para>A feature class or table containing a text field with the input text for the model and a label field containing the target class labels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Text Field</para>
		/// <para>A text field in the input feature class or table that contains the input text that will be classified by the model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object TextField { get; set; }

		/// <summary>
		/// <para>Label Field</para>
		/// <para>A text field in the input feature class or table that contains the target class labels for training the model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LabelField { get; set; }

		/// <summary>
		/// <para>Output Model</para>
		/// <para>The output folder location that will store the trained model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutModel { get; set; }

		/// <summary>
		/// <para>Pretrained Model File</para>
		/// <para>A pretrained model that will be used to fine-tune the new model. The input can be an Esri model definition file (.emd) or a deep learning package file (.dlpk).</para>
		/// <para>A pretrained model with similar classes can be fine-tuned to fit the new model. The pretrained model must have been trained with the same model type and backbone model that will be used to train the new model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object? PretrainedModelFile { get; set; }

		/// <summary>
		/// <para>Max Epochs</para>
		/// <para>The maximum number of epochs for which the model will be trained. A maximum epoch value of 1 means the dataset will be passed forward and backward through the neural network one time. The default value is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxEpochs { get; set; } = "5";

		/// <summary>
		/// <para>Model Backbone</para>
		/// <para>Specifies the preconfigured neural network that will serve as the encoder for the model and extract feature representations of the input text in the form of fixed length vectors. These vectors are then passed as input to the classification head of the model.</para>
		/// <para>bert-base-cased—The model will be trained using the BERT neural network. BERT is pretrained using the masked language modeling objective and next sentence prediction.</para>
		/// <para>roberta-base— The model will be trained using the RoBERTa neural network. RoBERTa modifies the key hyperparameters of BERT, eliminating the pretraining objective and training of the next sentence with small batches and higher learning rates.</para>
		/// <para>albert-base-v1—The model will be trained using the ALBERT neural network. ALBERT uses a self-supervised loss that focuses on modeling intersentence coherence, resulting in better scalability than BERT.</para>
		/// <para>xlnet-base-cased—The model will be trained using the XLNet neural network. XLNet is a generalized autoregressive pretraining method. It allows learning bidirectional contexts by maximizing the expected probability on all permutations of the factorization order, which overcomes BERT&apos;s drawbacks.</para>
		/// <para>xlm-roberta-base—The model will be trained using the XLM-RoBERTa neural network. XLM-RoBERTa is a multilingual model trained on 100 different languages. Unlike some XLM multilingual models, it does not require language tensors to understand which language is used and identifies the correct language from the input IDs.</para>
		/// <para>distilroberta-base—The model will be trained using the DistilRoBERTa neural network. DistilRoBERTa is an English language model pretrained with the supervision of roberta-base solely on OpenWebTextCorpus, a reproduction of OpenAI&apos;s WebText dataset.</para>
		/// <para>distilbert-base-cased—The model will be trained using the DistilBERT neural network. DistilBERT is a smaller general-purpose language representation model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Model Parameters")]
		public object? ModelBackbone { get; set; } = "bert-base-cased";

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>The number of training samples that will be processed at one time. The default value is 2.</para>
		/// <para>Increasing the batch size can improve tool performance; however, as the batch size increases, more memory is used. If an out of memory error occurs, use a smaller batch size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Model Parameters")]
		public object? BatchSize { get; set; } = "2";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>Additional arguments for initializing the model, such as seq_len for the maximum sequence length of the training data, that will be considered for training the model.</para>
		/// <para>See keyword arguments in the TextClassifier documentation for the list of supported models arguments that can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Model Parameters")]
		public object? ModelArguments { get; set; } = "sequence_length 512";

		/// <summary>
		/// <para>Learning Rate</para>
		/// <para>The step size indicating how much the model weights will be adjusted during the training process. If no value is specified, an optimal learning rate will be deduced automatically.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? LearningRate { get; set; }

		/// <summary>
		/// <para>Validation Percentage</para>
		/// <para>The percentage of training samples that will be used for validating the model. The default value is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? ValidationPercentage { get; set; } = "10";

		/// <summary>
		/// <para>Stop when model stops improving</para>
		/// <para>Specifies whether model training will stop when the model is no longer improving or until the Max Epochs parameter value is reached.</para>
		/// <para>Checked—The model training will stop when the model is no longer improving, regardless of the Max Epochs parameter value specified. This is the default.</para>
		/// <para>Unchecked—The model training will continue until the Max Epochs parameter value is reached.</para>
		/// <para><see cref="StopTrainingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? StopTraining { get; set; } = "true";

		/// <summary>
		/// <para>Make model backbone trainable</para>
		/// <para>Specifies whether the backbone layers in the pretrained model will be frozen, so that the weights and biases remain as originally designed.</para>
		/// <para>Checked—The backbone layers will not be frozen, and the weights and biases of the Model Backbone parameter value can be altered to fit the training samples. This takes more time to process but typically produces better results. This is the default.</para>
		/// <para>Unchecked—The backbone layers will be frozen, and the predefined weights and biases of the Model Backbone parameter value will not be altered during training.</para>
		/// <para><see cref="MakeTrainableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? MakeTrainable { get; set; } = "true";

		/// <summary>
		/// <para>Remove HTML Tags</para>
		/// <para>Specifies whether HTML tags will be removed from the input text.</para>
		/// <para>Checked—The HTML tags in the input text will be removed. This is the default.</para>
		/// <para>Unchecked—The HTML tags in the input text will not be removed.</para>
		/// <para><see cref="RemoveHtmlTagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? RemoveHtmlTags { get; set; } = "true";

		/// <summary>
		/// <para>Remove URLs</para>
		/// <para>Specifies whether URLs will be removed from the input text.</para>
		/// <para>Checked—The URLs in the input text will be removed. This is the default.</para>
		/// <para>Unchecked—The URLs in the input text will not be removed.</para>
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
		public TrainTextClassificationModel SetEnviroment(object? processorType = null )
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
			/// <para>Checked—The model training will stop when the model is no longer improving, regardless of the Max Epochs parameter value specified. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("STOP_TRAINING")]
			STOP_TRAINING,

			/// <summary>
			/// <para>Unchecked—The model training will continue until the Max Epochs parameter value is reached.</para>
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
			/// <para>Checked—The backbone layers will not be frozen, and the weights and biases of the Model Backbone parameter value can be altered to fit the training samples. This takes more time to process but typically produces better results. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRAIN_MODEL_BACKBONE")]
			TRAIN_MODEL_BACKBONE,

			/// <summary>
			/// <para>Unchecked—The backbone layers will be frozen, and the predefined weights and biases of the Model Backbone parameter value will not be altered during training.</para>
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
			/// <para>Checked—The HTML tags in the input text will be removed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_HTML_TAGS")]
			REMOVE_HTML_TAGS,

			/// <summary>
			/// <para>Unchecked—The HTML tags in the input text will not be removed.</para>
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
			/// <para>Checked—The URLs in the input text will be removed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_URLS")]
			REMOVE_URLS,

			/// <summary>
			/// <para>Unchecked—The URLs in the input text will not be removed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REMOVE_URLS")]
			DO_NOT_REMOVE_URLS,

		}

#endregion
	}
}
