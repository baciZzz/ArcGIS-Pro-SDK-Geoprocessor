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
	/// <para>Set Subnetwork Definition</para>
	/// <para>Sets the domain network tier's properties for a subnetwork in a utility network.</para>
	/// </summary>
	public class SetSubnetworkDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The input utility network that contains the tier's subnetwork.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the tier.</para>
		/// </param>
		/// <param name="TierName">
		/// <para>Tier Name</para>
		/// <para>The name of the tier that contains the subnetwork.</para>
		/// </param>
		/// <param name="SupportDisjointSubnetwork">
		/// <para>Support Disjoint Subnetwork</para>
		/// <para>Specifies whether the input tier will support disjoint subnetworks. Disjoint subnetworks are two or more subnetworks that belong to the same tier and have the same subnetwork name but are not traversable. This parameter is only available for tiers in domain networks with a partitioned tier definition. This parameter is checked for tiers in a domain network with a hierarchical tier definition to support disjoint subnetworks.</para>
		/// <para>Checked—The input tier will support disjoint subnetworks.</para>
		/// <para>Unchecked—The input tier will not support disjoint subnetworks. This is the default.</para>
		/// <para><see cref="SupportDisjointSubnetworkEnum"/></para>
		/// </param>
		public SetSubnetworkDefinition(object InUtilityNetwork, object DomainNetwork, object TierName, object SupportDisjointSubnetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.TierName = TierName;
			this.SupportDisjointSubnetwork = SupportDisjointSubnetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Subnetwork Definition</para>
		/// </summary>
		public override string DisplayName => "Set Subnetwork Definition";

		/// <summary>
		/// <para>Tool Name : SetSubnetworkDefinition</para>
		/// </summary>
		public override string ToolName => "SetSubnetworkDefinition";

		/// <summary>
		/// <para>Tool Excute Name : un.SetSubnetworkDefinition</para>
		/// </summary>
		public override string ExcuteName => "un.SetSubnetworkDefinition";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, DomainNetwork, TierName, SupportDisjointSubnetwork, ValidDevices!, ValidSubnetworkController!, ValidLines!, AggregatedLine!, DiagramTemplate!, Summaries!, ConditionBarriers!, FunctionBarriers!, IncludeBarriers!, TraversabilityScope!, Propagators!, OutUtilityNetwork!, UpdateStructureFeatures!, UpdateContainerFeatures!, EditModeForDefaultVersion!, EditModeForNamedVersion!, ValidJunctions!, ValidJunctionObjects!, ValidJunctionObjectSubnetworkController!, ValidEdgeObjects!, ManageSubnetworkIsdirty!, IncludeContainers!, IncludeContent!, IncludeStructures!, ValidateLocatability! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The input utility network that contains the tier's subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the tier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier Name</para>
		/// <para>The name of the tier that contains the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TierName { get; set; }

		/// <summary>
		/// <para>Support Disjoint Subnetwork</para>
		/// <para>Specifies whether the input tier will support disjoint subnetworks. Disjoint subnetworks are two or more subnetworks that belong to the same tier and have the same subnetwork name but are not traversable. This parameter is only available for tiers in domain networks with a partitioned tier definition. This parameter is checked for tiers in a domain network with a hierarchical tier definition to support disjoint subnetworks.</para>
		/// <para>Checked—The input tier will support disjoint subnetworks.</para>
		/// <para>Unchecked—The input tier will not support disjoint subnetworks. This is the default.</para>
		/// <para><see cref="SupportDisjointSubnetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SupportDisjointSubnetwork { get; set; } = "false";

		/// <summary>
		/// <para>Valid Devices</para>
		/// <para>The asset group/asset type pairs identified as valid devices for the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidDevices { get; set; }

		/// <summary>
		/// <para>Valid Device Subnetwork Controllers</para>
		/// <para>The asset group/asset type pairs identified as valid device subnetwork controllers in the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidSubnetworkController { get; set; }

		/// <summary>
		/// <para>Valid Lines</para>
		/// <para>The asset group/asset type pairs identified as valid lines for the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidLines { get; set; }

		/// <summary>
		/// <para>Aggregated Lines For SubnetLine Feature Class</para>
		/// <para>The valid lines with geometry that will be aggregated to generate the SubnetLine features. This list is a subset of the values specified in the Valid Lines parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? AggregatedLine { get; set; }

		/// <summary>
		/// <para>Subnetwork Diagram Templates</para>
		/// <para>The templates that will be used to generate subnetwork system diagrams for each subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? DiagramTemplate { get; set; }

		/// <summary>
		/// <para>Summaries</para>
		/// <para>Sets the summary attribute field to store function results when inserting or updating SubnetLine features.</para>
		/// <para>Summaries components are as follows:</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Filter Name—Filter the function results by attribute name.</para>
		/// <para>Filter Operator—Choose from a number of operators.</para>
		/// <para>Filter Type—Choose from a number of filter types.</para>
		/// <para>Filter Value—Provide a specific value for the input filter attribute.</para>
		/// <para>Summary Attribute—The field in the SubnetLine feature class that will persist the function result. Depending on the selected function and network attribute type, only the applicable type of user-added subnetwork attributes will be valid for this parameter. If a field to store the summary result does not exist in the SubnetLine feature class, the Add Field tool can be used to create one. A field can only support the result of one summary; each summary requires its own field in the SubnetLine feature class. See the following matrix of valid field types for the summary attribute field based on the function chosen:Function</para>
		/// <para>Short</para>
		/// <para>Long</para>
		/// <para>Double</para>
		/// <para>Date</para>
		/// <para>AVG</para>
		/// <para>Double</para>
		/// <para>Double</para>
		/// <para>Double</para>
		/// <para>N/A</para>
		/// <para>MIN</para>
		/// <para>Short</para>
		/// <para>Long</para>
		/// <para>Double</para>
		/// <para>Date</para>
		/// <para>MAX</para>
		/// <para>Short</para>
		/// <para>Long</para>
		/// <para>Double</para>
		/// <para>Date</para>
		/// <para>SUBTRACT</para>
		/// <para>Long</para>
		/// <para>Long</para>
		/// <para>Double</para>
		/// <para>N/A</para>
		/// <para>COUNT</para>
		/// <para>Long</para>
		/// <para>Long</para>
		/// <para>Long</para>
		/// <para>N/A</para>
		/// <para>ADD</para>
		/// <para>Long</para>
		/// <para>Long</para>
		/// <para>Double</para>
		/// <para>N/A</para>
		/// <para>The summaries Function value options are as follows:</para>
		/// <para>Minimum—The minimum of the input values.</para>
		/// <para>Maximum—The maximum of the input values.</para>
		/// <para>Add—The sum of the input values.</para>
		/// <para>Average—The average of the input values.</para>
		/// <para>Count—The number of features.</para>
		/// <para>Subtract—The difference between the input values.Subnetwork controllers and loops trace types do not support the subtract function.</para>
		/// <para>For example, the starting point feature has a value of 20. The next feature has a value of 30. If you use the minimum function, the result is 20, maximum is 30, add is 50, average is 25, count is 2, and subtract is -10.</para>
		/// <para>The summaries Filter Operator value options are as follows:</para>
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
		/// <para>The summaries Filter Type value options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? Summaries { get; set; }

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
		/// <para>The condition barriersType value options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Subnetwork Trace Configuration")]
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
		[Category("Subnetwork Trace Configuration")]
		public object? FunctionBarriers { get; set; }

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
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeBarriers { get; set; } = "true";

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
		[Category("Subnetwork Trace Configuration")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>Specifies the network attributes to propagate as well as how that propagation will occur during a trace. Propagated class attributes denote the key values on subnetwork controllers that are disseminated to the rest of the features in the subnetwork. For example, in an electric distribution model, you can propagate the phase value.</para>
		/// <para>Propagators components are as follows:</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Substitution Attribute—Use a substituted value instead of bitset network attribute values. Substitutions are encoded based on the number of bits in the network attribute being propagated. A substitution is a mapping of each bit in a phase to another bit. For example, for Phase AC, one substitution could map bit A to B and bit C to null. In this example the substitution for 1010 (Phase AC) is 0000-0010-0000-0000 (512). The substitution captures the mapping so you know that Phase A was mapped to B and Phase C was mapped to null and not the other way around (that is, Phase A was not mapped to null and Phase C was not mapped to B).</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Propagated Attribute—The name of the field in the network class that is used to store the calculated propagated values. The field type should be the same as the field type of the network attribute chosen for the Attribute value.</para>
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
		[Category("Subnetwork Trace Configuration")]
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Update Structure Network Containers</para>
		/// <para>Specifies whether the update subnetwork process will update the supported subnetwork name attribute for structure network containers.</para>
		/// <para>Checked—The structure network containers will be updated. This is the default.</para>
		/// <para>Unchecked—The structure network containers will not be updated.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// <para><see cref="UpdateStructureFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? UpdateStructureFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Update Domain Network Containers</para>
		/// <para>Specifies whether the update subnetwork process will update the supported subnetwork name for domain network containers.</para>
		/// <para>Checked—The domain network containers will be updated. This is the default.</para>
		/// <para>Unchecked—The domain network containers will not be updated.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// <para><see cref="UpdateContainerFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? UpdateContainerFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Edit Mode For Default Version</para>
		/// <para>Specifies the edit mode that will be used for subnetwork updates on the default version and with file and mobile geodatabases.</para>
		/// <para>Without eventing—Eventing will not be used for subnetwork updates on the default version or in a file or mobile geodatabase. This edit mode updates the subnetwork name and propagated values in place. This is the default.</para>
		/// <para>With eventing—Eventing will be used for subnetwork updates on the default version and in a file or mobile geodatabase. This edit mode executes geodatabase behavior (for example, attribute rules, editor tracking, and so on) when the subnetwork is updated and updates the subnetwork name and propagated values for all applicable features and objects.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// <para><see cref="EditModeForDefaultVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? EditModeForDefaultVersion { get; set; } = "WITHOUT_EVENTING";

		/// <summary>
		/// <para>Edit Mode For Named Version</para>
		/// <para>Specifies the edit mode that will be used for subnetwork updates on a named version.</para>
		/// <para>Without eventing—Eventing will not be used for subnetwork updates on named versions. This edit mode updates the subnetwork name and propagated values in place for features and objects edited in the version. This is the default.</para>
		/// <para>With eventing—Eventing will be used for subnetwork updates on named versions. This edit mode executes geodatabase behavior (for example, attribute rules, editor tracking, and so on) when the subnetwork is updated and updates the subnetwork name and propagated values for all applicable features and objects.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later and is only applicable to enterprise geodatabases.</para>
		/// <para><see cref="EditModeForNamedVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? EditModeForNamedVersion { get; set; } = "WITHOUT_EVENTING";

		/// <summary>
		/// <para>Valid Junctions</para>
		/// <para>The asset group/asset type pairs identified as valid junctions for the subnetwork.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidJunctions { get; set; }

		/// <summary>
		/// <para>Valid Junction Objects</para>
		/// <para>The asset group/asset type pairs identified as valid junction objects for the subnetwork.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidJunctionObjects { get; set; }

		/// <summary>
		/// <para>Valid Junction Object Subnetwork Controllers</para>
		/// <para>The asset group/asset type pairs identified as valid junction object subnetwork controllers for the subnetwork.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidJunctionObjectSubnetworkController { get; set; }

		/// <summary>
		/// <para>Valid Edge Objects</para>
		/// <para>The asset group/asset type pairs identified as valid edge objects for the subnetwork.</para>
		/// <para>This parameter requires a Utility Network Version value of 4 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Valid Features and Objects")]
		public object? ValidEdgeObjects { get; set; }

		/// <summary>
		/// <para>Manage IsDirty</para>
		/// <para>Specifies whether the Is dirty attribute in the subnetworks table will be managed by the update subnetwork operation.</para>
		/// <para>Checked—The Is dirty attribute will be managed by the update subnetwork operation. This is the default.</para>
		/// <para>Unchecked—The Is dirty attribute will not be managed by the update subnetwork operation.</para>
		/// <para>This parameter requires a Utility Network Version value of 5 or later.</para>
		/// <para><see cref="ManageSubnetworkIsdirtyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Subnetwork Policy")]
		public object? ManageSubnetworkIsdirty { get; set; } = "true";

		/// <summary>
		/// <para>Include Containers</para>
		/// <para>Specifies whether the container features and objects will be included in the trace results.</para>
		/// <para>Checked—Container features and objects will be included in the trace results.</para>
		/// <para>Unchecked—Container features and objects will not be included in the trace results. This is the default.</para>
		/// <para>This parameter requires a Utility Network Version value of 5 or later.</para>
		/// <para><see cref="IncludeContainersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeContainers { get; set; } = "true";

		/// <summary>
		/// <para>Include Content</para>
		/// <para>Specifies whether the trace will return content of containers in the results.</para>
		/// <para>Checked—Content of container features and objects will be included in the trace results.</para>
		/// <para>Unchecked—Content of container features and objects will not be included in the trace results. This is the default.</para>
		/// <para>This parameter requires a Utility Network Version value of 5 or later.</para>
		/// <para><see cref="IncludeContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeContent { get; set; } = "true";

		/// <summary>
		/// <para>Include Structures</para>
		/// <para>Specifies whether structure features and objects will be included in the trace results.</para>
		/// <para>Checked—Structure features and objects will be included in the trace results.</para>
		/// <para>Unchecked—Structure features and objects will not be included in the trace results. This is the default.</para>
		/// <para>This parameter requires a Utility Network Version value of 5 or later.</para>
		/// <para><see cref="IncludeStructuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? IncludeStructures { get; set; } = "true";

		/// <summary>
		/// <para>Validate Locatability</para>
		/// <para>Specifies whether an error will be returned during a trace or update subnetwork operation if nonspatial junction or edge objects are encountered without the necessary containment, attachment, or connectivity association in their association hierarchy of the traversed objects. This parameter ensures that nonspatial objects returned by a trace or update subnetwork operation can be located through an association with features or other locatable objects.</para>
		/// <para>Checked—An error will be returned if nonspatial junction or edge objects are encountered without the necessary containment, attachment, or connectivity association in their association hierarchy of the traversed objects.</para>
		/// <para>Unchecked—The trace will not check for unlocatable objects and will return results regardless of whether unlocatable objects are present in the association hierarchy of the traversed objects. This is the default.</para>
		/// <para>This parameter requires a Utility Network Version value of 5 or later.</para>
		/// <para><see cref="ValidateLocatabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Subnetwork Trace Configuration")]
		public object? ValidateLocatability { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Support Disjoint Subnetwork</para>
		/// </summary>
		public enum SupportDisjointSubnetworkEnum 
		{
			/// <summary>
			/// <para>Checked—The input tier will support disjoint subnetworks.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SUPPORT_DISJOINT")]
			SUPPORT_DISJOINT,

			/// <summary>
			/// <para>Unchecked—The input tier will not support disjoint subnetworks. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISJOINT")]
			NO_DISJOINT,

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
		/// <para>Update Structure Network Containers</para>
		/// </summary>
		public enum UpdateStructureFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—The structure network containers will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para>Unchecked—The structure network containers will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_UPDATE")]
			NOT_UPDATE,

		}

		/// <summary>
		/// <para>Update Domain Network Containers</para>
		/// </summary>
		public enum UpdateContainerFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—The domain network containers will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para>Unchecked—The domain network containers will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_UPDATE")]
			NOT_UPDATE,

		}

		/// <summary>
		/// <para>Edit Mode For Default Version</para>
		/// </summary>
		public enum EditModeForDefaultVersionEnum 
		{
			/// <summary>
			/// <para>Without eventing—Eventing will not be used for subnetwork updates on the default version or in a file or mobile geodatabase. This edit mode updates the subnetwork name and propagated values in place. This is the default.</para>
			/// </summary>
			[GPValue("WITHOUT_EVENTING")]
			[Description("Without eventing")]
			Without_eventing,

			/// <summary>
			/// <para>With eventing—Eventing will be used for subnetwork updates on the default version and in a file or mobile geodatabase. This edit mode executes geodatabase behavior (for example, attribute rules, editor tracking, and so on) when the subnetwork is updated and updates the subnetwork name and propagated values for all applicable features and objects.</para>
			/// </summary>
			[GPValue("WITH_EVENTING")]
			[Description("With eventing")]
			With_eventing,

		}

		/// <summary>
		/// <para>Edit Mode For Named Version</para>
		/// </summary>
		public enum EditModeForNamedVersionEnum 
		{
			/// <summary>
			/// <para>Without eventing—Eventing will not be used for subnetwork updates on named versions. This edit mode updates the subnetwork name and propagated values in place for features and objects edited in the version. This is the default.</para>
			/// </summary>
			[GPValue("WITHOUT_EVENTING")]
			[Description("Without eventing")]
			Without_eventing,

			/// <summary>
			/// <para>With eventing—Eventing will be used for subnetwork updates on named versions. This edit mode executes geodatabase behavior (for example, attribute rules, editor tracking, and so on) when the subnetwork is updated and updates the subnetwork name and propagated values for all applicable features and objects.</para>
			/// </summary>
			[GPValue("WITH_EVENTING")]
			[Description("With eventing")]
			With_eventing,

		}

		/// <summary>
		/// <para>Manage IsDirty</para>
		/// </summary>
		public enum ManageSubnetworkIsdirtyEnum 
		{
			/// <summary>
			/// <para>Checked—The Is dirty attribute will be managed by the update subnetwork operation. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MANAGE")]
			MANAGE,

			/// <summary>
			/// <para>Unchecked—The Is dirty attribute will not be managed by the update subnetwork operation.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_MANAGE")]
			NOT_MANAGE,

		}

		/// <summary>
		/// <para>Include Containers</para>
		/// </summary>
		public enum IncludeContainersEnum 
		{
			/// <summary>
			/// <para>Checked—Container features and objects will be included in the trace results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTAINERS")]
			INCLUDE_CONTAINERS,

			/// <summary>
			/// <para>Unchecked—Container features and objects will not be included in the trace results. This is the default.</para>
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
			/// <para>Checked—Content of container features and objects will be included in the trace results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTENT")]
			INCLUDE_CONTENT,

			/// <summary>
			/// <para>Unchecked—Content of container features and objects will not be included in the trace results. This is the default.</para>
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
		/// <para>Validate Locatability</para>
		/// </summary>
		public enum ValidateLocatabilityEnum 
		{
			/// <summary>
			/// <para>Checked—An error will be returned if nonspatial junction or edge objects are encountered without the necessary containment, attachment, or connectivity association in their association hierarchy of the traversed objects.</para>
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

#endregion
	}
}
