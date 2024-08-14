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
	/// <para>Add Diagram Feature Capability By Attribute Rule</para>
	/// <para>Adds a diagram rule to a diagram template to assign a particular capability on diagram features currently represented in the diagram. This capability is used by other rules executed later in the rule sequence. The diagram features that will be processed are queried from a network source class or object table by attributes.</para>
	/// </summary>
	public class AddDiagramFeatureCapabilityByAttributeRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template to modify.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>Specifies whether the rule will be active when generating and updating diagrams based on the specified template.</para>
		/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
		/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="NetworkSource">
		/// <para>Network Source</para>
		/// <para>The network source class or object table that references the features or objects associated with the diagram features to which the particular capability will be assigned.</para>
		/// </param>
		/// <param name="WhereClause">
		/// <para>Expression</para>
		/// <para>An SQL expression used to filter out the features or objects of interest among the specified network source feature class or objet table. For more information on SQL syntax, see SQL reference for query expressions used in ArcGIS.</para>
		/// </param>
		/// <param name="Capability">
		/// <para>Capability</para>
		/// <para>Specifies the capability that will be assigned to the queried diagram features at the end of the rule execution. This capability will be used by other rules executed later in the rule sequence.</para>
		/// <para>Prevent related container from collapse— All queried features will be flagged to prevent their related container from being collapsed by Collapse Container rules executed later in the rule sequence. This is the default.</para>
		/// <para>Allow related container to collapse— All queried features will be flagged to allow their related container to be collapsed by Collapse Container rules executed later in the rule sequence.</para>
		/// <para>Prevent reduce junction— All queried junctions will be flagged to prevent Reduce Junction rules executed later in the rule sequence to reduce them.</para>
		/// <para>Allow reduce junction— All queried junctions will be flagged to allow Reduce Junction rules executed later in the rule sequence to reduce them.</para>
		/// <para><see cref="CapabilityEnum"/></para>
		/// </param>
		public AddDiagramFeatureCapabilityByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object NetworkSource, object WhereClause, object Capability)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.NetworkSource = NetworkSource;
			this.WhereClause = WhereClause;
			this.Capability = Capability;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Diagram Feature Capability By Attribute Rule</para>
		/// </summary>
		public override string DisplayName => "Add Diagram Feature Capability By Attribute Rule";

		/// <summary>
		/// <para>Tool Name : AddDiagramFeatureCapabilityByAttributeRule</para>
		/// </summary>
		public override string ToolName => "AddDiagramFeatureCapabilityByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddDiagramFeatureCapabilityByAttributeRule</para>
		/// </summary>
		public override string ExcuteName => "nd.AddDiagramFeatureCapabilityByAttributeRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, NetworkSource, WhereClause, Capability, Description, OutUtilityNetwork, OutTemplateName };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template to modify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
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
		/// <para>Network Source</para>
		/// <para>The network source class or object table that references the features or objects associated with the diagram features to which the particular capability will be assigned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to filter out the features or objects of interest among the specified network source feature class or objet table. For more information on SQL syntax, see SQL reference for query expressions used in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Capability</para>
		/// <para>Specifies the capability that will be assigned to the queried diagram features at the end of the rule execution. This capability will be used by other rules executed later in the rule sequence.</para>
		/// <para>Prevent related container from collapse— All queried features will be flagged to prevent their related container from being collapsed by Collapse Container rules executed later in the rule sequence. This is the default.</para>
		/// <para>Allow related container to collapse— All queried features will be flagged to allow their related container to be collapsed by Collapse Container rules executed later in the rule sequence.</para>
		/// <para>Prevent reduce junction— All queried junctions will be flagged to prevent Reduce Junction rules executed later in the rule sequence to reduce them.</para>
		/// <para>Allow reduce junction— All queried junctions will be flagged to allow Reduce Junction rules executed later in the rule sequence to reduce them.</para>
		/// <para><see cref="CapabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Capability { get; set; } = "PREVENT_TO_COLLAPSE_CONTAINER";

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the rule.</para>
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
		/// <para>Capability</para>
		/// </summary>
		public enum CapabilityEnum 
		{
			/// <summary>
			/// <para>Allow related container to collapse— All queried features will be flagged to allow their related container to be collapsed by Collapse Container rules executed later in the rule sequence.</para>
			/// </summary>
			[GPValue("ALLOW_TO_COLLAPSE_CONTAINER")]
			[Description("Allow related container to collapse")]
			Allow_related_container_to_collapse,

			/// <summary>
			/// <para>Prevent related container from collapse— All queried features will be flagged to prevent their related container from being collapsed by Collapse Container rules executed later in the rule sequence. This is the default.</para>
			/// </summary>
			[GPValue("PREVENT_TO_COLLAPSE_CONTAINER")]
			[Description("Prevent related container from collapse")]
			Prevent_related_container_from_collapse,

			/// <summary>
			/// <para>Allow reduce junction— All queried junctions will be flagged to allow Reduce Junction rules executed later in the rule sequence to reduce them.</para>
			/// </summary>
			[GPValue("ALLOW_TO_REDUCE_JUNCTION")]
			[Description("Allow reduce junction")]
			Allow_reduce_junction,

			/// <summary>
			/// <para>Prevent reduce junction— All queried junctions will be flagged to prevent Reduce Junction rules executed later in the rule sequence to reduce them.</para>
			/// </summary>
			[GPValue("PREVENT_TO_REDUCE_JUNCTION")]
			[Description("Prevent reduce junction")]
			Prevent_reduce_junction,

		}

#endregion
	}
}
