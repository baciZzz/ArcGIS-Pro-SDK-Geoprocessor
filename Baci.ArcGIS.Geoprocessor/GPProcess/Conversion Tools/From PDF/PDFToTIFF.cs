using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>PDF To TIFF</para>
	/// <para>PDF 转 TIFF</para>
	/// <para>将 .pdf 文件导出为标记图像文件格式 (TIFF)。</para>
	/// </summary>
	public class PDFToTIFF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPdfFile">
		/// <para>Input PDF File</para>
		/// <para>要导出到 TIFF 的输入 .pdf 文件。</para>
		/// </param>
		/// <param name="OutTiffFile">
		/// <para>Output TIFF File</para>
		/// <para>输出 .tif 文件。</para>
		/// </param>
		public PDFToTIFF(object InPdfFile, object OutTiffFile)
		{
			this.InPdfFile = InPdfFile;
			this.OutTiffFile = OutTiffFile;
		}

		/// <summary>
		/// <para>Tool Display Name : PDF 转 TIFF</para>
		/// </summary>
		public override string DisplayName() => "PDF 转 TIFF";

		/// <summary>
		/// <para>Tool Name : PDFToTIFF</para>
		/// </summary>
		public override string ToolName() => "PDFToTIFF";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PDFToTIFF</para>
		/// </summary>
		public override string ExcuteName() => "conversion.PDFToTIFF";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPdfFile, OutTiffFile, PdfPassword!, PdfPageNumber!, PdfMap!, ClipOption!, Resolution!, ColorMode!, TiffCompression!, GeotiffTags! };

		/// <summary>
		/// <para>Input PDF File</para>
		/// <para>要导出到 TIFF 的输入 .pdf 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object InPdfFile { get; set; }

		/// <summary>
		/// <para>Output TIFF File</para>
		/// <para>输出 .tif 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutTiffFile { get; set; }

		/// <summary>
		/// <para>PDF Password</para>
		/// <para>此参数在 ArcGIS 3.0 中不可用。 将在未来的版本中提供支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? PdfPassword { get; set; }

		/// <summary>
		/// <para>PDF Page Number</para>
		/// <para>要导出到 TIFF 的 PDF 文档的页码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? PdfPageNumber { get; set; } = "1";

		/// <summary>
		/// <para>PDF Map</para>
		/// <para>将导出地图。</para>
		/// <para>在 .pdf 文件中，地图是 PDF 页面上已定义的具有空间参考的图形容器。 PDF 地图相当于 ArcGIS Pro 地图，其为空间数据的容器。 一个 PDF 文档可能包含一个或多个地图。 例如，一个页面可能包含一个主地图和一个附加的较小的概览或注记地图。</para>
		/// <para>如果已指定写入 GeoTIFF 标签参数值，它将用于设置 .tif 文件的输出空间参考。</para>
		/// <para>如果已指定裁剪输出到地图参数值，它将用于定义输出 .tif 文件的范围。</para>
		/// <para>如果页面包含多个地图，将按名称列出 PDF 页面上的所有唯一地图。 您还可以通过 LARGEST 选项来使用 PDF 中最大的地图。 这是默认设置。</para>
		/// <para>对于使用 OGC GeoPDF 标准的 .pdf 文件，唯一支持的选项是 LARGEST。</para>
		/// <para>如果页面只包含一个地图，则此参数将为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PdfMap { get; set; }

		/// <summary>
		/// <para>Clip Output to Map</para>
		/// <para>指定将导出整个页面还是仅导出地图。</para>
		/// <para>选中 - 仅在 PDF 地图参数中指定的地图才会导出到 TIFF。</para>
		/// <para>未选中 - 将整个页面导出到 TIFF。 这是默认设置。</para>
		/// <para><see cref="ClipOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClipOption { get; set; } = "false";

		/// <summary>
		/// <para>Resolution in dpi</para>
		/// <para>输出 .tif 文件的分辨率，以每英寸点数 (DPI) 为单位。 默认值为 250。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = 95)]
		[High(Allow = true, Value = 3000)]
		public object? Resolution { get; set; } = "250";

		/// <summary>
		/// <para>Color Mode</para>
		/// <para>指定将用于描述颜色的位数。</para>
		/// <para>未来的版本中将支持其他选项。</para>
		/// <para>RGB 真彩色—将使用 32 位 RGBA 颜色。 如果压缩参数设置为 Jpeg，则将使用 24 位 RGB 颜色。 这是默认设置。</para>
		/// <para><see cref="ColorModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ColorMode { get; set; } = "RGB_TRUE_COLOR";

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定输出 .tif 文件的压缩方案。</para>
		/// <para>LZW—将使用无损数据压缩 Lempel-Ziv-Welch。 这是默认设置。</para>
		/// <para>压缩—将使用有损数据压缩。</para>
		/// <para>Jpeg—将使用 JPEG 有损压缩。 压缩质量将自动设置为 100，并且无法更改。</para>
		/// <para>无—不应用压缩。</para>
		/// <para>PackBits—将使用 PackBits 无损压缩。</para>
		/// <para><see cref="TiffCompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TiffCompression { get; set; } = "LZW";

		/// <summary>
		/// <para>Write GeoTIFF Tags</para>
		/// <para>指定是否将 GeoTIFF 标签添加到输出中。 仅当输入 PDF 文件参数值具有空间参考时才支持此参数。</para>
		/// <para>选中 - 将 GeoTIFF 标签添加到输出中。 这是默认设置。</para>
		/// <para>未选中 - 不会将 GeoTIFF 标签添加到输出中。</para>
		/// <para><see cref="GeotiffTagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GeotiffTags { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PDFToTIFF SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip Output to Map</para>
		/// </summary>
		public enum ClipOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP_TO_MAP")]
			CLIP_TO_MAP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIP")]
			NO_CLIP,

		}

		/// <summary>
		/// <para>Color Mode</para>
		/// </summary>
		public enum ColorModeEnum 
		{
			/// <summary>
			/// <para>RGB 真彩色—将使用 32 位 RGBA 颜色。 如果压缩参数设置为 Jpeg，则将使用 24 位 RGB 颜色。 这是默认设置。</para>
			/// </summary>
			[GPValue("RGB_TRUE_COLOR")]
			[Description("RGB 真彩色")]
			RGB_true_color,

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum TiffCompressionEnum 
		{
			/// <summary>
			/// <para>Jpeg—将使用 JPEG 有损压缩。 压缩质量将自动设置为 100，并且无法更改。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Jpeg")]
			Jpeg,

			/// <summary>
			/// <para>LZW—将使用无损数据压缩 Lempel-Ziv-Welch。 这是默认设置。</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("LZW")]
			LZW,

			/// <summary>
			/// <para>PackBits—将使用 PackBits 无损压缩。</para>
			/// </summary>
			[GPValue("PACK_BITS")]
			[Description("PackBits")]
			PackBits,

			/// <summary>
			/// <para>压缩—将使用有损数据压缩。</para>
			/// </summary>
			[GPValue("DEFLATE")]
			[Description("压缩")]
			Deflate,

			/// <summary>
			/// <para>无—不应用压缩。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Write GeoTIFF Tags</para>
		/// </summary>
		public enum GeotiffTagsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOTIFF_TAGS")]
			GEOTIFF_TAGS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GEOTIFF_TAGS")]
			NO_GEOTIFF_TAGS,

		}

#endregion
	}
}
