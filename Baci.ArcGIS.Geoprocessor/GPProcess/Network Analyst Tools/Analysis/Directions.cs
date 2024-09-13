using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Directions</para>
	/// <para>描述</para>
	/// <para>根据包含路径的网络分析图层生成转弯方向。可以将这些方向信息写入到文本、XML 或 HTML 格式的文件中。如果提供了适合的样式表，也可以将这些方向写入其他任何文件格式。</para>
	/// </summary>
	public class Directions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>将生成方向信息的网络分析图层。只能为路径、最近设施点和车辆配送网络分析图层生成方向信息。</para>
		/// </param>
		/// <param name="FileType">
		/// <para>Output File Type</para>
		/// <para>输出方向文件的格式。如果样式表参数中具有值，则会忽略此参数。</para>
		/// <para>XML—将以 XML 文件的形式生成输出方向文件。除了路径的方向字符串和长度及时间信息外，该文件还包含有关每个方向的行进策略类型和转弯角度的信息。</para>
		/// <para>Text—将以简单 TXT 文件的形式生成输出方向文件，其中包含路径的方向字符串和长度信息，另外还可包含路径的时间信息。</para>
		/// <para>HTML—将以 HTML 文件的形式生成输出方向文件，其中包含路径的方向字符串和长度信息，另外还可包含路径的时间信息。</para>
		/// <para><see cref="FileTypeEnum"/></para>
		/// </param>
		/// <param name="OutDirectionsFile">
		/// <para>Output Directions File</para>
		/// <para>方向文件将写入的完整路径。</para>
		/// <para>如果在样式表参数中提供样式表，应确保输出方向文件的文件后缀与样式表生成的文件类型匹配。</para>
		/// </param>
		/// <param name="ReportUnits">
		/// <para>Report Length in These Units</para>
		/// <para>指定在方向文件中报告长度信息时所使用的线性单位。例如，即使阻抗的单位是米，您也可以选择使用英里显示方向。</para>
		/// <para><see cref="ReportUnitsEnum"/></para>
		/// </param>
		public Directions(object InNetworkAnalysisLayer, object FileType, object OutDirectionsFile, object ReportUnits)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.FileType = FileType;
			this.OutDirectionsFile = OutDirectionsFile;
			this.ReportUnits = ReportUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 描述</para>
		/// </summary>
		public override string DisplayName() => "描述";

		/// <summary>
		/// <para>Tool Name : 描述</para>
		/// </summary>
		public override string ToolName() => "描述";

		/// <summary>
		/// <para>Tool Excute Name : na.Directions</para>
		/// </summary>
		public override string ExcuteName() => "na.Directions";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, FileType, OutDirectionsFile, ReportUnits, ReportTime!, TimeAttribute!, Language!, StyleName!, Stylesheet!, OutputLayer! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>将生成方向信息的网络分析图层。只能为路径、最近设施点和车辆配送网络分析图层生成方向信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output File Type</para>
		/// <para>输出方向文件的格式。如果样式表参数中具有值，则会忽略此参数。</para>
		/// <para>XML—将以 XML 文件的形式生成输出方向文件。除了路径的方向字符串和长度及时间信息外，该文件还包含有关每个方向的行进策略类型和转弯角度的信息。</para>
		/// <para>Text—将以简单 TXT 文件的形式生成输出方向文件，其中包含路径的方向字符串和长度信息，另外还可包含路径的时间信息。</para>
		/// <para>HTML—将以 HTML 文件的形式生成输出方向文件，其中包含路径的方向字符串和长度信息，另外还可包含路径的时间信息。</para>
		/// <para><see cref="FileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FileType { get; set; } = "XML";

		/// <summary>
		/// <para>Output Directions File</para>
		/// <para>方向文件将写入的完整路径。</para>
		/// <para>如果在样式表参数中提供样式表，应确保输出方向文件的文件后缀与样式表生成的文件类型匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutDirectionsFile { get; set; }

		/// <summary>
		/// <para>Report Length in These Units</para>
		/// <para>指定在方向文件中报告长度信息时所使用的线性单位。例如，即使阻抗的单位是米，您也可以选择使用英里显示方向。</para>
		/// <para><see cref="ReportUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReportUnits { get; set; }

		/// <summary>
		/// <para>Report Travel Time</para>
		/// <para>选中 - 在方向文件中报告行驶时间。这是默认值。</para>
		/// <para>未选中 - 在方向文件中不报告行驶时间。</para>
		/// <para><see cref="ReportTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReportTime { get; set; } = "true";

		/// <summary>
		/// <para>Time Attribute</para>
		/// <para>用于提供方向中各行驶时间的基于时间的成本属性。输入网络分析图层所使用的网络数据集中必须存在成本属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeAttribute { get; set; }

		/// <summary>
		/// <para>Language</para>
		/// <para>选择生成驾车方向时所使用的语言。</para>
		/// <para>此参数的输入应为两位或五位字符语言代码，表示用于方向生成的可用语言之一。在 Python 中，可使用 ListDirectionsLanguages 函数检索可用语言代码列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Language { get; set; }

		/// <summary>
		/// <para>Style Name</para>
		/// <para>选择方向的格式化样式名称。</para>
		/// <para>可打印驾车方向—可打印转弯方向</para>
		/// <para>导航设备的行驶方向—针对车辆内导航设备设计的转弯方向</para>
		/// <para>步行方向—转弯行走方向，用于人行道</para>
		/// <para><see cref="StyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StyleName { get; set; }

		/// <summary>
		/// <para>Stylesheet</para>
		/// <para>生成格式化输出文件类型（如 PDF、Word 或 HTML 文件）的样式表。输出方向文件参数中的文件后缀应与样式表所生成的文件类型相匹配。如果此参数中包含了参数值，则方向工具会重写输出文件类型参数。</para>
		/// <para>如果想要领先创建自有文本和 HTML 样式表，请复制和编辑 Network Analyst 使用的样式表。它们位于以下目录中：&lt;ArcGIS installation directory&gt;\ArcGIS\ArcGIS Pro\Resources\NetworkAnalyst\Directions\Styles。样式表为 Dir2PHTML.xsl，文本样式表为 Dir2PlainText.xsl。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xsl")]
		public object? Stylesheet { get; set; }

		/// <summary>
		/// <para>Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Directions SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output File Type</para>
		/// </summary>
		public enum FileTypeEnum 
		{
			/// <summary>
			/// <para>Text—将以简单 TXT 文件的形式生成输出方向文件，其中包含路径的方向字符串和长度信息，另外还可包含路径的时间信息。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>XML—将以 XML 文件的形式生成输出方向文件。除了路径的方向字符串和长度及时间信息外，该文件还包含有关每个方向的行进策略类型和转弯角度的信息。</para>
			/// </summary>
			[GPValue("XML")]
			[Description("XML")]
			XML,

			/// <summary>
			/// <para>HTML—将以 HTML 文件的形式生成输出方向文件，其中包含路径的方向字符串和长度信息，另外还可包含路径的时间信息。</para>
			/// </summary>
			[GPValue("HTML")]
			[Description("HTML")]
			HTML,

		}

		/// <summary>
		/// <para>Report Length in These Units</para>
		/// </summary>
		public enum ReportUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("海里")]
			Nautical_miles,

		}

		/// <summary>
		/// <para>Report Travel Time</para>
		/// </summary>
		public enum ReportTimeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REPORT_TIME")]
			REPORT_TIME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REPORT_TIME")]
			NO_REPORT_TIME,

		}

		/// <summary>
		/// <para>Style Name</para>
		/// </summary>
		public enum StyleNameEnum 
		{
			/// <summary>
			/// <para>可打印驾车方向—可打印转弯方向</para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("可打印驾车方向")]
			Printable_driving_directions,

			/// <summary>
			/// <para>导航设备的行驶方向—针对车辆内导航设备设计的转弯方向</para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("导航设备的行驶方向")]
			Driving_directions_for_a_navigation_device,

			/// <summary>
			/// <para>步行方向—转弯行走方向，用于人行道</para>
			/// </summary>
			[GPValue("NA Campus")]
			[Description("步行方向")]
			Walking_directions,

		}

#endregion
	}
}
