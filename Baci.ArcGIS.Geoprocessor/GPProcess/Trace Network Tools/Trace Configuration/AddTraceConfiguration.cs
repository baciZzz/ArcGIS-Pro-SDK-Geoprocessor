using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Add Trace Configuration</para>
	/// <para>Add Trace Configuration</para>
	/// <para>Creates a named trace configuration in the trace network.</para>
	/// </summary>
	public class AddTraceConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network that will contain the new named trace configuration.</para>
		/// </param>
		/// <param name="TraceConfigName">
		/// <para>Trace Configuration Name</para>
		/// <para>The name for the named trace configuration.</para>
		/// </param>
		/// <param name="TraceType">
		/// <para>Trace Type</para>
		/// <para>Specifies the type of trace that will be configured.</para>
		/// <para>CONNECTED—A connected trace that begins at one or more starting points and spans outward along connected features will be used. This is the default.</para>
		/// <para>UPSTREAM—An upstream trace that discovers features upstream from a location in the network will be used. This type of trace uses flow direction.</para>
		/// <para>DOWNSTREAM—A downstream trace that discovers features downstream from a location in the network will be used. This type of trace uses flow direction.</para>
		/// <para>SHORTEST_PATH—A shortest path trace that finds the shortest path between two starting points in the network regardless of flow direction will be used. The cost of traversing the path is determined based on the network attribute set for the Shortest Path Network Attribute Name parameter.</para>
		/// <para><see cref="TraceTypeEnum"/></para>
		/// </param>
		public AddTraceConfiguration(object InTraceNetwork, object TraceConfigName, object TraceType)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.TraceConfigName = TraceConfigName;
			this.TraceType = TraceType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Trace Configuration</para>
		/// </summary>
		public override string DisplayName() => "Add Trace Configuration";

		/// <summary>
		/// <para>Tool Name : AddTraceConfiguration</para>
		/// </summary>
		public override string ToolName() => "AddTraceConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : tn.AddTraceConfiguration</para>
		/// </summary>
		public override string ExcuteName() => "tn.AddTraceConfiguration";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, TraceConfigName, TraceType, Description!, Tags!, PathDirection!, ShortestPathNetworkAttributeName!, IncludeBarriers!, ValidateConsistency!, IgnoreBarriersAtStartingPoints!, AllowIndeterminateFlow!, ConditionBarriers!, FunctionBarriers!, TraversabilityScope!, Functions!, OutputConditions!, ResultTypes!, UpdatedTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network that will contain the new named trace configuration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Trace Configuration Name</para>
		/// <para>The name for the named trace configuration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TraceConfigName { get; set; }

		/// <summary>
		/// <para>Trace Type</para>
		/// <para>Specifies the type of trace that will be configured.</para>
		/// <para>CONNECTED—A connected trace that begins at one or more starting points and spans outward along connected features will be used. This is the default.</para>
		/// <para>UPSTREAM—An upstream trace that discovers features upstream from a location in the network will be used. This type of trace uses flow direction.</para>
		/// <para>DOWNSTREAM—A downstream trace that discovers features downstream from a location in the network will be used. This type of trace uses flow direction.</para>
		/// <para>SHORTEST_PATH—A shortest path trace that finds the shortest path between two starting points in the network regardless of flow direction will be used. The cost of traversing the path is determined based on the network attribute set for the Shortest Path Network Attribute Name parameter.</para>
		/// <para><see cref="TraceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TraceType { get; set; } = "CONNECTED";

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the named trace configuration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>A set of tags used to identify the named trace configuration. The tags can be used in searches and indexing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Path Direction</para>
		/// <para>Specifies the direction of the trace path. The cost of traversing the path is determined by the Shortest Path Network Attribute Name parameter value. This parameter is only honored when running a Shortest path trace type.</para>
		/// <para>NO_DIRECTION—The path between the two starting points, regardless of the direction of flow, will be used. This is the default.</para>
		/// <para>PATH_UPSTREAM—The upstream path between the two starting points will be used.</para>
		/// <para>PATH_DOWNSTREAM—The downstream path between the two starting points will be used.</para>
		/// <para><see cref="PathDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PathDirection { get; set; } = "NO_DIRECTION";

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// <para>The name of the network attribute used to calculate the path. When running a shortest path trace type, the shortest path is calculated using a numeric network attribute such as shape length. Cost and distance based paths can both be achieved. This parameter is required when running a shortest path trace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ShortestPathNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>Specifies whether the traversability barrier features will be included in the trace results.</para>
		/// <para>Checked—Traversability barrier features will be included in the trace results. This is the default.</para>
		/// <para>Unchecked—Traversability barrier features will not be included in the trace results.</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeBarriers { get; set; } = "true";

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
		public object? ValidateConsistency { get; set; } = "true";

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// <para>Specifies whether barriers in the trace configuration will be ignored for starting points.</para>
		/// <para>Checked—Barriers at starting points will be ignored in the trace.</para>
		/// <para>Unchecked—Barriers at starting points will not be ignored in the trace. This is the default.</para>
		/// <para><see cref="IgnoreBarriersAtStartingPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreBarriersAtStartingPoints { get; set; } = "false";

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para>Specifies whether features that have indeterminate or uninitialized flow will be traced. This parameter is only honored when running an upstream or downstream trace.</para>
		/// <para>Checked—Features that have indeterminate or uninitialized flow direction will be traced.</para>
		/// <para>Unchecked—Features that have indeterminate or uninitialized flow direction will not be traced. This is the default.</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowIndeterminateFlow { get; set; } = "false";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>Sets a traversability barrier condition on features based on a comparison to a network attribute. A condition barrier uses a network attribute, an operator and a type, and an attribute value. For example, stop a trace when a feature has the Code attribute equal to the specific value of ArtificialPath. When a feature meets this condition, the trace stops. If you&apos;re using more than one attribute, you can use the Combine Using component to define an And or an Or condition.</para>
		/// <para>Condition barrier components are as follows:</para>
		/// <para>Name—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value specified in the Name component.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>Operator components are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Type components are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// <para>Combine using components are as follows:</para>
		/// <para>And—Combine the condition barriers.</para>
		/// <para>Or—Use if either condition barrier is met.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>Sets a traversability barrier on features based on a function. Function barriers can be used, for example, to restrict how far the trace travels from the starting point or to set a maximum value to stop a trace. For example, the length of each line traveled is added to the total distance traveled so far. When the total length traveled reaches the value specified, the trace stops.</para>
		/// <para>Function barrier components are as follows:</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Value—Provide a specific value for the input attribute type that, if discovered, will cause the termination.</para>
		/// <para>Use Local Values—Calculate values in each direction as opposed to an overall global value. For example, a function barrier calculates the sum of shape length in which the trace terminates if the value is greater than or equal to 4. In the global case, after you have traversed two edges with a value of 2, you have already reached a shape length sum of 4, so the trace stops. If local values are used, the local values along each path change, and the trace continues.</para>
		/// <para>Function components are as follows:</para>
		/// <para>Minimum—The minimum of the input values.</para>
		/// <para>Maximum—The maximum of the input values.</para>
		/// <para>Add—The sum of the input values.</para>
		/// <para>Average—The average of the input values.</para>
		/// <para>Count—The number of features.</para>
		/// <para>Subtract—The difference between the input values.</para>
		/// <para>For example, you have a starting point feature with a value of 20. The next feature has a value of 30. If you use the minimum function, the result is 20, maximum is 30, add is 50, average is 25, count is 2, and subtract is -10.</para>
		/// <para>Operator components are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Use Local Values components are as follows:</para>
		/// <para>Checked—Local values will be used.</para>
		/// <para>Unchecked—Global values will be used. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>Specifies whether traversability will be applied to junctions, edges, or both. For example, in a network of recreational trails, if a condition barrier is defined to stop a trace if a surfacetype attribute contains a value of gravel and the traversability scope is set to junctions only, the trace will not stop even if it encounters an edge feature with this value in the surfacetype field, because the surfacetype attribute is only applicable to edges. In other words, this parameter indicates to the trace whether to ignore junctions, ignore edges, or include both junctions and edges in the trace.</para>
		/// <para>Both junctions and edges—Traversability will be applied to both junctions and edges. This is the default.</para>
		/// <para>Junctions only—Traversability will be applied to junctions only.</para>
		/// <para>Edges only—Traversability will be applied to edges only.</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Functions</para>
		/// <para>The calculation function that will be applied to the trace results.</para>
		/// <para>Functions components are as follows:</para>
		/// <para>Function—Choose from a number of calculation functions.</para>
		/// <para>Attribute—Filter by any network attribute defined in the system.</para>
		/// <para>Filter Name—Filter the function results by attribute name.</para>
		/// <para>Filter Operator—Choose from a number of operators.</para>
		/// <para>Filter Type—Choose from a number of filter types.</para>
		/// <para>Filter Value—Provide a specific value for the input filter attribute.</para>
		/// <para>Function component options are as follows:</para>
		/// <para>Min—The minimum of the input values.</para>
		/// <para>Max—The maximum of the input values.</para>
		/// <para>Add—The sum of the input values.</para>
		/// <para>Average—The average of the input values.</para>
		/// <para>Count—The number of features.</para>
		/// <para>Subtract—The difference between the input values.</para>
		/// <para>For example, a starting point feature has a value of 20. The next feature has a value of 30. If you&apos;re using the Min function, the result is 20. Max is 30, Add is 50, Average is 25, Count is 2, and Subtract is -10.</para>
		/// <para>Filter Operator component options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Filter Type component options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? Functions { get; set; }

		/// <summary>
		/// <para>Output Conditions</para>
		/// <para>The types of features that will be returned based on a network attribute. For example, in a trace configured to filter out everything but Tap features, any traced features that do not have the Tap attribute assigned to them will not ve included in the results. Any traced features that do will be returned in the result selection set.</para>
		/// <para>Output conditions components are as follows:</para>
		/// <para>Name—Filter by any network attribute defined in the system.</para>
		/// <para>Operator—Choose from a number of operators.</para>
		/// <para>Type—Choose a specific value or network attribute from the value specified in the Name component.</para>
		/// <para>Value—Provide a specific value for the input attribute type that would cause termination based on the operator value.</para>
		/// <para>Combine using—Set this value if you have multiple attributes to add. You can combine them using an And or an Or condition.</para>
		/// <para>Operator component options are as follows:</para>
		/// <para>Is equal to—The attribute is equal to the value.</para>
		/// <para>Does not equal—The attribute is not equal to the value.</para>
		/// <para>Is greater than—The attribute is greater than the value.</para>
		/// <para>Is greater than or equal to—The attribute is greater than or equal to the value.</para>
		/// <para>Is less than—The attribute is less than the value.</para>
		/// <para>Is less than or equal to—The attribute is less than or equal to the value.</para>
		/// <para>Type component options are as follows:</para>
		/// <para>Specific Value—Filter by a specific value.</para>
		/// <para>Network Attribute—Filter by a network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? OutputConditions { get; set; }

		/// <summary>
		/// <para>Result Types</para>
		/// <para>Specifies the type of results that will be returned by the trace.</para>
		/// <para>Selection— The trace results will be returned as a selection set on the appropriate network features. This is the default.</para>
		/// <para>Aggregated Geometry— The trace results will be aggregated by geometry type and stored in feature classes displayed in layers in the active map.</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? ResultTypes { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? UpdatedTraceNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Trace Type</para>
		/// </summary>
		public enum TraceTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CONNECTED")]
			[Description("Connected")]
			Connected,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("UPSTREAM")]
			[Description("Upstream")]
			Upstream,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DOWNSTREAM")]
			[Description("Downstream")]
			Downstream,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SHORTEST_PATH")]
			[Description("Shortest path")]
			Shortest_path,

		}

		/// <summary>
		/// <para>Path Direction</para>
		/// </summary>
		public enum PathDirectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_DIRECTION")]
			[Description("No direction")]
			No_direction,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PATH_UPSTREAM")]
			[Description("Upstream path")]
			Upstream_path,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PATH_DOWNSTREAM")]
			[Description("Downstream path")]
			Downstream_path,

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
		/// <para>Allow Indeterminate Flow</para>
		/// </summary>
		public enum AllowIndeterminateFlowEnum 
		{
			/// <summary>
			/// <para>Checked—Features that have indeterminate or uninitialized flow direction will be traced.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACE_INDETERMINATE_FLOW")]
			TRACE_INDETERMINATE_FLOW,

			/// <summary>
			/// <para>Unchecked—Features that have indeterminate or uninitialized flow direction will not be traced. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_INDETERMINATE_FLOW")]
			IGNORE_INDETERMINATE_FLOW,

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
			/// <para>Aggregated Geometry— The trace results will be aggregated by geometry type and stored in feature classes displayed in layers in the active map.</para>
			/// </summary>
			[GPValue("AGGREGATED_GEOMETRY")]
			[Description("Aggregated Geometry")]
			Aggregated_Geometry,

		}

#endregion
	}
}
