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
	/// <para>Add Expand Container By Attribute Rule</para>
	/// <para>Adds a diagram rule to automatically expand container contents during diagram building based on an existing template. The containers to expand are filtered by attributes from a given container source class or object table.</para>
	/// </summary>
	public class AddExpandContainerByAttributeRule : AbstractGPProcess
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
		/// <param name="ContainersVisibility">
		/// <para>Keep containers visible</para>
		/// <para>Specifies whether the containers stay visible after they are expanded.</para>
		/// <para>Checked—The containers will stay visible after they are expanded. This is the default.</para>
		/// <para>Unchecked—The containers will be hidden after they are expanded.</para>
		/// <para><see cref="ContainersVisibilityEnum"/></para>
		/// </param>
		/// <param name="ContainerSource">
		/// <para>Container Source</para>
		/// <para>The container source class or object table that references the containers to be expanded.</para>
		/// </param>
		public AddExpandContainerByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object ContainersVisibility, object ContainerSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.ContainersVisibility = ContainersVisibility;
			this.ContainerSource = ContainerSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Expand Container By Attribute Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Expand Container By Attribute Rule";

		/// <summary>
		/// <para>Tool Name : AddExpandContainerByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddExpandContainerByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddExpandContainerByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddExpandContainerByAttributeRule";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainersVisibility, ContainerSource, WhereClause, Description, OutUtilityNetwork, OutTemplateName };

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
		/// <para>Keep containers visible</para>
		/// <para>Specifies whether the containers stay visible after they are expanded.</para>
		/// <para>Checked—The containers will stay visible after they are expanded. This is the default.</para>
		/// <para>Unchecked—The containers will be hidden after they are expanded.</para>
		/// <para><see cref="ContainersVisibilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContainersVisibility { get; set; } = "true";

		/// <summary>
		/// <para>Container Source</para>
		/// <para>The container source class or object table that references the containers to be expanded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object ContainerSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select the subset of containers in the container source class or object table that will be expanded in the generated diagrams. For more information on SQL syntax, see the SQL reference for query expressions used in ArcGIS help topic.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

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
		/// <para>Keep containers visible</para>
		/// </summary>
		public enum ContainersVisibilityEnum 
		{
			/// <summary>
			/// <para>Checked—The containers will stay visible after they are expanded. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_VISIBLE")]
			KEEP_VISIBLE,

			/// <summary>
			/// <para>Unchecked—The containers will be hidden after they are expanded.</para>
			/// </summary>
			[GPValue("false")]
			[Description("HIDE")]
			HIDE,

		}

#endregion
	}
}
