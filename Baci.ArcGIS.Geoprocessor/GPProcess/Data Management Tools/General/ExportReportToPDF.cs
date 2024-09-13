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
	/// <para>Export Report To PDF</para>
	/// <para>Export Report To PDF</para>
	/// <para>Exports an ArcGIS Pro report to a PDF file.</para>
	/// </summary>
	public class ExportReportToPDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InReport">
		/// <para>Input Report</para>
		/// <para>The input report or .rptx file.</para>
		/// </param>
		/// <param name="OutPdfFile">
		/// <para>PDF File</para>
		/// <para>The output PDF file.</para>
		/// </param>
		public ExportReportToPDF(object InReport, object OutPdfFile)
		{
			this.InReport = InReport;
			this.OutPdfFile = OutPdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Report To PDF</para>
		/// </summary>
		public override string DisplayName() => "Export Report To PDF";

		/// <summary>
		/// <para>Tool Name : ExportReportToPDF</para>
		/// </summary>
		public override string ToolName() => "ExportReportToPDF";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportReportToPDF</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportReportToPDF";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InReport, OutPdfFile, Expression!, Resolution!, ImageQuality!, EmbedFont!, CompressVectorGraphics!, ImageCompression!, PasswordProtect!, PdfPassword!, PageRangeType!, CustomPageRange!, InitialPageNumber!, FinalPageNumber! };

		/// <summary>
		/// <para>Input Report</para>
		/// <para>The input report or .rptx file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InReport { get; set; }

		/// <summary>
		/// <para>PDF File</para>
		/// <para>The output PDF file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object OutPdfFile { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records. This expression is applied in addition to any existing expressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Data Definition")]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Resolution (DPI)</para>
		/// <para>The resolution of the exported PDF in dots per inch (dpi).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Export Options")]
		public object? Resolution { get; set; } = "96";

		/// <summary>
		/// <para>Image Quality</para>
		/// <para>Specifies the output image quality of the PDF. The image quality option controls the quality of rasterized data going into the export.</para>
		/// <para>Best—The highest available image quality. This is the default.</para>
		/// <para>Better—High image quality.</para>
		/// <para>Normal—A compromise between image quality and speed.</para>
		/// <para>Faster—Lower image quality to generate the report faster.</para>
		/// <para>Fastest—The lowest image quality to create the report the fastest.</para>
		/// <para><see cref="ImageQualityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? ImageQuality { get; set; } = "BEST";

		/// <summary>
		/// <para>Embed Fonts</para>
		/// <para>Specifies whether fonts are embedded in the output report. Font embedding allows text and markers built from font glyphs to be displayed correctly when the PDF is viewed on a computer that does not have the necessary fonts installed.</para>
		/// <para>Checked—Fonts will be embedded in the output report. This is the default.</para>
		/// <para>Unchecked—Fonts will not be embedded in the output report.</para>
		/// <para><see cref="EmbedFontEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? EmbedFont { get; set; } = "true";

		/// <summary>
		/// <para>Compress Vector Graphics</para>
		/// <para>Specifies whether to compress the vector content streams in the PDF.</para>
		/// <para>Checked—Vector graphics will be compressed. This option should be set unless clear text is desired for troubleshooting. This is the default.</para>
		/// <para>Unchecked—Vector graphics will not be compressed.</para>
		/// <para><see cref="CompressVectorGraphicsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? CompressVectorGraphics { get; set; } = "true";

		/// <summary>
		/// <para>Image Compression</para>
		/// <para>Specifies the compression scheme used to compress image or raster data in the output PDF file.</para>
		/// <para>No image compression—Do not compress image or raster data.</para>
		/// <para>Run-length encoded (RLE) compression—Uses Run-length encoded compression.</para>
		/// <para>Deflate compression—Uses Deflate, a lossless data compression.</para>
		/// <para>Lempel-Ziv-Welch (LZW) compression—Uses Lempel-Ziv-Welch, a lossless data compression.</para>
		/// <para>Joint Photographic Experts Group (JPEG) compression—Uses JPEG, a lossy data compression.</para>
		/// <para>Adaptive compression—Uses Adaptive, which automatically selects the best compression type for each image on the page. JPEG will be used for large images with many unique colors. Deflate will be used for all other images. This is the default.</para>
		/// <para><see cref="ImageCompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? ImageCompression { get; set; } = "ADAPTIVE";

		/// <summary>
		/// <para>Password Protect</para>
		/// <para>Specifies whether password protection is needed to view the output PDF report.</para>
		/// <para>Checked—The output PDF report document will require a password to open.</para>
		/// <para>Unchecked—The output PDF report document can be opened without providing a password. This is the default.</para>
		/// <para><see cref="PasswordProtectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? PasswordProtect { get; set; } = "false";

		/// <summary>
		/// <para>PDF Password</para>
		/// <para>A password to restrict opening the PDF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		[Category("Export Options")]
		public object? PdfPassword { get; set; }

		/// <summary>
		/// <para>Page Range Type</para>
		/// <para>Specifies the page range of the report to export.</para>
		/// <para>All pages—Export all pages. This is the default.</para>
		/// <para>Last page—Export the last page only.</para>
		/// <para>Odd numbered pages—Export the odd numbered pages.</para>
		/// <para>Even numbered pages—Export the even numbered pages.</para>
		/// <para>Custom page range—Export a custom page range.</para>
		/// <para><see cref="PageRangeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Page Range Options")]
		public object? PageRangeType { get; set; } = "ALL";

		/// <summary>
		/// <para>Custom Page Range</para>
		/// <para>The pages to be exported when the Page Range Type parameter is set to Custom. You can set individual pages, ranges, or a combination of both separated by commas, such as 1, 3-5, 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Page Range Options")]
		public object? CustomPageRange { get; set; }

		/// <summary>
		/// <para>Initial Page Number</para>
		/// <para>The initial page number of the report to create a page numbering offset to add additional pages to the beginning of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Page Range Options")]
		public object? InitialPageNumber { get; set; }

		/// <summary>
		/// <para>Final Page Number</para>
		/// <para>The page number to display on the last page of the exported PDF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Page Range Options")]
		public object? FinalPageNumber { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Image Quality</para>
		/// </summary>
		public enum ImageQualityEnum 
		{
			/// <summary>
			/// <para>Best—The highest available image quality. This is the default.</para>
			/// </summary>
			[GPValue("BEST")]
			[Description("Best")]
			Best,

			/// <summary>
			/// <para>Better—High image quality.</para>
			/// </summary>
			[GPValue("BETTER")]
			[Description("Better")]
			Better,

			/// <summary>
			/// <para>Normal—A compromise between image quality and speed.</para>
			/// </summary>
			[GPValue("NORMAL")]
			[Description("Normal")]
			Normal,

			/// <summary>
			/// <para>Faster—Lower image quality to generate the report faster.</para>
			/// </summary>
			[GPValue("FASTER")]
			[Description("Faster")]
			Faster,

			/// <summary>
			/// <para>Fastest—The lowest image quality to create the report the fastest.</para>
			/// </summary>
			[GPValue("FASTEST")]
			[Description("Fastest")]
			Fastest,

		}

		/// <summary>
		/// <para>Embed Fonts</para>
		/// </summary>
		public enum EmbedFontEnum 
		{
			/// <summary>
			/// <para>Checked—Fonts will be embedded in the output report. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EMBED_FONTS")]
			EMBED_FONTS,

			/// <summary>
			/// <para>Unchecked—Fonts will not be embedded in the output report.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EMBED_FONTS")]
			NO_EMBED_FONTS,

		}

		/// <summary>
		/// <para>Compress Vector Graphics</para>
		/// </summary>
		public enum CompressVectorGraphicsEnum 
		{
			/// <summary>
			/// <para>Checked—Vector graphics will be compressed. This option should be set unless clear text is desired for troubleshooting. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPRESS_GRAPHICS")]
			COMPRESS_GRAPHICS,

			/// <summary>
			/// <para>Unchecked—Vector graphics will not be compressed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPRESS_GRAPHICS")]
			NO_COMPRESS_GRAPHICS,

		}

		/// <summary>
		/// <para>Image Compression</para>
		/// </summary>
		public enum ImageCompressionEnum 
		{
			/// <summary>
			/// <para>No image compression—Do not compress image or raster data.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No image compression")]
			No_image_compression,

			/// <summary>
			/// <para>Run-length encoded (RLE) compression—Uses Run-length encoded compression.</para>
			/// </summary>
			[GPValue("RLE")]
			[Description("Run-length encoded (RLE) compression")]
			RLE,

			/// <summary>
			/// <para>Deflate compression—Uses Deflate, a lossless data compression.</para>
			/// </summary>
			[GPValue("DEFLATE")]
			[Description("Deflate compression")]
			Deflate_compression,

			/// <summary>
			/// <para>Lempel-Ziv-Welch (LZW) compression—Uses Lempel-Ziv-Welch, a lossless data compression.</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("Lempel-Ziv-Welch (LZW) compression")]
			LZW,

			/// <summary>
			/// <para>Joint Photographic Experts Group (JPEG) compression—Uses JPEG, a lossy data compression.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Joint Photographic Experts Group (JPEG) compression")]
			JPEG,

			/// <summary>
			/// <para>Adaptive compression—Uses Adaptive, which automatically selects the best compression type for each image on the page. JPEG will be used for large images with many unique colors. Deflate will be used for all other images. This is the default.</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("Adaptive compression")]
			Adaptive_compression,

		}

		/// <summary>
		/// <para>Password Protect</para>
		/// </summary>
		public enum PasswordProtectEnum 
		{
			/// <summary>
			/// <para>Checked—The output PDF report document will require a password to open.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PASSWORD_PROTECT")]
			PASSWORD_PROTECT,

			/// <summary>
			/// <para>Unchecked—The output PDF report document can be opened without providing a password. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PASSWORD_PROTECT")]
			NO_PASSWORD_PROTECT,

		}

		/// <summary>
		/// <para>Page Range Type</para>
		/// </summary>
		public enum PageRangeTypeEnum 
		{
			/// <summary>
			/// <para>All pages—Export all pages. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All pages")]
			All_pages,

			/// <summary>
			/// <para>Last page—Export the last page only.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last page")]
			Last_page,

			/// <summary>
			/// <para>Odd numbered pages—Export the odd numbered pages.</para>
			/// </summary>
			[GPValue("ODD")]
			[Description("Odd numbered pages")]
			Odd_numbered_pages,

			/// <summary>
			/// <para>Even numbered pages—Export the even numbered pages.</para>
			/// </summary>
			[GPValue("EVEN")]
			[Description("Even numbered pages")]
			Even_numbered_pages,

			/// <summary>
			/// <para>Custom page range—Export a custom page range.</para>
			/// </summary>
			[GPValue("CUSTOM")]
			[Description("Custom page range")]
			Custom_page_range,

		}

#endregion
	}
}
