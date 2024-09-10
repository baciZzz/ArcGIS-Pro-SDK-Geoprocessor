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
	/// <para>Make Service Area Analysis Layer</para>
	/// <para>Makes a service area network analysis layer and sets its analysis properties. A service area analysis layer is useful in determining the area of accessibility within a given cutoff cost from a facility location. The layer can be created using a local network dataset or using a routing service hosted online or in a portal.</para>
	/// </summary>
	public class MakeServiceAreaAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </param>
		public MakeServiceAreaAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Service Area Analysis Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Service Area Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeServiceAreaAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeServiceAreaAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeServiceAreaAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeServiceAreaAnalysisLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName, TravelMode, TravelDirection, Cutoffs, TimeOfDay, TimeZone, OutputType, PolygonDetail, GeometryAtOverlaps, GeometryAtCutoffs, PolygonTrimDistance, ExcludeSourcesFromPolygonGeneration, AccumulateAttributes, OutNetworkAnalysisLayer };

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
		public object LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>The name of the travel mode to use in the analysis. The travel mode represents a collection of network settings, such as travel restrictions and U-turn policies, that determine how a pedestrian, car, truck, or other medium of transportation moves through the network. Travel modes are defined on your network data source.</para>
		/// <para>An arcpy.na.TravelMode object and a string containing the valid JSON representation of a travel mode can also be used as input to the parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel to or from the facilities.</para>
		/// <para>Away from facilities—The service area represents traveling away from the facilities. This is the default.</para>
		/// <para>Toward facilities—The service area represents traveling toward the facilities.</para>
		/// <para>Using this parameter can result in different service areas on a network with one-way restrictions and different impedances based on direction of travel. The service area for a pizza delivery store, for example, should be created away from the facility, whereas the service area of a hospital should be created toward the facility.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelDirection { get; set; } = "FROM_FACILITIES";

		/// <summary>
		/// <para>Cutoffs</para>
		/// <para>The extent of the service area to be calculated in the units of the impedance attribute used by your selected travel mode. For example, when analyzing driving time, a cutoff value of 10 means that the resulting service area will represent the area reachable within a 10-minute drive time.</para>
		/// <para>Multiple cutoffs can be set to create concentric service areas. For example, to find 2-, 3-, and 5-minute service areas for the same facility, specify 2, 3, and 5 as the values for this parameter.</para>
		/// <para>This default cutoff value can be overridden on a per-facility basis by specifying individual break values in the facilities sublayer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Cutoffs { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time to depart from or arrive at the facilities of the service area layer. The interpretation of this value as a departure or arrival time depends on whether travel is away from or toward the facilities.</para>
		/// <para>It represents the departure time if Travel Direction is set to Away from facilities.</para>
		/// <para>It represents the arrival time if Travel Direction is set to Toward facilities.</para>
		/// <para>The Time of Day parameter is most useful for finding the roads that can be reached based on a travel mode that uses an impedance attribute that varies with the time of the day, such as one based on dynamic traffic conditions. Solving the same analysis using different Time of Day values allows you to see how a facility&apos;s reach changes over time. For example, the five-minute service area around a fire station may start out large in the early morning, diminish during the morning rush hour, grow in the late morning, and so on, throughout the day.</para>
		/// <para>A date and time can be specified as 10/21/2015 10:30 AM.</para>
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
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone for the time of day parameter.</para>
		/// <para>Local time at locations—The time of day parameter will use the time zone or zones in which the facilities are located. The start or end times of the service areas are staggered by time zone. This is the default.For example, setting time of day to 9:00 a.m. causes service areas to be generated for 9:00 a.m. eastern time for any facilities in the eastern time zone, 9:00 a.m. central time for facilities in the central time zone, 9:00 a.m. mountain time for facilities in the mountain time zone, and so on. If stores in a chain that span the U.S. open at 9:00 a.m. local time, choose this parameter value to find market territories at opening time for all stores in one solve. First, the stores in the eastern time zone open and a polygon is generated. An hour later, stores open in the central time zone, and so on. Nine o&apos;clock is always in local time but staggered in real time.</para>
		/// <para>UTC—The time of day parameter will use coordinated universal time (UTC). All facilities are reached or departed from simultaneously, regardless of the time zone or zones in which they are located.Setting time of day to 2:00 p.m. causes service areas to be generated for 9:00 a.m. eastern standard time for any facilities in the eastern time zone, 8:00 a.m. central standard time for facilities in the central time zone, 7:00 a.m. mountain standard time for facilities in the mountain time zone, and so on.One of the cases in which the UTC option is useful is to visualize emergency response coverage for a jurisdiction that is split into two time zones. The emergency vehicles are loaded as facilities. Time of day is set to now in UTC. (You need to determine what the current time and date are in terms of UTC to correctly use this option.) Other properties are set and the analysis is solved. Even though a time-zone boundary divides the vehicles, the results show areas that can be reached given current traffic conditions. This same process can be used for other times as well, not just for now.The scenario above assumes standard time. During daylight saving time, the eastern, central, and mountain times will each be one hour ahead (that is, 10:00, 9:00, and 8:00 a.m., respectively).</para>
		/// <para>&lt;bold/&gt;</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the type of output to be generated. Service area output can be line features representing the roads reachable before the cutoffs are exceeded or the polygon features encompassing these lines (representing the reachable area).</para>
		/// <para>Polygons—The service area output will contain polygons only. This is the default.</para>
		/// <para>Lines—The service area output will contain lines only.</para>
		/// <para>Polygons and lines—The service area output will contain both polygons and lines.</para>
		/// <para>The Lines and Polygons and lines output types are not available if the network data source is a service on a version of Portal for ArcGIS that does not support line generation.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object OutputType { get; set; } = "POLYGONS";

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>Specifies the level of detail of the output polygons.</para>
		/// <para>Standard—Polygons with a standard level of detail will be created. This is the default.</para>
		/// <para>Generalized—Generalized polygons will be created using the network&apos;s hierarchy attribute to produce results quickly. This option is not available if the network does not have a hierarchy attribute.</para>
		/// <para>High—Polygons with a higher level of detail will be creates for applications in which precise results are important.</para>
		/// <para>If your analysis includes an urban area with a grid-like street network, the difference between generalized and standard polygons will be minimal. However, for mountain and rural roads, the standard and detailed polygons may present significantly more accurate results than generalized polygons.</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object PolygonDetail { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Geometry at Overlaps</para>
		/// <para>Specifies the behavior of service-area output from multiple facilities in relation to one another.</para>
		/// <para>Overlap—Individual polygons or sets of lines for each facility will be created. The polygons or lines can overlap each other. This is the default.</para>
		/// <para>Dissolve—The polygons of multiple facilities that have the same cutoff value will be joined into a single polygon. This option does not apply to line output.</para>
		/// <para>Split—An area will be assigned to the closest facility so polygons or lines do not overlap each other.</para>
		/// <para><see cref="GeometryAtOverlapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object GeometryAtOverlaps { get; set; } = "OVERLAP";

		/// <summary>
		/// <para>Geometry at Cutoffs</para>
		/// <para>Specifies the behavior of service area output for a single facility when multiple cutoff values are specified. This parameter does not apply to line output.</para>
		/// <para>Rings—Each polygon will include only the area between consecutive cutoff values. It will not include the area between the facility and any smaller cutoffs. For example, if you create 5- and 10-minute service areas, the 5-minute service area polygon will include the area reachable in 0 to 5 minutes, and the 10-minute service area polygon will include the area reachable in 5 to 10 minutes. This is the default.</para>
		/// <para>Disks—Each polygon will include the area reachable from the facility up to the cutoff value, including the area reachable within smaller cutoff values. For example, if you create 5- and 10-minute service areas, the 10-minute service area polygon will include the area under the 5-minute service area polygon.</para>
		/// <para><see cref="GeometryAtCutoffsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object GeometryAtCutoffs { get; set; } = "RINGS";

		/// <summary>
		/// <para>Polygon Trim Distance</para>
		/// <para>The service area polygon trim distance. The polygon trim distance is the distance the service area polygon will extend from the road when no other reachable roads are nearby, similar to a line buffer size. This is useful when the network is sparse and you don&apos;t want the service area to cover large areas where there are no features.</para>
		/// <para>This parameter includes a value and units for the distance. The default value is 100 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Output Geometry")]
		public object PolygonTrimDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Exclude Sources From Polygon Generation</para>
		/// <para>The network dataset edge sources that will be excluded when generating service area polygons. Polygons will not be generated around the excluded sources, even though they are traversed in the analysis.</para>
		/// <para>Excluding a network source from service area polygons does not prevent those sources from being traversed. Excluding sources from service area polygons only influences the polygon shape of the service areas. To prevent traversal of a given network source, you must create an appropriate restriction when defining your network dataset.</para>
		/// <para>This is useful if you have some network sources that you don&apos;t want to be included in the polygon generation because they create less accurate polygons or are inconsequential for the service area analysis. For example, while creating a walk-time service area in a multimodal network that includes streets and metro lines, you should choose to exclude the metro lines from polygon generation. Although the traveler can use the metro lines, they cannot stop partway along a metro line and enter a nearby building. Instead, they must travel the full length of the metro line, exit the metro system at a station, then use the streets to walk to the building. It would be inaccurate to generate a polygon feature around a metro line.</para>
		/// <para>This parameter is not available when the output geometry types do not include polygons, there are less than two edge sources in the network, the network data source is an ArcGIS Online service, or the network data source is a service on a version of Portal for ArcGIS which does not support excluding sources.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object ExcludeSourcesFromPolygonGeneration { get; set; }

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>A list of cost attributes to be accumulated during analysis. These accumulated attributes are for reference only; the solver only uses the cost attribute used by your designated travel mode when solving the analysis.</para>
		/// <para>For each cost attribute that is accumulated, a Total_[Impedance] property is populated in the network analysis output features.</para>
		/// <para>This parameter is not available if the analysis layer is not configured to output lines, the network data source is an ArcGIS Online service, or the network data source is a service on a version of Portal for ArcGIS that does not support accumulation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeServiceAreaAnalysisLayer SetEnviroment(object workspace = null )
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
			/// <para>Toward facilities—The service area represents traveling toward the facilities.</para>
			/// </summary>
			[GPValue("TO_FACILITIES")]
			[Description("Toward facilities")]
			Toward_facilities,

			/// <summary>
			/// <para>Away from facilities—The service area represents traveling away from the facilities. This is the default.</para>
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
			/// <para>UTC—The time of day parameter will use coordinated universal time (UTC). All facilities are reached or departed from simultaneously, regardless of the time zone or zones in which they are located.Setting time of day to 2:00 p.m. causes service areas to be generated for 9:00 a.m. eastern standard time for any facilities in the eastern time zone, 8:00 a.m. central standard time for facilities in the central time zone, 7:00 a.m. mountain standard time for facilities in the mountain time zone, and so on.One of the cases in which the UTC option is useful is to visualize emergency response coverage for a jurisdiction that is split into two time zones. The emergency vehicles are loaded as facilities. Time of day is set to now in UTC. (You need to determine what the current time and date are in terms of UTC to correctly use this option.) Other properties are set and the analysis is solved. Even though a time-zone boundary divides the vehicles, the results show areas that can be reached given current traffic conditions. This same process can be used for other times as well, not just for now.The scenario above assumes standard time. During daylight saving time, the eastern, central, and mountain times will each be one hour ahead (that is, 10:00, 9:00, and 8:00 a.m., respectively).</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The time of day parameter will use the time zone or zones in which the facilities are located. The start or end times of the service areas are staggered by time zone. This is the default.For example, setting time of day to 9:00 a.m. causes service areas to be generated for 9:00 a.m. eastern time for any facilities in the eastern time zone, 9:00 a.m. central time for facilities in the central time zone, 9:00 a.m. mountain time for facilities in the mountain time zone, and so on. If stores in a chain that span the U.S. open at 9:00 a.m. local time, choose this parameter value to find market territories at opening time for all stores in one solve. First, the stores in the eastern time zone open and a polygon is generated. An hour later, stores open in the central time zone, and so on. Nine o&apos;clock is always in local time but staggered in real time.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Polygons—The service area output will contain polygons only. This is the default.</para>
			/// </summary>
			[GPValue("POLYGONS")]
			[Description("Polygons")]
			Polygons,

			/// <summary>
			/// <para>Lines—The service area output will contain lines only.</para>
			/// </summary>
			[GPValue("LINES")]
			[Description("Lines")]
			Lines,

			/// <summary>
			/// <para>Polygons and lines—The service area output will contain both polygons and lines.</para>
			/// </summary>
			[GPValue("POLYGONS_AND_LINES")]
			[Description("Polygons and lines")]
			Polygons_and_lines,

		}

		/// <summary>
		/// <para>Polygon Detail</para>
		/// </summary>
		public enum PolygonDetailEnum 
		{
			/// <summary>
			/// <para>Generalized—Generalized polygons will be created using the network&apos;s hierarchy attribute to produce results quickly. This option is not available if the network does not have a hierarchy attribute.</para>
			/// </summary>
			[GPValue("GENERALIZED")]
			[Description("Generalized")]
			Generalized,

			/// <summary>
			/// <para>Standard—Polygons with a standard level of detail will be created. This is the default.</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard")]
			Standard,

			/// <summary>
			/// <para>High—Polygons with a higher level of detail will be creates for applications in which precise results are important.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

		/// <summary>
		/// <para>Geometry at Overlaps</para>
		/// </summary>
		public enum GeometryAtOverlapsEnum 
		{
			/// <summary>
			/// <para>Overlap—Individual polygons or sets of lines for each facility will be created. The polygons or lines can overlap each other. This is the default.</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Dissolve—The polygons of multiple facilities that have the same cutoff value will be joined into a single polygon. This option does not apply to line output.</para>
			/// </summary>
			[GPValue("DISSOLVE")]
			[Description("Dissolve")]
			Dissolve,

			/// <summary>
			/// <para>Split—An area will be assigned to the closest facility so polygons or lines do not overlap each other.</para>
			/// </summary>
			[GPValue("SPLIT")]
			[Description("Split")]
			Split,

		}

		/// <summary>
		/// <para>Geometry at Cutoffs</para>
		/// </summary>
		public enum GeometryAtCutoffsEnum 
		{
			/// <summary>
			/// <para>Rings—Each polygon will include only the area between consecutive cutoff values. It will not include the area between the facility and any smaller cutoffs. For example, if you create 5- and 10-minute service areas, the 5-minute service area polygon will include the area reachable in 0 to 5 minutes, and the 10-minute service area polygon will include the area reachable in 5 to 10 minutes. This is the default.</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("Rings")]
			Rings,

			/// <summary>
			/// <para>Disks—Each polygon will include the area reachable from the facility up to the cutoff value, including the area reachable within smaller cutoff values. For example, if you create 5- and 10-minute service areas, the 10-minute service area polygon will include the area under the 5-minute service area polygon.</para>
			/// </summary>
			[GPValue("DISKS")]
			[Description("Disks")]
			Disks,

		}

#endregion
	}
}
