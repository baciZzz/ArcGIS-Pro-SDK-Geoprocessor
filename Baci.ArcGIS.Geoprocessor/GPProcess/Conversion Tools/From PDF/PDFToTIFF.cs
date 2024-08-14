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
	/// <para>Exports a .pdf file to Tagged Image File Format (TIFF).</para>
	/// </summary>
	public class PDFToTIFF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPdfFile">
		/// <para>Input PDF File</para>
		/// <para>The input .pdf file to be exported to TIFF.</para>
		/// </param>
		/// <param name="OutTiffFile">
		/// <para>Output TIFF File</para>
		/// <para>The output .tif file.</para>
		/// </param>
		public PDFToTIFF(object InPdfFile, object OutTiffFile)
		{
			this.InPdfFile = InPdfFile;
			this.OutTiffFile = OutTiffFile;
		}

		/// <summary>
		/// <para>Tool Display Name : PDF To TIFF</para>
		/// </summary>
		public override string DisplayName => "PDF To TIFF";

		/// <summary>
		/// <para>Tool Name : PDFToTIFF</para>
		/// </summary>
		public override string ToolName => "PDFToTIFF";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PDFToTIFF</para>
		/// </summary>
		public override string ExcuteName => "conversion.PDFToTIFF";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPdfFile, OutTiffFile, PdfPassword!, PdfPageNumber!, PdfMap!, ClipOption!, Resolution!, ColorMode!, TiffCompression!, GeotiffTags };

		/// <summary>
		/// <para>Input PDF File</para>
		/// <para>The input .pdf file to be exported to TIFF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InPdfFile { get; set; }

		/// <summary>
		/// <para>Output TIFF File</para>
		/// <para>The output .tif file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutTiffFile { get; set; }

		/// <summary>
		/// <para>PDF Password</para>
		/// <para>This parameter is unavailable at ArcGIS 3.0. It will be supported in a future release.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? PdfPassword { get; set; }

		/// <summary>
		/// <para>PDF Page Number</para>
		/// <para>The page number of the PDF document to export to TIFF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? PdfPageNumber { get; set; } = "1";

		/// <summary>
		/// <para>PDF Map</para>
		/// <para>The map that will be exported.</para>
		/// <para>In a .pdf file, a map is a defined container of graphics on the PDF page that has a spatial reference. A PDF map is equivalent to an ArcGIS Pro map in that it is the container for spatial data. A PDF document may have one or more maps. For example, a page may have a main map and an additional smaller overview or key map.</para>
		/// <para>If the Write GeoTIFF Tags parameter value is specified, it will be used to set the output spatial reference of the .tif file.</para>
		/// <para>If the Clip Output to Map parameter value is specified, it will be used to define the extent of the output .tif file.</para>
		/// <para>If the page contains more than one map, each unique map on the PDF page will be listed by name. You can also use the LARGEST option to use the largest map in the PDF. This is the default.</para>
		/// <para>For .pdf files that use the OGC GeoPDF standard, the only supported option is LARGEST.</para>
		/// <para>If the page contains only one map, this parameter will be blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PdfMap { get; set; }

		/// <summary>
		/// <para>Clip Output to Map</para>
		/// <para>Specifies whether the entire page or only the map will be exported.</para>
		/// <para>Checked—Only the map specified in the PDF Map parameter will be exported to TIFF.</para>
		/// <para>Unchecked—The entire page will be exported to TIFF. This is the default.</para>
		/// <para><see cref="ClipOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClipOption { get; set; } = "false";

		/// <summary>
		/// <para>Resolution in dpi</para>
		/// <para>The resolution of the output .tif file in dots per inch (DPI). The default is 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? Resolution { get; set; } = "250";

		/// <summary>
		/// <para>Color Mode</para>
		/// <para>Specifies the number of bits that will be used to describe color.</para>
		/// <para>Additional options will be supported in a future release.</para>
		/// <para>RGB true color—32-bit RGBA color will be used. If the Compression parameter is set to Jpeg, 24-bit RGB color will be used. This is the default.</para>
		/// <para><see cref="ColorModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ColorMode { get; set; } = "RGB_TRUE_COLOR";

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies the compression scheme for the output .tif file.</para>
		/// <para>LZW—Lempel-Ziv-Welch, a lossless data compression, will be used. This is the default.</para>
		/// <para>Deflate—A lossless data compression will be used.</para>
		/// <para>Jpeg—JPEG lossy compression will be used. The compression quality will be automatically set to 100 and cannot be changed.</para>
		/// <para>None—Compression will not be applied.</para>
		/// <para>PackBits—PackBits lossless compression will be used.</para>
		/// <para><see cref="TiffCompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TiffCompression { get; set; } = "LZW";

		/// <summary>
		/// <para>Write GeoTIFF Tags</para>
		/// <para>Specifies whether GeoTIFF tags will be added to the output. This parameter is only supported if the Input PDF File parameter value has a spatial reference.</para>
		/// <para>Checked—GeoTIFF tags will be added to the output. This is the default.</para>
		/// <para>Unchecked—GeoTIFF tags will not be added to the output.</para>
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
			/// <para>Checked—Only the map specified in the PDF Map parameter will be exported to TIFF.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP_TO_MAP")]
			CLIP_TO_MAP,

			/// <summary>
			/// <para>Unchecked—The entire page will be exported to TIFF. This is the default.</para>
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
			/// <para>RGB true color—32-bit RGBA color will be used. If the Compression parameter is set to Jpeg, 24-bit RGB color will be used. This is the default.</para>
			/// </summary>
			[GPValue("RGB_TRUE_COLOR")]
			[Description("RGB true color")]
			RGB_true_color,

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum TiffCompressionEnum 
		{
			/// <summary>
			/// <para>Jpeg—JPEG lossy compression will be used. The compression quality will be automatically set to 100 and cannot be changed.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Jpeg")]
			Jpeg,

			/// <summary>
			/// <para>LZW—Lempel-Ziv-Welch, a lossless data compression, will be used. This is the default.</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("LZW")]
			LZW,

			/// <summary>
			/// <para>PackBits—PackBits lossless compression will be used.</para>
			/// </summary>
			[GPValue("PACK_BITS")]
			[Description("PackBits")]
			PackBits,

			/// <summary>
			/// <para>Deflate—A lossless data compression will be used.</para>
			/// </summary>
			[GPValue("DEFLATE")]
			[Description("Deflate")]
			Deflate,

			/// <summary>
			/// <para>None—Compression will not be applied.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Write GeoTIFF Tags</para>
		/// </summary>
		public enum GeotiffTagsEnum 
		{
			/// <summary>
			/// <para>Checked—GeoTIFF tags will be added to the output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOTIFF_TAGS")]
			GEOTIFF_TAGS,

			/// <summary>
			/// <para>Unchecked—GeoTIFF tags will not be added to the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GEOTIFF_TAGS")]
			NO_GEOTIFF_TAGS,

		}

#endregion
	}
}
