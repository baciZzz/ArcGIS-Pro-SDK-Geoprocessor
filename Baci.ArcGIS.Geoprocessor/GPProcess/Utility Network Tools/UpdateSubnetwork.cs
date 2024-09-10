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
	/// <para>Update Subnetwork</para>
	/// <para>Updates subnetwork information in the Subnetworks table, the SubnetLine feature class, and subnetwork system diagrams for the specified subnetworks. Also certain attributes are created or updated for subnetwork features. A record for any new subnetworks will be generated, the records for any deleted subnetworks will be removed, and the shape and information for any modified subnetworks will be updated.</para>
	/// </summary>
	public class UpdateSubnetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the subnetwork.</para>
		/// </param>
		/// <param name="Tier">
		/// <para>Tier</para>
		/// <para>The tier that contains the subnetwork.</para>
		/// </param>
		/// <param name="AllSubnetworksInTier">
		/// <para>All subnetworks in tier</para>
		/// <para>Specifies whether all subnetworks in the tier are updated. To update a subset of subnetworks in the tier, use the Subnetwork Name(s) parameter.</para>
		/// <para>Checked—Updates all subnetworks in the tier. This option uses asynchronous processing to update the subnetworks using the system UtilityNetworkTools geoprocessing service. The service is reserved for utility network geoprocessing tasks and has a longer default timeout setting. This is the default.</para>
		/// <para>Unchecked—Updates only the subnetworks that are specified in the Subnetwork Name(s) parameter.</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </param>
		public UpdateSubnetwork(object InUtilityNetwork, object DomainNetwork, object Tier, object AllSubnetworksInTier)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Tier = Tier;
			this.AllSubnetworksInTier = AllSubnetworksInTier;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Subnetwork</para>
		/// </summary>
		public override string DisplayName() => "Update Subnetwork";

		/// <summary>
		/// <para>Tool Name : UpdateSubnetwork</para>
		/// </summary>
		public override string ToolName() => "UpdateSubnetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateSubnetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.UpdateSubnetwork";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, AllSubnetworksInTier, SubnetworkName, ContinueOnFailure, ConditionBarriers, FunctionBarriers, IncludeBarriers, TraversabilityScope, Propagators, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>The tier that contains the subnetwork.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Tier { get; set; }

		/// <summary>
		/// <para>All subnetworks in tier</para>
		/// <para>Specifies whether all subnetworks in the tier are updated. To update a subset of subnetworks in the tier, use the Subnetwork Name(s) parameter.</para>
		/// <para>Checked—Updates all subnetworks in the tier. This option uses asynchronous processing to update the subnetworks using the system UtilityNetworkTools geoprocessing service. The service is reserved for utility network geoprocessing tasks and has a longer default timeout setting. This is the default.</para>
		/// <para>Unchecked—Updates only the subnetworks that are specified in the Subnetwork Name(s) parameter.</para>
		/// <para><see cref="AllSubnetworksInTierEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllSubnetworksInTier { get; set; } = "true";

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetworks to update. If all subnetworks will be updated using the All subnetworks in tier parameter, this parameter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Continue on failure</para>
		/// <para>Specifies whether to stop the update process if a subnetwork fails to update when updating multiple subnetworks.</para>
		/// <para>Checked—Continues to update subnetworks upon failure.</para>
		/// <para>Unchecked—Stops updating subnetworks if a failure occurs. This is the default.</para>
		/// <para><see cref="ContinueOnFailureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueOnFailure { get; set; } = "false";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>Sets a traversability barrier condition on features based on a comparison to a network attribute or check for a category string. A condition barrier uses a network attribute, an operator and a type, and an attribute value. For example, stop a trace when a feature has the Device Status attribute equal to the specific value of Open. When a feature meets this condition, the trace stops. If you&apos;re using more than one attribute, you can use the Combine using parameter to define an And or an Or condition.</para>
		/// <para>Condition barrier components are as follows:</para>
		/// <para>Name—Choose to filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of different operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value that is specified in the name parameter.</para>
		/// <para>Value—Set a specific value of the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine Using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>The condition barrier Operator values are as follows:</para>
		/// <para>IS_EQUAL_TO—The attribute is equal to the value.</para>
		/// <para>DOES_NOT_EQUAL—The attribute is not equal to the value.</para>
		/// <para>IS_GREATER_THAN—The attribute is greater than the value.</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—The attribute is greater than or equal to the value.</para>
		/// <para>IS_LESS_THAN—The attribute is less than the value.</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—The attribute is less than or equal to the value.</para>
		/// <para>INCLUDES_THE_VALUES—A bitwise AND operation where all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—A bitwise AND operation where not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>INCLUDES_ANY—A bitwise AND operation where at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>DOES_NOT_INCLUDE_ANY—A bitwise AND operation where none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>The condition barrier type options are as follows:</para>
		/// <para>SPECIFIC_VALUE—Filter by a specific value.</para>
		/// <para>NETWORK_ATTRIBUTE—Filter by a network attribute.</para>
		/// <para>The Combine Using values are as follows:</para>
		/// <para>AND—Combine the condition barriers.</para>
		/// <para>OR—Use if either condition barrier is met.</para>
		/// <para>This parameter is only available via Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>Sets a traversability barrier on features based on a function. Function barriers can be used to do such things as restrict how far the trace travels from the starting point, or set a maximum value to stop a trace. For example, the length of each line traveled is added to the total distance traveled so far. When the total length traveled reaches the value specified, the trace stops.</para>
		/// <para>Function barrier components are as follows:</para>
		/// <para>Function—Choose from a number of different calculation functions.</para>
		/// <para>Attribute—Choose to filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of different operators.</para>
		/// <para>Value—Set a specific value of the input attribute type that, if discovered, will cause the termination.</para>
		/// <para>Use Local Values—Calculate values in each direction as opposed to an overall global value, for example, for a function barrier that is calculating the sum of Shape length where the trace terminates if the value is greater than or equal to 4. In the global case, after you have traversed two edges with a value of 2, you have already reached a shape length sum of 4, so the trace stops. If local values are used, the local values along each path change, so the trace goes farther.</para>
		/// <para>TRUE—Use local values.</para>
		/// <para>FALSE—Use global values. This is the default.</para>
		/// <para>Possible values for the function barrier function options are as follows:</para>
		/// <para>AVERAGE—The average of the input values.</para>
		/// <para>COUNT—The number of features.</para>
		/// <para>MAX—The maximum of the input values.</para>
		/// <para>MIN—The minimum of the input values.</para>
		/// <para>ADD—Add the values.</para>
		/// <para>SUBTRACT—Subtract the values. Subnetwork controllers and loops trace types do not support the subtract function.</para>
		/// <para>For example, the starting point feature has a value of 20. The next feature has a value of 30. If you use the minimum function, the result is 20, maximum is 30, add is 50, average is 25, count is 2, and subtract is -10.</para>
		/// <para>The function barrier operator value options are as follows:</para>
		/// <para>IS_EQUAL_TO—The attribute is equal to the value.</para>
		/// <para>DOES_NOT_EQUAL—The attribute is not equal to the value.</para>
		/// <para>IS_GREATER_THAN—The attribute is greater than the value.</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—The attribute is greater than or equal to the value.</para>
		/// <para>IS_LESS_THAN—The attribute is less than the value.</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—The attribute is less than or equal to the value.</para>
		/// <para>INCLUDES_THE_VALUES—A bitwise AND operation where all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—A bitwise AND operation where not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>INCLUDES_ANY—A bitwise AND operation where at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>DOES_NOT_INCLUDE_ANY—A bitwise AND operation where none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>This parameter is only available via Python.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>Specifies whether the traversability barrier features are included in the trace results. Traversability barriers are optional even if they have been preset in the subnetwork definition.</para>
		/// <para>INCLUDE_BARRIERS—Traversability barriers are included in the trace results. This is the default.</para>
		/// <para>EXCLUDE_BARRIERS—Traversability barriers are not included in the trace results.</para>
		/// <para>This parameter is only available via Python and ModelBuilder.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>Specifies the type of traversability to enforce. Traversability scope dictates whether traversability is enforced at junctions, edges, or both. For example, if a condition barrier is defined to stop the trace if DEVICESTATUS is equal to Open and traversability scope is set to edges only, the trace would not stop even if the trace encounters an open device, because the DEVICESTATUS is only applicable for junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>BOTH_JUNCTIONS_AND_EDGES—Apply traversability to both junctions and edges. This is the default.</para>
		/// <para>JUNCTIONS_ONLY—Apply traversability to only junctions.</para>
		/// <para>EDGES_ONLY—Apply traversability to only edges.</para>
		/// <para>This parameter is only available via Python and ModelBuilder.</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Propagators</para>
		/// <para>Specifies the network attributes to propagate as well as how that propagation will occur during a trace. Propagated class attributes denote the key values on subnetwork controllers that are disseminated to the rest of the features in the subnetwork. For example, in an electric distribution model, you can propagate the phase value.</para>
		/// <para>Propagators components are as follows:</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Substitution Attribute—Use a substituted value instead of bitset network attribute values. Substitutions are encoded based on the number of bits in the network attribute being propagated. A substitution is a mapping of each bit in phase to another bit. For example, for Phase AC, one substitution could map bit A to B, and bit C to null. In this example, the substitution for 1010 (Phase AC) is 0000-0010-0000-0000 (512). The substitution captures the mapping so you know that Phase A was mapped to B and Phase C was mapped to null, and not the other way around (that is, Phase A was not mapped to null and Phase C was not mapped to B).</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Possible values for the propagators function are as follows:</para>
		/// <para>PROPAGATED_BITWISE_AND—Compare the values from one feature to the next.</para>
		/// <para>PROPAGATED_MIN—Get the minimum value.</para>
		/// <para>PROPAGATED_MAX—Get the maximum value.</para>
		/// <para>The propagator operator values are as follows:</para>
		/// <para>IS_EQUAL_TO—The attribute is equal to the value.</para>
		/// <para>DOES_NOT_EQUAL—The attribute is not equal to the value.</para>
		/// <para>IS_GREATER_THAN—The attribute is greater than the value.</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—The attribute is greater than or equal to the value.</para>
		/// <para>IS_LESS_THAN—The attribute is less than the value.</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—The attribute is less than or equal to the value.</para>
		/// <para>INCLUDES_THE_VALUES—A bitwise AND operation where all bits in the value are present in the attribute (bitwise AND == value).</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—A bitwise AND operation where not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>INCLUDES_ANY—A bitwise AND operation where at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>DOES_NOT_INCLUDE_ANY—A bitwise AND operation where none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>This parameter is only available via Python and ModelBuilder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Trace Parameters")]
		public object Propagators { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPUtilityNetworkLayer()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>All subnetworks in tier</para>
		/// </summary>
		public enum AllSubnetworksInTierEnum 
		{
			/// <summary>
			/// <para>Checked—Updates all subnetworks in the tier. This option uses asynchronous processing to update the subnetworks using the system UtilityNetworkTools geoprocessing service. The service is reserved for utility network geoprocessing tasks and has a longer default timeout setting. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SUBNETWORKS_IN_TIER")]
			ALL_SUBNETWORKS_IN_TIER,

			/// <summary>
			/// <para>Unchecked—Updates only the subnetworks that are specified in the Subnetwork Name(s) parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SPECIFIC_SUBNETWORK")]
			SPECIFIC_SUBNETWORK,

		}

		/// <summary>
		/// <para>Continue on failure</para>
		/// </summary>
		public enum ContinueOnFailureEnum 
		{
			/// <summary>
			/// <para>Checked—Continues to update subnetworks upon failure.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_ON_FAILURE")]
			CONTINUE_ON_FAILURE,

			/// <summary>
			/// <para>Unchecked—Stops updating subnetworks if a failure occurs. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STOP_ON_FAILURE")]
			STOP_ON_FAILURE,

		}

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// </summary>
		public enum IncludeBarriersEnum 
		{
			/// <summary>
			/// <para>INCLUDE_BARRIERS—Traversability barriers are included in the trace results. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para>EXCLUDE_BARRIERS—Traversability barriers are not included in the trace results.</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("Both junctions and edges")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("Edges only")]
			Edges_only,

		}

#endregion
	}
}
