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
	/// <para>Add Rule</para>
	/// <para>Add Rule</para>
	/// <para>Adds a rule to a utility network.</para>
	/// </summary>
	public class AddRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network for which the rule will be added.</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>The type of rule to be created.</para>
		/// <para>Junction-junction connectivity—Creates a junction-junction connectivity rule allowing two point features to connect via a connectivity association (features are offset geometrically).</para>
		/// <para>Containment—Creates a containment rule where the from parameters are the container and the to parameters are the contents in a containment association.</para>
		/// <para>Structural attachment—Creates a structural attachment rule where the from parameters are the structure features and the to parameters are the attachment features in a structural attachment association.</para>
		/// <para>Junction-edge connectivity—Creates an edge-junction connectivity rule allowing edge and junction features to connect via geometric coincidence (features are at the same x,y,z location).</para>
		/// <para>Edge-junction-edge connectivity—Creates an edge-junction-edge connectivity rule allowing a edge to connect to either side of a junction feature.</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		/// <param name="FromClass">
		/// <para>From Table</para>
		/// <para>The from utility network feature class or table that will be included in the rule.</para>
		/// <para>Structural attachment and containment association rules require that the container or structure feature be in this parameter.</para>
		/// <para>Ordering is irrelevant for the junction-junction, junction-edge, and edge-junction-edge connectivity rules.</para>
		/// </param>
		/// <param name="FromAssetgroup">
		/// <para>From Asset Group</para>
		/// <para>An asset group for the From Table to which the rule will apply.</para>
		/// </param>
		/// <param name="FromAssettype">
		/// <para>From Asset Type</para>
		/// <para>An asset type for the From Table to which the rule will apply.</para>
		/// </param>
		/// <param name="ToClass">
		/// <para>To Table</para>
		/// <para>The to utility network feature class or table that will be included in the rule.</para>
		/// <para>Structural attachment and containment associations rules require that the content or attachment feature be in this parameter.</para>
		/// <para>Ordering is irrelevant for the junction-junction, junction-edge, and edge-junction-edge connectivity rules.</para>
		/// </param>
		/// <param name="ToAssetgroup">
		/// <para>To Asset Group</para>
		/// <para>An asset group for the To Table to which the rule will apply.</para>
		/// </param>
		/// <param name="ToAssettype">
		/// <para>To Asset Type</para>
		/// <para>An asset type for the To Table to which the rule will apply.</para>
		/// </param>
		public AddRule(object InUtilityNetwork, object RuleType, object FromClass, object FromAssetgroup, object FromAssettype, object ToClass, object ToAssetgroup, object ToAssettype)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
			this.FromClass = FromClass;
			this.FromAssetgroup = FromAssetgroup;
			this.FromAssettype = FromAssettype;
			this.ToClass = ToClass;
			this.ToAssetgroup = ToAssetgroup;
			this.ToAssettype = ToAssettype;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Rule";

		/// <summary>
		/// <para>Tool Name : AddRule</para>
		/// </summary>
		public override string ToolName() => "AddRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddRule</para>
		/// </summary>
		public override string ExcuteName() => "un.AddRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, FromClass, FromAssetgroup, FromAssettype, ToClass, ToAssetgroup, ToAssettype, FromTerminal, ToTerminal, ViaClass, ViaAssetgroup, ViaAssettype, ViaTerminal, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network for which the rule will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>The type of rule to be created.</para>
		/// <para>Junction-junction connectivity—Creates a junction-junction connectivity rule allowing two point features to connect via a connectivity association (features are offset geometrically).</para>
		/// <para>Containment—Creates a containment rule where the from parameters are the container and the to parameters are the contents in a containment association.</para>
		/// <para>Structural attachment—Creates a structural attachment rule where the from parameters are the structure features and the to parameters are the attachment features in a structural attachment association.</para>
		/// <para>Junction-edge connectivity—Creates an edge-junction connectivity rule allowing edge and junction features to connect via geometric coincidence (features are at the same x,y,z location).</para>
		/// <para>Edge-junction-edge connectivity—Creates an edge-junction-edge connectivity rule allowing a edge to connect to either side of a junction feature.</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>From Table</para>
		/// <para>The from utility network feature class or table that will be included in the rule.</para>
		/// <para>Structural attachment and containment association rules require that the container or structure feature be in this parameter.</para>
		/// <para>Ordering is irrelevant for the junction-junction, junction-edge, and edge-junction-edge connectivity rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromClass { get; set; }

		/// <summary>
		/// <para>From Asset Group</para>
		/// <para>An asset group for the From Table to which the rule will apply.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromAssetgroup { get; set; }

		/// <summary>
		/// <para>From Asset Type</para>
		/// <para>An asset type for the From Table to which the rule will apply.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromAssettype { get; set; }

		/// <summary>
		/// <para>To Table</para>
		/// <para>The to utility network feature class or table that will be included in the rule.</para>
		/// <para>Structural attachment and containment associations rules require that the content or attachment feature be in this parameter.</para>
		/// <para>Ordering is irrelevant for the junction-junction, junction-edge, and edge-junction-edge connectivity rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToClass { get; set; }

		/// <summary>
		/// <para>To Asset Group</para>
		/// <para>An asset group for the To Table to which the rule will apply.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToAssetgroup { get; set; }

		/// <summary>
		/// <para>To Asset Type</para>
		/// <para>An asset type for the To Table to which the rule will apply.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToAssettype { get; set; }

		/// <summary>
		/// <para>From Terminal</para>
		/// <para>The from terminal to which the rule will apply. This will be a terminal in the From Table. When creating a connectivity rule for feature with terminals to connect to another feature, the terminal side to connect from must be specified, for example, the high-side terminal on a transformer.</para>
		/// <para>This parameter is required if the asset type has terminals. It is disabled when the structural attachment or containment association rule is specified in the Rule Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FromTerminal { get; set; }

		/// <summary>
		/// <para>To Terminal</para>
		/// <para>The to terminal to which the rule will apply. This will be a terminal in the To Table. When creating a connectivity rule for feature to connect to another feature with terminals, the terminal side to connect to must be specified, for example, the low-side terminal on a transformer.</para>
		/// <para>This parameter is required if the asset type has terminals. It is disabled for structural attachment or containment association rule types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ToTerminal { get; set; }

		/// <summary>
		/// <para>Via Table</para>
		/// <para>The junction utility network feature class or table to which the rule will apply. This parameter is available only when edge-junction-edge connectivity is selected for the Rule Type parameter, since three feature classes or tables are required to participate in edge-junction-edge connectivity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaClass { get; set; }

		/// <summary>
		/// <para>Via Asset Group</para>
		/// <para>An asset group of the Via Table to which the rule will apply. This parameter is available only when edge-junction-edge connectivity is selected for the Rule Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaAssetgroup { get; set; }

		/// <summary>
		/// <para>Via Asset Type</para>
		/// <para>An asset type of the Via Table to which the rule will apply. This parameter is available only when edge-junction-edge connectivity is selected for the Rule Type parameter</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaAssettype { get; set; }

		/// <summary>
		/// <para>Via Terminal</para>
		/// <para>The terminal from the Via Table to which the rule will apply. This parameter is available only when edge-junction-edge connectivity is selected for the Rule Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ViaTerminal { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>Junction-junction connectivity—Creates a junction-junction connectivity rule allowing two point features to connect via a connectivity association (features are offset geometrically).</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("Junction-junction connectivity")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity—Creates an edge-junction connectivity rule allowing edge and junction features to connect via geometric coincidence (features are at the same x,y,z location).</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Junction-edge connectivity")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>Containment—Creates a containment rule where the from parameters are the container and the to parameters are the contents in a containment association.</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("Containment")]
			Containment,

			/// <summary>
			/// <para>Structural attachment—Creates a structural attachment rule where the from parameters are the structure features and the to parameters are the attachment features in a structural attachment association.</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("Structural attachment")]
			Structural_attachment,

			/// <summary>
			/// <para>Edge-junction-edge connectivity—Creates an edge-junction-edge connectivity rule allowing a edge to connect to either side of a junction feature.</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Edge-junction-edge connectivity")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
