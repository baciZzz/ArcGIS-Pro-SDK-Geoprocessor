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
	/// <para>Make Location-Allocation Layer</para>
	/// <para>Makes a location-allocation network analysis layer and sets its analysis properties. A location-allocation analysis layer is useful for choosing a given number of facilities from a set of potential locations such that a demand will be allocated to facilities in an optimal and efficient manner.</para>
	/// </summary>
	[Obsolete()]
	public class MakeLocationAllocationLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset on which the location-allocation analysis will be performed.</para>
		/// </param>
		/// <param name="OutNetworkAnalysisLayer">
		/// <para>Output Layer Name</para>
		/// <para>Name of the location-allocation network analysis layer to create.</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>The cost attribute to be used as impedance in the analysis.</para>
		/// </param>
		public MakeLocationAllocationLayer(object InNetworkDataset, object OutNetworkAnalysisLayer, object ImpedanceAttribute)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutNetworkAnalysisLayer = OutNetworkAnalysisLayer;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Location-Allocation Layer</para>
		/// </summary>
		public override string DisplayName => "Make Location-Allocation Layer";

		/// <summary>
		/// <para>Tool Name : MakeLocationAllocationLayer</para>
		/// </summary>
		public override string ToolName => "MakeLocationAllocationLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeLocationAllocationLayer</para>
		/// </summary>
		public override string ExcuteName => "na.MakeLocationAllocationLayer";

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
		public override object[] Parameters => new object[] { InNetworkDataset, OutNetworkAnalysisLayer, ImpedanceAttribute, LocAllocFromTo, LocAllocProblemType, NumberFacilitiesToFind, ImpedanceCutoff, ImpedanceTransformation, ImpedanceParameter, TargetMarketShare, AccumulateAttributeName, UturnPolicy, RestrictionAttributeName, Hierarchy, OutputPathShape, DefaultCapacity, TimeOfDay, OutputLayer };

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>The network dataset on which the location-allocation analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>Name of the location-allocation network analysis layer to create.</para>
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
		/// <para>Travel From</para>
		/// <para>Specifies the direction of travel between facilities and demand points when calculating the network costs.</para>
		/// <para>Facility to Demand—Direction of travel is from facilities to demand points. Fire departments commonly use the this setting, since they are concerned with the time it takes to travel from the fire station to the location of the emergency.</para>
		/// <para>Demand to Facility—Direction of travel is from demand points to facilities. Retail stores commonly use this setting, since they are concerned with the time it takes the shoppers to reach the store.</para>
		/// <para>Using this option can affect the allocation of the demand points to the facilities on a network with one-way restrictions and different impedances based on direction of travel. For instance, a facility may be a 15-minute drive from the demand point to the facility, but only a 10-minute trip when traveling from the facility to the demand point.</para>
		/// <para><see cref="LocAllocFromToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocAllocFromTo { get; set; } = "FACILITY_TO_DEMAND";

		/// <summary>
		/// <para>Location-Allocation Problem Type</para>
		/// <para>The problem type that will be solved. The choice of the problem type depends on the kind of facility being located. Different kinds of facilities have different priorities and constraints.</para>
		/// <para>Minimize impedance—This option solves the warehouse location problem. It selects a set of facilities such that the total sum of weighted impedances (demand at a location times the impedance to the closest facility) is minimized. This problem type is often known as the P-Median problem.</para>
		/// <para>Maximize coverage—This option solves the fire station location problem. It chooses facilities such that all or the greatest amount of demand is within a specified impedance cutoff.</para>
		/// <para>Maximize capacitated coverage—This option solves the location problem where facilities have a finite capacity. It chooses facilities such that all or the greatest amount of demand can be served without exceeding the capacity of any facility. In addition to honoring capacity, it selects facilities such that the total sum of weighted impedance (demand allocated to a facility multiplied by the impedance to or from the facility) is minimized.</para>
		/// <para>Minimize facilities—This option solves the fire station location problem. It chooses the minimum number of facilities needed to cover all or the greatest amount of demand within a specified impedance cutoff.</para>
		/// <para>Maximize attendance—This option solves the neighborhood store location problem where the proportion of demand allocated to the nearest chosen facility falls with increasing distance. The set of facilities that maximize the total allocated demand is chosen. Demand further than the specified impedance cutoff does not affect the chosen set of facilities.</para>
		/// <para>Maximize market share—This option solves the competitive facility location problem. It chooses facilities to maximize market share in the presence of competitive facilities. Gravity model concepts are used to determine the proportion of demand allocated to each facility. The set of facilities that maximizes the total allocated demand is chosen.</para>
		/// <para>Target market share—This option solves the competitive facility location problem. It chooses facilities to reach a specified target market share in the presence of competitive facilities. Gravity model concepts are used to determine the proportion of demand allocated to each facility. The minimum number of facilities needed to reach the specified target market share is chosen.</para>
		/// <para><see cref="LocAllocProblemTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocAllocProblemType { get; set; } = "MINIMIZE_IMPEDANCE";

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>Specifies the number of facilities that the solver should locate.</para>
		/// <para>The facilities with a FacilityType value of Required are always part of the solution when there are more facilities to find than required facilities; any excess facilities to choose are picked from candidate facilities.</para>
		/// <para>Any facilities that have a FacilityType value of Chosen before solving are treated as candidate facilities at solve time.</para>
		/// <para>The parameter value is not considered for the Minimize facilities problem type since the solver determines the minimum number of facilities to locate to maximize coverage.</para>
		/// <para>The parameter value is overridden for the Target market share problem type because the solver searches for the minimum number of facilities required to capture the specified market share.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Impedance Cutoff</para>
		/// <para>Impedance Cutoff specifies the maximum impedance at which a demand point can be allocated to a facility. The maximum impedance is measured by the least-cost path along the network. If a demand point is outside the cutoff, it is left unallocated. This property might be used to model the maximum distance that people are willing to travel to visit your stores or the maximum time that is permitted for a fire department to reach anyone in the community.</para>
		/// <para>Demand points have a Cutoff_[Impedance] property, which, if set, overrides the Impedance Cutoff property of the analysis layer. You might find that people in rural areas are willing to travel up to 10 miles to reach a facility, while urbanites are only willing to travel up to 2 miles. You can model this behavior by setting the impedance cutoff value of the analysis layer to 10 and setting the Cutoff_Miles value of the demand points in urban areas to 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ImpedanceCutoff { get; set; }

		/// <summary>
		/// <para>Impedance Transformation</para>
		/// <para>This sets the equation for transforming the network cost between facilities and demand points. This property, coupled with the Impedance Parameter, specifies how severely the network impedance between facilities and demand points influences the solver&apos;s choice of facilities.</para>
		/// <para>Linear—The transformed network impedance between the facility and the demand point is the same as the shortest-path network impedance between them. With this option, the impedance parameter is always set to one. This is the default.</para>
		/// <para>Power—The transformed network impedance between the facility and the demand point is equal to the shortest-path network impedance raised to the power specified by the impedance parameter. Use this option with a positive impedance parameter to specify higher weight to nearby facilities.</para>
		/// <para>Exponential—The transformed network impedance between the facility and the demand point is equal to the mathematical constant e raised to the power specified by the shortest-path network impedance multiplied with the impedance parameter. Use this option with a positive impedance parameter to specify a very high weight to nearby facilities.Exponential transformations are commonly used in conjunction with an impedance cutoff.</para>
		/// <para>Demand points have an ImpedanceTransformation property, which, if set, overrides the Impedance Transformation property of the analysis layer. You might determine the impedance transformation should be different for urban and rural residents. You can model this by setting the impedance transformation for the analysis layer to match that of rural residents and setting the impedance transformation for the demand points in urban areas to match that of urbanites.</para>
		/// <para><see cref="ImpedanceTransformationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImpedanceTransformation { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Impedance Parameter</para>
		/// <para>Provides a parameter value to the equations specified in the Impedance transformation parameter. The parameter value is ignored when the impedance transformation is of type Linear. For Power and Exponential impedance transformations, the value should be nonzero.</para>
		/// <para>Demand points have an ImpedanceParameter property, which, if set, overrides the Impedance Parameter property of the analysis layer. You might determine that the impedance parameter should be different for urban and rural residents. You can model this by setting the impedance transformation for the analysis layer to match that of rural residents and setting the impedance transformation for the demand points in urban areas to match that of urbanites.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ImpedanceParameter { get; set; } = "1";

		/// <summary>
		/// <para>Target Market Share</para>
		/// <para>Specifies the target market share in percentage to solve for when the Location-Allocation Problem Type parameter is set to Target market share. It is the percentage of the total demand weight that you want your solution facilities to capture. The solver chooses the minimum number of facilities required to capture the target market share specified by this numeric value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object TargetMarketShare { get; set; } = "10";

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
		/// <para>Output Path Shape</para>
		/// <para>No lines—No shape will be generated for the output of the analysis.</para>
		/// <para>Straight lines—The output line shapes will be straight lines connecting the solution facilities to their allocated demand points.</para>
		/// <para><see cref="OutputPathShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Options")]
		public object OutputPathShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Default Capacity</para>
		/// <para>Specifies the default capacity of facilities when the Location-Allocation Problem Type parameter is set to Maximize capacitated coverage. This parameter is ignored for all other problem types.</para>
		/// <para>Facilities have a Capacity property, which, if set to a nonnull value, overrides the Default Capacity parameter for that facility.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DefaultCapacity { get; set; } = "1";

		/// <summary>
		/// <para>Start Time</para>
		/// <para>Indicates the time and date of departure. The departure time can be from facilities or demand points, depending on whether travel is from demand to facility or facility to demand.</para>
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
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeLocationAllocationLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel From</para>
		/// </summary>
		public enum LocAllocFromToEnum 
		{
			/// <summary>
			/// <para>Demand to Facility—Direction of travel is from demand points to facilities. Retail stores commonly use this setting, since they are concerned with the time it takes the shoppers to reach the store.</para>
			/// </summary>
			[GPValue("DEMAND_TO_FACILITY")]
			[Description("Demand to Facility")]
			Demand_to_Facility,

			/// <summary>
			/// <para>Facility to Demand—Direction of travel is from facilities to demand points. Fire departments commonly use the this setting, since they are concerned with the time it takes to travel from the fire station to the location of the emergency.</para>
			/// </summary>
			[GPValue("FACILITY_TO_DEMAND")]
			[Description("Facility to Demand")]
			Facility_to_Demand,

		}

		/// <summary>
		/// <para>Location-Allocation Problem Type</para>
		/// </summary>
		public enum LocAllocProblemTypeEnum 
		{
			/// <summary>
			/// <para>Minimize impedance—This option solves the warehouse location problem. It selects a set of facilities such that the total sum of weighted impedances (demand at a location times the impedance to the closest facility) is minimized. This problem type is often known as the P-Median problem.</para>
			/// </summary>
			[GPValue("MINIMIZE_IMPEDANCE")]
			[Description("Minimize impedance")]
			Minimize_impedance,

			/// <summary>
			/// <para>Maximize coverage—This option solves the fire station location problem. It chooses facilities such that all or the greatest amount of demand is within a specified impedance cutoff.</para>
			/// </summary>
			[GPValue("MAXIMIZE_COVERAGE")]
			[Description("Maximize coverage")]
			Maximize_coverage,

			/// <summary>
			/// <para>Maximize capacitated coverage—This option solves the location problem where facilities have a finite capacity. It chooses facilities such that all or the greatest amount of demand can be served without exceeding the capacity of any facility. In addition to honoring capacity, it selects facilities such that the total sum of weighted impedance (demand allocated to a facility multiplied by the impedance to or from the facility) is minimized.</para>
			/// </summary>
			[GPValue("MAXIMIZE_CAPACITATED_COVERAGE")]
			[Description("Maximize capacitated coverage")]
			Maximize_capacitated_coverage,

			/// <summary>
			/// <para>Minimize facilities—This option solves the fire station location problem. It chooses the minimum number of facilities needed to cover all or the greatest amount of demand within a specified impedance cutoff.</para>
			/// </summary>
			[GPValue("MINIMIZE_FACILITIES")]
			[Description("Minimize facilities")]
			Minimize_facilities,

			/// <summary>
			/// <para>Maximize attendance—This option solves the neighborhood store location problem where the proportion of demand allocated to the nearest chosen facility falls with increasing distance. The set of facilities that maximize the total allocated demand is chosen. Demand further than the specified impedance cutoff does not affect the chosen set of facilities.</para>
			/// </summary>
			[GPValue("MAXIMIZE_ATTENDANCE")]
			[Description("Maximize attendance")]
			Maximize_attendance,

			/// <summary>
			/// <para>Maximize market share—This option solves the competitive facility location problem. It chooses facilities to maximize market share in the presence of competitive facilities. Gravity model concepts are used to determine the proportion of demand allocated to each facility. The set of facilities that maximizes the total allocated demand is chosen.</para>
			/// </summary>
			[GPValue("MAXIMIZE_MARKET_SHARE")]
			[Description("Maximize market share")]
			Maximize_market_share,

			/// <summary>
			/// <para>Target market share—This option solves the competitive facility location problem. It chooses facilities to reach a specified target market share in the presence of competitive facilities. Gravity model concepts are used to determine the proportion of demand allocated to each facility. The minimum number of facilities needed to reach the specified target market share is chosen.</para>
			/// </summary>
			[GPValue("TARGET_MARKET_SHARE")]
			[Description("Target market share")]
			Target_market_share,

		}

		/// <summary>
		/// <para>Impedance Transformation</para>
		/// </summary>
		public enum ImpedanceTransformationEnum 
		{
			/// <summary>
			/// <para>Linear—The transformed network impedance between the facility and the demand point is the same as the shortest-path network impedance between them. With this option, the impedance parameter is always set to one. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Power—The transformed network impedance between the facility and the demand point is equal to the shortest-path network impedance raised to the power specified by the impedance parameter. Use this option with a positive impedance parameter to specify higher weight to nearby facilities.</para>
			/// </summary>
			[GPValue("POWER")]
			[Description("Power")]
			Power,

			/// <summary>
			/// <para>Exponential—The transformed network impedance between the facility and the demand point is equal to the mathematical constant e raised to the power specified by the shortest-path network impedance multiplied with the impedance parameter. Use this option with a positive impedance parameter to specify a very high weight to nearby facilities.Exponential transformations are commonly used in conjunction with an impedance cutoff.</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("Exponential")]
			Exponential,

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
			/// <para>No lines—No shape will be generated for the output of the analysis.</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("No lines")]
			No_lines,

			/// <summary>
			/// <para>Straight lines—The output line shapes will be straight lines connecting the solution facilities to their allocated demand points.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("Straight lines")]
			Straight_lines,

		}

#endregion
	}
}
