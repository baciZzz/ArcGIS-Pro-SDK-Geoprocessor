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
	/// <para>训练深度学习模型</para>
	/// <para>使用导出训练数据进行深度学习工具的输出训练深度学习模型。</para>
	/// </summary>
	public class TrainDeepLearningModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Input Training Data</para>
		/// <para>包含训练模型所需的影像片、标注和统计数据的文件夹。 此数据为导出训练数据进行深度学习工具的输出。</para>
		/// <para>当满足以下条件时，支持多个输入文件夹：</para>
		/// <para>元数据格式必须是以下格式之一：分类切片、标注切片、多标注切片、PASCAL 视觉对象类或 RCNN 掩码。</para>
		/// <para>所有训练数据必须具有相同的元数据格式。</para>
		/// <para>所有训练数据必须具有相同的波段数。</para>
		/// <para>所有训练数据必须具有相同的切片大小。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Model</para>
		/// <para>将存储经训练模型的输出文件夹位置。</para>
		/// </param>
		public TrainDeepLearningModel(object InFolder, object OutFolder)
		{
			this.InFolder = InFolder;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 训练深度学习模型</para>
		/// </summary>
		public override string DisplayName() => "训练深度学习模型";

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
		public override string[] ValidEnvironments() => new string[] { "gpuID", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFolder, OutFolder, MaxEpochs!, ModelType!, BatchSize!, Arguments!, LearningRate!, BackboneModel!, PretrainedModel!, ValidationPercentage!, StopTraining!, OutModelFile!, Freeze! };

		/// <summary>
		/// <para>Input Training Data</para>
		/// <para>包含训练模型所需的影像片、标注和统计数据的文件夹。 此数据为导出训练数据进行深度学习工具的输出。</para>
		/// <para>当满足以下条件时，支持多个输入文件夹：</para>
		/// <para>元数据格式必须是以下格式之一：分类切片、标注切片、多标注切片、PASCAL 视觉对象类或 RCNN 掩码。</para>
		/// <para>所有训练数据必须具有相同的元数据格式。</para>
		/// <para>所有训练数据必须具有相同的波段数。</para>
		/// <para>所有训练数据必须具有相同的切片大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Output Model</para>
		/// <para>将存储经训练模型的输出文件夹位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Max Epochs</para>
		/// <para>将用于训练模型的最大时期数。 最大新时期值为 1 意味着数据集将通过神经网络向前和向后传递一次。 默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxEpochs { get; set; } = "20";

		/// <summary>
		/// <para>Model Type</para>
		/// <para>指定将用于训练深度学习模型的模型类型。</para>
		/// <para>单帧检测器（对象检测）—单帧检测器 (SSD) 方法将用于训练模型。 SSD 将用于对象检测。 该模型类型的输入训练数据使用 Pascal 可视化对象类元数据格式。</para>
		/// <para>U-Net（像素分类）—U-Net 方法将用于训练模型。 U-Net 用于像素分类。</para>
		/// <para>要素分类器（对象分类）—“要素分类器”方法将用于训练模型。 可将其用于对象或图像分类。</para>
		/// <para>金字塔场景解析网络（像素分类）—金字塔场景解析网络 (PSPNET) 方法将用于训练模型。 PSPNET 用于像素分类。</para>
		/// <para>RetinaNet（对象检测）—RetinaNet 方法将用于训练模型。 RetinaNet 将用于对象检测。 该模型类型的输入训练数据使用 Pascal 可视化对象类元数据格式。</para>
		/// <para>MaskRCNN（对象检测）—MaskRCNN 方法将用于训练模型。 MaskRCNN 将用于对象检测。 可将此方法用于实例分割，即对影像中对象的精确划分。 此模型类型可用于检测建筑物覆盖区。 该类型将 MaskRCNN 元数据格式作为输入用于训练数据。 输入训练数据的类值必须从 1 开始。 只能使用支持 CUDA 的 GPU 来训练此模型类型。</para>
		/// <para>YOLOv3（对象检测）—YOLOv3 方法将用于训练模型。 YOLOv3 将用于对象检测。</para>
		/// <para>DeepLabV3（像素分类）—DeepLabV3 方法将用于训练模型。 DeepLab 用于像素分类。</para>
		/// <para>FasterRCNN（对象检测）—FasterRCNN 方法将用于训练模型。 FasterRCNN 将用于对象检测。</para>
		/// <para>BDCN 边缘检测器（像素分类）—双向级联网络 (BDCN) 架构将用于训练模型。 BDCN 边缘检测器用于像素分类。 此方法对于改进不同比例对象的边缘检测非常有用。</para>
		/// <para>HED 边缘检测器（像素分类）—整体嵌套边缘检测 (HED) 架构将用于训练模型。 HED 边缘检测器用于像素分类。 此方法对于边缘和对象边缘检测非常有用。</para>
		/// <para>多任务道路提取器（像素分类）—多任务道路提取器架构将用于训练模型。 多任务道路提取器可用于像素分类。 此方法对于从卫星影像提取道路网络非常有用。</para>
		/// <para>ConnectNet（像素分类）—ConnectNet 架构将用于训练模型。 ConnectNet 用于像素分类。 此方法对于从卫星影像提取道路网络非常有用。</para>
		/// <para>Pix2Pix（影像转换）—Pix2Pix 方法将用于训练模型。 Pix2Pix 可用于影像之间的转换。 此方法将创建一个模型对象，该模型对象会将一种类型的影像生成为另一种类型影像。 该模型类型的输入训练数据使用“导出切片”元数据格式。</para>
		/// <para>CycleGAN（影像转换）—CycleGAN 方法将用于训练模型。 CycleGAN 可用于影像之间的转换。 此方法将创建一个模型对象，该模型对象会将一种类型的影像生成为另一种类型影像。 这种方法的独特之处在于，要训练的影像不需要重叠。 该模型类型的输入训练数据使用 CycleGAN 元数据格式。</para>
		/// <para>超分辨率（影像转换）—超分辨率方法将用于训练模型。 超分辨率可用于影像之间的转换。 这种方法将创建一个模型对象，该模型对象可以提高分辨率并改善影像质量。 该模型类型的输入训练数据使用“导出切片”元数据格式。</para>
		/// <para>变化检测器（像素分类）—变化检测器方法将用于训练模型。 变化检测器用于像素分类。 这种方法将创建一个模型对象，该模型对象将使用两个时空影像来创建变化的分类栅格。 该模型类型的输入训练数据使用“分类切片”元数据格式。</para>
		/// <para>图像标题生成器（影像转换）—图像标题生成器方法将用于训练模型。 图像标题生成器可用于图像到文本的转换。 此方法将创建一个用于为图像生成文本标题的模型。</para>
		/// <para>Siam Mask（对象追踪器）—Siam Mask 方法将用于训练模型。 Siam Mask 将用于在视频中进行对象检测。 该模型使用视频帧进行训练，并检测每一帧中对象的类别和边界框。 此模型类型的输入训练数据使用 MaskRCNN 元数据格式。</para>
		/// <para>MMDetection（目标检测）—MMDetection 方法将用于训练模型。 MMDetection 将用于对象检测。 受支持的元数据格式包括 PASCAL 视觉对象类矩形和 KITTI 矩形。</para>
		/// <para>MMSegmentation（像素分类）—MMSegmentation 方法将用于训练模型。 MMDetection 用于像素分类。 受支持的元数据格式为分类切片。</para>
		/// <para>深度排序（对象追踪器）—深度排序方法将用于训练模型。 深度排序将用于在视频中进行对象检测。 该模型使用视频帧进行训练，并检测每一帧中对象的类别和边界框。 该模型类型的输入训练数据使用 Imagenet 元数据格式。 Siam Mask 在追踪对象时非常有用，而深度排序在训练模型以追踪多个对象时非常有用。</para>
		/// <para>Pix2PixHD（影像转换）—Pix2PixHD 方法将用于训练模型。 Pix2PixHD 可用于影像之间的转换。 此方法将创建一个模型对象，该模型对象会将一种类型的影像生成为另一种类型影像。 该模型类型的输入训练数据使用“导出切片”元数据格式。</para>
		/// <para>MaX-DeepLab（全景分割）—MaX-DeepLab 方法将用于训练模型。 用于全景分割的 MaX-DeepLab。 此方法将创建一个模型对象，该模型对象会将生成影像和要素。 此模型类型的输入训练数据使用全景元数据格式。</para>
		/// <para>DETReg（对象检测）—DETReg 方法将用于训练模型。 DETReg 将用于对象检测。 该模型类型的输入训练数据使用 Pascal 可视化对象类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Model Parameters")]
		public object? ModelType { get; set; }

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>一次需要处理以便用于训练的训练样本数。</para>
		/// <para>增加批处理大小可以提高工具性能；但是，随着批处理大小的增加，会占用更多内存。 如果发生内存不足错误，请使用较小的批处理大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Model Parameters")]
		public object? BatchSize { get; set; } = "64";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>函数参数在 Python 栅格函数类中定义。 您可以在此列出其他深度学习参数和用于试验和优化的参数，例如用于调整灵敏度的置信度阈值。 参数名称将通过读取 Python 模块进行填充。</para>
		/// <para>当您将单帧检测器（对象检测）选为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>格网 - 为进行处理将图像分割成的格网数。 将此参数设置为 4 意味着影像将被划分为 4 x 4 或 16 个格网像元。 如果未指定任何值，则将根据输入影像计算最佳格网值。</para>
		/// <para>缩放 - 每个格网像元将按比例进行扩大或缩小的缩放级别数。 将此参数设置为 1 意味着所有格网像元都将保持相同的大小或缩放级别。 缩放级别为 2 表示所有格网像元都将变成两倍大（放大 100%）。 提供缩放级别列表意味着将使用列表中的所有数字来缩放所有格网像元。 默认值为 1.0。</para>
		/// <para>比率 - 用于锚点框的纵横比列表。 在对象检测中，锚点框表示要预测的对象的理想位置、形状和大小。 将此参数设置为 [1.0,1.0]、[1.0，0.5] 表示锚点框是正方形 (1:1) 或水平边大小为垂直边一半 (1:0.5) 的矩形。 默认值为 [1.0, 1.0]。</para>
		/// <para>monitor - 指定在检查点和提前停止时要监控的指标。 可用指标包括 valid_loss 和 average_precision。 默认值为 valid_loss。</para>
		/// <para>当您选择像素分类模型（例如，金字塔场景解析网络（像素分类）、U-Net（像素分类）或 DeepLabv3（像素分类））作为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>use_net - 在金字塔池化完成后，指定是否使用 U-Net 解码器来恢复数据。 默认值为 True。 此参数特定于金字塔场景解析网络模型。</para>
		/// <para>pyramid_sizes - 要应用于不同子区域的卷积图层的数量和大小。 默认值为 [1,2,3,6]。 此参数特定于金字塔场景解析网络模型。</para>
		/// <para>mixup - 指定是否使用 mixup 增强和 mixup 损失。 默认值为 False。</para>
		/// <para>class_balancing - 指定是否平衡与每类像素的频率成反比的交叉熵损失。 默认值为 False。</para>
		/// <para>focus_loss - 指定是否使用焦点损失。 默认值为 False。</para>
		/// <para>ignore_classes - 包含模型不会在其上发生损失的类值列表。</para>
		/// <para>monitor - 指定在检查点和提前停止时要监控的指标。 可用指标包括 valid_loss 和 accuracy。 默认值为 valid_loss。</para>
		/// <para>当选择 RetinaNet（对象检测）作为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>比例 - 每个像元将按比例进行扩大或缩小的比例级数。 默认值为 [1, 0.8, 0.63]。</para>
		/// <para>比率 - 锚点框的纵横比。 默认值为 0.5,1,2。</para>
		/// <para>monitor - 指定在检查点和提前停止时要监控的指标。 可用指标包括 valid_loss 和 average_precision。 默认值为 valid_loss。</para>
		/// <para>当您将多任务道路提取器（像素分类）或 ConnectNet（像素分类）选为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>gaussian_thresh - 将设置高斯阈值，该阈值用于设置所需的道路宽度。 有效范围是 0.0 至 1.0。 默认值为 0.76。</para>
		/// <para>orient_bin_size - 设置方向角的图格大小。 默认值为 20。</para>
		/// <para>orient_theta - 设置方向掩膜的宽度。 默认值为 8。</para>
		/// <para>mtl_model - 设置将用于创建模型的架构类型。 对于神经架构，有效的选择是分别基于 Linknet 或基于 Hourglass 的 linknet 或 hourglass。 默认值为 hourglass。</para>
		/// <para>monitor - 指定在检查点和提前停止时要监控的指标。 可用指标包括 valid_loss、accuracy、miou 和 dice。 默认值为 valid_loss。</para>
		/// <para>当选择图像标题生成器（影像转换）作为模型类型参数值时，模型参数参数将使用以下参数进行填充：decode_params 参数由以下六个参数组成：</para>
		/// <para>decode_params - 一种用于控制图像标题生成器运行方式的字典。 默认值为 {&apos;embed_size&apos;:100, &apos;hidden_size&apos;:100, &apos;attention_size&apos;:100, &apos;teacher_forcing&apos;:1, &apos;dropout&apos;:0.1, &apos;pretrained_emb&apos;:False}。</para>
		/// <para>chip_size - 设置用于训练模型的图像大小。 图像将被裁剪为指定的片大小。 如果图像大小小于片大小，则使用图像大小。 默认大小为 224 像素。</para>
		/// <para>monitor - 指定在检查点和提前停止时要监控的指标。 可用指标包括 valid_loss、accuracy、corpus_bleu 和 multi_label_fbeta。 默认值为 valid_loss。</para>
		/// <para>embed_size - 设置嵌入大小。 神经网络中的默认设置为 100 个图层。</para>
		/// <para>hidden_size - 设置隐藏图层大小。 神经网络中的默认设置为 100 个图层。</para>
		/// <para>attention_size - 设置中间注意力图层大小。 神经网络中的默认设置为 100 个图层。</para>
		/// <para>teacher_forcing - 设置教师强制的概率。 教师强制是一种用于训练递归神经网络的策略。 该策略可在反向传播过程中将先前时间步长的模型输出用作输入而非先前的输出。 有效范围是 0.0 至 1.0。 默认值为 1。</para>
		/// <para>辍学 - 设置辍学概率。 有效范围是 0.0 至 1.0。 默认值为 0.1。</para>
		/// <para>pretrained_emb - 设置预训练嵌入标记。 如果为 True，则它将使用快速文本嵌入。 如果为 False，则它将不使用预训练文本嵌入。 默认值为 False。</para>
		/// <para>当您将变化检测器（像素分类）选为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>attention_type - 指定模块类型。 模块选择为 PAM（金字塔注意事项模块）或 BAM（基本注意事项模块）。 默认值为 PAM。</para>
		/// <para>monitor - 指定在检查点和提前停止时要监控的指标。 可用指标包括 valid_loss、precision、recall 和 f1。 默认值为 valid_loss。</para>
		/// <para>当选择 MMDetection（对象检测）作为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>model - 用于训练模型的骨干模型。 可用选择包括： atss、carafe、cascade_rcnn、cascade_rpn、dcn、detectors、double_heads、dynamic_rcnn、empirical_attention、fcos、foveabox、fsaf、ghm、hrnet、libra_rcnn、nas_fcos、pafpn、pisa、regnet、reppoints、res2net、sabl 和 vfnet。 默认值为 cascade_rcnn。</para>
		/// <para>model_weight - 指定将使用的预训练模型权重。 默认值为 false。 该值也可以是来自 MMDetection 资料档案库的包含模型权重的配置文件的路径。</para>
		/// <para>当您将 MMSegmentation（像素分类）选为模型类型参数值时，模型参数参数将使用以下参数进行填充：</para>
		/// <para>model - 用于训练模型的骨干模型。 可用选择包括： ann、apcnet、ccnet、cgnet、danet、deeplabv3、deeplabv3plus、dmnet 、dnlnet、emanet、encnet、fastscnn、fcn、gcnet、hrnet、mobilenet_v2、mobilenet_v3、nonlocal_net、ocrnet、ocrnet_base、pointrend、psanet、pspnet、resnest、sem_fpn、unet 和 upernet。 默认值为 deeplabv3。</para>
		/// <para>model_weight - 指定将使用的预训练模型权重。 默认值为 false。 该值也可以是来自 MMSegmentation 资料档案库的包含模型权重的配置文件的路径。</para>
		/// <para>所有模块类型均支持 chip_size 参数， 即训练样本的影像片大小。 将从输入训练数据参数中指定的文件夹中的 .emd 文件提取影像片大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Model Parameters")]
		public object? Arguments { get; set; }

		/// <summary>
		/// <para>Learning Rate</para>
		/// <para>在整个训练过程中，现有信息将被新获取的信息覆盖的比率。 如果未指定任何值，则系统将在训练过程中从学习曲线中提取最佳学习率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? LearningRate { get; set; }

		/// <summary>
		/// <para>Backbone Model</para>
		/// <para>指定要用作训练新模型的架构的、预先配置的神经网络。 这种方法称为迁移学习。</para>
		/// <para>DenseNet-121—预先配置的模型将是在 Imagenet 数据集上训练的密集网络，其中包含一百万个以上的影像，且深度为 121 个图层。 与使用求和来合并图层的 RESNET 不同，DenseNet 使用串联来合并图层。</para>
		/// <para>DenseNet-161—预先配置的模型将是在 Imagenet 数据集上训练的密集网络，其中包含一百万个以上的影像，且深度为 161 个图层。 与使用求和来合并图层的 RESNET 不同，DenseNet 使用串联来合并图层。</para>
		/// <para>DenseNet-169—预先配置的模型将是在 Imagenet 数据集上训练的密集网络，其中包含一百万个以上的影像，且深度为 169 个图层。 与使用求和来合并图层的 RESNET 不同，DenseNet 使用串联来合并图层。</para>
		/// <para>DenseNet-201—预先配置的模型将是在 Imagenet 数据集上训练的密集网络，其中包含一百万个以上的影像，且深度为 201 个图层。 与使用求和来合并图层的 RESNET 不同，DenseNet 使用串联来合并图层。</para>
		/// <para>MobileNet 2 版—由于这种预先配置的模型所使用的内存较少，因此将在 Imagenet 数据库上进行训练，且深度为 54 个图层，适用于边设备计算。</para>
		/// <para>ResNet-18—预先配置的模型将是在 Imagenet 数据集上训练的残差网络，其中包含一百万个以上的影像，且深度为 18 个图层。</para>
		/// <para>ResNet-34—预先配置的模型将是在 Imagenet 数据集上训练的残差网络，其中包含一百万个以上的影像，且深度为 34 个图层。 这是默认设置。</para>
		/// <para>ResNet-50—预先配置的模型将是在 Imagenet 数据集上训练的残差网络，其中包含一百万个以上的影像，且深度为 50 个图层。</para>
		/// <para>ResNet-101—预先配置的模型将是在 Imagenet 数据集上训练的残差网络，其中包含一百万个以上的影像，且深度为 101 个图层。</para>
		/// <para>ResNet-152—预先配置的模型将是在 Imagenet 数据集上训练的残差网络，其中包含一百万个以上的影像，且深度为 152 个图层。</para>
		/// <para>VGG-11—预先配置的模型将是在 Imagenet 数据集上训练的卷积神经网络，其中包含一百万个以上的影像以将影像分类为 1000 个对象类别，且深度为 11 个图层。</para>
		/// <para>使用批量归一化的 VGG-11—这种预先配置的模型将基于 VGG 网络，但具有批量归一化功能，这意味着网络中的每个图层都已归一化。 它在 Imagenet 数据集上进行了训练，具有 11 个图层。</para>
		/// <para>VGG-13—预先配置的模型将是在 Imagenet 数据集上训练的卷积神经网络，其中包含一百万个以上的影像以将影像分类为 1000 个对象类别，且深度为 13 个图层。</para>
		/// <para>使用批量归一化的 VGG-13—这种预先配置的模型将基于 VGG 网络，但具有批量归一化功能，这意味着网络中的每个图层都已归一化。 它在 Imagenet 数据集上进行了训练，具有 13 个图层。</para>
		/// <para>VGG-16—预先配置的模型将是在 Imagenet 数据集上训练的卷积神经网络，其中包含一百万个以上的影像以将影像分类为 1000 个对象类别，且深度为 16 个图层。</para>
		/// <para>使用批量归一化的 VGG-16—这种预先配置的模型将基于 VGG 网络，但具有批量归一化功能，这意味着网络中的每个图层都已归一化。 它在 Imagenet 数据集上进行了训练，具有 16 个图层。</para>
		/// <para>VGG-19—预先配置的模型将是在 Imagenet 数据集上训练的卷积神经网络，其中包含一百万个以上的影像以将影像分类为 1000 个对象类别，且深度为 19 个图层。</para>
		/// <para>使用批量归一化的 VGG-19—这种预先配置的模型将基于 VGG 网络，但具有批量归一化功能，这意味着网络中的每个图层都已归一化。 它在 Imagenet 数据集上进行了训练，具有 19 个图层。</para>
		/// <para>DarkNet-53—预先配置的模型将是在 Imagenet 数据集上训练的卷积神经网络，其中包含一百万个以上的影像，且深度为 53 个图层。</para>
		/// <para>Reid_v1—预先配置的模型将是在 Imagenet 数据集上训练的用于对象追踪的卷积神经网络。</para>
		/// <para>Reid_v2—预先配置的模型将是在 Imagenet 数据集上训练的用于对象追踪的卷积神经网络。</para>
		/// <para>此外，可以使用 timm: 作为前缀指定 PyTorch 图像模型 (timm) 中支持的卷积神经网络，例如 timm:resnet31、timm:inception_v4、timm:efficientnet_b3 等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? BackboneModel { get; set; }

		/// <summary>
		/// <para>Pre-trained Model</para>
		/// <para>将用于微调新模型的预训练模型。 输入为 Esri 模型定义文件 (.emd) 或深度学习包文件 (.dlpk)。</para>
		/// <para>可以对具有相似类的预训练模型进行微调以适应新模型。 预训练模型必须已使用将用于训练新模型的相同模型类型和骨干模型进行了训练。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		[Category("Advanced")]
		public object? PretrainedModel { get; set; }

		/// <summary>
		/// <para>Validation %</para>
		/// <para>将用于验证模型的训练样本的百分比。 默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? ValidationPercentage { get; set; } = "10";

		/// <summary>
		/// <para>Stop when model stops improving</para>
		/// <para>指定是否将实施提前停止。</para>
		/// <para>选中 - 将实施提前停止，当模型不再改进时，无论所指定的最大新时期参数值是什么，模型训练都将停止。 这是默认设置。</para>
		/// <para>未选中 - 不会实施提前停止，模型训练将一直持续，直至达到最大新时期参数值为止。</para>
		/// <para><see cref="StopTrainingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? StopTraining { get; set; } = "true";

		/// <summary>
		/// <para>Output Model</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutModelFile { get; set; }

		/// <summary>
		/// <para>Freeze Model</para>
		/// <para>指定是否冻结预训练模型中的骨干层，以使权重和偏差保持原始设计。</para>
		/// <para>选中 - 将冻结骨干图层，预定义的权重和偏差不会在骨干模型参数中进行更改。 这是默认设置。</para>
		/// <para>未选中 - 不会冻结骨干图层，骨干模型参数的权重和偏差可能会进行更改以更好地适合您的训练样本。 这将需要花费更多的时间来处理，但通常会产生更好的结果。</para>
		/// <para><see cref="FreezeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? Freeze { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainDeepLearningModel SetEnviroment(object? parallelProcessingFactor = null, object? processorType = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, scratchWorkspace: scratchWorkspace, workspace: workspace);
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
		/// <para>Freeze Model</para>
		/// </summary>
		public enum FreezeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FREEZE_MODEL")]
			FREEZE_MODEL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("UNFREEZE_MODEL")]
			UNFREEZE_MODEL,

		}

#endregion
	}
}
