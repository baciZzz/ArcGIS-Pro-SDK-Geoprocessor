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
	/// <para>Generate Customer Derived Trade Areas</para>
	/// <para>Generate Customer Derived Trade Areas</para>
	/// <para>Creates trade areas around stores based on the number of customers or volume attribute of each customer.</para>
	/// </summary>
	public class CustomerDerivedTA : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStoresLayer">
		/// <para>Stores</para>
		/// <para>A point layer representing store or facility locations.</para>
		/// </param>
		/// <param name="StoreIdField">
		/// <para>Store ID Field</para>
		/// <para>The unique ID field representing a store or facility location.</para>
		/// </param>
		/// <param name="InCustomersLayer">
		/// <para>Customers</para>
		/// <para>An input point layer representing customers or patrons.</para>
		/// </param>
		/// <param name="LinkField">
		/// <para>Associated Store ID Field</para>
		/// <para>An ID field that will be used to assign individual customers to stores.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output trade area feature class.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>Specifies the type of customer-derived trade area that will be generated.</para>
		/// <para>Simple—A generalized trade area based on the percentages of customers corresponding to each store will be generated.</para>
		/// <para>Amoeba—Points representing the boundary of the polygon trade area will be connected using natural curvature.</para>
		/// <para>Detailed—Points representing the boundary of the polygon trade area will be connected using straight lines.</para>
		/// <para>Detailed with smoothing—Points representing the boundary of the polygon trade area will be connected with smoothed curves using cubic splines. This approach takes into account the shape and pattern of the customer distributions. This is the default.</para>
		/// <para>Threshold Rings— Concentric rings that expand from input stores until they contain the specified threshold of customers will be generated.</para>
		/// <para>Threshold Drive Times—Polygons that expand from stores along network routes until they contain the specified threshold of customers will be generated.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="Rings">
		/// <para>Radii (%)</para>
		/// <para>The values that will be used to represent the percentage of customers—for example, total count or a customer attribute and total sales assigned to each store. Each value represents one trade area polygon.</para>
		/// </param>
		/// <param name="CustomerAggregationType">
		/// <para>Customer Aggregation Type</para>
		/// <para>Specifies the type of aggregation that will be used.</para>
		/// <para>Count—Percentage-based trade areas will be calculated using the geographic locations of customers. This is the default.</para>
		/// <para>Weight—Percentage-based trade areas will be calculated using a customer attribute—for example, sales.</para>
		/// <para><see cref="CustomerAggregationTypeEnum"/></para>
		/// </param>
		public CustomerDerivedTA(object InStoresLayer, object StoreIdField, object InCustomersLayer, object LinkField, object OutFeatureClass, object Method, object Rings, object CustomerAggregationType)
		{
			this.InStoresLayer = InStoresLayer;
			this.StoreIdField = StoreIdField;
			this.InCustomersLayer = InCustomersLayer;
			this.LinkField = LinkField;
			this.OutFeatureClass = OutFeatureClass;
			this.Method = Method;
			this.Rings = Rings;
			this.CustomerAggregationType = CustomerAggregationType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Customer Derived Trade Areas</para>
		/// </summary>
		public override string DisplayName() => "Generate Customer Derived Trade Areas";

		/// <summary>
		/// <para>Tool Name : CustomerDerivedTA</para>
		/// </summary>
		public override string ToolName() => "CustomerDerivedTA";

		/// <summary>
		/// <para>Tool Excute Name : ba.CustomerDerivedTA</para>
		/// </summary>
		public override string ExcuteName() => "ba.CustomerDerivedTA";

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
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "baNetworkSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InStoresLayer, StoreIdField, InCustomersLayer, LinkField, OutFeatureClass, Method, Rings, CustomerAggregationType, CustomerWeightField, ExcludeOutlyingCustomers, CutoffDistance, DissolveOption, UseCustomerCentroids, DistanceType, Units, TravelDirection, TimeOfDay, TimeZone, SearchTolerance, PolygonDetail, IterationsLimit, MinimumStep, TargetPercentDiff };

		/// <summary>
		/// <para>Stores</para>
		/// <para>A point layer representing store or facility locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InStoresLayer { get; set; }

		/// <summary>
		/// <para>Store ID Field</para>
		/// <para>The unique ID field representing a store or facility location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "Float", "Double", "GUID", "GlobalID")]
		public object StoreIdField { get; set; }

		/// <summary>
		/// <para>Customers</para>
		/// <para>An input point layer representing customers or patrons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InCustomersLayer { get; set; }

		/// <summary>
		/// <para>Associated Store ID Field</para>
		/// <para>An ID field that will be used to assign individual customers to stores.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "Float", "Double", "GUID", "GlobalID")]
		public object LinkField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output trade area feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the type of customer-derived trade area that will be generated.</para>
		/// <para>Simple—A generalized trade area based on the percentages of customers corresponding to each store will be generated.</para>
		/// <para>Amoeba—Points representing the boundary of the polygon trade area will be connected using natural curvature.</para>
		/// <para>Detailed—Points representing the boundary of the polygon trade area will be connected using straight lines.</para>
		/// <para>Detailed with smoothing—Points representing the boundary of the polygon trade area will be connected with smoothed curves using cubic splines. This approach takes into account the shape and pattern of the customer distributions. This is the default.</para>
		/// <para>Threshold Rings— Concentric rings that expand from input stores until they contain the specified threshold of customers will be generated.</para>
		/// <para>Threshold Drive Times—Polygons that expand from stores along network routes until they contain the specified threshold of customers will be generated.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "DETAILED_WITH_SMOOTHING";

		/// <summary>
		/// <para>Radii (%)</para>
		/// <para>The values that will be used to represent the percentage of customers—for example, total count or a customer attribute and total sales assigned to each store. Each value represents one trade area polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100)]
		public object Rings { get; set; }

		/// <summary>
		/// <para>Customer Aggregation Type</para>
		/// <para>Specifies the type of aggregation that will be used.</para>
		/// <para>Count—Percentage-based trade areas will be calculated using the geographic locations of customers. This is the default.</para>
		/// <para>Weight—Percentage-based trade areas will be calculated using a customer attribute—for example, sales.</para>
		/// <para><see cref="CustomerAggregationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CustomerAggregationType { get; set; } = "COUNT";

		/// <summary>
		/// <para>Customer Weight Field</para>
		/// <para>The field that will be used to calculate the trade areas. This is based on either the number of customers (count) or the calculated weighted value assigned to each customer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object CustomerWeightField { get; set; }

		/// <summary>
		/// <para>Exclude Outlying Customers</para>
		/// <para>Specifies whether outlying customers will be excluded from the trade area generation.</para>
		/// <para>Checked—Outlying customers will be excluded.</para>
		/// <para>Unchecked—Outlying customers will not be excluded; all customers will be considered. This is the default.</para>
		/// <para><see cref="ExcludeOutlyingCustomersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExcludeOutlyingCustomers { get; set; } = "false";

		/// <summary>
		/// <para>Cut-off Distance</para>
		/// <para>The distance beyond which customers will be considered outliers and excluded from consideration during trade area generation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object CutoffDistance { get; set; }

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>Specifies whether polygons of the entire area will be created or the polygons will be split into individual features.</para>
		/// <para>Overlap— Output polygons will be generated in which each feature begins at zero and grows to satisfy the specified percentage of customers. For example, if you specify a trade area of 50 percent and 70 percent of your customers, one polygon will be generated to include 0 to 50 percent and a second polygon will include all 0 to 70 percent of customers. This is the default.</para>
		/// <para>Split— Output polygons will be generated for individual features based on the specified percentage breaks. For example, if you specify a trade area of 50 percent and 70 percent of your customers, one polygon will be generated to include 0 to 50 percent and a second polygon will include 50 to 70 percent of customers.</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "OVERLAP";

		/// <summary>
		/// <para>Use Customers Centroid for Trade Area Center</para>
		/// <para>Specifies whether the centroid of your customer area will be used to calculate trade areas outward from this point.</para>
		/// <para>Checked—The centroid of customer points will be used to calculate trade areas.</para>
		/// <para>Unchecked—The centroid of customer points will not be used; store location will be used as the starting point to calculate trade areas. This is the default.</para>
		/// <para><see cref="UseCustomerCentroidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseCustomerCentroids { get; set; } = "false";

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The method of travel that will be used to calculate the distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The units that will be used for the distance values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Units { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel that will be used between stores and customers.</para>
		/// <para>Toward Stores—The direction of travel will be from customers to stores. This is the default.</para>
		/// <para>Away from Stores—The direction of travel will be from stores to customers.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object TravelDirection { get; set; } = "TOWARD_STORES";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time and date that will be used when calculating distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone that will be used for the Time of Day parameter.</para>
		/// <para>Time Zone at Location—The time zone in which the territories are located will be used. This is the default.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object TimeZone { get; set; } = "TIME_ZONE_AT_LOCATION";

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum distance that input points can be from the network. Points located beyond the search tolerance will be excluded from processing.</para>
		/// <para>The parameter requires a distance value and units for the tolerance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Parameters")]
		public object SearchTolerance { get; set; }

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>Specifies the level of detail that will be used for the output drive time polygons.</para>
		/// <para>Standard— Polygons with a standard level of detail will be created. This is the default.</para>
		/// <para>Generalized—Generalized polygons will be created using the hierarchy present in the network data source to produce results quickly.</para>
		/// <para>High— Polygons with a high level of detail will be created for applications in which precise results are important.</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object PolygonDetail { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Iterations Limit</para>
		/// <para>Restricts the number of drive times that can be used to find the optimal threshold limit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object IterationsLimit { get; set; }

		/// <summary>
		/// <para>Minimum Step</para>
		/// <para>The minimum increment distance or time—for example, 1 mile or 1 minute—that will be used between iterations to expand until the threshold is reached.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Advanced Parameters")]
		public object MinimumStep { get; set; }

		/// <summary>
		/// <para>Threshold Percent Difference</para>
		/// <para>The maximum percentage difference between the target value and threshold value that will be used when determining the threshold drive time, for example, 5 percent. The default value is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[High(Allow = false, Value = 100)]
		[Category("Advanced Parameters")]
		public object TargetPercentDiff { get; set; } = "5";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CustomerDerivedTA SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Simple—A generalized trade area based on the percentages of customers corresponding to each store will be generated.</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("Simple")]
			Simple,

			/// <summary>
			/// <para>Amoeba—Points representing the boundary of the polygon trade area will be connected using natural curvature.</para>
			/// </summary>
			[GPValue("AMOEBA")]
			[Description("Amoeba")]
			Amoeba,

			/// <summary>
			/// <para>Detailed—Points representing the boundary of the polygon trade area will be connected using straight lines.</para>
			/// </summary>
			[GPValue("DETAILED")]
			[Description("Detailed")]
			Detailed,

			/// <summary>
			/// <para>Detailed with smoothing—Points representing the boundary of the polygon trade area will be connected with smoothed curves using cubic splines. This approach takes into account the shape and pattern of the customer distributions. This is the default.</para>
			/// </summary>
			[GPValue("DETAILED_WITH_SMOOTHING")]
			[Description("Detailed with smoothing")]
			Detailed_with_smoothing,

			/// <summary>
			/// <para>Threshold Rings— Concentric rings that expand from input stores until they contain the specified threshold of customers will be generated.</para>
			/// </summary>
			[GPValue("THRESHOLD_RINGS")]
			[Description("Threshold Rings")]
			Threshold_Rings,

			/// <summary>
			/// <para>Threshold Drive Times—Polygons that expand from stores along network routes until they contain the specified threshold of customers will be generated.</para>
			/// </summary>
			[GPValue("THRESHOLD_DRIVETIMES")]
			[Description("Threshold Drive Times")]
			Threshold_Drive_Times,

		}

		/// <summary>
		/// <para>Customer Aggregation Type</para>
		/// </summary>
		public enum CustomerAggregationTypeEnum 
		{
			/// <summary>
			/// <para>Count—Percentage-based trade areas will be calculated using the geographic locations of customers. This is the default.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count")]
			Count,

			/// <summary>
			/// <para>Weight—Percentage-based trade areas will be calculated using a customer attribute—for example, sales.</para>
			/// </summary>
			[GPValue("WEIGHT")]
			[Description("Weight")]
			Weight,

		}

		/// <summary>
		/// <para>Exclude Outlying Customers</para>
		/// </summary>
		public enum ExcludeOutlyingCustomersEnum 
		{
			/// <summary>
			/// <para>Checked—Outlying customers will be excluded.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE_OUTLIERS")]
			EXCLUDE_OUTLIERS,

			/// <summary>
			/// <para>Unchecked—Outlying customers will not be excluded; all customers will be considered. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_POINTS")]
			ALL_POINTS,

		}

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>Overlap— Output polygons will be generated in which each feature begins at zero and grows to satisfy the specified percentage of customers. For example, if you specify a trade area of 50 percent and 70 percent of your customers, one polygon will be generated to include 0 to 50 percent and a second polygon will include all 0 to 70 percent of customers. This is the default.</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Split— Output polygons will be generated for individual features based on the specified percentage breaks. For example, if you specify a trade area of 50 percent and 70 percent of your customers, one polygon will be generated to include 0 to 50 percent and a second polygon will include 50 to 70 percent of customers.</para>
			/// </summary>
			[GPValue("SPLIT")]
			[Description("Split")]
			Split,

		}

		/// <summary>
		/// <para>Use Customers Centroid for Trade Area Center</para>
		/// </summary>
		public enum UseCustomerCentroidsEnum 
		{
			/// <summary>
			/// <para>Checked—The centroid of customer points will be used to calculate trade areas.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CENTROIDS")]
			USE_CENTROIDS,

			/// <summary>
			/// <para>Unchecked—The centroid of customer points will not be used; store location will be used as the starting point to calculate trade areas. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_STORES")]
			USE_STORES,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward Stores—The direction of travel will be from customers to stores. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Stores")]
			Toward_Stores,

			/// <summary>
			/// <para>Away from Stores—The direction of travel will be from stores to customers.</para>
			/// </summary>
			[GPValue("AWAY_FROM_STORES")]
			[Description("Away from Stores")]
			Away_from_Stores,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Time Zone at Location—The time zone in which the territories are located will be used. This is the default.</para>
			/// </summary>
			[GPValue("TIME_ZONE_AT_LOCATION")]
			[Description("Time Zone at Location")]
			Time_Zone_at_Location,

		}

		/// <summary>
		/// <para>Polygon Detail</para>
		/// </summary>
		public enum PolygonDetailEnum 
		{
			/// <summary>
			/// <para>Standard— Polygons with a standard level of detail will be created. This is the default.</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard")]
			Standard,

			/// <summary>
			/// <para>Generalized—Generalized polygons will be created using the hierarchy present in the network data source to produce results quickly.</para>
			/// </summary>
			[GPValue("GENERALIZED")]
			[Description("Generalized")]
			Generalized,

			/// <summary>
			/// <para>High— Polygons with a high level of detail will be created for applications in which precise results are important.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

#endregion
	}
}
