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
	/// <para>Export Subnetwork</para>
	/// <para>Exports subnetworks from a utility network into a JSON file. This tool also allows you to delete a row in the Subnetworks table as long as the Is deleted attribute is set to true. This indicates that the subnetwork controller has been removed from the subnetwork.</para>
	/// </summary>
	public class ExportSubnetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork to export.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the subnetwork.</para>
		/// </param>
		/// <param name="Tier">
		/// <para>Tier</para>
		/// <para>The tier that contains the subnetwork.</para>
		/// </param>
		/// <param name="SubnetworkName">
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetwork to export. Select a specific source to export the corresponding subnetwork information.</para>
		/// </param>
		/// <param name="ExportAcknowledged">
		/// <para>Set export acknowledged</para>
		/// <para>Specifies whether the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table and feature in the SubnetLine feature class is updated.</para>
		/// <para>Checked—Updates the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table. If the controller has been marked for deletion (Is deleted = True), it will be deleted from the Subnetworks table. This option requires the input utility network to reference the default version.</para>
		/// <para>Unchecked—Does not update the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table. This is the default.</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output JSON</para>
		/// <para>The name and location of the JSON file to be generated.</para>
		/// </param>
		public ExportSubnetwork(object InUtilityNetwork, object DomainNetwork, object Tier, object SubnetworkName, object ExportAcknowledged, object OutJsonFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Tier = Tier;
			this.SubnetworkName = SubnetworkName;
			this.ExportAcknowledged = ExportAcknowledged;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Subnetwork</para>
		/// </summary>
		public override string DisplayName() => "Export Subnetwork";

		/// <summary>
		/// <para>Tool Name : ExportSubnetwork</para>
		/// </summary>
		public override string ToolName() => "ExportSubnetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportSubnetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportSubnetwork";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Tier, SubnetworkName, ExportAcknowledged, OutJsonFile, ConditionBarriers, FunctionBarriers, IncludeBarriers, TraversabilityScope, Propagators, OutUtilityNetwork, IncludeGeometry, ResultTypes, ResultNetworkAttributes, ResultFields };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the subnetwork to export.</para>
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
		/// <para>Subnetwork Name</para>
		/// <para>The name of the subnetwork to export. Select a specific source to export the corresponding subnetwork information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SubnetworkName { get; set; }

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// <para>Specifies whether the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table and feature in the SubnetLine feature class is updated.</para>
		/// <para>Checked—Updates the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table. If the controller has been marked for deletion (Is deleted = True), it will be deleted from the Subnetworks table. This option requires the input utility network to reference the default version.</para>
		/// <para>Unchecked—Does not update the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table. This is the default.</para>
		/// <para><see cref="ExportAcknowledgedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExportAcknowledged { get; set; } = "false";

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>The name and location of the JSON file to be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object OutJsonFile { get; set; }

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>Sets a traversability barrier condition on features based on a comparison to a network attribute or check for a category string. A condition barrier uses a network attribute, an operator and a type, and an attribute value. For example, stop a trace when a feature has the Device Status attribute equal to the specific value of Open. When a feature meets this condition, the trace stops. If you&apos;re using more than one attribute, you can use the Combine using parameter to define an And or an Or condition.</para>
		/// <para>Condition barrier components are as follows:</para>
		/// <para>Name—Choose to filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of different operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value that is specified in the name parameter.</para>
		/// <para>Value—Set a specific value of the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine Using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>The condition barrier operator values are as follows:</para>
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
		/// <para>Use Local Values—Calculate values in each direction as opposed to an overall global value. For example, use for a function barrier that is calculating the sum of Shape length where the trace terminates if the value is greater than or equal to 4. In the global case, after you have traversed two edges with a value of 2, you have already reached a shape length sum of 4, so the trace stops. If local values are used, the local values along each path change, so the trace goes farther.</para>
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
		/// <para>This parameter is only available via Python.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Trace Parameters")]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>Specifies the type of traversability to enforce. Traversability scope dictates whether traversability is enforced at junctions, edges, or both. For example, if a condition barrier is defined to stop the trace if DEVICESTATUS is set to Open and the traversability scope is set to edges only, the trace would not stop even if the trace encounters an open device, because DEVICESTATUS is only applicable for junctions. In other words, this parameter indicates to the trace whether to ignore junctions, edges, or both.</para>
		/// <para>BOTH_JUNCTIONS_AND_EDGES—Apply traversability to both junctions and edges.</para>
		/// <para>JUNCTIONS_ONLY—Apply traversability to only junctions.</para>
		/// <para>EDGES_ONLY—Apply traversability to only edges.</para>
		/// <para>This parameter is only available via Python.</para>
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
		/// <para>DOES NOT INCLUDE_THE_VALUES—A bitwise AND operation where not all of the bits in the value are present in the attribute (bitwise AND != value).</para>
		/// <para>INCLUDES_ANY—A bitwise AND operation where at least one bit in the value is present in the attribute (bitwise AND == True).</para>
		/// <para>DOES_NOT_INLCUDE_ANY—A bitwise AND operation where none of the bits in the value are present in the attribute (bitwise AND == False).</para>
		/// <para>This parameter is only available via Python.</para>
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
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Include Geometry</para>
		/// <para>Specifies whether to include the geometry in the results.</para>
		/// <para>Checked—Include the geometry in the results.</para>
		/// <para>Unchecked—Do not include the geometry in the results. This is the default.</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Result Types</para>
		/// <para>Specifies the type of results to export.</para>
		/// <para>Connectivity—Return features that are connected via geometric coincidence or connectivity associations. This is the default.</para>
		/// <para>Features—Return feature-level information in the response.</para>
		/// <para>Containment and attachment associations—Return features that are associated via containment and structural attachment associations.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// <para>The containment and attachment associations option requires ArcGIS Enterprise 10.8.1 or later.</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ResultTypes { get; set; }

		/// <summary>
		/// <para>Result Network Attributes</para>
		/// <para>The network attributes that will be included in the results.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object ResultNetworkAttributes { get; set; }

		/// <summary>
		/// <para>Result Fields</para>
		/// <para>Fields from a feature class that will be returned as results. The values of the field will be returned in the results for the features in the subnetwork.</para>
		/// <para>For enterprise geodatabases, this parameter requires ArcGIS Enterprise 10.7 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ResultFields { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Set export acknowledged</para>
		/// </summary>
		public enum ExportAcknowledgedEnum 
		{
			/// <summary>
			/// <para>Checked—Updates the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table. If the controller has been marked for deletion (Is deleted = True), it will be deleted from the Subnetworks table. This option requires the input utility network to reference the default version.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ACKNOWLEDGE")]
			ACKNOWLEDGE,

			/// <summary>
			/// <para>Unchecked—Does not update the LASTACKEXPORTSUBNETWORK attribute for the corresponding controller in the Subnetworks table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ACKNOWLEDGE")]
			NO_ACKNOWLEDGE,

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

		/// <summary>
		/// <para>Include Geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—Include the geometry in the results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para>Unchecked—Do not include the geometry in the results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

		/// <summary>
		/// <para>Result Types</para>
		/// </summary>
		public enum ResultTypesEnum 
		{
			/// <summary>
			/// <para>Features—Return feature-level information in the response.</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("Features")]
			Features,

			/// <summary>
			/// <para>Connectivity—Return features that are connected via geometric coincidence or connectivity associations. This is the default.</para>
			/// </summary>
			[GPValue("CONNECTIVITY")]
			[Description("Connectivity")]
			Connectivity,

			/// <summary>
			/// <para>Containment and attachment associations—Return features that are associated via containment and structural attachment associations.</para>
			/// </summary>
			[GPValue("CONTAINMENT_AND_ATTACHMENT_ASSOCIATIONS")]
			[Description("Containment and attachment associations")]
			Containment_and_attachment_associations,

		}

#endregion
	}
}
