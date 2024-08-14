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
	/// <para>Generates turn-by-turn directions from a network analysis layer with routes. The directions can be written to a file in text, XML, or HTML format. If you provide an appropriate stylesheet, the directions can be written to any other file format.</para>
	/// </summary>
	public class Directions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>Network analysis layer for which directions will be generated. Directions can be generated only for route, closest facility, and vehicle routing problem network analysis layers.</para>
		/// </param>
		/// <param name="FileType">
		/// <para>Output File Type</para>
		/// <para>The format of the output directions file. This parameter is ignored if the stylesheet parameter has a value.</para>
		/// <para>XML—The output directions file will be generated as an XML file. Apart from direction strings and the length and time information for the routes, the file will also contain information about the maneuver type and the turn angle for each direction.</para>
		/// <para>Text—The output directions file will be generated as a simple TXT file containing the direction strings, the length and, optionally, the time information for the routes.</para>
		/// <para>HTML—The output directions file will be generated as an HTML file containing the direction strings, the length and, optionally, the time information for the routes.</para>
		/// <para><see cref="FileTypeEnum"/></para>
		/// </param>
		/// <param name="OutDirectionsFile">
		/// <para>Output Directions File</para>
		/// <para>The full path to the directions file that will be written.</para>
		/// <para>If you provide a stylesheet in the Stylesheet parameter, make sure the file suffix for Output Directions File matches the file type your stylesheet produces.</para>
		/// </param>
		/// <param name="ReportUnits">
		/// <para>Report Length in These Units</para>
		/// <para>Specifies the linear units in which the length information will be reported in the directions file. For example, even though your impedance was in meters, you can show directions in miles.</para>
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
		/// <para>Tool Display Name : Directions</para>
		/// </summary>
		public override string DisplayName => "Directions";

		/// <summary>
		/// <para>Tool Name : Directions</para>
		/// </summary>
		public override string ToolName => "Directions";

		/// <summary>
		/// <para>Tool Excute Name : na.Directions</para>
		/// </summary>
		public override string ExcuteName => "na.Directions";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkAnalysisLayer, FileType, OutDirectionsFile, ReportUnits, ReportTime, TimeAttribute, Language, StyleName, Stylesheet, OutputLayer };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>Network analysis layer for which directions will be generated. Directions can be generated only for route, closest facility, and vehicle routing problem network analysis layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output File Type</para>
		/// <para>The format of the output directions file. This parameter is ignored if the stylesheet parameter has a value.</para>
		/// <para>XML—The output directions file will be generated as an XML file. Apart from direction strings and the length and time information for the routes, the file will also contain information about the maneuver type and the turn angle for each direction.</para>
		/// <para>Text—The output directions file will be generated as a simple TXT file containing the direction strings, the length and, optionally, the time information for the routes.</para>
		/// <para>HTML—The output directions file will be generated as an HTML file containing the direction strings, the length and, optionally, the time information for the routes.</para>
		/// <para><see cref="FileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FileType { get; set; } = "XML";

		/// <summary>
		/// <para>Output Directions File</para>
		/// <para>The full path to the directions file that will be written.</para>
		/// <para>If you provide a stylesheet in the Stylesheet parameter, make sure the file suffix for Output Directions File matches the file type your stylesheet produces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutDirectionsFile { get; set; }

		/// <summary>
		/// <para>Report Length in These Units</para>
		/// <para>Specifies the linear units in which the length information will be reported in the directions file. For example, even though your impedance was in meters, you can show directions in miles.</para>
		/// <para><see cref="ReportUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReportUnits { get; set; }

		/// <summary>
		/// <para>Report Travel Time</para>
		/// <para>Checked—Report travel times in the directions file. This is the default value.</para>
		/// <para>Unchecked—Do not report travel times in the directions file.</para>
		/// <para><see cref="ReportTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReportTime { get; set; } = "true";

		/// <summary>
		/// <para>Time Attribute</para>
		/// <para>The time-based cost attribute to provide travel times in the directions. The cost attribute must exist on the network dataset used by the input network analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeAttribute { get; set; }

		/// <summary>
		/// <para>Language</para>
		/// <para>Choose a language in which to generate driving directions.</para>
		/// <para>The input for this parameter should be a two- or five-character language code representing one of the available languages for directions generation. In Python, you can retrieve a list of available language codes using the ListDirectionsLanguages function.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Language { get; set; }

		/// <summary>
		/// <para>Style Name</para>
		/// <para>Choose the name of the formatting style for the directions.</para>
		/// <para>Printable driving directions—Printable turn-by-turn directions</para>
		/// <para>Driving directions for a navigation device—Turn-by-turn directions designed for an in-vehicle navigation device</para>
		/// <para>Walking directions—Turn-by-turn walking directions, which are designed for pedestrian routes</para>
		/// <para><see cref="StyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StyleName { get; set; }

		/// <summary>
		/// <para>Stylesheet</para>
		/// <para>The stylesheet for generating a formatted output file type (such as a PDF, Word, or HTML file). The suffix of the file in the output directions file parameter should match the file type that the stylesheet generates. The Directions tool overrides the output file type parameter if this parameter contains a value.</para>
		/// <para>If you want a head start on creating your own text and HTML stylesheets, copy and edit the stylesheets Network Analyst uses. You can find them in the following directory: &lt;ArcGIS installation directory&gt;\ArcGIS\ArcGIS Pro\Resources\NetworkAnalyst\Directions\Styles. The stylesheet is Dir2PHTML.xsl, and the text stylesheet is Dir2PlainText.xsl.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object Stylesheet { get; set; }

		/// <summary>
		/// <para>Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Directions SetEnviroment(object workspace = null )
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
			/// <para>Text—The output directions file will be generated as a simple TXT file containing the direction strings, the length and, optionally, the time information for the routes.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>XML—The output directions file will be generated as an XML file. Apart from direction strings and the length and time information for the routes, the file will also contain information about the maneuver type and the turn angle for each direction.</para>
			/// </summary>
			[GPValue("XML")]
			[Description("XML")]
			XML,

			/// <summary>
			/// <para>HTML—The output directions file will be generated as an HTML file containing the direction strings, the length and, optionally, the time information for the routes.</para>
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
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("Nautical miles")]
			Nautical_miles,

		}

		/// <summary>
		/// <para>Report Travel Time</para>
		/// </summary>
		public enum ReportTimeEnum 
		{
			/// <summary>
			/// <para>Checked—Report travel times in the directions file. This is the default value.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REPORT_TIME")]
			REPORT_TIME,

			/// <summary>
			/// <para>Unchecked—Do not report travel times in the directions file.</para>
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
			/// <para>Printable driving directions—Printable turn-by-turn directions</para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("Printable driving directions")]
			Printable_driving_directions,

			/// <summary>
			/// <para>Driving directions for a navigation device—Turn-by-turn directions designed for an in-vehicle navigation device</para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("Driving directions for a navigation device")]
			Driving_directions_for_a_navigation_device,

			/// <summary>
			/// <para>Walking directions—Turn-by-turn walking directions, which are designed for pedestrian routes</para>
			/// </summary>
			[GPValue("NA Campus")]
			[Description("Walking directions")]
			Walking_directions,

		}

#endregion
	}
}
