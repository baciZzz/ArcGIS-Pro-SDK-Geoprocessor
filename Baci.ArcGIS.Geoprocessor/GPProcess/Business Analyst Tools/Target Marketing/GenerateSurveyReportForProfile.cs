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
	/// <para>Generate Survey Report For Profile</para>
	/// <para>Generate Survey Report For Profile</para>
	/// <para>Displays characteristics from the consumer survey data for your target profile to determine customer lifestyle habits and preferences.</para>
	/// </summary>
	public class GenerateSurveyReportForProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetProfile">
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be analyzed. The target profile usually represents your customer segmentation profile.</para>
		/// </param>
		/// <param name="BaseProfile">
		/// <para>Base Profile</para>
		/// <para>A segmentation profile representing the base profile segments. This is the segmentation used for comparison. The base profile usually represents your market area segmentation profile.</para>
		/// </param>
		/// <param name="SurveyCategory">
		/// <para>Survey Category</para>
		/// <para>A category that contains characteristics from the consumer survey.</para>
		/// </param>
		/// <param name="ReportFolder">
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </param>
		public GenerateSurveyReportForProfile(object TargetProfile, object BaseProfile, object SurveyCategory, object ReportFolder)
		{
			this.TargetProfile = TargetProfile;
			this.BaseProfile = BaseProfile;
			this.SurveyCategory = SurveyCategory;
			this.ReportFolder = ReportFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Survey Report For Profile</para>
		/// </summary>
		public override string DisplayName() => "Generate Survey Report For Profile";

		/// <summary>
		/// <para>Tool Name : GenerateSurveyReportForProfile</para>
		/// </summary>
		public override string ToolName() => "GenerateSurveyReportForProfile";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateSurveyReportForProfile</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateSurveyReportForProfile";

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
		public override object[] Parameters() => new object[] { TargetProfile, BaseProfile, SurveyCategory, ReportFolder, SortColumn!, SortOrder!, ReportTitle!, ReportFormat!, OutputReport! };

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
		/// <para>Base Profile</para>
		/// <para>A segmentation profile representing the base profile segments. This is the segmentation used for comparison. The base profile usually represents your market area segmentation profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object BaseProfile { get; set; }

		/// <summary>
		/// <para>Survey Category</para>
		/// <para>A category that contains characteristics from the consumer survey.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SurveyCategory { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		[Category("Report Options")]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Sort Column</para>
		/// <para>Specifies the column to use to sort the report.</para>
		/// <para>Expected Number—Sort is based on counts—for example, number of adults. This is the default.</para>
		/// <para>Index—Sort is based on rank.</para>
		/// <para><see cref="SortColumnEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SortColumn { get; set; } = "EXPECTED_NUMBER";

		/// <summary>
		/// <para>Sort Order</para>
		/// <para>Specifies the order of the report, based on the sort column, in ascending or descending order.</para>
		/// <para>Ascending—Sort in ascending order.</para>
		/// <para>Descending—Sort in descending order. This is the default.</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SortOrder { get; set; } = "DESCENDING";

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object? ReportTitle { get; set; }

		/// <summary>
		/// <para>Report Formats</para>
		/// <para>The report output format. The default value is PDF. Additional available formats are XLSX, HTML, CSV, and PAGX.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Report Options")]
		public object? ReportFormat { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutputReport { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSurveyReportForProfile SetEnviroment(object? baDataSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort Column</para>
		/// </summary>
		public enum SortColumnEnum 
		{
			/// <summary>
			/// <para>Expected Number—Sort is based on counts—for example, number of adults. This is the default.</para>
			/// </summary>
			[GPValue("EXPECTED_NUMBER")]
			[Description("Expected Number")]
			Expected_Number,

			/// <summary>
			/// <para>Index—Sort is based on rank.</para>
			/// </summary>
			[GPValue("INDEX")]
			[Description("Index")]
			Index,

		}

		/// <summary>
		/// <para>Sort Order</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para>Ascending—Sort in ascending order.</para>
			/// </summary>
			[GPValue("ASCENDING")]
			[Description("Ascending")]
			Ascending,

			/// <summary>
			/// <para>Descending—Sort in descending order. This is the default.</para>
			/// </summary>
			[GPValue("DESCENDING")]
			[Description("Descending")]
			Descending,

		}

#endregion
	}
}
