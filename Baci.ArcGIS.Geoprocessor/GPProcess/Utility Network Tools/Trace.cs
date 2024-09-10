using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Trace</para>
	/// <para>Returns selected features in a utility network based on connectivity or traversability from the specified starting points.</para>
	/// </summary>
	public class Trace : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network on which the trace will be run. When working with an enterprise geodatabase, an input utility network must be from a feature service; a utility network from a database connection is not supported.</para>
		/// </param>
		public Trace(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Trace</para>
		/// </summary>
		public override string DisplayName() => "Trace";

		/// <summary>
		/// <para>Tool Name : Trace</para>
		/// </summary>
		public override string ToolName() => "Trace";

		/// <summary>
		/// <para>Tool Excute Name : un.Trace</para>
		/// </summary>
		public override string ExcuteName() => "un.Trace";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TraceType, StartingPoints, Barriers, DomainNetwork, Tier, TargetTier, SubnetworkName, ShortestPathNetworkAttributeName, IncludeContainers, IncludeContent, IncludeStructures, IncludeBarriers, ValidateConsistency, ConditionBarriers, FunctionBarriers, TraversabilityScope, FilterBarriers, FilterFunctionBarriers, FilterScope, FilterBitsetNetworkAttributeName, FilterNearest, NearestCount, NearestCostNetworkAttribute, NearestCategories, NearestAssets, Functions, Propagators, OutputAssettypes, OutputConditions, OutUtilityNetwork, IncludeIsolatedFeatures, IgnoreBarriersAtStartingPoints, IncludeUpToFirstSpatialContainer, ResultTypes, SelectionType, ClearAllPreviousTraceResults, TraceName, AggregatedPoints, AggregatedLines, AggregatedPolygons, AllowIndeterminateFlow, ValidateLocatability, UseTraceConfig, TraceConfigName };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network on which the trace will be run. When working with an enterprise geodatabase, an input utility network must be from a feature service; a utility network from a database connection is not supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Trace Type</para>
		/// <para>Specifies the type of trace to execute.</para>
		/// <para>Connected— A connected trace that begins at one or more starting points and spans outward along connected features will be used. This is the default.</para>
		/// <para>Subnetwork— A subnetwork trace that begins at one or more starting points and spans outward to encompass the extent of the subnetwork will be used.</para>
		/// <para>Subnetwork controllers—A subnetwork controllers trace that locates sources and sinks on subnetwork controllers associated with a subnetwork will be used.</para>
		/// <para>Upstream—An upstream trace that discovers features upstream from a location in the network will be used.</para>
		/// <para>Downstream—A downstream trace that discovers features downstream from a location in the network will be used.</para>
		/// <para>Loops— Loops are areas of the network where flow direction is ambiguous. A loops trace that spans outward from the starting point based on connectivity will be used.</para>
		/// <para>Shortest path—A shortest path trace that identifies the shortest path between two starting points will be used.</para>
		/// <para>Isolation—An isolation trace that discovers features that isolate an area of a network will be used.</para>
		/// <para><see cref="TraceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TraceType { get; set; } = "CONNECTED";

		/// <summary>
		/// <para>Starting Points</para>
		/// <para>A feature layer created using the Starting Points tool in the Trace Locations pane, or a table or feature class containing one or more records that represent the starting points of the trace. This feature class or table must include the FEATUREGLOBALID field to store information from the associated network feature. The UN_Temp_Starting_Points feature class in the project's default geodatabase is used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object StartingPoints { get; set; } = "UN_Temp_Starting_Points";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>A feature layer created using the Barriers tool in the Trace Locations pane, or a table or feature class containing one or more records representing barriers that prevent the trace from traversing beyond that point. This feature class or table must include the FEATUREGLOBALID field to store information from the associated network feature. The UN_Temp_Barriers feature class in the project's default geodatabase is used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object Barriers { get; set; } = "UN_Temp_Barriers";

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The name of the domain network where the trace will be run. This parameter is required when running the subnetwork, subnetwork controllers, upstream, and downstream trace types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>The name of the tier to start the trace. This parameter is required when running the subnetwork, subnetwork controllers, upstream, and downstream trace types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tier { get; set; }

		/// <summary>
		/// <para>Target Tier</para>
		/// <para>The name of the target tier to which the input tier flows. If this parameter is missing for upstream and downstream traces, those traces will stop when they reach the boundary of the starting subnetwork. This parameter can be used to allow these traces to continue either farther up or farther down the hierarchy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetTier { get; set; }

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetwork where the trace will be run. This parameter can be used when running a subnetwork trace type. If a subnetwork name is specified, the Starting Points parameter (starting_points in Python) is not required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// <para>The network attribute that will be used to calculate the shortest path. When running a shortest path trace type, the shortest path is calculated using a numeric network attribute such as shape length. Cost and distance based paths can both be achieved. This parameter is required when running a shortest path trace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ShortestPathNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Include Containers</para>
		/// <para>Specifies whether the container features will be included in the trace results.</para>
		/// <para>Checked—Container features will be included in the trace results. This enables the Include up to First Spatial Container option.</para>
		/// <para>Unchecked—Container features will not be included in the trace results. This is the default.</para>
		/// <para><see cref="IncludeContainersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeContainers { get; set; } = "false";

		/// <summary>
		/// <para>Include Content</para>
		/// <para>Specifies whether the trace will return content in containers in the results.</para>
		/// <para>Checked—Content in container features will be included in the trace results.</para>
		/// <para>Unchecked—Content in container features will not be included in the trace results. This is the default.</para>
		/// <para><see cref="IncludeContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeContent { get; set; } = "false";

		/// <summary>
		/// <para>Include Structures</para>
		/// <para>Specifies whether structure features and objects will be included in the trace results.</para>
		/// <para>Checked—Structure features and objects will be included in the trace results.</para>
		/// <para>Unchecked—Structure features and objects will not be included in the trace results. This is the default.</para>
		/// <para><see cref="IncludeStructuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeStructures { get; set; } = "false";

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>Specifies whether the traversability barrier features will be included in the trace results. Traversability barriers are optional even if they have been preset in the subnetwork definition. This parameter does not apply to device features with terminals.</para>
		/// <para>Checked—Traversability barrier features will be included in the trace results. This is the default.</para>
		/// <para>Unchecked—Traversability barrier features will not be included in the trace results.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Validate Consistency</para>
		/// <para>Specifies whether an error will be returned if dirty areas are encountered in any of the traversed features. This is the only way to guarantee a trace is passing through features with consistent status in the network. To remove dirty areas, validate the network topology.</para>
		/// <para>Checked—The trace will return an error if dirty areas are encountered in any of the traversed features. This is the default.</para>
		/// <para>Unchecked—The trace will return results regardless of whether dirty areas are encountered in any of the traversed features.</para>
		/// <para><see cref="ValidateConsistencyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ValidateConsistency { get; set; } = "true";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>Sets a traversability barrier condition on features based on a comparison to a network attribute or check for a category string. A condition barrier uses a network attribute, an operator and a type, and an attribute value. For example, stop a trace when a feature has the Device Status attribute equal to the specific value of Open. When a feature meets this condition, the trace stops. If you&apos;re using more than one attribute, you can use the Combine using parameter to define an And or an Or condition.</para>
		/// <para>Condition barrier components are as follows:</para>
		/// <para>Name—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value that is specified in the Name parameter.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>The condition barriers Operator value options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Includes the values—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>Does not include the values—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>Includes any—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>Does not include any—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>The condition barriers Type value options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>Sets a traversability barrier on features based on a function. Function barriers can be used to do such things as restrict how far the trace travels from the starting point, or set a maximum value to stop a trace. For example, the length of each line traveled is added to the total distance traveled so far. When the total length traveled reaches the value specified, the trace stops.</para>
		/// <para>Function barrier components are as follows:</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that, if discovered, will cause the termination.</para>
		/// <para>Use Local Values—Calculate values in each direction as opposed to an overall global value, for example, a function barrier that is calculating the sum of Shape length in which the trace terminates if the value is greater than or equal to 4. In the global case, after you have traversed two edges with a value of 2, you have already reached a Shape length sum of 4, so the trace stops. If local values are used, the local values along each path change, and the trace continues.</para>
		/// <para>Checked—Local values will be used.</para>
		/// <para>Unchecked—Global values will be used. This is the default.</para>
		/// <para>The function barrier Function value options are as follows:</para>
		/// <para>Minimum—The minimum of the input values.</para>
		/// <para>Maximum—The maximum of the input values.</para>
		/// <para>Add—The sum of the input values.</para>
		/// <para>Average—The average of the input values.</para>
		/// <para>Count—The number of features.</para>
		/// <para>Subtract—The difference between the input values.Subnetwork controllers and loops trace types do not support the subtract function.</para>
		/// <para>For example, the starting point feature has a value of 20. The next feature has a value of 30. If you use the minimum function, the result is 20, maximum is 30, add is 50, average is 25, count is 2, and subtract is -10.</para>
		/// <para>The function barrier Operator value options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Includes the values—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>Does not include the values—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>Includes any—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>Does not include any—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>Specifies the type of traversability that will be applied. Traversability scope determines whether traversability is applied to junctions, edges, or both. For example, if a condition barrier is defined to stop the trace if Device Status is equal to Open and traversability scope is set to edges only, the trace will not stop—even if it encounters an open device—because Device Status is only applicable to junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges. This is the default.</para>
		/// <para>Junctions only—Traversability will be applied to junctions only.</para>
		/// <para>Edges only—Traversability will be applied to edges only.</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter Barriers</para>
		/// <para>Sets when the trace will stop for a specific category or network attribute. For example, stop a trace at features that have a life cycle status attribute that is equal to a certain value. This parameter is used to set a terminator based on a value of a network attribute that is defined in the system. If you&apos;re using more than one attribute, you can use the Combine Using option to define an And or an Or condition.</para>
		/// <para>Filter barrier components are as follows:</para>
		/// <para>Name—Filter by category or any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value that is specified in the Name parameter.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine Using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>The filter barriers Operator value options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Includes the values—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>Does not include the values—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>Includes any—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>Does not include any—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>The filter barriers Type value options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object FilterBarriers { get; set; }

		/// <summary>
		/// <para>Filter Function Barriers</para>
		/// <para>Filters the results of the trace for a specific category.</para>
		/// <para>Filter function barriers components are as follows:</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that, if discovered, will cause the termination.</para>
		/// <para>Use Local Values—Calculate values in each direction as opposed to an overall global value. For example, a function barrier that is calculating the sum of Shape length in which the trace terminates if the value is greater than or equal to 4. In the global case, after you have traversed two edges with a value of 2, you will have already reached a shape length sum of 4, so the trace stops. If local values are used, the local values along each path change, or the trace continues.</para>
		/// <para>Checked—Local values will be used.</para>
		/// <para>Unchecked—Global values will be used. This is the default.</para>
		/// <para>The filter function barriers Function value options are as follows:</para>
		/// <para>Minimum—The minimum of the input values.</para>
		/// <para>Maximum—The maximum of the input values.</para>
		/// <para>Add—The sum of the values.</para>
		/// <para>Average—The average of the input values.</para>
		/// <para>Count—The number of features.</para>
		/// <para>Subtract—The difference between the values. Subnetwork controllers and loops trace types do not support the subtract function.</para>
		/// <para>For example, a starting point feature has a value of 20. The next feature has a value of 30. If you are using the Minimum function, the result is 20. Maximum is 30, Add is 50, Average is 25, Count is 2, and Subtract is -10.</para>
		/// <para>The filter function barriers Operator value options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Includes the values—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>Does not include the values—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>Includes any—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>Does not include any—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object FilterFunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Filter To</para>
		/// <para>Specifies whether the filter for a specific category will be applied to junctions, edges, or both. For example, if a filter barrier is defined to stop the trace if Device Status is equal to Open and traversability scope is set to edges only, the trace will not stop—even if the trace encounters an open device—because Device Status is only applicable to junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>Both junctions and edges—The filter will be applied to both junctions and edges. This is the default.</para>
		/// <para>Junctions only—The filter will be applied to junctions only.</para>
		/// <para>Edges only—The filter will be applied to edges only.</para>
		/// <para><see cref="FilterScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object FilterScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter by bitset network attribute</para>
		/// <para>The name of the network attribute that will be used to filter by bitset. This parameter is only applicable to upstream, downstream, and loops trace types. This parameter can be used to add special logic during a trace so the trace more closely reflects real-world scenarios. For example, for a loops trace, the Phases current network attribute can determine if the loop is a true electrical loop (the same phase is energized all around the loop, that is, A) and return only real electrical loops for the trace results. An example for an upstream trace is when tracing an electric distribution network, specify a Phases current network attribute, and the trace results will only include valid paths that are specified in the network attribute, not all paths.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object FilterBitsetNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Filter by nearest</para>
		/// <para>Specifies whether the k-nearest neighbors algorithm will be used to return a number of features of a certain type within a given distance. When this parameter is used, you can specify a count and a cost as well as a collection of categories, an asset type, or both.</para>
		/// <para>Checked—The k-nearest neighbors algorithm will be used to return a number of features as specified in the Count, Cost Network Attribute, Nearest Categories, or Nearest Asset Groups/Types parameter.</para>
		/// <para>Unchecked—The k-nearest neighbors algorithm will not be used to filter results. This is the default.</para>
		/// <para><see cref="FilterNearestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object FilterNearest { get; set; } = "false";

		/// <summary>
		/// <para>Count</para>
		/// <para>The number of features to be returned when Filter by nearest is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Filters")]
		public object NearestCount { get; set; }

		/// <summary>
		/// <para>Cost Network Attribute</para>
		/// <para>The numeric network attribute that will be used to calculate nearness, cost, or distance when Filter by nearest is checked—for example, shape length.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object NearestCostNetworkAttribute { get; set; }

		/// <summary>
		/// <para>Nearest Categories</para>
		/// <para>The categories that will be returned when Filter by nearest is checked—for example, protective.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object NearestCategories { get; set; }

		/// <summary>
		/// <para>Nearest Asset Groups/Types</para>
		/// <para>The asset groups and asset types that will be returned when Filter by nearest is checked—for example, ElectricDistributionDevice/Transformer/Step Down.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object NearestAssets { get; set; }

		/// <summary>
		/// <para>Functions</para>
		/// <para>The calculation function or functions that will be applied to the trace results.</para>
		/// <para>Functions components are as follows:</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Filter Name—Filter the function results by attribute name.</para>
		/// <para>Filter Operator—Choose from a number of operators.</para>
		/// <para>Filter Type—Choose from a number of filter types.</para>
		/// <para>Filter Value—Provide a specific value for the input filter attribute.</para>
		/// <para>The functions Function value options are as follows:</para>
		/// <para>Average—The average of the input values.</para>
		/// <para>Count—The number of features.</para>
		/// <para>Maximum—The maximum of the input values.</para>
		/// <para>Minimum—The minimum of the input values.</para>
		/// <para>Add—The sum of the input values.</para>
		/// <para>Subtract—The difference between the input values.Subnetwork controllers and loops trace types do not support the subtract function.</para>
		/// <para>For example, a starting point feature has a value of 20. The next feature has a value of 30. If you&apos;re using the Minimum function, the result is 20. Maximum is 30, Add is 50, Average is 25, Count is 2, and Subtract is -10.</para>
		/// <para>The functions Filter Operator value options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Includes the values—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>Does not include the values—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>Includes any—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>Does not include any—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>The functions Filter Type value options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Functions")]
		public object Functions { get; set; }

		/// <summary>
		/// <para>Propagators</para>
		/// <para>Specifies the network attributes to propagate as well as how that propagation will occur during a trace. Propagated class attributes denote the key values on subnetwork controllers that are disseminated to the rest of the features in the subnetwork. For example, in an electric distribution model, you can propagate the phase value.</para>
		/// <para>Propagators components are as follows:</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Substitution Attribute—Use a substituted value instead of bitset network attribute values. Substitutions are encoded based on the number of bits in the network attribute being propagated. A substitution is a mapping of each bit in phase to another bit. For example, for Phase AC, one substitution could map bit A to B, and bit C to null. In this example, the substitution for 1010 (Phase AC) is 0000-0010-0000-0000 (512). The substitution captures the mapping so you know that Phase A was mapped to B and Phase C was mapped to null, and not the other way around (that is, Phase A was not mapped to null and Phase C was not mapped to B).</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>The propagators function value options are as follows:</para>
		/// <para>PROPAGATED_BITWISE_AND—Compare the values from one feature to the next.</para>
		/// <para>PROPAGATED_MIN—Get the minimum value.</para>
		/// <para>PROPAGATED_MAX—Get the maximum value.</para>
		/// <para>The propagators operator value options are as follows:</para>
		/// <para>IS_EQUAL_TO—The attribute is equal to the value.</para>
		/// <para>DOES_NOT_EQUAL—The attribute is not equal to the value.</para>
		/// <para>IS_GREATER_THAN—The attribute is greater than the value.</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—The attribute is greater than or equal to the value.</para>
		/// <para>IS_LESS_THAN—The attribute is less than the value.</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—The attribute is less than or equal to the value.</para>
		/// <para>INCLUDES_THE_VALUES—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>INCLUDES_ANY—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>DOES_NOT_INCLUDE_ANY—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>This parameter is only available via Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Propagators")]
		public object Propagators { get; set; }

		/// <summary>
		/// <para>Output Asset Types</para>
		/// <para>Filters the output asset types to be included in the results—for example, only return overhead transformers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Output")]
		public object OutputAssettypes { get; set; }

		/// <summary>
		/// <para>Output Conditions</para>
		/// <para>The types of features that will be returned based on a network attribute or category. For example, in a trace configured to filter out everything but Tap features, any traced features that do not have the Tap category assigned to them are not included in the results. Any traced features that do are returned in the result selection set.</para>
		/// <para>Output conditions components are as follows:</para>
		/// <para>Name—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value that is specified in the Name parameter.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>The output conditionsOperator value options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Includes the values—A bitwise AND operation in which all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>Does not include the values—A bitwise AND operation in which not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>Includes any—A bitwise AND operation in which at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>Does not include any—A bitwise AND operation in which none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>The output conditions Type value options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Output")]
		public object OutputConditions { get; set; }

		/// <summary>
		/// <para>Output Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Include Isolated Features</para>
		/// <para>Specifies whether the isolated features will be included in the trace results. This parameter is only used when running an isolation trace.</para>
		/// <para>Checked—Isolated features will be included in the trace results.</para>
		/// <para>Unchecked—Isolated features will not be included in the trace results. This is the default.</para>
		/// <para><see cref="IncludeIsolatedFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeIsolatedFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// <para>Specifies whether dynamic barriers in the trace configuration are ignored for starting points. This may be useful when performing an upstream protective device trace and using the discovered protective devices (barriers) as starting points to find subsequent upstream protective devices.</para>
		/// <para>Checked—Barriers at starting points will be ignored in the trace.</para>
		/// <para>Unchecked—Barriers at starting points will not be ignored in the trace. This is the default.</para>
		/// <para><see cref="IgnoreBarriersAtStartingPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreBarriersAtStartingPoints { get; set; } = "false";

		/// <summary>
		/// <para>Include up to First Spatial Container</para>
		/// <para>Specifies whether the containers returned will be limited to only those encountered up to, and including, the first spatial container for each network element in the trace results. If no spatial containers are encountered but nonspatial containers are present for a given network element, all nonspatial containers will be included in the results. This parameter is only available when Include Containers is checked.</para>
		/// <para>Checked—Only containers encountered up to, and including, the first spatial container will be returned in the results when nested containment associations are encountered along the trace path. If no spatial containers exist, all nonspatial containers will be included in the results for a given network element.</para>
		/// <para>Unchecked—All containers will be returned in the results. This is the default.</para>
		/// <para><see cref="IncludeUpToFirstSpatialContainerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeUpToFirstSpatialContainer { get; set; } = "false";

		/// <summary>
		/// <para>Result Types</para>
		/// <para>Specifies the type of results that will be returned by the trace.</para>
		/// <para>Selection— The trace results will be returned as a selection set on the appropriate network features. This is the default.</para>
		/// <para>Aggregated Geometry— The trace results will be aggregated by geometry type and stored in multipart feature classes displayed in the layers in the active map.</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object ResultTypes { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>Specifies how the selection will be applied and what to do if a current selection exists.</para>
		/// <para>New selection—The resulting selection will replace the current selection. This is the default.</para>
		/// <para>Add to the current selection—The resulting selection will be added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
		/// <para>Remove from the current selection—The resulting selection will be removed from the current selection. If no selection exists, this option has no effect.</para>
		/// <para>Select subset from the current selection—The resulting selection will be combined with the current selection. Only records that are common to both remain selected.</para>
		/// <para>Switch the current selection—The resulting selection will be switched. Results that were selected are removed from the current selection, while results that were not selected are added to the current selection. If no selection exists, this is the same as the new selection option.</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Clear All Previous Trace Results</para>
		/// <para>Specifies whether content will be truncated from, or appended to, the feature classes chosen to store aggregated geometry. This parameter is only applicable to the aggregated geometry result type.</para>
		/// <para>Checked—The feature classes storing aggregated trace geometry will be truncated. Only the output geometry from the current trace operation will be written. This is the default.</para>
		/// <para>Unchecked—The output geometry from the current trace operation will be appended to the feature classes storing aggregated geometry.</para>
		/// <para><see cref="ClearAllPreviousTraceResultsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object ClearAllPreviousTraceResults { get; set; } = "true";

		/// <summary>
		/// <para>Trace Name</para>
		/// <para>The name of the trace operation. This value is stored in the TRACENAME field of the output feature class to assist with identification of the trace results. This parameter is only applicable to the aggregated geometry result type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output")]
		public object TraceName { get; set; }

		/// <summary>
		/// <para>Aggregated Points</para>
		/// <para>An output multipoint feature class containing the aggregated result geometry. By default, the parameter is populated with a system-generated feature class named Trace_Results_Aggregated_Points that will be stored in the project&apos;s default geodatabase.</para>
		/// <para>This feature class will be created automatically if it does not exist. An existing feature class can also be used to store aggregated geometry. If a feature class other than the default is used, it must be a multipoint feature class and contain a string field named TRACENAME. This parameter is only applicable for the aggregated geometry result type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint")]
		[Category("Output")]
		public object AggregatedPoints { get; set; } = "Trace_Results_Aggregated_Points";

		/// <summary>
		/// <para>Aggregated Lines</para>
		/// <para>An output polyline feature class containing the aggregated result geometry. By default, the parameter is populated with a system-generated feature class named Trace_Results_Aggregated_Lines that will be stored in the project&apos;s default geodatabase.</para>
		/// <para>This feature class will be created automatically if it does not exist. An existing feature class can also be used to store aggregated geometry. If a feature class other than the default is used, it must be a polyline feature class and contain a string field named TRACENAME. This parameter is only applicable for the aggregated geometry result type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Output")]
		public object AggregatedLines { get; set; } = "Trace_Results_Aggregated_Lines";

		/// <summary>
		/// <para>Aggregated Polygons</para>
		/// <para>An output polygon feature class containing the aggregated result geometry. By default, the parameter is populated with a system-generated feature class named Trace_Results_Aggregated_Polygons that will be stored in the project&apos;s default geodatabase.</para>
		/// <para>This feature class will be created automatically if it does not exist. An existing feature class can also be used to store aggregated geometry. If a feature class other than the default is used, it must be a polygon feature class and contain a string field named TRACENAME. This parameter is only applicable for the aggregated geometry result type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Output")]
		public object AggregatedPolygons { get; set; } = "Trace_Results_Aggregated_Polygons";

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para>Specifies whether features with indeterminate flow will be traced. This parameter is only honored when running an upstream or downstream trace.</para>
		/// <para>Checked—Features with indeterminate flow will be traced. This is the default.</para>
		/// <para>Unchecked—Features with indeterminate flow will stop traversability and will not be traced.</para>
		/// <para>This parameter requires Utility Network Version 5 or later.</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllowIndeterminateFlow { get; set; } = "true";

		/// <summary>
		/// <para>Validate Locatability</para>
		/// <para>Specifies whether an error will be returned during a trace if nonspatial junction or edge objects are encountered without the necessary containment, attachment, or connectivity association in their association hierarchy of the traversed objects. This parameter ensures that nonspatial objects returned by a trace or update subnetwork operation can be located through an association with features or other locatable objects.</para>
		/// <para>Checked—The trace will return an error if nonspatial junction or edge objects are encountered without the necessary containment, attachment, or connectivity association in their association hierarchy of the traversed objects.</para>
		/// <para>Unchecked—The trace will not check for unlocatable objects and will return results regardless of whether unlocatable objects are present in the association hierarchy of the traversed objects. This is the default.</para>
		/// <para>This parameter requires Utility Network Version 4 or later.</para>
		/// <para><see cref="ValidateLocatabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ValidateLocatability { get; set; } = "false";

		/// <summary>
		/// <para>Use Trace Configuration</para>
		/// <para>Specifies whether an existing named trace configuration will be used to populate the parameters of the Trace tool.</para>
		/// <para>Checked—An existing named trace configuration will be used to define the properties of the trace. All parameters except Trace Configuration Name, Starting Points, and Barriers will be ignored.</para>
		/// <para>Unchecked—An existing named trace configuration will not be used to define the properties of the trace. This is the default.</para>
		/// <para>This parameter requires Utility Network Version 5 or later.</para>
		/// <para><see cref="UseTraceConfigEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseTraceConfig { get; set; } = "false";

		/// <summary>
		/// <para>Trace Configuration Name</para>
		/// <para>The name of the trace configuration that will be used to define the properties of the trace. This parameter is only active when the Use Trace Configuration parameter is checked.</para>
		/// <para>This parameter requires Utility Network Version 5 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TraceConfigName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Trace Type</para>
		/// </summary>
		public enum TraceTypeEnum 
		{
			/// <summary>
			/// <para>Connected— A connected trace that begins at one or more starting points and spans outward along connected features will be used. This is the default.</para>
			/// </summary>
			[GPValue("CONNECTED")]
			[Description("Connected")]
			Connected,

			/// <summary>
			/// <para>Subnetwork— A subnetwork trace that begins at one or more starting points and spans outward to encompass the extent of the subnetwork will be used.</para>
			/// </summary>
			[GPValue("SUBNETWORK")]
			[Description("Subnetwork")]
			Subnetwork,

			/// <summary>
			/// <para>Subnetwork controllers—A subnetwork controllers trace that locates sources and sinks on subnetwork controllers associated with a subnetwork will be used.</para>
			/// </summary>
			[GPValue("SUBNETWORK_CONTROLLERS")]
			[Description("Subnetwork controllers")]
			Subnetwork_controllers,

			/// <summary>
			/// <para>Upstream—An upstream trace that discovers features upstream from a location in the network will be used.</para>
			/// </summary>
			[GPValue("UPSTREAM")]
			[Description("Upstream")]
			Upstream,

			/// <summary>
			/// <para>Downstream—A downstream trace that discovers features downstream from a location in the network will be used.</para>
			/// </summary>
			[GPValue("DOWNSTREAM")]
			[Description("Downstream")]
			Downstream,

			/// <summary>
			/// <para>Loops— Loops are areas of the network where flow direction is ambiguous. A loops trace that spans outward from the starting point based on connectivity will be used.</para>
			/// </summary>
			[GPValue("LOOPS")]
			[Description("Loops")]
			Loops,

			/// <summary>
			/// <para>Shortest path—A shortest path trace that identifies the shortest path between two starting points will be used.</para>
			/// </summary>
			[GPValue("SHORTEST_PATH")]
			[Description("Shortest path")]
			Shortest_path,

			/// <summary>
			/// <para>Isolation—An isolation trace that discovers features that isolate an area of a network will be used.</para>
			/// </summary>
			[GPValue("ISOLATION")]
			[Description("Isolation")]
			Isolation,

		}

		/// <summary>
		/// <para>Include Containers</para>
		/// </summary>
		public enum IncludeContainersEnum 
		{
			/// <summary>
			/// <para>Checked—Container features will be included in the trace results. This enables the Include up to First Spatial Container option.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTAINERS")]
			INCLUDE_CONTAINERS,

			/// <summary>
			/// <para>Unchecked—Container features will not be included in the trace results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_CONTAINERS")]
			EXCLUDE_CONTAINERS,

		}

		/// <summary>
		/// <para>Include Content</para>
		/// </summary>
		public enum IncludeContentEnum 
		{
			/// <summary>
			/// <para>Checked—Content in container features will be included in the trace results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTENT")]
			INCLUDE_CONTENT,

			/// <summary>
			/// <para>Unchecked—Content in container features will not be included in the trace results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_CONTENT")]
			EXCLUDE_CONTENT,

		}

		/// <summary>
		/// <para>Include Structures</para>
		/// </summary>
		public enum IncludeStructuresEnum 
		{
			/// <summary>
			/// <para>Checked—Structure features and objects will be included in the trace results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_STRUCTURES")]
			INCLUDE_STRUCTURES,

			/// <summary>
			/// <para>Unchecked—Structure features and objects will not be included in the trace results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_STRUCTURES")]
			EXCLUDE_STRUCTURES,

		}

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// </summary>
		public enum IncludeBarriersEnum 
		{
			/// <summary>
			/// <para>Checked—Traversability barrier features will be included in the trace results. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para>Unchecked—Traversability barrier features will not be included in the trace results.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_BARRIERS")]
			EXCLUDE_BARRIERS,

		}

		/// <summary>
		/// <para>Validate Consistency</para>
		/// </summary>
		public enum ValidateConsistencyEnum 
		{
			/// <summary>
			/// <para>Checked—The trace will return an error if dirty areas are encountered in any of the traversed features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE_CONSISTENCY")]
			VALIDATE_CONSISTENCY,

			/// <summary>
			/// <para>Unchecked—The trace will return results regardless of whether dirty areas are encountered in any of the traversed features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_VALIDATE_CONSISTENCY")]
			DO_NOT_VALIDATE_CONSISTENCY,

		}

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// </summary>
		public enum TraversabilityScopeEnum 
		{
			/// <summary>
			/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges. This is the default.</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("Both junctions and edges")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>Junctions only—Traversability will be applied to junctions only.</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—Traversability will be applied to edges only.</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("Edges only")]
			Edges_only,

		}

		/// <summary>
		/// <para>Apply Filter To</para>
		/// </summary>
		public enum FilterScopeEnum 
		{
			/// <summary>
			/// <para>Both junctions and edges—The filter will be applied to both junctions and edges. This is the default.</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("Both junctions and edges")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>Junctions only—The filter will be applied to junctions only.</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—The filter will be applied to edges only.</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("Edges only")]
			Edges_only,

		}

		/// <summary>
		/// <para>Filter by nearest</para>
		/// </summary>
		public enum FilterNearestEnum 
		{
			/// <summary>
			/// <para>Checked—The k-nearest neighbors algorithm will be used to return a number of features as specified in the Count, Cost Network Attribute, Nearest Categories, or Nearest Asset Groups/Types parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_NEAREST")]
			FILTER_BY_NEAREST,

			/// <summary>
			/// <para>Unchecked—The k-nearest neighbors algorithm will not be used to filter results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_FILTER")]
			DO_NOT_FILTER,

		}

		/// <summary>
		/// <para>Include Isolated Features</para>
		/// </summary>
		public enum IncludeIsolatedFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—Isolated features will be included in the trace results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_ISOLATED_FEATURES")]
			INCLUDE_ISOLATED_FEATURES,

			/// <summary>
			/// <para>Unchecked—Isolated features will not be included in the trace results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_ISOLATED_FEATURES")]
			EXCLUDE_ISOLATED_FEATURES,

		}

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// </summary>
		public enum IgnoreBarriersAtStartingPointsEnum 
		{
			/// <summary>
			/// <para>Checked—Barriers at starting points will be ignored in the trace.</para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_BARRIERS_AT_STARTING_POINTS")]
			IGNORE_BARRIERS_AT_STARTING_POINTS,

			/// <summary>
			/// <para>Unchecked—Barriers at starting points will not be ignored in the trace. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_IGNORE_BARRIERS_AT_STARTING_POINTS")]
			DO_NOT_IGNORE_BARRIERS_AT_STARTING_POINTS,

		}

		/// <summary>
		/// <para>Include up to First Spatial Container</para>
		/// </summary>
		public enum IncludeUpToFirstSpatialContainerEnum 
		{
			/// <summary>
			/// <para>Checked—Only containers encountered up to, and including, the first spatial container will be returned in the results when nested containment associations are encountered along the trace path. If no spatial containers exist, all nonspatial containers will be included in the results for a given network element.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER")]
			INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER,

			/// <summary>
			/// <para>Unchecked—All containers will be returned in the results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER")]
			DO_NOT_INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER,

		}

		/// <summary>
		/// <para>Result Types</para>
		/// </summary>
		public enum ResultTypesEnum 
		{
			/// <summary>
			/// <para>Selection— The trace results will be returned as a selection set on the appropriate network features. This is the default.</para>
			/// </summary>
			[GPValue("SELECTION")]
			[Description("Selection")]
			Selection,

			/// <summary>
			/// <para>Aggregated Geometry— The trace results will be aggregated by geometry type and stored in multipart feature classes displayed in the layers in the active map.</para>
			/// </summary>
			[GPValue("AGGREGATED_GEOMETRY")]
			[Description("Aggregated Geometry")]
			Aggregated_Geometry,

		}

		/// <summary>
		/// <para>Selection Type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>New selection—The resulting selection will replace the current selection. This is the default.</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("New selection")]
			New_selection,

			/// <summary>
			/// <para>Add to the current selection—The resulting selection will be added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("Add to the current selection")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>Remove from the current selection—The resulting selection will be removed from the current selection. If no selection exists, this option has no effect.</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("Remove from the current selection")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>Select subset from the current selection—The resulting selection will be combined with the current selection. Only records that are common to both remain selected.</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("Select subset from the current selection")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>Switch the current selection—The resulting selection will be switched. Results that were selected are removed from the current selection, while results that were not selected are added to the current selection. If no selection exists, this is the same as the new selection option.</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("Switch the current selection")]
			Switch_the_current_selection,

		}

		/// <summary>
		/// <para>Clear All Previous Trace Results</para>
		/// </summary>
		public enum ClearAllPreviousTraceResultsEnum 
		{
			/// <summary>
			/// <para>Checked—The feature classes storing aggregated trace geometry will be truncated. Only the output geometry from the current trace operation will be written. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_ALL_PREVIOUS_TRACE_RESULTS")]
			CLEAR_ALL_PREVIOUS_TRACE_RESULTS,

			/// <summary>
			/// <para>Unchecked—The output geometry from the current trace operation will be appended to the feature classes storing aggregated geometry.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR_ALL_PREVIOUS_TRACE_RESULTS")]
			DO_NOT_CLEAR_ALL_PREVIOUS_TRACE_RESULTS,

		}

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// </summary>
		public enum AllowIndeterminateFlowEnum 
		{
			/// <summary>
			/// <para>Checked—Features with indeterminate flow will be traced. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACE_INDETERMINATE_FLOW")]
			TRACE_INDETERMINATE_FLOW,

			/// <summary>
			/// <para>Unchecked—Features with indeterminate flow will stop traversability and will not be traced.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_INDETERMINATE_FLOW")]
			IGNORE_INDETERMINATE_FLOW,

		}

		/// <summary>
		/// <para>Validate Locatability</para>
		/// </summary>
		public enum ValidateLocatabilityEnum 
		{
			/// <summary>
			/// <para>Checked—The trace will return an error if nonspatial junction or edge objects are encountered without the necessary containment, attachment, or connectivity association in their association hierarchy of the traversed objects.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE_LOCATABILITY")]
			VALIDATE_LOCATABILITY,

			/// <summary>
			/// <para>Unchecked—The trace will not check for unlocatable objects and will return results regardless of whether unlocatable objects are present in the association hierarchy of the traversed objects. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_VALIDATE_LOCATABILITY")]
			DO_NOT_VALIDATE_LOCATABILITY,

		}

		/// <summary>
		/// <para>Use Trace Configuration</para>
		/// </summary>
		public enum UseTraceConfigEnum 
		{
			/// <summary>
			/// <para>Checked—An existing named trace configuration will be used to define the properties of the trace. All parameters except Trace Configuration Name, Starting Points, and Barriers will be ignored.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_TRACE_CONFIGURATION")]
			USE_TRACE_CONFIGURATION,

			/// <summary>
			/// <para>Unchecked—An existing named trace configuration will not be used to define the properties of the trace. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_TRACE_CONFIGURATION")]
			DO_NOT_USE_TRACE_CONFIGURATION,

		}

#endregion
	}
}
