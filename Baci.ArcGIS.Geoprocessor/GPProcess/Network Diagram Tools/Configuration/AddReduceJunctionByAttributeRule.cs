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
	/// <para>Add Reduce Junction By Attribute Rule</para>
	/// <para>Add Reduce Junction By Attribute Rule</para>
	/// <para>Adds a diagram rule to automatically reduce diagram junctions during diagram building based on an existing template. The junctions to reduce are queried from a given network junction source class or object table by attributes according to the number of other junctions to which they are connected.</para>
	/// </summary>
	public class AddReduceJunctionByAttributeRule : AbstractGPProcess
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
		/// <param name="JunctionSource">
		/// <para>Junction Source to Reduce</para>
		/// <para>The network junction source class or object table to process. All diagram junctions related to network junctions that belong to this source class or object table are reduction candidates.</para>
		/// </param>
		public AddReduceJunctionByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object JunctionSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.JunctionSource = JunctionSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Reduce Junction By Attribute Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Reduce Junction By Attribute Rule";

		/// <summary>
		/// <para>Tool Name : AddReduceJunctionByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddReduceJunctionByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddReduceJunctionByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddReduceJunctionByAttributeRule";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, JunctionSource, WhereClause!, ConnectivityOptions!, UnconnectedJunctions!, OneConnectedJunction!, TwoConnectedJunctions!, EdgesAttributes!, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Junction Source to Reduce</para>
		/// <para>The network junction source class or object table to process. All diagram junctions related to network junctions that belong to this source class or object table are reduction candidates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JunctionSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select the subset of network junctions from the junction reduction candidates in the diagrams based on the input template. For more information on SQL syntax, see the SQL reference for query expressions used in ArcGIS help topic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Reduce Junctions With</para>
		/// <para>Specifies the number of junction connections that will be considered for reduction.</para>
		/// <para>Maximum two connected junctions—Junctions with two or less connections will be considered. In this case, a specific process will be executed according to the number of candidate junction connections that will be reduced. This is the default.</para>
		/// <para>Minimum three connected junctions—Junctions with three or more connections will be considered. In this case, upstream traces will be executed to determine whether candidate junction connections will be reduced.</para>
		/// <para><see cref="ConnectivityOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? ConnectivityOptions { get; set; } = "MAX_2_CONNECTED_JUNCTIONS";

		/// <summary>
		/// <para>Reduce if unconnected</para>
		/// <para>Specifies whether each unconnected network diagram junction candidate will be reduced. This parameter is only active when Reduce Junctions With is set to Maximum two connected junctions.</para>
		/// <para>Checked—Unconnected network diagram junction candidates will be reduced. Each junction will be removed.</para>
		/// <para>Unchecked—Unconnected network diagram junction candidates will not be reduced; they will be kept. This is the default.</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Reduce if connected to a single junction</para>
		/// <para>Specifies whether each network diagram junction reduction candidate that is connected to a single junction will be reduced. This parameter is only active when Reduce Junctions With is set to Maximum two connected junctions.</para>
		/// <para>Checked—Network diagram junction reduction candidates that are connected to a single junction will be reduced. Each junction and its incident edge will be reduced onto its single connected junction.</para>
		/// <para>Unchecked—Network diagram junction reduction candidates that are connected to a single junction will not be reduced; they will be kept. This is the default.</para>
		/// <para><see cref="OneConnectedJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? OneConnectedJunction { get; set; } = "false";

		/// <summary>
		/// <para>Reduce if connected to 2 different junctions</para>
		/// <para>Specifies whether each network diagram junction reduction candidate that is connected to two other junctions will be reduced. This parameter is only active when Reduce Junctions With is set to Maximum two connected junctions.</para>
		/// <para>Checked—Network diagram junction reduction candidates that connect two other junctions will be reduced. Each junction and its incident edges will be reduced onto a super span edge (the reduction edge). This is the default.</para>
		/// <para>Unchecked—Network diagram junction reduction candidates that connect two other junctions will not be reduced; they will be kept.</para>
		/// <para><see cref="TwoConnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? TwoConnectedJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Edge Attribute Names</para>
		/// <para>The alias of the edge attributes adjacent to the junction reduction candidate.</para>
		/// <para>The junction will be reduced only when all of its adjacent edges have the same values for each specified attribute alias.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Connected edges constraints")]
		public object? EdgesAttributes { get; set; }

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
		/// <para>Reduce Junctions With</para>
		/// </summary>
		public enum ConnectivityOptionsEnum 
		{
			/// <summary>
			/// <para>Maximum two connected junctions—Junctions with two or less connections will be considered. In this case, a specific process will be executed according to the number of candidate junction connections that will be reduced. This is the default.</para>
			/// </summary>
			[GPValue("MAX_2_CONNECTED_JUNCTIONS")]
			[Description("Maximum two connected junctions")]
			Maximum_two_connected_junctions,

			/// <summary>
			/// <para>Minimum three connected junctions—Junctions with three or more connections will be considered. In this case, upstream traces will be executed to determine whether candidate junction connections will be reduced.</para>
			/// </summary>
			[GPValue("MIN_3_CONNECTED_JUNCTIONS")]
			[Description("Minimum three connected junctions")]
			Minimum_three_connected_junctions,

		}

		/// <summary>
		/// <para>Reduce if unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para>Checked—Unconnected network diagram junction candidates will be reduced. Each junction will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_UNCONNECTED_JCT")]
			REDUCE_UNCONNECTED_JCT,

			/// <summary>
			/// <para>Unchecked—Unconnected network diagram junction candidates will not be reduced; they will be kept. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_UNCONNECTED_JCT")]
			KEEP_UNCONNECTED_JCT,

		}

		/// <summary>
		/// <para>Reduce if connected to a single junction</para>
		/// </summary>
		public enum OneConnectedJunctionEnum 
		{
			/// <summary>
			/// <para>Checked—Network diagram junction reduction candidates that are connected to a single junction will be reduced. Each junction and its incident edge will be reduced onto its single connected junction.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_JCT_TO_1JCT")]
			REDUCE_JCT_TO_1JCT,

			/// <summary>
			/// <para>Unchecked—Network diagram junction reduction candidates that are connected to a single junction will not be reduced; they will be kept. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_JCT_TO_1JCT")]
			KEEP_JCT_TO_1JCT,

		}

		/// <summary>
		/// <para>Reduce if connected to 2 different junctions</para>
		/// </summary>
		public enum TwoConnectedJunctionsEnum 
		{
			/// <summary>
			/// <para>Checked—Network diagram junction reduction candidates that connect two other junctions will be reduced. Each junction and its incident edges will be reduced onto a super span edge (the reduction edge). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_JCT_TO_2JCTS")]
			REDUCE_JCT_TO_2JCTS,

			/// <summary>
			/// <para>Unchecked—Network diagram junction reduction candidates that connect two other junctions will not be reduced; they will be kept.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_JCT_TO_2JCTS")]
			KEEP_JCT_TO_2JCTS,

		}

#endregion
	}
}
