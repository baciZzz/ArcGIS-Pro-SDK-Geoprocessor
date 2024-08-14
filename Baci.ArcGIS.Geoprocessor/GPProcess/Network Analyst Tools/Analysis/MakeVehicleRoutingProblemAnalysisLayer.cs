using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Make Vehicle Routing Problem Analysis Layer</para>
	/// <para>Creates a vehicle routing problem (VRP) network analysis layer and sets its analysis properties. A VRP analysis layer is useful for optimizing a set of routes using a fleet of vehicles. The layer can be created using a local network dataset or a service hosted online or in a portal.</para>
	/// </summary>
	public class MakeVehicleRoutingProblemAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </param>
		public MakeVehicleRoutingProblemAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Vehicle Routing Problem Analysis Layer</para>
		/// </summary>
		public override string DisplayName => "Make Vehicle Routing Problem Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeVehicleRoutingProblemAnalysisLayer</para>
		/// </summary>
		public override string ToolName => "MakeVehicleRoutingProblemAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeVehicleRoutingProblemAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName => "na.MakeVehicleRoutingProblemAnalysisLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { NetworkDataSource, LayerName!, TravelMode!, TimeUnits!, DistanceUnits!, DefaultDate!, TimeZoneForTimeFields!, LineShape!, TimeWindowFactor!, ExcessTransitFactor!, GenerateDirectionsOnSolve!, SpatialClustering!, OutNetworkAnalysisLayer!, IgnoreInvalidLocations! };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>The name of the VRP network analysis layer to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The name of the travel mode to use in the analysis. The travel mode represents a collection of network settings, such as travel restrictions and U-turn policies, that determine how a pedestrian, car, truck, or other medium of transportation moves through the network. Travel modes are defined on your network data source. An arcpy.na.TravelMode object and a string containing the valid JSON representation of a travel mode can also be used as input to the parameter.</para>
		/// <para>VRP only solves with a time-based impedance, so only time-based impedance travel modes are available for selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Time Field Units</para>
		/// <para>Specifies the time units to be used by the temporal fields of the analysis layer&apos;s sublayers and tables (network analysis classes). This value does not need to match the units of the time cost attribute.</para>
		/// <para>Minutes—The time units will be minutes. This is the default.</para>
		/// <para>Seconds—The time units will be seconds.</para>
		/// <para>Hours—The time units will be hours.</para>
		/// <para>Days—The time units will be days.</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Field Units</para>
		/// <para>Specifies the distance units to be used by the distance fields of the analysis layer&apos;s sublayers and tables (network analysis classes). This value does not need to match the units of the optional distance cost attribute.</para>
		/// <para>Miles—The distance units will be miles. This is the default.</para>
		/// <para>Kilometers—The distance units will be kilometers.</para>
		/// <para>Feet—The distance units will be feet.</para>
		/// <para>Yards—The distance units will be yards.</para>
		/// <para>Meters—The distance units will be meters.</para>
		/// <para>Inches—The distance units will be inches.</para>
		/// <para>Centimeters—The distance units will be centimeters.</para>
		/// <para>Millimeters—The distance units will be millimeters.</para>
		/// <para>Decimeters—The distance units will be decimeters.</para>
		/// <para>Nautical Miles—The distance units will be nautical miles.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Default Date</para>
		/// <para>The implied date for time field values that don't have a date specified with the time. If a time field for an order object, such as TimeWindowStart, has a time-only value, the date is assumed to be the default date. The default date has no effect on time field values that already have a date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Date and Time")]
		public object? DefaultDate { get; set; }

		/// <summary>
		/// <para>Time Zone for Time Fields</para>
		/// <para>Specifies the time zone to be used for the input date-time fields supported by the tool.</para>
		/// <para>Local time at locations— The date-time values associated with the orders or depots will be in the time zone in which the orders and depots are located. For routes, the date-time values are based on the time zone in which the starting depot for the route is located. If a route does not have a starting depot, all orders and depots across all the routes must be in a single time zone. For breaks, the date-time values are based on the time zone of the routes. This is the default.</para>
		/// <para>UTC—The date-time values associated with the orders or depots will be in coordinated universal time (UTC) and are not based on the time zone in which the orders or depots are located.</para>
		/// <para>Specifying the date-time values in UTC is useful if you do not know the time zone in which the orders or depots are located or when you have orders and depots in multiple time zones and you want all the date-time values to start simultaneously. The UTC option is applicable only when your network dataset defines a time zone attribute. Otherwise, all the date-time values are always treated as the time zone corresponding with that location.</para>
		/// <para><see cref="TimeZoneForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Date and Time")]
		public object? TimeZoneForTimeFields { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Output Route Shape</para>
		/// <para>Specifies the shape type that will be used for the route features that are output by the analysis.</para>
		/// <para>Along network—The output routes will have the exact shape of the underlying network sources. The output includes route measurements for linear referencing. The measurements increase from the first stop and record the cumulative impedance to reach a given position.</para>
		/// <para>No lines—No shape will be generated for the output routes.</para>
		/// <para>Straight lines—The output route shape will be a single straight line between the stops.This option is not available if the selected network data source is a service.</para>
		/// <para>Regardless of the output shape type specified, the best route is always determined by the network impedance, never Euclidean distance. This means that only the route shapes are different, not the underlying traversal of the network.</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object? LineShape { get; set; } = "ALONG_NETWORK";

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// <para>Specifies the importance of honoring time windows without causing violations. A time window violation occurs when a route arrives at an order, depot, or break after a time window has closed. The violation is the interval between the end of the time window and the arrival time of a route.</para>
		/// <para>High—The solver searches for a solution that minimizes time window violations at the expense of increasing the overall travel time. Choose this setting if arriving on time at orders is more important than minimizing the overall solution cost. This may be the case if you are meeting customers at your orders and you don&apos;t want to inconvenience them with late arrivals (another option is to use rigid time windows that cannot be violated).Given other constraints of a vehicle routing problem, it may be impossible to visit all the orders within their time windows. In this case, even a High setting might produce violations.</para>
		/// <para>Medium—The solver searches for a balance between meeting time windows and reducing the overall solution cost. This is the default.</para>
		/// <para>Low—The solver searches for a solution that minimizes overall travel time, regardless of time windows. Choose this setting if respecting time windows is less important than reducing the overall solution cost. You may want to use this setting if you have a growing backlog of service requests. For the purpose of servicing more orders in a day and reducing the backlog, you can choose this setting even though customers may be inconvenienced with your fleet&apos;s late arrivals.</para>
		/// <para><see cref="TimeWindowFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? TimeWindowFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// <para>Specifies the importance of reducing excess transit time. Excess transit time is the amount of time exceeding the time required to travel directly between paired orders. The excess time results from breaks or travel to other orders or depots between visits to the paired orders. This parameter is only relevant if you&apos;re using Order Pairs.</para>
		/// <para>High—The solver searches for a solution with less excess transit time between paired orders at the expense of increasing the overall travel costs. Use this setting if you are transporting people between paired orders and you want to shorten their ride time. This is characteristic of taxi services.</para>
		/// <para>Medium—The solver searches for a balance between reducing excess transit time and reducing the overall solution cost. This is the default.</para>
		/// <para>Low—The solver searches for a solution that minimizes overall solution cost, regardless of excess transit time. This setting is commonly used with courier services. Since couriers transport packages as opposed to people, ride time is not as important. Using this setting allows couriers to service paired orders in the proper sequence and minimize the overall solution cost.</para>
		/// <para><see cref="ExcessTransitFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? ExcessTransitFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Generate Directions on Solve</para>
		/// <para>Specifies whether directions will be generated.</para>
		/// <para>Checked—Turn-by-turn directions will be generated on solve. This is the default.</para>
		/// <para>Unchecked—Turn-by-turn directions will not be generated on solve.</para>
		/// <para><see cref="GenerateDirectionsOnSolveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Directions")]
		public object? GenerateDirectionsOnSolve { get; set; } = "true";

		/// <summary>
		/// <para>Spatial Clustering</para>
		/// <para>Specifies whether spatial clustering will be used.</para>
		/// <para>Checked—The orders assigned to an individual route will be spatially clustered. Clustering orders tends to keep routes in smaller areas and reduce how often route lines intersect one another; yet, clustering can increase overall travel times. This is the default.</para>
		/// <para>Unchecked—The solver will not prioritize spatially clustering orders and the route lines may intersect. Use this option if route zones are specified.</para>
		/// <para><see cref="SpatialClusteringEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? SpatialClustering { get; set; } = "true";

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// <para>Specifies whether invalid input locations will be ignored.</para>
		/// <para>Checked—Invalid input locations will be ignored so that the analysis will succeed using only valid locations.</para>
		/// <para>Unchecked—Invalid locations will not be ignored and will cause the analysis to fail. This is the default.</para>
		/// <para><see cref="IgnoreInvalidLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeVehicleRoutingProblemAnalysisLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Field Units</para>
		/// </summary>
		public enum TimeUnitsEnum 
		{
			/// <summary>
			/// <para>Minutes—The time units will be minutes. This is the default.</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Seconds—The time units will be seconds.</para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Hours—The time units will be hours.</para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—The time units will be days.</para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

		}

		/// <summary>
		/// <para>Distance Field Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Miles—The distance units will be miles. This is the default.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Kilometers—The distance units will be kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The distance units will be feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The distance units will be yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Meters—The distance units will be meters.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Inches—The distance units will be inches.</para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para>Centimeters—The distance units will be centimeters.</para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para>Millimeters—The distance units will be millimeters.</para>
			/// </summary>
			[GPValue("Millimeters")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para>Decimeters—The distance units will be decimeters.</para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para>Nautical Miles—The distance units will be nautical miles.</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("Nautical Miles")]
			Nautical_Miles,

		}

		/// <summary>
		/// <para>Time Zone for Time Fields</para>
		/// </summary>
		public enum TimeZoneForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>UTC—The date-time values associated with the orders or depots will be in coordinated universal time (UTC) and are not based on the time zone in which the orders or depots are located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations— The date-time values associated with the orders or depots will be in the time zone in which the orders and depots are located. For routes, the date-time values are based on the time zone in which the starting depot for the route is located. If a route does not have a starting depot, all orders and depots across all the routes must be in a single time zone. For breaks, the date-time values are based on the time zone of the routes. This is the default.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Output Route Shape</para>
		/// </summary>
		public enum LineShapeEnum 
		{
			/// <summary>
			/// <para>No lines—No shape will be generated for the output routes.</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("No lines")]
			No_lines,

			/// <summary>
			/// <para>Straight lines—The output route shape will be a single straight line between the stops.This option is not available if the selected network data source is a service.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("Straight lines")]
			Straight_lines,

			/// <summary>
			/// <para>Along network—The output routes will have the exact shape of the underlying network sources. The output includes route measurements for linear referencing. The measurements increase from the first stop and record the cumulative impedance to reach a given position.</para>
			/// </summary>
			[GPValue("ALONG_NETWORK")]
			[Description("Along network")]
			Along_network,

		}

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// </summary>
		public enum TimeWindowFactorEnum 
		{
			/// <summary>
			/// <para>High—The solver searches for a solution that minimizes time window violations at the expense of increasing the overall travel time. Choose this setting if arriving on time at orders is more important than minimizing the overall solution cost. This may be the case if you are meeting customers at your orders and you don&apos;t want to inconvenience them with late arrivals (another option is to use rigid time windows that cannot be violated).Given other constraints of a vehicle routing problem, it may be impossible to visit all the orders within their time windows. In this case, even a High setting might produce violations.</para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—The solver searches for a balance between meeting time windows and reducing the overall solution cost. This is the default.</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—The solver searches for a solution that minimizes overall travel time, regardless of time windows. Choose this setting if respecting time windows is less important than reducing the overall solution cost. You may want to use this setting if you have a growing backlog of service requests. For the purpose of servicing more orders in a day and reducing the backlog, you can choose this setting even though customers may be inconvenienced with your fleet&apos;s late arrivals.</para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// </summary>
		public enum ExcessTransitFactorEnum 
		{
			/// <summary>
			/// <para>High—The solver searches for a solution with less excess transit time between paired orders at the expense of increasing the overall travel costs. Use this setting if you are transporting people between paired orders and you want to shorten their ride time. This is characteristic of taxi services.</para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—The solver searches for a balance between reducing excess transit time and reducing the overall solution cost. This is the default.</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—The solver searches for a solution that minimizes overall solution cost, regardless of excess transit time. This setting is commonly used with courier services. Since couriers transport packages as opposed to people, ride time is not as important. Using this setting allows couriers to service paired orders in the proper sequence and minimize the overall solution cost.</para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Generate Directions on Solve</para>
		/// </summary>
		public enum GenerateDirectionsOnSolveEnum 
		{
			/// <summary>
			/// <para>Checked—Turn-by-turn directions will be generated on solve. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DIRECTIONS")]
			DIRECTIONS,

			/// <summary>
			/// <para>Unchecked—Turn-by-turn directions will not be generated on solve.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DIRECTIONS")]
			NO_DIRECTIONS,

		}

		/// <summary>
		/// <para>Spatial Clustering</para>
		/// </summary>
		public enum SpatialClusteringEnum 
		{
			/// <summary>
			/// <para>Checked—The orders assigned to an individual route will be spatially clustered. Clustering orders tends to keep routes in smaller areas and reduce how often route lines intersect one another; yet, clustering can increase overall travel times. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLUSTER")]
			CLUSTER,

			/// <summary>
			/// <para>Unchecked—The solver will not prioritize spatially clustering orders and the route lines may intersect. Use this option if route zones are specified.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLUSTER")]
			NO_CLUSTER,

		}

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// </summary>
		public enum IgnoreInvalidLocationsEnum 
		{
			/// <summary>
			/// <para>Checked—Invalid input locations will be ignored so that the analysis will succeed using only valid locations.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para>Unchecked—Invalid locations will not be ignored and will cause the analysis to fail. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

#endregion
	}
}
