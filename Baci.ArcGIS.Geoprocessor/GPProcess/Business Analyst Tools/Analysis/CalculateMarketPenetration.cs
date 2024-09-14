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
	/// <para>Calculate Market Penetration</para>
	/// <para>Calculate Market Penetration</para>
	/// <para>Calculates the market penetration based on the number of customers within an area compared to a demographic variable such as total population.</para>
	/// </summary>
	public class CalculateMarketPenetration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class used for calculating market penetration.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that contains the calculated market penetration features.</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>A unique ID field in the market penetration layer.</para>
		/// </param>
		/// <param name="MarketPenetrationBaseField">
		/// <para>Market Penetration Base Field</para>
		/// <para>The field containing the values used to calculate market penetration. This field will be used as the denominator and represents your market—for example, Total Population or Total Households.</para>
		/// </param>
		/// <param name="InCustomerFeatures">
		/// <para>Input Customer Features</para>
		/// <para>The input feature class containing the points for the customer layer.</para>
		/// </param>
		public CalculateMarketPenetration(object InFeatures, object OutFeatureClass, object IdField, object MarketPenetrationBaseField, object InCustomerFeatures)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.IdField = IdField;
			this.MarketPenetrationBaseField = MarketPenetrationBaseField;
			this.InCustomerFeatures = InCustomerFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Market Penetration</para>
		/// </summary>
		public override string DisplayName() => "Calculate Market Penetration";

		/// <summary>
		/// <para>Tool Name : CalculateMarketPenetration</para>
		/// </summary>
		public override string ToolName() => "CalculateMarketPenetration";

		/// <summary>
		/// <para>Tool Excute Name : ba.CalculateMarketPenetration</para>
		/// </summary>
		public override string ExcuteName() => "ba.CalculateMarketPenetration";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, IdField, MarketPenetrationBaseField, InCustomerFeatures, AreaDescriptionField!, WeightField!, CreateReport!, StoreId!, LinkField!, ReportTitle!, ReportFolder!, ReportFormat!, OutputReport! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class used for calculating market penetration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that contains the calculated market penetration features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>A unique ID field in the market penetration layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Market Penetration Base Field</para>
		/// <para>The field containing the values used to calculate market penetration. This field will be used as the denominator and represents your market—for example, Total Population or Total Households.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object MarketPenetrationBaseField { get; set; }

		/// <summary>
		/// <para>Input Customer Features</para>
		/// <para>The input feature class containing the points for the customer layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InCustomerFeatures { get; set; }

		/// <summary>
		/// <para>Area Description Field</para>
		/// <para>The field used to describe each feature in the market penetration layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? AreaDescriptionField { get; set; }

		/// <summary>
		/// <para>Customer Weight Field</para>
		/// <para>The field in the customer layer used as a weight to calculate market penetration rather than customer counts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Create Report</para>
		/// <para>Specifies whether a summary report will be created.</para>
		/// <para>Checked—A summary report will be created.</para>
		/// <para>Unchecked—A summary report will not be created. This is the default.</para>
		/// <para><see cref="CreateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateReport { get; set; } = "false";

		/// <summary>
		/// <para>Input Feature Store ID Field</para>
		/// <para>A unique identifier associated with each store for each trade area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		[Category("Trade Area Penetration")]
		public object? StoreId { get; set; }

		/// <summary>
		/// <para>Customer Feature Store ID Field</para>
		/// <para>An ID that assigns a trade area to a customer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		[Category("Trade Area Penetration")]
		public object? LinkField { get; set; }

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object? ReportTitle { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output directory that will contain the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Report Options")]
		public object? ReportFolder { get; set; }

		/// <summary>
		/// <para>Report Format</para>
		/// <para>Specifies one or more output report formats. The default value is PDF. Additional available formats: XLSX, HTML, CSV, PAGX.</para>
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
		public CalculateMarketPenetration SetEnviroment(object? workspace = null)
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
			/// <para>Checked—A summary report will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_REPORT")]
			CREATE_REPORT,

			/// <summary>
			/// <para>Unchecked—A summary report will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CREATE_REPORT")]
			DO_NOT_CREATE_REPORT,

		}

#endregion
	}
}
