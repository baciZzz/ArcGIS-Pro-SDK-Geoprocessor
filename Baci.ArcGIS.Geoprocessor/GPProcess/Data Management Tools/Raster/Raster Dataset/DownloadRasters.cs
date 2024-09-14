using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Download Rasters</para>
	/// <para>Download Rasters</para>
	/// <para>Downloads the source  files from an image service or mosaic dataset.</para>
	/// </summary>
	public class DownloadRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InImageService">
		/// <para>Input</para>
		/// <para>The image service or mosaic dataset to download.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>The destination for the image service or mosaic dataset.</para>
		/// </param>
		public DownloadRasters(object InImageService, object OutFolder)
		{
			this.InImageService = InImageService;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Download Rasters</para>
		/// </summary>
		public override string DisplayName() => "Download Rasters";

		/// <summary>
		/// <para>Tool Name : DownloadRasters</para>
		/// </summary>
		public override string ToolName() => "DownloadRasters";

		/// <summary>
		/// <para>Tool Excute Name : management.DownloadRasters</para>
		/// </summary>
		public override string ExcuteName() => "management.DownloadRasters";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InImageService, OutFolder, WhereClause, SelectionFeature, Clipping, ConvertRasters, Format, CompressionMethod, CompressionQuality, MAINTAINFOLDER, DerivedOutFolder };

		/// <summary>
		/// <para>Input</para>
		/// <para>The image service or mosaic dataset to download.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InImageService { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The destination for the image service or mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to limit the download to raster datasets that satisfy the expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Selection Feature</para>
		/// <para>Limits the download to an extent of a feature class or bounding box. All raster datasets that intersect the extent will be downloaded.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object SelectionFeature { get; set; }

		/// <summary>
		/// <para>Clipping Using Selection Feature</para>
		/// <para>Specify if you want to clip the downloaded images based on the geometry of a feature. Any raster that intersects the clipping geometry will be clipped and then downloaded. This is useful when your area of interest is not a rectangle. When downloaded images are clipped, you need to specify an output format for the clipped images.</para>
		/// <para>Unchecked—The files will be clipped based on the minimum bounding rectangle that has been specified. This is the default.</para>
		/// <para>Checked—The files will be clipped based on the geometry of the Selection Feature.</para>
		/// <para><see cref="ClippingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Clipping { get; set; } = "false";

		/// <summary>
		/// <para>Convert Rasters</para>
		/// <para>Choose whether to always convert your rasters to the specified format, or to only convert when it is necessary.</para>
		/// <para>Unchecked—Do not convert the raster datasets to a new format.</para>
		/// <para>Checked—Convert the downloaded raster datasets into another format. If you used Selection Feature to limit the extent, then you need to specify a format in the Output Format parameter.</para>
		/// <para><see cref="ConvertRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertRasters { get; set; } = "false";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>Choose a output format for the downloaded raster datasets.</para>
		/// <para>Tiff—Tagged Image File Format. This is the default.</para>
		/// <para>Bil—Esri band interleaved by line.</para>
		/// <para>Bsq—Esri band sequential.</para>
		/// <para>Bip—Esri band interleaved by pixel.</para>
		/// <para>Bmp—Bitmap.</para>
		/// <para>ENVI Dat—ENVI DAT file.</para>
		/// <para>Imagine image—ERDAS IMAGINE.</para>
		/// <para>Jpeg—Joint Photographics Experts Group. If chosen, you can also specify the compression quality. The valid compression quality value ranges are from 0 to 100.</para>
		/// <para>Gif—Graphic interchange format.</para>
		/// <para>Jp2—JPEG 2000. If chosen, you can also specify the compression quality. The valid compression quality value ranges are from 0 to 100.</para>
		/// <para>Png—Portable Network Graphics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>Choose the compression method to use with the specified Output Format.</para>
		/// <para>None—No compression will occur. This is the default.</para>
		/// <para>Jpeg—Lossy compression that uses the public JPEG compression algorithm. If you choose JPEG, you can also specify the compression quality. The valid compression quality value ranges are from 0 to 100. This compression can be used for JPEG files and TIFF files.</para>
		/// <para>Lzw—Lossless compression that preserves all raster cell values.</para>
		/// <para>Packbits—PackBits compression for TIFF files.</para>
		/// <para>Rle—Run-length encoding for IMG files.</para>
		/// <para>Ccitt Group 3—Lossless compression for 1-bit data.</para>
		/// <para>Ccitt Group 4—Lossless compression for 1-bit data.</para>
		/// <para>Ccitt 1D—Lossless compression for 1-bit data.</para>
		/// <para><see cref="CompressionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompressionMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>Set a value from 1 - 100. Higher values will have better image quality, but less compression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CompressionQuality { get; set; }

		/// <summary>
		/// <para>Maintain Folder Structure</para>
		/// <para>Determines the folder structure of the downloaded rasters.</para>
		/// <para>Checked—replicates the hierarchical folder structure used to store the source raster datasets.</para>
		/// <para>Unchecked—raster datasets will be downloaded into the output folder as a flat folder structure</para>
		/// <para><see cref="MAINTAINFOLDEREnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MAINTAINFOLDER { get; set; } = "false";

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DownloadRasters SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clipping Using Selection Feature</para>
		/// </summary>
		public enum ClippingEnum 
		{
			/// <summary>
			/// <para>Checked—The files will be clipped based on the geometry of the Selection Feature.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIPPING")]
			CLIPPING,

			/// <summary>
			/// <para>Unchecked—The files will be clipped based on the minimum bounding rectangle that has been specified. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIPPING")]
			NO_CLIPPING,

		}

		/// <summary>
		/// <para>Convert Rasters</para>
		/// </summary>
		public enum ConvertRastersEnum 
		{
			/// <summary>
			/// <para>Checked—Convert the downloaded raster datasets into another format. If you used Selection Feature to limit the extent, then you need to specify a format in the Output Format parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALWAYS_CONVERT")]
			ALWAYS_CONVERT,

			/// <summary>
			/// <para>Unchecked—Do not convert the raster datasets to a new format.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_AS_REQUIRED")]
			CONVERT_AS_REQUIRED,

		}

		/// <summary>
		/// <para>Compression Method</para>
		/// </summary>
		public enum CompressionMethodEnum 
		{
			/// <summary>
			/// <para>None—No compression will occur. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Jpeg—Lossy compression that uses the public JPEG compression algorithm. If you choose JPEG, you can also specify the compression quality. The valid compression quality value ranges are from 0 to 100. This compression can be used for JPEG files and TIFF files.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Jpeg")]
			Jpeg,

			/// <summary>
			/// <para>Lzw—Lossless compression that preserves all raster cell values.</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("Lzw")]
			Lzw,

			/// <summary>
			/// <para>Packbits—PackBits compression for TIFF files.</para>
			/// </summary>
			[GPValue("PACKBITS")]
			[Description("Packbits")]
			Packbits,

			/// <summary>
			/// <para>Rle—Run-length encoding for IMG files.</para>
			/// </summary>
			[GPValue("RLE")]
			[Description("Rle")]
			Rle,

			/// <summary>
			/// <para>Ccitt Group 3—Lossless compression for 1-bit data.</para>
			/// </summary>
			[GPValue("CCITT_GROUP3")]
			[Description("Ccitt Group 3")]
			Ccitt_Group_3,

			/// <summary>
			/// <para>Ccitt Group 4—Lossless compression for 1-bit data.</para>
			/// </summary>
			[GPValue("CCITT_GROUP4")]
			[Description("Ccitt Group 4")]
			Ccitt_Group_4,

			/// <summary>
			/// <para>Ccitt 1D—Lossless compression for 1-bit data.</para>
			/// </summary>
			[GPValue("CCITT_1D")]
			[Description("Ccitt 1D")]
			Ccitt_1D,

		}

		/// <summary>
		/// <para>Maintain Folder Structure</para>
		/// </summary>
		public enum MAINTAINFOLDEREnum 
		{
			/// <summary>
			/// <para>Checked—replicates the hierarchical folder structure used to store the source raster datasets.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_FOLDER")]
			MAINTAIN_FOLDER,

			/// <summary>
			/// <para>Unchecked—raster datasets will be downloaded into the output folder as a flat folder structure</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAINTAIN_FOLDER")]
			NO_MAINTAIN_FOLDER,

		}

#endregion
	}
}
