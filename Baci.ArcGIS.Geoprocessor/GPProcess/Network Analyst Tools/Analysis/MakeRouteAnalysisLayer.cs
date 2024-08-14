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
	/// <para>Make Route Analysis Layer</para>
	/// <para>Makes a route network analysis layer and sets its analysis properties. A route analysis layer is useful for determining the best route between a set of network locations based on a specified network cost. The layer can be created using a local network dataset or a routing service hosted online or in a portal.</para>
	/// </summary>
	public class MakeRouteAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </param>
		public MakeRouteAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Route Analysis Layer</para>
		/// </summary>
		public override string DisplayName => "Make Route Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeRouteAnalysisLayer</para>
		/// </summary>
		public override string ToolName => "MakeRouteAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeRouteAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName => "na.MakeRouteAnalysisLayer";

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
		public override object[] Parameters => new object[] { NetworkDataSource, LayerName!, TravelMode!, Sequence!, TimeOfDay!, TimeZone!, LineShape!, AccumulateAttributes!, GenerateDirectionsOnSolve!, OutNetworkAnalysisLayer!, TimeZoneForTimeFields!, IgnoreInvalidLocations! };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>The name of the network analysis layer to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The name of the travel mode to use in the analysis. The travel mode represents a collection of network settings, such as travel restrictions and U-turn policies, that determine how a pedestrian, car, truck, or other medium of transportation moves through the network. Travel modes are defined on your network data source.</para>
		/// <para>An arcpy.na.TravelMode object and a string containing the valid JSON representation of a travel mode can also be used as input to the parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Sequence</para>
		/// <para>Specifies whether the input stops must be visited in a particular order when calculating the optimal route. This option changes the route analysis from a shortest-path problem to a traveling salesperson problem (TSP).</para>
		/// <para>Use current order—The stops will be visited in the input order. This is the default.</para>
		/// <para>Find best order—The stops will be reordered to find the optimal route. This option changes the route analysis from a shortest-path problem to a traveling salesperson problem (TSP).</para>
		/// <para>Preserve both first and last stop—Preserve the first and last stops by input order. The rest will be reordered to find the optimal route.</para>
		/// <para>Preserve first stop—Preserve the first stop by input order. The rest will be reordered to find the optimal route.</para>
		/// <para>Preserve last stop—Preserve the last stop by input order. The rest will be reordered to find the optimal route.</para>
		/// <para><see cref="SequenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Sequence { get; set; } = "USE_CURRENT_ORDER";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The start date and time for the route. Route start time is typically used to find routes based on the impedance attribute that varies with the time of the day. For example, a start time of 7:00 a.m. could be used to find a route that considers rush hour traffic. The default value for this parameter is 8:00 a.m. A date and time can be specified as 10/21/05 10:30 AM. If the route spans multiple days and only the start time is specified, the current date is used.</para>
		/// <para>Instead of using a particular date, a day of the week can be specified using the following dates:</para>
		/// <para>Today—12/30/1899</para>
		/// <para>Sunday—12/31/1899</para>
		/// <para>Monday—1/1/1900</para>
		/// <para>Tuesday—1/2/1900</para>
		/// <para>Wednesday—1/3/1900</para>
		/// <para>Thursday—1/4/1900</para>
		/// <para>Friday—1/5/1900</para>
		/// <para>Saturday—1/6/1900</para>
		/// <para>For example, to specify that travel should begin at 5:00 p.m. on Tuesday, specify the parameter value as 1/2/1900 5:00 PM.</para>
		/// <para>After the solve, the start and end times of the route are populated in the output routes. These start and end times are also used when directions are generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone of the Time of Day parameter.</para>
		/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the first stop of a route is located. This is the default.If you are generating many routes that start in multiple times zones, the start times are staggered in coordinated universal time (UTC). For example, a Time of Day value of 10:00 a.m., 2 January, would mean a start time of 10:00 a.m. eastern standard time (3:00 p.m. UTC) for routes beginning in the eastern time zone and 10:00 a.m. central standard time (4:00 p.m. UTC) for routes beginning in the central time zone. The start times are offset by one hour in UTC.The arrival and departure times and dates recorded in the output Stops feature class will refer to the local time zone of the first stop for each route.</para>
		/// <para>UTC—The Time of Day parameter refers to coordinated universal time (UTC). Choose this option if you want to generate a route for a specific time, such as now, but aren&apos;t certain in which time zone the first stop will be located.If you are generating many routes spanning multiple times zones, the start times in UTC are simultaneous. For example, a Time of Day value of 10:00 a.m., 2 January, would mean a start time of 5:00 a.m. eastern standard time (10:00 a.m. UTC) for routes beginning in the eastern time zone and 4:00 a.m. central standard time (10:00 a.m. UTC) for routes beginning in the central time zone. Both routes would start at 10:00 a.m. UTC.The arrival and departure times and dates recorded in the output Stops feature class will refer to UTC.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>Specifies the shape type that will be used for the route features that are output by the analysis.</para>
		/// <para>Along network—The output routes will have the exact shape of the underlying network sources. The output includes route measurements for linear referencing. The measurements increase from the first stop and record the cumulative impedance to reach a given position.</para>
		/// <para>No lines—No shape will be generated for the output routes.</para>
		/// <para>Straight lines—The output route shape will be a single straight line between the stops.</para>
		/// <para>Regardless of the output shape type specified, the best route is always determined by the network impedance, never Euclidean distance. This means that only the route shapes are different, not the underlying traversal of the network.</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object? LineShape { get; set; } = "ALONG_NETWORK";

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>A list of cost attributes to be accumulated during analysis. These accumulated attributes are for reference only; the solver only uses the cost attribute used by the designated travel mode when solving the analysis.</para>
		/// <para>For each cost attribute that is accumulated, a Total_[Impedance] property is populated in the network analysis output features.</para>
		/// <para>This parameter is not available if the network data source is an ArcGIS Online service or the network data source is a service on a version of Portal for ArcGIS that does not support accumulation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object? AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Generate Directions on Solve</para>
		/// <para>Specifies whether directions will be generated when running the analysis.</para>
		/// <para>Checked—Turn-by-turn directions will be generated on solve. This is the default.</para>
		/// <para>Unchecked—Turn-by-turn directions will not be generated on solve.</para>
		/// <para>For an analysis in which generating turn-by-turn directions is not needed, leaving this option unchecked will reduce the time it takes to solve the analysis.</para>
		/// <para><see cref="GenerateDirectionsOnSolveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Directions")]
		public object? GenerateDirectionsOnSolve { get; set; } = "true";

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Time Zone for Time Fields</para>
		/// <para>Specifies the time zone that will be used to interpret the time fields included in the input tables, such as the fields used for time windows.</para>
		/// <para>Local time at locations—The dates and times in the time fields for the stop will be interpreted according to the time zone in which the stop is located. This is the default.</para>
		/// <para>UTC—The dates and times in the time fields for the stop refer to coordinated universal time (UTC).</para>
		/// <para><see cref="TimeZoneForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeZoneForTimeFields { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// <para>Specifies whether invalid input locations will be ignored. Typically, locations are invalid if they cannot be located on the network. When invalid locations are ignored, the solver will skip them and attempt to perform the analysis using the remaining locations.</para>
		/// <para>Checked—Invalid input locations will be ignored and only valid locations will be used. This is the default.</para>
		/// <para>Unchecked—All input locations will be used. Invalid locations will cause the analysis to fail.</para>
		/// <para><see cref="IgnoreInvalidLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRouteAnalysisLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sequence</para>
		/// </summary>
		public enum SequenceEnum 
		{
			/// <summary>
			/// <para>Use current order—The stops will be visited in the input order. This is the default.</para>
			/// </summary>
			[GPValue("USE_CURRENT_ORDER")]
			[Description("Use current order")]
			Use_current_order,

			/// <summary>
			/// <para>Find best order—The stops will be reordered to find the optimal route. This option changes the route analysis from a shortest-path problem to a traveling salesperson problem (TSP).</para>
			/// </summary>
			[GPValue("FIND_BEST_ORDER")]
			[Description("Find best order")]
			Find_best_order,

			/// <summary>
			/// <para>Preserve both first and last stop—Preserve the first and last stops by input order. The rest will be reordered to find the optimal route.</para>
			/// </summary>
			[GPValue("PRESERVE_BOTH")]
			[Description("Preserve both first and last stop")]
			Preserve_both_first_and_last_stop,

			/// <summary>
			/// <para>Preserve first stop—Preserve the first stop by input order. The rest will be reordered to find the optimal route.</para>
			/// </summary>
			[GPValue("PRESERVE_FIRST")]
			[Description("Preserve first stop")]
			Preserve_first_stop,

			/// <summary>
			/// <para>Preserve last stop—Preserve the last stop by input order. The rest will be reordered to find the optimal route.</para>
			/// </summary>
			[GPValue("PRESERVE_LAST")]
			[Description("Preserve last stop")]
			Preserve_last_stop,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—The Time of Day parameter refers to coordinated universal time (UTC). Choose this option if you want to generate a route for a specific time, such as now, but aren&apos;t certain in which time zone the first stop will be located.If you are generating many routes spanning multiple times zones, the start times in UTC are simultaneous. For example, a Time of Day value of 10:00 a.m., 2 January, would mean a start time of 5:00 a.m. eastern standard time (10:00 a.m. UTC) for routes beginning in the eastern time zone and 4:00 a.m. central standard time (10:00 a.m. UTC) for routes beginning in the central time zone. Both routes would start at 10:00 a.m. UTC.The arrival and departure times and dates recorded in the output Stops feature class will refer to UTC.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the first stop of a route is located. This is the default.If you are generating many routes that start in multiple times zones, the start times are staggered in coordinated universal time (UTC). For example, a Time of Day value of 10:00 a.m., 2 January, would mean a start time of 10:00 a.m. eastern standard time (3:00 p.m. UTC) for routes beginning in the eastern time zone and 10:00 a.m. central standard time (4:00 p.m. UTC) for routes beginning in the central time zone. The start times are offset by one hour in UTC.The arrival and departure times and dates recorded in the output Stops feature class will refer to the local time zone of the first stop for each route.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Line Shape</para>
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
			/// <para>Straight lines—The output route shape will be a single straight line between the stops.</para>
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
		/// <para>Time Zone for Time Fields</para>
		/// </summary>
		public enum TimeZoneForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>UTC—The dates and times in the time fields for the stop refer to coordinated universal time (UTC).</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The dates and times in the time fields for the stop will be interpreted according to the time zone in which the stop is located. This is the default.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// </summary>
		public enum IgnoreInvalidLocationsEnum 
		{
			/// <summary>
			/// <para>Checked—Invalid input locations will be ignored and only valid locations will be used. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para>Unchecked—All input locations will be used. Invalid locations will cause the analysis to fail.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

#endregion
	}
}
