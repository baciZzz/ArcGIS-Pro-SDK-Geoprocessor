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
	/// <para>Make Service Area Layer</para>
	/// <para>Make Service Area Layer</para>
	/// <para>Makes a service area network analysis layer and sets its analysis properties. A service area analysis layer is useful in determining the area of accessibility within a given cutoff cost from a facility location.</para>
	/// </summary>
	[Obsolete()]
	public class MakeServiceAreaLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset on which the service area analysis will be performed.</para>
		/// </param>
		/// <param name="OutNetworkAnalysisLayer">
		/// <para>Output Layer Name</para>
		/// <para>Name of the service area network analysis layer to create.</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>The cost attribute to be used as impedance in the analysis.</para>
		/// </param>
		public MakeServiceAreaLayer(object InNetworkDataset, object OutNetworkAnalysisLayer, object ImpedanceAttribute)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutNetworkAnalysisLayer = OutNetworkAnalysisLayer;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Service Area Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Service Area Layer";

		/// <summary>
		/// <para>Tool Name : MakeServiceAreaLayer</para>
		/// </summary>
		public override string ToolName() => "MakeServiceAreaLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeServiceAreaLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeServiceAreaLayer";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutNetworkAnalysisLayer, ImpedanceAttribute, TravelFromTo!, DefaultBreakValues!, PolygonType!, Merge!, NestingType!, LineType!, Overlap!, Split!, ExcludedSourceName!, AccumulateAttributeName!, UturnPolicy!, RestrictionAttributeName!, PolygonTrim!, PolyTrimValue!, LinesSourceFields!, Hierarchy!, TimeOfDay!, OutputLayer! };

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset on which the service area analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>Name of the service area network analysis layer to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Impedance Attribute</para>
		/// <para>The cost attribute to be used as impedance in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImpedanceAttribute { get; set; }

		/// <summary>
		/// <para>Travel From or To Facility</para>
		/// <para>Specifies the direction of travel to or from the facilities.</para>
		/// <para>Away from Facilities—The service area is created in the direction away from the facilities.</para>
		/// <para>Toward Facilities—The service area is created in the direction towards the facilities.</para>
		/// <para>Using this option can result in different service areas on a network with one-way restrictions and having different impedances based on direction of travel. The service area for a pizza delivery store, for example, should be created away from the facility, whereas the service area of a hospital should be created toward the facility.</para>
		/// <para><see cref="TravelFromToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelFromTo { get; set; } = "TRAVEL_FROM";

		/// <summary>
		/// <para>Default Break Values</para>
		/// <para>Default impedance values indicating the extent of the service area to be calculated. The default can be overridden by specifying the break value on the facilities.</para>
		/// <para>Multiple polygon breaks can be set to create concentric service areas. For instance, to find 2-, 3-, and 5-minute service areas for the same facility, specify &quot;2 3 5&quot; as the value for the Default break values parameter (the numbers 2, 3, and 5 should be separated by a space).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DefaultBreakValues { get; set; }

		/// <summary>
		/// <para>Polygon Type</para>
		/// <para>Specifies the type of polygons to be generated.</para>
		/// <para>Simple polygons—Creates generalized polygons, which are generated quickly and are fairly accurate, except on the fringes. This is the default.</para>
		/// <para>Detailed polygons—Creates detailed polygons, which accurately model the service area lines and may contain islands of unreached areas. This option is slower than generating generalized polygons.</para>
		/// <para>No polygons—Turns off polygon generation for the case in which only service area lines are desired.</para>
		/// <para>If your data is of an urban area with a gridlike network, the difference between generalized and detailed polygons would be minimal. However, for mountain and rural roads, the detailed polygons may present significantly more accurate results than generalized polygons.</para>
		/// <para><see cref="PolygonTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object? PolygonType { get; set; } = "SIMPLE_POLYS";

		/// <summary>
		/// <para>Merge Polygons with Similar Ranges</para>
		/// <para>Specifies the options to merge polygons that share similar break values. This option is applicable only when generating polygons for multiple facilities.</para>
		/// <para>Overlap—Creates individual polygons for each facility. The polygons can overlap each other.</para>
		/// <para>Split—Creates individual polygons that are closest for each facility. The polygons do not overlap each other.</para>
		/// <para>Dissolve— Joins the polygons of multiple facilities that have the same break value.</para>
		/// <para><see cref="MergeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object? Merge { get; set; } = "NO_MERGE";

		/// <summary>
		/// <para>Polygon Nest Option</para>
		/// <para>Specifies the option to create concentric service area polygons as disks or rings. This option is applicable only when multiple break values are specified for the facilities.</para>
		/// <para>Rings—Do not include the area of the smaller breaks. This creates polygons going between consecutive breaks. Use this option if you want to find the area from one break to another.</para>
		/// <para>Disks— Creates the polygons going from the facility to the break. For instance, If you create 5- and 10-minute service areas, then the 10-minute service area polygon will include the area under the 5-minute service area polygon. Use this option if you want to find the entire area from the facility to the break for each break.</para>
		/// <para><see cref="NestingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object? NestingType { get; set; } = "RINGS";

		/// <summary>
		/// <para>Line Type</para>
		/// <para>Specifies the type of lines to be generated based on the service area analysis. Selecting the True Lines or True lines with measures option for large service areas will increase the amount of memory consumed by the analysis.</para>
		/// <para>No lines—Do not generate lines. This is the default.</para>
		/// <para>True lines—Lines are generated without measures.</para>
		/// <para>True lines with measures—Lines are generated with measures. The measure values are generated based on the impedance value on each end of the edge with the intermediate vertices interpolated. Do not use this option if faster performance is desired.</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object? LineType { get; set; } = "NO_LINES";

		/// <summary>
		/// <para>Overlap Lines</para>
		/// <para>Determines whether overlapping lines are generated when the service area lines are computed.</para>
		/// <para>Checked—Include a separate line feature for each facility when the facilities have service area lines that are coincident.</para>
		/// <para>Unchecked—Include each service area line at most once and associate it with its closest (least impedance) facility.</para>
		/// <para><see cref="OverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object? Overlap { get; set; } = "true";

		/// <summary>
		/// <para>Split Lines when They Cross a Service Area Break</para>
		/// <para>Checked—Split every line between two breaks into two lines, each lying within its break. This is useful if you want to symbolize the service area lines by break. Otherwise, leave this option unchecked for optimal performance.</para>
		/// <para>Unchecked—The lines are not split at the boundaries of the breaks. This is the default.</para>
		/// <para><see cref="SplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object? Split { get; set; } = "true";

		/// <summary>
		/// <para>Exclude Sources from Polygon Generation</para>
		/// <para>Specifies the list of network sources to be excluded when generating the polygons. The geometry of traversed elements from the excluded sources will be omitted from all polygons.</para>
		/// <para>This is useful if you have some network sources that you don&apos;t want to be included in the polygon generation because they create less accurate polygons or are inconsequential for the service area analysis. For example, while creating a drive time service area in a multimodal network of streets and rails, you should choose to exclude the rail lines from polygon generation so as to correctly model where a vehicle could travel.</para>
		/// <para>Excluding a network source from service area polygons does not prevent those sources from being traversed. Excluding sources from service area polygons only influences the polygon shape of the service areas. If you want to prevent traversal of a given network source, you must create an appropriate restriction when defining your network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object? ExcludedSourceName { get; set; }

		/// <summary>
		/// <para>Accumulators</para>
		/// <para>A list of cost attributes to be accumulated during analysis. These accumulation attributes are for reference only; the solver only uses the cost attribute specified by the Impedance Attribute parameter to calculate the route.</para>
		/// <para>For each cost attribute that is accumulated, a Total_[Impedance] property is added to the routes that are output by the solver.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulators")]
		public object? AccumulateAttributeName { get; set; }

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// <para>Specifies the U-turn policy that will be used at junctions. Allowing U-turns implies that the solver can turn around at a junction and double back on the same street. Given that junctions represent street intersections and dead ends, different vehicles may be able to turn around at some junctions but not at others—it depends on whether the junction represents an intersection or a dead end. To accommodate this, the U-turn policy parameter is implicitly specified by the number of edges that connect to the junction, which is known as junction valency. The acceptable values for this parameter are listed below; each is followed by a description of its meaning in terms of junction valency.</para>
		/// <para>Allowed—U-turns are permitted at junctions with any number of connected edges. This is the default value.</para>
		/// <para>Not allowed—U-turns are prohibited at all junctions, regardless of junction valency. However, U-turns are still permitted at network locations even when this setting is chosen, but you can set the individual network location&apos;s CurbApproach property to prohibit U-turns there as well.</para>
		/// <para>Allowed at dead ends only—U-turns are prohibited at all junctions, except those that have only one adjacent edge (a dead end).</para>
		/// <para>Allowed at dead ends and intersections only—U-turns are prohibited at junctions where exactly two adjacent edges meet but are permitted at intersections (junctions with three or more adjacent edges) and dead ends (junctions with exactly one adjacent edge). Often, networks have extraneous junctions in the middle of road segments. This option prevents vehicles from making U-turns at these locations.</para>
		/// <para>If you need a more precisely defined U-turn policy, consider adding a global turn delay evaluator to a network cost attribute or adjusting its settings if one exists, and pay particular attention to the configuration of reverse turns. You can also set the CurbApproach property of your network locations.</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object? UturnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>A list of restriction attributes to be applied during the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object? RestrictionAttributeName { get; set; }

		/// <summary>
		/// <para>Trim Polygons</para>
		/// <para>Checked—Trims the polygons containing the edges at the periphery of the service area to be within the specified distance of these outer edges. This is useful if the network is very sparse and you don&apos;t want the service area to cover large areas where there are no features.</para>
		/// <para>Unchecked—Do not trim polygons.</para>
		/// <para><see cref="PolygonTrimEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object? PolygonTrim { get; set; } = "true";

		/// <summary>
		/// <para>Polygon Trim</para>
		/// <para>Specifies the distance within which the service area polygons are trimmed. The parameter includes a value and units for the distance. The default value is 100 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Polygon Generation Options")]
		public object? PolyTrimValue { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Include Network Source Fields in Lines</para>
		/// <para>Checked—Add the SourceID, SourceOID, FromPosition, and ToPosition fields to the service area lines to hold information about the underlying source features traversed during the analysis. This can be useful to join the results of the service area lines to the original source data.</para>
		/// <para>Unchecked—Do not add the source fields (SourceID, SourceOID, FromPosition, and ToPosition) to the service area lines.</para>
		/// <para><see cref="LinesSourceFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object? LinesSourceFields { get; set; } = "true";

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>Checked—The hierarchy attribute will be used for the analysis. Using a hierarchy results in the solver preferring higher-order edges to lower-order edges. Hierarchical solves are faster, and they can be used to simulate the preference of a driver who chooses to travel on freeways rather than local roads when possible—even if that means a longer trip. This option is active only if the input network dataset has a hierarchy attribute.</para>
		/// <para>Unchecked—The hierarchy attribute will not be used for the analysis. If hierarchy is not used, the result is a service area measured along all edges of the network dataset regardless of hierarchy level.</para>
		/// <para>The parameter is inactive if a hierarchy attribute is not defined on the network dataset used to perform the analysis.</para>
		/// <para><see cref="HierarchyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Hierarchy")]
		public object? Hierarchy { get; set; } = "false";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time to depart from or arrive at the facilities of the service area layer. The interpretation of this value as a depart or arrive time depends on whether travel is away from or toward the facilities.</para>
		/// <para>It represents the departure time if Travel From or To Facility is set to TRAVEL_FROM.</para>
		/// <para>It represents the arrival time if Travel From or To Facility is set to TRAVEL_TO.</para>
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
		/// <para>Repeatedly solving the same analysis, but using different Time of Day values, allows you to see how a facility&apos;s reach changes over time. For instance, the five-minute service area around a fire station may start out large in the early morning, diminish during the morning rush hour, grow in the late morning, and so on throughout the day.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeServiceAreaLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel From or To Facility</para>
		/// </summary>
		public enum TravelFromToEnum 
		{
			/// <summary>
			/// <para>Toward Facilities—The service area is created in the direction towards the facilities.</para>
			/// </summary>
			[GPValue("TRAVEL_TO")]
			[Description("Toward Facilities")]
			Toward_Facilities,

			/// <summary>
			/// <para>Away from Facilities—The service area is created in the direction away from the facilities.</para>
			/// </summary>
			[GPValue("TRAVEL_FROM")]
			[Description("Away from Facilities")]
			Away_from_Facilities,

		}

		/// <summary>
		/// <para>Polygon Type</para>
		/// </summary>
		public enum PolygonTypeEnum 
		{
			/// <summary>
			/// <para>Simple polygons—Creates generalized polygons, which are generated quickly and are fairly accurate, except on the fringes. This is the default.</para>
			/// </summary>
			[GPValue("SIMPLE_POLYS")]
			[Description("Simple polygons")]
			Simple_polygons,

			/// <summary>
			/// <para>Detailed polygons—Creates detailed polygons, which accurately model the service area lines and may contain islands of unreached areas. This option is slower than generating generalized polygons.</para>
			/// </summary>
			[GPValue("DETAILED_POLYS")]
			[Description("Detailed polygons")]
			Detailed_polygons,

			/// <summary>
			/// <para>No polygons—Turns off polygon generation for the case in which only service area lines are desired.</para>
			/// </summary>
			[GPValue("NO_POLYS")]
			[Description("No polygons")]
			No_polygons,

		}

		/// <summary>
		/// <para>Merge Polygons with Similar Ranges</para>
		/// </summary>
		public enum MergeEnum 
		{
			/// <summary>
			/// <para>Overlap—Creates individual polygons for each facility. The polygons can overlap each other.</para>
			/// </summary>
			[GPValue("NO_MERGE")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Split—Creates individual polygons that are closest for each facility. The polygons do not overlap each other.</para>
			/// </summary>
			[GPValue("NO_OVERLAP")]
			[Description("Split")]
			Split,

			/// <summary>
			/// <para>Dissolve— Joins the polygons of multiple facilities that have the same break value.</para>
			/// </summary>
			[GPValue("MERGE")]
			[Description("Dissolve")]
			Dissolve,

		}

		/// <summary>
		/// <para>Polygon Nest Option</para>
		/// </summary>
		public enum NestingTypeEnum 
		{
			/// <summary>
			/// <para>Rings—Do not include the area of the smaller breaks. This creates polygons going between consecutive breaks. Use this option if you want to find the area from one break to another.</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("Rings")]
			Rings,

			/// <summary>
			/// <para>Disks— Creates the polygons going from the facility to the break. For instance, If you create 5- and 10-minute service areas, then the 10-minute service area polygon will include the area under the 5-minute service area polygon. Use this option if you want to find the entire area from the facility to the break for each break.</para>
			/// </summary>
			[GPValue("DISKS")]
			[Description("Disks")]
			Disks,

		}

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>No lines—Do not generate lines. This is the default.</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("No lines")]
			No_lines,

			/// <summary>
			/// <para>True lines—Lines are generated without measures.</para>
			/// </summary>
			[GPValue("TRUE_LINES")]
			[Description("True lines")]
			True_lines,

			/// <summary>
			/// <para>True lines with measures—Lines are generated with measures. The measure values are generated based on the impedance value on each end of the edge with the intermediate vertices interpolated. Do not use this option if faster performance is desired.</para>
			/// </summary>
			[GPValue("TRUE_LINES_WITH_MEASURES")]
			[Description("True lines with measures")]
			True_lines_with_measures,

		}

		/// <summary>
		/// <para>Overlap Lines</para>
		/// </summary>
		public enum OverlapEnum 
		{
			/// <summary>
			/// <para>Checked—Include a separate line feature for each facility when the facilities have service area lines that are coincident.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERLAP")]
			OVERLAP,

			/// <summary>
			/// <para>Unchecked—Include each service area line at most once and associate it with its closest (least impedance) facility.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_OVERLAP")]
			NON_OVERLAP,

		}

		/// <summary>
		/// <para>Split Lines when They Cross a Service Area Break</para>
		/// </summary>
		public enum SplitEnum 
		{
			/// <summary>
			/// <para>Checked—Split every line between two breaks into two lines, each lying within its break. This is useful if you want to symbolize the service area lines by break. Otherwise, leave this option unchecked for optimal performance.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT")]
			SPLIT,

			/// <summary>
			/// <para>Unchecked—The lines are not split at the boundaries of the breaks. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPLIT")]
			NO_SPLIT,

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
		/// <para>Trim Polygons</para>
		/// </summary>
		public enum PolygonTrimEnum 
		{
			/// <summary>
			/// <para>Checked—Trims the polygons containing the edges at the periphery of the service area to be within the specified distance of these outer edges. This is useful if the network is very sparse and you don&apos;t want the service area to cover large areas where there are no features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRIM_POLYS")]
			TRIM_POLYS,

			/// <summary>
			/// <para>Unchecked—Do not trim polygons.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRIM_POLYS")]
			NO_TRIM_POLYS,

		}

		/// <summary>
		/// <para>Include Network Source Fields in Lines</para>
		/// </summary>
		public enum LinesSourceFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Add the SourceID, SourceOID, FromPosition, and ToPosition fields to the service area lines to hold information about the underlying source features traversed during the analysis. This can be useful to join the results of the service area lines to the original source data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LINES_SOURCE_FIELDS")]
			LINES_SOURCE_FIELDS,

			/// <summary>
			/// <para>Unchecked—Do not add the source fields (SourceID, SourceOID, FromPosition, and ToPosition) to the service area lines.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LINES_SOURCE_FIELDS")]
			NO_LINES_SOURCE_FIELDS,

		}

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// </summary>
		public enum HierarchyEnum 
		{
			/// <summary>
			/// <para>Checked—The hierarchy attribute will be used for the analysis. Using a hierarchy results in the solver preferring higher-order edges to lower-order edges. Hierarchical solves are faster, and they can be used to simulate the preference of a driver who chooses to travel on freeways rather than local roads when possible—even if that means a longer trip. This option is active only if the input network dataset has a hierarchy attribute.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_HIERARCHY")]
			USE_HIERARCHY,

			/// <summary>
			/// <para>Unchecked—The hierarchy attribute will not be used for the analysis. If hierarchy is not used, the result is a service area measured along all edges of the network dataset regardless of hierarchy level.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HIERARCHY")]
			NO_HIERARCHY,

		}

#endregion
	}
}
