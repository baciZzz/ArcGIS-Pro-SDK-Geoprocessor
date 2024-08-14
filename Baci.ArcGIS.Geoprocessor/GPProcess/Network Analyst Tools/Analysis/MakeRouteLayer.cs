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
	/// <para>Make Route Layer</para>
	/// <para>Makes a route network analysis layer and sets its analysis properties. A route analysis layer is useful for determining the best route between a set of network locations based on a specified network cost.</para>
	/// </summary>
	[Obsolete()]
	public class MakeRouteLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset on which the route analysis will be performed.</para>
		/// </param>
		/// <param name="OutNetworkAnalysisLayer">
		/// <para>Output Layer Name</para>
		/// <para>Name of the route network analysis layer to create.</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>The cost attribute to be used as impedance in the analysis.</para>
		/// </param>
		public MakeRouteLayer(object InNetworkDataset, object OutNetworkAnalysisLayer, object ImpedanceAttribute)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutNetworkAnalysisLayer = OutNetworkAnalysisLayer;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Route Layer</para>
		/// </summary>
		public override string DisplayName => "Make Route Layer";

		/// <summary>
		/// <para>Tool Name : MakeRouteLayer</para>
		/// </summary>
		public override string ToolName => "MakeRouteLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeRouteLayer</para>
		/// </summary>
		public override string ExcuteName => "na.MakeRouteLayer";

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
		public override object[] Parameters => new object[] { InNetworkDataset, OutNetworkAnalysisLayer, ImpedanceAttribute, FindBestOrder, OrderingType, TimeWindows, AccumulateAttributeName, UturnPolicy, RestrictionAttributeName, Hierarchy, HierarchySettings, OutputPathShape, StartDateTime, OutputLayer };

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset on which the route analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>Name of the route network analysis layer to create.</para>
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
		/// <para>Reorder Stops to Find Optimal Route</para>
		/// <para>Checked—The stops will be reordered to find the optimal route. This option changes the route analysis from a shortest-path problem to a traveling salesperson problem (TSP).</para>
		/// <para>Unchecked—The stops will be visited in the input order. This is the default.</para>
		/// <para><see cref="FindBestOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FindBestOrder { get; set; } = "false";

		/// <summary>
		/// <para>Preserve Ordering of Stops</para>
		/// <para>Specifies the ordering of stops when Reorder stops to find optimal route parameter is checked.</para>
		/// <para>Preserve first and last stops—The first and last stops by input order will be preserved as the first and last stops in the route.</para>
		/// <para>Preserve first stop—The first stop by input order will be preserved as the first stop in the route, but the last stop can be reordered.</para>
		/// <para>Preserve last stop—The last stop by input order will be preserved as the last stop in the route, but the first stop can be reordered.</para>
		/// <para>Reorder all stops—The first and last stops will not be preserved and can be reordered.</para>
		/// <para><see cref="OrderingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OrderingType { get; set; } = "PRESERVE_BOTH";

		/// <summary>
		/// <para>Use Time Windows</para>
		/// <para>Specifies whether time windows will be used at the stops.</para>
		/// <para>Checked—The route will consider time windows on the stops. If a stop is arrived at before its time window, there will be wait time until the time window starts. If a stop is arrived at after its time window, there will be a time window violation. Total time window violation is balanced against adding impedance when computing the route. This option is enabled only when the impedance is in time units.</para>
		/// <para>Unchecked—The route will ignore time windows on the stops. This is the default.</para>
		/// <para><see cref="TimeWindowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TimeWindows { get; set; } = "false";

		/// <summary>
		/// <para>Accumulators</para>
		/// <para>A list of cost attributes to be accumulated during analysis. These accumulation attributes are for reference only; the solver only uses the cost attribute specified by the Impedance Attribute parameter to calculate the route.</para>
		/// <para>For each cost attribute that is accumulated, a Total_[Impedance] property is added to the routes that are output by the solver.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulators")]
		public object AccumulateAttributeName { get; set; }

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
		public object UturnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>A list of restriction attributes to be applied during the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object RestrictionAttributeName { get; set; }

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>Checked—The hierarchy attribute will be used for the analysis. Using a hierarchy results in the solver preferring higher-order edges to lower-order edges. Hierarchical solves are faster, and they can be used to simulate the preference of a driver who chooses to travel on freeways rather than local roads when possible—even if that means a longer trip. This option is active only if the input network dataset has a hierarchy attribute.</para>
		/// <para>Unchecked—The hierarchy attribute will not be used for the analysis. If hierarchy is not used, the result is an exact route for the network dataset.</para>
		/// <para>The parameter is inactive if a hierarchy attribute is not defined on the network dataset used to perform the analysis.</para>
		/// <para><see cref="HierarchyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Hierarchy")]
		public object Hierarchy { get; set; }

		/// <summary>
		/// <para>Hierarchy Rank Settings</para>
		/// <para>Prior to version 10, this parameter allowed you to change the hierarchy ranges for your analysis from the default hierarchy ranges established in the network dataset. At version 10, this parameter is no longer supported. To change the hierarchy ranges for your analysis, update the default hierarchy ranges in the network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNAHierarchySettings()]
		[Category("Hierarchy")]
		public object HierarchySettings { get; set; }

		/// <summary>
		/// <para>Output Path Shape</para>
		/// <para>Specifies the shape type for the route features that are output by the analysis.</para>
		/// <para>True lines with measures—The output routes will have the exact shape of the underlying network sources. The output includes route measurements for linear referencing. The measurements increase from the first stop and record the cumulative impedance to reach a given position.</para>
		/// <para>True lines without measures—The output routes will have the exact shape of the underlying network sources.</para>
		/// <para>Straight lines—The output route shape will be a single straight line between the stops.</para>
		/// <para>No lines—No shape will be generated for the output routes.</para>
		/// <para>No matter which output shape type is chosen, the best route is always determined by the network impedance, never Euclidean distance. This means that only the route shapes are different, not the underlying traversal of the network.</para>
		/// <para><see cref="OutputPathShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Options")]
		public object OutputPathShape { get; set; } = "TRUE_LINES_WITH_MEASURES";

		/// <summary>
		/// <para>Start Time</para>
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
		public object StartDateTime { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRouteLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reorder Stops to Find Optimal Route</para>
		/// </summary>
		public enum FindBestOrderEnum 
		{
			/// <summary>
			/// <para>Checked—The stops will be reordered to find the optimal route. This option changes the route analysis from a shortest-path problem to a traveling salesperson problem (TSP).</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_BEST_ORDER")]
			FIND_BEST_ORDER,

			/// <summary>
			/// <para>Unchecked—The stops will be visited in the input order. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_INPUT_ORDER")]
			USE_INPUT_ORDER,

		}

		/// <summary>
		/// <para>Preserve Ordering of Stops</para>
		/// </summary>
		public enum OrderingTypeEnum 
		{
			/// <summary>
			/// <para>Preserve first and last stops—The first and last stops by input order will be preserved as the first and last stops in the route.</para>
			/// </summary>
			[GPValue("PRESERVE_BOTH")]
			[Description("Preserve first and last stops")]
			Preserve_first_and_last_stops,

			/// <summary>
			/// <para>Reorder all stops—The first and last stops will not be preserved and can be reordered.</para>
			/// </summary>
			[GPValue("PRESERVE_NONE")]
			[Description("Reorder all stops")]
			Reorder_all_stops,

			/// <summary>
			/// <para>Preserve first stop—The first stop by input order will be preserved as the first stop in the route, but the last stop can be reordered.</para>
			/// </summary>
			[GPValue("PRESERVE_FIRST")]
			[Description("Preserve first stop")]
			Preserve_first_stop,

			/// <summary>
			/// <para>Preserve last stop—The last stop by input order will be preserved as the last stop in the route, but the first stop can be reordered.</para>
			/// </summary>
			[GPValue("PRESERVE_LAST")]
			[Description("Preserve last stop")]
			Preserve_last_stop,

		}

		/// <summary>
		/// <para>Use Time Windows</para>
		/// </summary>
		public enum TimeWindowsEnum 
		{
			/// <summary>
			/// <para>Checked—The route will consider time windows on the stops. If a stop is arrived at before its time window, there will be wait time until the time window starts. If a stop is arrived at after its time window, there will be a time window violation. Total time window violation is balanced against adding impedance when computing the route. This option is enabled only when the impedance is in time units.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_TIMEWINDOWS")]
			USE_TIMEWINDOWS,

			/// <summary>
			/// <para>Unchecked—The route will ignore time windows on the stops. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TIMEWINDOWS")]
			NO_TIMEWINDOWS,

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
			/// <para>Unchecked—The hierarchy attribute will not be used for the analysis. If hierarchy is not used, the result is an exact route for the network dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HIERARCHY")]
			NO_HIERARCHY,

		}

		/// <summary>
		/// <para>Output Path Shape</para>
		/// </summary>
		public enum OutputPathShapeEnum 
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
			/// <para>True lines with measures—The output routes will have the exact shape of the underlying network sources. The output includes route measurements for linear referencing. The measurements increase from the first stop and record the cumulative impedance to reach a given position.</para>
			/// </summary>
			[GPValue("TRUE_LINES_WITH_MEASURES")]
			[Description("True lines with measures")]
			True_lines_with_measures,

			/// <summary>
			/// <para>True lines without measures—The output routes will have the exact shape of the underlying network sources.</para>
			/// </summary>
			[GPValue("TRUE_LINES_WITHOUT_MEASURES")]
			[Description("True lines without measures")]
			True_lines_without_measures,

		}

#endregion
	}
}
