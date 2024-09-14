using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TerritoryDesignTools
{
	/// <summary>
	/// <para>Generate Territory Report</para>
	/// <para>Generate Territory Report</para>
	/// <para>Creates a summary report of a territory solution or a comparison report of two solutions.</para>
	/// </summary>
	public class GenerateTerritoryReport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution for the report.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The territory level to create the report.</para>
		/// </param>
		public GenerateTerritoryReport(object InTerritorySolution, object Level)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Territory Report</para>
		/// </summary>
		public override string DisplayName() => "Generate Territory Report";

		/// <summary>
		/// <para>Tool Name : GenerateTerritoryReport</para>
		/// </summary>
		public override string ToolName() => "GenerateTerritoryReport";

		/// <summary>
		/// <para>Tool Excute Name : td.GenerateTerritoryReport</para>
		/// </summary>
		public override string ExcuteName() => "td.GenerateTerritoryReport";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise() => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, ReportType, ReportFolder, ReportTitle, ReportFormat, ComparisonTerritorySolution, ComparisonLevel, OutputReport };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution for the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The territory level to create the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Report Type</para>
		/// <para>Specifies the type of report that will be generated.</para>
		/// <para>Territory Summary—The report contains a summary of a territory solution, such as hierarchy and statistics. This is the default.</para>
		/// <para>Compare Territories—The report compares two territory solutions.</para>
		/// <para>Realignment— The report contains a summary realignment report for the territories.</para>
		/// <para>Realignment Detailed— The report contains a full list of the reassigned features.</para>
		/// <para><see cref="ReportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReportType { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ReportTitle { get; set; }

		/// <summary>
		/// <para>Report Output Formats</para>
		/// <para>The report output format. The default value is PDF. Additional available formats: XLSX, HTML, CSV, PAGX.</para>
		/// <para><see cref="ReportFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ReportFormat { get; set; }

		/// <summary>
		/// <para>Comparison Territory Solution</para>
		/// <para>The territory solution for the comparison report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object ComparisonTerritorySolution { get; set; }

		/// <summary>
		/// <para>Comparison Level</para>
		/// <para>The territory level to be used for the comparison or realignment report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ComparisonLevel { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutputReport { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTerritoryReport SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Report Type</para>
		/// </summary>
		public enum ReportTypeEnum 
		{
			/// <summary>
			/// <para>Territory Summary—The report contains a summary of a territory solution, such as hierarchy and statistics. This is the default.</para>
			/// </summary>
			[GPValue("TERRITORY_SUMMARY")]
			[Description("Territory Summary")]
			Territory_Summary,

			/// <summary>
			/// <para>Compare Territories—The report compares two territory solutions.</para>
			/// </summary>
			[GPValue("COMPARE_TERRITORIES")]
			[Description("Compare Territories")]
			Compare_Territories,

			/// <summary>
			/// <para>Realignment— The report contains a summary realignment report for the territories.</para>
			/// </summary>
			[GPValue("REALIGNMENT")]
			[Description("Realignment")]
			Realignment,

			/// <summary>
			/// <para>Realignment Detailed— The report contains a full list of the reassigned features.</para>
			/// </summary>
			[GPValue("REALIGNMENT_DETAILED")]
			[Description("Realignment Detailed")]
			Realignment_Detailed,

		}

		/// <summary>
		/// <para>Report Output Formats</para>
		/// </summary>
		public enum ReportFormatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PDF")]
			[Description("PDF")]
			PDF,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("XLSX")]
			[Description("XLSX")]
			XLSX,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("HTML")]
			[Description("HTML")]
			HTML,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ZIP")]
			[Description("ZIP")]
			ZIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CSV")]
			[Description("CSV")]
			CSV,

		}

#endregion
	}
}
