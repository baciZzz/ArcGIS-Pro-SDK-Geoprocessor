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
	/// <para>Measure Cannibalization</para>
	/// <para>Calculates the amount of overlap between two or more polygons. Overlap refers to the extent of the polygons beyond intersection.</para>
	/// </summary>
	public class MeasureCannibalization : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input polygon features that will be analyzed for overlap.</para>
		/// </param>
		/// <param name="AreaIdField">
		/// <para>Trade Area ID</para>
		/// <para>The field that uniquely identifies each feature in the input layer.</para>
		/// </param>
		/// <param name="AreaDescriptionField">
		/// <para>Trade Area Description</para>
		/// <para>The field that describes each feature in the input layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the areas of overlap found in the input layer.</para>
		/// </param>
		public MeasureCannibalization(object InFeatures, object AreaIdField, object AreaDescriptionField, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.AreaIdField = AreaIdField;
			this.AreaDescriptionField = AreaDescriptionField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Measure Cannibalization</para>
		/// </summary>
		public override string DisplayName => "Measure Cannibalization";

		/// <summary>
		/// <para>Tool Name : MeasureCannibalization</para>
		/// </summary>
		public override string ToolName => "MeasureCannibalization";

		/// <summary>
		/// <para>Tool Excute Name : ba.MeasureCannibalization</para>
		/// </summary>
		public override string ExcuteName => "ba.MeasureCannibalization";

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
		public override object[] Parameters => new object[] { InFeatures, AreaIdField, AreaDescriptionField, OutFeatureClass, StoreIdField, CreateReport, ReportTitle, ReportFolder, ReportFormat, OutputReport, Variables };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input polygon features that will be analyzed for overlap.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Trade Area ID</para>
		/// <para>The field that uniquely identifies each feature in the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object AreaIdField { get; set; }

		/// <summary>
		/// <para>Trade Area Description</para>
		/// <para>The field that describes each feature in the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object AreaDescriptionField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the areas of overlap found in the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Store ID Field</para>
		/// <para>The unique ID that associates a store with each polygon when the inputs are trade areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object StoreIdField { get; set; }

		/// <summary>
		/// <para>Create Report</para>
		/// <para>Specifies whether a report will be generated.</para>
		/// <para>Checked—A report will be generated.</para>
		/// <para>Unchecked—A report will not be generated. This is the default.</para>
		/// <para><see cref="CreateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateReport { get; set; } = "false";

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report. The default value is Measure Cannibalization.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object ReportTitle { get; set; } = "Measure Cannibalization";

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Report Options")]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Report Output Formats</para>
		/// <para>The output format or formats of the report.</para>
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
		/// <para>Variables</para>
		/// <para>One or more variables that will be used to calculate additional overlap metrics—for example, the total number of people and households in intersection areas, or the percentage of the total number of people and households in a trade area falling into overlapped area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Additional Metrics")]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MeasureCannibalization SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Report</para>
		/// </summary>
		public enum CreateReportEnum 
		{
			/// <summary>
			/// <para>Checked—A report will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_REPORT")]
			CREATE_REPORT,

			/// <summary>
			/// <para>Unchecked—A report will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CREATE_REPORT")]
			DO_NOT_CREATE_REPORT,

		}

#endregion
	}
}
