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
	/// <para>Video Multiplexer</para>
	/// <para>视频多路复用器</para>
	/// <para>创建一个视频文件，从而将存档视频流文件和按照时间戳同步的关联元数据文件相结合。</para>
	/// </summary>
	public class VideoMultiplexer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVideoFile">
		/// <para>Input Video File</para>
		/// <para>将转换为兼容 FMV 的视频文件的输入视频文件。</para>
		/// <para>以下为受支持的视频文件类型：.avi（支持 H.264 而非 H.265）、.h264、.mp2、.mp4、.m2ts、.mpeg、.mpeg2、.mpeg4、.mpg、.mpg2、.mpg4、.ps、.ts 和 vob。</para>
		/// </param>
		/// <param name="MetadataFile">
		/// <para>Metadata File</para>
		/// <para>逗号分隔值 (CSV) 文件，其中包含有关特定时间的视频帧的元数据。</para>
		/// <para>每列将代表一个元数据字段，且其中一列必须为时间参考。时间参考为 Unix 时间戳（1970 年至今的秒数）乘以一百万，且将以整数形式存储。之所以采用此种方式来存储时间，是为了可以用整数来引用任何时刻（最小单位为百万分之一秒）。因此，两个 500,000 条目之间的时间差表示历时半秒。</para>
		/// <para>第一行中将包含元数据列的字段名称。这些字段名称将在从 FMV_Multiplexer_Field_Mapping_Template.csv 获取的 C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo 文件中列出，或者您也可以使用模板将您的自定义字段名称与其对应的 FMV 字段名称相匹配。每个后续行中均包含特定时间的元数据值，我们称之为时间戳。</para>
		/// <para>元数据字段名称可以按任何顺序进行排列，并且应完全按照 FMV_Multiplexer_Field_Mapping_Template.csv 模板中列出的名称命名，以便将元数据字段名称映射到正确的 FMV 元数据字段名称。</para>
		/// </param>
		/// <param name="OutVideoFile">
		/// <para>Output Video File</para>
		/// <para>输出视频文件的名称，包括文件扩展名。</para>
		/// <para>受支持的视频文件如下：.h264、.mp2、.mp4、.m2ts、.mpeg、.mpeg2、.mpeg4、.mpg、.mpg2、.mpg4、.ps、.ts 和 vob。</para>
		/// </param>
		public VideoMultiplexer(object InVideoFile, object MetadataFile, object OutVideoFile)
		{
			this.InVideoFile = InVideoFile;
			this.MetadataFile = MetadataFile;
			this.OutVideoFile = OutVideoFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 视频多路复用器</para>
		/// </summary>
		public override string DisplayName() => "视频多路复用器";

		/// <summary>
		/// <para>Tool Name : VideoMultiplexer</para>
		/// </summary>
		public override string ToolName() => "VideoMultiplexer";

		/// <summary>
		/// <para>Tool Excute Name : ia.VideoMultiplexer</para>
		/// </summary>
		public override string ExcuteName() => "ia.VideoMultiplexer";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InVideoFile, MetadataFile, OutVideoFile, MetadataMappingFile, TimeshiftFile, ElevationLayer };

		/// <summary>
		/// <para>Input Video File</para>
		/// <para>将转换为兼容 FMV 的视频文件的输入视频文件。</para>
		/// <para>以下为受支持的视频文件类型：.avi（支持 H.264 而非 H.265）、.h264、.mp2、.mp4、.m2ts、.mpeg、.mpeg2、.mpeg4、.mpg、.mpg2、.mpg4、.ps、.ts 和 vob。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object InVideoFile { get; set; }

		/// <summary>
		/// <para>Metadata File</para>
		/// <para>逗号分隔值 (CSV) 文件，其中包含有关特定时间的视频帧的元数据。</para>
		/// <para>每列将代表一个元数据字段，且其中一列必须为时间参考。时间参考为 Unix 时间戳（1970 年至今的秒数）乘以一百万，且将以整数形式存储。之所以采用此种方式来存储时间，是为了可以用整数来引用任何时刻（最小单位为百万分之一秒）。因此，两个 500,000 条目之间的时间差表示历时半秒。</para>
		/// <para>第一行中将包含元数据列的字段名称。这些字段名称将在从 FMV_Multiplexer_Field_Mapping_Template.csv 获取的 C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo 文件中列出，或者您也可以使用模板将您的自定义字段名称与其对应的 FMV 字段名称相匹配。每个后续行中均包含特定时间的元数据值，我们称之为时间戳。</para>
		/// <para>元数据字段名称可以按任何顺序进行排列，并且应完全按照 FMV_Multiplexer_Field_Mapping_Template.csv 模板中列出的名称命名，以便将元数据字段名称映射到正确的 FMV 元数据字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object MetadataFile { get; set; }

		/// <summary>
		/// <para>Output Video File</para>
		/// <para>输出视频文件的名称，包括文件扩展名。</para>
		/// <para>受支持的视频文件如下：.h264、.mp2、.mp4、.m2ts、.mpeg、.mpeg2、.mpeg4、.mpg、.mpg2、.mpg4、.ps、.ts 和 vob。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object OutVideoFile { get; set; }

		/// <summary>
		/// <para>Metadata Mapping File</para>
		/// <para>一个 CSV 文件中包含 5 个列和 87 个行，且基于从 C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo 中获取的 FMV_Multiplexer_Field_Mapping_Template.csv 模板文件。</para>
		/// <para>此 CSV 文件将您的元数据字段名称交叉引用到 FMV 字段名称。每行将代表一个标准元数据参数，例如传感器纬度。前两列中包含已在表单中提供的标签以及 MISB 参数名称的相关信息。第三列中包含显示在输入元数据文件参数中的字段名称。填充第三列之后，该软件即可将您的元数据字段名称与正确的 FMV 元数据标签进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object MetadataMappingFile { get; set; }

		/// <summary>
		/// <para>Timeshift File</para>
		/// <para>包含已定义时移间隔的文件。</para>
		/// <para>在理想情况下，视频影像和元数据将在时间上同步。在这种情况下，全动态视频中的影像轮廓线将围绕可在视频影像中看到的要素。有时视频的时间与元数据中的时间会出现不匹配。这会导致地面要素被影像轮廓线包围的时刻与该地面要素在视频影像中可见的时刻之间出现明显的时间延迟。如果该时移是可观测且一致的，则多路复用器可以调整元数据的时间，使其与视频相匹配。</para>
		/// <para>如果视频的时间与元数据不匹配，则请指定 FMV_Multiplexer_TimeShift_Template.csv 模板（从 C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo 获取）中的时移。时移观测点文件是一种 CSV 文件，其中包含了两个列（elapsed time 和 time shift）和一个或多个数据行。列名称的行是可选的。</para>
		/// <para>例如，如果视频影像在整个时间内存在 5 秒的滞后，则时移观测点文件将出现以下一行：0:00, -5。整个视频将移动 5 秒。</para>
		/// <para>如果视频的 0:18 标记存在 5 秒滞后，且视频的 2:21 标记存在 9 秒滞后，则时移观测点文件中将包含以下两行：</para>
		/// <para>&lt;code&gt;0:18, -5 2:21, -9&lt;/code&gt;在这种情况下，该视频在视频开始时和视频结束时的移动方式将有所不同。</para>
		/// <para>您可以在时移观测点文件中定义任意数量的时移间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object TimeshiftFile { get; set; }

		/// <summary>
		/// <para>Digital Elevation Model</para>
		/// <para>计算视频帧角坐标所需的高程源。该源可以是图层、图像服务、平均地面高程或海洋深度。平均高程值需要包含测量单位，如米、英尺或其他长度测量单位。</para>
		/// <para>视频轮廓线和帧中心的精度取决于所提供的 DEM 数据源的精度。建议您提供 DEM 图层或图像服务。如果您无法访问 DEM 数据，则可以输入相对于海平面的平均高程和单位，例如 15 英尺或 10 米。在使用潜水器的情况下，您可以输入 -15 英尺或 -10 米。使用平均高程或海洋深度的精度要低于提供 DEM 或深海探测数据的情况。</para>
		/// <para>要计算帧角坐标，平均高程值必须始终小于元数据中记录的传感器高度或深度。例如，如果视频是在 10 米或以上的传感器高度下拍摄的，则有效平均高度可为 9 米或更低。如果视频是在深度为 -10 米或更深的水下拍摄的，则有效平均高程（相对于海平面）可能为 -11 米或更深。如果传感器高度值小于平均高程值，则系统不会为该记录计算四个角坐标。如果您不知道工程区域的平均高程，请使用 DEM。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object ElevationLayer { get; set; }

	}
}
