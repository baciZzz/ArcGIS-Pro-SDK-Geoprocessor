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
	/// <para>Add Trace Rule</para>
	/// <para>Add Trace Rule</para>
	/// <para>Add a trace rule to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddTraceRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="TraceType">
		/// <para>Trace Type</para>
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
		public override string DisplayName() => "Add Trace Rule";

		/// <summary>
		/// <para>Tool Name : AddTraceRule</para>
		/// </summary>
		public override string ToolName() => "AddTraceRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTraceRule</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTraceRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, TraceType, DomainNetwork, Tier, TargetTier, IncludeStructures, IncludeBarriers, ConditionBarriers, FunctionBarriers, TraversabilityScope, FilterBarriers, FilterFunctionBarriers, FilterScope, FilterBitsetNetworkAttributeName, FilterNearest, NearestCount, NearestCostNetworkAttribute, NearestCategories, NearestAssets, Propagators, Description, OutUtilityNetwork, OutTemplateName, AllowIndeterminateFlow, PathDirection, PathNetworkWeightName };

		/// <summary>
		/// <para>Input Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Trace Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TraceType { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tier { get; set; }

		/// <summary>
		/// <para>Target Tier</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetTier { get; set; }

		/// <summary>
		/// <para>Include Structures</para>
		/// <para><see cref="IncludeStructuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeStructures { get; set; } = "false";

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object FilterBarriers { get; set; }

		/// <summary>
		/// <para>Filter Function Barriers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object FilterFunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Filter To</para>
		/// <para><see cref="FilterScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object FilterScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter by bitset network attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object FilterBitsetNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Filter by nearest</para>
		/// <para><see cref="FilterNearestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object FilterNearest { get; set; } = "false";

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Filters")]
		public object NearestCount { get; set; }

		/// <summary>
		/// <para>Cost Network Attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object NearestCostNetworkAttribute { get; set; }

		/// <summary>
		/// <para>Nearest Categories</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object NearestCategories { get; set; }

		/// <summary>
		/// <para>Nearest Asset Groups/Types</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object NearestAssets { get; set; }

		/// <summary>
		/// <para>Propagators</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Propagators")]
		public object Propagators { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutTemplateName { get; set; }

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllowIndeterminateFlow { get; set; } = "false";

		/// <summary>
		/// <para>Path Direction</para>
		/// <para><see cref="PathDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object PathDirection { get; set; } = "NO_DIRECTION";

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object PathNetworkWeightName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_STRUCTURES")]
			INCLUDE_STRUCTURES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para></para>
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
			[Description("BOTH_JUNCTIONS_AND_EDGES")]
			BOTH_JUNCTIONS_AND_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("JUNCTIONS_ONLY")]
			JUNCTIONS_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("EDGES_ONLY")]
			EDGES_ONLY,

		}

		/// <summary>
		/// <para>Apply Filter To</para>
		/// </summary>
		public enum FilterScopeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("BOTH_JUNCTIONS_AND_EDGES")]
			BOTH_JUNCTIONS_AND_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("JUNCTIONS_ONLY")]
			JUNCTIONS_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("EDGES_ONLY")]
			EDGES_ONLY,

		}

		/// <summary>
		/// <para>Filter by nearest</para>
		/// </summary>
		public enum FilterNearestEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_NEAREST")]
			FILTER_BY_NEAREST,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACE_INDETERMINATE_FLOW")]
			TRACE_INDETERMINATE_FLOW,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("NO_DIRECTION")]
			[Description("NO_DIRECTION")]
			NO_DIRECTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PATH_UPSTREAM")]
			[Description("PATH_UPSTREAM")]
			PATH_UPSTREAM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PATH_DOWNSTREAM")]
			[Description("PATH_DOWNSTREAM")]
			PATH_DOWNSTREAM,

		}

#endregion
	}
}
