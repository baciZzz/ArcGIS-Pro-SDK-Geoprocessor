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
	/// <para>导出 Web 地图</para>
	/// <para>采用 web 应用程序的状态（例如，随附的服务、图层可见性设置和客户端图形）并返回可打印的页面布局或指定感兴趣区的基本地图。</para>
	/// </summary>
	public class ExportWebMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="WebMapAsJSON">
		/// <para>Web Map as JSON</para>
		/// <para>要按照 Web 应用程序中显示的情况导出地图状态的 JSON 制图表达。请参阅 ExportWebMap 规范以了解如何设置此文本格式。 通过 ArcGIS Web API（针对 JavaScript、Flex、Silverlight 等），您可以从地图中获取此 JSON 字符串。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出文件名。 文件扩展名取决于格式参数值。</para>
		/// </param>
		public ExportWebMap(object WebMapAsJSON, object OutputFile)
		{
			this.WebMapAsJSON = WebMapAsJSON;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出 Web 地图</para>
		/// </summary>
		public override string DisplayName() => "导出 Web 地图";

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
		/// <para>要按照 Web 应用程序中显示的情况导出地图状态的 JSON 制图表达。请参阅 ExportWebMap 规范以了解如何设置此文本格式。 通过 ArcGIS Web API（针对 JavaScript、Flex、Silverlight 等），您可以从地图中获取此 JSON 字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object WebMapAsJSON { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出文件名。 文件扩展名取决于格式参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>指定传送打印用地图影像时所使用的格式。</para>
		/// <para>8 位可移植网络图形 (PNG8)。—将使用 8 位可移植网络图形 (PNG8)。 这是默认设置。</para>
		/// <para>便携文档格式(PDF)—将使用可移植文档格式 (PDF)。</para>
		/// <para>32 位可移植网络图形 (PNG32)—将使用 32 位可移植网络图形 (PNG32)。</para>
		/// <para>联合图像专家组 (JPG)—将使用联合图像专家组 (JPG)。</para>
		/// <para>图形交换格式 (GIF)—将使用图形交换格式 (GIF)。</para>
		/// <para>Encapsulated PostScript (EPS)—将使用 Encapsulated PostScript (EPS)。</para>
		/// <para>可伸缩矢量图形 (SVG)—将使用可伸缩矢量图形 (SVG)。</para>
		/// <para>压缩的可伸缩矢量图形 (SVGZ)—将使用压缩的可伸缩矢量图形 (SVGZ)。</para>
		/// <para>Adobe Illustrator Exchange (AIX)—将使用 Adobe Illustrator Exchange (AIX)。</para>
		/// <para>标记图像文件格式 (TIFF)—将使用标记图像文件格式 (TIFF)。</para>
		/// <para>输出文件的背景始终是不透明的。</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Format { get; set; } = "PDF";

		/// <summary>
		/// <para>Layout Templates Folder</para>
		/// <para>包含要用作布局模板的布局页面（.pagx 文件）的文件夹的完整路径。 默认位置为 &lt;install_directory&gt;\Resources\ArcToolBox\Templates\ExportWebMapTemplates。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? LayoutTemplatesFolder { get; set; }

		/// <summary>
		/// <para>Layout Template</para>
		/// <para>可以是列表中某个模板的名称，也可以是关键字 MAP_ONLY。 选择 MAP_ONLY 或传递空字符串时，输出地图将不包含任何页面布局元素，例如标题、图例和比例尺。</para>
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
			/// <para>便携文档格式(PDF)—将使用可移植文档格式 (PDF)。</para>
			/// </summary>
			[GPValue("PDF")]
			[Description("便携文档格式(PDF)")]
			PDF,

			/// <summary>
			/// <para>32 位可移植网络图形 (PNG32)—将使用 32 位可移植网络图形 (PNG32)。</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("32 位可移植网络图形 (PNG32)")]
			PNG32,

			/// <summary>
			/// <para>8 位可移植网络图形 (PNG8)。—将使用 8 位可移植网络图形 (PNG8)。 这是默认设置。</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("8 位可移植网络图形 (PNG8)。")]
			PNG8,

			/// <summary>
			/// <para>联合图像专家组 (JPG)—将使用联合图像专家组 (JPG)。</para>
			/// </summary>
			[GPValue("JPG")]
			[Description("联合图像专家组 (JPG)")]
			JPG,

			/// <summary>
			/// <para>图形交换格式 (GIF)—将使用图形交换格式 (GIF)。</para>
			/// </summary>
			[GPValue("GIF")]
			[Description("图形交换格式 (GIF)")]
			GIF,

			/// <summary>
			/// <para>Encapsulated PostScript (EPS)—将使用 Encapsulated PostScript (EPS)。</para>
			/// </summary>
			[GPValue("EPS")]
			[Description("Encapsulated PostScript (EPS)")]
			EPS,

			/// <summary>
			/// <para>可伸缩矢量图形 (SVG)—将使用可伸缩矢量图形 (SVG)。</para>
			/// </summary>
			[GPValue("SVG")]
			[Description("可伸缩矢量图形 (SVG)")]
			SVG,

			/// <summary>
			/// <para>压缩的可伸缩矢量图形 (SVGZ)—将使用压缩的可伸缩矢量图形 (SVGZ)。</para>
			/// </summary>
			[GPValue("SVGZ")]
			[Description("压缩的可伸缩矢量图形 (SVGZ)")]
			SVGZ,

			/// <summary>
			/// <para>Adobe Illustrator Exchange (AIX)—将使用 Adobe Illustrator Exchange (AIX)。</para>
			/// </summary>
			[GPValue("AIX")]
			[Description("Adobe Illustrator Exchange (AIX)")]
			AIX,

			/// <summary>
			/// <para>标记图像文件格式 (TIFF)—将使用标记图像文件格式 (TIFF)。</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("标记图像文件格式 (TIFF)")]
			TIFF,

		}

#endregion
	}
}
