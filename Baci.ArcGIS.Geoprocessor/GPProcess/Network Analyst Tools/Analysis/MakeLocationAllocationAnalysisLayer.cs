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
	/// <para>Make Location-Allocation Analysis Layer</para>
	/// <para>Makes a location-allocation network analysis layer and sets its analysis properties. A location-allocation analysis layer is useful for choosing a given number of facilities from a set of potential locations such that a demand will be allocated to facilities in an optimal and efficient manner. The layer can be created using a local network dataset or using a service hosted online or in a portal.</para>
	/// </summary>
	public class MakeLocationAllocationAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>The network dataset or service on which the network analysis will be performed. Use the portal URL for a service.</para>
		/// </param>
		public MakeLocationAllocationAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Location-Allocation Analysis Layer</para>
		/// </summary>
		public override string DisplayName => "Make Location-Allocation Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeLocationAllocationAnalysisLayer</para>
		/// </summary>
		public override string ToolName => "MakeLocationAllocationAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeLocationAllocationAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName => "na.MakeLocationAllocationAnalysisLayer";

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
		public override object[] Parameters => new object[] { NetworkDataSource, LayerName, TravelMode, TravelDirection, ProblemType, Cutoff, NumberOfFacilitiesToFind, DecayFunctionType, DecayFunctionParameterValue, TargetMarketShare, Capacity, TimeOfDay, TimeZone, LineShape, AccumulateAttributes, OutNetworkAnalysisLayer };

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
		/// <para>Specifies the direction of travel between facilities and demand points when calculating the network costs.</para>
		/// <para>Away from facilities—Direction of travel is from facilities to demand points. This is the default. Fire departments commonly use this setting, since they are concerned with the time it takes to travel from the fire station to the location of the emergency.</para>
		/// <para>Toward facilities—Direction of travel is from demand points to facilities. Retail stores commonly use this setting, since they are concerned with the time it takes the shoppers to reach the store.</para>
		/// <para>Using this option can affect the allocation of the demand points to the facilities on a network with one-way restrictions and different impedances based on direction of travel. For instance, it may take 15 minutes to drive from the demand point to the facility but only 10 minutes when driving from the facility to the demand point.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelDirection { get; set; } = "FROM_FACILITIES";

		/// <summary>
		/// <para>Problem Type</para>
		/// <para>The problem type that will be solved. The choice of the problem type depends on the kind of facility being located. Different kinds of facilities have different priorities and constraints.</para>
		/// <para>Minimize impedance—This option solves the warehouse location problem. It selects a set of facilities such that the total sum of weighted impedances (demand at a location times the impedance to the closest facility) is minimized. This problem type is often known as the P-Median problem. This is the default problem type.</para>
		/// <para>Maximize coverage—This option solves the fire station location problem. It chooses facilities such that all or the greatest amount of demand is within a specified impedance cutoff.</para>
		/// <para>Maximize capacitated coverage—This option solves the location problem where facilities have a finite capacity. It chooses facilities such that all or the greatest amount of demand can be served without exceeding the capacity of any facility. In addition to honoring capacity, it selects facilities such that the total sum of weighted impedance (demand allocated to a facility multiplied by the impedance to or from the facility) is minimized.</para>
		/// <para>Minimize facilities—This option solves the fire station location problem. It chooses the minimum number of facilities needed to cover all or the greatest amount of demand within a specified impedance cutoff.</para>
		/// <para>Maximize attendance—This option solves the neighborhood store location problem where the proportion of demand allocated to the nearest chosen facility falls with increasing distance. The set of facilities that maximize the total allocated demand is chosen. Demand further than the specified impedance cutoff does not affect the chosen set of facilities.</para>
		/// <para>Maximize market share—This option solves the competitive facility location problem. It chooses facilities to maximize market share in the presence of competitive facilities. Gravity model concepts are used to determine the proportion of demand allocated to each facility. The set of facilities that maximizes the total allocated demand is chosen.</para>
		/// <para>Target market share—This option solves the competitive facility location problem. It chooses facilities to reach a specified target market share in the presence of competitive facilities. Gravity model concepts are used to determine the proportion of demand allocated to each facility. The minimum number of facilities needed to reach the specified target market share is chosen.</para>
		/// <para><see cref="ProblemTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Problem Type")]
		public object ProblemType { get; set; } = "MINIMIZE_IMPEDANCE";

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>The maximum impedance at which a demand point can be allocated to a facility in the units of the impedance attribute used by your chosen Travel Mode. The maximum impedance is measured by the least-cost path along the network. If a demand point is outside the cutoff, it is left unallocated. This property might be used to model the maximum distance that people are willing to travel to visit your stores or the maximum time that is permitted for a fire department to reach anyone in the community.</para>
		/// <para>This cutoff can be overridden on a per-demand-point basis by specifying individual cutoff values in the demand points sublayer in the Cutoff_[Impedance] property. For example, you might find that people in rural areas are willing to travel up to 10 miles to reach a facility while urbanites are only willing to travel up to 2 miles. You can model this behavior by setting the Cutoff value of the analysis layer to 10 and setting the Cutoff_Miles value of each demand point in an urban areas to 2.</para>
		/// <para>By default, no cutoff is used for the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object Cutoff { get; set; }

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>Specifies the number of facilities that the solver should locate. By default, this parameter is set to 1.</para>
		/// <para>The facilities with a FacilityType value of Required are always part of the solution when there are more facilities to find than required facilities; any excess facilities to choose are picked from candidate facilities.</para>
		/// <para>Any facilities that have a FacilityType value of Chosen before solving are treated as candidate facilities at solve time.</para>
		/// <para>The parameter value is not considered for the Minimize facilities problem type since the solver determines the minimum number of facilities to locate to maximize coverage.</para>
		/// <para>The parameter value is overridden for the Target market share problem type because the solver searches for the minimum number of facilities required to capture the specified market share.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Problem Type")]
		public object NumberOfFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Decay Function Type</para>
		/// <para>This sets the equation for transforming the network cost between facilities and demand points. This property, coupled with the Decay Function Parameter Value, specifies how severely the network impedance between facilities and demand points influences the solver&apos;s choice of facilities.</para>
		/// <para>Linear—The transformed network impedance between the facility and the demand point is the same as the shortest-path network impedance between them. With this option, the impedance parameter is always set to 1. This is the default.</para>
		/// <para>Power—The transformed network impedance between the facility and the demand point is equal to the shortest-path network impedance raised to the power specified by the impedance parameter. Use this option with a positive impedance parameter to specify higher weight to nearby facilities.</para>
		/// <para>Exponential—The transformed network impedance between the facility and the demand point is equal to the mathematical constant e raised to the power specified by the shortest-path network impedance multiplied with the impedance parameter. Use this option with a positive impedance parameter to specify a very high weight to nearby facilities.Exponential transformations are commonly used in conjunction with an impedance cutoff.</para>
		/// <para>Demand points have an ImpedanceTransformation property, which, if set, overrides the Decay Function Parameter Value property of the analysis layer on a per-demand-point basis. You might determine that the decay function should be different for urban and rural residents. You can model this by setting the impedance transformation for the analysis layer to match that of rural residents and setting the impedance transformation for the individual demand points located in urban areas to match that of urbanites.</para>
		/// <para><see cref="DecayFunctionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Problem Type")]
		public object DecayFunctionType { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Decay Function Parameter Value</para>
		/// <para>Provides a parameter value to the equations specified in the Decay Function Type parameter. The parameter value is ignored when the decay function is of type Linear. For Power and Exponential decay functions, the value should be nonzero.</para>
		/// <para>Demand points have an ImpedanceTransformation property, which, if set, overrides the Decay Function Parameter Value property of the analysis layer on a per-demand-point basis. You might determine that the decay function should be different for urban and rural residents. You can model this by setting the impedance transformation for the analysis layer to match that of rural residents and setting the impedance transformation for the individual demand points located in urban areas to match that of urbanites.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object DecayFunctionParameterValue { get; set; } = "1";

		/// <summary>
		/// <para>Target Market Share</para>
		/// <para>Specifies the target market share in percentage to solve for when the Problem Type parameter is set to Target market share. It is the percentage of the total demand weight that you want your solution facilities to capture. The solver chooses the minimum number of facilities required to capture the target market share specified by this numeric value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object TargetMarketShare { get; set; } = "10";

		/// <summary>
		/// <para>Capacity</para>
		/// <para>Specifies the default capacity of facilities when the Problem Type parameter is set to Maximize capacitated coverage. This parameter is ignored for all other problem types.</para>
		/// <para>Facilities have a Capacity property, which, if set to a nonnull value, overrides the Capacity parameter for that facility.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object Capacity { get; set; } = "1";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>Indicates the time and date of departure. The departure time can be from facilities or demand points, depending on whether Travel Direction is from demand to facility or facility to demand.</para>
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
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone of the Time of Day parameter.</para>
		/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the facilities or demand points are located. If Travel Direction is facilities to demand points, this is the time zone of the facilities. If Travel Direction is demand points to facilities, this is the time zone of the demand points. This is the default.</para>
		/// <para>UTC—The Time of Day parameter refers to Coordinated Universal Time (UTC). Choose this option if you want to choose the best location for a specific time, such as now, but aren&apos;t certain in which time zone the facilities or demand points will be located.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>No lines—No shape will be generated for the output of the analysis. This is useful if you are solving a very large problem and are interested only in solution table and are not interested in visualizing your results in a map.</para>
		/// <para>Straight lines—The output line shapes will be straight lines connecting the solution facilities to their allocated demand points. This is the default.</para>
		/// <para>No matter which output shape type is chosen, the best route is always determined by the network impedance, never Euclidean distance. This means that only the route shapes are different, not the underlying traversal of the network.</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object LineShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>A list of cost attributes to be accumulated during analysis. These accumulated attributes are for reference only; the solver only uses the cost attribute used by your designated travel mode when solving the analysis.</para>
		/// <para>For each cost attribute that is accumulated, a Total_[Impedance] property is populated in the network analysis output features.</para>
		/// <para>This parameter is not available if the network data source is an ArcGIS Online service or the network data source is a service on a version of Portal for ArcGIS that does not support accumulation.</para>
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
		public MakeLocationAllocationAnalysisLayer SetEnviroment(object workspace = null )
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
			/// <para>Toward facilities—Direction of travel is from demand points to facilities. Retail stores commonly use this setting, since they are concerned with the time it takes the shoppers to reach the store.</para>
			/// </summary>
			[GPValue("TO_FACILITIES")]
			[Description("Toward facilities")]
			Toward_facilities,

			/// <summary>
			/// <para>Away from facilities—Direction of travel is from facilities to demand points. This is the default. Fire departments commonly use this setting, since they are concerned with the time it takes to travel from the fire station to the location of the emergency.</para>
			/// </summary>
			[GPValue("FROM_FACILITIES")]
			[Description("Away from facilities")]
			Away_from_facilities,

		}

		/// <summary>
		/// <para>Problem Type</para>
		/// </summary>
		public enum ProblemTypeEnum 
		{
			/// <summary>
			/// <para>Minimize impedance—This option solves the warehouse location problem. It selects a set of facilities such that the total sum of weighted impedances (demand at a location times the impedance to the closest facility) is minimized. This problem type is often known as the P-Median problem. This is the default problem type.</para>
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
		/// <para>Decay Function Type</para>
		/// </summary>
		public enum DecayFunctionTypeEnum 
		{
			/// <summary>
			/// <para>Linear—The transformed network impedance between the facility and the demand point is the same as the shortest-path network impedance between them. With this option, the impedance parameter is always set to 1. This is the default.</para>
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
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—The Time of Day parameter refers to Coordinated Universal Time (UTC). Choose this option if you want to choose the best location for a specific time, such as now, but aren&apos;t certain in which time zone the facilities or demand points will be located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The Time of Day parameter refers to the time zone in which the facilities or demand points are located. If Travel Direction is facilities to demand points, this is the time zone of the facilities. If Travel Direction is demand points to facilities, this is the time zone of the demand points. This is the default.</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Line Shape</para>
		/// </summary>
		public enum LineShapeEnum 
		{
			/// <summary>
			/// <para>No lines—No shape will be generated for the output of the analysis. This is useful if you are solving a very large problem and are interested only in solution table and are not interested in visualizing your results in a map.</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("No lines")]
			No_lines,

			/// <summary>
			/// <para>Straight lines—The output line shapes will be straight lines connecting the solution facilities to their allocated demand points. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("Straight lines")]
			Straight_lines,

		}

#endregion
	}
}
