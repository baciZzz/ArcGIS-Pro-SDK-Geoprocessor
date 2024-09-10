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
	/// <para>Train Deep Learning Model</para>
	/// <para>Trains a deep learning model using the output from the Export Training Data For Deep Learning tool.</para>
	/// </summary>
	public class TrainDeepLearningModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Input Training Data</para>
		/// <para>The folder containing the image chips, labels, and statistics required to train the model. This is the output from the Export Training Data For Deep Learning tool.</para>
		/// <para>To train a model, the input images must be 8-bit rasters with three bands.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Model</para>
		/// <para>The output folder location that will store the trained model.</para>
		/// </param>
		public TrainDeepLearningModel(object InFolder, object OutFolder)
		{
			this.InFolder = InFolder;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Deep Learning Model</para>
		/// </summary>
		public override string DisplayName() => "Train Deep Learning Model";

		/// <summary>
		/// <para>Tool Name : TrainDeepLearningModel</para>
		/// </summary>
		public override string ToolName() => "TrainDeepLearningModel";

		/// <summary>
		/// <para>Tool Excute Name : ia.TrainDeepLearningModel</para>
		/// </summary>
		public override string ExcuteName() => "ia.TrainDeepLearningModel";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "gpuID", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFolder, OutFolder, MaxEpochs, ModelType, BatchSize, Arguments, LearningRate, BackboneModel, PretrainedModel, ValidationPercentage, StopTraining, OutModelFile, Freeze };

		/// <summary>
		/// <para>Input Training Data</para>
		/// <para>The folder containing the image chips, labels, and statistics required to train the model. This is the output from the Export Training Data For Deep Learning tool.</para>
		/// <para>To train a model, the input images must be 8-bit rasters with three bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Output Model</para>
		/// <para>The output folder location that will store the trained model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Max Epochs</para>
		/// <para>The maximum number of epochs for which the model will be trained. A maximum epoch of one means the dataset will be passed forward and backward through the neural network one time. The default value is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxEpochs { get; set; } = "20";

		/// <summary>
		/// <para>Model Type</para>
		/// <para>Specifies the model type that will be used to train the deep learning model.</para>
		/// <para>Single Shot Detector (Object detection)—The Single Shot Detector (SSD) approach will be used to train the model. SSD is used for object detection. The input training data for this model type uses the Pascal Visual Object Classes metadata format.</para>
		/// <para>U-Net (Pixel classification)—The U-Net approach will be used to train the model. U-Net is used for pixel classification.</para>
		/// <para>Feature classifier (Object classification)—The Feature Classifier approach will be used to train the model. This is used for object or image classification.</para>
		/// <para>Pyramid Scene Parsing Network (Pixel classification)—The Pyramid Scene Parsing Network (PSPNET) approach will be used to train the model. PSPNET is used for pixel classification.</para>
		/// <para>RetinaNet (Object detection)—The RetinaNet approach will be used to train the model. RetinaNet is used for object detection. The input training data for this model type uses the Pascal Visual Object Classes metadata format.</para>
		/// <para>MaskRCNN (Object detection)—The MaskRCNN approach will be used to train the model. MaskRCNN is used for object detection. This approach is used for instance segmentation, which is precise delineation of objects in an image. This model type can be used to detect building footprints. It uses the MaskRCNN metadata format for training data as input. Class values for input training data must start at 1. This model type can only be trained using a CUDA-enabled GPU.</para>
		/// <para>YOLOv3 (Object detection)—The YOLOv3 approach will be used to train the model. YOLOv3 is used for object detection.</para>
		/// <para>DeepLabV3 (Pixel classification)—The DeepLabV3 approach will be used to train the model. DeepLab is used for pixel classification.</para>
		/// <para>FasterRCNN (Object detection)—The FasterRCNN approach will be used to train the model. FasterRCNN is used for object detection.</para>
		/// <para>BDCN Edge Detector (Pixel classification)— The Bi-Directional Cascade Network (BDCN) architecture will be used to train the model. The BDCN Edge Detector is used for pixel classification. This approach is useful to improve edge detection for objects at different scales.</para>
		/// <para>HED Edge Detector (Pixel classification)— The Holistically-Nested Edge Detection (HED) architecture will be used to train the model. The HED Edge Detector is used for pixel classification. This approach is useful to in edge and object boundary detection.</para>
		/// <para>Multi Task Road Extractor (Pixel classification)— The Multi Task Road Extractor architecture will be used to train the model. The Multi Task Road Extractor is used for pixel classification. This approach is useful for road network extraction from satellite imagery.</para>
		/// <para>ConnectNet (Pixel classification)—The ConnectNet architecture will be used to train the model. ConnectNet is used for pixel classification. This approach is useful for road network extraction from satellite imagery.</para>
		/// <para>Pix2Pix (Image translation)—The Pix2Pix approach will be used to train the model. Pix2Pix is used for image to image translation. This approach creates a model object that generates images of one type to another. The input training data for this model type uses the Export Tiles metadata format.</para>
		/// <para>CycleGAN (Image translation)—The CycleGAN approach will be used to train the model. CycleGAN is used for image-to-image translation. This approach creates a model object that generates images of one type to another. This approach is unique in that the images to be trained do not need to overlap. The input training data for this model type uses the CycleGAN metadata format.</para>
		/// <para>Super-resolution (Image translation)—The super-resolution approach will be used to train the model. Super-resolution is used for image-to-image translation. This approach creates a model object that increases the resolution and improves the quality of images. The input training data for this model type uses the Export Tiles metadata format.</para>
		/// <para>Change detector (Pixel Classification)—The Change Detector approach will be used to train the model. Change Detector is used for pixel classification. This approach creates a model object that uses two spatial-temporal images to create a classified raster of the change. The input training data for this model type uses the Classified Tiles metadata format.</para>
		/// <para>Image captioner (Image Translation)—The Image Captioner approach will be used to train the model. Image Captioner is used for image-to-text translation. This approach creates a model that generates text captions for an image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Model Parameters")]
		public object ModelType { get; set; }

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>The number of training samples to be processed for training at one time. The default value is 2.</para>
		/// <para>If you have a powerful GPU, this number can be increased to 8, 16, 32, or 64.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Model Parameters")]
		public object BatchSize { get; set; } = "64";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>The function arguments are defined in the Python raster function class. This is where you list additional deep learning parameters and arguments for experiments and refinement, such as a confidence threshold for adjusting sensitivity. The names of the arguments are populated from reading the Python module.</para>
		/// <para>When you choose Single Shot Detector as the Model Type parameter value, the Model Arguments parameter will be populated with the following arguments:</para>
		/// <para>grids—The number of grids the image will be divided into for processing. Setting this argument to 4 means the image will be divided into 4 x 4 or 16 grid cells. If no value is specified, the optimal grid value will be calculated based on the input imagery.</para>
		/// <para>zooms—The number of zoom levels each grid cell will be scaled up or down. Setting this argument to 1 means all the grid cells will remain at the same size or zoom level. A zoom level of 2 means all the grid cells will become twice as large (zoomed in 100 percent). Providing a list of zoom levels means all the grid cells will be scaled using all the numbers in the list. The default is 1.0.</para>
		/// <para>ratios—The list of aspect ratios to use for the anchor boxes. In object detection, an anchor box represents the ideal location, shape, and size of the object being predicted. Setting this argument to [1.0,1.0], [1.0, 0.5] means the anchor box is a square (1:1) or a rectangle in which the horizontal side is half the size of the vertical side (1:0.5). The default is [1.0, 1.0].</para>
		/// <para>When you choose a pixel classification model such as Pyramid Scene Parsing Network, U-Net, or DeepLabv3 as the Model Type parameter value, the Model Arguments parameter will be populated with the following arguments:</para>
		/// <para>use_net—Specifies whether the U-Net decoder will be used to recover data once the pyramid pooling is complete. The default is True. This argument is specific to the Pyramid Scene Parsing Network model.</para>
		/// <para>pyramid_sizes—The number and size of convolution layers to be applied to the different subregions. The default is [1,2,3,6]. This argument is specific to the Pyramid Scene Parsing Network model.</para>
		/// <para>mixup—Specifies whether mixup augmentation and mixup loss will be used. The default is False.</para>
		/// <para>class_balancing—Specifies whether the cross-entropy loss inverse will be balanced to the frequency of pixels per class. The default is False.</para>
		/// <para>focal_loss—Specifies whether focal loss will be used. The default is False.</para>
		/// <para>ignore_classes—Contains the list of class values on which the model will not incur loss.</para>
		/// <para>When you choose RetinaNet as the Model Type parameter value, the Model Arguments parameter will be populated with the following arguments:</para>
		/// <para>scales—The number of scale levels each cell will be scaled up or down. The default is [1, 0.8, 0.63].</para>
		/// <para>ratios—The aspect ratio of the anchor box. The default is 0.5,1,2.</para>
		/// <para>When you choose Multi Task Road Extractor or ConnectNet as the Model Type parameter value, the Model Arguments parameter will be populated with the following arguments:</para>
		/// <para>gaussian_thresh—Sets the Gaussian threshold, which sets the required road width. The valid range is 0.0 to 1.0. The default is 0.76.</para>
		/// <para>orient_bin_size—Sets the bin size for orientation angles. The default is 20.</para>
		/// <para>orient_theta—Sets the width of orientation mask. The default is 8.</para>
		/// <para>mtl_model—Sets the architecture type that will be used to create the model. Valid choices are linknet or hourglass for linknet-based or hourglass-based, respectively, neural architectures. The default is hourglass.</para>
		/// <para>When you choose Image Captioner as the Model Type parameter value, the Model Arguments parameter will be populated with the following arguments:The decode_params, are comprised of the following six parameters:</para>
		/// <para>decode_params—A dictionary that controls how the Image Captioner will run. The default value is {&apos;embed_size&apos;:100, &apos;hidden_size&apos;:100, &apos;attention_size&apos;:100, &apos;teacher_forcing&apos;:1, &apos;dropout&apos;:0.1, &apos;pretrained_emb&apos;:False}.</para>
		/// <para>chip_size—Sets the size of image to train the model. Images are cropped to the specified chip size. If image size is less than chip size, the image size is used. The default size is 224 pixels.</para>
		/// <para>embed_size—Sets the embedding size. The default is 100 layers in the neural network.</para>
		/// <para>hidden_size—Sets the hidden layer size. The default is 100 layers in the neural network.</para>
		/// <para>attention_size—Sets the intermediate attention layer size . The default is 100 layers in the neural network.</para>
		/// <para>teacher_forcing—Sets the probability of teacher forcing. Teacher forcing is a strategy for training recurrent neural networks that uses model output from a prior time step as an input, instead of the previous output, during back propagation. Valid ranges is from 0.0 to 1.0. The default is 1.</para>
		/// <para>dropout—Sets the dropout probability. Valid ranges is from 0.0 to 1.0. The default is 0.1.</para>
		/// <para>pretrained_emb—Sets the pretrained embedding flag. If True, it will use fast text embedding. If False, it will not use the pretrained text embedding. The default is False.</para>
		/// <para>When you choose Change Detector as the Model Type parameter value, the Model Arguments parameter will be populated with the following argument:</para>
		/// <para>attention_type—Specifies the module type. The module choices are PAM (Pyramid Attention Module) or BAM (Basic Attention Module). The default is PAM.</para>
		/// <para>All model types support the chip_size argument, which is the image chip size of the training samples. The image chip size is extracted from the .emd file from the folder specified in the Input Training Data parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Model Parameters")]
		public object Arguments { get; set; }

		/// <summary>
		/// <para>Learning Rate</para>
		/// <para>The rate at which existing information will be overwritten with newly acquired information throughout the training process. If no value is specified, the optimal learning rate will be extracted from the learning curve during the training process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object LearningRate { get; set; }

		/// <summary>
		/// <para>Backbone Model</para>
		/// <para>Specifies the preconfigured neural network that will be used as the architecture for training the new model. This method is known as Transfer Learning.</para>
		/// <para>DenseNet-121—The preconfigured model will be a dense network trained on the ImageNET Dataset that contains more than 1 million images and is 121 layers deep. Unlike RESNET, which combines the layer using summation, DenseNet combines the layers using concatenation.</para>
		/// <para>DenseNet-161—The preconfigured model will be a dense network trained on the ImageNET Dataset that contains more than 1 million images and is 161 layers deep. Unlike RESNET, which combines the layer using summation, DenseNet combines the layers using concatenation.</para>
		/// <para>DenseNet-169—The preconfigured model will be a dense network trained on the ImageNET Dataset that contains more than 1 million images and is 169 layers deep. Unlike RESNET, which combines the layer using summation, DenseNet combines the layers using concatenation.</para>
		/// <para>DenseNet-201—The preconfigured model will be a dense network trained on the ImageNET Dataset that contains more than 1 million images and is 201 layers deep. Unlike RESNET, which combines the layer using summation, DenseNet combines the layers using concatenation.</para>
		/// <para>MobileNet version 2—This preconfigured model will be trained on the ImageNet Database and is 54 layers deep geared toward Edge device computing, since it uses less memory.</para>
		/// <para>ResNet-18—The preconfigured model will be a residual network trained on the ImageNET Dataset that contains more than million images and is 18 layers deep.</para>
		/// <para>ResNet-34—The preconfigured model will be a residual network trained on the ImageNET Dataset that contains more than 1 million images and is 34 layers deep. This is the default.</para>
		/// <para>ResNet-50—The preconfigured model will be a residual network trained on the ImageNET Dataset that contains more than 1 million images and is 50 layers deep.</para>
		/// <para>ResNet-101—The preconfigured model will be a residual network trained on the ImageNET Dataset that contains more than 1 million images and is 101 layers deep.</para>
		/// <para>ResNet-152—The preconfigured model will be a residual network trained on the ImageNET Dataset that contains more than 1 million images and is 152 layers deep.</para>
		/// <para>VGG-11—The preconfigured model will be a convolution neural network trained on the ImageNET Dataset that contains more than 1 million images to classify images into 1,000 object categories and is 11 layers deep.</para>
		/// <para>VGG-11 with batch normalization—This preconfigured model will be based on the VGG network but with batch normalization, which means each layer in the network is normalized. It trained on the ImageNet dataset and has 11 layers.</para>
		/// <para>VGG-13—The preconfigured model will be a convolution neural network trained on the ImageNET Dataset that contains more than 1 million images to classify images into 1,000 object categories and is 13 layers deep.</para>
		/// <para>VGG-13 with batch normalization—This preconfigured model will be based on the VGG network but with batch normalization, which means each layer in the network is normalized. It trained on the ImageNet dataset and has 13 layers.</para>
		/// <para>VGG-16—The preconfigured model will be a convolution neural network trained on the ImageNET Dataset that contains more than 1 million images to classify images into 1,000 object categories and is 16 layers deep.</para>
		/// <para>VGG-16 with batch normalization—This preconfigured model will be based on the VGG network but with batch normalization, which means each layer in the network is normalized. It trained on the ImageNet dataset and has 16 layers.</para>
		/// <para>VGG-19—The preconfigured model will be a convolution neural network trained on the ImageNET Dataset that contains more than 1 million images to classify images into 1,000 object categories and is 19 layers deep.</para>
		/// <para>VGG-19 with batch normalization—This preconfigured model will be based on the VGG network but with batch normalization, which means each layer in the network is normalized. It trained on the ImageNet dataset and has 19 layers.</para>
		/// <para>DarkNet-53—The preconfigured model will be a convolution neural network trained on the ImageNET Dataset that contains more than 1 million images and is 53 layers deep.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object BackboneModel { get; set; }

		/// <summary>
		/// <para>Pre-trained Model</para>
		/// <para>A pretrained model that will be used to fine-tune the new model. The input is an Esri Model Definition file (.emd) or a deep learning package file (.dlpk).</para>
		/// <para>A pretrained model with similar classes can be fine-tuned to fit the new model. The pretrained model must have been trained with the same model type and backbone model that will be used to train the new model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		[Category("Advanced")]
		public object PretrainedModel { get; set; }

		/// <summary>
		/// <para>Validation %</para>
		/// <para>The percentage of training samples that will be used for validating the model. The default value is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object ValidationPercentage { get; set; } = "10";

		/// <summary>
		/// <para>Stop when model stops improving</para>
		/// <para>Specifies whether early stopping will be implemented.</para>
		/// <para>Checked—Early stopping will be implemented, and the model training will stop when the model is no longer improving, regardless of the Max Epochs parameter value specified. This is the default.</para>
		/// <para>Unchecked—Early stopping will not be implemented, and the model training will continue until the Max Epochs parameter value is reached.</para>
		/// <para><see cref="StopTrainingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object StopTraining { get; set; } = "true";

		/// <summary>
		/// <para>Output Model</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutModelFile { get; set; }

		/// <summary>
		/// <para>Freeze Model</para>
		/// <para>Specifies whether the backbone layers in the pretrained model will be frozen, so that the weights and biases remain as originally designed.</para>
		/// <para>Checked—The backbone layers will be frozen, and the predefined weights and biases will not be altered in the Backbone Model parameter. This is the default.</para>
		/// <para>Unchecked—The backbone layers will not be frozen, and the weights and biases of the Backbone Model parameter can be altered to fit the training samples. This takes more time to process but typically produces better results.</para>
		/// <para><see cref="FreezeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object Freeze { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainDeepLearningModel SetEnviroment(object extent = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Stop when model stops improving</para>
		/// </summary>
		public enum StopTrainingEnum 
		{
			/// <summary>
			/// <para>Checked—Early stopping will be implemented, and the model training will stop when the model is no longer improving, regardless of the Max Epochs parameter value specified. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("STOP_TRAINING")]
			STOP_TRAINING,

			/// <summary>
			/// <para>Unchecked—Early stopping will not be implemented, and the model training will continue until the Max Epochs parameter value is reached.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CONTINUE_TRAINING")]
			CONTINUE_TRAINING,

		}

		/// <summary>
		/// <para>Freeze Model</para>
		/// </summary>
		public enum FreezeEnum 
		{
			/// <summary>
			/// <para>Checked—The backbone layers will be frozen, and the predefined weights and biases will not be altered in the Backbone Model parameter. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FREEZE_MODEL")]
			FREEZE_MODEL,

			/// <summary>
			/// <para>Unchecked—The backbone layers will not be frozen, and the weights and biases of the Backbone Model parameter can be altered to fit the training samples. This takes more time to process but typically produces better results.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UNFREEZE_MODEL")]
			UNFREEZE_MODEL,

		}

#endregion
	}
}
