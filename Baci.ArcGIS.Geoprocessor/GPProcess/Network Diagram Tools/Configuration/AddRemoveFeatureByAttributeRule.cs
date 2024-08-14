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
	/// <para>Add Remove Feature By Attribute Rule</para>
	/// <para>Adds a diagram rule to automatically remove diagram features during diagram building based on an existing template. The features to be removed are queried by attributes from a given network source class or object table. You can also constrain the removal of features based on connectivity.</para>
	/// </summary>
	public class AddRemoveFeatureByAttributeRule : AbstractGPProcess
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
		/// <param name="NetworkSource">
		/// <para>Network Source to Remove</para>
		/// <para>The network source class or object table to process. All diagram features related to network features or objects that belong to this source class or object table are removal candidates.</para>
		/// </param>
		public AddRemoveFeatureByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object NetworkSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.NetworkSource = NetworkSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Remove Feature By Attribute Rule</para>
		/// </summary>
		public override string DisplayName => "Add Remove Feature By Attribute Rule";

		/// <summary>
		/// <para>Tool Name : AddRemoveFeatureByAttributeRule</para>
		/// </summary>
		public override string ToolName => "AddRemoveFeatureByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddRemoveFeatureByAttributeRule</para>
		/// </summary>
		public override string ExcuteName => "nd.AddRemoveFeatureByAttributeRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, NetworkSource, WhereClause!, Description!, OutUtilityNetwork!, OutTemplateName!, UnconnectedJunctions!, OneConnectedJunction! };

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
		/// <para>Network Source to Remove</para>
		/// <para>The network source class or object table to process. All diagram features related to network features or objects that belong to this source class or object table are removal candidates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select the subset of network elements from the element removal candidates in the diagrams based on the input template. For more information on SQL syntax, see the SQL reference for query expressions used in ArcGIS help topic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

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
		/// <para>Junctions must be unconnected</para>
		/// <para>Specifies whether diagram junctions and diagram containers must be unconnected to be removed.</para>
		/// <para>Checked—Diagram junctions and diagram containers must be unconnected to be removed.</para>
		/// <para>Unchecked—Diagram junctions and diagram containers do not need to be unconnected to be removed. This is the default.</para>
		/// <para>This parameter is only active when the Network Source to Remove parameter value corresponds to junctions or containers in the network diagrams.</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// <para>Specifies whether diagram junctions and diagram containers must be connected to a single diagram junction or diagram container to be removed.</para>
		/// <para>Checked—Diagram junctions and diagram containers must be connected to a single diagram junction or diagram container to be removed.</para>
		/// <para>Unchecked—Diagram junctions and diagram containers do not need to be connected to a single diagram junction or diagram container to be removed. This is the default.</para>
		/// <para>This parameter is only active when the Network Source to Remove parameter value corresponds to junctions or containers in the network diagrams.</para>
		/// <para><see cref="OneConnectedJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? OneConnectedJunction { get; set; } = "false";

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
		/// <para>Junctions must be unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para>Checked—Diagram junctions and diagram containers must be unconnected to be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_UNCONNECTED")]
			MUST_BE_UNCONNECTED,

			/// <summary>
			/// <para>Unchecked—Diagram junctions and diagram containers do not need to be unconnected to be removed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// </summary>
		public enum OneConnectedJunctionEnum 
		{
			/// <summary>
			/// <para>Checked—Diagram junctions and diagram containers must be connected to a single diagram junction or diagram container to be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_CONNECTED_TO_SINGLE_JUNCTION")]
			MUST_BE_CONNECTED_TO_SINGLE_JUNCTION,

			/// <summary>
			/// <para>Unchecked—Diagram junctions and diagram containers do not need to be connected to a single diagram junction or diagram container to be removed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

#endregion
	}
}
