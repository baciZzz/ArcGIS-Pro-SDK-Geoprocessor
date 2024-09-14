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
	/// <para>Delete Rule</para>
	/// <para>Delete Rule</para>
	/// <para>Permanently deletes a rule from a utility network.</para>
	/// </summary>
	public class DeleteRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network for which the rule will be removed.</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>The type of rule being deleted.</para>
		/// <para>All—Delete all rules.</para>
		/// <para>Junction-junction connectivity—Delete a junction-junction connectivity association rule.</para>
		/// <para>Containment—Delete a containment association rule.</para>
		/// <para>Structural attachment—Delete a structural attachment association rule.</para>
		/// <para>Junction-edge connectivity—Delete a junction-edge connectivity rule.</para>
		/// <para>Edge-junction-edge connectivity—Delete an edge-junction-edge connectivity rule.</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		public DeleteRule(object InUtilityNetwork, object RuleType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Rule</para>
		/// </summary>
		public override string DisplayName() => "Delete Rule";

		/// <summary>
		/// <para>Tool Name : DeleteRule</para>
		/// </summary>
		public override string ToolName() => "DeleteRule";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteRule</para>
		/// </summary>
		public override string ExcuteName() => "un.DeleteRule";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, RuleDesc!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network for which the rule will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>The type of rule being deleted.</para>
		/// <para>All—Delete all rules.</para>
		/// <para>Junction-junction connectivity—Delete a junction-junction connectivity association rule.</para>
		/// <para>Containment—Delete a containment association rule.</para>
		/// <para>Structural attachment—Delete a structural attachment association rule.</para>
		/// <para>Junction-edge connectivity—Delete a junction-edge connectivity rule.</para>
		/// <para>Edge-junction-edge connectivity—Delete an edge-junction-edge connectivity rule.</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>Rules</para>
		/// <para>Specifies which rule to remove. This includes the rule ID and the description of the rule.You can find the rule ID by browsing the Rules section of the Network Properties, which is available on the Layer Properties dialog box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RuleDesc { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>All—Delete all rules.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Junction-junction connectivity—Delete a junction-junction connectivity association rule.</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("Junction-junction connectivity")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity—Delete a junction-edge connectivity rule.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Junction-edge connectivity")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>Containment—Delete a containment association rule.</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("Containment")]
			Containment,

			/// <summary>
			/// <para>Structural attachment—Delete a structural attachment association rule.</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("Structural attachment")]
			Structural_attachment,

			/// <summary>
			/// <para>Edge-junction-edge connectivity—Delete an edge-junction-edge connectivity rule.</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Edge-junction-edge connectivity")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
