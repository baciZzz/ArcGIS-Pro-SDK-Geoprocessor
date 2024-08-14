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
	/// <para>Find Nearby Locations</para>
	/// <para>Identifies locations closest to the input features based on a selected distance type. The number of points in the output is defined by limiting the count or percentage of location points to return or by limiting the distance from the input points.</para>
	/// </summary>
	public class FindNearbyLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point layer to be measured to or from the Location Points parameter value.</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>A field containing unique identifiers for each input feature.</para>
		/// </param>
		/// <param name="InLocationPoints">
		/// <para>Location Points</para>
		/// <para>The layer that will be used to generate the output with distance and direction attributes to or from the Input Features parameter value.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output location point features.</para>
		/// </param>
		public FindNearbyLocations(object InFeatures, object IdField, object InLocationPoints, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.IdField = IdField;
			this.InLocationPoints = InLocationPoints;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Nearby Locations</para>
		/// </summary>
		public override string DisplayName => "Find Nearby Locations";

		/// <summary>
		/// <para>Tool Name : FindNearbyLocations</para>
		/// </summary>
		public override string ToolName => "FindNearbyLocations";

		/// <summary>
		/// <para>Tool Excute Name : ba.FindNearbyLocations</para>
		/// </summary>
		public override string ExcuteName => "ba.FindNearbyLocations";

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
		public override string[] ValidEnvironments => new string[] { "baDataSource", "baNetworkSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, IdField, InLocationPoints, OutFeatureClass, DistanceType!, Units!, DistanceLimit!, NumberLimit!, PercentLimit!, CreateReport!, ReportTitle!, ReportFolder!, ReportFormat!, ReportFields!, TravelDirection!, TimeOfDay!, TimeZone!, SearchTolerance!, OutputReport!, LocationName! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point layer to be measured to or from the Location Points parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>A field containing unique identifiers for each input feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Location Points</para>
		/// <para>The layer that will be used to generate the output with distance and direction attributes to or from the Input Features parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InLocationPoints { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output location point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The calculated distance based on the method of travel. Straight Line is the default value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceType { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The measurement units, in distance or time, that will be used when calculating nearby locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Units { get; set; }

		/// <summary>
		/// <para>Distance Limit</para>
		/// <para>The analysis extent measured in distance or time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? DistanceLimit { get; set; }

		/// <summary>
		/// <para>Number of Locations Limit</para>
		/// <para>The numeric limit of the Location Points value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NumberLimit { get; set; }

		/// <summary>
		/// <para>Percentage of Locations Limit</para>
		/// <para>The closest points, as a percentage of the points of the Location Points value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? PercentLimit { get; set; }

		/// <summary>
		/// <para>Create Report</para>
		/// <para>Specifies whether an output report will be created.</para>
		/// <para>Checked—A report will be created.</para>
		/// <para>Unchecked—A report will not be created. This is the default.</para>
		/// <para><see cref="CreateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateReport { get; set; } = "false";

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the output report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object? ReportTitle { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The directory that will contain the output report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Report Options")]
		public object? ReportFolder { get; set; }

		/// <summary>
		/// <para>Report Output Formats</para>
		/// <para>The output report formats. The default value is InfographicHTML. Additional available formats are PDF, XLSX, S.XLSX, HTML, S.XML, ZIP, CVS, PAGX, and InfographicPDF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Report Options")]
		public object? ReportFormat { get; set; }

		/// <summary>
		/// <para>Report Fields</para>
		/// <para>The additional fields that will be added to the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[Category("Report Options")]
		public object? ReportFields { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies whether travel times or distances will be measured from location points to input features or from input features to location points.</para>
		/// <para>Toward Input Features—The direction of travel will be from location points to input features. This is the default.</para>
		/// <para>Away from Input Features—The direction of travel will be from input features to location points.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TravelDirection { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time at which travel will begin.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone that will be used for the Time of Day parameter.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used. Choose this option if you want the best location for a specific time, such as now, but aren&apos;t certain of the time zone in which the Location Points value will be located.</para>
		/// <para>Local time at locations—The time zone in which the Location Points value is located will be used. If the travel direction is input features to location points, this is the time zone of the input features. If the travel direction is location points to input features, this is the time zone of the location points. This is the default.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TimeZone { get; set; } = "TIME_ZONE_AT_LOCATION";

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum distance that input points can be from the network. Points located beyond the search tolerance will be excluded from processing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Parameters")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutputReport { get; set; }

		/// <summary>
		/// <para>Location Name</para>
		/// <para>A field from the input Location Points parameter. This field contains the name or ID for each input point used in the Find Nearby Locations report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? LocationName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindNearbyLocations SetEnviroment(object? baDataSource = null , object? baNetworkSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, baNetworkSource: baNetworkSource, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Report</para>
		/// </summary>
		public enum CreateReportEnum 
		{
			/// <summary>
			/// <para>Checked—A report will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_REPORT")]
			CREATE_REPORT,

			/// <summary>
			/// <para>Unchecked—A report will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CREATE_REPORT")]
			DO_NOT_CREATE_REPORT,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward Input Features—The direction of travel will be from location points to input features. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Input Features")]
			Toward_Input_Features,

			/// <summary>
			/// <para>Away from Input Features—The direction of travel will be from input features to location points.</para>
			/// </summary>
			[GPValue("AWAY_FROM_STORES")]
			[Description("Away from Input Features")]
			Away_from_Input_Features,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—Coordinated universal time (UTC) will be used. Choose this option if you want the best location for a specific time, such as now, but aren&apos;t certain of the time zone in which the Location Points value will be located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The time zone in which the Location Points value is located will be used. If the travel direction is input features to location points, this is the time zone of the input features. If the travel direction is location points to input features, this is the time zone of the location points. This is the default.</para>
			/// </summary>
			[GPValue("TIME_ZONE_AT_LOCATION")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

#endregion
	}
}
