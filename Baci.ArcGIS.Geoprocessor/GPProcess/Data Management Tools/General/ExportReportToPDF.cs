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
	/// <para>将报表导出为 PDF</para>
	/// <para>将 ArcGIS Pro 报表导出至 PDF 文件。</para>
	/// </summary>
	public class ExportReportToPDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InReport">
		/// <para>Input Report</para>
		/// <para>输入报表或 .rptx 文件。</para>
		/// </param>
		/// <param name="OutPdfFile">
		/// <para>PDF File</para>
		/// <para>输出 PDF 文件。</para>
		/// </param>
		public ExportReportToPDF(object InReport, object OutPdfFile)
		{
			this.InReport = InReport;
			this.OutPdfFile = OutPdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 将报表导出为 PDF</para>
		/// </summary>
		public override string DisplayName() => "将报表导出为 PDF";

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
		/// <para>输入报表或 .rptx 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InReport { get; set; }

		/// <summary>
		/// <para>PDF File</para>
		/// <para>输出 PDF 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object OutPdfFile { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。除了任何现有表达式之外，还应用此表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Data Definition")]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Resolution (DPI)</para>
		/// <para>已导出 PDF 的分辨率，单位为每英寸点数 (dpi)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Export Options")]
		public object? Resolution { get; set; } = "96";

		/// <summary>
		/// <para>Image Quality</para>
		/// <para>指定 PDF 的输出图像质量。“图像质量”选项用于控制要导出的栅格化数据的质量。</para>
		/// <para>最佳—可用的最高图像质量。这是默认设置。</para>
		/// <para>更佳—高图像质量。</para>
		/// <para>正常—图像质量和速度之间的折衷。</para>
		/// <para>较快—图像质量越低，报表生成速度越快。</para>
		/// <para>最快—图像质量最低时，创建报表的速度最快。</para>
		/// <para><see cref="ImageQualityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? ImageQuality { get; set; } = "BEST";

		/// <summary>
		/// <para>Embed Fonts</para>
		/// <para>指定是否在输出报表中嵌入字体。当在未安装所需字体的计算机上查看 PDF 时，允许在字体嵌入中使用基于字体字形构建的文本和标记。</para>
		/// <para>选中 - 将在输出报表中嵌入字体。这是默认设置。</para>
		/// <para>未选中 - 不会在输出报表中嵌入字体。</para>
		/// <para><see cref="EmbedFontEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? EmbedFont { get; set; } = "true";

		/// <summary>
		/// <para>Compress Vector Graphics</para>
		/// <para>指定是否在 PDF 中压缩矢量内容流。</para>
		/// <para>选中 - 将压缩矢量图形。应设置此选项，除非需要使用明文进行故障排除。这是默认设置。</para>
		/// <para>未选中 - 不会压缩矢量图形。</para>
		/// <para><see cref="CompressVectorGraphicsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? CompressVectorGraphics { get; set; } = "true";

		/// <summary>
		/// <para>Image Compression</para>
		/// <para>指定在输出 PDF 文件中压缩图像或栅格数据时使用的压缩方案。</para>
		/// <para>无图像压缩—请勿压缩图像或栅格数据。</para>
		/// <para>游程编码 (RLE) 压缩—使用游程编码压缩。</para>
		/// <para>Deflate 压缩—使用 Deflate 无损数据压缩。</para>
		/// <para>Lempel-Ziv-Welch (LZW) 压缩—使用 Lempel-Ziv-Welch 无损数据压缩。</para>
		/// <para>联合图像专家组 (JPEG) 压缩—使用 JPEG 有损数据压缩。</para>
		/// <para>Adaptive 压缩—使用自动为页面中的每个图像选择最佳压缩类型的 Adaptive。JPEG 适用于包含许多唯一颜色的较大图像。Deflate 适用于所有其他图像。这是默认设置。</para>
		/// <para><see cref="ImageCompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? ImageCompression { get; set; } = "ADAPTIVE";

		/// <summary>
		/// <para>Password Protect</para>
		/// <para>指定是否需要密码保护才能查看输出 PDF 报表。</para>
		/// <para>选中 - 输出 PDF 报表文档需要密码才能打开。</para>
		/// <para>未选中 - 无需提供密码即可打开输出 PDF 报表文档。这是默认设置。</para>
		/// <para><see cref="PasswordProtectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Export Options")]
		public object? PasswordProtect { get; set; } = "false";

		/// <summary>
		/// <para>PDF Password</para>
		/// <para>用于限制打开 PDF 的密码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		[Category("Export Options")]
		public object? PdfPassword { get; set; }

		/// <summary>
		/// <para>Page Range Type</para>
		/// <para>指定要导出的报表页面范围。</para>
		/// <para>所有页面—导出所有页面。这是默认设置。</para>
		/// <para>最后一页—仅导出最后一页。</para>
		/// <para>奇数页面—导出奇数页面。</para>
		/// <para>偶数页面—导出偶数页面。</para>
		/// <para>自定义页面范围—导出自定义页面范围。</para>
		/// <para><see cref="PageRangeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Page Range Options")]
		public object? PageRangeType { get; set; } = "ALL";

		/// <summary>
		/// <para>Custom Page Range</para>
		/// <para>页面范围类型参数设置为自定义时要导出的页面。可设置单独页面、范围或者以逗号分隔的两者组合，例如 1, 3-5, 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Page Range Options")]
		public object? CustomPageRange { get; set; }

		/// <summary>
		/// <para>Initial Page Number</para>
		/// <para>报表的初始页码来创建页面编号偏移，以将其他页面添加到报表开头。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Page Range Options")]
		public object? InitialPageNumber { get; set; }

		/// <summary>
		/// <para>Final Page Number</para>
		/// <para>要在导出的 PDF 最后一页上显示的页码。</para>
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
			/// <para>最佳—可用的最高图像质量。这是默认设置。</para>
			/// </summary>
			[GPValue("BEST")]
			[Description("最佳")]
			Best,

			/// <summary>
			/// <para>更佳—高图像质量。</para>
			/// </summary>
			[GPValue("BETTER")]
			[Description("更佳")]
			Better,

			/// <summary>
			/// <para>正常—图像质量和速度之间的折衷。</para>
			/// </summary>
			[GPValue("NORMAL")]
			[Description("正常")]
			Normal,

			/// <summary>
			/// <para>较快—图像质量越低，报表生成速度越快。</para>
			/// </summary>
			[GPValue("FASTER")]
			[Description("较快")]
			Faster,

			/// <summary>
			/// <para>最快—图像质量最低时，创建报表的速度最快。</para>
			/// </summary>
			[GPValue("FASTEST")]
			[Description("最快")]
			Fastest,

		}

		/// <summary>
		/// <para>Embed Fonts</para>
		/// </summary>
		public enum EmbedFontEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EMBED_FONTS")]
			EMBED_FONTS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPRESS_GRAPHICS")]
			COMPRESS_GRAPHICS,

			/// <summary>
			/// <para></para>
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
			/// <para>无图像压缩—请勿压缩图像或栅格数据。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无图像压缩")]
			No_image_compression,

			/// <summary>
			/// <para>游程编码 (RLE) 压缩—使用游程编码压缩。</para>
			/// </summary>
			[GPValue("RLE")]
			[Description("游程编码 (RLE) 压缩")]
			RLE,

			/// <summary>
			/// <para>Deflate 压缩—使用 Deflate 无损数据压缩。</para>
			/// </summary>
			[GPValue("DEFLATE")]
			[Description("Deflate 压缩")]
			Deflate_compression,

			/// <summary>
			/// <para>Lempel-Ziv-Welch (LZW) 压缩—使用 Lempel-Ziv-Welch 无损数据压缩。</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("Lempel-Ziv-Welch (LZW) 压缩")]
			LZW,

			/// <summary>
			/// <para>联合图像专家组 (JPEG) 压缩—使用 JPEG 有损数据压缩。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("联合图像专家组 (JPEG) 压缩")]
			JPEG,

			/// <summary>
			/// <para>Adaptive 压缩—使用自动为页面中的每个图像选择最佳压缩类型的 Adaptive。JPEG 适用于包含许多唯一颜色的较大图像。Deflate 适用于所有其他图像。这是默认设置。</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("Adaptive 压缩")]
			Adaptive_compression,

		}

		/// <summary>
		/// <para>Password Protect</para>
		/// </summary>
		public enum PasswordProtectEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PASSWORD_PROTECT")]
			PASSWORD_PROTECT,

			/// <summary>
			/// <para></para>
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
			/// <para>所有页面—导出所有页面。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有页面")]
			All_pages,

			/// <summary>
			/// <para>最后一页—仅导出最后一页。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后一页")]
			Last_page,

			/// <summary>
			/// <para>奇数页面—导出奇数页面。</para>
			/// </summary>
			[GPValue("ODD")]
			[Description("奇数页面")]
			Odd_numbered_pages,

			/// <summary>
			/// <para>偶数页面—导出偶数页面。</para>
			/// </summary>
			[GPValue("EVEN")]
			[Description("偶数页面")]
			Even_numbered_pages,

			/// <summary>
			/// <para>自定义页面范围—导出自定义页面范围。</para>
			/// </summary>
			[GPValue("CUSTOM")]
			[Description("自定义页面范围")]
			Custom_page_range,

		}

#endregion
	}
}
