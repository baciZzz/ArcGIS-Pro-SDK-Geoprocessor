using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Report Aviation Chart Changes</para>
	/// <para>Compares feature classes in two enterprise geodatabase versions and returns the differences in a report. You can filter the reported changes to determine which charts are affected by the differing data sources. You can set  filters based on areas of interest (AOI), definition queries, and Report Chart Changes preferences.</para>
	/// </summary>
	public class ReportAviationChartChanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="AviationWorkspace">
		/// <para>Aviation Workspace</para>
		/// <para>The versioned enterprise ArcGIS Aviation Charting AIS geodatabase.</para>
		/// <para>The workspace cannot be a file geodatabase.</para>
		/// </param>
		/// <param name="BaseVersion">
		/// <para>Base Version</para>
		/// <para>The version of the ArcGIS Aviation Charting AIS geodatabase to compare to.</para>
		/// </param>
		/// <param name="ComparisonVersion">
		/// <para>Comparison Version</para>
		/// <para>The version of the ArcGIS Aviation Charting AIS geodatabase to compare to the Base Version parameter value.</para>
		/// </param>
		/// <param name="ReportPreference">
		/// <para>Report Preference</para>
		/// <para>The Report Chart Changes preference setting from the preference table.</para>
		/// <para>This preference will define which feature classes will be included in your report.</para>
		/// </param>
		/// <param name="ReportName">
		/// <para>Report Name</para>
		/// <para>The unique name of the report, containing changes between the geodatabase versions.</para>
		/// </param>
		public ReportAviationChartChanges(object AviationWorkspace, object BaseVersion, object ComparisonVersion, object ReportPreference, object ReportName)
		{
			this.AviationWorkspace = AviationWorkspace;
			this.BaseVersion = BaseVersion;
			this.ComparisonVersion = ComparisonVersion;
			this.ReportPreference = ReportPreference;
			this.ReportName = ReportName;
		}

		/// <summary>
		/// <para>Tool Display Name : Report Aviation Chart Changes</para>
		/// </summary>
		public override string DisplayName => "Report Aviation Chart Changes";

		/// <summary>
		/// <para>Tool Name : ReportAviationChartChanges</para>
		/// </summary>
		public override string ToolName => "ReportAviationChartChanges";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ReportAviationChartChanges</para>
		/// </summary>
		public override string ExcuteName => "aviation.ReportAviationChartChanges";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { AviationWorkspace, BaseVersion, ComparisonVersion, ReportPreference, ReportName, AoiFeatures, ReportId };

		/// <summary>
		/// <para>Aviation Workspace</para>
		/// <para>The versioned enterprise ArcGIS Aviation Charting AIS geodatabase.</para>
		/// <para>The workspace cannot be a file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object AviationWorkspace { get; set; }

		/// <summary>
		/// <para>Base Version</para>
		/// <para>The version of the ArcGIS Aviation Charting AIS geodatabase to compare to.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BaseVersion { get; set; }

		/// <summary>
		/// <para>Comparison Version</para>
		/// <para>The version of the ArcGIS Aviation Charting AIS geodatabase to compare to the Base Version parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ComparisonVersion { get; set; }

		/// <summary>
		/// <para>Report Preference</para>
		/// <para>The Report Chart Changes preference setting from the preference table.</para>
		/// <para>This preference will define which feature classes will be included in your report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ReportPreference { get; set; }

		/// <summary>
		/// <para>Report Name</para>
		/// <para>The unique name of the report, containing changes between the geodatabase versions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ReportName { get; set; }

		/// <summary>
		/// <para>Area of Interest Features</para>
		/// <para>The boundary within which features will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object AoiFeatures { get; set; }

		/// <summary>
		/// <para>ID of Generated Report</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object ReportId { get; set; }

	}
}
