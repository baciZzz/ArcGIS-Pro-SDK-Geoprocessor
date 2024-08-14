using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Solve Vehicle Routing Problem</para>
	/// <para>Solves a vehicle routing problem (VRP) to find the best routes for a fleet of vehicles.</para>
	/// </summary>
	public class SolveVehicleRoutingProblem : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Orders">
		/// <para>Orders</para>
		/// <para>Specifies one or more locations that the routes of the VRP analysis will visit. An order can represent a delivery (for example, furniture delivery), a pickup (such as an airport shuttle bus picking up a passenger), or some type of service or inspection (a tree trimming job or building inspection, for instance).</para>
		/// <para>When specifying the orders, you can set properties for each—such as its name or service time—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Name</para>
		/// <para>The name of the order. The name must be unique. If the name is left null, a name is automatically generated at solve time.</para>
		/// <para>Description</para>
		/// <para>The descriptive information about the order. This can contain any textual information for the order and has no restrictions for uniqueness. You may want to store a client&apos;s ID number in the Name field and the client&apos;s actual name or address in the Description field.</para>
		/// <para>ServiceTime</para>
		/// <para>This property specifies the amount of time that will be spent at the network location when the route visits it; that is, it stores the impedance value for the network location. A zero or null value indicates that the network location requires no service time.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>TimeWindowStart1</para>
		/// <para>The beginning time of the first time window for the network location. This field can contain a null value; a null value indicates no beginning time.</para>
		/// <para>A time window only states when a vehicle can arrive at an order; it doesn&apos;t state when the service time must be completed. To account for service time and departure before the time window ends, subtract ServiceTime from the TimeWindowEnd1 field.</para>
		/// <para>The time window fields (TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, and TimeWindowEnd2) can contain a time-only value or a date and time value in a date field and cannot be integers representing milliseconds since epoch. The time zone for time window fields is specified using the time_zone_usage_for_time_fields parameter. If a time field such as TimeWindowStart1 has a time-only value (for example, 8:00 a.m.), the date is assumed to be the default date set for the analysis. Using date and time values (for example, 7/11/2010 8:00 a.m.) allows you to set time windows that span multiple days.</para>
		/// <para>When solving a problem that spans multiple time zones, each order&apos;s time-window values refer to the time zone in which the order is located.</para>
		/// <para>TimeWindowEnd1</para>
		/// <para>The ending time of the first window for the network location. This field can contain a null value; a null value indicates no ending time.</para>
		/// <para>TimeWindowStart2</para>
		/// <para>The beginning time of the second time window for the network location. This field can contain a null value; a null value indicates that there is no second time window.</para>
		/// <para>If the first time window is null as specified by the TimeWindowStart1 and TimeWindowEnd1 fields, the second time window must also be null.</para>
		/// <para>If both time windows are non null, they can&apos;t overlap. Also, the second time window must occur after the first.</para>
		/// <para>TimeWindowEnd2</para>
		/// <para>The ending time of the second time window for the network location. This field can contain a null value.</para>
		/// <para>When TimeWindowStart2 and TimeWindowEnd2 are both null, there is no second time window.</para>
		/// <para>When TimeWindowStart2 is not null but TimeWindowEnd2 is null, there is a second time window that has a starting time but no ending time. This is valid.</para>
		/// <para>MaxViolationTime1</para>
		/// <para>A time window is considered violated if the arrival time occurs after the time window has ended. This field specifies the maximum allowable violation time for the first time window of the order. It can contain a zero value but can&apos;t contain negative values. A zero value indicates that a time window violation at the first time window of the order is unacceptable; that is, the first time window is hard. Conversely, a null value indicates that there is no limit on the allowable violation time. A nonzero value specifies the maximum amount of lateness; for example, a route can arrive at an order up to 30 minutes beyond the end of its first time window.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter</para>
		/// <para>Time window violations can be tracked and weighted by the solver. Consequently, you can direct the VRP solver to do one of the following:</para>
		/// <para>Minimize the overall violation time regardless of the increase in travel cost for the fleet.</para>
		/// <para>Find a solution that balances overall violation time and travel cost.</para>
		/// <para>Ignore the overall violation time and minimize the travel cost for the fleet.</para>
		/// <para>By assigning an importance level for the Time Window Violation Importance parameter, you are essentially choosing one of these options. In any case, however, the solver will return an error if the value set for MaxViolationTime1 is surpassed.</para>
		/// <para>MaxViolationTime2</para>
		/// <para>The maximum allowable violation time for the second time window of the order. This field is analogous to the MaxViolationTime1 field.</para>
		/// <para>InboundArriveTime</para>
		/// <para>Defines when the item to be delivered to the order will be ready at the starting depot.</para>
		/// <para>The order can be assigned to a route only if the inbound arrive time precedes the route&apos;s latest start time value; this way, the route cannot leave the depot before the item is ready to be loaded onto it.</para>
		/// <para>This field can help model scenarios involving inbound-wave transshipments. For example, a job at an order requires special materials that are not currently available at the depot. The materials are being shipped from another location and will arrive at the depot at 11:00 a.m. To ensure a route that leaves before the shipment arrives isn&apos;t assigned to the order, the order&apos;s inbound arrive time is set to 11:00 a.m. The special materials arrive at 11:00 a.m., they are loaded onto the vehicle, and the vehicle departs from the depot to visit its assigned orders.</para>
		/// <para>Notes:</para>
		/// <para>The route&apos;s start time, which includes service times, must occur after the inbound arrive time. If a route begins before an order&apos;s inbound arrive time, the order cannot be assigned to the route. The assignment is invalid even if the route has a start-depot service time that lasts until after the inbound arrive time.</para>
		/// <para>This time field can contain a time-only value or a date and time value. If a time-only value is set (for example, 11:00 AM), the date is assumed to be the default date set for the analysis. The default date is ignored, however, when any time field in the Depots, Routes, Orders, or Breaks includes a date with the time. In that case, specify all such fields with a date and time (for example, 7/11/2015 11:00 AM).</para>
		/// <para>The VRP solver honors InboundArriveTime regardless of the DeliveryQuantities value.</para>
		/// <para>If an outbound depart time is also specified, its time value must occur after the inbound arrive time.</para>
		/// <para>OutboundDepartTime</para>
		/// <para>Defines when the item to be picked up at the order must arrive at the ending depot.</para>
		/// <para>The order can be assigned to a route only if the route can visit the order and reach its end depot before the specified outbound depart time.</para>
		/// <para>This field can help model scenarios involving outbound-wave transshipments. For instance, a shipping company sends out delivery trucks to pick up packages from orders and bring them into a depot where they are forwarded on to other facilities, en route to their final destination. At 3:00 p.m. every day, a semitrailer stops at the depot to pick up the high-priority packages and take them directly to a central processing station. To avoid delaying the high-priority packages until the next day&apos;s 3:00 p.m. trip, the shipping company tries to have delivery trucks pick up the high-priority packages from orders and bring them to the depot before the 3:00 p.m. deadline. This is done by setting the outbound depart time to 3:00 p.m.</para>
		/// <para>Notes:</para>
		/// <para>The route&apos;s end time, including service times, must occur before the outbound depart time. If a route reaches a depot but doesn&apos;t complete its end-depot service time prior to the order&apos;s outbound depart time, the order cannot be assigned to the route.</para>
		/// <para>This time field can contain a time-only value or a date and time value. If a time-only value is set (for example, 11:00 AM), the date is assumed to be the default date set for the analysis. The default date is ignored, however, when any time field in Depots, Routes, Orders, or Breaks includes a date with the time. In that case, specify all such fields with a date and time (for example, 7/11/2015 11:00 AM).</para>
		/// <para>The VRP solver honors OutboundDepartTime regardless of the PickupQuantities value.</para>
		/// <para>If an inbound arrive time is also specified, its time value must occur before the outbound depart time.</para>
		/// <para>DeliveryQuantities</para>
		/// <para>The size of the delivery. You can specify size in any dimension, such as weight, volume, or quantity. You can also specify multiple dimensions, for example, weight and volume.</para>
		/// <para>Enter delivery quantities without indicating units. For example, if a 300-pound object needs to be delivered to an order, enter 300. You will need to remember that the value is in pounds.</para>
		/// <para>If you are tracking multiple dimensions, separate the numeric values with a space. For example, if you are recording the weight and volume of a delivery that weighs 2,000 pounds and has a volume of 100 cubic feet, enter 2000 100. Again, you need to remember the units—in this case, pounds and cubic feet. You also need to remember the sequence in which the values and their corresponding units are entered.</para>
		/// <para>Make sure that Capacities for Routes and DeliveryQuantities and PickupQuantities for Orders are specified in the same manner; that is, the values must be in the same units. If you are using multiple dimensions, the dimensions must be listed in the same sequence for all parameters. For example, if you specify weight in pounds, followed by volume in cubic feet for DeliveryQuantities, the capacity of your routes and the pickup quantities of your orders must be specified the same way: weight in pounds, then volume in cubic feet. If you combine units or change the sequence, you will get unwanted results with no warning messages.</para>
		/// <para>An empty string or null value is equivalent to all dimensions being zero. If the string has an insufficient number of values in relation to the capacity count or dimensions being tracked, the remaining values are treated as zeros. Delivery quantities can&apos;t be negative.</para>
		/// <para>PickupQuantities</para>
		/// <para>The size of the pickup. You can specify size in any dimension, such as weight, volume, or quantity. You can also specify multiple dimensions, for example, weight and volume. You cannot, however, use negative values. This field is analogous to the DeliveryQuantities field of Orders.</para>
		/// <para>In the case of an exchange visit, an order can have both delivery and pickup quantities.</para>
		/// <para>Revenue</para>
		/// <para>The income generated if the order is included in a solution. This field can contain a null value—a null value indicates zero revenue—but it can&apos;t have a negative value.</para>
		/// <para>Revenue is included in optimizing the objective function value but is not part of the solution&apos;s operating cost; that is, the TotalCost field in the routes never includes revenue in its output. However, revenue weights the relative importance of servicing orders.</para>
		/// <para>Revenue is included in optimizing the objective function value but is not part of the solution&apos;s operating cost; that is, the TotalCost field in the route class never includes revenue in its output. However, revenue weights the relative importance of servicing orders.</para>
		/// <para>SpecialtyNames</para>
		/// <para>A space-separated string containing the names of the specialties required by the order. A null value indicates that the order doesn&apos;t require specialties.</para>
		/// <para>The spelling of any specialties listed in the Orders and Routes classes must match exactly so that the VRP solver can link them together.</para>
		/// <para>To illustrate what specialties are and how they work, assume a lawn care and tree trimming company has a portion of its orders that requires a bucket truck to trim tall trees. The company enters BucketTruck in the SpecialtyNames field for these orders to indicate their special need. SpecialtyNames is left null for the other orders. Similarly, the company also enters BucketTruck in the SpecialtyNames field of routes that are driven by trucks with hydraulic booms. It leaves the field null for the other routes. At solve time, the VRP solver assigns orders without special needs to any route, but it only assigns orders that need bucket trucks to routes that have them.</para>
		/// <para>AssignmentRule</para>
		/// <para>Specifies the rule for assigning the order to a route. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Exclude)—The order will be excluded from the subsequent solve operation.</para>
		/// <para>1 (Preserve route and relative sequence)—The solver must always assign the order to the preassigned route at the preassigned relative sequence during the solve operation. If this assignment rule can&apos;t be followed, it results in an order violation. With this setting, only the relative sequence is maintained, not the absolute sequence. To illustrate what this means, imagine there are two orders: A and B. They have sequence values of 2 and 3, respectively. If you set their AssignmentRule field values to Preserve route and relative sequence, the sequence values for A and B may change after solving because other orders, breaks, and depot visits can be sequenced before, between, or after A and B. However, B cannot be sequenced before A.</para>
		/// <para>2 (Preserve route)—The solver must always assign the order to the preassigned route during the solve operation. A valid sequence must also be set even though the sequence may or may not be preserved. If the order can&apos;t be assigned to the specified route, it results in an order violation.</para>
		/// <para>3 (Override)—The solver tries to preserve the route and sequence preassignment for the order during the solve operation. However, a new route or sequence for the order may be assigned if it helps minimize the overall value of the objective function. This is the default value.</para>
		/// <para>4 (Anchor first)—The solver ignores the route and sequence preassignment (if any) for the order during the solve operation. It assigns a route to the order and makes it the first order on that route to minimize the overall value of the objective function.</para>
		/// <para>5 (Anchor last)—The solver ignores the route and sequence preassignment (if any) for the order during the solve operation. It assigns a route to the order and makes it the last order on that route to minimize the overall value of the objective function.</para>
		/// <para>This field can&apos;t contain a null value.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at and depart from the order. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The vehicle can approach and depart the order in either direction, so a U-turn is allowed at the incident. This setting can be chosen if it is possible and practical for a vehicle to turn around at the order. This decision may depend on the width of the road and the amount of traffic or whether the order has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 (Right side of vehicle)—When the vehicle approaches and departs the order, the order must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle approaches and departs the order, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—When the vehicle approaches the order, the curb can be on either side of the vehicle; however, the vehicle must depart without turning around.</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider an order on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach an order from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at an order and not have a lane of traffic between the vehicle and the order, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
		/// <para>RouteName</para>
		/// <para>The name of the route to which the order is assigned.</para>
		/// <para>This field is used to preassign an order to a specific route. It can contain a null value, indicating that the order is not preassigned to any route, and the solver identifies the best possible route assignment for the order. If this is set to null, the Sequence field must also be set to null.</para>
		/// <para>After a solve operation, if the order is routed, the RouteName field contains the name of the route to which the order is assigned.</para>
		/// <para>Sequence</para>
		/// <para>This indicates the sequence of the order on its assigned route.</para>
		/// <para>This field is used to specify the relative sequence of an order on the route. This field can contain a null value specifying that the order can be placed anywhere along the route. A null value can only occur together with a null RouteName value.</para>
		/// <para>The input sequence values are positive and unique for each route (shared across renewal depot visits, orders, and breaks) but do not need to start from 1 or be contiguous.</para>
		/// <para>After a solve operation, the Sequence field contains the sequence value of the order on its assigned route. Output sequence values for a route are shared across depot visits, orders, and breaks; start from 1 (at the starting depot); and are consecutive. The smallest possible output sequence value for a routed order is 2, since a route always begins at a depot.</para>
		/// <para>Bearing</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured clockwise from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device equipped with a GPS receiver. Try to include bearing data if you are loading an input location that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps the tool determine on which side of the street the point is.</para>
		/// <para>BearingTol</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the Bearing field value is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than 0 and less than 180. A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15 degrees to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>NavLatency</para>
		/// <para>This field is only used in the solve process if the Bearing and BearingTol fields also have values; however, entering a NavLatency field value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much cost is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device.</para>
		/// <para>The units of NavLatency are the same as the units of the impedance attribute.</para>
		/// </param>
		/// <param name="Depots">
		/// <para>Depots</para>
		/// <para>Specifies one or more depots for the given vehicle routing problem. A depot is a location that a vehicle departs from at the beginning of its workday and returns to at the end of the workday. Vehicles are loaded (for deliveries) or unloaded (for pickups) at depots. In some cases, a depot can also act as a renewal location whereby the vehicle can unload or reload and continue performing deliveries and pickups. A depot has open and close times, as specified by a hard time window. Vehicles can&apos;t arrive at a depot outside of this time window.</para>
		/// <para>When specifying the depots, you can set properties for each—such as its name or service time—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Name</para>
		/// <para>The name of the depot. The StartDepotName and EndDepotName fields on routes reference the names you specify here. It is also referenced by the route renewals, when used.</para>
		/// <para>Depot names are not case sensitive but must be nonempty and unique.</para>
		/// <para>Description</para>
		/// <para>The descriptive information about the depot location. This can contain any textual information and has no restrictions for uniqueness.</para>
		/// <para>For example, if you want to note which region a depot is in or the depot&apos;s address and telephone number, you can enter the information here rather than in the Name field.</para>
		/// <para>TimeWindowStart1</para>
		/// <para>The beginning time of the first time window for the network location. This field can contain a null value; a null value indicates no beginning time.</para>
		/// <para>The time window fields (TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, and TimeWindowEnd2) can contain a time-only value or a date and time value in a date field and cannot be integers representing milliseconds since epoch. The time zone for time window fields is specified using the time_zone_usage_for_time_fields parameter. If a time field such as TimeWindowStart1 has a time-only value (for example, 8:00 a.m.), the date is assumed to be the default date set for the analysis. Using date and time values (for example, 7/11/2010 8:00 a.m.) allows you to set time windows that span multiple days.</para>
		/// <para>When solving a problem that spans multiple time zones, each depot&apos;s time-window values refer to the time zone in which the depot is located.</para>
		/// <para>TimeWindowEnd1</para>
		/// <para>The ending time of the first window for the network location. This field can contain a null value; a null value indicates no ending time.</para>
		/// <para>TimeWindowStart2</para>
		/// <para>The beginning time of the second time window for the network location. This field can contain a null value; a null value indicates that there is no second time window.</para>
		/// <para>If the first time window is null, as specified by the TimeWindowStart1 and TimeWindowEnd1 fields, the second time window must also be null.</para>
		/// <para>If both time windows are not null, they can&apos;t overlap. Also, the second time window must occur after the first.</para>
		/// <para>TimeWindowEnd2</para>
		/// <para>The ending time of the second time window for the network location. This field can contain a null value.</para>
		/// <para>When TimeWindowStart2 and TimeWindowEnd2 are both null, there is no second time window.</para>
		/// <para>When TimeWindowStart2 is not null but TimeWindowEnd2 is null, there is a second time window that has a starting time but no ending time. This is valid.</para>
		/// <para>CurbApproach</para>
		/// <para>0 (Either side of vehicle)—The vehicle can approach and depart the depot in either direction, so a U-turn is allowed at the incident. This setting can be chosen if it is possible and practical for a vehicle to turn around at the depot. This decision may depend on the width of the road and the amount of traffic or whether the depot has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 (Right side of vehicle)—When the vehicle approaches and departs the depot, the depot must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle approaches and departs the depot, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—When the vehicle approaches the depot, the curb can be on either side of the vehicle; however, the vehicle must depart without turning around.</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a depot on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a depot from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at a depot and not have a lane of traffic between the vehicle and the depot, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
		/// <para>Bearing</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured clockwise from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device equipped with a GPS receiver. Try to include bearing data if you are loading an input location that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps the tool determine on which side of the street the point is.</para>
		/// <para>BearingTol</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the Bearing field value is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than 0 and less than 180. A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15 degrees to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>NavLatency</para>
		/// <para>This field is only used in the solve process if the Bearing and BearingTol fields also have values; however, entering a NavLatency field value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much cost is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device.</para>
		/// <para>The units of NavLatency are the same as the units of the impedance attribute.</para>
		/// </param>
		/// <param name="Routes">
		/// <para>Routes</para>
		/// <para>Specifies one or more routes that describe vehicle and driver characteristics. A route can have start and end depot service times, a fixed or flexible starting time, time-based operating costs, distance-based operating costs, multiple capacities, various constraints on a driver&apos;s workday, and so on.</para>
		/// <para>The routes can be specified with the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the route. The name must be unique.</para>
		/// <para>The tool generates a unique name at solve time if the field value is null; therefore, entering a value is optional in most cases. However, you must enter a name if your analysis includes breaks, route renewals, route zones, or orders that are preassigned to a route because the route name is used as a foreign key in these cases. Route names not are case sensitive.</para>
		/// <para>StartDepotName</para>
		/// <para>The name of the starting depot for the route. This field is a foreign key to the Name field in Depots.</para>
		/// <para>If the StartDepotName value is null, the route will begin from the first order assigned. Omitting the start depot is useful when the vehicle&apos;s starting location is unknown or irrelevant to your problem. However, when StartDepotName is null, EndDepotName cannot also be null.</para>
		/// <para>Virtual start depots are not allowed if orders or depots are in multiple time zones.</para>
		/// <para>If the route is making deliveries and StartDepotName is null, it is assumed the cargo is loaded on the vehicle at a virtual depot before the route begins. For a route that has no renewal visits, its delivery orders (those with nonzero DeliveryQuantities values in Orders) are loaded at the start depot or virtual depot. For a route that has renewal visits, only the delivery orders before the first renewal visit are loaded at the start depot or virtual depot.</para>
		/// <para>EndDepotName</para>
		/// <para>The name of the ending depot for the route. This field is a foreign key to the Name field in Depots.</para>
		/// <para>StartDepotServiceTime</para>
		/// <para>The service time at the starting depot. This can be used to model the time spent loading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter.</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. The depot service times can be assigned values corresponding to a full truckload or an average truckload, or you can make your own time estimate.</para>
		/// <para>EndDepotServiceTime</para>
		/// <para>The service time at the ending depot. This can be used to model the time spent unloading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter.</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. The depot service times can be assigned values corresponding to a full truckload or an average truckload, or you can make your own time estimate.</para>
		/// <para>EarliestStartTime</para>
		/// <para>The earliest allowable starting time for the route. This is used by the solver in conjunction with the time window of the starting depot for determining feasible route start times.</para>
		/// <para>This field can&apos;t contain null values and has a default time-only value of 8:00 AM. The default value is interpreted as 8:00 a.m. on the default date set for the analysis.</para>
		/// <para>When solving a problem that spans multiple time zones, the time zone for EarliestStartTime is the same as the time zone in which the starting depot is located.</para>
		/// <para>LatestStartTime</para>
		/// <para>The latest allowable starting time for the route.</para>
		/// <para>This field can&apos;t contain null values and has a default time-only value of 10:00 AM. The default value is interpreted as 10:00 a.m. on the default date set for the analysis.</para>
		/// <para>When solving a problem that spans multiple time zones, the time zone for LatestStartTime is the same as the time zone in which the starting depot is located.</para>
		/// <para>ArriveDepartDelay</para>
		/// <para>This field stores the amount of travel time needed to accelerate the vehicle to normal travel speeds, decelerate it to a stop, and move it off and on the network (for example, in and out of parking). By including an ArriveDepartDelay value, the VRP solver is deterred from sending many routes to service physically coincident orders.</para>
		/// <para>The cost for this property is incurred between visits to noncoincident orders, depots, and route renewals. For example, when a route starts from a depot and visits the first order, the total arrive/depart delay is added to the travel time. The same is true when traveling from the first order to the second order. If the second and third orders are coincident, the ArriveDepartDelay value is not added between them since the vehicle doesn&apos;t need to move. If the route travels to a route renewal, the value is added to the travel time again.</para>
		/// <para>Although a vehicle must slow down and stop for a break and accelerate afterward, the VRP solver cannot add the ArriveDepartDelay value for breaks. This means that if a route leaves an order, stops for a break, and continues to the next order, the arrive/depart delay is added only once, not twice.</para>
		/// <para>For example, assume there are five coincident orders in a high-rise building, and they are serviced by three different routes. This means three arrive/depart delays are incurred; that is, three drivers need to separately find parking places and enter the same building. However, if the orders can be serviced by one route instead, only one driver needs to park and enter the building, and only one arrive/depart delay is incurred. Since the VRP solver tries to minimize cost, it attempts to limit the arrive/depart delays and thus identify the single-route option. (Note that multiple routes may need to be sent when other constraints—such as specialties, time windows, or capacities—require it.)</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>Capacities</para>
		/// <para>The maximum capacity of the vehicle. You can specify capacity in any dimension, such as weight, volume, or quantity. You can also specify multiple dimensions, for example, weight and volume.</para>
		/// <para>Enter capacities without indicating units. For example, if your vehicle can carry a maximum of 40,000 pounds, enter 40000. You need to remember that the value is in pounds.</para>
		/// <para>If you are tracking multiple dimensions, separate the numeric values with a space. For example, if you are recording the weight and volume of a delivery that weighs 2,000 pounds and has a volume of 100 cubic feet, enter 2000 100. Again, you need to remember the units—in this case, pounds and cubic feet. You also need to remember the sequence in which the values and their corresponding units are entered.</para>
		/// <para>Remembering the units and the unit sequence is important for a couple of reasons: first, so you can reinterpret the information later; second, so you can properly enter values for the DeliveryQuantities and PickupQuantities fields for the orders. Note that the VRP solver simultaneously refers to Capacities, DeliveryQuantities, and PickupQuantities to verify that a route doesn&apos;t become overloaded. Units can&apos;t be entered in the field and the VRP tool can&apos;t make unit conversions. You must enter the values for the three fields using the same units and the same unit sequence to ensure that the values are correctly interpreted. If you combine units or change the sequence in any of the three fields, unwanted results occur with no warning messages. It is recommended that you set up a unit and unit-sequence standard beforehand and continually refer to it when you enter values for these three fields.</para>
		/// <para>An empty string or null value is equivalent to all values being zero. Capacity values can&apos;t be negative.</para>
		/// <para>If the Capacities field has an insufficient number of values in relation to the DeliveryQuantities or PickupQuantities field for orders, the remaining values are treated as zero.</para>
		/// <para>The VRP solver only performs a simple Boolean test to determine whether capacities are exceeded. If a route&apos;s capacity value is greater than or equal to the total quantity being carried, the VRP solver will assume the cargo fits in the vehicle. This could be incorrect, depending on the actual shape of the cargo and the vehicle. For example, the VRP solver allows you to fit a 1,000-cubic-foot sphere into a 1,000-cubic-foot truck that is 8 feet wide. In reality, however, since the sphere is 12.6 feet in diameter, it won&apos;t fit in the 8-foot wide truck.</para>
		/// <para>FixedCost</para>
		/// <para>A fixed monetary cost that is incurred only if the route is used in a solution (that is, it has orders assigned to it). This field can contain null values; a null value indicates zero fixed cost. This cost is part of the total route operating cost.</para>
		/// <para>CostPerUnitTime</para>
		/// <para>The monetary cost incurred—per unit of work time—for the total route duration, including travel times as well as service times and wait times at orders, depots, and breaks. This field can&apos;t contain a null value and has a default value of 1.0.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>CostPerUnitDistance</para>
		/// <para>The monetary cost incurred—per unit of distance traveled—for the route length (total travel distance). This field can contain null values; a null value indicates zero cost.</para>
		/// <para>The unit for this field value is specified by the distance_units parameter.</para>
		/// <para>OvertimeStartTime</para>
		/// <para>The duration of regular work time before overtime computation begins. This field can contain null values; a null value indicates that overtime does not apply.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>For example, if the driver is to be paid overtime when the total route duration extends beyond eight hours, OvertimeStartTime is specified as 480 (8 hours * 60 minutes/hour), given the time units are minutes.</para>
		/// <para>CostPerUnitOvertime</para>
		/// <para>The monetary cost incurred per time unit of overtime work. This field can contain null values; a null value indicates that the CostPerUnitOvertime value is the same as the CostPerUnitTime value.</para>
		/// <para>MaxOrderCount</para>
		/// <para>The maximum allowable number of orders on the route. This field can&apos;t contain null values and has a default value of 30.</para>
		/// <para>MaxTotalTime</para>
		/// <para>The maximum allowable route duration. The route duration includes travel times as well as service and wait times at orders, depots, and breaks. This field can contain null values; a null value indicates that there is no constraint on the route duration.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>MaxTotalTravelTime</para>
		/// <para>The maximum allowable travel time for the route. The travel time includes only the time spent driving on the network and does not include service or wait times.</para>
		/// <para>This field can contain null values; a null value indicates that there is no constraint on the maximum allowable travel time. This field value can&apos;t be larger than the MaxTotalTime field value.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>MaxTotalDistance</para>
		/// <para>The maximum allowable travel distance for the route.</para>
		/// <para>The unit for this field value is specified by the distance_units parameter.</para>
		/// <para>This field can contain null values; a null value indicates that there is no constraint on the maximum allowable travel distance.</para>
		/// <para>SpecialtyNames</para>
		/// <para>A space-separated string containing the names of the specialties required by the order. A null value indicates that the order doesn&apos;t require specialties.</para>
		/// <para>The spelling of any specialties listed in the Orders and Routes classes must match exactly so that the VRP solver can link them together.</para>
		/// <para>To illustrate what specialties are and how they work, assume a lawn care and tree trimming company has a portion of its orders that requires a bucket truck to trim tall trees. The company enters BucketTruck in the SpecialtyNames field for these orders to indicate their special need. SpecialtyNames is left null for the other orders. Similarly, the company also enters BucketTruck in the SpecialtyNames field of routes that are driven by trucks with hydraulic booms. It leaves the field null for the other routes. At solve time, the VRP solver assigns orders without special needs to any route, but it only assigns orders that need bucket trucks to routes that have them.</para>
		/// <para>AssignmentRule</para>
		/// <para>Specifies the rule for assigning the order to a route. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>This field can&apos;t contain a null value.</para>
		/// <para>1 (Include)—The route is included in the solve operation. This is the default value.</para>
		/// <para>2 (Exclude)—The route is excluded from the solve operation.</para>
		/// </param>
		public SolveVehicleRoutingProblem(object Orders, object Depots, object Routes)
		{
			this.Orders = Orders;
			this.Depots = Depots;
			this.Routes = Routes;
		}

		/// <summary>
		/// <para>Tool Display Name : Solve Vehicle Routing Problem</para>
		/// </summary>
		public override string DisplayName => "Solve Vehicle Routing Problem";

		/// <summary>
		/// <para>Tool Name : SolveVehicleRoutingProblem</para>
		/// </summary>
		public override string ToolName => "SolveVehicleRoutingProblem";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.SolveVehicleRoutingProblem</para>
		/// </summary>
		public override string ExcuteName => "agolservices.SolveVehicleRoutingProblem";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Orders, Depots, Routes, Breaks, TimeUnits, DistanceUnits, AnalysisRegion, DefaultDate, UturnPolicy, TimeWindowFactor, SpatiallyClusterRoutes, RouteZones, RouteRenewals, OrderPairs, ExcessTransitFactor, PointBarriers, LineBarriers, PolygonBarriers, UseHierarchyInAnalysis, Restrictions, AttributeParameterValues, PopulateRouteLines, RouteLineSimplificationTolerance, PopulateDirections, DirectionsLanguage, DirectionsStyleName, TravelMode, Impedance, TimeZoneUsageForTimeFields, SaveOutputLayer, Overrides, SaveRouteData, TimeImpedance, DistanceImpedance, PopulateStopShapes, OutputFormat, IgnoreInvalidOrderLocations, OutUnassignedStops, OutStops, OutRoutes, OutDirections, SolveSucceeded, OutNetworkAnalysisLayer, OutRouteData, OutResultFile, OutputNetworkAnalysisLayerPackage };

		/// <summary>
		/// <para>Orders</para>
		/// <para>Specifies one or more locations that the routes of the VRP analysis will visit. An order can represent a delivery (for example, furniture delivery), a pickup (such as an airport shuttle bus picking up a passenger), or some type of service or inspection (a tree trimming job or building inspection, for instance).</para>
		/// <para>When specifying the orders, you can set properties for each—such as its name or service time—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Name</para>
		/// <para>The name of the order. The name must be unique. If the name is left null, a name is automatically generated at solve time.</para>
		/// <para>Description</para>
		/// <para>The descriptive information about the order. This can contain any textual information for the order and has no restrictions for uniqueness. You may want to store a client&apos;s ID number in the Name field and the client&apos;s actual name or address in the Description field.</para>
		/// <para>ServiceTime</para>
		/// <para>This property specifies the amount of time that will be spent at the network location when the route visits it; that is, it stores the impedance value for the network location. A zero or null value indicates that the network location requires no service time.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>TimeWindowStart1</para>
		/// <para>The beginning time of the first time window for the network location. This field can contain a null value; a null value indicates no beginning time.</para>
		/// <para>A time window only states when a vehicle can arrive at an order; it doesn&apos;t state when the service time must be completed. To account for service time and departure before the time window ends, subtract ServiceTime from the TimeWindowEnd1 field.</para>
		/// <para>The time window fields (TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, and TimeWindowEnd2) can contain a time-only value or a date and time value in a date field and cannot be integers representing milliseconds since epoch. The time zone for time window fields is specified using the time_zone_usage_for_time_fields parameter. If a time field such as TimeWindowStart1 has a time-only value (for example, 8:00 a.m.), the date is assumed to be the default date set for the analysis. Using date and time values (for example, 7/11/2010 8:00 a.m.) allows you to set time windows that span multiple days.</para>
		/// <para>When solving a problem that spans multiple time zones, each order&apos;s time-window values refer to the time zone in which the order is located.</para>
		/// <para>TimeWindowEnd1</para>
		/// <para>The ending time of the first window for the network location. This field can contain a null value; a null value indicates no ending time.</para>
		/// <para>TimeWindowStart2</para>
		/// <para>The beginning time of the second time window for the network location. This field can contain a null value; a null value indicates that there is no second time window.</para>
		/// <para>If the first time window is null as specified by the TimeWindowStart1 and TimeWindowEnd1 fields, the second time window must also be null.</para>
		/// <para>If both time windows are non null, they can&apos;t overlap. Also, the second time window must occur after the first.</para>
		/// <para>TimeWindowEnd2</para>
		/// <para>The ending time of the second time window for the network location. This field can contain a null value.</para>
		/// <para>When TimeWindowStart2 and TimeWindowEnd2 are both null, there is no second time window.</para>
		/// <para>When TimeWindowStart2 is not null but TimeWindowEnd2 is null, there is a second time window that has a starting time but no ending time. This is valid.</para>
		/// <para>MaxViolationTime1</para>
		/// <para>A time window is considered violated if the arrival time occurs after the time window has ended. This field specifies the maximum allowable violation time for the first time window of the order. It can contain a zero value but can&apos;t contain negative values. A zero value indicates that a time window violation at the first time window of the order is unacceptable; that is, the first time window is hard. Conversely, a null value indicates that there is no limit on the allowable violation time. A nonzero value specifies the maximum amount of lateness; for example, a route can arrive at an order up to 30 minutes beyond the end of its first time window.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter</para>
		/// <para>Time window violations can be tracked and weighted by the solver. Consequently, you can direct the VRP solver to do one of the following:</para>
		/// <para>Minimize the overall violation time regardless of the increase in travel cost for the fleet.</para>
		/// <para>Find a solution that balances overall violation time and travel cost.</para>
		/// <para>Ignore the overall violation time and minimize the travel cost for the fleet.</para>
		/// <para>By assigning an importance level for the Time Window Violation Importance parameter, you are essentially choosing one of these options. In any case, however, the solver will return an error if the value set for MaxViolationTime1 is surpassed.</para>
		/// <para>MaxViolationTime2</para>
		/// <para>The maximum allowable violation time for the second time window of the order. This field is analogous to the MaxViolationTime1 field.</para>
		/// <para>InboundArriveTime</para>
		/// <para>Defines when the item to be delivered to the order will be ready at the starting depot.</para>
		/// <para>The order can be assigned to a route only if the inbound arrive time precedes the route&apos;s latest start time value; this way, the route cannot leave the depot before the item is ready to be loaded onto it.</para>
		/// <para>This field can help model scenarios involving inbound-wave transshipments. For example, a job at an order requires special materials that are not currently available at the depot. The materials are being shipped from another location and will arrive at the depot at 11:00 a.m. To ensure a route that leaves before the shipment arrives isn&apos;t assigned to the order, the order&apos;s inbound arrive time is set to 11:00 a.m. The special materials arrive at 11:00 a.m., they are loaded onto the vehicle, and the vehicle departs from the depot to visit its assigned orders.</para>
		/// <para>Notes:</para>
		/// <para>The route&apos;s start time, which includes service times, must occur after the inbound arrive time. If a route begins before an order&apos;s inbound arrive time, the order cannot be assigned to the route. The assignment is invalid even if the route has a start-depot service time that lasts until after the inbound arrive time.</para>
		/// <para>This time field can contain a time-only value or a date and time value. If a time-only value is set (for example, 11:00 AM), the date is assumed to be the default date set for the analysis. The default date is ignored, however, when any time field in the Depots, Routes, Orders, or Breaks includes a date with the time. In that case, specify all such fields with a date and time (for example, 7/11/2015 11:00 AM).</para>
		/// <para>The VRP solver honors InboundArriveTime regardless of the DeliveryQuantities value.</para>
		/// <para>If an outbound depart time is also specified, its time value must occur after the inbound arrive time.</para>
		/// <para>OutboundDepartTime</para>
		/// <para>Defines when the item to be picked up at the order must arrive at the ending depot.</para>
		/// <para>The order can be assigned to a route only if the route can visit the order and reach its end depot before the specified outbound depart time.</para>
		/// <para>This field can help model scenarios involving outbound-wave transshipments. For instance, a shipping company sends out delivery trucks to pick up packages from orders and bring them into a depot where they are forwarded on to other facilities, en route to their final destination. At 3:00 p.m. every day, a semitrailer stops at the depot to pick up the high-priority packages and take them directly to a central processing station. To avoid delaying the high-priority packages until the next day&apos;s 3:00 p.m. trip, the shipping company tries to have delivery trucks pick up the high-priority packages from orders and bring them to the depot before the 3:00 p.m. deadline. This is done by setting the outbound depart time to 3:00 p.m.</para>
		/// <para>Notes:</para>
		/// <para>The route&apos;s end time, including service times, must occur before the outbound depart time. If a route reaches a depot but doesn&apos;t complete its end-depot service time prior to the order&apos;s outbound depart time, the order cannot be assigned to the route.</para>
		/// <para>This time field can contain a time-only value or a date and time value. If a time-only value is set (for example, 11:00 AM), the date is assumed to be the default date set for the analysis. The default date is ignored, however, when any time field in Depots, Routes, Orders, or Breaks includes a date with the time. In that case, specify all such fields with a date and time (for example, 7/11/2015 11:00 AM).</para>
		/// <para>The VRP solver honors OutboundDepartTime regardless of the PickupQuantities value.</para>
		/// <para>If an inbound arrive time is also specified, its time value must occur before the outbound depart time.</para>
		/// <para>DeliveryQuantities</para>
		/// <para>The size of the delivery. You can specify size in any dimension, such as weight, volume, or quantity. You can also specify multiple dimensions, for example, weight and volume.</para>
		/// <para>Enter delivery quantities without indicating units. For example, if a 300-pound object needs to be delivered to an order, enter 300. You will need to remember that the value is in pounds.</para>
		/// <para>If you are tracking multiple dimensions, separate the numeric values with a space. For example, if you are recording the weight and volume of a delivery that weighs 2,000 pounds and has a volume of 100 cubic feet, enter 2000 100. Again, you need to remember the units—in this case, pounds and cubic feet. You also need to remember the sequence in which the values and their corresponding units are entered.</para>
		/// <para>Make sure that Capacities for Routes and DeliveryQuantities and PickupQuantities for Orders are specified in the same manner; that is, the values must be in the same units. If you are using multiple dimensions, the dimensions must be listed in the same sequence for all parameters. For example, if you specify weight in pounds, followed by volume in cubic feet for DeliveryQuantities, the capacity of your routes and the pickup quantities of your orders must be specified the same way: weight in pounds, then volume in cubic feet. If you combine units or change the sequence, you will get unwanted results with no warning messages.</para>
		/// <para>An empty string or null value is equivalent to all dimensions being zero. If the string has an insufficient number of values in relation to the capacity count or dimensions being tracked, the remaining values are treated as zeros. Delivery quantities can&apos;t be negative.</para>
		/// <para>PickupQuantities</para>
		/// <para>The size of the pickup. You can specify size in any dimension, such as weight, volume, or quantity. You can also specify multiple dimensions, for example, weight and volume. You cannot, however, use negative values. This field is analogous to the DeliveryQuantities field of Orders.</para>
		/// <para>In the case of an exchange visit, an order can have both delivery and pickup quantities.</para>
		/// <para>Revenue</para>
		/// <para>The income generated if the order is included in a solution. This field can contain a null value—a null value indicates zero revenue—but it can&apos;t have a negative value.</para>
		/// <para>Revenue is included in optimizing the objective function value but is not part of the solution&apos;s operating cost; that is, the TotalCost field in the routes never includes revenue in its output. However, revenue weights the relative importance of servicing orders.</para>
		/// <para>Revenue is included in optimizing the objective function value but is not part of the solution&apos;s operating cost; that is, the TotalCost field in the route class never includes revenue in its output. However, revenue weights the relative importance of servicing orders.</para>
		/// <para>SpecialtyNames</para>
		/// <para>A space-separated string containing the names of the specialties required by the order. A null value indicates that the order doesn&apos;t require specialties.</para>
		/// <para>The spelling of any specialties listed in the Orders and Routes classes must match exactly so that the VRP solver can link them together.</para>
		/// <para>To illustrate what specialties are and how they work, assume a lawn care and tree trimming company has a portion of its orders that requires a bucket truck to trim tall trees. The company enters BucketTruck in the SpecialtyNames field for these orders to indicate their special need. SpecialtyNames is left null for the other orders. Similarly, the company also enters BucketTruck in the SpecialtyNames field of routes that are driven by trucks with hydraulic booms. It leaves the field null for the other routes. At solve time, the VRP solver assigns orders without special needs to any route, but it only assigns orders that need bucket trucks to routes that have them.</para>
		/// <para>AssignmentRule</para>
		/// <para>Specifies the rule for assigning the order to a route. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Exclude)—The order will be excluded from the subsequent solve operation.</para>
		/// <para>1 (Preserve route and relative sequence)—The solver must always assign the order to the preassigned route at the preassigned relative sequence during the solve operation. If this assignment rule can&apos;t be followed, it results in an order violation. With this setting, only the relative sequence is maintained, not the absolute sequence. To illustrate what this means, imagine there are two orders: A and B. They have sequence values of 2 and 3, respectively. If you set their AssignmentRule field values to Preserve route and relative sequence, the sequence values for A and B may change after solving because other orders, breaks, and depot visits can be sequenced before, between, or after A and B. However, B cannot be sequenced before A.</para>
		/// <para>2 (Preserve route)—The solver must always assign the order to the preassigned route during the solve operation. A valid sequence must also be set even though the sequence may or may not be preserved. If the order can&apos;t be assigned to the specified route, it results in an order violation.</para>
		/// <para>3 (Override)—The solver tries to preserve the route and sequence preassignment for the order during the solve operation. However, a new route or sequence for the order may be assigned if it helps minimize the overall value of the objective function. This is the default value.</para>
		/// <para>4 (Anchor first)—The solver ignores the route and sequence preassignment (if any) for the order during the solve operation. It assigns a route to the order and makes it the first order on that route to minimize the overall value of the objective function.</para>
		/// <para>5 (Anchor last)—The solver ignores the route and sequence preassignment (if any) for the order during the solve operation. It assigns a route to the order and makes it the last order on that route to minimize the overall value of the objective function.</para>
		/// <para>This field can&apos;t contain a null value.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at and depart from the order. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The vehicle can approach and depart the order in either direction, so a U-turn is allowed at the incident. This setting can be chosen if it is possible and practical for a vehicle to turn around at the order. This decision may depend on the width of the road and the amount of traffic or whether the order has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 (Right side of vehicle)—When the vehicle approaches and departs the order, the order must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle approaches and departs the order, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—When the vehicle approaches the order, the curb can be on either side of the vehicle; however, the vehicle must depart without turning around.</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider an order on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach an order from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at an order and not have a lane of traffic between the vehicle and the order, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
		/// <para>RouteName</para>
		/// <para>The name of the route to which the order is assigned.</para>
		/// <para>This field is used to preassign an order to a specific route. It can contain a null value, indicating that the order is not preassigned to any route, and the solver identifies the best possible route assignment for the order. If this is set to null, the Sequence field must also be set to null.</para>
		/// <para>After a solve operation, if the order is routed, the RouteName field contains the name of the route to which the order is assigned.</para>
		/// <para>Sequence</para>
		/// <para>This indicates the sequence of the order on its assigned route.</para>
		/// <para>This field is used to specify the relative sequence of an order on the route. This field can contain a null value specifying that the order can be placed anywhere along the route. A null value can only occur together with a null RouteName value.</para>
		/// <para>The input sequence values are positive and unique for each route (shared across renewal depot visits, orders, and breaks) but do not need to start from 1 or be contiguous.</para>
		/// <para>After a solve operation, the Sequence field contains the sequence value of the order on its assigned route. Output sequence values for a route are shared across depot visits, orders, and breaks; start from 1 (at the starting depot); and are consecutive. The smallest possible output sequence value for a routed order is 2, since a route always begins at a depot.</para>
		/// <para>Bearing</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured clockwise from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device equipped with a GPS receiver. Try to include bearing data if you are loading an input location that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps the tool determine on which side of the street the point is.</para>
		/// <para>BearingTol</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the Bearing field value is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than 0 and less than 180. A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15 degrees to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>NavLatency</para>
		/// <para>This field is only used in the solve process if the Bearing and BearingTol fields also have values; however, entering a NavLatency field value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much cost is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device.</para>
		/// <para>The units of NavLatency are the same as the units of the impedance attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Orders { get; set; }

		/// <summary>
		/// <para>Depots</para>
		/// <para>Specifies one or more depots for the given vehicle routing problem. A depot is a location that a vehicle departs from at the beginning of its workday and returns to at the end of the workday. Vehicles are loaded (for deliveries) or unloaded (for pickups) at depots. In some cases, a depot can also act as a renewal location whereby the vehicle can unload or reload and continue performing deliveries and pickups. A depot has open and close times, as specified by a hard time window. Vehicles can&apos;t arrive at a depot outside of this time window.</para>
		/// <para>When specifying the depots, you can set properties for each—such as its name or service time—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>Name</para>
		/// <para>The name of the depot. The StartDepotName and EndDepotName fields on routes reference the names you specify here. It is also referenced by the route renewals, when used.</para>
		/// <para>Depot names are not case sensitive but must be nonempty and unique.</para>
		/// <para>Description</para>
		/// <para>The descriptive information about the depot location. This can contain any textual information and has no restrictions for uniqueness.</para>
		/// <para>For example, if you want to note which region a depot is in or the depot&apos;s address and telephone number, you can enter the information here rather than in the Name field.</para>
		/// <para>TimeWindowStart1</para>
		/// <para>The beginning time of the first time window for the network location. This field can contain a null value; a null value indicates no beginning time.</para>
		/// <para>The time window fields (TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, and TimeWindowEnd2) can contain a time-only value or a date and time value in a date field and cannot be integers representing milliseconds since epoch. The time zone for time window fields is specified using the time_zone_usage_for_time_fields parameter. If a time field such as TimeWindowStart1 has a time-only value (for example, 8:00 a.m.), the date is assumed to be the default date set for the analysis. Using date and time values (for example, 7/11/2010 8:00 a.m.) allows you to set time windows that span multiple days.</para>
		/// <para>When solving a problem that spans multiple time zones, each depot&apos;s time-window values refer to the time zone in which the depot is located.</para>
		/// <para>TimeWindowEnd1</para>
		/// <para>The ending time of the first window for the network location. This field can contain a null value; a null value indicates no ending time.</para>
		/// <para>TimeWindowStart2</para>
		/// <para>The beginning time of the second time window for the network location. This field can contain a null value; a null value indicates that there is no second time window.</para>
		/// <para>If the first time window is null, as specified by the TimeWindowStart1 and TimeWindowEnd1 fields, the second time window must also be null.</para>
		/// <para>If both time windows are not null, they can&apos;t overlap. Also, the second time window must occur after the first.</para>
		/// <para>TimeWindowEnd2</para>
		/// <para>The ending time of the second time window for the network location. This field can contain a null value.</para>
		/// <para>When TimeWindowStart2 and TimeWindowEnd2 are both null, there is no second time window.</para>
		/// <para>When TimeWindowStart2 is not null but TimeWindowEnd2 is null, there is a second time window that has a starting time but no ending time. This is valid.</para>
		/// <para>CurbApproach</para>
		/// <para>0 (Either side of vehicle)—The vehicle can approach and depart the depot in either direction, so a U-turn is allowed at the incident. This setting can be chosen if it is possible and practical for a vehicle to turn around at the depot. This decision may depend on the width of the road and the amount of traffic or whether the depot has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 (Right side of vehicle)—When the vehicle approaches and departs the depot, the depot must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle approaches and departs the depot, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—When the vehicle approaches the depot, the curb can be on either side of the vehicle; however, the vehicle must depart without turning around.</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a depot on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a depot from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at a depot and not have a lane of traffic between the vehicle and the depot, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
		/// <para>Bearing</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured clockwise from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device equipped with a GPS receiver. Try to include bearing data if you are loading an input location that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps the tool determine on which side of the street the point is.</para>
		/// <para>BearingTol</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the Bearing field value is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than 0 and less than 180. A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15 degrees to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>NavLatency</para>
		/// <para>This field is only used in the solve process if the Bearing and BearingTol fields also have values; however, entering a NavLatency field value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much cost is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device.</para>
		/// <para>The units of NavLatency are the same as the units of the impedance attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Depots { get; set; }

		/// <summary>
		/// <para>Routes</para>
		/// <para>Specifies one or more routes that describe vehicle and driver characteristics. A route can have start and end depot service times, a fixed or flexible starting time, time-based operating costs, distance-based operating costs, multiple capacities, various constraints on a driver&apos;s workday, and so on.</para>
		/// <para>The routes can be specified with the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the route. The name must be unique.</para>
		/// <para>The tool generates a unique name at solve time if the field value is null; therefore, entering a value is optional in most cases. However, you must enter a name if your analysis includes breaks, route renewals, route zones, or orders that are preassigned to a route because the route name is used as a foreign key in these cases. Route names not are case sensitive.</para>
		/// <para>StartDepotName</para>
		/// <para>The name of the starting depot for the route. This field is a foreign key to the Name field in Depots.</para>
		/// <para>If the StartDepotName value is null, the route will begin from the first order assigned. Omitting the start depot is useful when the vehicle&apos;s starting location is unknown or irrelevant to your problem. However, when StartDepotName is null, EndDepotName cannot also be null.</para>
		/// <para>Virtual start depots are not allowed if orders or depots are in multiple time zones.</para>
		/// <para>If the route is making deliveries and StartDepotName is null, it is assumed the cargo is loaded on the vehicle at a virtual depot before the route begins. For a route that has no renewal visits, its delivery orders (those with nonzero DeliveryQuantities values in Orders) are loaded at the start depot or virtual depot. For a route that has renewal visits, only the delivery orders before the first renewal visit are loaded at the start depot or virtual depot.</para>
		/// <para>EndDepotName</para>
		/// <para>The name of the ending depot for the route. This field is a foreign key to the Name field in Depots.</para>
		/// <para>StartDepotServiceTime</para>
		/// <para>The service time at the starting depot. This can be used to model the time spent loading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter.</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. The depot service times can be assigned values corresponding to a full truckload or an average truckload, or you can make your own time estimate.</para>
		/// <para>EndDepotServiceTime</para>
		/// <para>The service time at the ending depot. This can be used to model the time spent unloading the vehicle. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the Time Field Units parameter.</para>
		/// <para>The service times at the start and end depots are fixed values (given by the StartDepotServiceTime and EndDepotServiceTime field values) and do not take into account the actual load for a route. For example, the time taken to load a vehicle at the starting depot may depend on the size of the orders. The depot service times can be assigned values corresponding to a full truckload or an average truckload, or you can make your own time estimate.</para>
		/// <para>EarliestStartTime</para>
		/// <para>The earliest allowable starting time for the route. This is used by the solver in conjunction with the time window of the starting depot for determining feasible route start times.</para>
		/// <para>This field can&apos;t contain null values and has a default time-only value of 8:00 AM. The default value is interpreted as 8:00 a.m. on the default date set for the analysis.</para>
		/// <para>When solving a problem that spans multiple time zones, the time zone for EarliestStartTime is the same as the time zone in which the starting depot is located.</para>
		/// <para>LatestStartTime</para>
		/// <para>The latest allowable starting time for the route.</para>
		/// <para>This field can&apos;t contain null values and has a default time-only value of 10:00 AM. The default value is interpreted as 10:00 a.m. on the default date set for the analysis.</para>
		/// <para>When solving a problem that spans multiple time zones, the time zone for LatestStartTime is the same as the time zone in which the starting depot is located.</para>
		/// <para>ArriveDepartDelay</para>
		/// <para>This field stores the amount of travel time needed to accelerate the vehicle to normal travel speeds, decelerate it to a stop, and move it off and on the network (for example, in and out of parking). By including an ArriveDepartDelay value, the VRP solver is deterred from sending many routes to service physically coincident orders.</para>
		/// <para>The cost for this property is incurred between visits to noncoincident orders, depots, and route renewals. For example, when a route starts from a depot and visits the first order, the total arrive/depart delay is added to the travel time. The same is true when traveling from the first order to the second order. If the second and third orders are coincident, the ArriveDepartDelay value is not added between them since the vehicle doesn&apos;t need to move. If the route travels to a route renewal, the value is added to the travel time again.</para>
		/// <para>Although a vehicle must slow down and stop for a break and accelerate afterward, the VRP solver cannot add the ArriveDepartDelay value for breaks. This means that if a route leaves an order, stops for a break, and continues to the next order, the arrive/depart delay is added only once, not twice.</para>
		/// <para>For example, assume there are five coincident orders in a high-rise building, and they are serviced by three different routes. This means three arrive/depart delays are incurred; that is, three drivers need to separately find parking places and enter the same building. However, if the orders can be serviced by one route instead, only one driver needs to park and enter the building, and only one arrive/depart delay is incurred. Since the VRP solver tries to minimize cost, it attempts to limit the arrive/depart delays and thus identify the single-route option. (Note that multiple routes may need to be sent when other constraints—such as specialties, time windows, or capacities—require it.)</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>Capacities</para>
		/// <para>The maximum capacity of the vehicle. You can specify capacity in any dimension, such as weight, volume, or quantity. You can also specify multiple dimensions, for example, weight and volume.</para>
		/// <para>Enter capacities without indicating units. For example, if your vehicle can carry a maximum of 40,000 pounds, enter 40000. You need to remember that the value is in pounds.</para>
		/// <para>If you are tracking multiple dimensions, separate the numeric values with a space. For example, if you are recording the weight and volume of a delivery that weighs 2,000 pounds and has a volume of 100 cubic feet, enter 2000 100. Again, you need to remember the units—in this case, pounds and cubic feet. You also need to remember the sequence in which the values and their corresponding units are entered.</para>
		/// <para>Remembering the units and the unit sequence is important for a couple of reasons: first, so you can reinterpret the information later; second, so you can properly enter values for the DeliveryQuantities and PickupQuantities fields for the orders. Note that the VRP solver simultaneously refers to Capacities, DeliveryQuantities, and PickupQuantities to verify that a route doesn&apos;t become overloaded. Units can&apos;t be entered in the field and the VRP tool can&apos;t make unit conversions. You must enter the values for the three fields using the same units and the same unit sequence to ensure that the values are correctly interpreted. If you combine units or change the sequence in any of the three fields, unwanted results occur with no warning messages. It is recommended that you set up a unit and unit-sequence standard beforehand and continually refer to it when you enter values for these three fields.</para>
		/// <para>An empty string or null value is equivalent to all values being zero. Capacity values can&apos;t be negative.</para>
		/// <para>If the Capacities field has an insufficient number of values in relation to the DeliveryQuantities or PickupQuantities field for orders, the remaining values are treated as zero.</para>
		/// <para>The VRP solver only performs a simple Boolean test to determine whether capacities are exceeded. If a route&apos;s capacity value is greater than or equal to the total quantity being carried, the VRP solver will assume the cargo fits in the vehicle. This could be incorrect, depending on the actual shape of the cargo and the vehicle. For example, the VRP solver allows you to fit a 1,000-cubic-foot sphere into a 1,000-cubic-foot truck that is 8 feet wide. In reality, however, since the sphere is 12.6 feet in diameter, it won&apos;t fit in the 8-foot wide truck.</para>
		/// <para>FixedCost</para>
		/// <para>A fixed monetary cost that is incurred only if the route is used in a solution (that is, it has orders assigned to it). This field can contain null values; a null value indicates zero fixed cost. This cost is part of the total route operating cost.</para>
		/// <para>CostPerUnitTime</para>
		/// <para>The monetary cost incurred—per unit of work time—for the total route duration, including travel times as well as service times and wait times at orders, depots, and breaks. This field can&apos;t contain a null value and has a default value of 1.0.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>CostPerUnitDistance</para>
		/// <para>The monetary cost incurred—per unit of distance traveled—for the route length (total travel distance). This field can contain null values; a null value indicates zero cost.</para>
		/// <para>The unit for this field value is specified by the distance_units parameter.</para>
		/// <para>OvertimeStartTime</para>
		/// <para>The duration of regular work time before overtime computation begins. This field can contain null values; a null value indicates that overtime does not apply.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>For example, if the driver is to be paid overtime when the total route duration extends beyond eight hours, OvertimeStartTime is specified as 480 (8 hours * 60 minutes/hour), given the time units are minutes.</para>
		/// <para>CostPerUnitOvertime</para>
		/// <para>The monetary cost incurred per time unit of overtime work. This field can contain null values; a null value indicates that the CostPerUnitOvertime value is the same as the CostPerUnitTime value.</para>
		/// <para>MaxOrderCount</para>
		/// <para>The maximum allowable number of orders on the route. This field can&apos;t contain null values and has a default value of 30.</para>
		/// <para>MaxTotalTime</para>
		/// <para>The maximum allowable route duration. The route duration includes travel times as well as service and wait times at orders, depots, and breaks. This field can contain null values; a null value indicates that there is no constraint on the route duration.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>MaxTotalTravelTime</para>
		/// <para>The maximum allowable travel time for the route. The travel time includes only the time spent driving on the network and does not include service or wait times.</para>
		/// <para>This field can contain null values; a null value indicates that there is no constraint on the maximum allowable travel time. This field value can&apos;t be larger than the MaxTotalTime field value.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>MaxTotalDistance</para>
		/// <para>The maximum allowable travel distance for the route.</para>
		/// <para>The unit for this field value is specified by the distance_units parameter.</para>
		/// <para>This field can contain null values; a null value indicates that there is no constraint on the maximum allowable travel distance.</para>
		/// <para>SpecialtyNames</para>
		/// <para>A space-separated string containing the names of the specialties required by the order. A null value indicates that the order doesn&apos;t require specialties.</para>
		/// <para>The spelling of any specialties listed in the Orders and Routes classes must match exactly so that the VRP solver can link them together.</para>
		/// <para>To illustrate what specialties are and how they work, assume a lawn care and tree trimming company has a portion of its orders that requires a bucket truck to trim tall trees. The company enters BucketTruck in the SpecialtyNames field for these orders to indicate their special need. SpecialtyNames is left null for the other orders. Similarly, the company also enters BucketTruck in the SpecialtyNames field of routes that are driven by trucks with hydraulic booms. It leaves the field null for the other routes. At solve time, the VRP solver assigns orders without special needs to any route, but it only assigns orders that need bucket trucks to routes that have them.</para>
		/// <para>AssignmentRule</para>
		/// <para>Specifies the rule for assigning the order to a route. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>This field can&apos;t contain a null value.</para>
		/// <para>1 (Include)—The route is included in the solve operation. This is the default value.</para>
		/// <para>2 (Exclude)—The route is excluded from the solve operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		public object Routes { get; set; }

		/// <summary>
		/// <para>Breaks</para>
		/// <para>These are the rest periods, or breaks, for the routes in a given vehicle routing problem. A break is associated with exactly one route and can be taken after completing an order, while en route to an order, or prior to servicing an order. It has a start time and a duration for which the driver may or may not be paid. There are three options for establishing when a break begins: a time window, a maximum travel time, or a maximum work time.</para>
		/// <para>Time-window breaks are not allowed if orders or depots are in multiple time zones unless times are in UTC.</para>
		/// <para>When specifying the breaks, you can set properties for each—such as its name or service time—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>RouteName</para>
		/// <para>The name of the route to which the break applies. Although a break is assigned to exactly one route, many breaks can be assigned to the same route.</para>
		/// <para>This field is a foreign key to the Name field in the routes, so it can&apos;t have a null value.</para>
		/// <para>Precedence</para>
		/// <para>Precedence values sequence the breaks of a given route. Breaks with a precedence value of 1 occur before those with a value of 2, and so on.</para>
		/// <para>All breaks must have a precedence value, regardless of whether they are time-window, maximum-travel-time, or maximum-work-time breaks.</para>
		/// <para>ServiceTime</para>
		/// <para>The duration of the break. This field can&apos;t contain null values. The default value is 60.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>TimeWindowStart</para>
		/// <para>The starting time of the break&apos;s time window. Both a starting time and end time must be specified.</para>
		/// <para>If this field has a value, the MaxTravelTimeBetweenBreaks and MaxCumulWorkTime field values must be null, and all other breaks in the analysis must have null values for MaxTravelTimeBetweenBreaks and MaxCumulWorkTime.</para>
		/// <para>An error will occur at solve time if a route has multiple breaks with overlapping time windows.</para>
		/// <para>The time window fields in breaks can contain a time-only value or a date and time value in a date field and not as integers representing milliseconds since epoch. The time zone for time window fields is specified using the time_zone_usage_for_time_fields parameter. If a time field, such as TimeWindowStart, has a time-only value (for example, 12:00 p.m.), the date is assumed to be the date specified by the Default Date parameter (default_date in Python). Using date and time values (for example, 7/11/2012, 12:00 p.m.) allows you to specify time windows that span two or more days. This is beneficial when a break should be taken sometime before and after midnight.</para>
		/// <para>TimeWindowEnd</para>
		/// <para>The ending time of the break&apos;s time window. Both a starting time and end time must be specified.</para>
		/// <para>If this field has a value, MaxTravelTimeBetweenBreaks and MaxCumulWorkTime must be null, and all other breaks in the analysis must have null values for MaxTravelTimeBetweenBreaks and MaxCumulWorkTime.</para>
		/// <para>MaxViolationTime</para>
		/// <para>This field specifies the maximum allowable violation time for a time-window break. A time window is considered violated if the arrival time falls outside the time range.</para>
		/// <para>A zero value indicates that the time window cannot be violated; that is, the time window is hard. A nonzero value specifies the maximum amount of lateness. For example, the break can begin up to 30 minutes beyond the end of its time window, but the lateness is penalized pursuant to the Time Window Violation Importance parameter.</para>
		/// <para>This property can be null. A null value with TimeWindowStart and TimeWindowEnd values indicates that there is no limit on the allowable violation time. If MaxTravelTimeBetweenBreaks or MaxCumulWorkTime has a value, MaxViolationTime must be null.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>MaxTravelTimeBetweenBreaks</para>
		/// <para>The maximum amount of travel time that can be accumulated before the break is taken. The travel time is accumulated either from the end of the previous break or, if a break has not yet been taken, from the start of the route.</para>
		/// <para>If this is the route&apos;s final break, MaxTravelTimeBetweenBreaks also indicates the maximum travel time that can be accumulated from the final break to the end depot.</para>
		/// <para>This field is designed to limit how long a person can drive until a break is required. For instance, if the time unit for the analysis is set to minutes, and MaxTravelTimeBetweenBreaks has a value of 120, the driver will get a break after two hours of driving. To assign a second break after two more hours of driving, the second break&apos;s MaxTravelTimeBetweenBreaks property must be 120.</para>
		/// <para>If this field has a value, TimeWindowStart, TimeWindowEnd, MaxViolationTime, and MaxCumulWorkTime must be null for an analysis to solve successfully.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>MaxCumulWorkTime</para>
		/// <para>The maximum amount of work time that can be accumulated before the break is taken. Work time is always accumulated from the beginning of the route.</para>
		/// <para>Work time is the sum of travel time and service times at orders, depots, and breaks. Note, however, that this excludes wait time, which is the time a route (or driver) spends waiting at an order or depot for a time window to begin.</para>
		/// <para>This field limits how long a person can work until a break is required. For example, if the time unit for the analysis is set to minutes, MaxCumulWorkTime has a value of 120, and ServiceTime has a value of 15, the driver will get a 15-minute break after two hours of work.</para>
		/// <para>Continuing with the last example, assume a second break is needed after three more hours of work. To specify this break, enter 315 (five hours and 15 minutes) as the second break&apos;s MaxCumulWorkTime value. This number includes the MaxCumulWorkTime and ServiceTime values of the preceding break, along with the three additional hours of work time before granting the second break. To avoid taking maximum-work-time breaks prematurely, remember that they accumulate work time from the beginning of the route and that work time includes the service time at previously visited depots, orders, and breaks.</para>
		/// <para>If this field has a value, TimeWindowStart, TimeWindowEnd, MaxViolationTime, and MaxTravelTimeBetweenBreaks must be null for an analysis to solve successfully.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>IsPaid</para>
		/// <para>A Boolean value indicating whether the break is paid or unpaid. Setting this field value to 1 indicates that the time spent at the break is included in the route cost computation and overtime determination. A value of 0 indicates otherwise. The default value is 1.</para>
		/// <para>Sequence</para>
		/// <para>Indicates the sequence of the break on its route. This field can contain null values, which causes the solver to assign the break sequence. If sequence values are specified, they should be positive and unique for each route (shared across renewal depot visits, orders, and breaks) but need not start from 1 or be contiguous.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		public object Breaks { get; set; }

		/// <summary>
		/// <para>Time Units</para>
		/// <para>The time units for all time-based field values in the analysis. Many features and records in a VRP analysis have fields for storing time values, such as ServiceTime for orders and CostPerUnitTime for routes. To minimize data entry requirements, these field values don&apos;t include units. Instead, all distance-based field values must be entered in the same units, and this parameter is used to specify the units of those values.</para>
		/// <para>Seconds—The time unit is seconds.</para>
		/// <para>Minutes—The time unit is minutes.</para>
		/// <para>Hours—The time unit is hours.</para>
		/// <para>Days—The time unit is days.</para>
		/// <para>Note that output time-based fields use the same units specified by this parameter.</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The distance units for all distance-based field values in the analysis. Many features and records in a VRP analysis have fields for storing distance values, such as MaxTotalDistance and CostPerUnitDistance for routes. To minimize data entry requirements, these field values don&apos;t include units. Instead, all distance-based field values must be entered in the same units, and this parameter is used to specify the units of those values.</para>
		/// <para>Meters—The linear unit is meters.</para>
		/// <para>Kilometers—The linear unit is kilometers.</para>
		/// <para>Feet—The linear unit is feet.</para>
		/// <para>Yards—The linear unit is yards.</para>
		/// <para>Miles—The linear unit is miles.</para>
		/// <para>Nautical Miles—The linear unit is nautical miles.</para>
		/// <para>Note that output distance-based fields use the same units specified by this parameter.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Analysis Region</para>
		/// <para>The region in which the analysis will be performed. If a value is not specified for this parameter, the tool will automatically calculate the region name based on the location of the input points. Setting the name of the region is required only if the automatic detection of the region name is not accurate for your inputs.</para>
		/// <para>To specify a region, use one of the following values:</para>
		/// <para>Europe—The analysis region is Europe.</para>
		/// <para>Japan—The analysis region is Japan.</para>
		/// <para>Korea—The analysis region is Korea.</para>
		/// <para>Middle East And Africa—The analysis region is Middle East and Africa.</para>
		/// <para>North America—The analysis region is North America.</para>
		/// <para>South America—The analysis region is South America.</para>
		/// <para>South Asia—The analysis region is South Asia.</para>
		/// <para>Thailand—The analysis region is Thailand.</para>
		/// <para>The following region names are no longer supported and will be removed in future releases. If you specify one of the deprecated region names, the tool automatically assigns a supported region name for your region.</para>
		/// <para>Greece redirects to Europe</para>
		/// <para>India redirects to SouthAsia</para>
		/// <para>Oceania redirects to SouthAsia</para>
		/// <para>SouthEastAsia redirects to SouthAsia</para>
		/// <para>Taiwan redirects to SouthAsia</para>
		/// <para><see cref="AnalysisRegionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object AnalysisRegion { get; set; }

		/// <summary>
		/// <para>Default Date</para>
		/// <para>The default date for time field values that specify a time of day without including a date. You can find these time fields in various input parameters, such as the ServiceTime attributes in the orders and breaks parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object DefaultDate { get; set; }

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// <para>Specifies whether to restrict or permit the service area to make U-turns at junctions. To understand the parameter values, consider the following terminology: a junction is a point where a street segment ends and potentially connects to one or more other segments; a pseudojunction is a point where exactly two streets connect to one another; an intersection is a point where three or more streets connect; and a dead end is where one street segment ends without connecting to another.</para>
		/// <para>Allow UTurns—U-turns are permitted everywhere. Allowing U-turns implies that the vehicle can turn around at any junction and double back on the same street. This is the default value.</para>
		/// <para>No UTurns—U-turns are prohibited at all junctions: pseudojunctions, intersections, and dead ends. Note, however, that U-turns may be permitted even when this option is chosen. To prevent U-turns at incidents and facilities, set the CurbApproach field value to prohibit U-turns.</para>
		/// <para>Allow Dead Ends Only—U-turns are prohibited at all junctions, except those that have only one connected street feature (a dead end).</para>
		/// <para>Allow Dead Ends and Intersections Only—U-turns are prohibited at pseudojunctions where exactly two adjacent streets meet, but U-turns are permitted at intersections and dead ends. This prevents turning around in the middle of the road where one length of road happens to be digitized as two street features.</para>
		/// <para>The value you provide for this parameter is ignored unless Travel Mode is set to Custom, which is the default value.</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object UturnPolicy { get; set; } = "ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY";

		/// <summary>
		/// <para>Time Window Factor</para>
		/// <para>Specifies the importance of honoring time windows.</para>
		/// <para>High—Importance is placed on arriving at stops on time rather than minimizing drive times. For example, organizations that make time-critical deliveries or that are concerned with customer service choose High.</para>
		/// <para>Medium—Importance is balanced between minimizing drive times and arriving within time windows. This is the default value.</para>
		/// <para>Low—Importance is placed on minimizing drive times and rather than arriving at stops on time. You may want to use this setting if you have a growing backlog of service requests. For the purpose of servicing more orders in a day and reducing the backlog, you can choose Low even though customers may be inconvenienced with your late arrivals.</para>
		/// <para><see cref="TimeWindowFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object TimeWindowFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Spatially Cluster Routes</para>
		/// <para>Specifies whether routes will be spatially clustered.</para>
		/// <para>CLUSTER (True)—Dynamic seed points are automatically created for all routes, and the orders assigned to an individual route are spatially clustered. Clustering orders tends to keep routes in smaller areas and reduce how often different route lines intersect one another; yet, clustering also tends to increase overall travel times.</para>
		/// <para>NO_CLUSTER (False)—Dynamic seed points aren&apos;t created. Choose this option if route zones are specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Advanced Analysis")]
		public object SpatiallyClusterRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Route Zones</para>
		/// <para>Delineates work territories for given routes. A route zone is a polygon feature used to constrain routes to servicing only those orders that fall within or near the specified area. The following are examples of when route zones may be useful:</para>
		/// <para>Some of your employees don&apos;t have the required permits to perform work in certain states or communities. You can create a hard route zone so they only visit orders in areas where they meet the requirements.</para>
		/// <para>One of your vehicles breaks down frequently and you want to minimize response time by having it only visit orders that are close to your maintenance garage. You can create a soft or hard route zone to keep the vehicle nearby.</para>
		/// <para>When specifying the route zones, you must set properties for each—such as its associated route—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>RouteName</para>
		/// <para>The name of the route to which this zone applies. A route zone can have a maximum of one associated route. This field can&apos;t contain null values, and it is a foreign key to the Name field in routes.</para>
		/// <para>IsHardZone</para>
		/// <para>A Boolean value indicating a hard or soft route zone. A True value indicates that the route zone is hard; that is, an order that falls outside the route zone polygon can&apos;t be assigned to the route. The default value is 1 (True). A False value (0) indicates that such orders can still be assigned, but the cost of servicing the order is weighted by a function based on the Euclidean distance from the route zone. Basically, this means that as the straight-line distance from the soft zone to the order increases, the likelihood of the order being assigned to the route decreases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Advanced Analysis")]
		public object RouteZones { get; set; }

		/// <summary>
		/// <para>Route Renewals</para>
		/// <para>Specifies the intermediate depots that routes can visit to reload or unload the cargo they are delivering or picking up. Specifically, a route renewal links a route to a depot. The relationship indicates the route can renew (reload or unload while en route) at the associated depot.</para>
		/// <para>Route renewals can be used to model scenarios in which a vehicle picks up a full load of deliveries at the starting depot, services the orders, returns to the depot to renew its load of deliveries, and continues servicing more orders. For example, in propane gas delivery, the vehicle may make several deliveries until its tank is nearly or completely depleted, visit a refueling point, and make more deliveries.</para>
		/// <para>Here are a few rules and options to consider:</para>
		/// <para>The reload/unload point, or renewal location, can be different from the start or end depot.</para>
		/// <para>Each route can have one or many predetermined renewal locations.</para>
		/// <para>A renewal location can be used more than once by a single route.</para>
		/// <para>In cases where there may be several potential renewal locations for a route, the closest available renewal location is identified by the solver.</para>
		/// <para>When specifying the route renewals, you must set properties for each—such as the name of the depot where the route renewal can occur—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>DepotName</para>
		/// <para>The name of the depot where this renewal takes place. This field can&apos;t contain a null value and is a foreign key to the Name field in depots.</para>
		/// <para>RouteName</para>
		/// <para>The name of the route to which this renewal applies. This field can&apos;t contain a null value and is a foreign key to the Name field in routes.</para>
		/// <para>ServiceTime</para>
		/// <para>The service time for the renewal. This field can contain a null value; a null value indicates zero service time.</para>
		/// <para>The unit for this field value is specified by the time_units parameter.</para>
		/// <para>The time taken to load a vehicle at a renewal depot may depend on the size of the vehicle and how full or empty the vehicle is. However, the service time for a route renewal is a fixed value and does not take into account the actual load. As such, the renewal service time should be given a value corresponding to a full truckload, an average truckload, or another time estimate of your choice.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object RouteRenewals { get; set; }

		/// <summary>
		/// <para>Order Pairs</para>
		/// <para>Pairs pick up and deliver orders so they are serviced by the same route. Specifying order pairs prevents the analysis from assigning only one of the orders to a route: either both orders are assigned to the same route, or neither order is assigned.</para>
		/// <para>Sometimes it is necessary for the pick up and delivery of orders to be paired. For example, a courier company may need to have a route pick up a high-priority package from one order and deliver it to another without returning to a depot, or sorting station, to minimize delivery time. These related orders can be assigned to the same route with the appropriate sequence using order pairs. Restrictions on how long the package can stay in the vehicle can also be assigned; for example, the package might be a blood sample that must be transported from the doctor&apos;s office to the lab within two hours.</para>
		/// <para>Some situations may require two pairs of orders. For example, suppose you want to transport a senior citizen from her home to the doctor and then back home. The ride from her home to the doctor is one pair of orders with a desired arrival time at the doctor, while the ride from the doctor to her home is another pair with a desired pickup time.</para>
		/// <para>When specifying the order pairs, you must set properties for each—such as the names of the two orders—using the following attributes:</para>
		/// <para>ObjectID</para>
		/// <para>The system-managed ID field.</para>
		/// <para>FirstOrderName</para>
		/// <para>The name of the first order of the pair. This field is a foreign key to the Name field in orders.</para>
		/// <para>SecondOrderName</para>
		/// <para>The name of the second order of the pair. This field is a foreign key to the Name field in orders.</para>
		/// <para>The first order in the pair must be a pickup order; that is, the value for its DeliveryQuantities field is null. The second order in the pair must be a delivery order; that is, the value for its PickupQuantities field is null. The quantity picked up at the first order must agree with the quantity delivered at the second order. As a special case, both orders may have zero quantities for scenarios where capacities are not used.</para>
		/// <para>The order quantities are not loaded or unloaded at depots.</para>
		/// <para>MaxTransitTime</para>
		/// <para>The maximum transit time for the pair. The transit time is the duration from the departure time of the first order to the arrival time at the second order. This constraint limits the time-on-vehicle, or ride time, between the two orders. When a vehicle is carrying people or perishable goods, the ride time is typically shorter than that of a vehicle carrying packages or nonperishable goods. This field can contain null values; a null value indicates that there is no constraint on the ride time.</para>
		/// <para>The unit for this field value is specified by the timeUnits property of the analysis object.</para>
		/// <para>Excess transit time (measured with respect to the direct travel time between order pairs) can be tracked and weighted by the solver. Because of this, you can direct the VRP solver to take one of three approaches:</para>
		/// <para>Minimize the overall excess transit time, regardless of the increase in travel cost for the fleet.</para>
		/// <para>Find a solution that balances overall violation time and travel cost.</para>
		/// <para>Ignore the overall excess transit time and, instead, minimize the travel cost for the fleet.</para>
		/// <para>By assigning an importance level for the excess_transit_factor parameter, you are, in effect, choosing one of these three approaches. Regardless of the importance level, the solver will always return an error if the MaxTransitTime value is surpassed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object OrderPairs { get; set; }

		/// <summary>
		/// <para>Excess Transit Factor</para>
		/// <para>Specifies the importance of reducing excess transit time of order pairs. Excess transit time is the amount of time exceeding the time required to travel directly between the paired orders. Excess time can be caused by driver breaks or travel to intermediate orders and depots.</para>
		/// <para>High—Importance is placed on the least excess transit time between paired orders at the expense of increasing the overall travel costs. This setting is typically used when transporting people between paired orders and you want to shorten their ride time. This is characteristic of taxi services.</para>
		/// <para>Medium—Importance is balanced between reducing excess transit time and reducing the overall solution cost. This is the default value.</para>
		/// <para>Low—Importance is placed on minimizing overall solution cost, regardless of excess transit time. This setting is commonly used with courier services. Since couriers transport packages as opposed to people, they don&apos;t worry about ride time. Low allows the couriers to service paired orders in the proper sequence and minimize the overall solution cost.</para>
		/// <para><see cref="ExcessTransitFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object ExcessTransitFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Point Barriers</para>
		/// <para>Use this parameter to specify one or more points that will act as temporary restrictions or represent additional time or distance that may be required to travel on the underlying streets. For example, a point barrier can be used to represent a fallen tree along a street or a time delay spent at a railroad crossing.</para>
		/// <para>The tool imposes a limit of 250 points that can be added as barriers.</para>
		/// <para>When specifying point barriers, you can set properties for each, such as its name or barrier type, using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the barrier.</para>
		/// <para>BarrierType</para>
		/// <para>Specifies whether the point barrier restricts travel completely or adds time or distance when it is crossed. The value for this attribute is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Restriction)—Prohibits travel through the barrier. The barrier is referred to as a restriction point barrier since it acts as a restriction.</para>
		/// <para>2 (Added Cost)—Traveling through the barrier increases the travel time or distance by the amount specified in the Additional_Time, Additional_Distance, or Additional_Cost field. This barrier type is referred to as an added cost point barrier.</para>
		/// <para>Additional_Time</para>
		/// <para>The added travel time when the barrier is traversed. This field is applicable only for added-cost barriers and when the Measurement Units parameter value is time based.</para>
		/// <para>This field value must be greater than or equal to zero, and its units must be the same as those specified in the Measurement Units parameter.</para>
		/// <para>Additional_Distance</para>
		/// <para>The added distance when the barrier is traversed. This field is applicable only for added-cost barriers and when the Measurement Units parameter value is distance based.</para>
		/// <para>The field value must be greater than or equal to zero, and its units must be the same as those specified in the Measurement Units parameter.</para>
		/// <para>Additional_Cost</para>
		/// <para>The added cost when the barrier is traversed. This field is applicable only for added-cost barriers when the Measurement Units parameter value is neither time based nor distance based.</para>
		/// <para>FullEdge</para>
		/// <para>Specifies how the restriction point barriers are applied to the edge elements during the analysis. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (False)—Permits travel on the edge up to the barrier but not through it. This is the default value.</para>
		/// <para>1 (True)—Restricts travel anywhere on the associated edge.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction of traffic that is affected by the barrier. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The barrier affects travel over the edge in both directions.</para>
		/// <para>1 (Right side of vehicle)—Vehicles are only affected if the barrier is on their right side during the approach. Vehicles that traverse the same edge but approach the barrier on their left side are not affected by the barrier.</para>
		/// <para>2 (Left side of vehicle)—Vehicles are only affected if the barrier is on their left side during the approach. Vehicles that traverse the same edge but approach the barrier on their right side are not affected by the barrier.</para>
		/// <para>Because junctions are points and don&apos;t have a side, barriers on junctions affect all vehicles regardless of the curb approach.</para>
		/// <para>The CurbApproach attribute works with both types of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a facility on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a facility from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, to arrive at a facility and not have a lane of traffic between the vehicle and the facility, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
		/// <para>Bearing</para>
		/// <para>The direction in which a point is moving. The units are degrees and are measured clockwise from true north. This field is used in conjunction with the BearingTol field.</para>
		/// <para>Bearing data is usually sent automatically from a mobile device equipped with a GPS receiver. Try to include bearing data if you are loading an input location that is moving, such as a pedestrian or a vehicle.</para>
		/// <para>Using this field tends to prevent adding locations to the wrong edges, which can occur when a vehicle is near an intersection or an overpass, for example. Bearing also helps the tool determine on which side of the street the point is.</para>
		/// <para>BearingTol</para>
		/// <para>The bearing tolerance value creates a range of acceptable bearing values when locating moving points on an edge using the Bearing field. If the Bearing field value is within the range of acceptable values that are generated from the bearing tolerance on an edge, the point can be added as a network location there; otherwise, the closest point on the next-nearest edge is evaluated.</para>
		/// <para>The units are in degrees, and the default value is 30. Values must be greater than 0 and less than 180. A value of 30 means that when Network Analyst attempts to add a network location on an edge, a range of acceptable bearing values is generated 15 degrees to either side of the edge (left and right) and in both digitized directions of the edge.</para>
		/// <para>NavLatency</para>
		/// <para>This field is only used in the solve process if the Bearing and BearingTol fields also have values; however, entering a NavLatency field value is optional, even when values are present in Bearing and BearingTol. NavLatency indicates how much cost is expected to elapse from the moment GPS information is sent from a moving vehicle to a server and the moment the processed route is received by the vehicle&apos;s navigation device.</para>
		/// <para>The units of NavLatency are the same as the units of the impedance attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object PointBarriers { get; set; }

		/// <summary>
		/// <para>Line Barriers</para>
		/// <para>Use this parameter to specify one or more lines that prohibit travel anywhere the lines intersect the streets. For example, a parade or protest that blocks traffic across several street segments can be modeled with a line barrier. A line barrier can also quickly fence off several roads from being traversed, thereby channeling possible routes away from undesirable parts of the street network.</para>
		/// <para>The tool imposes a limit on the number of streets you can restrict using the Line Barriers parameter. While there is no limit to the number of lines you can specify as line barriers, the combined number of streets intersected by all the lines cannot exceed 500.</para>
		/// <para>When specifying the line barriers, you can set name and barrier type properties for each using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the barrier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// <para>Use this parameter to specify polygons that either completely restrict travel or proportionately scale the time or distance required to travel on the streets intersected by the polygons.</para>
		/// <para>The service imposes a limit on the number of streets you can restrict using the Polygon Barriers parameter. While there is no limit to the number of polygons you can specify as polygon barriers, the combined number of streets intersected by all the polygons cannot exceed 2,000.</para>
		/// <para>When specifying the polygon barriers, you can set properties for each, such as its name or barrier type, using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the barrier.</para>
		/// <para>BarrierType</para>
		/// <para>Specifies whether the barrier restricts travel completely or scales the cost (such as time or distance) for traveling through it. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Restriction)—Prohibits traveling through any part of the barrier. The barrier is referred to as a restriction polygon barrier since it prohibits traveling on streets intersected by the barrier. One use of this type of barrier is to model floods covering areas of the street that make traveling on those streets impossible.</para>
		/// <para>1 (Scaled Cost)—Scales the cost (such as travel time or distance) required to travel the underlying streets by a factor specified using the ScaledTimeFactor or ScaledDistanceFactor field. If the streets are partially covered by the barrier, the travel time or distance is apportioned and then scaled. For example, a factor of 0.25 means that travel on underlying streets is expected to be four times faster than normal. A factor of 3.0 means it is expected to take three times longer than normal to travel on underlying streets. This barrier type is referred to as a scaled-cost polygon barrier. It can be used to model storms that reduce travel speeds in specific regions.</para>
		/// <para>ScaledTimeFactor</para>
		/// <para>This is the factor by which the travel time of the streets intersected by the barrier is multiplied. The field value must be greater than zero.</para>
		/// <para>This field is applicable only for scaled-cost barriers and when the Measurement Units parameter is time-based.</para>
		/// <para>ScaledDistanceFactor</para>
		/// <para>This is the factor by which the distance of the streets intersected by the barrier is multiplied. The field value must be greater than zero.</para>
		/// <para>This field is applicable only for scaled-cost barriers and when the Measurement Units parameter is distance-based.</para>
		/// <para>ScaledCostFactor</para>
		/// <para>This is the factor by which the cost of the streets intersected by the barrier is multiplied. The field value must be greater than zero.</para>
		/// <para>This field is applicable only for scaled-cost barriers when the Measurement Units parameter is neither time-based nor distance-based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Use Hierarchy</para>
		/// <para>Specifies whether hierarchy will be used when finding the best routes.</para>
		/// <para>Checked (True)—Hierarchy will be used when finding routes. When hierarchy is used, the tool identifies higher-order streets, such as freeways, before lower-order streets, such as local roads, and can be used to simulate the driver preference of traveling on freeways instead of local roads even if that means a longer trip. This is especially true when finding routes to faraway locations, because drivers on long-distance trips tend to prefer traveling on freeways, where stops, intersections, and turns can be avoided. Using hierarchy is computationally faster, especially for long-distance routes, as the tool identifies the best route from a relatively smaller subset of streets.</para>
		/// <para>Unchecked (False)—Hierarchy will not be used when finding routes. If hierarchy is not used, the tool considers all the streets and doesn&apos;t necessarily identify higher-order streets when finding the route. This is often used when finding short-distance routes within a city.</para>
		/// <para>The tool automatically reverts to using hierarchy if the straight-line distance between orders, depots, or orders and depots is greater than 50 miles, even if this parameter is unchecked (False).</para>
		/// <para>This parameter is ignored unless Travel Mode is set to Custom, which is the default value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object UseHierarchyInAnalysis { get; set; } = "true";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>The restrictions that will be honored by the tool when finding the best routes.</para>
		/// <para>A restriction represents a driving preference or requirement. In most cases, restrictions cause roads to be prohibited. For instance, using the Avoid Toll Roads restriction will result in a route that will include toll roads only when it is required to travel on toll roads to visit an incident or a facility. Height Restriction makes it possible to route around any clearances that are lower than the height of your vehicle. If you are carrying corrosive materials on your vehicle, using the Any Hazmat Prohibited restriction prevents hauling the materials along roads where it is marked illegal to do so.</para>
		/// <para>The values you provide for this parameter are ignored unless Travel Mode is set to Custom.</para>
		/// <para>Some restrictions require an additional value to be specified for their use. This value must be associated with the restriction name and a specific parameter intended to work with the restriction. You can identify such restrictions if their names appear in the AttributeName column in the Attribute Parameter Values parameter. The ParameterValue field should be specified in the Attribute Parameter Values parameter for the restriction to be correctly used when finding traversable roads.</para>
		/// <para>Some restrictions are supported only in certain countries; their availability is stated by region in the list below. Of the restrictions that have limited availability within a region, you can determine whether the restriction is available in a particular country by reviewing the table in the Country list section of Network analysis coverage. If a country has a value of Yes in the Logistics Attribute column, the restriction with select availability in the region is supported in that country. If you specify restriction names that are not available in the country where your incidents are located, the service ignores the invalid restrictions. The service also ignores restrictions when the Restriction Usage attribute parameter value is between 0 and 1 (see the Attribute Parameter Value parameter). It prohibits all restrictions when the Restriction Usage parameter value is greater than 0.</para>
		/// <para>The tool supports the following restrictions:</para>
		/// <para>Any Hazmat Prohibited—The results will not include roads where transporting any kind of hazardous material is prohibited. Availability: Select countries in North America and Europe</para>
		/// <para>Avoid Carpool Roads—The results will avoid roads that are designated exclusively for car pool (high-occupancy) vehicles. Availability: All countries</para>
		/// <para>Avoid Express Lanes—The results will avoid roads designated as express lanes. Availability: All countries</para>
		/// <para>Avoid Ferries—The results will avoid ferries. Availability: All countries</para>
		/// <para>Avoid Gates—The results will avoid roads where there are gates, such as keyed access or guard-controlled entryways.Availability: All countries</para>
		/// <para>Avoid Limited Access Roads—The results will avoid roads that are limited-access highways.Availability: All countries</para>
		/// <para>Avoid Private Roads—The results will avoid roads that are not publicly owned and maintained.Availability: All countries</para>
		/// <para>Avoid Roads Unsuitable for Pedestrians—The results will avoid roads that are unsuitable for pedestrians.Availability: All countries</para>
		/// <para>Avoid Stairways—The results will avoid all stairways on a pedestrian-suitable route.Availability: All countries</para>
		/// <para>Avoid Toll Roads—The results will avoid all toll roads for automobiles.Availability: All countries</para>
		/// <para>Avoid Toll Roads for Trucks—The results will avoid all toll roads for trucks.Availability: All countries</para>
		/// <para>Avoid Truck Restricted Roads—The results will avoid roads where trucks are not allowed, except when making deliveries.Availability: All countries</para>
		/// <para>Avoid Unpaved Roads—The results will avoid roads that are not paved (for example, dirt, gravel, and so on). Availability: All countries</para>
		/// <para>Axle Count Restriction—The results will not include roads where trucks with the specified number of axles are prohibited. The number of axles can be specified using the Number of Axles restriction parameter.Availability: Select countries in North America and Europe</para>
		/// <para>Driving a Bus—The results will not include roads where buses are prohibited. Using this restriction will also ensure that the results will honor one-way streets. Availability: All countries</para>
		/// <para>Driving a Taxi—The results will not include roads where taxis are prohibited. Using this restriction will also ensure that the results will honor one-way streets. Availability: All countries</para>
		/// <para>Driving a Truck—The results will not include roads where trucks are prohibited. Using this restriction will also ensure that the results will honor one-way streets. Availability: All countries</para>
		/// <para>Driving an Automobile—The results will not include roads where automobiles are prohibited. Using this restriction will also ensure that the results will honor one-way streets. Availability: All countries</para>
		/// <para>Driving an Emergency Vehicle—The results will not include roads where emergency vehicles are prohibited. Using this restriction will also ensure that the results will honor one-way streets.Availability: All countries</para>
		/// <para>Height Restriction—The results will not include roads where the vehicle height exceeds the maximum allowed height for the road. The vehicle height can be specified using the Vehicle Height (meters) restriction parameter. Availability: Select countries in North America and Europe</para>
		/// <para>Kingpin to Rear Axle Length Restriction—The results will not include roads where the vehicle length exceeds the maximum allowed kingpin to rear axle for all trucks on the road. The length between the vehicle kingpin and the rear axle can be specified using the Vehicle Kingpin to Rear Axle Length (meters) restriction parameter. Availability: Select countries in North America and Europe</para>
		/// <para>Length Restriction—The results will not include roads where the vehicle length exceeds the maximum allowed length for the road. The vehicle length can be specified using the Vehicle Length (meters) restriction parameter. Availability: Select countries in North America and Europe</para>
		/// <para>Preferred for Pedestrians—The results will use preferred routes suitable for pedestrian navigation. Availability: Select countries in North America and Europe</para>
		/// <para>Riding a Motorcycle—The results will not include roads where motorcycles are prohibited. Using this restriction will also ensure that the results will honor one-way streets.Availability: All countries</para>
		/// <para>Roads Under Construction Prohibited—The results will not include roads that are under construction.Availability: All countries</para>
		/// <para>Semi or Tractor with One or More Trailers Prohibited—The results will not include roads where semis or tractors with one or more trailers are prohibited. Availability: Select countries in North America and Europe</para>
		/// <para>Single Axle Vehicles Prohibited—The results will not include roads where vehicles with single axles are prohibited.Availability: Select countries in North America and Europe</para>
		/// <para>Tandem Axle Vehicles Prohibited—The results will not include roads where vehicles with tandem axles are prohibited.Availability: Select countries in North America and Europe</para>
		/// <para>Through Traffic Prohibited—The results will not include roads where through traffic (nonlocal) is prohibited.Availability: All countries</para>
		/// <para>Truck with Trailers Restriction—The results will not include roads where trucks with the specified number of trailers on the truck are prohibited. The number of trailers on the truck can be specified using the Number of Trailers on Truck restriction parameter.Availability: Select countries in North America and Europe</para>
		/// <para>Use Preferred Hazmat Routes—The results will prefer roads that are designated for transporting any kind of hazardous materials. Availability: Select countries in North America and Europe</para>
		/// <para>Use Preferred Truck Routes—The results will prefer roads that are designated as truck routes, such as the roads that are part of the national network as specified by the National Surface Transportation Assistance Act in the United States, or roads that are designated as truck routes by the state or province, or roads that are preferred by truckers when driving in an area.Availability: Select countries in North America and Europe</para>
		/// <para>Walking—The results will not include roads where pedestrians are prohibited.Availability: All countries</para>
		/// <para>Weight Restriction—The results will not include roads where the vehicle weight exceeds the maximum allowed weight for the road. The vehicle weight can be specified using the Vehicle Weight (kilograms) restriction parameter.Availability: Select countries in North America and Europe</para>
		/// <para>Weight per Axle Restriction—The results will not include roads where the vehicle weight per axle exceeds the maximum allowed weight per axle for the road. The vehicle weight per axle can be specified using the Vehicle Weight per Axle (kilograms) restriction parameter.Availability: Select countries in North America and Europe</para>
		/// <para>Width Restriction—The results will not include roads where the vehicle width exceeds the maximum allowed width for the road. The vehicle width can be specified using the Vehicle Width (meters) restriction parameter.Availability: Select countries in North America and Europe</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object Restrictions { get; set; } = "'Avoid Carpool Roads';'Avoid Express Lanes';'Avoid Gates';'Avoid Private Roads';'Avoid Unpaved Roads';'Driving an Automobile';'Roads Under Construction Prohibited';'Through Traffic Prohibited'";

		/// <summary>
		/// <para>Attribute Parameter Values</para>
		/// <para>Use this parameter to specify additional values required by an attribute or restriction, such as to specify whether the restriction prohibits, avoids, or prefers travel on restricted roads. If the restriction is meant to avoid or prefer roads, you can further specify the degree to which they are avoided or preferred using this parameter. For example, you can choose to never use toll roads, avoid them as much as possible, or prefer them.</para>
		/// <para>The values you provide for this parameter are ignored unless Travel Mode is set to Custom.</para>
		/// <para>If you specify the Attribute Parameter Values parameter from a feature class, the field names on the feature class must match the fields as follows:</para>
		/// <para>AttributeName—The name of the restriction.</para>
		/// <para>ParameterName—The name of the parameter associated with the restriction. A restriction can have one or more ParameterName field values based on its intended use.</para>
		/// <para>ParameterValue—The value for ParameterName used by the tool when evaluating the restriction.</para>
		/// <para>The Attribute Parameter Values parameter is dependent on the Restrictions parameter. The ParameterValue field is applicable only if the restriction name is specified as the value for the Restrictions parameter.</para>
		/// <para>In Attribute Parameter Values, each restriction (listed as AttributeName) has a ParameterName field value, Restriction Usage, that specifies whether the restriction prohibits, avoids, or prefers travel on the roads associated with the restriction as well as the degree to which the roads are avoided or preferred. The Restriction Usage ParameterName can be assigned any of the following string values or their equivalent numeric values listed in the parentheses:</para>
		/// <para>PROHIBITED (-1)—Travel on the roads using the restriction is completely prohibited.</para>
		/// <para>AVOID_HIGH (5)—It is highly unlikely the tool will include in the route the roads that are associated with the restriction.</para>
		/// <para>AVOID_MEDIUM (2)—It is unlikely the tool will include in the route the roads that are associated with the restriction.</para>
		/// <para>AVOID_LOW (1.3)—It is somewhat unlikely the tool will include in the route the roads that are associated with the restriction.</para>
		/// <para>PREFER_LOW (0.8)—It is somewhat likely the tool will include in the route the roads that are associated with the restriction.</para>
		/// <para>PREFER_MEDIUM (0.5)—It is likely the tool will include in the route the roads that are associated with the restriction.</para>
		/// <para>PREFER_HIGH (0.2)—It is highly likely the tool will include in the route the roads that are associated with the restriction.</para>
		/// <para>In most cases, you can use the default value, PROHIBITED, as the Restriction Usage value if the restriction is dependent on a vehicle characteristic such as vehicle height. However, in some cases, the Restriction Usage value depends on your routing preferences. For example, the Avoid Toll Roads restriction has the default value of AVOID_MEDIUM for the Restriction Usage attribute. This means that when the restriction is used, the tool will try to route around toll roads when it can. AVOID_MEDIUM also indicates how important it is to avoid toll roads when finding the best route; it has a medium priority. Choosing AVOID_LOW puts lower importance on avoiding tolls; choosing AVOID_HIGH instead gives it a higher importance and thus makes it more acceptable for the service to generate longer routes to avoid tolls. Choosing PROHIBITED entirely disallows travel on toll roads, making it impossible for a route to travel on any portion of a toll road. Keep in mind that avoiding or prohibiting toll roads, and thus avoiding toll payments, is the objective for some. In contrast, others prefer to drive on toll roads, because avoiding traffic is more valuable to them than the money spent on tolls. In the latter case, choose PREFER_LOW, PREFER_MEDIUM, or PREFER_HIGH as the value for Restriction Usage. The higher the preference, the farther the tool will go out of its way to travel on the roads associated with the restriction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Populate Route Lines</para>
		/// <para>Specifies whether the output route line will be generated.</para>
		/// <para>Checked (True)—The output routes will have the exact shape of the underlying streets.</para>
		/// <para>Unchecked (False)—No shape is generated for the output routes, yet the routes will still contain tabular information about the solution. You can&apos;t generate driving directions if route lines aren&apos;t created.</para>
		/// <para>When the Route Shape parameter is set to True Shape, the generalization of the route shape can be further controlled using the appropriate values for the Route Line Simplification Tolerance parameter.</para>
		/// <para>No matter which value you choose for the Route Shape parameter, the best routes are always determined by minimizing the travel along the streets, never using the straight-line distance. This means that only the route shapes are different, not the underlying streets that are searched when finding the route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object PopulateRouteLines { get; set; } = "true";

		/// <summary>
		/// <para>Route Line Simplification Tolerance</para>
		/// <para>The amount by which the geometry of the output lines will be simplified for routes and directions.</para>
		/// <para>The value provided for this parameter is ignored unless Travel Mode is set to Custom, which is the default value.</para>
		/// <para>The tool ignores this parameter if the populate_route_lines parameter is unchecked (False).</para>
		/// <para>Simplification maintains critical points on a route, such as turns at intersections, to define the essential shape of the route and removes other points. The simplification distance you specify is the maximum allowable offset that the simplified line can deviate from the original line. Simplifying a line reduces the number of vertices that are part of the route geometry. This improves the tool execution time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Custom Travel Mode")]
		public object RouteLineSimplificationTolerance { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Populate Directions</para>
		/// <para>Specifies whether the tool will generate driving directions for each route.</para>
		/// <para>Checked (True in Python)—Directions will be generated and configured based on the values of the Directions Language, Directions Style Name, and Directions Distance Units parameters.</para>
		/// <para>Unchecked (False in Python)—Directions will not be generated, and the tool will return an empty Directions layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object PopulateDirections { get; set; } = "false";

		/// <summary>
		/// <para>Directions Language</para>
		/// <para>The language that will be used when generating travel directions.</para>
		/// <para>This parameter is used only when the Populate Directions parameter is checked (True in Python).</para>
		/// <para>The parameter value can be specified using one of the following two- or five-character language codes:</para>
		/// <para>ar—Arabic</para>
		/// <para>bs—Bosnian</para>
		/// <para>ca—Catalan</para>
		/// <para>cs—Czech</para>
		/// <para>da—Danish</para>
		/// <para>de—German</para>
		/// <para>el—Greek</para>
		/// <para>en—English</para>
		/// <para>es—Spanish</para>
		/// <para>et—Estonian</para>
		/// <para>fi—Finnish</para>
		/// <para>fr—French</para>
		/// <para>he—Hebrew</para>
		/// <para>hr—Croatian</para>
		/// <para>hu—Hungarian</para>
		/// <para>id—Indonesian</para>
		/// <para>it—Italian</para>
		/// <para>ja—Japanese</para>
		/// <para>ko—Korean</para>
		/// <para>lt—Lithuanian</para>
		/// <para>lv—Latvian</para>
		/// <para>nb—Norwegian</para>
		/// <para>nl—Dutch</para>
		/// <para>pl—Polish</para>
		/// <para>pt-BR—Brazilian Portuguese</para>
		/// <para>pt-PT—European Portuguese</para>
		/// <para>ro—Romanian</para>
		/// <para>ru—Russian</para>
		/// <para>sl—Slovenian</para>
		/// <para>sr—Serbian</para>
		/// <para>sv—Swedish</para>
		/// <para>th—Thai</para>
		/// <para>tr—Turkish</para>
		/// <para>uk—Ukrainian</para>
		/// <para>vi—Vietnamese</para>
		/// <para>zh-CN—Simplified Chinese</para>
		/// <para>zh-HK—Traditional Chinese (Hong Kong)</para>
		/// <para>zh-TW—Traditional Chinese (Taiwan)</para>
		/// <para>The tool first searches for an exact match for the specified language including any language localization. If an exact match is not found, it tries to match the language family. If a match is still not found, the tool returns the directions using the default language, English. For example, if the directions language is specified as es-MX (Mexican Spanish), the tool will return the directions in Spanish, as it supports the es language code but not es-MX.</para>
		/// <para>If a language supports localization, such as Brazilian Portuguese (pt-BR) and European Portuguese (pt-PT), specify the language family and the localization. If you only specify the language family, the tool will not match the language family and instead return directions in the default language, English. For example, if the directions language specified is pt, the tool will return the directions in English since it cannot determine whether the directions should be returned in pt-BR or pt-PT.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output")]
		public object DirectionsLanguage { get; set; } = "en";

		/// <summary>
		/// <para>Directions Style Name</para>
		/// <para>Specifies the name of the formatting style for the directions. This parameter is used only when the Populate Directions parameter is checked (True in Python).</para>
		/// <para>Network Analyst Desktop—Turn-by-turn directions suitable for printing.</para>
		/// <para>Network Analyst Navigation—Turn-by-turn directions designed for an in-vehicle navigation device.</para>
		/// <para><see cref="DirectionsStyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object DirectionsStyleName { get; set; } = "NA Desktop";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The mode of transportation to model in the analysis. Travel modes are managed in ArcGIS Online and can be configured by the administrator of your organization to reflect your organization&apos;s workflows. You need to specify the name of a travel mode that is supported by your organization.</para>
		/// <para>To get a list of supported travel mode names, run the Get Travel Modes tool from the Utilities toolbox under the same GIS Server connection you used to access the tool. The Get Travel Modes tool adds a table, Supported Travel Modes, to the application. Any value in the Travel Mode Name field from the Supported Travel Modes table can be specified as input. You can also specify the value from the Travel Mode Settings field as input. This speeds up tool execution, as the tool does not have to find the settings based on the travel mode name.</para>
		/// <para>The default value, Custom, allows you to configure your own travel mode using the custom travel mode parameters (UTurn at Junctions, Use Hierarchy, Restrictions, Attribute Parameter Values, and Impedance). The default values of the custom travel mode parameters model traveling by car. You can also choose Custom and set the custom travel mode parameters listed above to model a pedestrian with a fast walking speed or a truck with a given height, weight, and cargo of certain hazardous materials. You can try different settings to get the analysis results you want. Once you have identified the analysis settings, work with your organization&apos;s administrator and save these settings as part of a new or existing travel mode so that everyone in your organization can run the analysis with the same settings.</para>
		/// <para>When you choose Custom, the values you set for the custom travel mode parameters are included in the analysis. Specifying another travel mode, as defined by your organization, causes any values you set for the custom travel mode parameters to be ignored; the tool overrides them with values from your specified travel mode.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TravelMode { get; set; } = "Custom";

		/// <summary>
		/// <para>Impedance</para>
		/// <para>Specifies the impedance, which is a value that represents the effort or cost of traveling along road segments or on other parts of the transportation network.</para>
		/// <para>Travel time is an impedance: a car may take 1 minute to travel a mile along an empty road. Travel times can vary by travel mode—a pedestrian may take more than 20 minutes to walk the same mile, so it is important to choose the right impedance for the travel mode you are modeling.</para>
		/// <para>Travel distance can also be an impedance; the length of a road in kilometers can be thought of as impedance. Travel distance in this sense is the same for all modes—a kilometer for a pedestrian is also a kilometer for a car. (What may change is the pathways on which the different modes are allowed to travel, which affects distance between points, and this is modeled by travel mode settings.)</para>
		/// <para>The value you provide for this parameter is ignored unless Travel Mode is set to Custom, which is the default value.</para>
		/// <para>Travel Time—Historical and live traffic data is used. This option is good for modeling the time it takes automobiles to travel along roads at a specific time of day using live traffic speed data where available. When using TravelTime, you can optionally set the TravelTime::Vehicle Maximum Speed (km/h) attribute parameter to specify the physical limitation of the speed the vehicle is capable of traveling.</para>
		/// <para>Minutes—Live traffic data is not used, but historical average speeds for automobiles data is used.</para>
		/// <para>Truck Travel Time—Historical and live traffic data is used, but the speed is capped at the posted truck speed limit. This is good for modeling the time it takes for the trucks to travel along roads at a specific time. When using TruckTravelTime, you can optionally set the TruckTravelTime::Vehicle Maximum Speed (km/h) attribute parameter to specify the physical limitation of the speed the truck is capable of traveling.</para>
		/// <para>Truck Minutes—Live traffic data is not used, but the smaller of the historical average speeds for automobiles and the posted speed limits for trucks are used.</para>
		/// <para>Walk Time—The default is a speed of 5 km/hr on all roads and paths, but this can be configured through the WalkTime::Walking Speed (km/h) attribute parameter.</para>
		/// <para>Time At One Kilometer Per Hour—The default is a speed of 1 km/hr on all roads and paths. The speed cannot be changed using any attribute parameter.</para>
		/// <para>Drive Time—Models travel times for a car. These travel times are dynamic and fluctuate according to traffic flows in areas where traffic data is available. This is the default value.</para>
		/// <para>Truck Time—Models travel times for a truck. These travel times are static for each road and don&apos;t fluctuate with traffic.</para>
		/// <para>Walk Time—Models travel times for a pedestrian.</para>
		/// <para>If you choose a time-based impedance, such as TravelTime, TruckTravelTime, Minutes, TruckMinutes, or WalkTime, the Break Units parameter must be set to a time-based value; if you choose a distance-based impedance such as Miles or Kilometers, Break Units must be distance-based.</para>
		/// <para>Drive Time, Truck Time, Walk Time, and Travel Distance impedance values are no longer supported and will be removed in a future release. If you use one of these values, the tool uses the value of the Time Impedance parameter for time-based values and the Distance Impedance parameter for distance-based values.</para>
		/// <para><see cref="ImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object Impedance { get; set; } = "Drive Time";

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// <para>Specifies the time zone for the input date-time fields supported by the tool. This parameter specifies the time zone for the following fields: TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, TimeWindowEnd2, InboundArriveTime, and OutboundDepartTime on orders. TimeWindowStart1, TimeWindowEnd1, TimeWindowStart2, and TimeWindowEnd2 on depots. EarliestStartTime and LatestStartTime on routes. TimeWindowStart and TimeWindowEnd on breaks.</para>
		/// <para>GEO_LOCAL—The date-time values associated with the orders or depots are in the time zone in which the orders and depots are located. For routes, the date-time values are based on the time zone in which the starting depot for the route is located. If a route does not have a starting depot, all orders and depots across all the routes must be in a single time zone. For breaks, the date-time values are based on the time zone of the routes. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 AM and 5 PM, the time window values will be treated as 8:00 a.m. and 5:00 p.m. eastern standard time.</para>
		/// <para>UTC—The date-time values associated with the orders or depots are in coordinated universal time (UTC) and are not based on the time zone in which the orders or depots are located. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 AM and 5 PM, the time window values will be treated as 12:00 p.m. and 9:00 p.m. eastern standard time, assuming eastern standard time is obeying daylight saving time.</para>
		/// <para>GEO_LOCAL—GEO_LOCAL</para>
		/// <para>UTC—UTC</para>
		/// <para>Specifying the date-time values in UTC is useful if you do not know the time zone in which the orders or depots are located or if you have orders and depots in multiple time zones, and you want all the date-time values to start simultaneously. The UTC option is applicable only when your network dataset defines a time zone attribute. Otherwise, all the date-time values are always treated as GEO_LOCAL.</para>
		/// <para><see cref="TimeZoneUsageForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object TimeZoneUsageForTimeFields { get; set; } = "GEO_LOCAL";

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// <para>Specifies whether the analysis settings will be saved as a network analysis layer file. You cannot directly work with this file even when you open the file in an ArcGIS Desktop application such as ArcMap. It is meant to be sent to Esri Technical Support to diagnose the quality of results returned from the tool.</para>
		/// <para>Checked (True)—The network analysis layer file will be saved. The file is downloaded in a temporary directory on your machine. In ArcGIS Pro, the location of the downloaded file can be determined by viewing the value for the Output Network Analysis Layer parameter in the entry corresponding to the tool execution in the geoprocessing history of your project. In ArcMap, the location of the file can be determined by accessing the Copy Location option in the shortcut menu on the Output Network Analysis Layer parameter in the entry corresponding to the tool execution in the Geoprocessing Results window.</para>
		/// <para>Unchecked (False)—The network analysis layer file will not be saved. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object SaveOutputLayer { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>Additional settings that can influence the behavior of the solver when finding solutions for the network analysis problems.</para>
		/// <para>The value for this parameter must be specified in JavaScript Object Notation (JSON). For example, a valid value is of the following form: {&quot;overrideSetting1&quot; : &quot;value1&quot;, &quot;overrideSetting2&quot; : &quot;value2&quot;}. The override setting name is always enclosed in double quotation marks. The values can be a number, Boolean, or string.</para>
		/// <para>The default value for this parameter is no value, which indicates not to override any solver settings.</para>
		/// <para>Overrides are advanced settings that should be used only after careful analysis of the results obtained before and after applying the settings. For a list of supported override settings for each solver and their acceptable values, contact Esri Technical Support.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object Overrides { get; set; }

		/// <summary>
		/// <para>Save Route Data</para>
		/// <para>Specifies whether the output includes a .zip file that contains a file geodatabase with the inputs and outputs of the analysis in a format that can be used to share route layers with ArcGIS Online or Portal for ArcGIS.</para>
		/// <para>Checked (True)—The route data will be saved as a .zip file. The file is downloaded to a temporary directory on your machine. In ArcGIS Pro, the location of the downloaded file can be determined by viewing the value for the Output Route Data parameter in the entry corresponding to the tool execution in the geoprocessing history of your project. In ArcMap, the location of the file can be determined by accessing the Copy Location option in the shortcut menu on the Output Route Data parameter in the entry corresponding to the tool execution in the Geoprocessing Results window.</para>
		/// <para>Unchecked (False)—The route data will not be saved. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object SaveRouteData { get; set; } = "false";

		/// <summary>
		/// <para>Time Impedance</para>
		/// <para>If the impedance for the travel mode, as specified using the Impedance parameter, is time based, the values for the Time Impedance and Impedance parameters must be identical. Otherwise, the service will return an error.</para>
		/// <para><see cref="TimeImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object TimeImpedance { get; set; } = "TravelTime";

		/// <summary>
		/// <para>Distance Impedance</para>
		/// <para>If the impedance for the travel mode, as specified using the Impedance parameter, is distance based, the values for the Distance Impedance and Impedance parameters must be identical. Otherwise, the service will return an error.</para>
		/// <para><see cref="DistanceImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object DistanceImpedance { get; set; } = "Kilometers";

		/// <summary>
		/// <para>Populate Stop Shapes</para>
		/// <para>Specifies whether the tool will create the shapes for the output assigned and unassigned stops.</para>
		/// <para>Checked (True)—The output assigned and unassigned stops are created as point features. This can be useful to visualize which stops are assigned to routes and which stops could not be assigned to any route.</para>
		/// <para>Unchecked (False)—The output assigned and unassigned stops are created as tables and will not have shapes. This is the default. Use this option only if you don&apos;t need your application to visualize the output stops and can work with only the attributes of the stops.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object PopulateStopShapes { get; set; } = "false";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>Specifies the format in which the output features will be created.</para>
		/// <para>Feature Set—The output features will be returned as feature classes and tables. This is the default.</para>
		/// <para>JSON File—The output features will be returned as a compressed file containing the JSON representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more JSON files (with a .json extension) for each of the outputs created by the service.</para>
		/// <para>GeoJSON File—The output features will be returned as a compressed file containing the GeoJSON representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more GeoJSON files (with a .geojson extension) for each of the outputs created by the service.</para>
		/// <para>When a file-based output format, such as JSON File or GeoJSON File, is specified, no outputs will be added to the display because the application, such as ArcMap or ArcGIS Pro, cannot draw the contents of the result file. Instead, the result file is downloaded to a temporary directory on your machine. In ArcGIS Pro, the location of the downloaded file can be determined by viewing the value for the Output Result File parameter in the entry corresponding to the tool execution in the geoprocessing history of your project. In ArcMap, the location of the file can be determined by accessing the Copy Location option in the shortcut menu on the Output Result File parameter in the entry corresponding to the tool execution in the Geoprocessing Results window.</para>
		/// <para><see cref="OutputFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object OutputFormat { get; set; } = "Feature Set";

		/// <summary>
		/// <para>Ignore Invalid Order Locations</para>
		/// <para>Specifies whether invalid orders will be ignored when solving the vehicle routing problem.</para>
		/// <para>Checked (True)—The solve operation will ignore any invalid orders and return a solution, as long as it didn&apos;t encounter any other errors. If you need to generate routes and deliver them to drivers immediately, you may be able to ignore invalid orders, solve, and distribute the routes to your drivers. Then resolve any invalid orders from the last solve and include them in the VRP analysis for the next workday or work shift.</para>
		/// <para>Unchecked (False)—The solve operation will fail when any invalid orders are encountered. An invalid order is an order that the VRP solver can&apos;t reach. An order may be unreachable for a variety of reasons, including when the order is located on a prohibited network element, isn&apos;t on the network at all, or is on a disconnected part of the network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Network Locations")]
		public object IgnoreInvalidOrderLocations { get; set; } = "false";

		/// <summary>
		/// <para>Output Unassigned Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object OutUnassignedStops { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object OutStops { get; set; }

		/// <summary>
		/// <para>Output Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutRoutes { get; set; }

		/// <summary>
		/// <para>Output Directions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutDirections { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object SolveSucceeded { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutNetworkAnalysisLayer { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Route Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutRouteData { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Result File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutResultFile { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Network Analysis Layer Package</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutputNetworkAnalysisLayerPackage { get; set; } = "scratchfile";

		#region InnerClass

		/// <summary>
		/// <para>Time Units</para>
		/// </summary>
		public enum TimeUnitsEnum 
		{
			/// <summary>
			/// <para>Seconds—The time unit is seconds.</para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Minutes—The time unit is minutes.</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Hours—The time unit is hours.</para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—The time unit is days.</para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The linear unit is meters.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The linear unit is kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The linear unit is feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The linear unit is yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—The linear unit is miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical Miles—The linear unit is nautical miles.</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("Nautical Miles")]
			Nautical_Miles,

		}

		/// <summary>
		/// <para>Analysis Region</para>
		/// </summary>
		public enum AnalysisRegionEnum 
		{
			/// <summary>
			/// <para>Europe—The analysis region is Europe.</para>
			/// </summary>
			[GPValue("Europe")]
			[Description("Europe")]
			Europe,

			/// <summary>
			/// <para>Japan—The analysis region is Japan.</para>
			/// </summary>
			[GPValue("Japan")]
			[Description("Japan")]
			Japan,

			/// <summary>
			/// <para>Korea—The analysis region is Korea.</para>
			/// </summary>
			[GPValue("Korea")]
			[Description("Korea")]
			Korea,

			/// <summary>
			/// <para>Middle East And Africa—The analysis region is Middle East and Africa.</para>
			/// </summary>
			[GPValue("MiddleEastAndAfrica")]
			[Description("Middle East And Africa")]
			Middle_East_And_Africa,

			/// <summary>
			/// <para>North America—The analysis region is North America.</para>
			/// </summary>
			[GPValue("NorthAmerica")]
			[Description("North America")]
			North_America,

			/// <summary>
			/// <para>South America—The analysis region is South America.</para>
			/// </summary>
			[GPValue("SouthAmerica")]
			[Description("South America")]
			South_America,

			/// <summary>
			/// <para>South Asia—The analysis region is South Asia.</para>
			/// </summary>
			[GPValue("SouthAsia")]
			[Description("South Asia")]
			South_Asia,

			/// <summary>
			/// <para>Thailand—The analysis region is Thailand.</para>
			/// </summary>
			[GPValue("Thailand")]
			[Description("Thailand")]
			Thailand,

		}

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// </summary>
		public enum UturnPolicyEnum 
		{
			/// <summary>
			/// <para>Allow UTurns—U-turns are permitted everywhere. Allowing U-turns implies that the vehicle can turn around at any junction and double back on the same street. This is the default value.</para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("Allow UTurns")]
			Allow_UTurns,

			/// <summary>
			/// <para>No UTurns—U-turns are prohibited at all junctions: pseudojunctions, intersections, and dead ends. Note, however, that U-turns may be permitted even when this option is chosen. To prevent U-turns at incidents and facilities, set the CurbApproach field value to prohibit U-turns.</para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("No UTurns")]
			No_UTurns,

			/// <summary>
			/// <para>Allow Dead Ends Only—U-turns are prohibited at all junctions, except those that have only one connected street feature (a dead end).</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("Allow Dead Ends Only")]
			Allow_Dead_Ends_Only,

			/// <summary>
			/// <para>Allow Dead Ends and Intersections Only—U-turns are prohibited at pseudojunctions where exactly two adjacent streets meet, but U-turns are permitted at intersections and dead ends. This prevents turning around in the middle of the road where one length of road happens to be digitized as two street features.</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("Allow Dead Ends and Intersections Only")]
			Allow_Dead_Ends_and_Intersections_Only,

		}

		/// <summary>
		/// <para>Time Window Factor</para>
		/// </summary>
		public enum TimeWindowFactorEnum 
		{
			/// <summary>
			/// <para>High—Importance is placed on arriving at stops on time rather than minimizing drive times. For example, organizations that make time-critical deliveries or that are concerned with customer service choose High.</para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—Importance is balanced between minimizing drive times and arriving within time windows. This is the default value.</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—Importance is placed on minimizing drive times and rather than arriving at stops on time. You may want to use this setting if you have a growing backlog of service requests. For the purpose of servicing more orders in a day and reducing the backlog, you can choose Low even though customers may be inconvenienced with your late arrivals.</para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Excess Transit Factor</para>
		/// </summary>
		public enum ExcessTransitFactorEnum 
		{
			/// <summary>
			/// <para>High—Importance is placed on the least excess transit time between paired orders at the expense of increasing the overall travel costs. This setting is typically used when transporting people between paired orders and you want to shorten their ride time. This is characteristic of taxi services.</para>
			/// </summary>
			[GPValue("High")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—Importance is balanced between reducing excess transit time and reducing the overall solution cost. This is the default value.</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—Importance is placed on minimizing overall solution cost, regardless of excess transit time. This setting is commonly used with courier services. Since couriers transport packages as opposed to people, they don&apos;t worry about ride time. Low allows the couriers to service paired orders in the proper sequence and minimize the overall solution cost.</para>
			/// </summary>
			[GPValue("Low")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Directions Style Name</para>
		/// </summary>
		public enum DirectionsStyleNameEnum 
		{
			/// <summary>
			/// <para>Network Analyst Desktop—Turn-by-turn directions suitable for printing.</para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("Network Analyst Desktop")]
			Network_Analyst_Desktop,

			/// <summary>
			/// <para>Network Analyst Navigation—Turn-by-turn directions designed for an in-vehicle navigation device.</para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("Network Analyst Navigation")]
			Network_Analyst_Navigation,

		}

		/// <summary>
		/// <para>Impedance</para>
		/// </summary>
		public enum ImpedanceEnum 
		{
			/// <summary>
			/// <para>Drive Time—Models travel times for a car. These travel times are dynamic and fluctuate according to traffic flows in areas where traffic data is available. This is the default value.</para>
			/// </summary>
			[GPValue("Drive Time")]
			[Description("Drive Time")]
			Drive_Time,

			/// <summary>
			/// <para>Truck Time—Models travel times for a truck. These travel times are static for each road and don&apos;t fluctuate with traffic.</para>
			/// </summary>
			[GPValue("Truck Time")]
			[Description("Truck Time")]
			Truck_Time,

			/// <summary>
			/// <para>Walk Time—The default is a speed of 5 km/hr on all roads and paths, but this can be configured through the WalkTime::Walking Speed (km/h) attribute parameter.</para>
			/// </summary>
			[GPValue("Walk Time")]
			[Description("Walk Time")]
			Walk_Time,

			/// <summary>
			/// <para>Minutes—Live traffic data is not used, but historical average speeds for automobiles data is used.</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Travel Time—Historical and live traffic data is used. This option is good for modeling the time it takes automobiles to travel along roads at a specific time of day using live traffic speed data where available. When using TravelTime, you can optionally set the TravelTime::Vehicle Maximum Speed (km/h) attribute parameter to specify the physical limitation of the speed the vehicle is capable of traveling.</para>
			/// </summary>
			[GPValue("TravelTime")]
			[Description("Travel Time")]
			Travel_Time,

			/// <summary>
			/// <para>Time At One Kilometer Per Hour—The default is a speed of 1 km/hr on all roads and paths. The speed cannot be changed using any attribute parameter.</para>
			/// </summary>
			[GPValue("TimeAt1KPH")]
			[Description("Time At One Kilometer Per Hour")]
			Time_At_One_Kilometer_Per_Hour,

			/// <summary>
			/// <para>Walk Time—The default is a speed of 5 km/hr on all roads and paths, but this can be configured through the WalkTime::Walking Speed (km/h) attribute parameter.</para>
			/// </summary>
			[GPValue("WalkTime")]
			[Description("Walk Time")]
			Walk_Time1,

			/// <summary>
			/// <para>Truck Minutes—Live traffic data is not used, but the smaller of the historical average speeds for automobiles and the posted speed limits for trucks are used.</para>
			/// </summary>
			[GPValue("TruckMinutes")]
			[Description("Truck Minutes")]
			Truck_Minutes,

			/// <summary>
			/// <para>Truck Travel Time—Historical and live traffic data is used, but the speed is capped at the posted truck speed limit. This is good for modeling the time it takes for the trucks to travel along roads at a specific time. When using TruckTravelTime, you can optionally set the TruckTravelTime::Vehicle Maximum Speed (km/h) attribute parameter to specify the physical limitation of the speed the truck is capable of traveling.</para>
			/// </summary>
			[GPValue("TruckTravelTime")]
			[Description("Truck Travel Time")]
			Truck_Travel_Time,

		}

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// </summary>
		public enum TimeZoneUsageForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>GEO_LOCAL—The date-time values associated with the orders or depots are in the time zone in which the orders and depots are located. For routes, the date-time values are based on the time zone in which the starting depot for the route is located. If a route does not have a starting depot, all orders and depots across all the routes must be in a single time zone. For breaks, the date-time values are based on the time zone of the routes. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 AM and 5 PM, the time window values will be treated as 8:00 a.m. and 5:00 p.m. eastern standard time.</para>
			/// </summary>
			[GPValue("GEO_LOCAL")]
			[Description("GEO_LOCAL")]
			GEO_LOCAL,

			/// <summary>
			/// <para>UTC—The date-time values associated with the orders or depots are in coordinated universal time (UTC) and are not based on the time zone in which the orders or depots are located. For example, if your depot is located in an area that follows eastern standard time and has the first time window values (specified as TimeWindowStart1 and TimeWindowEnd1) of 8 AM and 5 PM, the time window values will be treated as 12:00 p.m. and 9:00 p.m. eastern standard time, assuming eastern standard time is obeying daylight saving time.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Time Impedance</para>
		/// </summary>
		public enum TimeImpedanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TravelTime")]
			[Description("Travel Time")]
			Travel_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TimeAt1KPH")]
			[Description("Time At One Kilometer Per Hour")]
			Time_At_One_Kilometer_Per_Hour,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WalkTime")]
			[Description("Walk Time")]
			Walk_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckMinutes")]
			[Description("Truck Minutes")]
			Truck_Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckTravelTime")]
			[Description("Truck Travel Time")]
			Truck_Travel_Time,

		}

		/// <summary>
		/// <para>Distance Impedance</para>
		/// </summary>
		public enum DistanceImpedanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

		/// <summary>
		/// <para>Output Format</para>
		/// </summary>
		public enum OutputFormatEnum 
		{
			/// <summary>
			/// <para>Feature Set—The output features will be returned as feature classes and tables. This is the default.</para>
			/// </summary>
			[GPValue("Feature Set")]
			[Description("Feature Set")]
			Feature_Set,

			/// <summary>
			/// <para>JSON File—The output features will be returned as a compressed file containing the JSON representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more JSON files (with a .json extension) for each of the outputs created by the service.</para>
			/// </summary>
			[GPValue("JSON File")]
			[Description("JSON File")]
			JSON_File,

			/// <summary>
			/// <para>GeoJSON File—The output features will be returned as a compressed file containing the GeoJSON representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more GeoJSON files (with a .geojson extension) for each of the outputs created by the service.</para>
			/// </summary>
			[GPValue("GeoJSON File")]
			[Description("GeoJSON File")]
			GeoJSON_File,

		}

#endregion
	}
}
