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
	/// <para>Summary Reports</para>
	/// <para>Populates and creates demographic style summary reports for any boundary layer using Esri report templates.</para>
	/// </summary>
	public class SummaryReports : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Boundary Layer</para>
		/// <para>The boundary layer containing one or more polygons that will be used to create reports.</para>
		/// </param>
		/// <param name="ReportTemplates">
		/// <para>Create Reports</para>
		/// <para>One or more report templates that will be used to create the summary report. You must be signed in to ArcGIS Online or have Business Analyst Data installed.</para>
		/// </param>
		/// <param name="ReportsFolder">
		/// <para>Output Folder</para>
		/// <para>The output location where the summary reports will be saved.</para>
		/// </param>
		public SummaryReports(object InFeatures, object ReportTemplates, object ReportsFolder)
		{
			this.InFeatures = InFeatures;
			this.ReportTemplates = ReportTemplates;
			this.ReportsFolder = ReportsFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Summary Reports</para>
		/// </summary>
		public override string DisplayName => "Summary Reports";

		/// <summary>
		/// <para>Tool Name : SummaryReports</para>
		/// </summary>
		public override string ToolName => "SummaryReports";

		/// <summary>
		/// <para>Tool Excute Name : ba.SummaryReports</para>
		/// </summary>
		public override string ExcuteName => "ba.SummaryReports";

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
		public override object[] Parameters => new object[] { InFeatures, ReportTemplates, ReportsFolder, SummarizationOptions, SingleReport, Formats, StoreIdField, StoreNameField, StoreAddressField, StoreLatitudeField, StoreLongitudeField, RingIdField, AreaDescriptionField, Title, Subtitle, OutputFiles };

		/// <summary>
		/// <para>Boundary Layer</para>
		/// <para>The boundary layer containing one or more polygons that will be used to create reports.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Create Reports</para>
		/// <para>One or more report templates that will be used to create the summary report. You must be signed in to ArcGIS Online or have Business Analyst Data installed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ReportTemplates { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output location where the summary reports will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object ReportsFolder { get; set; }

		/// <summary>
		/// <para>Summarization Options</para>
		/// <para>Specifies how the data will be displayed in a report.</para>
		/// <para>Individual features—Selected report templates will be returned for each individual trade area polygon. This is the default.</para>
		/// <para>For the whole layer—Selected report templates will be returned representing only the full extent of the trade area.</para>
		/// <para>For both individual features and the whole layer—Selected report templates will be returned for both individual features and the whole layer.</para>
		/// <para><see cref="SummarizationOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Report Formatting")]
		public object SummarizationOptions { get; set; } = "INDIVIDUAL_FEATURES";

		/// <summary>
		/// <para>Single Report</para>
		/// <para>Specifies whether a single output will be generated or if a separate file will be generated for each report.</para>
		/// <para>Checked—All reports will be combined into a single output.</para>
		/// <para>Unchecked—A separate file will be generated for each selected report. This is the default.</para>
		/// <para><see cref="SingleReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Report Formatting")]
		public object SingleReport { get; set; } = "false";

		/// <summary>
		/// <para>Report Output Formats</para>
		/// <para>The report output format. The default value is PDF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Report Formatting")]
		public object Formats { get; set; } = "PDF";

		/// <summary>
		/// <para>Store ID Field</para>
		/// <para>The field that will be used to group data for each site in output reports. These field values are not displayed in the header.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object StoreIdField { get; set; }

		/// <summary>
		/// <para>Store Name Field</para>
		/// <para>The field values that will be displayed in the output report headers that identify the site corresponding to each polygon's data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object StoreNameField { get; set; }

		/// <summary>
		/// <para>Store Address Field</para>
		/// <para>The store address associated with each trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object StoreAddressField { get; set; }

		/// <summary>
		/// <para>Store Latitude Field</para>
		/// <para>The field that will contain the latitude coordinates (y field).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object StoreLatitudeField { get; set; }

		/// <summary>
		/// <para>Store Longitude Field</para>
		/// <para>The field that will contain the longitude coordinates (x field).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object StoreLongitudeField { get; set; }

		/// <summary>
		/// <para>Ring ID Field</para>
		/// <para>The field that will control the presentation order of data for inputs with multiple polygons per site.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object RingIdField { get; set; }

		/// <summary>
		/// <para>Area Description Field</para>
		/// <para>The field that will be displayed as the output template header with values corresponding to each input polygons' data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Report Header Options")]
		public object AreaDescriptionField { get; set; }

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title on the report header.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Header Options")]
		public object Title { get; set; }

		/// <summary>
		/// <para>Report Subtitle</para>
		/// <para>The subtitle on the report header. The default value is Prepared by Business Analyst Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Header Options")]
		public object Subtitle { get; set; } = "Prepared By Business Analyst for ArcGIS Pro";

		/// <summary>
		/// <para>Output Files</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutputFiles { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummaryReports SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Summarization Options</para>
		/// </summary>
		public enum SummarizationOptionsEnum 
		{
			/// <summary>
			/// <para>Individual features—Selected report templates will be returned for each individual trade area polygon. This is the default.</para>
			/// </summary>
			[GPValue("INDIVIDUAL_FEATURES")]
			[Description("Individual features")]
			Individual_features,

			/// <summary>
			/// <para>For the whole layer—Selected report templates will be returned representing only the full extent of the trade area.</para>
			/// </summary>
			[GPValue("WHOLE_LAYER")]
			[Description("For the whole layer")]
			For_the_whole_layer,

			/// <summary>
			/// <para>For both individual features and the whole layer—Selected report templates will be returned for both individual features and the whole layer.</para>
			/// </summary>
			[GPValue("BOTH_FEATURES_AND_LAYER")]
			[Description("For both individual features and the whole layer")]
			For_both_individual_features_and_the_whole_layer,

		}

		/// <summary>
		/// <para>Single Report</para>
		/// </summary>
		public enum SingleReportEnum 
		{
			/// <summary>
			/// <para>Checked—All reports will be combined into a single output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_SINGLE_REPORT")]
			CREATE_SINGLE_REPORT,

			/// <summary>
			/// <para>Unchecked—A separate file will be generated for each selected report. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CREATE_REPORT_PER_TEMPLATE")]
			CREATE_REPORT_PER_TEMPLATE,

		}

#endregion
	}
}
