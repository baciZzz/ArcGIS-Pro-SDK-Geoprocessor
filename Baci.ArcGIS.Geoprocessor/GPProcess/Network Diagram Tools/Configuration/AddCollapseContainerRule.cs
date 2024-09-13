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
	/// <para>Add Collapse Container Rule</para>
	/// <para>Add Collapse Container Rule</para>
	/// <para>Adds a diagram rule that automatically collapses container contents during the building of diagrams based on an existing template. This rule collapses the entire contents of containers in the diagrams.</para>
	/// </summary>
	public class AddCollapseContainerRule : AbstractGPProcess
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
		/// <param name="ContainerType">
		/// <para>Container Type</para>
		/// <para>Specifies the geometry type of the container source class or object table the rule will process.</para>
		/// <para>Junctions only—The Collapse Container rule will process the junction container source classes and object tables only. Only the polygon container source classes, point container source classes, and container junction object tables will be processed.</para>
		/// <para>Edges only—The Collapse Container rule will process the edge container source classes and object tables only. Only the linear container source classes or container edge object tables will be processed.</para>
		/// <para>Both junctions and edges—The Collapse Container rule will process any container source classes and object tables regardless of their type. Both junction and edge types will be processed. This is the default.</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>Specifies how the rule will process the specified container source classes and object tables.</para>
		/// <para>Exclude source classes—Containers that are based on the specified source classes and object tables will not be collapsed, while other containers will be collapsed. This is the default.</para>
		/// <para>Include source classes—Containers that are based on the specified source classes and object tables will be collapsed.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		public AddCollapseContainerRule(object InUtilityNetwork, object TemplateName, object IsActive, object ContainerType, object InverseSourceSelection)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.ContainerType = ContainerType;
			this.InverseSourceSelection = InverseSourceSelection;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Collapse Container Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Collapse Container Rule";

		/// <summary>
		/// <para>Tool Name : AddCollapseContainerRule</para>
		/// </summary>
		public override string ToolName() => "AddCollapseContainerRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddCollapseContainerRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddCollapseContainerRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainerType, InverseSourceSelection, ContainerSources!, Description!, OutUtilityNetwork!, OutTemplateName!, ReconnectedEdgesOption! };

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
		/// <para>Container Type</para>
		/// <para>Specifies the geometry type of the container source class or object table the rule will process.</para>
		/// <para>Junctions only—The Collapse Container rule will process the junction container source classes and object tables only. Only the polygon container source classes, point container source classes, and container junction object tables will be processed.</para>
		/// <para>Edges only—The Collapse Container rule will process the edge container source classes and object tables only. Only the linear container source classes or container edge object tables will be processed.</para>
		/// <para>Both junctions and edges—The Collapse Container rule will process any container source classes and object tables regardless of their type. Both junction and edge types will be processed. This is the default.</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContainerType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para>Specifies how the rule will process the specified container source classes and object tables.</para>
		/// <para>Exclude source classes—Containers that are based on the specified source classes and object tables will not be collapsed, while other containers will be collapsed. This is the default.</para>
		/// <para>Include source classes—Containers that are based on the specified source classes and object tables will be collapsed.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "EXCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Container Sources</para>
		/// <para>The container source class (or classes) and object table (or tables) that will be excluded or included during the Collapse Container rule execution depending on the chosen rule process.</para>
		/// <para>If Rule Process is Exclude source classes (inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot; in Python), the rule can be configured without specifying a particular network source class or object table, in which case it will collapse contents of any container source classes and object tables in the generated diagrams. However, if Rule Process is Include source classes (inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot; in Python), the particular container source class (or classes) or object table (or tables) to be collapsed must be specified.</para>
		/// <para>When Exclude source classes (inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot; in Python), the contents related to any container features or container objects belonging to the specified classes or object tables will not be collapsed in the generated diagrams, while contents related to container features and container objects that don&apos;t belong to those classes and object tables will be collapsed. Conversely, when Rule Process is Include Source Classes (inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot; in Python), the contents related to any container features and container objects belonging to the specified source classes and object tables will be collapsed in the generated diagrams, while contents related to container features and container objects that don&apos;t belong to those source classes and object tables will not be collapsed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ContainerSources { get; set; }

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
		/// <para>Aggregate reconnected edges</para>
		/// <para>Specifies whether the rule will aggregate the edges that are reconnected to the collapsed container junctions.</para>
		/// <para>Unchecked—Any edge connecting a content junction will be kept and reconnected to the collapsed container junction.</para>
		/// <para>Checked—Any edge connecting a content junction will be replaced by a reduction edge that is reconnected to the collapsed container junction. Multiple edges between two collapsed junctions will be systematically aggregated under the same reduction edge. This is the default.</para>
		/// <para><see cref="ReconnectedEdgesOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReconnectedEdgesOption { get; set; } = "true";

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
		/// <para>Container Type</para>
		/// </summary>
		public enum ContainerTypeEnum 
		{
			/// <summary>
			/// <para>Junctions only—The Collapse Container rule will process the junction container source classes and object tables only. Only the polygon container source classes, point container source classes, and container junction object tables will be processed.</para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—The Collapse Container rule will process the edge container source classes and object tables only. Only the linear container source classes or container edge object tables will be processed.</para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("Edges only")]
			Edges_only,

			/// <summary>
			/// <para>Both junctions and edges—The Collapse Container rule will process any container source classes and object tables regardless of their type. Both junction and edge types will be processed. This is the default.</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("Both junctions and edges")]
			Both_junctions_and_edges,

		}

		/// <summary>
		/// <para>Rule Process</para>
		/// </summary>
		public enum InverseSourceSelectionEnum 
		{
			/// <summary>
			/// <para>Exclude source classes—Containers that are based on the specified source classes and object tables will not be collapsed, while other containers will be collapsed. This is the default.</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("Exclude source classes")]
			Exclude_source_classes,

			/// <summary>
			/// <para>Include source classes—Containers that are based on the specified source classes and object tables will be collapsed.</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("Include source classes")]
			Include_source_classes,

		}

		/// <summary>
		/// <para>Aggregate reconnected edges</para>
		/// </summary>
		public enum ReconnectedEdgesOptionEnum 
		{
			/// <summary>
			/// <para>Checked—Any edge connecting a content junction will be replaced by a reduction edge that is reconnected to the collapsed container junction. Multiple edges between two collapsed junctions will be systematically aggregated under the same reduction edge. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AGGREGATE_RECONNECTED_EDGES")]
			AGGREGATE_RECONNECTED_EDGES,

			/// <summary>
			/// <para>Unchecked—Any edge connecting a content junction will be kept and reconnected to the collapsed container junction.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_AGGREGATE_RECONNECTED_EDGES")]
			DONT_AGGREGATE_RECONNECTED_EDGES,

		}

#endregion
	}
}
