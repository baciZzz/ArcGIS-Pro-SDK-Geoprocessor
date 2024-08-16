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
	/// <para>Extracts video frame images and associated metadata from a FMV-compliant video stream.  The extracted images can be added to a mosaic dataset or other tools and functions for further analysis.</para>
	/// </summary>
	public class ExtractVideoFramesToImages : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVideo">
		/// <para>Input Video File</para>
		/// <para>The input video file in any of the supported video file types, including PS, TS, MPG, MPEG, MP2, MPG2, MPEG2, MP4, MPG4, MPEG4, H264, VOB, and M2TS.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>The file directory where the output images and metadata will be saved.</para>
		/// </param>
		/// <param name="ImageType">
		/// <para>Image Type</para>
		/// <para>The output image format.</para>
		/// <para>JPEG—JPEG image format.</para>
		/// <para>TIFF—TIFF image format. This is the default.</para>
		/// <para>NITF—NITF image format.</para>
		/// <para><see cref="ImageTypeEnum"/></para>
		/// </param>
		public ExtractVideoFramesToImages(object InVideo, object OutFolder, object ImageType)
		{
			this.InVideo = InVideo;
			this.OutFolder = OutFolder;
			this.ImageType = ImageType;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Video Frames To Images</para>
		/// </summary>
		public override string DisplayName => "Extract Video Frames To Images";

		/// <summary>
		/// <para>Tool Name : ExtractVideoFramesToImages</para>
		/// </summary>
		public override string ToolName => "ExtractVideoFramesToImages";

		/// <summary>
		/// <para>Tool Excute Name : ia.ExtractVideoFramesToImages</para>
		/// </summary>
		public override string ExcuteName => "ia.ExtractVideoFramesToImages";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InVideo, OutFolder, ImageType, ImageOverlap, RequireFreshMetadata, MinTime };

		/// <summary>
		/// <para>Input Video File</para>
		/// <para>The input video file in any of the supported video file types, including PS, TS, MPG, MPEG, MP2, MPG2, MPEG2, MP4, MPG4, MPEG4, H264, VOB, and M2TS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TS", "PS", "MPG", "MPEG", "MP2", "MPEG2", "MP4", "MPG4", "MPEG4", "H264", "VOB", "M2TS", "AVI", "MOV")]
		public object InVideo { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The file directory where the output images and metadata will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Image Type</para>
		/// <para>The output image format.</para>
		/// <para>JPEG—JPEG image format.</para>
		/// <para>TIFF—TIFF image format. This is the default.</para>
		/// <para>NITF—NITF image format.</para>
		/// <para><see cref="ImageTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImageType { get; set; } = "TIFF";

		/// <summary>
		/// <para>Maximum Overlap Percentage</para>
		/// <para>The maximum overlap percentage between two images. If the overlap between a candidate image and the last image written to disk is greater than this value, the candidate image will be ignored. The default percentage is 100%, which writes all images to disk.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ImageOverlap { get; set; } = "100";

		/// <summary>
		/// <para>Require Fresh Metadata</para>
		/// <para>Specifies whether video frames with associated metadata will be extracted and saved.</para>
		/// <para>Checked—Only video frames with associated metadata will be saved.</para>
		/// <para>Unchecked—All video frames will be saved. This is the default.</para>
		/// <para><see cref="RequireFreshMetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RequireFreshMetadata { get; set; } = "false";

		/// <summary>
		/// <para>Minimum Time Between Features</para>
		/// <para>The minimum time interval between video frames to be saved. If this is not specified, all video frames will be saved as images.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object MinTime { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Image Type</para>
		/// </summary>
		public enum ImageTypeEnum 
		{
			/// <summary>
			/// <para>JPEG—JPEG image format.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>TIFF—TIFF image format. This is the default.</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

			/// <summary>
			/// <para>NITF—NITF image format.</para>
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
			/// <para>Checked—Only video frames with associated metadata will be saved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRE_FRESH_METADATA")]
			REQUIRE_FRESH_METADATA,

			/// <summary>
			/// <para>Unchecked—All video frames will be saved. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REQUIRE_FRESH_METADATA")]
			NO_REQUIRE_FRESH_METADATA,

		}

#endregion
	}
}
