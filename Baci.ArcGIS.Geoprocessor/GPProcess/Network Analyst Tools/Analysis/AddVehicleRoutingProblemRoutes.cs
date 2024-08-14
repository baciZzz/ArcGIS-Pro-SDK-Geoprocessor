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
	/// <para>Add Vehicle Routing Problem Routes</para>
	/// <para>Creates routes in a Vehicle Routing Problem (VRP) layer. This tool will append rows to the Routes sublayer and can add rows with specific settings while creating a unique name field.</para>
	/// </summary>
	public class AddVehicleRoutingProblemRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVrpLayer">
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>The  vehicle routing problem analysis layer to which routes will be added.</para>
		/// </param>
		/// <param name="NumberOfRoutes">
		/// <para>Number of Routes</para>
		/// <para>The number of routes to add.</para>
		/// </param>
		/// <param name="RouteNamePrefix">
		/// <para>Route Name Prefix</para>
		/// <para>A qualifier added to the title of every route layer item. For example, a route name prefix WeekdayRoute would be used as the starting text for every route’s name with Object ID appended to it.</para>
		/// </param>
		public AddVehicleRoutingProblemRoutes(object InVrpLayer, object NumberOfRoutes, object RouteNamePrefix)
		{
			this.InVrpLayer = InVrpLayer;
			this.NumberOfRoutes = NumberOfRoutes;
			this.RouteNamePrefix = RouteNamePrefix;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Vehicle Routing Problem Routes</para>
		/// </summary>
		public override string DisplayName => "Add Vehicle Routing Problem Routes";

		/// <summary>
		/// <para>Tool Name : AddVehicleRoutingProblemRoutes</para>
		/// </summary>
		public override string ToolName => "AddVehicleRoutingProblemRoutes";

		/// <summary>
		/// <para>Tool Excute Name : na.AddVehicleRoutingProblemRoutes</para>
		/// </summary>
		public override string ExcuteName => "na.AddVehicleRoutingProblemRoutes";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InVrpLayer, NumberOfRoutes, RouteNamePrefix, StartDepotName, EndDepotName, EarliestStartTime, LatestStartTime, MaxOrderCount, Capacities, RouteConstraints, Costs, AdditionalRouteTime, AppendToExistingRoutes, OutVrpLayer };

		/// <summary>
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>The  vehicle routing problem analysis layer to which routes will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InVrpLayer { get; set; }

		/// <summary>
		/// <para>Number of Routes</para>
		/// <para>The number of routes to add.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfRoutes { get; set; }

		/// <summary>
		/// <para>Route Name Prefix</para>
		/// <para>A qualifier added to the title of every route layer item. For example, a route name prefix WeekdayRoute would be used as the starting text for every route’s name with Object ID appended to it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteNamePrefix { get; set; } = "Route";

		/// <summary>
		/// <para>Start Depot Name</para>
		/// <para>The name of the starting depot for the route. If the Start Depot Name value is null, the route will begin from the first order assigned. Omitting the start depot is useful when the vehicle's starting location is unknown or irrelevant to your problem. However, when the Start Depot Name value is null, the End Depot Name value cannot also be null. Virtual start depots are not allowed if orders or depots are in multiple time zones.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object StartDepotName { get; set; }

		/// <summary>
		/// <para>End Depot Name</para>
		/// <para>The name of the ending depot for the route. If the End Depot Name value is null, the route will end at the last order assigned. When the End Depot Name value is null, the Start Depot Name value cannot also be null.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object EndDepotName { get; set; }

		/// <summary>
		/// <para>Earliest Start Time</para>
		/// <para>The earliest allowable start time for the route.</para>
		/// <para>This parameter is used by the solver in conjunction with the time window of the starting depot, provided in the Depots layer by the TimeWindowStart field, for determining feasible route start times. This parameter has a default time-only value of 8:00:00 a.m., interpreted as 8:00:00 a.m. on the date given by the Default Date property of the analysis layer. If no value is specified, the default value is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object EarliestStartTime { get; set; } = "8:00:00 AM";

		/// <summary>
		/// <para>Latest Start Time</para>
		/// <para>The latest allowable start time for the route. This parameter has a default time-only value of 10:00:00 a.m., interpreted as 10:00:00 a.m. on the date provided by the Default Date property of the analysis layer. If no value is specified, the default value is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object LatestStartTime { get; set; } = "10:00:00 AM";

		/// <summary>
		/// <para>Max Order Count</para>
		/// <para>The maximum allowable number of orders on the route. The default value is 30. If no value is specified, the default value is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxOrderCount { get; set; } = "30";

		/// <summary>
		/// <para>Capacities</para>
		/// <para>The maximum amount (volume, weight, quantity, and so on) that can be carried by the vehicle. A null value is the same as zero. A maximum of nine capacity fields are allowed, but use only the number necessary to model the needs of the vehicles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Capacities { get; set; }

		/// <summary>
		/// <para>Route Constraints</para>
		/// <para>The constraints placed on routes to limit total time, total travel time, and total distance.</para>
		/// <para>Max Total Time—The maximum allowable route duration. The route duration includes travel times as well as service and wait times at orders, depots, and breaks.</para>
		/// <para>Max Total Travel Time—The maximum allowable travel time for the route. The travel time includes only the time spent driving on the network and does not include service or wait times. This field value can&apos;t be larger than the MaxTotalTime  field value.</para>
		/// <para>Max Total Distance—The maximum allowable travel distance for the route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object RouteConstraints { get; set; }

		/// <summary>
		/// <para>Costs</para>
		/// <para>The costs incurred by the route in a VRP solution.</para>
		/// <para>Fixed Cost—A fixed monetary cost that is incurred only if the route is used in a solution (that is, it has orders assigned to it).</para>
		/// <para>Cost Per Unit Time—The monetary cost incurred per unit of work time for the total route duration, including travel times and service and wait times at orders, depots, and breaks.</para>
		/// <para>Cost Per Unit Distance—The monetary cost incurred per unit of distance traveled for the route length (total travel distance).</para>
		/// <para>Overtime Start Time—The duration of regular work time before overtime computation begins.</para>
		/// <para>Cost Per Unit Overtime—The monetary cost incurred per time unit of overtime work. This field can contain null values; a null value indicates that the Cost Per Unit Overtime value is the same as the Cost Per Unit Time value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Costs { get; set; }

		/// <summary>
		/// <para>Additional Route Time</para>
		/// <para>Additional route time options.</para>
		/// <para>Start Depot Service Time—The service time at the starting depot. This can be used to model the time spent loading the vehicle.</para>
		/// <para>End Depot Service Time—The service time at the ending depot. This can be used to model the time spent unloading the vehicle.</para>
		/// <para>Arrive/Depart Delay—The amount of travel time needed to accelerate the vehicle to normal travel speeds, decelerate it to a stop, and move it off and on the network (for example, in and out of parking). By including an Arrive/Depart Delay value, the VRP solver is deterred from sending many routes to service physically coincident orders.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object AdditionalRouteTime { get; set; }

		/// <summary>
		/// <para>Append To Existing Routes</para>
		/// <para>Specifies whether new routes will be appended to the existing routes attribute table.</para>
		/// <para>Checked—New routes will be appended to the existing set in the routes attribute table. This is the default.</para>
		/// <para>Unchecked—Existing routes will be deleted and replaced with new routes.</para>
		/// <para><see cref="AppendToExistingRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToExistingRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Output Vehicle Routing Problem Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutVrpLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Append To Existing Routes</para>
		/// </summary>
		public enum AppendToExistingRoutesEnum 
		{
			/// <summary>
			/// <para>Checked—New routes will be appended to the existing set in the routes attribute table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—Existing routes will be deleted and replaced with new routes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CLEAR")]
			CLEAR,

		}

#endregion
	}
}
