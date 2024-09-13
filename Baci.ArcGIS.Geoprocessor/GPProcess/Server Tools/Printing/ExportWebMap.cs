using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Export Web Map</para>
	/// <para>Export Web Map</para>
	/// <para>Takes the state of a web app (for example, included services, layer visibility settings, and client-side graphics) and returns a printable page layout or basic map of the specified area of interest.</para>
	/// </summary>
	public class ExportWebMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="WebMapAsJSON">
		/// <para>Web Map as JSON</para>
		/// <para>A JSON representation of the state of the map to be exported as it appears in the web app. See the ExportWebMap specification to understand how to format this text. The ArcGIS web APIs for JavaScript, Flex, Silverlight, and so on allow you to get this JSON string from the map.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output file name. The extension of the file depends on the Format parameter value.</para>
		/// </param>
		public ExportWebMap(object WebMapAsJSON, object OutputFile)
		{
			this.WebMapAsJSON = WebMapAsJSON;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Web Map</para>
		/// </summary>
		public override string DisplayName() => "Export Web Map";

		/// <summary>
		/// <para>Tool Name : ExportWebMap</para>
		/// </summary>
		public override string ToolName() => "ExportWebMap";

		/// <summary>
		/// <para>Tool Excute Name : server.ExportWebMap</para>
		/// </summary>
		public override string ExcuteName() => "server.ExportWebMap";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { WebMapAsJSON, OutputFile, Format!, LayoutTemplatesFolder!, LayoutTemplate! };

		/// <summary>
		/// <para>Web Map as JSON</para>
		/// <para>A JSON representation of the state of the map to be exported as it appears in the web app. See the ExportWebMap specification to understand how to format this text. The ArcGIS web APIs for JavaScript, Flex, Silverlight, and so on allow you to get this JSON string from the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object WebMapAsJSON { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output file name. The extension of the file depends on the Format parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>Specifies the format in which the map image for printing will be delivered.</para>
		/// <para>8-bit Portable Network Graphics (PNG8)—8-bit Portable Network Graphics (PNG8) will be used. This is the default.</para>
		/// <para>Portable Document Format (PDF)—Portable Document Format (PDF) will be used.</para>
		/// <para>32-bit Portable Network Graphics (PNG32)—32-bit Portable Network Graphics (PNG32) will be used.</para>
		/// <para>Joint Photographic Experts Group (JPG)— Joint Photographic Experts Group (JPG) will be used.</para>
		/// <para>Graphics Interchange Format (GIF)— Graphics Interchange Format (GIF) will be used.</para>
		/// <para>Encapsulated PostScript (EPS)— Encapsulated PostScript (EPS) will be used.</para>
		/// <para>Scalable Vector Graphics (SVG)—Scalable Vector Graphics (SVG) will be used.</para>
		/// <para>Compressed Scalable Vector Graphics (SVGZ)—Compressed Scalable Vector Graphics (SVGZ) will be used.</para>
		/// <para>Adobe Illustrator Exchange (AIX)—Adobe Illustrator Exchange (AIX) will be used.</para>
		/// <para>Tag Image File Format (TIFF)—Tag Image File Format (TIFF) will be used.</para>
		/// <para>The background of the output file is always opaque.</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Format { get; set; } = "PDF";

		/// <summary>
		/// <para>Layout Templates Folder</para>
		/// <para>The full path to the folder containing layout pages (.pagx files ) to be used as layout templates. The default location is &lt;install_directory&gt;\Resources\ArcToolBox\Templates\ExportWebMapTemplates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? LayoutTemplatesFolder { get; set; }

		/// <summary>
		/// <para>Layout Template</para>
		/// <para>The name of a template from the list or the keyword MAP_ONLY. When MAP_ONLY is chosen or an empty string is passed in, the output map will not contain any page layout elements such as title, legend, or scale bar.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LayoutTemplate { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>Portable Document Format (PDF)—Portable Document Format (PDF) will be used.</para>
			/// </summary>
			[GPValue("PDF")]
			[Description("Portable Document Format (PDF)")]
			PDF,

			/// <summary>
			/// <para>32-bit Portable Network Graphics (PNG32)—32-bit Portable Network Graphics (PNG32) will be used.</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("32-bit Portable Network Graphics (PNG32)")]
			PNG32,

			/// <summary>
			/// <para>8-bit Portable Network Graphics (PNG8)—8-bit Portable Network Graphics (PNG8) will be used. This is the default.</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("8-bit Portable Network Graphics (PNG8)")]
			PNG8,

			/// <summary>
			/// <para>Joint Photographic Experts Group (JPG)— Joint Photographic Experts Group (JPG) will be used.</para>
			/// </summary>
			[GPValue("JPG")]
			[Description("Joint Photographic Experts Group (JPG)")]
			JPG,

			/// <summary>
			/// <para>Graphics Interchange Format (GIF)— Graphics Interchange Format (GIF) will be used.</para>
			/// </summary>
			[GPValue("GIF")]
			[Description("Graphics Interchange Format (GIF)")]
			GIF,

			/// <summary>
			/// <para>Encapsulated PostScript (EPS)— Encapsulated PostScript (EPS) will be used.</para>
			/// </summary>
			[GPValue("EPS")]
			[Description("Encapsulated PostScript (EPS)")]
			EPS,

			/// <summary>
			/// <para>Scalable Vector Graphics (SVG)—Scalable Vector Graphics (SVG) will be used.</para>
			/// </summary>
			[GPValue("SVG")]
			[Description("Scalable Vector Graphics (SVG)")]
			SVG,

			/// <summary>
			/// <para>Compressed Scalable Vector Graphics (SVGZ)—Compressed Scalable Vector Graphics (SVGZ) will be used.</para>
			/// </summary>
			[GPValue("SVGZ")]
			[Description("Compressed Scalable Vector Graphics (SVGZ)")]
			SVGZ,

			/// <summary>
			/// <para>Adobe Illustrator Exchange (AIX)—Adobe Illustrator Exchange (AIX) will be used.</para>
			/// </summary>
			[GPValue("AIX")]
			[Description("Adobe Illustrator Exchange (AIX)")]
			AIX,

			/// <summary>
			/// <para>Tag Image File Format (TIFF)—Tag Image File Format (TIFF) will be used.</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("Tag Image File Format (TIFF)")]
			TIFF,

		}

#endregion
	}
}
