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
	/// <para>Generate Origin Destination Cost Matrix</para>
	/// <para>Generate Origin Destination Cost Matrix</para>
	/// <para>Creates an origin-destination (OD) cost matrix from multiple origins to multiple destinations. An OD cost matrix is a table that contains the travel time and travel distance from each origin to each destination. Additionally, it ranks the destinations that each origin connects to in ascending order based on the minimum time or distance required to travel from that origin to each destination. The best path on the street network is discovered for each origin-destination pair, and the travel times and travel distances are stored as attributes of the output lines. Even though the lines are straight for performance reasons, they always store the travel time and travel distance along the street network, not straight-line distance.</para>
	/// </summary>
	public class GenerateOriginDestinationCostMatrix : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Origins">
		/// <para>Origins</para>
		/// <para>Specifies the starting points from which to travel to the destinations.</para>
		/// <para>You can add up to 1000 origins.</para>
		/// <para>When specifying the origins, you can set properties for each—such as its name or the number of destinations to find from the origin— using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the origin. The name can be a unique identifier for the origin. The name is included in the output lines (as the OriginName field) and in the output origins (as the Name field) and can be used to join additional information from the tool outputs to the attributes of your origins.</para>
		/// <para>If the name is not specified, a unique name prefixed with Location is automatically generated.</para>
		/// <para>TargetDestinationCount</para>
		/// <para>The maximum number of destinations to find for the origin.</para>
		/// <para>If a value is not specified, the value from the Number of Destinations to Find parameter is used.</para>
		/// <para>This field allows you to specify a different number of destinations to find for each origin. For example, using this field, you can find the three closest destinations from one origin and the two closest destinations from another origin.</para>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for destinations from a given origin. This attribute allows you to specify a different cutoff value for each destination. For example, using this attribute, you can specify to search for destinations within five minutes of travel time from one origin and to search for destinations within eight minutes of travel time from another origin.</para>
		/// <para>The units of the cutoff are the same as the units of your impedance attribute. If a value is not specified, the value from the Cutoff parameter is used.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may depart from the origin. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The vehicle can depart the origin in either direction, so a U-turn is allowed at the origin. This setting can be chosen if it is possible and practical for a vehicle to turn around at the origin. This decision may depend on the width of the road and the amount of traffic or whether the origin has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 (Right side of vehicle)—When the vehicle departs the origin, the origin must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle departs the origin, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—For this tool, this value functions the same as 0 (Either side of vehicle).</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider an origin on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to depart the origin from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to depart from an origin and not have a lane of traffic between the vehicle and the origin, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		/// <param name="Destinations">
		/// <para>Destinations</para>
		/// <para>Specifies the ending point locations to travel to from the origins.</para>
		/// <para>You can add up to 1000 destinations.</para>
		/// <para>When specifying the destinations, you can set properties for each—such as its name—using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the destination. The name can be a unique identifier for the destination. The name is included in the output lines (as the DestinationName field) and in the output destinations (as the Name field) and can be used to join additional information from the tool outputs to the attributes of your destinations.</para>
		/// <para>If the name is not specified, a unique name prefixed with Location is automatically generated.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at a destination. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The vehicle can arrive at the destination in either direction, so a U-turn is allowed at the origin. This setting can be chosen if it is possible and practical for a vehicle to turn around at the destination. This decision may depend on the width of the road and the amount of traffic or whether the destination has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 ( Right side of vehicle)—When the vehicle arrive at the destination, the destination must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle arrives at the destination, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—For this tool, this value functions the same as 0 (Either side of vehicle).</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider an origin on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to depart the origin from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to depart from an origin and not have a lane of traffic between the vehicle and the origin, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		public GenerateOriginDestinationCostMatrix(object Origins, object Destinations)
		{
			this.Origins = Origins;
			this.Destinations = Destinations;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Origin Destination Cost Matrix</para>
		/// </summary>
		public override string DisplayName() => "Generate Origin Destination Cost Matrix";

		/// <summary>
		/// <para>Tool Name : GenerateOriginDestinationCostMatrix</para>
		/// </summary>
		public override string ToolName() => "GenerateOriginDestinationCostMatrix";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.GenerateOriginDestinationCostMatrix</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.GenerateOriginDestinationCostMatrix";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Origins, Destinations, TravelMode!, TimeUnits!, DistanceUnits!, AnalysisRegion!, NumberOfDestinationsToFind!, Cutoff!, TimeOfDay!, TimeZoneForTimeOfDay!, PointBarriers!, LineBarriers!, PolygonBarriers!, UturnAtJunctions!, UseHierarchy!, Restrictions!, AttributeParameterValues!, Impedance!, OriginDestinationLineShape!, SaveOutputNetworkAnalysisLayer!, Overrides!, TimeImpedance!, DistanceImpedance!, OutputFormat!, IgnoreInvalidLocations!, SolveSucceeded!, OutputOriginDestinationLines!, OutputOrigins!, OutputDestinations!, OutputNetworkAnalysisLayer!, OutputResultFile!, OutputNetworkAnalysisLayerPackage! };

		/// <summary>
		/// <para>Origins</para>
		/// <para>Specifies the starting points from which to travel to the destinations.</para>
		/// <para>You can add up to 1000 origins.</para>
		/// <para>When specifying the origins, you can set properties for each—such as its name or the number of destinations to find from the origin— using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the origin. The name can be a unique identifier for the origin. The name is included in the output lines (as the OriginName field) and in the output origins (as the Name field) and can be used to join additional information from the tool outputs to the attributes of your origins.</para>
		/// <para>If the name is not specified, a unique name prefixed with Location is automatically generated.</para>
		/// <para>TargetDestinationCount</para>
		/// <para>The maximum number of destinations to find for the origin.</para>
		/// <para>If a value is not specified, the value from the Number of Destinations to Find parameter is used.</para>
		/// <para>This field allows you to specify a different number of destinations to find for each origin. For example, using this field, you can find the three closest destinations from one origin and the two closest destinations from another origin.</para>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for destinations from a given origin. This attribute allows you to specify a different cutoff value for each destination. For example, using this attribute, you can specify to search for destinations within five minutes of travel time from one origin and to search for destinations within eight minutes of travel time from another origin.</para>
		/// <para>The units of the cutoff are the same as the units of your impedance attribute. If a value is not specified, the value from the Cutoff parameter is used.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may depart from the origin. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The vehicle can depart the origin in either direction, so a U-turn is allowed at the origin. This setting can be chosen if it is possible and practical for a vehicle to turn around at the origin. This decision may depend on the width of the road and the amount of traffic or whether the origin has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 (Right side of vehicle)—When the vehicle departs the origin, the origin must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle departs the origin, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—For this tool, this value functions the same as 0 (Either side of vehicle).</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider an origin on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to depart the origin from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to depart from an origin and not have a lane of traffic between the vehicle and the origin, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		public object Origins { get; set; }

		/// <summary>
		/// <para>Destinations</para>
		/// <para>Specifies the ending point locations to travel to from the origins.</para>
		/// <para>You can add up to 1000 destinations.</para>
		/// <para>When specifying the destinations, you can set properties for each—such as its name—using the following attributes:</para>
		/// <para>Name</para>
		/// <para>The name of the destination. The name can be a unique identifier for the destination. The name is included in the output lines (as the DestinationName field) and in the output destinations (as the Name field) and can be used to join additional information from the tool outputs to the attributes of your destinations.</para>
		/// <para>If the name is not specified, a unique name prefixed with Location is automatically generated.</para>
		/// <para>CurbApproach</para>
		/// <para>Specifies the direction a vehicle may arrive at a destination. The field value is specified as one of the following integers (use the numeric code, not the name in parentheses):</para>
		/// <para>0 (Either side of vehicle)—The vehicle can arrive at the destination in either direction, so a U-turn is allowed at the origin. This setting can be chosen if it is possible and practical for a vehicle to turn around at the destination. This decision may depend on the width of the road and the amount of traffic or whether the destination has a parking lot where vehicles can enter and turn around.</para>
		/// <para>1 ( Right side of vehicle)—When the vehicle arrive at the destination, the destination must be on the right side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the right-hand side.</para>
		/// <para>2 (Left side of vehicle)—When the vehicle arrives at the destination, the curb must be on the left side of the vehicle. A U-turn is prohibited. This is typically used for vehicles such as buses that must depart from the bus stop on the left-hand side.</para>
		/// <para>3 (No U-Turn)—For this tool, this value functions the same as 0 (Either side of vehicle).</para>
		/// <para>The CurbApproach attribute is designed to work with both kinds of national driving standards: right-hand traffic (United States) and left-hand traffic (United Kingdom). First, consider an origin on the left side of a vehicle. It is always on the left side regardless of whether the vehicle travels on the left or right half of the road. What may change with national driving standards is your decision to depart the origin from one of two directions, that is, so it ends up on the right or left side of the vehicle. For example, if you want to depart from an origin and not have a lane of traffic between the vehicle and the origin, choose 1 (Right side of vehicle) in the United States and 2 (Left side of vehicle) in the United Kingdom.</para>
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
		public object Destinations { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The mode of transportation to model in the analysis. Travel modes are managed in ArcGIS Online and can be configured by the administrator of your organization to reflect the organization&apos;s workflows. Specify the name of a travel mode that is supported by your organization.</para>
		/// <para>To get a list of supported travel mode names, run the Get Travel Modes tool from the Utilities toolbox under the same GIS Server connection you used to access the tool. The Get Travel Modes tool adds a table, Supported Travel Modes, to the application. Any value in the Travel Mode Name field from the Supported Travel Modes table can be specified as input. You can also specify the value from the Travel Mode Settings field as input. This speeds up tool execution, as the tool does not have to find the settings based on the travel mode name.</para>
		/// <para>The default value, Custom, allows you to configure a custom travel mode using the custom travel mode parameters (UTurn at Junctions, Use Hierarchy, Restrictions, Attribute Parameter Values, and Impedance). The default values of the custom travel mode parameters model traveling by car. You can also choose Custom and set the custom travel mode parameters listed above to model a pedestrian with a fast walking speed or a truck with a given height, weight, and cargo of certain hazardous materials. You can try different settings to get the analysis results you want. Once you have identified the analysis settings, work with your organization&apos;s administrator and save these settings as part of a new or existing travel mode so that everyone in your organization can run the analysis with the same settings.</para>
		/// <para>When you choose Custom, the values you set for the custom travel mode parameters are included in the analysis. Specifying another travel mode, as defined by your organization, causes any values you set for the custom travel mode parameters to be ignored; the tool overrides them with values from the specified travel mode.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TravelMode { get; set; } = "Custom";

		/// <summary>
		/// <para>Time Units</para>
		/// <para>Specifies the units that will be used to measure and report the total travel time between each origin-destination pair.</para>
		/// <para>Seconds—The time unit is seconds.</para>
		/// <para>Minutes—The time unit is minutes.</para>
		/// <para>Hours—The time unit is hours.</para>
		/// <para>Days—The time unit is days.</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the units that will be used to measure and report the total travel distance between each origin-destination pair.</para>
		/// <para>Meters—The linear unit is meters.</para>
		/// <para>Kilometers—The linear unit is kilometers.</para>
		/// <para>Feet—The linear unit is feet.</para>
		/// <para>Yards—The linear unit is yards.</para>
		/// <para>Miles—The linear unit is miles.</para>
		/// <para>Nautical Miles—The linear unit is nautical miles.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnits { get; set; } = "Kilometers";

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
		/// <para>Number of Destinations to Find</para>
		/// <para>The maximum number of destinations to find per origin. If a value for this parameter is not specified, the output matrix includes travel costs from each origin to every destination. Individual origins can have their own values (specified as the TargetDestinationCount field) that override the Number of Destinations to Find parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Analysis")]
		public object? NumberOfDestinationsToFind { get; set; }

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>The travel time or travel distance value at which to stop searching for destinations from a given origin. Any destination beyond the cutoff value will not be considered. Individual origins can have their own values (specified as the Cutoff field) that override the Cutoff parameter value.</para>
		/// <para>The value must be in the units specified by the Time Units parameter if the impedance attribute of your travel mode is time based or in the units specified by the Distance Units parameter if the impedance attribute of your travel mode is distance based. If a value is not specified, the tool will not enforce any travel time or travel distance limit when searching for destinations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Analysis")]
		public object? Cutoff { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time and date the routes will begin.</para>
		/// <para>If you are modeling the driving travel mode and specify the current date and time as the value for this parameter, the tool will use live traffic conditions to find the best routes, and the total travel time will be based on traffic conditions.</para>
		/// <para>Specifying a time of day results in more accurate routes and estimations of travel times because the travel times account for the traffic conditions that are applicable for that date and time.</para>
		/// <para>The Time Zone for Time of Day parameter specifies whether this time and date refer to UTC or the time zone in which the stop is located.</para>
		/// <para>The tool ignores this parameter when Measurement Units isn&apos;t set to a time-based unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// <para>Specifies the time zone of the Time of Day parameter.</para>
		/// <para>Geographically Local—The Time of Day parameter refers to the time zone in which the first stop of a route is located. If you are generating many routes that start in multiple time zones, the start times are staggered in coordinated universal time (UTC). For example, a Time of Day value of 10:00 a.m., 2 January, means a start time of 10:00 a.m. eastern standard time (UTC-3:00) for routes beginning in the eastern time zone and 10:00 a.m. central standard time (UTC-4:00) for routes beginning in the central time zone. The start times are offset by one hour in UTC. The arrive and depart times and dates recorded in the output Stops feature class will refer to the local time zone of the first stop for each route.</para>
		/// <para>UTC—The Time of Day parameter refers to UTC. Choose this option if you want to generate a route for a specific time, such as now, but aren&apos;t certain in which time zone the first stop will be located. If you are generating many routes spanning multiple time zones, the start times in UTC are simultaneous. For example, a Time of Day value of 10:00 a.m., 2 January, means a start time of 5:00 a.m. eastern standard time (UTC-5:00) for routes beginning in the eastern time zone and 4:00 a.m. central standard time (UTC-6:00) for routes beginning in the central time zone. Both routes start at 10:00 a.m. UTC. The arrive and depart times and dates recorded in the output Stops feature class will refer to UTC.</para>
		/// <para><see cref="TimeZoneForTimeOfDayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeZoneForTimeOfDay { get; set; } = "Geographically Local";

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
		/// <para>UTurn at Junctions</para>
		/// <para>&lt;para/&gt;Specifies the U-turn policy at junctions. Allowing U-turns implies the solver can turn around at a junction and double back on the same street. Given that junctions represent street intersections and dead ends, different vehicles may be able to turn around at some junctions but not at others—it depends on whether the junction represents an intersection or dead end. To accommodate this, the U-turn policy parameter is implicitly specified by the number of edges that connect to the junction, which is known as junction valency. The acceptable values for this parameter are listed below; each is followed by a description of its meaning in terms of junction valency.</para>
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
		/// <para>Use Hierarchy</para>
		/// <para>Specifies whether hierarchy will be used when finding the shortest paths between stops.</para>
		/// <para>Checked (True in Python)—Hierarchy will be used when finding routes. When hierarchy is used, the tool identifies higher-order streets (such as freeways) before lower-order streets (such as local roads) and can be used to simulate the driver preference of traveling on freeways instead of local roads even if that means a longer trip. This is especially useful when finding routes to faraway locations, because drivers on long-distance trips tend to prefer traveling on freeways, where stops, intersections, and turns can be avoided. Using hierarchy is computationally faster, especially for long-distance routes, as the tool identifies the best route from a relatively smaller subset of streets.</para>
		/// <para>Unchecked (False in Python)—Hierarchy will not be used when finding routes. If hierarchy is not used, the tool considers all the streets and doesn&apos;t necessarily identify higher-order streets when finding the route. This is often used when finding short routes in a city.</para>
		/// <para>The tool automatically reverts to using hierarchy if the straight-line distance between facilities and demand points is greater than 50 miles (80.46 kilometers), even if this parameter is unchecked (set to False in Python).</para>
		/// <para>This parameter is ignored unless Travel Mode is set to Custom. When modeling a custom walking mode, it is recommended that you turn off hierarchy since hierarchy is designed for motorized vehicles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object? UseHierarchy { get; set; } = "true";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>The restrictions that will be honored by the tool when finding the best routes.</para>
		/// <para>A restriction represents a driving preference or requirement. In most cases, restrictions cause roads to be prohibited. For instance, using the Avoid Toll Roads restriction will result in a route that will include toll roads only when it is required to travel on toll roads to visit an incident or a facility. Height Restriction makes it possible to route around any clearances that are lower than the height of the vehicle. If you are carrying corrosive materials on the vehicle, using the Any Hazmat Prohibited restriction prevents hauling the materials along roads where it is marked illegal to do so.</para>
		/// <para>The values you provide for this parameter are ignored unless Travel Mode is set to Custom.</para>
		/// <para>Some restrictions require an additional value to be specified for their use. This value must be associated with the restriction name and a specific parameter intended to work with the restriction. You can identify such restrictions if their names appear in the AttributeName column of the Attribute Parameter Values parameter. Specify the ParameterValue field for the Attribute Parameter Values parameter for the restriction to be correctly used when finding traversable roads.</para>
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
		/// <para>Origin Destination Line Shape</para>
		/// <para>The resulting lines of an OD cost matrix can be represented with either straight-line geometry or no geometry at all. In both cases, the route is always computed along the street network by minimizing the travel time or the travel distance, never using the straight-line distance between origins and destinations.</para>
		/// <para>Straight Line—Straight lines connect origins and destinations.</para>
		/// <para>None—Do not return any shapes for the lines that connect origins and destinations. This is useful when you have a large number of origins and destinations and are interested only in the OD cost matrix table (and not the output line shapes).</para>
		/// <para><see cref="OriginDestinationLineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? OriginDestinationLineShape { get; set; } = "None";

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
		/// <para>CSV File—The output features will be returned as a compressed file containing a comma-separated values (CSV) representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more CSV files (with a .csv extension) for each of the outputs created by the service.</para>
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
		/// <para>Output Origin Destination Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputOriginDestinationLines { get; set; }

		/// <summary>
		/// <para>Output Origins</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputOrigins { get; set; }

		/// <summary>
		/// <para>Output Destinations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputDestinations { get; set; }

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
		/// <para>Time Zone for Time of Day</para>
		/// </summary>
		public enum TimeZoneForTimeOfDayEnum 
		{
			/// <summary>
			/// <para>Geographically Local—The Time of Day parameter refers to the time zone in which the first stop of a route is located. If you are generating many routes that start in multiple time zones, the start times are staggered in coordinated universal time (UTC). For example, a Time of Day value of 10:00 a.m., 2 January, means a start time of 10:00 a.m. eastern standard time (UTC-3:00) for routes beginning in the eastern time zone and 10:00 a.m. central standard time (UTC-4:00) for routes beginning in the central time zone. The start times are offset by one hour in UTC. The arrive and depart times and dates recorded in the output Stops feature class will refer to the local time zone of the first stop for each route.</para>
			/// </summary>
			[GPValue("Geographically Local")]
			[Description("Geographically Local")]
			Geographically_Local,

			/// <summary>
			/// <para>UTC—The Time of Day parameter refers to UTC. Choose this option if you want to generate a route for a specific time, such as now, but aren&apos;t certain in which time zone the first stop will be located. If you are generating many routes spanning multiple time zones, the start times in UTC are simultaneous. For example, a Time of Day value of 10:00 a.m., 2 January, means a start time of 5:00 a.m. eastern standard time (UTC-5:00) for routes beginning in the eastern time zone and 4:00 a.m. central standard time (UTC-6:00) for routes beginning in the central time zone. Both routes start at 10:00 a.m. UTC. The arrive and depart times and dates recorded in the output Stops feature class will refer to UTC.</para>
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
		/// <para>Origin Destination Line Shape</para>
		/// </summary>
		public enum OriginDestinationLineShapeEnum 
		{
			/// <summary>
			/// <para>None—Do not return any shapes for the lines that connect origins and destinations. This is useful when you have a large number of origins and destinations and are interested only in the OD cost matrix table (and not the output line shapes).</para>
			/// </summary>
			[GPValue("None")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Straight Line—Straight lines connect origins and destinations.</para>
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
			/// <para>CSV File—The output features will be returned as a compressed file containing a comma-separated values (CSV) representation of the outputs. When this option is specified, the output is a single file (with a .zip extension) that contains one or more CSV files (with a .csv extension) for each of the outputs created by the service.</para>
			/// </summary>
			[GPValue("CSV File")]
			[Description("CSV File")]
			CSV_File,

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
