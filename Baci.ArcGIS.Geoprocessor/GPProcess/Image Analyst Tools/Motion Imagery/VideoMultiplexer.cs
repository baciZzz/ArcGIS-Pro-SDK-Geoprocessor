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
	/// <para>Creates a video file that combines an archived video stream file and an associated metadata file synchronized by a time stamp.</para>
	/// </summary>
	public class VideoMultiplexer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVideoFile">
		/// <para>Input Video File</para>
		/// <para>The input video file that will be converted to a FMV-compliant video file.</para>
		/// <para>The following video file types are supported: .avi (supports H.264, not H.265), .h264, .mp2, .mp4,.m2ts,.mpeg, .mpeg2, .mpeg4, .mpg, .mpg2, .mpg4, .ps, .ts, and vob.</para>
		/// </param>
		/// <param name="MetadataFile">
		/// <para>Metadata File</para>
		/// <para>A comma-separated values (CSV) file containing metadata about the video frames for specific times.</para>
		/// <para>Each column represents one metadata field, and one of the columns must be a time reference. The time reference is Unix Time Stamp (seconds past 1970) multiplied by one million, which is stored as an integer. The time is stored as such so that any instant in time (down to one millionth of a second) can be referenced with an integer. Consequently, a time difference between two entries of 500,000 represents one half of a second in elapsed time.</para>
		/// <para>The first row contains the field names for the metadata columns. These field names are listed in the FMV_Multiplexer_Field_Mapping_Template.csv file obtained from C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo, or your custom field names can be matched to their corresponding FMV field names using the template. Each subsequent row contains the metadata values for a specific time, called a time stamp.</para>
		/// <para>The metadata field names can be in any order and should be named exactly as listed in the FMV_Multiplexer_Field_Mapping_Template.csv template to map your metadata field names to the proper FMV metadata field names.</para>
		/// </param>
		/// <param name="OutVideoFile">
		/// <para>Output Video File</para>
		/// <para>The name of the output video file, including the file extension.</para>
		/// <para>Supported video files are as follows: .h264, .mp2, .mp4, .m2ts, .mpeg, .mpeg2, .mpeg4, .mpg, .mpg2, .mpg4, .ps, .ts, and vob.</para>
		/// </param>
		public VideoMultiplexer(object InVideoFile, object MetadataFile, object OutVideoFile)
		{
			this.InVideoFile = InVideoFile;
			this.MetadataFile = MetadataFile;
			this.OutVideoFile = OutVideoFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Video Multiplexer</para>
		/// </summary>
		public override string DisplayName() => "Video Multiplexer";

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
		/// <para>The input video file that will be converted to a FMV-compliant video file.</para>
		/// <para>The following video file types are supported: .avi (supports H.264, not H.265), .h264, .mp2, .mp4,.m2ts,.mpeg, .mpeg2, .mpeg4, .mpg, .mpg2, .mpg4, .ps, .ts, and vob.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object InVideoFile { get; set; }

		/// <summary>
		/// <para>Metadata File</para>
		/// <para>A comma-separated values (CSV) file containing metadata about the video frames for specific times.</para>
		/// <para>Each column represents one metadata field, and one of the columns must be a time reference. The time reference is Unix Time Stamp (seconds past 1970) multiplied by one million, which is stored as an integer. The time is stored as such so that any instant in time (down to one millionth of a second) can be referenced with an integer. Consequently, a time difference between two entries of 500,000 represents one half of a second in elapsed time.</para>
		/// <para>The first row contains the field names for the metadata columns. These field names are listed in the FMV_Multiplexer_Field_Mapping_Template.csv file obtained from C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo, or your custom field names can be matched to their corresponding FMV field names using the template. Each subsequent row contains the metadata values for a specific time, called a time stamp.</para>
		/// <para>The metadata field names can be in any order and should be named exactly as listed in the FMV_Multiplexer_Field_Mapping_Template.csv template to map your metadata field names to the proper FMV metadata field names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object MetadataFile { get; set; }

		/// <summary>
		/// <para>Output Video File</para>
		/// <para>The name of the output video file, including the file extension.</para>
		/// <para>Supported video files are as follows: .h264, .mp2, .mp4, .m2ts, .mpeg, .mpeg2, .mpeg4, .mpg, .mpg2, .mpg4, .ps, .ts, and vob.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object OutVideoFile { get; set; }

		/// <summary>
		/// <para>Metadata Mapping File</para>
		/// <para>A CSV file that contains 5 columns and 87 rows and is based on the FMV_Multiplexer_Field_Mapping_Template.csv template file obtained from C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo.</para>
		/// <para>This CSV file cross references your metadata field name to the FMV field name. Each row represents one of the standard metadata parameters, such as sensor latitude. The first two columns contain the information for the tag and MISB parameter name already provided in the form. The third column contains the field name as it appears in the Input Metadata File parameter. When the third column is populated, the software can match your metadata field names to the proper FMV metadata tags.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object MetadataMappingFile { get; set; }

		/// <summary>
		/// <para>Timeshift File</para>
		/// <para>A file containing defined time shift intervals.</para>
		/// <para>Ideally, the video images and the metadata are synchronized in time. When this is the case, the image footprint in full motion video surrounds features that can be seen in the video image. Sometimes there is a mismatch between the timing of the video and the timing in the metadata. This leads to an apparent time delay between when a ground feature is surrounded by the image footprint and when that ground feature is visible in the video image. If this time shift is observable and consistent, the multiplexer can adjust the timing of the metadata to match the video.</para>
		/// <para>If there is a mismatch between the timing of the video and metadata, specify the time shift in the FMV_Multiplexer_TimeShift_Template.csv template, obtained from C:\Program Files\ArcGIS\Pro\Resources\FullMotionVideo. The time shift observations file is a CSV file containing two columns (elapsed time and time shift) and one or more data rows. A row for column names is optional.</para>
		/// <para>For example, if the video image has a 5-second lag for the entire time, the time shift observation file would have one line: 0:00, -5. The entire video is shifted 5 seconds.</para>
		/// <para>If there is a 5-second lag at the 0:18 mark of the video, and a 9-second lag at the 2:21 mark of the video, the time shift observation file would have the following two lines:</para>
		/// <para>&lt;code&gt;0:18, -5 2:21, -9&lt;/code&gt;In this case, the video is shifted differently at the beginning of the video and at the end of the video.</para>
		/// <para>You can define any number of time shift intervals in the time shift observation file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object TimeshiftFile { get; set; }

		/// <summary>
		/// <para>Digital Elevation Model</para>
		/// <para>The source of the elevation needed for calculating the video frame corner coordinates. The source can be a layer, image service, or an average ground elevation or ocean depth. The average elevation value needs to include the units of measurement such as meters or feet or other measure of length.</para>
		/// <para>The accuracy of the video footprint and frame center depends on the accuracy of the DEM data source provided. It is recommended that you provide a DEM layer or image service. If you do not have access to DEM data, you can enter an average elevation and unit relative to sea level, such as 15 feet or 10 meters. In the case of a submersible, you can enter -15 feet or -10 meters. Using an average elevation or ocean depth is not as accurate as providing a DEM or bathymetric data.</para>
		/// <para>To calculate frame corner coordinates, the average elevation value must always be less than the sensor&apos;s altitude or depth as recorded in the metadata. For example, if the video was filmed at a sensor altitude of 10 meters and higher, a valid average elevation could be 9 meters or less. If a video was filmed underwater at a depth of -10 meters and deeper, the valid average elevation (relative to sea level) could be -11 or deeper. If the Sensor Altitude value is less than the average elevation value, the four corner coordinates will not be calculated for that record. If you do not know the average elevation of your project area, use a DEM.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object ElevationLayer { get; set; }

	}
}
