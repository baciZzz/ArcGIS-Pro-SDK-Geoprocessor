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
	/// <para>Make Closest Facility Analysis Layer</para>
	/// <para>Makes a closest facility network analysis layer and sets its analysis properties. A closest facility analysis layer is useful in determining the closest facility or facilities to an incident based on a specified travel mode. The layer can be created using a local network dataset or using a service hosted online or in a portal.</para>
	/// </summary>
	public class MakeClosestFacilityAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </param>
		public MakeClosestFacilityAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Closest Facility Analysis Layer</para>
		/// </summary>
		public override string DisplayName => "Make Closest Facility Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeClosestFacilityAnalysisLayer</para>
		/// </summary>
		public override string ToolName => "MakeClosestFacilityAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeClosestFacilityAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName => "na.MakeClosestFacilityAnalysisLayer";

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
		public override object[] Parameters => new object[] { NetworkDataSource, LayerName!, TravelMode!, TravelDirection!, Cutoff!, NumberOfFacilitiesToFind!, TimeOfDay!, TimeZone!, TimeOfDayUsage!, LineShape!, AccumulateAttributes!, GenerateDirectionsOnSolve!, OutNetworkAnalysisLayer!, IgnoreInvalidLocations! };

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
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel between facilities and incidents.</para>
		/// <para>Toward facilities—Direction of travel is from incidents to facilities. Retail stores commonly use this setting, since they are concerned with the time it takes the shoppers (incidents) to reach the store (facility). This is the default.</para>
		/// <para>Away from facilities—Direction of travel is from facilities to incidents. Fire departments commonly use this setting, since they are concerned with the time it takes to travel from the fire station (facility) to the location of the emergency (incident).</para>
		/// <para>The direction of travel may influence the facilities found if the network contains one-way streets or impedances based on the direction of travel. For instance, it might take 10 minutes to drive from a particular incident to a particular facility, but the journey might take 15 minutes traveling in the other direction, from the facility to the incident, because of one-way streets or different traffic conditions.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelDirection { get; set; } = "TO_FACILITIES";

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>The impedance value at which to stop searching for facilities for a given incident in the units of the impedance attribute used by your chosen Travel Mode. This cutoff can be overridden on a per-incident basis by specifying individual cutoff values in the incidents sublayer when the Travel Direction is Toward facilities or on a per-facility basis by specifying individual cutoff values in the facilities sublayer when the Travel Direction is Away from facilities. By default, no cutoff is used for the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cutoff { get; set; }

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>The number of closest facilities to find per incident. This default can be overridden by specifying an individual value for the TargetFacilityCount property in the incidents sublayer. The default number of facilities to find is one.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time and date at which the routes should begin or end. The interpretation of this value depends on whether Time of Day Usage is set to be the start time or the end time of the route.</para>
		/// <para>If you have chosen a traffic-based impedance attribute, the solution will be generated given dynamic traffic conditions at the time of day specified here. A date and time can be specified as 5/14/2012 10:30 AM.</para>
		/// <para>Instead of using a particular date, a day of the week can be specified using the following dates:</para>
		/// <para>Today—12/30/1899</para>
		/// <para>Sunday—12/31/1899</para>
		/// <para>Monday—1/1/1900</para>
		/// <para>Tuesday—1/2/1900</para>
		/// <para>Wednesday—1/3/1900</para>
		/// <para>Thursday—1/4/1900</para>
		/// <para>Friday—1/5/1900</para>
		/// <para>Saturday—1/6/1900</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone of the Time of Day parameter.</para>
		/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the facilities or incidents are located. This is the default.</para>
		/// <para>If Time of Day Usage is set to Start time and Travel Direction is Away from facilities, this is the time zone of the facilities.</para>
		/// <para>If Time of Day Usage is set to Start time and Travel Direction is Towards facilities, this is the time zone of the incidents.</para>
		/// <para>If Time of Day Usage is set to End time and Travel Direction is Away from facilities, this is the time zone of the incidents.</para>
		/// <para>If Time of Day Usage is set to End time and Travel Direction is Towards facilities, this is the time zone of the facilities.</para>
		/// <para>UTC—The Time of Day parameter refers to Coordinated Universal Time (UTC). Choose this option if you want to find what&apos;s nearest for a specific time, such as now, but aren&apos;t certain in which time zone the facilities or incidents will be located.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Time of Day Usage</para>
		/// <para>Specifies whether the value of the Time of Day parameter represents the arrival or departure time for the route or routes.</para>
		/// <para>Start time—Time of Day is interpreted as the departure time from the facility or incident. This is the default.When this setting is chosen, Time of Day indicates the solver should find the best route given a departure time.</para>
		/// <para>End time—Time of Day is interpreted as the arrival time at the facility or incident. This option is useful if you want to know what time to depart from a location so you arrive at the destination at the time specified in Time of Day.</para>
		/// <para><see cref="TimeOfDayUsageEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeOfDayUsage { get; set; } = "START_TIME";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>Specifies the shape type that will be used for the route features that are output by the analysis.</para>
		/// <para>Regardless of the output shape type specified, the best route is always determined by the network impedance, never Euclidean distance. This means that only the route shapes are different, not the underlying traversal of the network.</para>
		/// <para>Along network—The output routes will have the exact shape of the underlying network sources. The output includes route measurements for linear referencing. The measurements increase from the first stop and record the cumulative impedance to reach a given position.</para>
		/// <para>No lines—No shape will be generated for the output routes.</para>
		/// <para>Straight lines—The output route shape will be a single straight line between the stops.</para>
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
		/// <para>Checked—Indicates that the turn-by-turn directions will be generated on solve.</para>
		/// <para>Unchecked—Indicates that the turn-by-turn directions will not be generated on solve. This is the default.</para>
		/// <para>For an analysis in which generating turn-by-turn directions is not needed, leaving this option unchecked will considerably reduce the time it takes to solve the analysis.</para>
		/// <para><see cref="GenerateDirectionsOnSolveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Directions")]
		public object? GenerateDirectionsOnSolve { get; set; } = "false";

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

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
		public MakeClosestFacilityAnalysisLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward facilities—Direction of travel is from incidents to facilities. Retail stores commonly use this setting, since they are concerned with the time it takes the shoppers (incidents) to reach the store (facility). This is the default.</para>
			/// </summary>
			[GPValue("TO_FACILITIES")]
			[Description("Toward facilities")]
			Toward_facilities,

			/// <summary>
			/// <para>Away from facilities—Direction of travel is from facilities to incidents. Fire departments commonly use this setting, since they are concerned with the time it takes to travel from the fire station (facility) to the location of the emergency (incident).</para>
			/// </summary>
			[GPValue("FROM_FACILITIES")]
			[Description("Away from facilities")]
			Away_from_facilities,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—The Time of Day parameter refers to Coordinated Universal Time (UTC). Choose this option if you want to find what&apos;s nearest for a specific time, such as now, but aren&apos;t certain in which time zone the facilities or incidents will be located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the facilities or incidents are located. This is the default.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Time of Day Usage</para>
		/// </summary>
		public enum TimeOfDayUsageEnum 
		{
			/// <summary>
			/// <para>Start time—Time of Day is interpreted as the departure time from the facility or incident. This is the default.When this setting is chosen, Time of Day indicates the solver should find the best route given a departure time.</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("Start time")]
			Start_time,

			/// <summary>
			/// <para>End time—Time of Day is interpreted as the arrival time at the facility or incident. This option is useful if you want to know what time to depart from a location so you arrive at the destination at the time specified in Time of Day.</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("End time")]
			End_time,

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
			/// <para>Checked—Indicates that the turn-by-turn directions will be generated on solve.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DIRECTIONS")]
			DIRECTIONS,

			/// <summary>
			/// <para>Unchecked—Indicates that the turn-by-turn directions will not be generated on solve. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DIRECTIONS")]
			NO_DIRECTIONS,

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
