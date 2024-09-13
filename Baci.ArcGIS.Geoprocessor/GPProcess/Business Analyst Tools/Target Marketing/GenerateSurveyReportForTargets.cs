using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Survey Report For Targets</para>
	/// <para>Generate Survey Report For Targets</para>
	/// <para>Displays the top characteristics, in each of the selected survey categories, of your Core and Developmental target groups, as well as your overall customer profile.</para>
	/// </summary>
	public class GenerateSurveyReportForTargets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetProfile">
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be analyzed. The target profile usually represents your customer segmentation profile.</para>
		/// </param>
		/// <param name="TargetGroup">
		/// <para>Target Group</para>
		/// <para>A collection of segments grouped into targets. Targets represent segments that are selected based on similar characteristics—for example, segments that have high index and percent composition.</para>
		/// </param>
		/// <param name="CoreTarget">
		/// <para>Core Target</para>
		/// <para>A group of segments that make up a large percentage of your customer base and have an above average index, indicating likelihood to be a customer.</para>
		/// </param>
		/// <param name="DevelopmentalTarget">
		/// <para>Developmental Target</para>
		/// <para>A group of segments that make up a significant percentage of your customers and of the market area but do not have an above average index.</para>
		/// </param>
		/// <param name="ReportFolder">
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </param>
		public GenerateSurveyReportForTargets(object TargetProfile, object TargetGroup, object CoreTarget, object DevelopmentalTarget, object ReportFolder)
		{
			this.TargetProfile = TargetProfile;
			this.TargetGroup = TargetGroup;
			this.CoreTarget = CoreTarget;
			this.DevelopmentalTarget = DevelopmentalTarget;
			this.ReportFolder = ReportFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Survey Report For Targets</para>
		/// </summary>
		public override string DisplayName() => "Generate Survey Report For Targets";

		/// <summary>
		/// <para>Tool Name : GenerateSurveyReportForTargets</para>
		/// </summary>
		public override string ToolName() => "GenerateSurveyReportForTargets";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateSurveyReportForTargets</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateSurveyReportForTargets";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetProfile, TargetGroup, CoreTarget, DevelopmentalTarget, ReportFolder, ReportType, SurveyCategories, ReportTitle, ReportFormat, OutputReport };

		/// <summary>
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be analyzed. The target profile usually represents your customer segmentation profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object TargetProfile { get; set; }

		/// <summary>
		/// <para>Target Group</para>
		/// <para>A collection of segments grouped into targets. Targets represent segments that are selected based on similar characteristics—for example, segments that have high index and percent composition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgtargetgroup")]
		public object TargetGroup { get; set; }

		/// <summary>
		/// <para>Core Target</para>
		/// <para>A group of segments that make up a large percentage of your customer base and have an above average index, indicating likelihood to be a customer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CoreTarget { get; set; }

		/// <summary>
		/// <para>Developmental Target</para>
		/// <para>A group of segments that make up a significant percentage of your customers and of the market area but do not have an above average index.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DevelopmentalTarget { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		[Category("Report Options")]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Report Type</para>
		/// <para>Specifies the survey categories to be added to the report.</para>
		/// <para>Understanding Your Target—Media-related characteristics—for example, reading, watching, and listening related.</para>
		/// <para>Developing Market Strategies—Leisure-related characteristics—for example, leisure, sports, and travel.</para>
		/// <para>Custom— User-defined characteristics. This is the default.</para>
		/// <para><see cref="ReportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReportType { get; set; } = "CUSTOM";

		/// <summary>
		/// <para>Survey Categories</para>
		/// <para>A category that contains the characteristics from the consumer survey.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object SurveyCategories { get; set; }

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object ReportTitle { get; set; }

		/// <summary>
		/// <para>Report Output Formats</para>
		/// <para>The report output format. The default value is PDF. Additional available formats are XLSX, HTML, CSV, and PAGX.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Report Options")]
		public object ReportFormat { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutputReport { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSurveyReportForTargets SetEnviroment(object workspace = null )
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
			/// <para>Understanding Your Target—Media-related characteristics—for example, reading, watching, and listening related.</para>
			/// </summary>
			[GPValue("UNDERSTANDING_YOUR_TARGET")]
			[Description("Understanding Your Target")]
			Understanding_Your_Target,

			/// <summary>
			/// <para>Developing Market Strategies—Leisure-related characteristics—for example, leisure, sports, and travel.</para>
			/// </summary>
			[GPValue("DEVELOPING_MARKET_STRATEGIES")]
			[Description("Developing Market Strategies")]
			Developing_Market_Strategies,

			/// <summary>
			/// <para>Custom— User-defined characteristics. This is the default.</para>
			/// </summary>
			[GPValue("CUSTOM")]
			[Description("Custom")]
			Custom,

		}

#endregion
	}
}
