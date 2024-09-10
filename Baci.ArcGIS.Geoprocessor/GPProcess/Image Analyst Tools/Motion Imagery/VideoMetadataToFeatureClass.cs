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
	/// <para>Extracts the platform, frame center, frame outline, and attributes metadata from an FMV-compliant video. The output geometry and attributes are saved as feature classes.</para>
	/// </summary>
	public class VideoMetadataToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVideo">
		/// <para>Input Video</para>
		/// <para>The FMV-compliant input video file containing essential metadata for each frame of the video data. The supported video file types include PS, TS, MPG, MPEG, MP2, MPG2, MPEG2, MP4, MPG4, MPEG4, H264, VOB, and M2TS.</para>
		/// </param>
		public VideoMetadataToFeatureClass(object InVideo)
		{
			this.InVideo = InVideo;
		}

		/// <summary>
		/// <para>Tool Display Name : Video Metadata To Feature Class</para>
		/// </summary>
		public override string DisplayName() => "Video Metadata To Feature Class";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InVideo, CsvFile, Flightpath, FlightpathType, Imagepath, ImagepathType, Footprint, StartTime, StopTime, MinDistance, MinTime };

		/// <summary>
		/// <para>Input Video</para>
		/// <para>The FMV-compliant input video file containing essential metadata for each frame of the video data. The supported video file types include PS, TS, MPG, MPEG, MP2, MPG2, MPEG2, MP4, MPG4, MPEG4, H264, VOB, and M2TS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object InVideo { get; set; }

		/// <summary>
		/// <para>Output Metadata File</para>
		/// <para>A comma-separated values (CSV) file containing metadata about the video frames for specific times.</para>
		/// <para>This metadata file is in the same format used by the Video Multiplexer tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object CsvFile { get; set; }

		/// <summary>
		/// <para>Output Flight Path Feature Class</para>
		/// <para>The feature class containing the sensor's flight path information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object Flightpath { get; set; }

		/// <summary>
		/// <para>Flight Path Feature Class Type</para>
		/// <para>Specifies the feature class type for the flight path.</para>
		/// <para>Point—Point feature class.</para>
		/// <para>Polyline—Polyline feature class. This is the default.</para>
		/// <para><see cref="FlightpathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FlightpathType { get; set; } = "POLYLINE";

		/// <summary>
		/// <para>Output Image Path Feature Class</para>
		/// <para>The output feature class containing the image path information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object Imagepath { get; set; }

		/// <summary>
		/// <para>Image Path Feature Class Type</para>
		/// <para>Specifies the feature class type for the image path. If you&apos;re using a point output, the center of each video frame image will appear on the map.</para>
		/// <para>Point—Point feature class.</para>
		/// <para>Polyline—Polyline feature class. This is the default.</para>
		/// <para><see cref="ImagepathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImagepathType { get; set; } = "POLYLINE";

		/// <summary>
		/// <para>Output Image Footprint Feature Class</para>
		/// <para>The output feature class containing the video image footprint information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object Footprint { get; set; }

		/// <summary>
		/// <para>Metadata Capture Start Time</para>
		/// <para>The metadata recording start time from the beginning of the video. The input format is d.hh:mm:ss, and the default start time is 0.00:00:00. Metadata time stamps are not used in this field; the time of the video file is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object StartTime { get; set; }

		/// <summary>
		/// <para>Metadata Capture Stop Time</para>
		/// <para>The metadata recording end time. The input format is d.hh:mm:ss. If not set, the value will default to the end of the video. Metadata time stamps are not used in this field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object StopTime { get; set; }

		/// <summary>
		/// <para>Minimum Distance Between Features</para>
		/// <para>The distance between the features in sequential video frames. If left blank, every metadata feature will be extracted and added to the feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinDistance { get; set; }

		/// <summary>
		/// <para>Minimum Time Between Features</para>
		/// <para>The time interval between the features in sequential video frames. If left blank, every metadata feature will be extracted and added to the feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object MinTime { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Flight Path Feature Class Type</para>
		/// </summary>
		public enum FlightpathTypeEnum 
		{
			/// <summary>
			/// <para>Point—Point feature class.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polyline—Polyline feature class. This is the default.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

		}

		/// <summary>
		/// <para>Image Path Feature Class Type</para>
		/// </summary>
		public enum ImagepathTypeEnum 
		{
			/// <summary>
			/// <para>Point—Point feature class.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polyline—Polyline feature class. This is the default.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

		}

#endregion
	}
}
