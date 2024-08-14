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
	/// <para>Solve Location Allocation</para>
	/// <para>Identifies the best location or locations from a set of input locations by assigning demand points to input facilities in a way that allocates the most demand to facilities and minimizes overall travel.</para>
	/// </summary>
	public class SolveLocationAllocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Facilities">
		/// <para>Facilities</para>
		/// <para>Specify one or more facilities that the solver will choose from during the analysis. The solver identifies the best facilities to allocate demand in the most efficient way according to the problem type and criteria you specify.</para>
		/// <para>In a competitive analysis in which you try to find the best locations in the face of competition, the facilities of the competitors are specified here as well.</para>
		/// <para>When defining the facilities, you can set properties for each—such as its name or type—using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the facility. The name is included in the name of output allocation lines if the facility is part of the solution.</para>
		/// <para>FacilityType</para>
		/// <para>Specifies whether the facility is a candidate, required, or a competitor facility. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Candidate)—A facility that may be part of the solution.</para>
		/// <para>1 (Required)—A facility that must be part of the solution.</para>
		/// <para>2 (Competitor)—A rival facility that potentially removes demand from your facilities. Competitor facilities are specific to the maximize market share and target market share problem types; they are ignored in other problem types.</para>
		/// <para>Weight</para>
		/// <para>The relative weighting of the facility, which is used to rate the attractiveness, desirability, or bias of one facility compared to another.</para>
		/// <para>For example, a value of 2.0 may capture the preference of customers who prefer, at a ratio of 2 to 1, shopping in one facility over another facility. Factors that potentially affect facility weight include square footage, neighborhood, and age of the building. Weight values other than one are only honored by the maximize market share and target market share problem types; they are ignored in other problem types.</para>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for demand points from a given facility. The demand point can&apos;t be allocated to a facility that is beyond the value indicated here.</para>
		/// <para>This attribute allows you to specify a different cutoff value for each demand point. For example, you may find that people in rural areas are willing to travel up to 10 miles to reach a facility, while urbanites are only willing to travel up to 2 miles. You can model this behavior by setting the Cutoff value for all demand points that are in rural areas to 10 and setting the Cutoff value of the demand points in urban areas to 2.</para>
		/// <para>Capacity</para>
		/// <para>The Capacity field is specific to the maximize capacitated coverage problem type; the other problem types ignore this field.</para>
		/// <para>Capacity specifies how much weighted demand the facility is capable of supplying. Excess demand won&apos;t be allocated to a facility even if that demand is within the facility&apos;s default measurement cutoff.</para>
		/// <para>Any value assigned to the Capacity field overrides the Default Capacity parameter (Default_Capacity in Python) for the given facility.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at or depart from the facility. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The facility can be visited from either the right or left side of the vehicle.</para>
		/// <para>1 (Right side of vehicle)—Arrive at or depart the facility so it is on the right side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side so passengers can disembark at the curb.</para>
		/// <para>2 (Left side of vehicle)—Arrive at or depart the facility so it is on the left side of the vehicle. When the vehicle approaches and departs the facility, the curb must be on the left side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side so passengers can disembark at the curb.</para>
		/// <para>The CurbApproach attribute is designed to work with both types of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a facility on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a facility from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at a facility and not have a lane of traffic between the vehicle and the incident, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		/// <param name="DemandPoints">
		/// <para>Demand Points</para>
		/// <para>Specify one or more demand points. The solver identifies the best facilities based in large part on how they serve the demand points specified here.</para>
		/// <para>A demand point is typically a location that represents the people or things requiring the goods and services your facilities provide. A demand point may be a ZIP Code centroid weighted by the number of people residing within it or by the expected consumption generated by those people. Demand points can also represent business customers. If you supply businesses with a high turnover of inventory, they will be weighted more heavily than those with a low turnover rate.</para>
		/// <para>When specifying the demand points, you can set properties for each—such as its name or weight—using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the demand point. The name is included in the name of the output allocation line or lines if the demand point is part of the solution.</para>
		/// <para>GroupName</para>
		/// <para>The name of the group to which the demand point belongs. This field is ignored for the Maximize Capacitated Coverage, Target Market Share, and Maximize Market Share problem types.</para>
		/// <para>If demand points share a group name, the solver allocates all members of the group to the same facility. (If constraints, such as a cutoff distance, prevent any of the demand points in the group from reaching the same facility, none of the demand points are allocated.)</para>
		/// <para>Weight</para>
		/// <para>The relative weighting of the demand point. A value of 2.0 means the demand point is twice as important as one with a weight of 1.0. If demand points represent households, for example, weight can indicate the number of people in each household.</para>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for demand points from a given facility. The demand point can&apos;t be allocated to a facility that is beyond the value indicated here.</para>
		/// <para>This attribute allows you to specify a cutoff value for each demand point. For example, you may find that people in rural areas are willing to travel up to 10 miles to reach a facility, while those in urban areas are only willing to travel up to 2 miles. You can model this behavior by setting the Cutoff value for all demand points that are in rural areas to 10 and setting the Cutoff value of the demand points in urban areas to 2.</para>
		/// <para>The units for this attribute value are specified by the Measurement Units parameter.</para>
		/// <para>A value for this attribute overrides the default set for the analysis using the Default Measurement Cutoff parameter. The default value is Null, which results in using the default value set by the Default Measurement Cutoff parameter for all the demand points.</para>
		/// <para>ImpedanceTransformation</para>
		/// <para>A value for this attribute overrides the default set for the analysis by the Measurement Transformation Model parameter.</para>
		/// <para>ImpedanceParameter</para>
		/// <para>A value for this attribute overrides the default set for the analysis by the Measurement Transformation Factor parameter.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at or depart from the demand point. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The demand point can be visited from either the right or left side of the vehicle.</para>
		/// <para>1 (Right side of vehicle)—Arrive at or depart the demand point so it is on the right side of the vehicle. When the vehicle approaches and departs the demand point, the curb must be on the right side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side so passengers can disembark at the curb.</para>
		/// <para>2 (Left side of vehicle)—Arrive at or depart the demand point so it is on the left side of the vehicle. When the vehicle approaches and departs the demand point, the curb must be on the left side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side so passengers can disembark at the curb.</para>
		/// <para>The CurbApproach attribute is designed to work with both types of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a demand point on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a demand point from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at a demand point and not have a lane of traffic between the vehicle and the demand point, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		/// <param name="MeasurementUnits">
		/// <para>Measurement Units</para>
		/// <para>Specify the units that will be used to measure the travel times or travel distances between demand points and facilities. The tool finds the best facilities based on those that can reach, or be reached by, the most amount of weighted demand with the least amount travel.</para>
		/// <para>The output allocation lines report travel distance or travel time in different units, including the units you specify for this parameter.</para>
		/// <para>Meters—The linear unit is meters.</para>
		/// <para>Kilometers—The linear unit is kilometers.</para>
		/// <para>Feet—The linear unit is feet.</para>
		/// <para>Yards—The linear unit is yards.</para>
		/// <para>Miles—The linear unit is miles.</para>
		/// <para>Nautical Miles—The linear unit is nautical miles.</para>
		/// <para>Seconds—The time unit is seconds.</para>
		/// <para>Minutes—The time unit is minutes.</para>
		/// <para>Hours—The time unit is hours.</para>
		/// <para>Days—The time unit is days.</para>
		/// <para><see cref="MeasurementUnitsEnum"/></para>
		/// </param>
		public SolveLocationAllocation(object Facilities, object DemandPoints, object MeasurementUnits)
		{
			this.Facilities = Facilities;
			this.DemandPoints = DemandPoints;
			this.MeasurementUnits = MeasurementUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : Solve Location Allocation</para>
		/// </summary>
		public override string DisplayName => "Solve Location Allocation";

		/// <summary>
		/// <para>Tool Name : SolveLocationAllocation</para>
		/// </summary>
		public override string ToolName => "SolveLocationAllocation";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.SolveLocationAllocation</para>
		/// </summary>
		public override string ExcuteName => "agolservices.SolveLocationAllocation";

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
		public override object[] Parameters => new object[] { Facilities, DemandPoints, MeasurementUnits, AnalysisRegion!, ProblemType!, NumberOfFacilitiesToFind!, DefaultMeasurementCutoff!, DefaultCapacity!, TargetMarketShare!, MeasurementTransformationModel!, MeasurementTransformationFactor!, TravelDirection!, TimeOfDay!, TimeZoneForTimeOfDay!, UturnAtJunctions!, PointBarriers!, LineBarriers!, PolygonBarriers!, UseHierarchy!, Restrictions!, AttributeParameterValues!, AllocationLineShape!, TravelMode!, Impedance!, SaveOutputNetworkAnalysisLayer!, Overrides!, TimeImpedance!, DistanceImpedance!, OutputFormat!, IgnoreInvalidLocations!, SolveSucceeded!, OutputAllocationLines!, OutputFacilities!, OutputDemandPoints!, OutputNetworkAnalysisLayer!, OutputResultFile!, OutputNetworkAnalysisLayerPackage };

		/// <summary>
		/// <para>Facilities</para>
		/// <para>Specify one or more facilities that the solver will choose from during the analysis. The solver identifies the best facilities to allocate demand in the most efficient way according to the problem type and criteria you specify.</para>
		/// <para>In a competitive analysis in which you try to find the best locations in the face of competition, the facilities of the competitors are specified here as well.</para>
		/// <para>When defining the facilities, you can set properties for each—such as its name or type—using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the facility. The name is included in the name of output allocation lines if the facility is part of the solution.</para>
		/// <para>FacilityType</para>
		/// <para>Specifies whether the facility is a candidate, required, or a competitor facility. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Candidate)—A facility that may be part of the solution.</para>
		/// <para>1 (Required)—A facility that must be part of the solution.</para>
		/// <para>2 (Competitor)—A rival facility that potentially removes demand from your facilities. Competitor facilities are specific to the maximize market share and target market share problem types; they are ignored in other problem types.</para>
		/// <para>Weight</para>
		/// <para>The relative weighting of the facility, which is used to rate the attractiveness, desirability, or bias of one facility compared to another.</para>
		/// <para>For example, a value of 2.0 may capture the preference of customers who prefer, at a ratio of 2 to 1, shopping in one facility over another facility. Factors that potentially affect facility weight include square footage, neighborhood, and age of the building. Weight values other than one are only honored by the maximize market share and target market share problem types; they are ignored in other problem types.</para>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for demand points from a given facility. The demand point can&apos;t be allocated to a facility that is beyond the value indicated here.</para>
		/// <para>This attribute allows you to specify a different cutoff value for each demand point. For example, you may find that people in rural areas are willing to travel up to 10 miles to reach a facility, while urbanites are only willing to travel up to 2 miles. You can model this behavior by setting the Cutoff value for all demand points that are in rural areas to 10 and setting the Cutoff value of the demand points in urban areas to 2.</para>
		/// <para>Capacity</para>
		/// <para>The Capacity field is specific to the maximize capacitated coverage problem type; the other problem types ignore this field.</para>
		/// <para>Capacity specifies how much weighted demand the facility is capable of supplying. Excess demand won&apos;t be allocated to a facility even if that demand is within the facility&apos;s default measurement cutoff.</para>
		/// <para>Any value assigned to the Capacity field overrides the Default Capacity parameter (Default_Capacity in Python) for the given facility.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at or depart from the facility. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The facility can be visited from either the right or left side of the vehicle.</para>
		/// <para>1 (Right side of vehicle)—Arrive at or depart the facility so it is on the right side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side so passengers can disembark at the curb.</para>
		/// <para>2 (Left side of vehicle)—Arrive at or depart the facility so it is on the left side of the vehicle. When the vehicle approaches and departs the facility, the curb must be on the left side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side so passengers can disembark at the curb.</para>
		/// <para>The CurbApproach attribute is designed to work with both types of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a facility on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a facility from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at a facility and not have a lane of traffic between the vehicle and the incident, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		public object Facilities { get; set; }

		/// <summary>
		/// <para>Demand Points</para>
		/// <para>Specify one or more demand points. The solver identifies the best facilities based in large part on how they serve the demand points specified here.</para>
		/// <para>A demand point is typically a location that represents the people or things requiring the goods and services your facilities provide. A demand point may be a ZIP Code centroid weighted by the number of people residing within it or by the expected consumption generated by those people. Demand points can also represent business customers. If you supply businesses with a high turnover of inventory, they will be weighted more heavily than those with a low turnover rate.</para>
		/// <para>When specifying the demand points, you can set properties for each—such as its name or weight—using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the demand point. The name is included in the name of the output allocation line or lines if the demand point is part of the solution.</para>
		/// <para>GroupName</para>
		/// <para>The name of the group to which the demand point belongs. This field is ignored for the Maximize Capacitated Coverage, Target Market Share, and Maximize Market Share problem types.</para>
		/// <para>If demand points share a group name, the solver allocates all members of the group to the same facility. (If constraints, such as a cutoff distance, prevent any of the demand points in the group from reaching the same facility, none of the demand points are allocated.)</para>
		/// <para>Weight</para>
		/// <para>The relative weighting of the demand point. A value of 2.0 means the demand point is twice as important as one with a weight of 1.0. If demand points represent households, for example, weight can indicate the number of people in each household.</para>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for demand points from a given facility. The demand point can&apos;t be allocated to a facility that is beyond the value indicated here.</para>
		/// <para>This attribute allows you to specify a cutoff value for each demand point. For example, you may find that people in rural areas are willing to travel up to 10 miles to reach a facility, while those in urban areas are only willing to travel up to 2 miles. You can model this behavior by setting the Cutoff value for all demand points that are in rural areas to 10 and setting the Cutoff value of the demand points in urban areas to 2.</para>
		/// <para>The units for this attribute value are specified by the Measurement Units parameter.</para>
		/// <para>A value for this attribute overrides the default set for the analysis using the Default Measurement Cutoff parameter. The default value is Null, which results in using the default value set by the Default Measurement Cutoff parameter for all the demand points.</para>
		/// <para>ImpedanceTransformation</para>
		/// <para>A value for this attribute overrides the default set for the analysis by the Measurement Transformation Model parameter.</para>
		/// <para>ImpedanceParameter</para>
		/// <para>A value for this attribute overrides the default set for the analysis by the Measurement Transformation Factor parameter.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at or depart from the demand point. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The demand point can be visited from either the right or left side of the vehicle.</para>
		/// <para>1 (Right side of vehicle)—Arrive at or depart the demand point so it is on the right side of the vehicle. When the vehicle approaches and departs the demand point, the curb must be on the right side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the right-hand side so passengers can disembark at the curb.</para>
		/// <para>2 (Left side of vehicle)—Arrive at or depart the demand point so it is on the left side of the vehicle. When the vehicle approaches and departs the demand point, the curb must be on the left side of the vehicle. This is typically used for vehicles such as buses that must arrive with the bus stop on the left-hand side so passengers can disembark at the curb.</para>
		/// <para>The CurbApproach attribute is designed to work with both types of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider a demand point on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to approach a demand point from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to arrive at a demand point and not have a lane of traffic between the vehicle and the demand point, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		public object DemandPoints { get; set; }

		/// <summary>
		/// <para>Measurement Units</para>
		/// <para>Specify the units that will be used to measure the travel times or travel distances between demand points and facilities. The tool finds the best facilities based on those that can reach, or be reached by, the most amount of weighted demand with the least amount travel.</para>
		/// <para>The output allocation lines report travel distance or travel time in different units, including the units you specify for this parameter.</para>
		/// <para>Meters—The linear unit is meters.</para>
		/// <para>Kilometers—The linear unit is kilometers.</para>
		/// <para>Feet—The linear unit is feet.</para>
		/// <para>Yards—The linear unit is yards.</para>
		/// <para>Miles—The linear unit is miles.</para>
		/// <para>Nautical Miles—The linear unit is nautical miles.</para>
		/// <para>Seconds—The time unit is seconds.</para>
		/// <para>Minutes—The time unit is minutes.</para>
		/// <para>Hours—The time unit is hours.</para>
		/// <para>Days—The time unit is days.</para>
		/// <para><see cref="MeasurementUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MeasurementUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Analysis Region</para>
		/// <para>The region in which the analysis will be performed. If a value is not specified for this parameter, the tool will automatically calculate the region name based on the location of the input points. Setting the name of the region is required only if the automatic detection of the region name is not accurate for the inputs.</para>
		/// <para>To specify a region, use one of the following values:</para>
		/// <para>Europe—The analysis region is Europe.</para>
		/// <para>Japan—The analysis region is Japan.</para>
		/// <para>Korea—The analysis region is Korea.</para>
		/// <para>Middle East And Africa—The analysis region is Middle East and Africa.</para>
		/// <para>North America—The analysis region is North America.</para>
		/// <para>South America—The analysis region is South America.</para>
		/// <para>South Asia—The analysis region is South Asia.</para>
		/// <para>Thailand—The analysis region is Thailand.</para>
		/// <para>The following region names are no longer supported and will be removed in future releases. If you specify one of the deprecated region names, the tool automatically assigns a supported region name for the region.</para>
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
		public object? AnalysisRegion { get; set; }

		/// <summary>
		/// <para>Problem Type</para>
		/// <para>Specifies the objective of the location-allocation analysis. The default objective is to minimize impedance.</para>
		/// <para>Minimize Impedance—This is also known as the P-Median problem type. Facilities are located such that the sum of all weighted travel time or distance between demand points and solution facilities is minimized. (Weighted travel is the amount of demand allocated to a facility multiplied by the travel distance or time to the facility.)This problem type is traditionally used to locate warehouses, because it can reduce the overall transportation costs of delivering goods to outlets. Since minimize impedance reduces the overall distance the public needs to travel to reach the chosen facilities, the minimize impedance problem without an impedance cutoff is typically regarded as more equitable than other problem types for locating some public sector facilities such as libraries, regional airports, museums, department of motor vehicles offices, and health clinics.The following list describes how the minimize impedance problem type handles demand:</para>
		/// <para>A demand point that cannot reach any facilities due to setting a cutoff distance or time is not allocated.</para>
		/// <para>A demand point that can only reach one facility has all its demand weight allocated to that facility.</para>
		/// <para>A demand point that can reach two or more facilities has all its demand weight allocated to the nearest facility only.</para>
		/// <para>Maximize Coverage—Facilities are located such that as much demand as possible is allocated to solution facilities within the impedance cutoff.Maximize coverage is frequently used to locate fire stations, police stations, and ERS centers, because emergency services are often required to arrive at all demand points within a specified response time. Note that it is important for all organizations, and critical for emergency services, to have accurate and precise data so analysis results correctly model real-world results.Pizza delivery businesses, as opposed to eat-in pizzerias, try to locate stores where they can cover the most people within a certain drive time. People who order pizzas for delivery don&apos;t typically worry about how far away the pizzeria is; they are mainly concerned with the pizza arriving within an advertised time window. Therefore, a pizza delivery business would subtract pizza preparation time from their advertised delivery time and solve a maximize coverage problem to choose the candidate facility that will capture the most potential customers in the coverage area. (Potential customers of eat-in pizzerias are more affected by distance, since they need to travel to the restaurant; thus, the attendance maximizing and market share problem types are better suited to eat-in restaurants.)The following list describes how the maximize coverage problem type handles demand:</para>
		/// <para>A demand point that cannot reach any facilities due to cutoff distance or time is not allocated.</para>
		/// <para>A demand point that can only reach one facility has all its demand weight allocated to that facility.</para>
		/// <para>A demand point that can reach two or more facilities has all its demand weight allocated to the nearest facility only.</para>
		/// <para>Maximize Capacitated Coverage—Facilities are located such that all or the greatest amount of demand can be served without exceeding the capacity of any facility.Maximize capacitated coverage behaves similarly to the minimize impedance and maximize coverage problem types but with the added constraint of capacity. You can specify a capacity for an individual facility by assigning a numeric value to its corresponding Capacity field on the input facilities. If the Capacity field value is null, the facility is assigned a capacity from the Default Capacity property.Use cases for the maximize capacitated coverage problem type include creating territories that encompass a given number of people or businesses, locating hospitals or other medical facilities with a limited number of beds or patients who can be treated, and locating warehouses whose inventory isn&apos;t assumed to be unlimited. The following list describes how the maximize capacitated coverage problem type handles demand:</para>
		/// <para>Unlike maximize coverage, maximize capacitated coverage doesn&apos;t require a value for the Default Measurement Cutoff parameter; however, when a cutoff is specified, any demand point outside the cutoff time or distance of all facilities is not allocated.</para>
		/// <para>An allocated demand point has all or none of its demand weight assigned to a facility; that is, demand isn&apos;t apportioned with this problem type.</para>
		/// <para>If the total demand that can reach a facility is greater than the capacity of the facility, only the demand points that maximize total captured demand and minimize total weighted travel are allocated.You may notice an apparent inefficiency when a demand point is allocated to a facility that isn&apos;t the nearest solution facility. This may occur when demand points have varying weights and when the demand point in question can reach more than one facility. This kind of result indicates the nearest solution facility didn&apos;t have adequate capacity for the weighted demand, or the most efficient solution for the entire problem required one or more local inefficiencies. In either case, the solution is correct.</para>
		/// <para>Minimize Facilities—Facilities are chosen such that as much weighted demand as possible is allocated to solution facilities within the travel time or distance cutoff; additionally, the number of facilities required to cover demand is minimized.Minimize facilities is the same as maximize coverage but with the exception of the number of facilities to locate, which in this case is determined by the solver. When the cost of building facilities is not a limiting factor, the same types of organizations that use maximize coverage (emergency response, for instance) use minimize facilities so all possible demand points will be covered. The following list describes how the minimize facilities problem type handles demand:</para>
		/// <para>A demand point that cannot reach any facilities due to a cutoff distance or time is not allocated.</para>
		/// <para>A demand point that can only reach one facility has all its demand weight allocated to that facility.</para>
		/// <para>A demand point that can reach two or more facilities has all its demand weight allocated to the nearest facility only.</para>
		/// <para>Maximize Attendance—Facilities are chosen such that as much demand weight as possible is allocated to facilities while assuming the demand weight decreases in relation to the distance between the facility and the demand point.Specialty stores that have little or no competition benefit from this problem type, but it may also be beneficial to general retailers and restaurants that don&apos;t have the data on competitors necessary to perform market share problem types. Some businesses that may benefit from this problem type include coffee shops, fitness centers, dental and medical offices, and electronics stores. Public transit bus stops are often chosen with the help of maximize attendance. Maximize attendance assumes that the farther people must travel to reach your facility, the less likely they are to use it. This is reflected in how the amount of demand allocated to facilities diminishes with distance.The following list describes how the maximize attendance problem type handles demand:</para>
		/// <para>A demand point that cannot reach any facilities due to a cutoff distance or time is not allocated.</para>
		/// <para>When a demand point can reach a facility, its demand weight is only partially allocated to the facility. The amount allocated decreases as a function of the maximum cutoff distance (or time) and the travel distance (or time) between the facility and the demand point.</para>
		/// <para>The weight of a demand point that can reach more than one facility is proportionately allocated to the nearest facility only.</para>
		/// <para>Maximize Market Share—A specific number of facilities are chosen such that the allocated demand is maximized in the presence of competitors. The goal is to capture as much of the total market share as possible with a given number of facilities, which you specify. The total market share is the sum of all demand weight for valid demand points.The market share problem types require the most data because, along with knowing your own facilities&apos; weight, you also need to know that of your competitors&apos; facilities. The same types of facilities that use the maximize attendance problem type can also use market share problem types given that they have comprehensive information that includes competitor data. Large discount stores typically use maximize market share to locate a finite set of new stores. The market share problem types use a Huff model, which is also known as a gravity model or spatial interaction.The following list describes how the maximize market share problem type handles demand:</para>
		/// <para>A demand point that cannot reach any facilities due to a cutoff distance or time is not allocated.</para>
		/// <para>A demand point that can only reach one facility has all its demand weight allocated to that facility.</para>
		/// <para>A demand point that can reach two or more facilities has all its demand weight allocated to them; furthermore, the weight is split among the facilities proportionally to the facilities&apos; attractiveness (facility weight) and inversely proportionally to the distance between the facility and demand point. Given equal facility weights, this means more demand weight is assigned to near facilities than far facilities.</para>
		/// <para>The total market share, which can be used to calculate the captured market share, is the sum of the weight of all valid demand points.</para>
		/// <para>Target Market Share—The minimum number of facilities necessary to capture a specific percentage of the total market share in the presence of competitors is chosen. The total market share is the sum of all demand weight for valid demand points. You set the percent of the market share you want to reach and the solver identifies the fewest number of facilities necessary to meet that threshold.The market share problem types require the most data because, along with knowing your own facilities&apos; weight, you also need to know that of your competitors&apos; facilities. The same types of facilities that use the maximize attendance problem type can also use market share problem types given that they have comprehensive information that includes competitor data.Large discount stores typically use the target market share problem type when they want to know how much expansion would be required to reach a certain level of the market share or see what strategy would be needed just to maintain their current market share given the introduction of new competing facilities. The results often represent what stores would do if budgets weren&apos;t a concern. In other cases where budget is a concern, stores revert to the maximize market share problem type and capture as much of the market share as possible with a limited number of facilities.The following list describes how the target market share problem type handles demand:</para>
		/// <para>The total market share, which is used in calculating the captured market share, is the sum of the weight of all valid demand points.</para>
		/// <para>A demand point that cannot reach any facilities due to a cutoff distance or time is not allocated.</para>
		/// <para>A demand point that can only reach one facility has all its demand weight allocated to that facility.</para>
		/// <para>A demand point that can reach two or more facilities has all its demand weight allocated to them; furthermore, the weight is split among the facilities proportionally to the facilities&apos; attractiveness (facility weight) and inversely proportionally to the distance between the facility and demand point. Given equal facility weights, this means more demand weight is assigned to near facilities than far facilities.</para>
		/// <para><see cref="ProblemTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Location-Allocation Problem Settings")]
		public object? ProblemType { get; set; } = "Minimize Impedance";

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>The number of facilities to find. The default value is 1.</para>
		/// <para>The facilities with a FacilityType field value of 1 (Required) are always chosen first. Any excess facilities are chosen from candidate facilities with a FacilityType field value of 2.</para>
		/// <para>Any facilities that have a FacilityType value of 3 (Chosen) before solving are treated as candidate facilities at solve time.</para>
		/// <para>If the number of facilities to find is less than the number of required facilities, an error occurs.</para>
		/// <para>Number of Facilities to Find is disabled for the minimize facilities and target market share problem types since the solver determines the minimum number of facilities needed to meet the objectives.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Location-Allocation Problem Settings")]
		public object? NumberOfFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Default Measurement Cutoff</para>
		/// <para>The maximum travel time or distance allowed between a demand point and the facility it is allocated to. If a demand point is outside the cutoff of a facility, it cannot be allocated to that facility.</para>
		/// <para>The default value is none, which means the cutoff limit doesn&apos;t apply.</para>
		/// <para>The units for this parameter are the same as those specified by the Measurement Units parameter.</para>
		/// <para>The travel time or distance cutoff is measured by the shortest path along roads.</para>
		/// <para>This parameter can be used to model the maximum distance that people are willing to travel to visit stores or the maximum time permitted for a fire department to reach anyone in the community.</para>
		/// <para>Note that Demand Points includes the Cutoff field, which, if set accordingly, overrides the Default Measurement Cutoff parameter. You may find that people in rural areas are willing to travel up to 10 miles to reach a facility while urbanites are only willing to travel up to two miles. Assuming Measurement Units is set to Miles, you can model this behavior by setting the default measurement cutoff to 10 and the Cutoff field value of the demand points in urban areas to 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? DefaultMeasurementCutoff { get; set; }

		/// <summary>
		/// <para>Default Capacity</para>
		/// <para>This parameter is specific to the maximize capacitated coverage problem type. It is the default capacity assigned to all facilities in the analysis. You can override the default capacity for a facility by specifying a value in the facility&apos;s Capacity field.</para>
		/// <para>The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? DefaultCapacity { get; set; } = "1";

		/// <summary>
		/// <para>Target Market Share</para>
		/// <para>This parameter is specific to the target market share problem type. It is the percentage of the total demand weight that you want the chosen and required facilities to capture. The solver identifies the minimum number of facilities needed to capture the target market share specified here.</para>
		/// <para>The default value is 10 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? TargetMarketShare { get; set; } = "10";

		/// <summary>
		/// <para>Measurement Transformation Model</para>
		/// <para>This sets the equation for transforming the network cost between facilities and demand points. This parameter, along with Impedance Parameter, specifies how severely the network impedance between facilities and demand points influences the solver&apos;s choice of facilities.</para>
		/// <para>In the following list of transformation options, d refers to demand points and f refers to facilities. Impedance refers to the shortest travel distance or time between two locations. So impedancedf is the shortest-path (time or distance) between demand point d and facility f, and costdf is the transformed travel time or distance between the facility and demand point. Lambda (λ) denotes the impedance parameter. The Measurement Units parameter determines whether travel time or distance is analyzed.</para>
		/// <para>Linear—costdf = λ * impedancedfThe transformed travel time or distance between the facility and the demand point is the same as the time or distance of the shortest path between the two locations. With this option, the impedance parameter (λ) is always set to one. This is the default.</para>
		/// <para>Power—costdf = impedancedfλThe transformed travel time or distance between the facility and the demand point is equal to the time or distance of the shortest path raised to the power specified by the impedance parameter (λ). Use the Power option with a positive impedance parameter to specify higher weight to nearby facilities.</para>
		/// <para>Exponential—costdf = e(λ * impedancedf)The transformed travel time or distance between the facility and the demand point is equal to the mathematical constant e raised to the power specified by the shortest-path network impedance multiplied with the impedance parameter (λ). Use the Exponential option with a positive impedance parameter to specify a high weight to nearby facilities.</para>
		/// <para>The value set for this parameter can be overridden on a per-demand-point basis using the ImpedanceTransformation field in the input demand points.</para>
		/// <para><see cref="MeasurementTransformationModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Location-Allocation Problem Settings")]
		public object? MeasurementTransformationModel { get; set; } = "Linear";

		/// <summary>
		/// <para>Measurement Transformation Factor</para>
		/// <para>Provides a parameter value to the equations specified in the Measurement Transformation Model parameter. The parameter value is ignored when the impedance transformation is of type linear. For power and exponential impedance transformations, the value should be nonzero.</para>
		/// <para>The default value is 1.</para>
		/// <para>The value set for this parameter can be overridden on a per-demand-point basis using the ImpedanceParameter field in the input demand points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? MeasurementTransformationFactor { get; set; } = "1";

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies whether travel times or distances will be measured from facilities to demand points or from demand points to facilities.</para>
		/// <para>Facility to Demand—The direction of travel is from facilities to demand points. This is the default.</para>
		/// <para>Demand to Facility—The direction of travel is from demand points to facilities.</para>
		/// <para>Travel times and distances may change based on direction of travel. If traveling from point A to point B, you may encounter less traffic or have a shorter path, due to one-way streets and turn restrictions, than if you were traveling in the opposite direction. For instance, traveling from point A to point B may take 10 minutes, but traveling the other direction may take 15 minutes. These differing measurements may affect whether demand points can be assigned to certain facilities because of cutoffs or, for problem types in which demand is apportioned, affect how much demand is captured.</para>
		/// <para>Fire departments commonly measure from facilities to demand points since they are concerned with the time it takes to travel from the fire station (facility) to the location of the emergency (demand point). Management at a retail store is more concerned with the time it takes shoppers (demand points) to reach the store (facility); therefore, store management commonly measure from demand points to facilities.</para>
		/// <para>Travel Direction also determines the meaning of any start time that is provided. See the Time of Day parameter for more information.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TravelDirection { get; set; } = "Facility to Demand";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time at which travel begins. This parameter is ignored unless Measurement Units is time based. The default is no time or date. When Time of Day isn&apos;t specified, the solver uses generic speeds—typically those from posted speed limits.</para>
		/// <para>Traffic constantly changes in reality, and as it changes, travel times between facilities and demand points fluctuate. Therefore, indicating different time and date values over several analyses may affect how demand is allocated to facilities and which facilities are chosen in the results.</para>
		/// <para>The time of day always indicates a start time. However, travel may start from facilities or demand points; it depends on what you choose for the Travel Direction parameter.</para>
		/// <para>The Time Zone for Time of Day parameter specifies whether this time and date refer to UTC or the time zone in which the facility or demand point is located.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// <para>Specifies the time zone of the Time of Day parameter. The default is geographically local.</para>
		/// <para>Geographically Local—The Time of Day parameter refers to the time zone in which the facilities or demand points are located. If Travel Direction is facilities to demand points, this is the time zone of the facilities. If Travel Direction is demand points to facilities, this is the time zone of the demand points.</para>
		/// <para>UTC—The Time of Day parameter refers to coordinated universal time (UTC). Choose this option if you want to find the best location for a specific time, such as now, but aren&apos;t certain in which time zone the facilities or demand points will be located.</para>
		/// <para>Regardless of the Time Zone for Time of Day parameter value, the following rules are enforced by the tool if your facilities and demand points are in multiple time zones:</para>
		/// <para>All facilities must be in the same time zone when specifying a time of day and travel is from facility to demand.</para>
		/// <para>All demand points must be in the same time zone when specifying a time of day and travel is from demand to facility.</para>
		/// <para><see cref="TimeZoneForTimeOfDayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeZoneForTimeOfDay { get; set; } = "Geographically Local";

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// <para><para/>Specifies the U-turn policy at junctions. Allowing U-turns implies the solver can turn around at a junction and double back on the same street. Given that junctions represent street intersections and dead ends, different vehicles may be able to turn around at some junctions but not at others—it depends on whether the junction represents an intersection or dead end. To accommodate this, the U-turn policy parameter is implicitly specified by the number of edges that connect to the junction, which is known as junction valency. The acceptable values for this parameter are listed below; each is followed by a description of its meaning in terms of junction valency.</para>
		/// <para>Allowed—U-turns are permitted at junctions with any number of connected edges. This is the default value.</para>
		/// <para>Not Allowed—U-turns are prohibited at all junctions, regardless of junction valency. Note, however, that U-turns are still permitted at network locations even when this option is chosen; however, you can set the individual network locations&apos; CurbApproach attribute to prohibit U-turns there as well.</para>
		/// <para>Allowed only at Dead Ends—U-turns are prohibited at all junctions except those that have only one adjacent edge (a dead end).</para>
		/// <para>Allowed only at Intersections and Dead Ends—U-turns are prohibited at junctions where exactly two adjacent edges meet but are permitted at intersections (junctions with three or more adjacent edges) and dead ends (junctions with exactly one adjacent edge). Often, networks have extraneous junctions in the middle of road segments. This option prevents vehicles from making U-turns at these locations.</para>
		/// <para>This parameter is ignored unless Travel Mode is set to Custom.</para>
		/// <para><see cref="UturnAtJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? UturnAtJunctions { get; set; } = "Allowed Only at Intersections and Dead Ends";

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
		/// <para>2 (Added Cost)—Traveling through the barrier increases the travel time or distance by the amount specified in the Additional_Time, Additional_Distance, or AdditionalCost field. This barrier type is referred to as an added cost point barrier.</para>
		/// <para>Additional_Time</para>
		/// <para>The added travel time when the barrier is traversed. This field is applicable only for added-cost barriers and when the Measurement Units parameter value is time based.</para>
		/// <para>This field value must be greater than or equal to zero, and its units must be the same as those specified in the Measurement Units parameter.</para>
		/// <para>Additional_Distance</para>
		/// <para>The added distance when the barrier is traversed. This field is applicable only for added-cost barriers and when the Measurement Units parameter value is distance based.</para>
		/// <para>The field value must be greater than or equal to zero, and its units must be the same as those specified in the Measurement Units parameter.</para>
		/// <para>AdditionalCost</para>
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
		public object? PointBarriers { get; set; }

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
		public object? LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// <para>Use this parameter to specify polygons that either completely restrict travel or proportionately scale the time or distance required to travel on the streets intersected by the polygons.</para>
		/// <para>The operation imposes a limit on the number of streets you can restrict using the Polygon Barriers parameter. While there is no limit to the number of polygons you can specify as polygon barriers, the combined number of streets intersected by all the polygons cannot exceed 2,000.</para>
		/// <para>When specifying the polygon barriers, you can set properties for each, such as its name or barrier type, using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the barrier.</para>
		/// <para>BarrierType</para>
		/// <para>Specifies whether the barrier restricts travel completely or scales the cost (such as time or distance) for traveling through it. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Restriction)—Prohibits traveling through any part of the barrier. The barrier is referred to as a restriction polygon barrier since it prohibits traveling on streets intersected by the barrier. One use of this type of barrier is to model floods covering areas of the street that make traveling on those streets impossible.</para>
		/// <para>1 (Scaled Cost)—Scales the cost (such as travel time or distance) required to travel the underlying streets by a factor specified using the ScaledTimeFactor or ScaledDistanceFactor field. If the streets are partially covered by the barrier, the travel time or distance is apportioned and then scaled. For example, a factor of 0.25 means that travel on underlying streets is expected to be four times faster than normal. A factor of 3.0 means it is expected to take three times longer than normal to travel on underlying streets. This barrier type is referred to as a scaled-cost polygon barrier. It can be used to model storms that reduce travel speeds in specific regions, for example.</para>
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
		public object? PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Use Hierarchy</para>
		/// <para>Specifies whether hierarchy will be used when finding the shortest path between facilities and demand points.</para>
		/// <para>Checked (True)—Hierarchy will be used when measuring between facilities and demand points. When hierarchy is used, the tool prefers higher-order streets (such as freeways) to lower-order streets (such as local roads) and can be used to simulate the driver preference of traveling on freeways instead of local roads even if that means a longer trip. This is especially true when finding routes to faraway locations, because drivers on long-distance trips tend to prefer traveling on freeways where stops, intersections, and turns can be avoided. Using hierarchy is computationally faster, especially for long-distance routes, since the tool can determine the best route from a relatively smaller subset of streets.</para>
		/// <para>Unchecked (False)—Hierarchy will not be used when measuring between facilities and demand points. If hierarchy is not used, the tool considers all streets and doesn&apos;t prefer higher-order streets when finding the route. This is often used when finding short-distance routes within a city.</para>
		/// <para>The tool automatically reverts to using hierarchy if the straight-line distance between facilities and demand points is greater than 50 miles, even if you set this parameter to not use hierarchy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object? UseHierarchy { get; set; } = "true";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>Specifies which restrictions will be honored by the tool when finding the best routes between facilities and demand points.</para>
		/// <para>A restriction represents a driving preference or requirement. In most cases, restrictions cause roads to be prohibited. For instance, using the Avoid Toll Roads restriction will result in a route that will include toll roads only when it is required to travel on toll roads to visit an incident or a facility. Height Restriction makes it possible to route around any clearances that are lower than the height of the vehicle. If you are carrying corrosive materials on the vehicle, using the Any Hazmat Prohibited restriction prevents hauling the materials along roads where it is marked illegal to do so.</para>
		/// <para>Some restrictions require an additional value to be specified for their use. This value must be associated with the restriction name and a specific parameter intended to work with the restriction. You can identify such restrictions if their names appear in the AttributeName column of the Attribute Parameter Values parameter. Specify the ParameterValue field for the Attribute Parameter Values parameter for the restriction to be correctly used when finding traversable roads.</para>
		/// <para>Some restrictions are supported only in certain countries; their availability is stated by region in the list below. Of the restrictions that have limited availability within a region, you can determine whether the restriction is available in a particular country by reviewing the table in the Country list section of Network analysis coverage. If a country has a value of Yes in the Logistics Attribute column, the restriction with select availability in the region is supported in that country. If you specify restriction names that are not available in the country where your incidents are located, the service ignores the invalid restrictions. The service also ignores restrictions when the Restriction Usage attribute parameter value is between 0 and 1 (see the Attribute Parameter Value parameter). It prohibits all restrictions when the Restriction Usage parameter value is greater than 0.</para>
		/// <para>The values you provide for this parameter are ignored unless Travel Mode is set to Custom.</para>
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
		public object? Restrictions { get; set; } = "'Avoid Carpool Roads';'Avoid Express Lanes';'Avoid Gates';'Avoid Private Roads';'Avoid Unpaved Roads';'Driving an Automobile';'Roads Under Construction Prohibited';'Through Traffic Prohibited'";

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
		/// <para>In most cases, you can use the default value, PROHIBITED, as the Restriction Usage value if the restriction is dependent on a vehicle characteristic such as vehicle height. However, in some cases, the Restriction Usage value depends on your routing preferences. For example, the Avoid Toll Roads restriction has the default value of AVOID_MEDIUM for the Restriction Usage attribute. This means that when the restriction is used, the tool will route around toll roads when it can. AVOID_MEDIUM also indicates how important it is to avoid toll roads when finding the best route; it has a medium priority. Choosing AVOID_LOW puts lower importance on avoiding tolls; choosing AVOID_HIGH instead gives it a higher importance and makes it more acceptable for the operation to generate longer routes to avoid tolls. Choosing PROHIBITED entirely disallows travel on toll roads, making it impossible for a route to travel on any portion of a toll road. Keep in mind that avoiding or prohibiting toll roads, and avoiding toll payments, is the objective for some. In contrast, others prefer to drive on toll roads, because avoiding traffic is more valuable to them than the money spent on tolls. In the latter case, choose PREFER_LOW, PREFER_MEDIUM, or PREFER_HIGH as the value for Restriction Usage. The higher the preference, the farther the tool will go to travel on the roads associated with the restriction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object? AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Allocation Line Shape</para>
		/// <para>Specifies the type of line features that are output by the tool. The parameter accepts one of the following values:</para>
		/// <para>Straight Line—Straight lines between solution facilities and the demand points allocated to them are returned. This is the default. Drawing straight lines on a map helps you visualize how demand is allocated.</para>
		/// <para>None—A table containing data about the shortest paths between solution facilities and the demand points allocated to them is returned but lines are not.</para>
		/// <para>No matter which value you choose for the Allocation Line Shape parameter, the shortest route is always determined by minimizing the travel time or the travel distance, never using the straight-line distance between demand points and facilities. That is, this parameter only changes the output line shapes; it doesn&apos;t change the measurement method.</para>
		/// <para><see cref="AllocationLineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? AllocationLineShape { get; set; } = "Straight Line";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The mode of transportation to model in the analysis. Travel modes are managed in ArcGIS Online and can be configured by the administrator of your organization to reflect The organization&apos;s workflows. Specify the name of a travel mode that is supported by your organization.</para>
		/// <para>To get a list of supported travel mode names, run the Get Travel Modes tool from the Utilities toolbox under the same GIS Server connection you used to access the tool. The Get Travel Modes tool adds a table, Supported Travel Modes, to the application. Any value in the Travel Mode Name field from the Supported Travel Modes table can be specified as input. You can also specify the value from the Travel Mode Settings field as input. This speeds up tool execution, as the tool does not have to find the settings based on the travel mode name.</para>
		/// <para>The default value, Custom, allows you to configure a custom travel mode using the custom travel mode parameters (UTurn at Junctions, Use Hierarchy, Restrictions, Attribute Parameter Values, and Impedance). The default values of the custom travel mode parameters model traveling by car. You can also choose Custom and set the custom travel mode parameters listed above to model a pedestrian with a fast walking speed or a truck with a given height, weight, and cargo of certain hazardous materials. You can try different settings to get the analysis results you want. Once you have identified the analysis settings, work with your organization&apos;s administrator and save these settings as part of a new or existing travel mode so that everyone in your organization can run the analysis with the same settings.</para>
		/// <para>When you choose Custom, the values you set for the custom travel mode parameters are included in the analysis. Specifying another travel mode, as defined by your organization, causes any values you set for the custom travel mode parameters to be ignored; the tool overrides them with values from the specified travel mode.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TravelMode { get; set; } = "Custom";

		/// <summary>
		/// <para>Impedance</para>
		/// <para>Specifies the impedance, which is a value that represents the effort or cost of traveling along road segments or on other parts of the transportation network.</para>
		/// <para>Travel time is an impedance: a car may take 1 minute to travel a mile along an empty road. Travel times can vary by travel mode—a pedestrian may take more than 20 minutes to walk the same mile, so it is important to choose the right impedance for the travel mode you are modeling.</para>
		/// <para>Travel distance can also be an impedance; the length of a road in kilometers can be thought of as impedance. Travel distance in this sense is the same for all modes—a kilometer for a pedestrian is also a kilometer for a car. (What may change is the pathways on which the different modes are allowed to travel, which affects distance between points, and this is modeled by travel mode settings.)</para>
		/// <para>The value you provide for this parameter is ignored unless Travel Mode is set to Custom, which is the default value.</para>
		/// <para>Travel Time—Historical and live traffic data is used. This option is good for modeling the time it takes automobiles to travel along roads at a specific time of day using live traffic speed data where available. When using TravelTime, you can optionally set the TravelTime::Vehicle Maximum Speed (km/h) attribute parameter to specify the physical limitation of the speed the vehicle is capable of traveling.</para>
		/// <para>Minutes—Live traffic data is not used, but historical average speeds for automobiles data is used.</para>
		/// <para>Truck Travel Time—Historical and live traffic data is used, but the speed is capped at the posted truck speed limit. This is good for modeling the time it takes for the trucks to travel along roads at a specific time. When using TruckTravelTime, you can optionally set the TruckTravelTime::Vehicle Maximum Speed (km/h) attribute parameter to specify the physical limitation of the speed the truck is capable of traveling.</para>
		/// <para>Truck Minutes—Live traffic data is not used, but the smaller of the historical average speeds for automobiles and the posted speed limits for trucks is used.</para>
		/// <para>Walk Time—The default is a speed of 5 km/hr on all roads and paths, but this can be configured through the WalkTime::Walking Speed (km/h) attribute parameter.</para>
		/// <para>Miles—Length measurements along roads are stored in miles and can be used for performing analysis based on shortest distance.</para>
		/// <para>Kilometers—Length measurements along roads are stored in kilometers and can be used for performing analysis based on shortest distance.</para>
		/// <para>Time At One Kilometer Per Hour—The default is a speed of 1 km/hr on all roads and paths. The speed cannot be changed using any attribute parameter.</para>
		/// <para>Drive Time—Models travel times for a car. These travel times are dynamic and fluctuate according to traffic flows in areas where traffic data is available. This is the default value.</para>
		/// <para>Truck Time—Models travel times for a truck. These travel times are static for each road and don&apos;t fluctuate with traffic.</para>
		/// <para>Walk Time—Models travel times for a pedestrian.</para>
		/// <para>Travel Distance—Stores length measurements along roads and paths. To model walk distance, choose this option and ensure Walking is set in the Restriction parameter. Similarly, to model drive or truck distance, choose Travel Distance here and set the appropriate restrictions so your vehicle travels only on roads where it is permitted to do so.</para>
		/// <para>If you choose a time-based impedance, such as TravelTime, TruckTravelTime, Minutes, TruckMinutes, or WalkTime, the Measurement Units parameter must be set to a time-based value. If you choose a distance-based impedance, such as Miles or Kilometers, Measurement Units must be distance based.</para>
		/// <para>Drive Time, Truck Time, Walk Time, and Travel Distance impedance values are no longer supported and will be removed in a future release. If you use one of these values, the tool uses the value of the Time Impedance parameter for time-based values and the Distance Impedance parameter for distance-based values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? Impedance { get; set; } = "Drive Time";

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// <para>Specifies whether the analysis settings will be saved as a network analysis layer file. You cannot directly work with this file even when you open the file in an ArcGIS Desktop application such as ArcMap. It is meant to be sent to Esri Technical Support to diagnose the quality of results returned from the tool.</para>
		/// <para>Checked (True in Python)—The output will be saved as a network analysis layer file. The file will be downloaded to a temporary directory on your machine. In ArcGIS Pro, the location of the downloaded file can be determined by viewing the value for the Output Network Analysis Layer parameter in the entry corresponding to the tool operation in the geoprocessing history of the project. In ArcMap, the location of the file can be determined by accessing the Copy Location option in the shortcut menu of the Output Network Analysis Layer parameter in the entry corresponding to the tool operation in the Geoprocessing Results window.</para>
		/// <para>Unchecked (False in Python)—The output will not be saved as a network analysis layer file. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? SaveOutputNetworkAnalysisLayer { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>This parameter is for internal use only.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object? Overrides { get; set; }

		/// <summary>
		/// <para>Time Impedance</para>
		/// <para>If the impedance for the travel mode, as specified using the Impedance parameter, is time based, the values for the Time Impedance and Impedance parameters must be identical. Otherwise, the operation will return an error.</para>
		/// <para><see cref="TimeImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? TimeImpedance { get; set; } = "TravelTime";

		/// <summary>
		/// <para>Distance Impedance</para>
		/// <para>If the impedance for the travel mode, as specified using the Impedance parameter, is distance based, the values for the Distance Impedance and Impedance parameters must be identical. Otherwise, the operation will return an error.</para>
		/// <para><see cref="DistanceImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? DistanceImpedance { get; set; } = "Kilometers";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>Specifies the format in which the output features will be returned.</para>
		/// <para>Feature Set—The output features will be returned as feature classes and tables. This is the default.</para>
		/// <para>JSON File—The output features will be returned as a compressed file containing the JSON representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more JSON files (with a .json extension) for each of the outputs created by the service.</para>
		/// <para>GeoJSON File—The output features will be returned as a compressed file containing the GeoJSON representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more GeoJSON files (with a .geojson extension) for each of the outputs created by the service.</para>
		/// <para>When a file-based output format, such as JSON File or GeoJSON File, is specified, no outputs will be added to the display because the application, such as ArcMap or ArcGIS Pro, cannot draw the contents of the result file. Instead, the result file is downloaded to a temporary directory on your machine. In ArcGIS Pro, the location of the downloaded file can be determined by viewing the value for the Output Result File parameter in the entry corresponding to the tool operation in the geoprocessing history of the project. In ArcMap, the location of the file can be determined by accessing the Copy Location option in the shortcut menu of the Output Result File parameter in the entry corresponding to the tool operation in the Geoprocessing Results window.</para>
		/// <para><see cref="OutputFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? OutputFormat { get; set; } = "Feature Set";

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>Specifies whether invalid input locations will be ignored.</para>
		/// <para>Checked—Network locations that are unlocated will be ignored and the analysis will run using valid network locations only. The analysis will also continue if locations are on non-traversable elements or have other errors. This is useful if you know the network locations are not all correct, but you want to run the analysis with the network locations that are valid. This is the default.</para>
		/// <para>Unchecked—Invalid locations will not be ignored. Do not run the analysis if there are invalid locations. Correct the invalid locations and rerun the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Network Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; }

		/// <summary>
		/// <para>Output Allocation Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputAllocationLines { get; set; }

		/// <summary>
		/// <para>Output Facilities</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputFacilities { get; set; }

		/// <summary>
		/// <para>Output Demand Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputDemandPoints { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputNetworkAnalysisLayer { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Result File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputResultFile { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Network Analysis Layer Package</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputNetworkAnalysisLayerPackage { get; set; } = "scratchfile";

		#region InnerClass

		/// <summary>
		/// <para>Measurement Units</para>
		/// </summary>
		public enum MeasurementUnitsEnum 
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
		/// <para>Problem Type</para>
		/// </summary>
		public enum ProblemTypeEnum 
		{
			/// <summary>
			/// <para>Maximize Attendance—Facilities are chosen such that as much demand weight as possible is allocated to facilities while assuming the demand weight decreases in relation to the distance between the facility and the demand point.Specialty stores that have little or no competition benefit from this problem type, but it may also be beneficial to general retailers and restaurants that don&apos;t have the data on competitors necessary to perform market share problem types. Some businesses that may benefit from this problem type include coffee shops, fitness centers, dental and medical offices, and electronics stores. Public transit bus stops are often chosen with the help of maximize attendance. Maximize attendance assumes that the farther people must travel to reach your facility, the less likely they are to use it. This is reflected in how the amount of demand allocated to facilities diminishes with distance.The following list describes how the maximize attendance problem type handles demand:</para>
			/// </summary>
			[GPValue("Maximize Attendance")]
			[Description("Maximize Attendance")]
			Maximize_Attendance,

			/// <summary>
			/// <para>Maximize Capacitated Coverage—Facilities are located such that all or the greatest amount of demand can be served without exceeding the capacity of any facility.Maximize capacitated coverage behaves similarly to the minimize impedance and maximize coverage problem types but with the added constraint of capacity. You can specify a capacity for an individual facility by assigning a numeric value to its corresponding Capacity field on the input facilities. If the Capacity field value is null, the facility is assigned a capacity from the Default Capacity property.Use cases for the maximize capacitated coverage problem type include creating territories that encompass a given number of people or businesses, locating hospitals or other medical facilities with a limited number of beds or patients who can be treated, and locating warehouses whose inventory isn&apos;t assumed to be unlimited. The following list describes how the maximize capacitated coverage problem type handles demand:</para>
			/// </summary>
			[GPValue("Maximize Capacitated Coverage")]
			[Description("Maximize Capacitated Coverage")]
			Maximize_Capacitated_Coverage,

			/// <summary>
			/// <para>Maximize Coverage—Facilities are located such that as much demand as possible is allocated to solution facilities within the impedance cutoff.Maximize coverage is frequently used to locate fire stations, police stations, and ERS centers, because emergency services are often required to arrive at all demand points within a specified response time. Note that it is important for all organizations, and critical for emergency services, to have accurate and precise data so analysis results correctly model real-world results.Pizza delivery businesses, as opposed to eat-in pizzerias, try to locate stores where they can cover the most people within a certain drive time. People who order pizzas for delivery don&apos;t typically worry about how far away the pizzeria is; they are mainly concerned with the pizza arriving within an advertised time window. Therefore, a pizza delivery business would subtract pizza preparation time from their advertised delivery time and solve a maximize coverage problem to choose the candidate facility that will capture the most potential customers in the coverage area. (Potential customers of eat-in pizzerias are more affected by distance, since they need to travel to the restaurant; thus, the attendance maximizing and market share problem types are better suited to eat-in restaurants.)The following list describes how the maximize coverage problem type handles demand:</para>
			/// </summary>
			[GPValue("Maximize Coverage")]
			[Description("Maximize Coverage")]
			Maximize_Coverage,

			/// <summary>
			/// <para>Maximize Market Share—A specific number of facilities are chosen such that the allocated demand is maximized in the presence of competitors. The goal is to capture as much of the total market share as possible with a given number of facilities, which you specify. The total market share is the sum of all demand weight for valid demand points.The market share problem types require the most data because, along with knowing your own facilities&apos; weight, you also need to know that of your competitors&apos; facilities. The same types of facilities that use the maximize attendance problem type can also use market share problem types given that they have comprehensive information that includes competitor data. Large discount stores typically use maximize market share to locate a finite set of new stores. The market share problem types use a Huff model, which is also known as a gravity model or spatial interaction.The following list describes how the maximize market share problem type handles demand:</para>
			/// </summary>
			[GPValue("Maximize Market Share")]
			[Description("Maximize Market Share")]
			Maximize_Market_Share,

			/// <summary>
			/// <para>Minimize Facilities—Facilities are chosen such that as much weighted demand as possible is allocated to solution facilities within the travel time or distance cutoff; additionally, the number of facilities required to cover demand is minimized.Minimize facilities is the same as maximize coverage but with the exception of the number of facilities to locate, which in this case is determined by the solver. When the cost of building facilities is not a limiting factor, the same types of organizations that use maximize coverage (emergency response, for instance) use minimize facilities so all possible demand points will be covered. The following list describes how the minimize facilities problem type handles demand:</para>
			/// </summary>
			[GPValue("Minimize Facilities")]
			[Description("Minimize Facilities")]
			Minimize_Facilities,

			/// <summary>
			/// <para>Minimize Impedance—This is also known as the P-Median problem type. Facilities are located such that the sum of all weighted travel time or distance between demand points and solution facilities is minimized. (Weighted travel is the amount of demand allocated to a facility multiplied by the travel distance or time to the facility.)This problem type is traditionally used to locate warehouses, because it can reduce the overall transportation costs of delivering goods to outlets. Since minimize impedance reduces the overall distance the public needs to travel to reach the chosen facilities, the minimize impedance problem without an impedance cutoff is typically regarded as more equitable than other problem types for locating some public sector facilities such as libraries, regional airports, museums, department of motor vehicles offices, and health clinics.The following list describes how the minimize impedance problem type handles demand:</para>
			/// </summary>
			[GPValue("Minimize Impedance")]
			[Description("Minimize Impedance")]
			Minimize_Impedance,

			/// <summary>
			/// <para>Target Market Share—The minimum number of facilities necessary to capture a specific percentage of the total market share in the presence of competitors is chosen. The total market share is the sum of all demand weight for valid demand points. You set the percent of the market share you want to reach and the solver identifies the fewest number of facilities necessary to meet that threshold.The market share problem types require the most data because, along with knowing your own facilities&apos; weight, you also need to know that of your competitors&apos; facilities. The same types of facilities that use the maximize attendance problem type can also use market share problem types given that they have comprehensive information that includes competitor data.Large discount stores typically use the target market share problem type when they want to know how much expansion would be required to reach a certain level of the market share or see what strategy would be needed just to maintain their current market share given the introduction of new competing facilities. The results often represent what stores would do if budgets weren&apos;t a concern. In other cases where budget is a concern, stores revert to the maximize market share problem type and capture as much of the market share as possible with a limited number of facilities.The following list describes how the target market share problem type handles demand:</para>
			/// </summary>
			[GPValue("Target Market Share")]
			[Description("Target Market Share")]
			Target_Market_Share,

		}

		/// <summary>
		/// <para>Measurement Transformation Model</para>
		/// </summary>
		public enum MeasurementTransformationModelEnum 
		{
			/// <summary>
			/// <para>Linear—costdf = λ * impedancedfThe transformed travel time or distance between the facility and the demand point is the same as the time or distance of the shortest path between the two locations. With this option, the impedance parameter (λ) is always set to one. This is the default.</para>
			/// </summary>
			[GPValue("Linear")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Power—costdf = impedancedfλThe transformed travel time or distance between the facility and the demand point is equal to the time or distance of the shortest path raised to the power specified by the impedance parameter (λ). Use the Power option with a positive impedance parameter to specify higher weight to nearby facilities.</para>
			/// </summary>
			[GPValue("Power")]
			[Description("Power")]
			Power,

			/// <summary>
			/// <para>Exponential—costdf = e(λ * impedancedf)The transformed travel time or distance between the facility and the demand point is equal to the mathematical constant e raised to the power specified by the shortest-path network impedance multiplied with the impedance parameter (λ). Use the Exponential option with a positive impedance parameter to specify a high weight to nearby facilities.</para>
			/// </summary>
			[GPValue("Exponential")]
			[Description("Exponential")]
			Exponential,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Demand to Facility—The direction of travel is from demand points to facilities.</para>
			/// </summary>
			[GPValue("Demand to Facility")]
			[Description("Demand to Facility")]
			Demand_to_Facility,

			/// <summary>
			/// <para>Facility to Demand—The direction of travel is from facilities to demand points. This is the default.</para>
			/// </summary>
			[GPValue("Facility to Demand")]
			[Description("Facility to Demand")]
			Facility_to_Demand,

		}

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// </summary>
		public enum TimeZoneForTimeOfDayEnum 
		{
			/// <summary>
			/// <para>Geographically Local—The Time of Day parameter refers to the time zone in which the facilities or demand points are located. If Travel Direction is facilities to demand points, this is the time zone of the facilities. If Travel Direction is demand points to facilities, this is the time zone of the demand points.</para>
			/// </summary>
			[GPValue("Geographically Local")]
			[Description("Geographically Local")]
			Geographically_Local,

			/// <summary>
			/// <para>UTC—The Time of Day parameter refers to coordinated universal time (UTC). Choose this option if you want to find the best location for a specific time, such as now, but aren&apos;t certain in which time zone the facilities or demand points will be located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// </summary>
		public enum UturnAtJunctionsEnum 
		{
			/// <summary>
			/// <para>Allowed—U-turns are permitted at junctions with any number of connected edges. This is the default value.</para>
			/// </summary>
			[GPValue("Allowed")]
			[Description("Allowed")]
			Allowed,

			/// <summary>
			/// <para>Not Allowed—U-turns are prohibited at all junctions, regardless of junction valency. Note, however, that U-turns are still permitted at network locations even when this option is chosen; however, you can set the individual network locations&apos; CurbApproach attribute to prohibit U-turns there as well.</para>
			/// </summary>
			[GPValue("Not Allowed")]
			[Description("Not Allowed")]
			Not_Allowed,

			/// <summary>
			/// <para>Allowed only at Dead Ends—U-turns are prohibited at all junctions except those that have only one adjacent edge (a dead end).</para>
			/// </summary>
			[GPValue("Allowed Only at Dead Ends")]
			[Description("Allowed only at Dead Ends")]
			Allowed_only_at_Dead_Ends,

			/// <summary>
			/// <para>Allowed only at Intersections and Dead Ends—U-turns are prohibited at junctions where exactly two adjacent edges meet but are permitted at intersections (junctions with three or more adjacent edges) and dead ends (junctions with exactly one adjacent edge). Often, networks have extraneous junctions in the middle of road segments. This option prevents vehicles from making U-turns at these locations.</para>
			/// </summary>
			[GPValue("Allowed Only at Intersections and Dead Ends")]
			[Description("Allowed only at Intersections and Dead Ends")]
			Allowed_only_at_Intersections_and_Dead_Ends,

		}

		/// <summary>
		/// <para>Allocation Line Shape</para>
		/// </summary>
		public enum AllocationLineShapeEnum 
		{
			/// <summary>
			/// <para>None—A table containing data about the shortest paths between solution facilities and the demand points allocated to them is returned but lines are not.</para>
			/// </summary>
			[GPValue("None")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Straight Line—Straight lines between solution facilities and the demand points allocated to them are returned. This is the default. Drawing straight lines on a map helps you visualize how demand is allocated.</para>
			/// </summary>
			[GPValue("Straight Line")]
			[Description("Straight Line")]
			Straight_Line,

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
