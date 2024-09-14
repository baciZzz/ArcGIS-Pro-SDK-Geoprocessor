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
	/// <para>Extract Video Frames To Images</para>
	/// <para>将视频帧提取为图像</para>
	/// <para>从兼容 FMV 的视频流中提取视频帧图像和关联的元数据。 可将所提取的图像添加到镶嵌数据集或其他工具和函数中，以供进一步分析。</para>
	/// </summary>
	public class ExtractVideoFramesToImages : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVideo">
		/// <para>Input Video File</para>
		/// <para>所有受支持的视频文件格式的输入视频文件，包括 PS、TS、MPG、MPEG、MP2、MPG2、MPEG2、MP4、MPG4、MPEG4、H264、VOB 和 M2TS。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>将用于保存输出图像和元数据的文件目录。</para>
		/// </param>
		public ExtractVideoFramesToImages(object InVideo, object OutFolder)
		{
			this.InVideo = InVideo;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 将视频帧提取为图像</para>
		/// </summary>
		public override string DisplayName() => "将视频帧提取为图像";

		/// <summary>
		/// <para>Tool Name : ExtractVideoFramesToImages</para>
		/// </summary>
		public override string ToolName() => "ExtractVideoFramesToImages";

		/// <summary>
		/// <para>Tool Excute Name : ia.ExtractVideoFramesToImages</para>
		/// </summary>
		public override string ExcuteName() => "ia.ExtractVideoFramesToImages";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InVideo, OutFolder, ImageType!, ImageOverlap!, RequireFreshMetadata!, MinTime! };

		/// <summary>
		/// <para>Input Video File</para>
		/// <para>所有受支持的视频文件格式的输入视频文件，包括 PS、TS、MPG、MPEG、MP2、MPG2、MPEG2、MP4、MPG4、MPEG4、H264、VOB 和 M2TS。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object InVideo { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将用于保存输出图像和元数据的文件目录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Image Type</para>
		/// <para>指定输出图像格式。</para>
		/// <para>JPEG—将以 JPEG 图像格式输出。</para>
		/// <para>TIFF—将以 TIFF 图像格式输出。 这是默认设置。</para>
		/// <para>NITF—将以 NITF 图像格式输出。</para>
		/// <para><see cref="ImageTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ImageType { get; set; } = "TIFF";

		/// <summary>
		/// <para>Maximum Overlap Percentage</para>
		/// <para>两个图像之间的最大重叠百分比。 如果候选图像与写入到磁盘的最后一个图像之间的重叠大于该值，则将忽略此候选图像。 默认百分比为 100%，此时会将所有图像写入磁盘。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ImageOverlap { get; set; } = "100";

		/// <summary>
		/// <para>Require Fresh Metadata</para>
		/// <para>指定是否要提取和保存具有关联元数据的视频帧。</para>
		/// <para>选中 - 将仅保存具有关联元数据的视频帧。</para>
		/// <para>未选中 - 将保存所有视频帧。 这是默认设置。</para>
		/// <para><see cref="RequireFreshMetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RequireFreshMetadata { get; set; }

		/// <summary>
		/// <para>Minimum Time Between Features</para>
		/// <para>要保存的视频帧之间的最小时间间隔。 如果未指定该时间，则所有视频帧都将保存为图像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object? MinTime { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Image Type</para>
		/// </summary>
		public enum ImageTypeEnum 
		{
			/// <summary>
			/// <para>JPEG—将以 JPEG 图像格式输出。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>TIFF—将以 TIFF 图像格式输出。 这是默认设置。</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

			/// <summary>
			/// <para>NITF—将以 NITF 图像格式输出。</para>
			/// </summary>
			[GPValue("NITF")]
			[Description("NITF")]
			NITF,

		}

		/// <summary>
		/// <para>Require Fresh Metadata</para>
		/// </summary>
		public enum RequireFreshMetadataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRE_FRESH_METADATA")]
			REQUIRE_FRESH_METADATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REQUIRE_FRESH_METADATA")]
			NO_REQUIRE_FRESH_METADATA,

		}

#endregion
	}
}
