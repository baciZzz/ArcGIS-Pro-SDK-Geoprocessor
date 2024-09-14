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
	/// <para>Export Training Data For Deep Learning</para>
	/// <para>导出训练数据进行深度学习</para>
	/// <para>使用遥感影像将标注的矢量或栅格数据转换为深度学习训练数据集。 输出将是影像芯片文件夹和指定格式的元数据文件文件夹。</para>
	/// </summary>
	public class ExportTrainingDataForDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入源影像，通常是多光谱影像。</para>
		/// <para>输入源影像类型的示例包括多光谱卫星影像、无人机影像、航空影像和国家农业影像计划 (NAIP)。 输入可以是影像的文件夹。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>将存储输出影像片和元数据的文件夹。</para>
		/// <para>该文件夹还可以是使用云存储连接文件 (*.acs) 的文件夹 URL。</para>
		/// </param>
		public ExportTrainingDataForDeepLearning(object InRaster, object OutFolder)
		{
			this.InRaster = InRaster;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出训练数据进行深度学习</para>
		/// </summary>
		public override string DisplayName() => "导出训练数据进行深度学习";

		/// <summary>
		/// <para>Tool Name : ExportTrainingDataForDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ExportTrainingDataForDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExportTrainingDataForDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExportTrainingDataForDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFolder, InClassData!, ImageChipFormat!, TileSizeX!, TileSizeY!, StrideX!, StrideY!, OutputNofeatureTiles!, MetadataFormat!, StartIndex!, ClassValueField!, BufferRadius!, InMaskPolygons!, RotationAngle!, ReferenceSystem!, ProcessingMode!, BlackenAroundFeature!, CropMode!, InRaster2!, InInstanceData!, InstanceClassValueField!, MinPolygonOverlapRatio! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入源影像，通常是多光谱影像。</para>
		/// <para>输入源影像类型的示例包括多光谱卫星影像、无人机影像、航空影像和国家农业影像计划 (NAIP)。 输入可以是影像的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将存储输出影像片和元数据的文件夹。</para>
		/// <para>该文件夹还可以是使用云存储连接文件 (*.acs) 的文件夹 URL。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Input Feature Class Or Classified Raster Or Table</para>
		/// <para>矢量或栅格形式的训练样本数据。</para>
		/// <para>矢量输入应当遵循使用训练样本管理器窗格生成的训练样本格式。 栅格输入应当遵循分类栅格工具生成的分类栅格格式。 栅格输入也可以来自分类栅格的文件夹。 输入表应遵循训练样本管理器窗格中的标注对象以供深度学习工具生成的训练样本格式。 可以使用统计信息并遵循正确的训练样本格式生成最佳结果；但输入也可以是没有类值字段的点要素类，或不具有任何类信息的整型栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InClassData { get; set; }

		/// <summary>
		/// <para>Image Format</para>
		/// <para>指定将用于影像片输出的栅格格式。</para>
		/// <para>PNG 和 JPEG 格式最多支持 3 个波段。</para>
		/// <para>TIFF 格式—将使用 TIFF 格式。</para>
		/// <para>PNG 格式—将使用 PNG 格式。</para>
		/// <para>JPEG 格式—将使用 JPEG 格式。</para>
		/// <para>MRF（元栅格格式）—将使用元栅格格式 (MRF)。</para>
		/// <para><see cref="ImageChipFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ImageChipFormat { get; set; } = "TIFF";

		/// <summary>
		/// <para>Tile Size X</para>
		/// <para>影像片的大小，针对 x 维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? TileSizeX { get; set; } = "256";

		/// <summary>
		/// <para>Tile Size Y</para>
		/// <para>影像片的大小，针对 y 维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? TileSizeY { get; set; } = "256";

		/// <summary>
		/// <para>Stride X</para>
		/// <para>在创建下一个影像片时 x 方向上移动的距离。</para>
		/// <para>当步幅等于切片大小时，将不会发生重叠。 当步幅等于切片大小的一半时，将有 50% 的重叠。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? StrideX { get; set; } = "128";

		/// <summary>
		/// <para>Stride Y</para>
		/// <para>在创建下一个影像片时 y 方向上移动的距离。</para>
		/// <para>当步幅等于切片大小时，将不会发生重叠。 当步幅等于切片大小的一半时，将有 50% 的重叠。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? StrideY { get; set; } = "128";

		/// <summary>
		/// <para>Output No Feature Tiles</para>
		/// <para>指定是否将导出不捕获训练样本的影像片。</para>
		/// <para>选中 - 将导出所有影像片，包括不捕获训练样本的影像片。</para>
		/// <para>未选中 - 仅会导出捕获训练样本的影像片。 这是默认设置。</para>
		/// <para>如果选中，不捕获标注数据的影像片也会被导出；如果未选中，它们将不会被导出。</para>
		/// <para><see cref="OutputNofeatureTilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutputNofeatureTiles { get; set; } = "false";

		/// <summary>
		/// <para>Metadata Format</para>
		/// <para>指定将用于输出元数据标注的格式。</para>
		/// <para>如果输入训练样本数据是诸如建筑物图层等的要素类图层或者标准分类训练样本文件，请使用 KITTI 标注或 PASCAL 可视化对象类选项（Python 中的 KITTI_rectangles 或 PASCAL_VOC_rectangles）。 输出元数据是包含训练样本数据的 .txt 文件或 .xml 文件，其中训练样本数据包含在最小外接矩形中。 元数据文件的名称与输入源影像名称相匹配。 如果输入训练样本数据是类地图，请使用分类切片选项（Python 中的 Classified_Tiles）作为输出元数据格式。</para>
		/// <para>KITTI 标注—元数据将遵循与卡尔斯鲁厄理工学院和丰田工业大学 (KITTI) 对象检测评估数据集相同的格式。 KITTI 数据集是一款视觉基准套件。 标注文件是纯文本文件。 所有的值（数值和字符串）均由空格分隔开，每行对应一个对象。此格式将用于对象检测。</para>
		/// <para>PASCAL 可视化对象类—元数据将遵循与模式分析、统计建模和计算学习、可视化对象类 (PASCAL_VOC) 数据集相同的格式。 PASCAL VOC 数据集是用于对象类识别的标准化影像数据集。 标注文件为 XML 格式，包含有关影像名称、类值和边界框的信息。此格式将用于对象检测。 这是默认设置。</para>
		/// <para>分类切片—每有一个输入影像片，就将输出一个分类影像片。 不会使用每个影像片的任何其他元数据。 仅统计数据输出具有关于类的详细信息，如类名称、类值和输出统计数据。此格式主要用于像素分类。 当输出为两个影像片中的一个分类影像片时，此格式也用于变化检测。</para>
		/// <para>RCNN 掩膜—输出将为在样本所在的区域上具有掩膜的影像片。 该模型将为影像中对象的每个实例生成边界框和分割掩膜。 此格式基于特征金字塔网络 (FPN) 和深度学习框架模型中的 ResNet101 核心支柱。此格式将用于对象检测；但是，在训练期间使用 Siam 掩膜模型类型时，此格式也可以用于对象追踪。</para>
		/// <para>标注的切片—每个输出切片都将使用特定类进行标注。此格式将用于对象分类。</para>
		/// <para>多标注切片—每个输出切片都将使用一个或多个类进行标注。 例如，可将切片标注为“农业”，也可将其标注为“多云”。此格式将用于对象分类。</para>
		/// <para>导出切片—输出将为不带标注的影像片。此格式用于影像转换技术，例如 Pix2Pix 和超分辨率。</para>
		/// <para>CycleGAN—输出将为不带标注的影像片。此格式用于影像转换技术 CycleGAN，该技术可用于训练不重叠的影像。</para>
		/// <para>Imagenet—每个输出切片都将使用特定类进行标注。此格式将用于对象分类；但是，在培训期间使用深度排序模型类型时，也可以用于对象追踪。</para>
		/// <para>全景分割—针对每个输入影像片，输出将为一个分类影像片和一个实例。 输出还将具有影像片，这些影像片会在样本存在的区域上具有掩膜；这些影像片将存储在不同的文件夹中。此格式用于像素分类和实例分割，因此将生成两个输出标注文件夹。</para>
		/// <para>对于 KITTI 元数据格式，将创建 15 个列，但此工具中仅使用其中 5 个列。 第一个列是类值。 然后，跳过之后 3 个列。 5 至 8 列用于定义最小外接矩形，该矩形将由以下 4 个影像坐标位置构成：左、上、右和下像素。 最小外接矩形包含用于深度学习分类器中的训练片。 系统将不会使用其他列。</para>
		/// <para><see cref="MetadataFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MetadataFormat { get; set; } = "PASCAL_VOC_rectangles";

		/// <summary>
		/// <para>Start Index</para>
		/// <para>此参数已弃用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? StartIndex { get; set; } = "0";

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>包含类值的字段。 如果未指定任何字段，则系统将搜索 value 或 classvalue 字段。 如果该要素不包含类字段，则系统将确定所有记录均属于一个类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? ClassValueField { get; set; }

		/// <summary>
		/// <para>Buffer Radius</para>
		/// <para>每个训练样本周围的缓冲区半径，将用于描绘训练样本区域。 您可以借此从点创建圆形面训练样本。</para>
		/// <para>系统将使用输入要素类或分类栅格或表参数值的空间参考的线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BufferRadius { get; set; } = "0";

		/// <summary>
		/// <para>Input Mask Polygons</para>
		/// <para>此面要素类用于描绘将创建影像片的区域。</para>
		/// <para>系统仅会创建完全位于面内的影像片。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InMaskPolygons { get; set; }

		/// <summary>
		/// <para>Rotation Angle</para>
		/// <para>将用于生成其他影像片的旋转角度。</para>
		/// <para>影像片将在旋转角度为 0 的情况下生成，这意味着无旋转。 随后系统将以指定的角度旋转该芯片，以创建其他影像片。 系统将在多个影像片中以多个角度捕获相同的训练样本，以便用于数据增强。</para>
		/// <para>默认旋转角度为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? RotationAngle { get; set; } = "0";

		/// <summary>
		/// <para>Reference System</para>
		/// <para>指定将用于解释输入影像的参考系类型。 指定的参考系必须与训练深度学习模型所使用的参考系相匹配。</para>
		/// <para>地图空间—将使用基于地图的坐标系。 这是默认设置。</para>
		/// <para>像素空间—将使用图像空间，没有旋转且没有失真。</para>
		/// <para><see cref="ReferenceSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReferenceSystem { get; set; } = "MAP_SPACE";

		/// <summary>
		/// <para>Processing Mode</para>
		/// <para>指定处理镶嵌数据集或影像服务中的所有栅格项目的方式。 当输入栅格是镶嵌数据集或影像服务时，将应用此参数。</para>
		/// <para>以镶嵌影像方式处理—将镶嵌在一起并处理镶嵌数据集或影像服务中的所有栅格项目。 这是默认设置。</para>
		/// <para>单独处理所有栅格项目—将作为独立影像处理镶嵌数据集或影像服务中的所有栅格项目。</para>
		/// <para><see cref="ProcessingModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ProcessingMode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Blacken Around Feature</para>
		/// <para>指定是否对每个影像切片中的每个对象或要素周围的像素进行掩膜。</para>
		/// <para>仅当元数据格式参数设置为标注切片且已指定输入要素类或分类栅格时，此参数才适用。</para>
		/// <para>未选中 - 将不会对对象或要素周围的像素进行掩膜。 这是默认设置。</para>
		/// <para>选中 - 将对对象或要素周围的像素进行掩膜。</para>
		/// <para><see cref="BlackenAroundFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BlackenAroundFeature { get; set; } = "false";

		/// <summary>
		/// <para>Crop Mode</para>
		/// <para>指定是否将裁剪导出的切片，从而使其大小均相同。</para>
		/// <para>仅当元数据格式参数设置为标注切片或 Imagenet 且已指定输入要素类或分类栅格时，此参数才适用。</para>
		/// <para>固定大小—导出的切片将被裁剪为相同的大小，并将以要素为中心。 这是默认设置。</para>
		/// <para>边界框—将对导出的切片进行裁剪，以使边界几何仅围绕切片中的要素。</para>
		/// <para><see cref="CropModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CropMode { get; set; } = "FIXED_SIZE";

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>附加输入影像源，将用于影像转换方法。</para>
		/// <para>当元数据格式参数设置为已分类切片、导出切片或 CycleGAN 时，此参数有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InRaster2 { get; set; }

		/// <summary>
		/// <para>Instance Feature Class</para>
		/// <para>采集的训练样本数据，包含用于实例分割的类。</para>
		/// <para>输入也可以是没有类值字段的点要素类，或不具有任何类信息的整型栅格。</para>
		/// <para>该参数仅在将元数据格式参数设置为全景分割时有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InInstanceData { get; set; }

		/// <summary>
		/// <para>Instance Class Value Field</para>
		/// <para>包含实例分割的类值的字段。 如果未指定任何字段，则该工具将使用值或类值字段（如果存在）。 如果要素不包含类字段，则工具将确定所有记录均属于一个类。</para>
		/// <para>该参数仅在将元数据格式参数设置为全景分割时有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? InstanceClassValueField { get; set; }

		/// <summary>
		/// <para>Minimum Polygon Overlap Ratio</para>
		/// <para>要包含在训练数据中的要素的最小重叠百分比。 如果重叠百分比小于指定的值，则将从训练片中排除该要素，并且不会将其添加到标注文件中。</para>
		/// <para>百分比值以小数表示。 例如，要指定 20% 重叠，请使用值 0.2。 默认值为 0，这意味着将包含所有要素。</para>
		/// <para>此参数可以改善工具的性能，也可以改善推断能力。 由于创建的训练片较少，因此速度得到了改进。 由于将对模型进行训练以仅检测大块对象，而忽略要素的小角落，因此推断得到了改进。 这意味着将检测到较少的误报，并且非最大抑制工具将移除较少的误报。</para>
		/// <para>当输入要素类或分类栅格或表参数值为要素类时，此参数无效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinPolygonOverlapRatio { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTrainingDataForDeepLearning SetEnviroment(object? cellSize = null, object? extent = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Image Format</para>
		/// </summary>
		public enum ImageChipFormatEnum 
		{
			/// <summary>
			/// <para>TIFF 格式—将使用 TIFF 格式。</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF 格式")]
			TIFF_format,

			/// <summary>
			/// <para>MRF（元栅格格式）—将使用元栅格格式 (MRF)。</para>
			/// </summary>
			[GPValue("MRF")]
			[Description("MRF（元栅格格式）")]
			MRF,

			/// <summary>
			/// <para>PNG 格式—将使用 PNG 格式。</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG 格式")]
			PNG_format,

			/// <summary>
			/// <para>JPEG 格式—将使用 JPEG 格式。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG 格式")]
			JPEG_format,

		}

		/// <summary>
		/// <para>Output No Feature Tiles</para>
		/// </summary>
		public enum OutputNofeatureTilesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_TILES")]
			ALL_TILES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_TILES_WITH_FEATURES")]
			ONLY_TILES_WITH_FEATURES,

		}

		/// <summary>
		/// <para>Metadata Format</para>
		/// </summary>
		public enum MetadataFormatEnum 
		{
			/// <summary>
			/// <para>KITTI 标注—元数据将遵循与卡尔斯鲁厄理工学院和丰田工业大学 (KITTI) 对象检测评估数据集相同的格式。 KITTI 数据集是一款视觉基准套件。 标注文件是纯文本文件。 所有的值（数值和字符串）均由空格分隔开，每行对应一个对象。此格式将用于对象检测。</para>
			/// </summary>
			[GPValue("KITTI_rectangles")]
			[Description("KITTI 标注")]
			KITTI_Labels,

			/// <summary>
			/// <para>PASCAL 可视化对象类—元数据将遵循与模式分析、统计建模和计算学习、可视化对象类 (PASCAL_VOC) 数据集相同的格式。 PASCAL VOC 数据集是用于对象类识别的标准化影像数据集。 标注文件为 XML 格式，包含有关影像名称、类值和边界框的信息。此格式将用于对象检测。 这是默认设置。</para>
			/// </summary>
			[GPValue("PASCAL_VOC_rectangles")]
			[Description("PASCAL 可视化对象类")]
			PASCAL_Visual_Object_Classes,

			/// <summary>
			/// <para>分类切片—每有一个输入影像片，就将输出一个分类影像片。 不会使用每个影像片的任何其他元数据。 仅统计数据输出具有关于类的详细信息，如类名称、类值和输出统计数据。此格式主要用于像素分类。 当输出为两个影像片中的一个分类影像片时，此格式也用于变化检测。</para>
			/// </summary>
			[GPValue("Classified_Tiles")]
			[Description("分类切片")]
			Classified_Tiles,

			/// <summary>
			/// <para>RCNN 掩膜—输出将为在样本所在的区域上具有掩膜的影像片。 该模型将为影像中对象的每个实例生成边界框和分割掩膜。 此格式基于特征金字塔网络 (FPN) 和深度学习框架模型中的 ResNet101 核心支柱。此格式将用于对象检测；但是，在训练期间使用 Siam 掩膜模型类型时，此格式也可以用于对象追踪。</para>
			/// </summary>
			[GPValue("RCNN_Masks")]
			[Description("RCNN 掩膜")]
			RCNN_Masks,

			/// <summary>
			/// <para>标注的切片—每个输出切片都将使用特定类进行标注。此格式将用于对象分类。</para>
			/// </summary>
			[GPValue("Labeled_Tiles")]
			[Description("标注的切片")]
			Labeled_Tiles,

			/// <summary>
			/// <para>多标注切片—每个输出切片都将使用一个或多个类进行标注。 例如，可将切片标注为“农业”，也可将其标注为“多云”。此格式将用于对象分类。</para>
			/// </summary>
			[GPValue("MultiLabeled_Tiles")]
			[Description("多标注切片")]
			MultiLabeled_Tiles,

			/// <summary>
			/// <para>导出切片—输出将为不带标注的影像片。此格式用于影像转换技术，例如 Pix2Pix 和超分辨率。</para>
			/// </summary>
			[GPValue("Export_Tiles")]
			[Description("导出切片")]
			Export_Tiles,

			/// <summary>
			/// <para>CycleGAN—输出将为不带标注的影像片。此格式用于影像转换技术 CycleGAN，该技术可用于训练不重叠的影像。</para>
			/// </summary>
			[GPValue("CycleGAN")]
			[Description("CycleGAN")]
			CycleGAN,

			/// <summary>
			/// <para>Imagenet—每个输出切片都将使用特定类进行标注。此格式将用于对象分类；但是，在培训期间使用深度排序模型类型时，也可以用于对象追踪。</para>
			/// </summary>
			[GPValue("Imagenet")]
			[Description("Imagenet")]
			Imagenet,

			/// <summary>
			/// <para>全景分割—针对每个输入影像片，输出将为一个分类影像片和一个实例。 输出还将具有影像片，这些影像片会在样本存在的区域上具有掩膜；这些影像片将存储在不同的文件夹中。此格式用于像素分类和实例分割，因此将生成两个输出标注文件夹。</para>
			/// </summary>
			[GPValue("Panoptic_Segmentation")]
			[Description("全景分割")]
			Panoptic_Segmentation,

		}

		/// <summary>
		/// <para>Reference System</para>
		/// </summary>
		public enum ReferenceSystemEnum 
		{
			/// <summary>
			/// <para>地图空间—将使用基于地图的坐标系。 这是默认设置。</para>
			/// </summary>
			[GPValue("MAP_SPACE")]
			[Description("地图空间")]
			Map_space,

			/// <summary>
			/// <para>像素空间—将使用图像空间，没有旋转且没有失真。</para>
			/// </summary>
			[GPValue("PIXEL_SPACE")]
			[Description("像素空间")]
			Pixel_space,

		}

		/// <summary>
		/// <para>Processing Mode</para>
		/// </summary>
		public enum ProcessingModeEnum 
		{
			/// <summary>
			/// <para>以镶嵌影像方式处理—将镶嵌在一起并处理镶嵌数据集或影像服务中的所有栅格项目。 这是默认设置。</para>
			/// </summary>
			[GPValue("PROCESS_AS_MOSAICKED_IMAGE")]
			[Description("以镶嵌影像方式处理")]
			Process_as_mosaicked_image,

			/// <summary>
			/// <para>单独处理所有栅格项目—将作为独立影像处理镶嵌数据集或影像服务中的所有栅格项目。</para>
			/// </summary>
			[GPValue("PROCESS_ITEMS_SEPARATELY")]
			[Description("单独处理所有栅格项目")]
			Process_all_raster_items_separately,

		}

		/// <summary>
		/// <para>Blacken Around Feature</para>
		/// </summary>
		public enum BlackenAroundFeatureEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BLACKEN_AROUND_FEATURE")]
			BLACKEN_AROUND_FEATURE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BLACKEN")]
			NO_BLACKEN,

		}

		/// <summary>
		/// <para>Crop Mode</para>
		/// </summary>
		public enum CropModeEnum 
		{
			/// <summary>
			/// <para>固定大小—导出的切片将被裁剪为相同的大小，并将以要素为中心。 这是默认设置。</para>
			/// </summary>
			[GPValue("FIXED_SIZE")]
			[Description("固定大小")]
			Fixed_size,

			/// <summary>
			/// <para>边界框—将对导出的切片进行裁剪，以使边界几何仅围绕切片中的要素。</para>
			/// </summary>
			[GPValue("BOUNDING_BOX")]
			[Description("边界框")]
			Bounding_box,

		}

#endregion
	}
}
