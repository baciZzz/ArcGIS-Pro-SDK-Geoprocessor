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
	/// <para>Video Metadata To Feature Class</para>
	/// <para>视频元数据至要素类</para>
	/// <para>从兼容 FMV 的视频中提取平台、帧中心、帧轮廓和属性元数据。 输出几何和属性将保存为要素类。</para>
	/// </summary>
	public class VideoMetadataToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVideo">
		/// <para>Input Video</para>
		/// <para>兼容 FMV 的输入视频文件，其中包含对应视频数据中每一帧的基本元数据。 受支持的视频文件类型包括 PS、TS、MPG、MPEG、MP2、MPG2、MPEG2、MP4、MPG4、MPEG4、H264、VOB 和 M2TS。</para>
		/// </param>
		public VideoMetadataToFeatureClass(object InVideo)
		{
			this.InVideo = InVideo;
		}

		/// <summary>
		/// <para>Tool Display Name : 视频元数据至要素类</para>
		/// </summary>
		public override string DisplayName() => "视频元数据至要素类";

		/// <summary>
		/// <para>Tool Name : VideoMetadataToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "VideoMetadataToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : ia.VideoMetadataToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "ia.VideoMetadataToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "outputZFlag" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InVideo, CsvFile!, Flightpath!, FlightpathType!, Imagepath!, ImagepathType!, Footprint!, StartTime!, StopTime!, MinDistance!, MinTime! };

		/// <summary>
		/// <para>Input Video</para>
		/// <para>兼容 FMV 的输入视频文件，其中包含对应视频数据中每一帧的基本元数据。 受支持的视频文件类型包括 PS、TS、MPG、MPEG、MP2、MPG2、MPEG2、MP4、MPG4、MPEG4、H264、VOB 和 M2TS。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object InVideo { get; set; }

		/// <summary>
		/// <para>Output Metadata File</para>
		/// <para>逗号分隔值 (CSV) 文件，其中包含有关特定时间的视频帧的元数据。</para>
		/// <para>此元数据文件的格式与视频多路复用器工具所使用的格式相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object? CsvFile { get; set; }

		/// <summary>
		/// <para>Output Flight Path Feature Class</para>
		/// <para>包含传感器飞行路径信息的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object? Flightpath { get; set; }

		/// <summary>
		/// <para>Flight Path Feature Class Type</para>
		/// <para>用于指定飞行路径的要素类类型。</para>
		/// <para>点—点要素类。</para>
		/// <para>折线—折线要素类。 这是默认设置。</para>
		/// <para><see cref="FlightpathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlightpathType { get; set; } = "POLYLINE";

		/// <summary>
		/// <para>Output Image Path Feature Class</para>
		/// <para>包含影像路径信息的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object? Imagepath { get; set; }

		/// <summary>
		/// <para>Image Path Feature Class Type</para>
		/// <para>用于指定影像路径的要素类类型。 如果您所使用的是点输出，则每个视频帧图像的中心都将显示在地图上。</para>
		/// <para>点—点要素类。</para>
		/// <para>折线—折线要素类。 这是默认设置。</para>
		/// <para><see cref="ImagepathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ImagepathType { get; set; } = "POLYLINE";

		/// <summary>
		/// <para>Output Image Footprint Feature Class</para>
		/// <para>包含视频影像轮廓线信息的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object? Footprint { get; set; }

		/// <summary>
		/// <para>Metadata Capture Start Time</para>
		/// <para>记录视频开头的开始时间的元数据。 输入格式为 d.hh:mm:ss，且默认开始时间为 0.00:00:00。 此字段中不使用元数据时间戳；将使用视频文件中的时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? StartTime { get; set; }

		/// <summary>
		/// <para>Metadata Capture Stop Time</para>
		/// <para>记录结束时间的元数据。 其输入格式为 d.hh:mm:ss。 如果未进行设置，则该值将默认为视频结尾的时间。 此字段中不使用元数据时间戳。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? StopTime { get; set; }

		/// <summary>
		/// <para>Minimum Distance Between Features</para>
		/// <para>连续视频帧中要素之间的距离。 如果将其留空，则将提取每个元数据要素并将其添加到要素类中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinDistance { get; set; }

		/// <summary>
		/// <para>Minimum Time Between Features</para>
		/// <para>连续视频帧中要素之间的时间间隔。 如果将其留空，则将提取每个元数据要素并将其添加到要素类中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object? MinTime { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public VideoMetadataToFeatureClass SetEnviroment(object? outputZFlag = null)
		{
			base.SetEnv(outputZFlag: outputZFlag);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Flight Path Feature Class Type</para>
		/// </summary>
		public enum FlightpathTypeEnum 
		{
			/// <summary>
			/// <para>点—点要素类。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>折线—折线要素类。 这是默认设置。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

		/// <summary>
		/// <para>Image Path Feature Class Type</para>
		/// </summary>
		public enum ImagepathTypeEnum 
		{
			/// <summary>
			/// <para>点—点要素类。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>折线—折线要素类。 这是默认设置。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

#endregion
	}
}
