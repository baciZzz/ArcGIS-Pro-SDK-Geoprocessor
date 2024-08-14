using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Add Trace Rule</para>
	/// <para>Adds a diagram rule to automatically execute a trace on a utility network or trace network during the building of diagrams based on an existing template. The resulting traced network features and network objects are used to build the diagram content.</para>
	/// </summary>
	public class AddTraceRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template that will be modified.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template that will be modified.</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>Specifies whether the rule will be active when generating and updating diagrams based on the specified template.</para>
		/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
		/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="TraceType">
		/// <para>Trace Type</para>
		/// <para>Specifies the type of trace the rule will perform to build the diagram content.</para>
		/// <para>Connected— A connected trace will be executed from the utility network or trace network elements currently represented in the diagram when the rule starts and spans outward along connected elements. This is the default.</para>
		/// <para>Subnetwork— A subnetwork trace will be executed from the utility network elements currently represented in the diagram when the rule starts and spans outward along connected elements to find sources or sinks from which it spans outward along the related subnetwork.</para>
		/// <para>Upstream—An upstream trace will be executed from the utility network or trace network elements currently represented in the diagram when the rule starts to discover elements upstream.</para>
		/// <para>Downstream—A downstream trace will be executed from the utility network or trace network elements currently represented in the diagram when the rule starts to discover elements downstream.</para>
		/// <para>Shortest path— A shortest path trace will be executed from the utility network or trace network features currently specified as starting points in the diagram when the rule starts to discover features along the shortest path between those starting points. The cost of traversing the path is determined based on the network attribute set for the Shortest Path Network Attribute Name parameter value regardless of flow direction.</para>
		/// </param>
		public AddTraceRule(object InUtilityNetwork, object TemplateName, object IsActive, object TraceType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.TraceType = TraceType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Trace Rule</para>
		/// </summary>
		public override string DisplayName => "Add Trace Rule";

		/// <summary>
		/// <para>Tool Name : AddTraceRule</para>
		/// </summary>
		public override string ToolName => "AddTraceRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddTraceRule</para>
		/// </summary>
		public override string ExcuteName => "nd.AddTraceRule";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, TraceType, DomainNetwork!, Tier!, TargetTier!, IncludeStructures!, IncludeBarriers!, ConditionBarriers!, FunctionBarriers!, TraversabilityScope!, FilterBarriers!, FilterFunctionBarriers!, FilterScope!, FilterBitsetNetworkAttributeName!, FilterNearest!, NearestCount!, NearestCostNetworkAttribute!, NearestCategories!, NearestAssets!, Propagators!, Description!, OutUtilityNetwork!, OutTemplateName!, AllowIndeterminateFlow!, PathDirection!, PathNetworkWeightName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template that will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template that will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>Specifies whether the rule will be active when generating and updating diagrams based on the specified template.</para>
		/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
		/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Trace Type</para>
		/// <para>Specifies the type of trace the rule will perform to build the diagram content.</para>
		/// <para>Connected— A connected trace will be executed from the utility network or trace network elements currently represented in the diagram when the rule starts and spans outward along connected elements. This is the default.</para>
		/// <para>Subnetwork— A subnetwork trace will be executed from the utility network elements currently represented in the diagram when the rule starts and spans outward along connected elements to find sources or sinks from which it spans outward along the related subnetwork.</para>
		/// <para>Upstream—An upstream trace will be executed from the utility network or trace network elements currently represented in the diagram when the rule starts to discover elements upstream.</para>
		/// <para>Downstream—A downstream trace will be executed from the utility network or trace network elements currently represented in the diagram when the rule starts to discover elements downstream.</para>
		/// <para>Shortest path— A shortest path trace will be executed from the utility network or trace network features currently specified as starting points in the diagram when the rule starts to discover features along the shortest path between those starting points. The cost of traversing the path is determined based on the network attribute set for the Shortest Path Network Attribute Name parameter value regardless of flow direction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TraceType { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The name of the domain network where the trace will be run for a utility network. This parameter is required when running the subnetwork, upstream, and downstream trace types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>The name of the tier where the trace will start for a utility network. This parameter is optional when running the connected trace type; it is required when running the subnetwork, upstream, and downstream trace types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tier { get; set; }

		/// <summary>
		/// <para>Target Tier</para>
		/// <para>The name of the target tier to which the input tier will flow for a utility network. If this parameter is missing for upstream and downstream traces, those traces will stop when they reach the boundary of the starting subnetwork. This parameter can be used to allow these traces to continue either farther up or farther down the hierarchy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetTier { get; set; }

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
		public object? IncludeStructures { get; set; } = "false";

		/// <summary>
		/// <para>Include Barriers Features</para>
		/// <para>Specifies whether the traversability barrier features will be included in the trace results. Traversability barriers are optional even if they have been preset in the subnetwork definition. This parameter does not apply to device features with terminals.</para>
		/// <para>Checked—Traversability barrier features will be included in the trace results. This is the default.</para>
		/// <para>Unchecked—Traversability barrier features will not be included in the trace results.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object? IncludeBarriers { get; set; } = "true";

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
		public object? ConditionBarriers { get; set; }

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
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>The type of traversability to enforce. Traversability scope dictates whether traversability is enforced at junctions, edges, or both. For example, if a condition barrier is defined to stop the trace if Device Status is equal to Open and traversability scope is set to edges only, the trace will not stop—even if it encounters an open device—because Device Status is only applicable to junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges.</para>
		/// <para>Junctions only—Traversability will be applied to junctions only.</para>
		/// <para>Edges only—Traversability will be applied to edges only.</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter Barriers</para>
		/// <para>Specifies when the trace will stop for a specific category or network attribute. For example, stop a trace at features that have a life cycle status attribute that is equal to a certain value. This parameter is used to set a terminator based on a value of a network attribute that is defined in the system. If using more than one attribute, you can use the Combine Using option to define an And or an Or condition.</para>
		/// <para>Filter barrier components are as follows:</para>
		/// <para>Name—Filter by category or any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of different operators.</para>
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
		public object? FilterBarriers { get; set; }

		/// <summary>
		/// <para>Filter Function Barriers</para>
		/// <para>Filters the results of the trace for a specific category.</para>
		/// <para>Filter function barriers components are as follows:</para>
		/// <para>Function—Choose from a number of different calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of different operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that, if discovered, will cause the termination.</para>
		/// <para>Use Local Values—Calculate values in each direction as opposed to an overall global value. For example, a function barrier is calculating the sum of Shape length in which the trace terminates if the value is greater than or equal to 4. In the global case, after you traverse two edges with a value of 2, you will have reached a shape length sum of 4, so the trace stops. If local values are used, the local values along each path change, or the trace continues.</para>
		/// <para>Checked—Local values will be used.</para>
		/// <para>Unchecked—Global values will be used. This is the default.</para>
		/// <para>The filter function barriers Function value options are as follows:</para>
		/// <para>Minimum—The minimum of the input values will be used.</para>
		/// <para>Maximum—The maximum of the input values will be used.</para>
		/// <para>Add—The sum of the values will be used.</para>
		/// <para>Average—The average of the input values will be used.</para>
		/// <para>Count—The number of features will be used.</para>
		/// <para>Subtract—The difference between the values will be used. Subnetwork controllers and loops trace types do not support the subtract function.</para>
		/// <para>For example, there is a starting point feature with a value of 20. The next feature has a value of 30. If you are using the Minimum function, the result is 20. Maximum is 30, Add is 50, Average is 25, Count is 2, and Subtract is -10.</para>
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
		public object? FilterFunctionBarriers { get; set; }

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
		public object? FilterScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter by bitset network attribute</para>
		/// <para>The name of the network attribute that will be used to filter by bitset. This parameter is only applicable to upstream, downstream, and loops trace types. This parameter can be used to add special logic during a trace so the trace more closely reflects real-world scenarios. For example, for a loops trace, the Phases current network attribute can determine if the loop is a true electrical loop (the same phase is energized all around the loop, that is, A) and return only real electrical loops for the trace results. An example for an upstream trace is when tracing an electric distribution network, specify a Phases current network attribute, and the trace results will only include valid paths that are specified in the network attribute, not all paths.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object? FilterBitsetNetworkAttributeName { get; set; }

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
		public object? FilterNearest { get; set; } = "false";

		/// <summary>
		/// <para>Count</para>
		/// <para>The number of features to be returned when Filter by nearest is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Filters")]
		public object? NearestCount { get; set; }

		/// <summary>
		/// <para>Cost Network Attribute</para>
		/// <para>The numeric network attribute that will be used to calculate nearness, cost, or distance when Filter by nearest is checked—for example, shape length.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object? NearestCostNetworkAttribute { get; set; }

		/// <summary>
		/// <para>Nearest Categories</para>
		/// <para>The categories that will be returned when Filter by nearest is checked—for example, protective.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object? NearestCategories { get; set; }

		/// <summary>
		/// <para>Nearest Asset Groups/Types</para>
		/// <para>The asset groups and asset types that will be returned when Filter by nearest is checked—for example, ElectricDistributionDevice/Transformer/Step Down.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object? NearestAssets { get; set; }

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
		/// <para>PROPAGATED_BITWISE_AND—Values will be compared from one feature to the next.</para>
		/// <para>PROPAGATED_MIN—The minimum value will be propagated.</para>
		/// <para>PROPAGATED_MAX—The maximum value will be propagated.</para>
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
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the rule.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para>Specifies whether trace network features that have indeterminate or uninitialized flow will be traced. This parameter is only honored when running an upstream or downstream trace on a trace network.</para>
		/// <para>Checked—Trace network features that have indeterminate or uninitialized flow direction in the trace will be included.</para>
		/// <para>Unchecked—Trace network features that have indeterminate or uninitialized flow direction will not be included. This is the default.</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowIndeterminateFlow { get; set; } = "false";

		/// <summary>
		/// <para>Path Direction</para>
		/// <para>Specifies the direction of the path for a trace network. The cost of traversing the path is determined by the Shortest Path Network Attribute Name parameter value. This parameter is only honored when running a Shortest path trace type.</para>
		/// <para>NO_DIRECTION—The path will be between the two starting points regardless of the direction of flow. This is the default.</para>
		/// <para>PATH_UPSTREAM—The direction of the path will be downstream between the two starting points.</para>
		/// <para>PATH_DOWNSTREAM—The direction of the path will be upstream between the two starting points.</para>
		/// <para><see cref="PathDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? PathDirection { get; set; } = "NO_DIRECTION";

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// <para>The network attribute that will be used to calculate the path for a utility network or trace network. When running a shortest path trace type, the shortest path is calculated using a numeric network attribute such as shape length. Cost-and distance-based paths can both be achieved. This parameter is required when running a shortest path trace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? PathNetworkWeightName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INACTIVE")]
			INACTIVE,

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
		/// <para>Include Barriers Features</para>
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
		/// <para>Apply Traversability To</para>
		/// </summary>
		public enum TraversabilityScopeEnum 
		{
			/// <summary>
			/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges.</para>
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
		/// <para>Allow Indeterminate Flow</para>
		/// </summary>
		public enum AllowIndeterminateFlowEnum 
		{
			/// <summary>
			/// <para>Checked—Trace network features that have indeterminate or uninitialized flow direction in the trace will be included.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACE_INDETERMINATE_FLOW")]
			TRACE_INDETERMINATE_FLOW,

			/// <summary>
			/// <para>Unchecked—Trace network features that have indeterminate or uninitialized flow direction will not be included. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_INDETERMINATE_FLOW")]
			IGNORE_INDETERMINATE_FLOW,

		}

		/// <summary>
		/// <para>Path Direction</para>
		/// </summary>
		public enum PathDirectionEnum 
		{
			/// <summary>
			/// <para>NO_DIRECTION—The path will be between the two starting points regardless of the direction of flow. This is the default.</para>
			/// </summary>
			[GPValue("NO_DIRECTION")]
			[Description("NO_DIRECTION")]
			NO_DIRECTION,

			/// <summary>
			/// <para>PATH_UPSTREAM—The direction of the path will be downstream between the two starting points.</para>
			/// </summary>
			[GPValue("PATH_UPSTREAM")]
			[Description("PATH_UPSTREAM")]
			PATH_UPSTREAM,

			/// <summary>
			/// <para>PATH_DOWNSTREAM—The direction of the path will be upstream between the two starting points.</para>
			/// </summary>
			[GPValue("PATH_DOWNSTREAM")]
			[Description("PATH_DOWNSTREAM")]
			PATH_DOWNSTREAM,

		}

#endregion
	}
}
