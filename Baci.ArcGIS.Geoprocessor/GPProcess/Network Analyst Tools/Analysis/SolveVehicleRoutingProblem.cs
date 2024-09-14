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
	/// <para>Solve Vehicle Routing Problem</para>
	/// <para>Solve Vehicle Routing Problem</para>
	/// <para>Creates a vehicle routing problem (VRP) network analysis layer, sets the analysis properties, and solves the analysis, which is ideal for setting up a VRP web service. A VRP analysis layer finds the best routes for a fleet of vehicles.</para>
	/// </summary>
	[Obsolete()]
	public class SolveVehicleRoutingProblem : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Orders">
		/// <para>Orders</para>
		/// <para>In the case of an exchange visit, an order can have both delivery and pickup quantities.</para>
		/// </param>
		/// <param name="Depots">
		/// <para>Depots</para>
		/// <para>A depot is a location that a vehicle departs from at the beginning of the workday and returns to at the end of the workday. Vehicles are loaded (for deliveries) or unloaded (for pickups) at depots at the start of the route. In some cases, a depot can also act as a renewal location, whereby the vehicle can unload or reload and continue performing deliveries and pickups. A depot has open and close times, as specified by a hard time window. Vehicles can&apos;t arrive at a depot outside of this time window.</para>
		/// <para>The depots feature set has an associated attribute table. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Shape:</para>
		/// <para>The geometry field indicating the geographic location of the network analysis object.</para>
		/// <para>Name:</para>
		/// <para>The name of the depot. The StartDepotName and EndDepotName fields of the routes record set reference the names you specify here. It is also referenced by the route renewals record set, when used.</para>
		/// <para>Depot names are not case sensitive and must be nonempty and unique.</para>
		/// <para>TimeWindowStart1:</para>
		/// <para>The beginning time of the first time window for the network location. This field can contain a null value; a null value indicates no beginning time.</para>
		/// <para>Time window fields can contain a time-only value or a date and time value. If a time field has a time-only value (for example, 8:00 a.m.), the date is assumed to be the date specified by the Default Date parameter of the analysis layer. Using date and time values (for example, 7/11/2010 8:00 a.m.) allows you to set time windows that span multiple days.</para>
		/// <para>The default date is ignored when any time window field includes a date with the time. To avoid an error in this situation, format all time windows in Depots, Routes, Orders, and Breaks to also include the date with the time.</para>
		/// <para>If you&apos;re using traffic data, the time-of-day fields for the network location always reference the same time zone as the edge on which the network location is located.</para>
		/// <para>TimeWindowEnd1:</para>
		/// <para>The ending time of the first time window for the network location. This field can contain a null value; a null value indicates no ending time.</para>
		/// <para>TimeWindowStart2:</para>
		/// <para>The beginning time of the second time window for the network location. This field can contain a null value; a null value indicates that there is no second time window.</para>
		/// <para>If the first time window is null as specified by the TimeWindowStart1 and TimeWindowEnd1 fields, the second time window must also be null.</para>
		/// <para>If both time windows are nonnull, they can&apos;t overlap. Also, the second time window must occur after the first.</para>
		/// <para>TimeWindowEnd2:</para>
		/// <para>The ending time of the second time window for the network location. This field can contain a null value.</para>
		/// <para>When TimeWindowStart2 and TimeWindowEnd2 are both null, there is no second time window.</para>
		/// <para>When TimeWindowStart2 is not null but TimeWindowEnd2 is null, there is a second time window that has a starting time but no ending time. This is valid.</para>
		/// <para>CurbApproach:</para>
		/// <para>The CurbApproach property specifies the direction a vehicle may arrive at and depart from the network location. There are four choices (their coded values are shown in parentheses):</para>
		/// <para>Either side of vehicle (0)—The vehicle can approach and depart the network location in either direction. U-turns are allowed. You should choose this setting if your vehicle can make a U-turn at the stop or if it can pull into a driveway or parking lot and turn around.</para>
		/// <para>Right side of vehicle (1)—When the vehicle approaches and departs the network location, the curb must be on the right side of the vehicle. A U-turn is prohibited.</para>
		/// <para>Left side of vehicle (2)—When the vehicle approaches and departs the network location, the curb must be on the left side of the vehicle. A U-turn is prohibited.</para>
		/// <para>No U-Turn (3)—When the vehicle approaches the network location, the curb can be on either side of the vehicle; however, the vehicle must depart without turning around.</para>
		/// <para>Bearing:</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured in a clockwise fashion from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device that is equipped with a GPS receiver. Try to include bearing data if you are loading an order that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps Network Analyst determine which side of the street the point is on.</para>
		/// <para>For more information, see Bearing and BearingTol.</para>
		/// <para>BearingTol:</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the value from the Bearing field is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than zero and less than 180.</para>
		/// <para>A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15º to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>For more information, see Bearing and BearingTol.</para>
		/// <para>NavLatency:</para>
		/// <para>This field is only used in the solve process if Bearing and BearingTol also have values; however, entering a NavLatency value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much time is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device. The time units of NavLatency are the same as the units of the cost attribute specified by the Time Attribute parameter.</para>
		/// </param>
		/// <param name="Routes">
		/// <para>Routes</para>
		/// <para>The routes that are available for the given vehicle routing problem. A route specifies vehicle and driver characteristics; after solving, it also represents the path between depots and orders.</para>
		/// <para>A route can have start and end depot service times, a fixed or flexible starting time, time-based operating costs, distance-based operating costs, multiple capacities, various constraints on a driver&apos;s workday, and so on.</para>
		/// <para>The routes record set has several attributes. The fields in the attribute table are listed and described below.</para>
		/// <para>Name:</para>
		/// <para>The name of the route. The name must be unique.</para>
		/// <para>Network Analyst generates a unique name at solve time if the field value is null. Therefore, entering a value is optional in most cases. However, you must enter a name if your analysis includes breaks, route renewals, route zones, or orders that are preassigned to a route, because the route name is used as a foreign key in these cases. Note that route names are not case sensitive.</para>
		/// <para>StartDepotName:</para>
		/// <para>The name of the starting depot for the route. This field is a foreign key to the Name field in Depots.</para>
		/// <para>If the StartDepotName value is null, the route will begin from the first order assigned. Omitting the start depot is useful when the vehicle&apos;s starting location is unknown or irrelevant to your problem. However, when StartDepotName is null, EndDepotName cannot also be null.</para>
		/// <para>Virtual start depots are not allowed if orders or depots are in multiple time zones.</para>
		/// <para>If the route is making deliveries and StartDepotName is null, it is assumed the cargo is loaded on the vehicle at a virtual depot before the route begins. For a route that has no renewal visits, its delivery orders (those with nonzero DeliveryQuantities values in the Orders class) are loaded at the start depot or virtual depot. For a route that has renewal visits, only the delivery orders before the first renewal visit are loaded at the start depot or virtual depot.</para>
		/// <para>EndDepotName:</para>
		/// <para>The name of the ending depot for the route. This field is a foreign key to the Name field in the Depots parameter.</para>
		/// <para>StartDepotServiceTime:</para>
		/// <para>The service time at the starting depot. This can be used to model the time spent for loading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. As such, the depot service times could be given values corresponding to a full truckload or an average truckload, or you could make your own time estimate.</para>
		/// <para>EndDepotServiceTime:</para>
		/// <para>The service time at the ending depot. This can be used to model the time spent for unloading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. As such, the depot service times could be given values corresponding to a full truckload or an average truckload, or you could make your own time estimate.</para>
		/// <para>EarliestStartTime:</para>
		/// <para>The earliest allowable starting time for the route. This is used by the solver in conjunction with the time window of the starting depot for determining feasible route start times.</para>
		/// <para>This field can&apos;t contain null values and has a default time-only value of 8:00 a.m.; the default value is interpreted as 8:00 a.m. on the date given by the Default Date parameter (default_date in Python).</para>
		/// <para>The default date is ignored when any time window field includes a date with the time. To avoid an error in this situation, format all time windows in Depots, Routes, Orders, and Breaks to also include the date with the time.</para>
		/// <para>When using network datasets with traffic data across multiple time zones, the time zone for EarliestStartTime is the same as the time zone of the edge or junction on which the starting depot is located.</para>
		/// <para>LatestStartTime:</para>
		/// <para>The latest allowable starting time for the route. This field can&apos;t contain null values and has a default time-only value of 10:00 a.m; the default value is interpreted as 10:00 a.m. on the date given by the Default Date property of the analysis layer.</para>
		/// <para>When using network datasets with traffic data across multiple time zones, the time zone for LatestStartTime is the same as the time zone of the edge or junction on which the starting depot is located.</para>
		/// <para>ArriveDepartDelay</para>
		/// <para>This field stores the amount of travel time needed to accelerate the vehicle to normal travel speeds, decelerate it to a stop, and move it off and on the network (for example, in and out of parking). By including an ArriveDepartDelay value, the VRP solver is deterred from sending many routes to service physically coincident orders.</para>
		/// <para>The cost for this property is incurred between visits to noncoincident orders, depots, and route renewals. For example, when a route starts from a depot and visits the first order, the total arrive/depart delay is added to the travel time. The same is true when traveling from the first order to the second order. If the second and third orders are coincident, the ArriveDepartDelay value is not added between them since the vehicle doesn&apos;t need to move. If the route travels to a route renewal, the value is added to the travel time again.</para>
		/// <para>Although a vehicle needs to slow down and stop for a break and accelerate afterward, the VRP solver cannot add the ArriveDepartDelay value for breaks. This means that if a route leaves an order, stops for a break, and continues to the next order, the arrive/depart delay is added only once, not twice.</para>
		/// <para>To illustrate, assume there are five coincident orders in a high-rise building, and they are serviced by three different routes. This means three arrive/depart delays would be incurred; that is, three drivers would need to separately find parking places and enter the same building. However, if the orders could be serviced by just one route instead, only one driver would need to park and enter the building—only one arrive/depart delay would be incurred. Since the VRP solver tries to minimize cost, it will try to limit the arrive/depart delays and thus choose the single-route option. (Note that multiple routes may need to be sent when other constraints—such as specialties, time windows, or capacities—require it.)</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>Capacities:</para>
		/// <para>The maximum capacity of the vehicle. You can specify capacity in any dimension, such as weight, volume, or quantity. You can even specify multiple dimensions, for example, weight and volume.</para>
		/// <para>Enter capacities without indicating units. For example, assume your vehicle can carry a maximum of 40,000 pounds; you would enter 40000. You need to remember for future reference that the value is in pounds.</para>
		/// <para>If you are tracking multiple dimensions, separate the numeric values with a space. For instance, if you are recording both weight and volume and your vehicle can carry a maximum weight of 40,000 pounds and a maximum volume of 2,000 cubic feet, Capacities should be entered as 40000 2000. Again, you need to remember the units. You also need to remember the sequence the values and their corresponding units are entered (pounds followed by cubic feet in this case).</para>
		/// <para>Remembering the units and the unit sequence is important for a couple of reasons: one, so you can reinterpret the information later; two, so you can properly enter values for the DeliveryQuantities and PickupQuantities fields for Orders. To elaborate on the second point, note that the VRP solver simultaneously refers to Capacities, DeliveryQuantities, and PickupQuantities to make sure that a route doesn&apos;t become overloaded. Since units can&apos;t be entered in the field, Network Analyst can&apos;t make unit conversions, so you need to enter the values for the three fields using the same units and the same unit sequence to ensure that the values are correctly interpreted. If you combine units or change the sequence in any of the three fields, you will get unwanted results without receiving a warning messages. Thus, it is a good idea to set up a unit and unit-sequence standard beforehand and continually refer to it whenever entering values for these three fields.</para>
		/// <para>An empty string or null value is equivalent to all values being zero. Capacity values can&apos;t be negative.</para>
		/// <para>If the Capacities string has an insufficient number of values in relation to the DeliveryQuantities or PickupQuantities field for orders, the remaining values are treated as zero.</para>
		/// <para>The VRP solver only performs a simple Boolean test to determine whether capacities are exceeded. If a route&apos;s capacity value is greater than or equal to the total quantity being carried, the VRP solver will assume the cargo fits in the vehicle. This could be incorrect, depending on the actual shape of the cargo and the vehicle. For example, the VRP solver allows you to fit a 1,000-cubic-foot sphere into a 1,000-cubic-foot truck that is 8 feet wide. In reality, however, since the sphere is 12.6 feet in diameter, it won&apos;t fit in the 8-foot-wide truck.</para>
		/// <para>FixedCost:</para>
		/// <para>A fixed monetary cost that is incurred only if the route is used in a solution (that is, it has orders assigned to it). This field can contain null values; a null value indicates zero fixed cost. This cost is part of the total route operating cost.</para>
		/// <para>CostPerUnitTime:</para>
		/// <para>The monetary cost incurred—per unit of work time—for the total route duration, including travel times as well as service times and wait times at orders, depots, and breaks. This field can&apos;t contain a null value and has a default value of 1.0.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>CostPerUnitDistance:</para>
		/// <para>The monetary cost incurred—per unit of distance traveled—for the route length (total travel distance). This field can contain null values; a null value indicates zero cost.</para>
		/// <para>The unit for this field value is specified by the Distance Field Units parameter (distance_units for Python).</para>
		/// <para>OvertimeStartTime:</para>
		/// <para>The duration of regular work time before overtime computation begins. This field can contain null values; a null value indicates that overtime does not apply.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>For example, if the driver is to be paid overtime when the total route duration extends beyond eight hours, OvertimeStartTime is specified as 480 (8 hours * 60 minutes/hour), given the Time Field Units parameter is set to Minutes.</para>
		/// <para>CostPerUnitOvertime:</para>
		/// <para>The monetary cost incurred per time unit of overtime work. This can only contain a null value if OvertimeStartTime is also null. Otherwise it must be a positive value greater than the CostPerUnitTime.</para>
		/// <para>MaxOrderCount:</para>
		/// <para>The maximum allowable number of orders on the route. This field can&apos;t contain null values and has a default value of 30.</para>
		/// <para>MaxTotalTime:</para>
		/// <para>The maximum allowable route duration. The route duration includes travel times as well as service and wait times at orders, depots, and breaks. This field can contain null values; a null value indicates that there is no constraint on the route duration.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>MaxTotalTravelTime:</para>
		/// <para>The maximum allowable travel time for the route. The travel time includes only the time spent driving on the network and does not include service or wait times.</para>
		/// <para>This field can contain null values; a null value indicates there is no constraint on the maximum allowable travel time. This field value can&apos;t be larger than the MaxTotalTime field value.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>MaxTotalDistance:</para>
		/// <para>The maximum allowable travel distance for the route.</para>
		/// <para>The unit for this field value is specified by the Distance Field Units parameter (distance_units for Python).</para>
		/// <para>This field can contain null values; a null value indicates that there is no constraint on the maximum allowable travel distance.</para>
		/// <para>SpecialtyNames:</para>
		/// <para>A space-separated string containing the names of the specialties supported by the route. A null value indicates that the route does not support any specialties.</para>
		/// <para>This field is a foreign key to the SpecialtyNames field in the Orders parameter.</para>
		/// <para>To illustrate what specialties are and how they work, assume a lawn care and tree trimming company has a portion of its orders that requires a bucket truck to trim tall trees. The company would enter BucketTruck in the SpecialtyNames field for these orders to indicate their special need. SpecialtyNames would be left as null for the other orders. Similarly, the company would also enter BucketTruck in the SpecialtyNames field of routes that are driven by trucks with hydraulic booms. It would leave the field null for the other routes. At solve time, the VRP solver assigns orders without special needs to any route, but it only assigns orders that need bucket trucks to routes that have them.</para>
		/// <para>AssignmentRule:</para>
		/// <para>This specifies whether or not the route can be used when solving the problem. This field is constrained by a domain of values, and the possible values are the following:</para>
		/// <para>Include—The route is included in the solve operation. This is the default value.</para>
		/// <para>Exclude—The route is excluded from the solve operation.</para>
		/// </param>
		/// <param name="TimeUnits">
		/// <para>Time Field Units</para>
		/// <para>Specifies the time units for all time-based field values in the analysis.</para>
		/// <para>Seconds—Seconds</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Hours—Hours</para>
		/// <para>Days—Days</para>
		/// <para>Many features and records in a VRP analysis have fields for storing time values, such as ServiceTime for orders and CostPerUnitTime for routes. To minimize data entry requirements, these field values don&apos;t include units. Instead, all distance-based field values must be entered in the same units, and this parameter is used to specify the units of those values.</para>
		/// <para>Note that output time-based fields use the same units specified by this parameter.</para>
		/// <para>This time unit doesn&apos;t need to match the time unit of the network Time Attribute parameter (time_attribute in Python).</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Field Units</para>
		/// <para>Specifies the distance units for all distance-based field values in the analysis.</para>
		/// <para>Miles—Miles</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Meters—Meters</para>
		/// <para>Nautical Miles—Nautical miles</para>
		/// <para>Many features and records in a VRP analysis have fields for storing distance values, such as MaxTotalDistance and CostPerUnitDistance for routes. To minimize data entry requirements, these field values don&apos;t include units. Instead, all distance-based field values must be entered in the same units, and this parameter is used to specify the units of those values.</para>
		/// <para>Note that output distance-based fields use the same units specified by this parameter.</para>
		/// <para>This distance unit doesn&apos;t need to match the distance unit of the network Distance Attribute (distance attribute in Python).</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		/// <param name="NetworkDataset">
		/// <para>Network Dataset</para>
		/// <para>The network dataset on which the vehicle routing problem analysis will be performed. The network dataset must have a time-based cost attribute, since the VRP solver minimizes time.</para>
		/// </param>
		/// <param name="OutputWorkspaceLocation">
		/// <para>Output Geodatabase Workspace</para>
		/// <para>The file geodatabase or in-memory workspace in which the output feature classes will be created. This workspace must already exist. The default output workspace is in memory.</para>
		/// </param>
		/// <param name="OutputUnassignedStopsName">
		/// <para>Output Unassigned Stops Name</para>
		/// <para>The name of the output feature class that will contain any unreachable depots or unassigned orders.</para>
		/// </param>
		/// <param name="OutputStopsName">
		/// <para>Output Stops Name</para>
		/// <para>The name of the feature class that will contain the stops visited by routes. This feature class includes stops at depots, orders, and breaks.</para>
		/// </param>
		/// <param name="OutputRoutesName">
		/// <para>Output Routes Name</para>
		/// <para>The name of the feature class that will contain the routes of the analysis.</para>
		/// </param>
		/// <param name="OutputDirectionsName">
		/// <para>Output Directions Name</para>
		/// <para>The name of the feature class that will contain the directions for the routes.</para>
		/// </param>
		public SolveVehicleRoutingProblem(object Orders, object Depots, object Routes, object TimeUnits, object DistanceUnits, object NetworkDataset, object OutputWorkspaceLocation, object OutputUnassignedStopsName, object OutputStopsName, object OutputRoutesName, object OutputDirectionsName)
		{
			this.Orders = Orders;
			this.Depots = Depots;
			this.Routes = Routes;
			this.TimeUnits = TimeUnits;
			this.DistanceUnits = DistanceUnits;
			this.NetworkDataset = NetworkDataset;
			this.OutputWorkspaceLocation = OutputWorkspaceLocation;
			this.OutputUnassignedStopsName = OutputUnassignedStopsName;
			this.OutputStopsName = OutputStopsName;
			this.OutputRoutesName = OutputRoutesName;
			this.OutputDirectionsName = OutputDirectionsName;
		}

		/// <summary>
		/// <para>Tool Display Name : Solve Vehicle Routing Problem</para>
		/// </summary>
		public override string DisplayName() => "Solve Vehicle Routing Problem";

		/// <summary>
		/// <para>Tool Name : SolveVehicleRoutingProblem</para>
		/// </summary>
		public override string ToolName() => "SolveVehicleRoutingProblem";

		/// <summary>
		/// <para>Tool Excute Name : na.SolveVehicleRoutingProblem</para>
		/// </summary>
		public override string ExcuteName() => "na.SolveVehicleRoutingProblem";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Orders, Depots, Routes, Breaks!, TimeUnits, DistanceUnits, NetworkDataset, OutputWorkspaceLocation, OutputUnassignedStopsName, OutputStopsName, OutputRoutesName, OutputDirectionsName, DefaultDate!, UturnPolicy!, TimeWindowFactor!, SpatiallyClusterRoutes!, RouteZones!, RouteRenewals!, OrderPairs!, ExcessTransitFactor!, PointBarriers!, LineBarriers!, PolygonBarriers!, TimeAttribute!, DistanceAttribute!, UseHierarchyInAnalysis!, Restrictions!, AttributeParameterValues!, MaximumSnapTolerance!, ExcludeRestrictedPortionsOfTheNetwork!, FeatureLocatorWhereClause!, PopulateRouteLines!, RouteLineSimplificationTolerance!, PopulateDirections!, DirectionsLanguage!, DirectionsStyleName!, SaveOutputLayer!, ServiceCapabilities!, IgnoreInvalidOrderLocations!, TravelMode!, SolveSucceeded!, OutUnassignedStops!, OutStops!, OutRoutes!, OutDirections!, OutNetworkAnalysisLayer!, IgnoreNetworkLocationFields!, TimeZoneUsageForTimeFields!, Overrides!, SaveRouteData!, OutRouteData! };

		/// <summary>
		/// <para>Orders</para>
		/// <para>In the case of an exchange visit, an order can have both delivery and pickup quantities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Orders { get; set; }

		/// <summary>
		/// <para>Depots</para>
		/// <para>A depot is a location that a vehicle departs from at the beginning of the workday and returns to at the end of the workday. Vehicles are loaded (for deliveries) or unloaded (for pickups) at depots at the start of the route. In some cases, a depot can also act as a renewal location, whereby the vehicle can unload or reload and continue performing deliveries and pickups. A depot has open and close times, as specified by a hard time window. Vehicles can&apos;t arrive at a depot outside of this time window.</para>
		/// <para>The depots feature set has an associated attribute table. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Shape:</para>
		/// <para>The geometry field indicating the geographic location of the network analysis object.</para>
		/// <para>Name:</para>
		/// <para>The name of the depot. The StartDepotName and EndDepotName fields of the routes record set reference the names you specify here. It is also referenced by the route renewals record set, when used.</para>
		/// <para>Depot names are not case sensitive and must be nonempty and unique.</para>
		/// <para>TimeWindowStart1:</para>
		/// <para>The beginning time of the first time window for the network location. This field can contain a null value; a null value indicates no beginning time.</para>
		/// <para>Time window fields can contain a time-only value or a date and time value. If a time field has a time-only value (for example, 8:00 a.m.), the date is assumed to be the date specified by the Default Date parameter of the analysis layer. Using date and time values (for example, 7/11/2010 8:00 a.m.) allows you to set time windows that span multiple days.</para>
		/// <para>The default date is ignored when any time window field includes a date with the time. To avoid an error in this situation, format all time windows in Depots, Routes, Orders, and Breaks to also include the date with the time.</para>
		/// <para>If you&apos;re using traffic data, the time-of-day fields for the network location always reference the same time zone as the edge on which the network location is located.</para>
		/// <para>TimeWindowEnd1:</para>
		/// <para>The ending time of the first time window for the network location. This field can contain a null value; a null value indicates no ending time.</para>
		/// <para>TimeWindowStart2:</para>
		/// <para>The beginning time of the second time window for the network location. This field can contain a null value; a null value indicates that there is no second time window.</para>
		/// <para>If the first time window is null as specified by the TimeWindowStart1 and TimeWindowEnd1 fields, the second time window must also be null.</para>
		/// <para>If both time windows are nonnull, they can&apos;t overlap. Also, the second time window must occur after the first.</para>
		/// <para>TimeWindowEnd2:</para>
		/// <para>The ending time of the second time window for the network location. This field can contain a null value.</para>
		/// <para>When TimeWindowStart2 and TimeWindowEnd2 are both null, there is no second time window.</para>
		/// <para>When TimeWindowStart2 is not null but TimeWindowEnd2 is null, there is a second time window that has a starting time but no ending time. This is valid.</para>
		/// <para>CurbApproach:</para>
		/// <para>The CurbApproach property specifies the direction a vehicle may arrive at and depart from the network location. There are four choices (their coded values are shown in parentheses):</para>
		/// <para>Either side of vehicle (0)—The vehicle can approach and depart the network location in either direction. U-turns are allowed. You should choose this setting if your vehicle can make a U-turn at the stop or if it can pull into a driveway or parking lot and turn around.</para>
		/// <para>Right side of vehicle (1)—When the vehicle approaches and departs the network location, the curb must be on the right side of the vehicle. A U-turn is prohibited.</para>
		/// <para>Left side of vehicle (2)—When the vehicle approaches and departs the network location, the curb must be on the left side of the vehicle. A U-turn is prohibited.</para>
		/// <para>No U-Turn (3)—When the vehicle approaches the network location, the curb can be on either side of the vehicle; however, the vehicle must depart without turning around.</para>
		/// <para>Bearing:</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured in a clockwise fashion from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device that is equipped with a GPS receiver. Try to include bearing data if you are loading an order that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps Network Analyst determine which side of the street the point is on.</para>
		/// <para>For more information, see Bearing and BearingTol.</para>
		/// <para>BearingTol:</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the value from the Bearing field is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than zero and less than 180.</para>
		/// <para>A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15º to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>For more information, see Bearing and BearingTol.</para>
		/// <para>NavLatency:</para>
		/// <para>This field is only used in the solve process if Bearing and BearingTol also have values; however, entering a NavLatency value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much time is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device. The time units of NavLatency are the same as the units of the cost attribute specified by the Time Attribute parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Depots { get; set; }

		/// <summary>
		/// <para>Routes</para>
		/// <para>The routes that are available for the given vehicle routing problem. A route specifies vehicle and driver characteristics; after solving, it also represents the path between depots and orders.</para>
		/// <para>A route can have start and end depot service times, a fixed or flexible starting time, time-based operating costs, distance-based operating costs, multiple capacities, various constraints on a driver&apos;s workday, and so on.</para>
		/// <para>The routes record set has several attributes. The fields in the attribute table are listed and described below.</para>
		/// <para>Name:</para>
		/// <para>The name of the route. The name must be unique.</para>
		/// <para>Network Analyst generates a unique name at solve time if the field value is null. Therefore, entering a value is optional in most cases. However, you must enter a name if your analysis includes breaks, route renewals, route zones, or orders that are preassigned to a route, because the route name is used as a foreign key in these cases. Note that route names are not case sensitive.</para>
		/// <para>StartDepotName:</para>
		/// <para>The name of the starting depot for the route. This field is a foreign key to the Name field in Depots.</para>
		/// <para>If the StartDepotName value is null, the route will begin from the first order assigned. Omitting the start depot is useful when the vehicle&apos;s starting location is unknown or irrelevant to your problem. However, when StartDepotName is null, EndDepotName cannot also be null.</para>
		/// <para>Virtual start depots are not allowed if orders or depots are in multiple time zones.</para>
		/// <para>If the route is making deliveries and StartDepotName is null, it is assumed the cargo is loaded on the vehicle at a virtual depot before the route begins. For a route that has no renewal visits, its delivery orders (those with nonzero DeliveryQuantities values in the Orders class) are loaded at the start depot or virtual depot. For a route that has renewal visits, only the delivery orders before the first renewal visit are loaded at the start depot or virtual depot.</para>
		/// <para>EndDepotName:</para>
		/// <para>The name of the ending depot for the route. This field is a foreign key to the Name field in the Depots parameter.</para>
		/// <para>StartDepotServiceTime:</para>
		/// <para>The service time at the starting depot. This can be used to model the time spent for loading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. As such, the depot service times could be given values corresponding to a full truckload or an average truckload, or you could make your own time estimate.</para>
		/// <para>EndDepotServiceTime:</para>
		/// <para>The service time at the ending depot. This can be used to model the time spent for unloading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. As such, the depot service times could be given values corresponding to a full truckload or an average truckload, or you could make your own time estimate.</para>
		/// <para>EarliestStartTime:</para>
		/// <para>The earliest allowable starting time for the route. This is used by the solver in conjunction with the time window of the starting depot for determining feasible route start times.</para>
		/// <para>This field can&apos;t contain null values and has a default time-only value of 8:00 a.m.; the default value is interpreted as 8:00 a.m. on the date given by the Default Date parameter (default_date in Python).</para>
		/// <para>The default date is ignored when any time window field includes a date with the time. To avoid an error in this situation, format all time windows in Depots, Routes, Orders, and Breaks to also include the date with the time.</para>
		/// <para>When using network datasets with traffic data across multiple time zones, the time zone for EarliestStartTime is the same as the time zone of the edge or junction on which the starting depot is located.</para>
		/// <para>LatestStartTime:</para>
		/// <para>The latest allowable starting time for the route. This field can&apos;t contain null values and has a default time-only value of 10:00 a.m; the default value is interpreted as 10:00 a.m. on the date given by the Default Date property of the analysis layer.</para>
		/// <para>When using network datasets with traffic data across multiple time zones, the time zone for LatestStartTime is the same as the time zone of the edge or junction on which the starting depot is located.</para>
		/// <para>ArriveDepartDelay</para>
		/// <para>This field stores the amount of travel time needed to accelerate the vehicle to normal travel speeds, decelerate it to a stop, and move it off and on the network (for example, in and out of parking). By including an ArriveDepartDelay value, the VRP solver is deterred from sending many routes to service physically coincident orders.</para>
		/// <para>The cost for this property is incurred between visits to noncoincident orders, depots, and route renewals. For example, when a route starts from a depot and visits the first order, the total arrive/depart delay is added to the travel time. The same is true when traveling from the first order to the second order. If the second and third orders are coincident, the ArriveDepartDelay value is not added between them since the vehicle doesn&apos;t need to move. If the route travels to a route renewal, the value is added to the travel time again.</para>
		/// <para>Although a vehicle needs to slow down and stop for a break and accelerate afterward, the VRP solver cannot add the ArriveDepartDelay value for breaks. This means that if a route leaves an order, stops for a break, and continues to the next order, the arrive/depart delay is added only once, not twice.</para>
		/// <para>To illustrate, assume there are five coincident orders in a high-rise building, and they are serviced by three different routes. This means three arrive/depart delays would be incurred; that is, three drivers would need to separately find parking places and enter the same building. However, if the orders could be serviced by just one route instead, only one driver would need to park and enter the building—only one arrive/depart delay would be incurred. Since the VRP solver tries to minimize cost, it will try to limit the arrive/depart delays and thus choose the single-route option. (Note that multiple routes may need to be sent when other constraints—such as specialties, time windows, or capacities—require it.)</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>Capacities:</para>
		/// <para>The maximum capacity of the vehicle. You can specify capacity in any dimension, such as weight, volume, or quantity. You can even specify multiple dimensions, for example, weight and volume.</para>
		/// <para>Enter capacities without indicating units. For example, assume your vehicle can carry a maximum of 40,000 pounds; you would enter 40000. You need to remember for future reference that the value is in pounds.</para>
		/// <para>If you are tracking multiple dimensions, separate the numeric values with a space. For instance, if you are recording both weight and volume and your vehicle can carry a maximum weight of 40,000 pounds and a maximum volume of 2,000 cubic feet, Capacities should be entered as 40000 2000. Again, you need to remember the units. You also need to remember the sequence the values and their corresponding units are entered (pounds followed by cubic feet in this case).</para>
		/// <para>Remembering the units and the unit sequence is important for a couple of reasons: one, so you can reinterpret the information later; two, so you can properly enter values for the DeliveryQuantities and PickupQuantities fields for Orders. To elaborate on the second point, note that the VRP solver simultaneously refers to Capacities, DeliveryQuantities, and PickupQuantities to make sure that a route doesn&apos;t become overloaded. Since units can&apos;t be entered in the field, Network Analyst can&apos;t make unit conversions, so you need to enter the values for the three fields using the same units and the same unit sequence to ensure that the values are correctly interpreted. If you combine units or change the sequence in any of the three fields, you will get unwanted results without receiving a warning messages. Thus, it is a good idea to set up a unit and unit-sequence standard beforehand and continually refer to it whenever entering values for these three fields.</para>
		/// <para>An empty string or null value is equivalent to all values being zero. Capacity values can&apos;t be negative.</para>
		/// <para>If the Capacities string has an insufficient number of values in relation to the DeliveryQuantities or PickupQuantities field for orders, the remaining values are treated as zero.</para>
		/// <para>The VRP solver only performs a simple Boolean test to determine whether capacities are exceeded. If a route&apos;s capacity value is greater than or equal to the total quantity being carried, the VRP solver will assume the cargo fits in the vehicle. This could be incorrect, depending on the actual shape of the cargo and the vehicle. For example, the VRP solver allows you to fit a 1,000-cubic-foot sphere into a 1,000-cubic-foot truck that is 8 feet wide. In reality, however, since the sphere is 12.6 feet in diameter, it won&apos;t fit in the 8-foot-wide truck.</para>
		/// <para>FixedCost:</para>
		/// <para>A fixed monetary cost that is incurred only if the route is used in a solution (that is, it has orders assigned to it). This field can contain null values; a null value indicates zero fixed cost. This cost is part of the total route operating cost.</para>
		/// <para>CostPerUnitTime:</para>
		/// <para>The monetary cost incurred—per unit of work time—for the total route duration, including travel times as well as service times and wait times at orders, depots, and breaks. This field can&apos;t contain a null value and has a default value of 1.0.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>CostPerUnitDistance:</para>
		/// <para>The monetary cost incurred—per unit of distance traveled—for the route length (total travel distance). This field can contain null values; a null value indicates zero cost.</para>
		/// <para>The unit for this field value is specified by the Distance Field Units parameter (distance_units for Python).</para>
		/// <para>OvertimeStartTime:</para>
		/// <para>The duration of regular work time before overtime computation begins. This field can contain null values; a null value indicates that overtime does not apply.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>For example, if the driver is to be paid overtime when the total route duration extends beyond eight hours, OvertimeStartTime is specified as 480 (8 hours * 60 minutes/hour), given the Time Field Units parameter is set to Minutes.</para>
		/// <para>CostPerUnitOvertime:</para>
		/// <para>The monetary cost incurred per time unit of overtime work. This can only contain a null value if OvertimeStartTime is also null. Otherwise it must be a positive value greater than the CostPerUnitTime.</para>
		/// <para>MaxOrderCount:</para>
		/// <para>The maximum allowable number of orders on the route. This field can&apos;t contain null values and has a default value of 30.</para>
		/// <para>MaxTotalTime:</para>
		/// <para>The maximum allowable route duration. The route duration includes travel times as well as service and wait times at orders, depots, and breaks. This field can contain null values; a null value indicates that there is no constraint on the route duration.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>MaxTotalTravelTime:</para>
		/// <para>The maximum allowable travel time for the route. The travel time includes only the time spent driving on the network and does not include service or wait times.</para>
		/// <para>This field can contain null values; a null value indicates there is no constraint on the maximum allowable travel time. This field value can&apos;t be larger than the MaxTotalTime field value.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>MaxTotalDistance:</para>
		/// <para>The maximum allowable travel distance for the route.</para>
		/// <para>The unit for this field value is specified by the Distance Field Units parameter (distance_units for Python).</para>
		/// <para>This field can contain null values; a null value indicates that there is no constraint on the maximum allowable travel distance.</para>
		/// <para>SpecialtyNames:</para>
		/// <para>A space-separated string containing the names of the specialties supported by the route. A null value indicates that the route does not support any specialties.</para>
		/// <para>This field is a foreign key to the SpecialtyNames field in the Orders parameter.</para>
		/// <para>To illustrate what specialties are and how they work, assume a lawn care and tree trimming company has a portion of its orders that requires a bucket truck to trim tall trees. The company would enter BucketTruck in the SpecialtyNames field for these orders to indicate their special need. SpecialtyNames would be left as null for the other orders. Similarly, the company would also enter BucketTruck in the SpecialtyNames field of routes that are driven by trucks with hydraulic booms. It would leave the field null for the other routes. At solve time, the VRP solver assigns orders without special needs to any route, but it only assigns orders that need bucket trucks to routes that have them.</para>
		/// <para>AssignmentRule:</para>
		/// <para>This specifies whether or not the route can be used when solving the problem. This field is constrained by a domain of values, and the possible values are the following:</para>
		/// <para>Include—The route is included in the solve operation. This is the default value.</para>
		/// <para>Exclude—The route is excluded from the solve operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		public object Routes { get; set; }

		/// <summary>
		/// <para>Breaks</para>
		/// <para>The rest periods, or breaks, for the routes in a given vehicle routing problem. A break is associated with exactly one route, and it can be taken after completing an order, while en route to an order, or prior to servicing an order. It has a start time and a duration, for which the driver may or may not be paid. There are three options for establishing when a break begins: using a time window, a maximum travel time, or a maximum work time.</para>
		/// <para>The breaks record set has associated attributes. The fields in the attribute table are listed and described below.</para>
		/// <para>&lt;para/&gt;ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>RouteName:</para>
		/// <para>The name of the route that the break applies to. Although a break is assigned to exactly one route, many breaks can be assigned to the same route.</para>
		/// <para>This field is a foreign key to the Name field in the Routes class and can&apos;t have a null value.</para>
		/// <para>Precedence:</para>
		/// <para>Precedence values sequence the breaks of a given route. Breaks with a precedence value of 1 occur before those with a value of 2, and so on.</para>
		/// <para>All breaks must have a precedence value, regardless of whether they are time-window, maximum-travel-time, or maximum-work-time breaks.</para>
		/// <para>ServiceTime</para>
		/// <para>The duration of the break. This field can&apos;t contain null values and has a default value of 60.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>TimeWindowStart:</para>
		/// <para>The starting time of the break&apos;s time window. Half-open time windows are invalid for Breaks.</para>
		/// <para>If this field has a value, MaxTravelTimeBetweenBreaks and MaxCumulWorkTime must be null; moreover, all other breaks in the analysis layer must have null values for MaxTravelTimeBetweenBreaks and MaxCumulWorkTime.</para>
		/// <para>An error will occur at solve time if a route has multiple breaks with overlapping time windows.</para>
		/// <para>The time window fields in breaks can contain a time-only value or a date and time value in a date field and cannot be integers representing milliseconds since Epoch. The time zone for time window fields is specified using the time_zone_usage_for_time_fields parameter. If a time field, such as TimeWindowStart, has a time-only value (for example, 12:00 p.m.), the date is assumed to be the date specified by the Default Date parameter (default_date in Python). Using date and time values (for example, 7/11/2012 12:00 p.m.) allows you to specify time windows that span two or more days. This is beneficial when a break should be taken sometime before and after midnight.</para>
		/// <para>The default date is ignored when any time window field includes a date with the time. To avoid an error in this situation, format all time windows in Depots, Routes, Orders, and Breaks to also include the date with the time.</para>
		/// <para>TimeWindowEnd:</para>
		/// <para>The ending time of the break&apos;s time window. Half-open time windows are invalid for Breaks.</para>
		/// <para>If this field has a value, MaxTravelTimeBetweenBreaks and MaxCumulWorkTime must be null; moreover, all other breaks in the analysis layer must have null values for MaxTravelTimeBetweenBreaks and MaxCumulWorkTime.</para>
		/// <para>MaxViolationTime:</para>
		/// <para>This field specifies the maximum allowable violation time for a time-window break. A time window is considered violated if the arrival time falls outside the time range.</para>
		/// <para>A zero value indicates the time window cannot be violated; that is, the time window is hard. A nonzero value specifies the maximum amount of lateness; for example, the break can begin up to 30 minutes beyond the end of its time window, but the lateness is penalized pursuant to the Time Window Violation Importance parameter (time_window_factor in Python).</para>
		/// <para>This property can be null; a null value with TimeWindowStart and TimeWindowEnd values indicates that there is no limit on the allowable violation time. If MaxTravelTimeBetweenBreaks or MaxCumulWorkTime has a value, MaxViolationTime must be null.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>MaxTravelTimeBetweenBreaks:</para>
		/// <para>The maximum amount of travel time that can be accumulated before the break is taken. The travel time is accumulated either from the end of the previous break or, if a break has not yet been taken, from the start of the route.</para>
		/// <para>If this is the route&apos;s final break, MaxTravelTimeBetweenBreaks also indicates the maximum travel time that can be accumulated from the final break to the end depot.</para>
		/// <para>This field is designed to limit how long a person can drive until a break is required. For instance, if the Time Field Units parameter (time_units in Python) of the analysis is set to Minutes, and MaxTravelTimeBetweenBreaks has a value of 120, the driver will get a break after two hours of driving. To assign a second break after two more hours of driving, the second break&apos;s MaxTravelTimeBetweenBreaks field value should be 120.</para>
		/// <para>If this field has a value, TimeWindowStart, TimeWindowEnd, MaxViolationTime, and MaxCumulWorkTime must be null for an analysis to solve successfully.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>MaxCumulWorkTime:</para>
		/// <para>The maximum amount of work time that can be accumulated before the break is taken. Work time is always accumulated from the beginning of the route.</para>
		/// <para>Work time is the sum of travel time and service times at orders, depots, and breaks. Note, however, that this excludes wait time, which is the time a route (or driver) spends waiting at an order or depot for a time window to begin.</para>
		/// <para>This field is designed to limit how long a person can work until a break is required. For instance, if the Time Field Units parameter (time_units in Python) is set to Minutes, MaxCumulWorkTime has a value of 120, and ServiceTime has a value of 15, the driver will get a 15-minute break after two hours of work.</para>
		/// <para>Continuing with the last example, assume a second break is needed after three more hours of work. To specify this break, you would enter 315 (five hours and 15 minutes) as the second break&apos;s MaxCumulWorkTime value. This number includes the MaxCumulWorkTime and ServiceTime values of the preceding break, along with the three additional hours of work time before granting the second break. To avoid taking maximum-work-time breaks prematurely, remember that they accumulate work time from the beginning of the route and that work time includes the service time at previously visited depots, orders, and breaks.</para>
		/// <para>If this field has a value, TimeWindowStart, TimeWindowEnd, MaxViolationTime, and MaxTravelTimeBetweenBreaks must be null for an analysis to solve successfully.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter (time_units in Python).</para>
		/// <para>IsPaid:</para>
		/// <para>A Boolean value indicating whether the break is paid or unpaid. A True value indicates that the time spent at the break is included in the route cost computation and overtime determination. A False value indicates otherwise. The default value is True.</para>
		/// <para>Sequence:</para>
		/// <para>As an input field, this indicates the sequence of the break on its route. This field can contain null values. The input sequence values are positive and unique for each route (shared across renewal depot visits, orders, and breaks) but need not start from 1 or be contiguous.</para>
		/// <para>The solver modifies the sequence field. After solving, this field contains the sequence value of the break on its route. Output sequence values for a route are shared across depot visits, orders, and breaks; start from 1 (at the starting depot); and are consecutive.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		public object? Breaks { get; set; }

		/// <summary>
		/// <para>Time Field Units</para>
		/// <para>Specifies the time units for all time-based field values in the analysis.</para>
		/// <para>Seconds—Seconds</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Hours—Hours</para>
		/// <para>Days—Days</para>
		/// <para>Many features and records in a VRP analysis have fields for storing time values, such as ServiceTime for orders and CostPerUnitTime for routes. To minimize data entry requirements, these field values don&apos;t include units. Instead, all distance-based field values must be entered in the same units, and this parameter is used to specify the units of those values.</para>
		/// <para>Note that output time-based fields use the same units specified by this parameter.</para>
		/// <para>This time unit doesn&apos;t need to match the time unit of the network Time Attribute parameter (time_attribute in Python).</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Field Units</para>
		/// <para>Specifies the distance units for all distance-based field values in the analysis.</para>
		/// <para>Miles—Miles</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Meters—Meters</para>
		/// <para>Nautical Miles—Nautical miles</para>
		/// <para>Many features and records in a VRP analysis have fields for storing distance values, such as MaxTotalDistance and CostPerUnitDistance for routes. To minimize data entry requirements, these field values don&apos;t include units. Instead, all distance-based field values must be entered in the same units, and this parameter is used to specify the units of those values.</para>
		/// <para>Note that output distance-based fields use the same units specified by this parameter.</para>
		/// <para>This distance unit doesn&apos;t need to match the distance unit of the network Distance Attribute (distance attribute in Python).</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Network Dataset</para>
		/// <para>The network dataset on which the vehicle routing problem analysis will be performed. The network dataset must have a time-based cost attribute, since the VRP solver minimizes time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object NetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Geodatabase Workspace</para>
		/// <para>The file geodatabase or in-memory workspace in which the output feature classes will be created. This workspace must already exist. The default output workspace is in memory.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object OutputWorkspaceLocation { get; set; }

		/// <summary>
		/// <para>Output Unassigned Stops Name</para>
		/// <para>The name of the output feature class that will contain any unreachable depots or unassigned orders.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputUnassignedStopsName { get; set; }

		/// <summary>
		/// <para>Output Stops Name</para>
		/// <para>The name of the feature class that will contain the stops visited by routes. This feature class includes stops at depots, orders, and breaks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputStopsName { get; set; }

		/// <summary>
		/// <para>Output Routes Name</para>
		/// <para>The name of the feature class that will contain the routes of the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputRoutesName { get; set; }

		/// <summary>
		/// <para>Output Directions Name</para>
		/// <para>The name of the feature class that will contain the directions for the routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputDirectionsName { get; set; }

		/// <summary>
		/// <para>Default Date</para>
		/// <para>The default date for time field values that specify a time of day without including a date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object? DefaultDate { get; set; }

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// <para>Specifies the U-turn policy that will be used at junctions. Allowing U-turns implies that the solver can turn around at a junction and double back on the same street. Given that junctions represent street intersections and dead ends, different vehicles may be able to turn around at some junctions but not at others—it depends on whether the junction represents an intersection or a dead end. To accommodate this, the U-turn policy parameter is implicitly specified by the number of edges that connect to the junction, which is known as junction valency. The acceptable values for this parameter are listed below; each is followed by a description of its meaning in terms of junction valency.</para>
		/// <para>Allowed—U-turns are permitted at junctions with any number of connected edges. This is the default value.</para>
		/// <para>Not allowed—U-turns are prohibited at all junctions, regardless of junction valency. However, U-turns are still permitted at network locations even when this setting is chosen, but you can set the individual network location&apos;s CurbApproach property to prohibit U-turns there as well.</para>
		/// <para>Allowed at dead ends only—U-turns are prohibited at all junctions, except those that have only one adjacent edge (a dead end).</para>
		/// <para>Allowed at dead ends and intersections only—U-turns are prohibited at junctions where exactly two adjacent edges meet but are permitted at intersections (junctions with three or more adjacent edges) and dead ends (junctions with exactly one adjacent edge). Often, networks have extraneous junctions in the middle of road segments. This option prevents vehicles from making U-turns at these locations.</para>
		/// <para>If you need a more precisely defined U-turn policy, consider adding a global turn delay evaluator to a network cost attribute or adjusting its settings if one exists, and pay particular attention to the configuration of reverse turns. You can also set the CurbApproach property of your network locations.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? UturnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// <para>Specifies the importance of honoring time windows. There are three options, which are listed and described below.</para>
		/// <para>Low—Places more importance on minimizing drive times and less on arriving at stops on time. You may want to use this setting if you have a growing backlog of service requests. For the purpose of servicing more orders in a day and reducing the backlog, you can choose this setting even though customers may be inconvenienced with your late arrivals.</para>
		/// <para>Medium—Balances the importance of minimizing drive times and arriving within time windows. This is the default value.</para>
		/// <para>High—Places more importance on arriving at stops on time and less on minimizing drive times. Organizations that make time-critical deliveries or that are concerned with customer service would choose this setting.</para>
		/// <para><see cref="TimeWindowFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeWindowFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Spatially Cluster Routes</para>
		/// <para>Specifies whether to use spatial clustering.</para>
		/// <para>Checked—The orders assigned to an individual route will be spatially clustered. Clustering orders tends to keep routes in smaller areas and reduce how often route lines intersect one another; yet, clustering can increase overall travel times. This is the default.</para>
		/// <para>Unchecked—The solver will not prioritize spatially clustering orders and the route lines may intersect. Use this option if route zones are specified.</para>
		/// <para><see cref="SpatiallyClusterRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? SpatiallyClusterRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Route Zones</para>
		/// <para>Delineates work territories for given routes. A route zone is a polygon feature and is used to constrain routes to servicing only those orders that fall within or near the specified area. The following are examples of when route zones may be useful:</para>
		/// <para>Some of your employees don&apos;t have the required permits to perform work in certain states or communities. You can create a hard route zone so they only visit orders in areas where they meet the requirements.</para>
		/// <para>One of your vehicles breaks down frequently, so you want to minimize response time by having it only visit orders that are close to your maintenance garage. You can create a soft or hard route zone to keep the vehicle nearby.</para>
		/// <para>The route zones feature set has an associated attribute table. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Shape:</para>
		/// <para>The geometry field indicating the geographic location of the network analysis object.</para>
		/// <para>RouteName:</para>
		/// <para>The name of the route to which this zone applies. A route zone can have a maximum of one associated route. This field can&apos;t contain null values, and it is a foreign key to the Name field in the Routes feature layer.</para>
		/// <para>IsHardZone:</para>
		/// <para>A Boolean value indicating a hard or soft route zone. A True value indicates that the route zone is hard; that is, an order that falls outside the route zone polygon can&apos;t be assigned to the route. The default value is True (1). A False value (0) indicates that such orders can still be assigned, but the cost of servicing the order is weighted by a function that is based on the Euclidean distance from the route zone. Basically, this means that as the straight-line distance from the soft zone to the order increases, the likelihood of the order being assigned to the route decreases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Advanced Analysis")]
		public object? RouteZones { get; set; }

		/// <summary>
		/// <para>Route Renewals</para>
		/// <para>Specifies the intermediate depots that routes can visit to reload or unload the cargo they are delivering or picking up. Specifically, a route renewal links a route to a depot. The relationship indicates that the route can renew (reload or unload while en route) at the associated depot.</para>
		/// <para>Route renewals can be used to model scenarios in which a vehicle picks up a full load of deliveries at the starting depot, services the orders, returns to the depot to renew its load of deliveries, and continues servicing more orders. For example, in propane gas delivery, the vehicle may make several deliveries until its tank is nearly or completely depleted, visit a refueling point, and make more deliveries.</para>
		/// <para>The following are rules and options to consider when also working with route seed points:</para>
		/// <para>The reload/unload point, or renewal location, can be different from the start or end depot.</para>
		/// <para>Each route can have one or many predetermined renewal locations.</para>
		/// <para>A renewal location may be used more than once by a single route.</para>
		/// <para>In some cases where there may be several potential renewal locations for a route, the closest available renewal location is chosen by the solver.</para>
		/// <para>The route renewals record set has associated attributes. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>DepotName:</para>
		/// <para>The name of the depot where this renewal takes place. This field can&apos;t contain a null value and is a foreign key to the Name field in the Depots feature layer.</para>
		/// <para>RouteName:</para>
		/// <para>The name of the route that this renewal applies to. This field can&apos;t contain a null value and is a foreign key to the Name field in the Routes feature layer.</para>
		/// <para>ServiceTime:</para>
		/// <para>The service time for the renewal. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units property of the analysis layer.</para>
		/// <para>The time taken to load a vehicle at a renewal depot may depend on the size of the vehicle and how full or empty the vehicle is. However, the service time for a route renewal is a fixed value and does not take into account the actual load. As such, the renewal service time should be given a value corresponding to a full truckload, an average truckload, or another time estimate of your choice.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object? RouteRenewals { get; set; }

		/// <summary>
		/// <para>Order Pairs</para>
		/// <para>Pairs pick up and deliver orders so they are serviced by the same route.</para>
		/// <para>Sometimes it is required that the pick up and delivery of orders be paired. For example, a courier company may need to have a route pick up a high-priority package from one order and deliver it to another without returning to a depot, or sorting station, to minimize delivery time. These related orders can be assigned to the same route with the appropriate sequence using order pairs. Moreover, restrictions on how long the package can stay in the vehicle can also be assigned; for example, the package might be a blood sample that has to be transported from the doctor&apos;s office to the lab within two hours.</para>
		/// <para>The order pairs record set has associated attributes. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>FirstOrderName:</para>
		/// <para>The name of the first order of the pair. This field is a foreign key to the Name field in the Orders feature layer.</para>
		/// <para>SecondOrderName:</para>
		/// <para>The name of the second order of the pair. This field is a foreign key to the Name field in the Orders feature layer.</para>
		/// <para>The first order in the pair must be a pickup order; that is, the value for its DeliveryQuantities field is null. The second order in the pair must be a delivery order; that is, the value for its PickupQuantities field is null. The quantity that is picked up at the first order must agree with the quantity that is delivered at the second order. As a special case, both orders may have zero quantities for scenarios where capacities are not used.</para>
		/// <para>The order quantities are not loaded or unloaded at depots.</para>
		/// <para>MaxTransitTime:</para>
		/// <para>The maximum transit time for the pair. The transit time is the duration from the departure time of the first order to the arrival time at the second order. This constraint limits the time-on-vehicle, or ride time, between the two orders. When a vehicle is carrying people or perishable goods, the ride time is typically shorter than that of a vehicle carrying packages or nonperishable goods. This field can contain null values; a null value indicates that there is no constraint on the ride time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units property of the analysis layer.</para>
		/// <para>Excess transit time (measured with respect to the direct travel time between order pairs) can be tracked and weighted by the solver. Because of this, you can direct the VRP solver to take one of three approaches: minimize the overall excess transit time, regardless of the increase in travel cost for the fleet; find a solution that balances overall violation time and travel cost; or ignore the overall excess transit time and, instead, minimize the travel cost for the fleet. By assigning an importance level for the Excess Transit Time Importance parameter (excess_transit_factor in Python), you are in effect choosing one of these three approaches. Regardless of the importance level, the solver will always return an error if the MaxTransitTime value is surpassed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object? OrderPairs { get; set; }

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// <para>Specifies the importance of reducing excess transit time of order pairs. Excess transit time is the amount of time exceeding the time required to travel directly between the paired orders. Excess time can be caused by driver breaks or travel to intermediate orders and depots.</para>
		/// <para>Low—Places more importance on minimizing overall solution cost and less on excess transit time. This setting is commonly used by courier services. Since couriers transport packages as opposed to people, they don&apos;t need to worry about ride time. Using this setting allows the couriers to service paired orders in the proper sequence and minimize the overall solution cost.</para>
		/// <para>Medium—Balances the importance of reducing excess transit time and reducing the overall solution cost. This is the default value.</para>
		/// <para>High—Places more importance on the shortest transit time between paired orders and less on the overall travel costs. It makes sense to use this setting if you are transporting people between paired orders and you want to shorten their ride time. This is characteristic of taxi services.</para>
		/// <para><see cref="ExcessTransitFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? ExcessTransitFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Point Barriers</para>
		/// <para>Specifies point barriers, which are split into two types: restriction and added cost point barriers. They temporarily restrict traversal across or add impedance to points on the network. The point barriers are defined by a feature set, and the attribute values you specify for the point features determine whether they are restriction or added cost barriers. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Shape:</para>
		/// <para>The geometry field indicating the geographic location of the network analysis object.</para>
		/// <para>Name:</para>
		/// <para>The name of the barrier.</para>
		/// <para>BarrierType:</para>
		/// <para>Specifies whether the barrier restricts travel completely or adds cost when traveling through it. There are two options:</para>
		/// <para>(0)—Prohibits traversing through the barrier. This is the default value.&lt;bold&gt;Restriction&lt;/bold&gt;</para>
		/// <para>(2)—Traversing through the barrier increases the network cost by the amount specified in the Additional_Time and Additional_Distance fields.&lt;bold&gt;Added Cost&lt;/bold&gt;</para>
		/// <para>Additional_Time:</para>
		/// <para>If BarrierType is set to added cost, the value of the Additional_Time field indicates how much time is added to a route when the route passes through the barrier.</para>
		/// <para>The unit for this field value is specified by the Time Field Units property of the analysis layer.</para>
		/// <para>Additional_Distance:</para>
		/// <para>If BarrierType is set to added cost, the value of the Additional_Distance field indicates how much impedance is added to a route when the route passes through the barrier.</para>
		/// <para>The unit for this field value is specified by the Distance Field Units parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? PointBarriers { get; set; }

		/// <summary>
		/// <para>Line Barriers</para>
		/// <para>Specifies line barriers, which temporarily restrict traversal across them. The line barriers are defined by a feature set. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Shape:</para>
		/// <para>The geometry field indicating the geographic location of the network analysis object.</para>
		/// <para>Name:</para>
		/// <para>The name of the barrier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// <para>Specifies polygon barriers, which are split into two types: restriction and scaled cost polygon barriers. They temporarily restrict traversal or scale impedance on the parts of the network they cover. The polygon barriers are defined by a feature set, and the attribute values you specify for the polygon features determine whether they are restriction or scaled cost barriers. The fields in the attribute table are listed and described below.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Shape:</para>
		/// <para>The geometry field indicating the geographic location of the network analysis object.</para>
		/// <para>Name:</para>
		/// <para>The name of the barrier.</para>
		/// <para>BarrierType:</para>
		/// <para>Specifies whether the barrier restricts travel completely or scales the cost of traveling through it. There are two options:</para>
		/// <para>(0)—Prohibits traversing through any part of the barrier. This is the default value.&lt;bold&gt;Restriction&lt;/bold&gt;</para>
		/// <para>(1)—Scales the impedance of underlying edges by multiplying them by the value of the Attr_[Impedance] property. If edges are partially covered by the barrier, the impedance is apportioned and multiplied.&lt;bold&gt;Scaled Cost&lt;/bold&gt;</para>
		/// <para>Scaled_Time:</para>
		/// <para>The time-based impedance values of the edges underlying the barrier are multiplied by the value set in this field. This field is only relevant when the barrier is a scaled cost barrier.</para>
		/// <para>Scaled_Distance:</para>
		/// <para>The distance-based impedance values of the edges underlying the barrier are multiplied by the value set in this field. This field is only relevant when the barrier is a scaled cost barrier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Time Attribute</para>
		/// <para>The network cost attribute to use when determining the travel time of network elements.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? TimeAttribute { get; set; }

		/// <summary>
		/// <para>Distance Attribute</para>
		/// <para>The network cost attribute to use when determining the distance of network elements.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? DistanceAttribute { get; set; }

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>Checked—The hierarchy attribute will be used for the analysis. Using a hierarchy results in the solver preferring higher-order edges to lower-order edges. Hierarchical solves are faster, and they can be used to simulate the preference of a driver who chooses to travel on freeways rather than local roads when possible—even if that means a longer trip. This option is active only if the input network dataset has a hierarchy attribute.</para>
		/// <para>Unchecked—The hierarchy attribute will not be used for the analysis. If hierarchy is not used, the result is an exact route for the network dataset.</para>
		/// <para>The parameter is inactive if a hierarchy attribute is not defined on the network dataset used to perform the analysis.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// <para><see cref="UseHierarchyInAnalysisEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? UseHierarchyInAnalysis { get; set; }

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>Indicates which network restriction attributes are respected during solve time.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? Restrictions { get; set; }

		/// <summary>
		/// <para>Attribute Parameter Values</para>
		/// <para>Specifies the parameter values for network attributes that have parameters. The record set has two columns that work together to uniquely identify parameters and another column that specifies the parameter value.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// <para>The attribute parameter values record set has associated attributes. The fields in the attribute table are listed below and described.</para>
		/// <para>ObjectID:</para>
		/// <para>The system-managed ID field.</para>
		/// <para>AttributeName:</para>
		/// <para>The name of the network attribute whose attribute parameter is set by the table row.</para>
		/// <para>ParameterName:</para>
		/// <para>The name of the attribute parameter whose value is set by the table row. (Object type parameters cannot be updated using this tool.)</para>
		/// <para>ParameterValue:</para>
		/// <para>The value you want for the attribute parameter. If a value is not specified, the attribute parameter is set to null.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object? AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Maximum Snap Tolerance</para>
		/// <para>The maximum snap tolerance is the furthest distance that Network Analyst searches when locating or relocating a point onto the network. The search looks for suitable edges or junctions and snaps the point to the nearest one. If a suitable location isn't found within the maximum snap tolerance, the object is marked as unlocated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Locations")]
		public object? MaximumSnapTolerance { get; set; } = "20 Kilometers";

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// <para>Specifies where network locations are placed.</para>
		/// <para>Checked—The network locations are only placed on traversable portions of the network. This prevents placing network locations on elements that you can&apos;t reach due to restrictions or barriers. Before adding your network locations using this option, make sure that you have already added all the restriction barriers to the input network analysis layer to get expected results. This option is not applicable when adding barrier objects.</para>
		/// <para>Unchecked—The network locations are placed on all the elements of the network. The network locations that are added with this option may be unreachable during the solve process if they are placed on restricted elements.</para>
		/// <para><see cref="ExcludeRestrictedPortionsOfTheNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Locations")]
		public object? ExcludeRestrictedPortionsOfTheNetwork { get; set; } = "true";

		/// <summary>
		/// <para>Feature Locator WHERE Clause</para>
		/// <para>An SQL expression used to select a subset of source features that limits on which network elements orders and depots can be located. For example, to ensure orders and depots are not located on limited-access highways, write an SQL expression that excludes those source features. Note that the other network analysis objects, such as barriers, ignore the feature locator WHERE clause when loading.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Network Locations")]
		public object? FeatureLocatorWhereClause { get; set; }

		/// <summary>
		/// <para>Populate Route Lines</para>
		/// <para>Specifies whether lines that show the true shape of the routes will be generated.</para>
		/// <para>Checked—The route features will have their Shape fields populated with lines.</para>
		/// <para>Unchecked—No shape will be generated for the output routes.</para>
		/// <para><see cref="PopulateRouteLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? PopulateRouteLines { get; set; } = "true";

		/// <summary>
		/// <para>Route Line Simplification Tolerance</para>
		/// <para>The simplification distance of the route geometry.</para>
		/// <para>Simplification maintains critical points on a route, such as turns at intersections, to define the essential shape of the route and removes other points. The simplification distance you specify is the maximum allowable offset that the simplified line can deviate from the original line. Simplifying a line reduces the number of vertices and tends to reduce drawing times.</para>
		/// <para>The value of this parameter is overridden when Travel Mode (travel_mode in Python) is set to any value other than custom.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Custom Travel Mode")]
		public object? RouteLineSimplificationTolerance { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Populate Directions</para>
		/// <para>Specifies whether driving directions will be generated.</para>
		/// <para>Checked—Driving directions will be generated. The feature class specified in the Output Directions Name parameter is populated with turn-by-turn instructions for each route. The network dataset must support driving directions; otherwise, an error will occur when solving with directions.</para>
		/// <para>Unchecked—Directions will not be generated.</para>
		/// <para><see cref="PopulateDirectionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? PopulateDirections { get; set; } = "false";

		/// <summary>
		/// <para>Directions Language</para>
		/// <para>The language in which driving directions will be generated. The languages available in the drop-down list depend on which ArcGIS language packs are installed on your computer.</para>
		/// <para>If you are going to publish this tool as part of a service on a separate server, the ArcGIS language pack that corresponds to the language you choose must be installed on that server for the tool to function properly. Also, if a language pack isn&apos;t installed on your computer, the language won&apos;t appear in the drop-down list; however, you can type a language code instead.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? DirectionsLanguage { get; set; }

		/// <summary>
		/// <para>Directions Style Name</para>
		/// <para>Specifies the formatting style of directions.</para>
		/// <para>NA Desktop—Printable turn-by-turn directions</para>
		/// <para>NA Navigation—Turn-by-turn directions designed for an in-vehicle navigation device</para>
		/// <para>NA Campus—Turn-by-turn walking directions designed for pedestrian routes</para>
		/// <para><see cref="DirectionsStyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? DirectionsStyleName { get; set; }

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// <para>Specifies whether the output includes a network analysis layer of the results.</para>
		/// <para>Checked—The output will include a network analysis layer of the results.</para>
		/// <para>Unchecked—The output will not include a network analysis layer of the results.</para>
		/// <para>In either case, stand-alone tables and feature classes are returned. However, a server administrator may want to choose to output a network analysis layer so the setup and results of the tool can be debugged using the Network Analyst controls in the ArcGIS Desktop environment. This can make the debugging process easier.</para>
		/// <para>In ArcGIS Desktop, the default output location for the network analysis layer is in the scratch workspace, at the same level as the scratch geodatabase; that is, it is stored as a sibling of the scratch geodatabase. The output network analysis layer is stored as an .lyr file whose name starts with _ags_gpna and is followed by an alphanumeric GUID.</para>
		/// <para><see cref="SaveOutputLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? SaveOutputLayer { get; set; } = "false";

		/// <summary>
		/// <para>Service Capabilities</para>
		/// <para>Specifies the maximum amount of computer processing that occurs when running this tool as a geoprocessing service. You may want to do this for one of two reasons: to avoid letting your server solve problems that require more resources or processing time than you want to allow, or to create multiple services with different VRP capabilities to support a business model. For example, if you have a tiered-service business model, you may want to provide a free VRP service that supports a maximum of five routes per solve and another service that is fee-based and supports more than five routes per solve.</para>
		/// <para>In addition to limiting the maximum number of routes, you can limit the number of orders or point barriers that can be added to the analysis. Another way to control problem sizes is by setting a maximum number of features—usually street features—that line or polygon barriers can intersect. The last method is to force a hierarchical solve, even if the user chooses not to use a hierarchy, when orders are geographically dispersed beyond a given straight-line distance.</para>
		/// <para>MAXIMUM POINT BARRIERS—The maximum number of point barriers allowed. An error is returned if this limit is exceeded. A null value indicates there is no limit.</para>
		/// <para>MAXIMUM FEATURES INTERSECTING LINE BARRIERS—The maximum number of source features that can be intersected by all line barriers in the analysis. An error is returned if this limit is exceeded. A null value indicates there is no limit.</para>
		/// <para>MAXIMUM FEATURES INTERSECTING POLYGON BARRIERS—The maximum number of source features that can be intersected by all polygon barriers in the analysis. An error is returned if this limit is exceeded. A null value indicates there is no limit.</para>
		/// <para>MAXIMUM ORDERS—The maximum number of orders allowed in the analysis. An error is returned if this limit is exceeded. A null value indicates there is no limit.</para>
		/// <para>MAXIMUM ROUTES—The maximum number of routes allowed in the analysis. An error is returned if this limit is exceeded. A null value indicates there is no limit.</para>
		/// <para>FORCE HIERARCHY BEYOND DISTANCE—The maximum straight-line distance between orders before the vehicle routing problem is solved using the network&apos;s hierarchy. The units for this value are the same as those specified in the Distance Field Units parameter.If the network doesn&apos;t have a hierarchy attribute, this constraint is ignored. If Use Hierarchy in Analysis is checked, hierarchy is always used. If the Use Hierarchy in Analysis parameter is unchecked and this constraint has a null value, hierarchy is not forced.</para>
		/// <para>MAXIMUM ORDERS PER ROUTE—The maximum number of orders that can be assigned to each route. An error is returned if this limit is exceeded. A null value indicates there is no limit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Service Capabilities")]
		public object? ServiceCapabilities { get; set; } = "'MAXIMUM POINT BARRIERS' #;'MAXIMUM FEATURES INTERSECTING LINE BARRIERS' #;'MAXIMUM FEATURES INTERSECTING POLYGON BARRIERS' #;'MAXIMUM ORDERS' #;'MAXIMUM ROUTES' #;'FORCE HIERARCHY BEYOND DISTANCE' #;'MAXIMUM ORDERS PER ROUTE' #";

		/// <summary>
		/// <para>Ignore Invalid Order Locations</para>
		/// <para>Specifies whether invalid orders will be ignored when solving the vehicle routing problem.</para>
		/// <para>Checked—The solve operation will ignore any invalid orders and return a solution, given it didn&apos;t encounter any other errors. If you need to generate routes and deliver them to drivers immediately, you may be able to ignore invalid orders, solve, and distribute the routes to your drivers. Next, resolve any invalid orders from the last solve and include them in the VRP analysis for the next workday or work shift.</para>
		/// <para>Unchecked—The solve operation will fail when any invalid orders are encountered. An invalid order is an order that the VRP solver can&apos;t reach. An order may be unreachable for a variety of reasons, including if it&apos;s located on a prohibited network element, it isn&apos;t located on the network at all, or it&apos;s located on a disconnected portion of the network.</para>
		/// <para>&lt;para/&gt;</para>
		/// <para><see cref="IgnoreInvalidOrderLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Locations")]
		public object? IgnoreInvalidOrderLocations { get; set; } = "false";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>Choose the mode of transportation for the analysis. Custom is always a choice. For other travel mode names to appear, they must be present in the network dataset specified in the Network Dataset parameter.</para>
		/// <para>A travel mode is defined on a network dataset and provides override values for parameters that, together, model cars, trucks, pedestrians, or other modes of travel. By choosing a travel mode here, you don&apos;t need to provide values for the following parameters, which are overridden by values specified in the network dataset:</para>
		/// <para>UTurn Policy</para>
		/// <para>Time Attribute</para>
		/// <para>Distance Attribute</para>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>Restrictions</para>
		/// <para>Attribute Parameter Values</para>
		/// <para>Route Line Simplification Tolerance</para>
		/// <para>Custom—Define a travel mode that fits your specific needs. When Custom is chosen, the tool does not override the travel mode parameters listed above. This is the default value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Output Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; } = "false";

		/// <summary>
		/// <para>Output Unassigned Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutUnassignedStops { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutStops { get; set; }

		/// <summary>
		/// <para>Output Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutRoutes { get; set; }

		/// <summary>
		/// <para>Output Directions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutDirections { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Network Location Fields</para>
		/// <para>Specifies whether the network location fields (SourceID, SourceOID, PosAlong, and SideOfEdge) will be considered when locating orders, depots, or barriers on the network.</para>
		/// <para>Checked—Network location fields will not be considered when locating the inputs on the network. Instead, the inputs will always be located by performing a spatial search.</para>
		/// <para>Unchecked—Network location fields will be considered when locating the inputs on the network. This is the default value.</para>
		/// <para><see cref="IgnoreNetworkLocationFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Locations")]
		public object? IgnoreNetworkLocationFields { get; set; } = "false";

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// <para>Specifies the time zone for the following input date-time fields supported by the tool: TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, TimeWindowEnd2, InboundArriveTime, and OutboundDepartTime for orders; TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, and TimeWindowEnd2 for depots; EarliestStartTime and LatestStartTime for routes; and TimeWindowStart and TimeWindowEnd for breaks.</para>
		/// <para>Geo local— The date-time values associated with the orders or depots are in the time zone in which the orders and depots are located. For routes, the date-time values are based on the time zone in which the starting depot for the route is located. If a route does not have a starting depot, all orders and depots across all the routes must be in a single time zone. For breaks, the date-time values are based on the time zone of the routes. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 a.m. and 5 p.m., respectively, the time window values will be treated as 8 a.m. and 5 p.m. eastern standard time.</para>
		/// <para>UTC— The date-time values associated with the orders or depots are in Coordinated Universal Time (UTC) and are not based on the time zone in which the orders or depots are located. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 a.m. and 5 p.m., respectively, the time window values will be treated as 12 p.m. and 9 p.m. eastern standard time, assuming eastern standard time is obeying daylight saving time.</para>
		/// <para>Specifying the date-time values in UTC is useful if you do not know the time zone in which the orders or depots are located or when you have orders and depots in multiple time zones and you want all the date-time values to start simultaneously. The UTC option is applicable only when your network dataset defines a time zone attribute. Otherwise, all the date-time values are always treated as Geo local (GEO_LOCAL in Python).</para>
		/// <para><see cref="TimeZoneUsageForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeZoneUsageForTimeFields { get; set; } = "GEO_LOCAL";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>This parameter is for internal use only.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object? Overrides { get; set; }

		/// <summary>
		/// <para>Save Route Data</para>
		/// <para>Specifies whether to save a .zip file that contains a file geodatabase containing the inputs and outputs of the analysis in a format that can be used to share route layers with ArcGIS Online or ArcGIS Enterprise.</para>
		/// <para>In ArcGIS Desktop, the default output location for this output file is in the scratch folder. You can determine the location of the scratch folder using arcpy.env.scratchFolder or checking the geoprocessing environment.</para>
		/// <para>Checked—The tool writes out a .zip archive containing a file geodatabase workspace that contains the inputs and outputs of the analysis.</para>
		/// <para>Unchecked—Route data is not saved. This is the default.</para>
		/// <para><see cref="SaveRouteDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? SaveRouteData { get; set; } = "false";

		/// <summary>
		/// <para>Output Route Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutRouteData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SolveVehicleRoutingProblem SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Field Units</para>
		/// </summary>
		public enum TimeUnitsEnum 
		{
			/// <summary>
			/// <para>Minutes—Minutes</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Seconds—Seconds</para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Hours—Hours</para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—Days</para>
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
			/// <para>Miles—Miles</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Kilometers—Kilometers</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—Feet</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—Yards</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Meters—Meters</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Nautical Miles—Nautical miles</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("Nautical Miles")]
			Nautical_Miles,

		}

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// </summary>
		public enum UturnPolicyEnum 
		{
			/// <summary>
			/// <para>Allowed—U-turns are permitted at junctions with any number of connected edges. This is the default value.</para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("Allowed")]
			Allowed,

			/// <summary>
			/// <para>Not allowed—U-turns are prohibited at all junctions, regardless of junction valency. However, U-turns are still permitted at network locations even when this setting is chosen, but you can set the individual network location&apos;s CurbApproach property to prohibit U-turns there as well.</para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("Not allowed")]
			Not_allowed,

			/// <summary>
			/// <para>Allowed at dead ends only—U-turns are prohibited at all junctions, except those that have only one adjacent edge (a dead end).</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("Allowed at dead ends only")]
			Allowed_at_dead_ends_only,

			/// <summary>
			/// <para>Allowed at dead ends and intersections only—U-turns are prohibited at junctions where exactly two adjacent edges meet but are permitted at intersections (junctions with three or more adjacent edges) and dead ends (junctions with exactly one adjacent edge). Often, networks have extraneous junctions in the middle of road segments. This option prevents vehicles from making U-turns at these locations.</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("Allowed at dead ends and intersections only")]
			Allowed_at_dead_ends_and_intersections_only,

		}

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// </summary>
		public enum TimeWindowFactorEnum 
		{
			/// <summary>
			/// <para>High—Places more importance on arriving at stops on time and less on minimizing drive times. Organizations that make time-critical deliveries or that are concerned with customer service would choose this setting.</para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—Balances the importance of minimizing drive times and arriving within time windows. This is the default value.</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—Places more importance on minimizing drive times and less on arriving at stops on time. You may want to use this setting if you have a growing backlog of service requests. For the purpose of servicing more orders in a day and reducing the backlog, you can choose this setting even though customers may be inconvenienced with your late arrivals.</para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Spatially Cluster Routes</para>
		/// </summary>
		public enum SpatiallyClusterRoutesEnum 
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
		/// <para>Excess Transit Time Importance</para>
		/// </summary>
		public enum ExcessTransitFactorEnum 
		{
			/// <summary>
			/// <para>High—Places more importance on the shortest transit time between paired orders and less on the overall travel costs. It makes sense to use this setting if you are transporting people between paired orders and you want to shorten their ride time. This is characteristic of taxi services.</para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—Balances the importance of reducing excess transit time and reducing the overall solution cost. This is the default value.</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—Places more importance on minimizing overall solution cost and less on excess transit time. This setting is commonly used by courier services. Since couriers transport packages as opposed to people, they don&apos;t need to worry about ride time. Using this setting allows the couriers to service paired orders in the proper sequence and minimize the overall solution cost.</para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// </summary>
		public enum UseHierarchyInAnalysisEnum 
		{
			/// <summary>
			/// <para>Checked—The hierarchy attribute will be used for the analysis. Using a hierarchy results in the solver preferring higher-order edges to lower-order edges. Hierarchical solves are faster, and they can be used to simulate the preference of a driver who chooses to travel on freeways rather than local roads when possible—even if that means a longer trip. This option is active only if the input network dataset has a hierarchy attribute.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_HIERARCHY")]
			USE_HIERARCHY,

			/// <summary>
			/// <para>Unchecked—The hierarchy attribute will not be used for the analysis. If hierarchy is not used, the result is an exact route for the network dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HIERARCHY")]
			NO_HIERARCHY,

		}

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// </summary>
		public enum ExcludeRestrictedPortionsOfTheNetworkEnum 
		{
			/// <summary>
			/// <para>Checked—The network locations are only placed on traversable portions of the network. This prevents placing network locations on elements that you can&apos;t reach due to restrictions or barriers. Before adding your network locations using this option, make sure that you have already added all the restriction barriers to the input network analysis layer to get expected results. This option is not applicable when adding barrier objects.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE")]
			EXCLUDE,

			/// <summary>
			/// <para>Unchecked—The network locations are placed on all the elements of the network. The network locations that are added with this option may be unreachable during the solve process if they are placed on restricted elements.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE")]
			INCLUDE,

		}

		/// <summary>
		/// <para>Populate Route Lines</para>
		/// </summary>
		public enum PopulateRouteLinesEnum 
		{
			/// <summary>
			/// <para>Checked—The route features will have their Shape fields populated with lines.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROUTE_LINES")]
			ROUTE_LINES,

			/// <summary>
			/// <para>Unchecked—No shape will be generated for the output routes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ROUTE_LINES")]
			NO_ROUTE_LINES,

		}

		/// <summary>
		/// <para>Populate Directions</para>
		/// </summary>
		public enum PopulateDirectionsEnum 
		{
			/// <summary>
			/// <para>Checked—Driving directions will be generated. The feature class specified in the Output Directions Name parameter is populated with turn-by-turn instructions for each route. The network dataset must support driving directions; otherwise, an error will occur when solving with directions.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DIRECTIONS")]
			DIRECTIONS,

			/// <summary>
			/// <para>Unchecked—Directions will not be generated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DIRECTIONS")]
			NO_DIRECTIONS,

		}

		/// <summary>
		/// <para>Directions Style Name</para>
		/// </summary>
		public enum DirectionsStyleNameEnum 
		{
			/// <summary>
			/// <para>NA Desktop—Printable turn-by-turn directions</para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("NA Desktop")]
			NA_Desktop,

			/// <summary>
			/// <para>NA Navigation—Turn-by-turn directions designed for an in-vehicle navigation device</para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("NA Navigation")]
			NA_Navigation,

			/// <summary>
			/// <para>NA Campus—Turn-by-turn walking directions designed for pedestrian routes</para>
			/// </summary>
			[GPValue("NA Campus")]
			[Description("NA Campus")]
			NA_Campus,

		}

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// </summary>
		public enum SaveOutputLayerEnum 
		{
			/// <summary>
			/// <para>Checked—The output will include a network analysis layer of the results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_OUTPUT_LAYER")]
			SAVE_OUTPUT_LAYER,

			/// <summary>
			/// <para>Unchecked—The output will not include a network analysis layer of the results.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SAVE_OUTPUT_LAYER")]
			NO_SAVE_OUTPUT_LAYER,

		}

		/// <summary>
		/// <para>Ignore Invalid Order Locations</para>
		/// </summary>
		public enum IgnoreInvalidOrderLocationsEnum 
		{
			/// <summary>
			/// <para>Checked—The solve operation will ignore any invalid orders and return a solution, given it didn&apos;t encounter any other errors. If you need to generate routes and deliver them to drivers immediately, you may be able to ignore invalid orders, solve, and distribute the routes to your drivers. Next, resolve any invalid orders from the last solve and include them in the VRP analysis for the next workday or work shift.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para>Unchecked—The solve operation will fail when any invalid orders are encountered. An invalid order is an order that the VRP solver can&apos;t reach. An order may be unreachable for a variety of reasons, including if it&apos;s located on a prohibited network element, it isn&apos;t located on the network at all, or it&apos;s located on a disconnected portion of the network.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

		/// <summary>
		/// <para>Ignore Network Location Fields</para>
		/// </summary>
		public enum IgnoreNetworkLocationFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Network location fields will not be considered when locating the inputs on the network. Instead, the inputs will always be located by performing a spatial search.</para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE")]
			IGNORE,

			/// <summary>
			/// <para>Unchecked—Network location fields will be considered when locating the inputs on the network. This is the default value.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HONOR")]
			HONOR,

		}

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// </summary>
		public enum TimeZoneUsageForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>Geo local— The date-time values associated with the orders or depots are in the time zone in which the orders and depots are located. For routes, the date-time values are based on the time zone in which the starting depot for the route is located. If a route does not have a starting depot, all orders and depots across all the routes must be in a single time zone. For breaks, the date-time values are based on the time zone of the routes. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 a.m. and 5 p.m., respectively, the time window values will be treated as 8 a.m. and 5 p.m. eastern standard time.</para>
			/// </summary>
			[GPValue("GEO_LOCAL")]
			[Description("Geo local")]
			Geo_local,

			/// <summary>
			/// <para>UTC— The date-time values associated with the orders or depots are in Coordinated Universal Time (UTC) and are not based on the time zone in which the orders or depots are located. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 a.m. and 5 p.m., respectively, the time window values will be treated as 12 p.m. and 9 p.m. eastern standard time, assuming eastern standard time is obeying daylight saving time.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Save Route Data</para>
		/// </summary>
		public enum SaveRouteDataEnum 
		{
			/// <summary>
			/// <para>Checked—The tool writes out a .zip archive containing a file geodatabase workspace that contains the inputs and outputs of the analysis.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_ROUTE_DATA")]
			SAVE_ROUTE_DATA,

			/// <summary>
			/// <para>Unchecked—Route data is not saved. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SAVE_ROUTE_DATA")]
			NO_SAVE_ROUTE_DATA,

		}

#endregion
	}
}
