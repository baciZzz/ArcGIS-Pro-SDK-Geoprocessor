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
	/// <para>Generate Segmentation Profile Report</para>
	/// <para>Creates a report that displays segments of your customers and compares them to the study area (base profile).</para>
	/// </summary>
	public class GenerateSegmentationProfileReport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetProfile">
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be profiled. The target profile usually represents your customer segmentation profile.</para>
		/// </param>
		/// <param name="BaseProfile">
		/// <para>Base Profile</para>
		/// <para>A segmentation profile representing the base profile segments. This is the segmentation used for comparison. The base profile usually represents your market area segmentation profile.</para>
		/// </param>
		public GenerateSegmentationProfileReport(object TargetProfile, object BaseProfile)
		{
			this.TargetProfile = TargetProfile;
			this.BaseProfile = BaseProfile;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Segmentation Profile Report</para>
		/// </summary>
		public override string DisplayName => "Generate Segmentation Profile Report";

		/// <summary>
		/// <para>Tool Name : GenerateSegmentationProfileReport</para>
		/// </summary>
		public override string ToolName => "GenerateSegmentationProfileReport";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateSegmentationProfileReport</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateSegmentationProfileReport";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { TargetProfile, BaseProfile, ReportTitle, ReportFolder, ReportFormat, OutputReport };

		/// <summary>
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be profiled. The target profile usually represents your customer segmentation profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object TargetProfile { get; set; }

		/// <summary>
		/// <para>Base Profile</para>
		/// <para>A segmentation profile representing the base profile segments. This is the segmentation used for comparison. The base profile usually represents your market area segmentation profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object BaseProfile { get; set; }

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object ReportTitle { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output location to which the report will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Report Options")]
		public object ReportFolder { get; set; }

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
		public GenerateSegmentationProfileReport SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
