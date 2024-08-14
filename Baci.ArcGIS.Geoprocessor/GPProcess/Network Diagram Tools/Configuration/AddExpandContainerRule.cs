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
	/// <para>Add Expand Container Rule</para>
	/// <para>Adds a diagram rule that automatically expands container contents during diagram building  based on an existing template. This rule expands all of the container contents in the diagrams.</para>
	/// </summary>
	public class AddExpandContainerRule : AbstractGPProcess
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
		/// <param name="ContainersVisibility">
		/// <para>Keep containers visible</para>
		/// <para>Specifies whether the containers stay visible after they are expanded.</para>
		/// <para>Checked—The containers will stay visible after they are expanded. This is the default.</para>
		/// <para>Unchecked—The containers will be hidden after they are expanded.</para>
		/// <para><see cref="ContainersVisibilityEnum"/></para>
		/// </param>
		/// <param name="ContainerType">
		/// <para>Container Type</para>
		/// <para>Specifies the geometry type of the container source class or object table to be processed.</para>
		/// <para>Junctions only—Only junction container source classes or object tables (polygon container source classes, point container source classes, or container junction object tables) will be processed.</para>
		/// <para>Edges only—Only edge container source classes or object tables (linear container source classes or container edge object tables) will be processed.</para>
		/// <para>Both junctions and edges—All container source classes and object tables regardless of their type (both junction and edge types), will be processed. This is the default.</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>Specifies how the specified container source classes and object tables will be processed.</para>
		/// <para>Exclude source classes—Containers based on the specified source classes and object tables will not be expanded, while other containers will be expanded. This is the default.</para>
		/// <para>Include source classes—Containers based on the specified source classes and object tables will be expanded.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		public AddExpandContainerRule(object InUtilityNetwork, object TemplateName, object IsActive, object ContainersVisibility, object ContainerType, object InverseSourceSelection)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.ContainersVisibility = ContainersVisibility;
			this.ContainerType = ContainerType;
			this.InverseSourceSelection = InverseSourceSelection;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Expand Container Rule</para>
		/// </summary>
		public override string DisplayName => "Add Expand Container Rule";

		/// <summary>
		/// <para>Tool Name : AddExpandContainerRule</para>
		/// </summary>
		public override string ToolName => "AddExpandContainerRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddExpandContainerRule</para>
		/// </summary>
		public override string ExcuteName => "nd.AddExpandContainerRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainersVisibility, ContainerType, InverseSourceSelection, ContainerSources!, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Container Type</para>
		/// <para>Specifies the geometry type of the container source class or object table to be processed.</para>
		/// <para>Junctions only—Only junction container source classes or object tables (polygon container source classes, point container source classes, or container junction object tables) will be processed.</para>
		/// <para>Edges only—Only edge container source classes or object tables (linear container source classes or container edge object tables) will be processed.</para>
		/// <para>Both junctions and edges—All container source classes and object tables regardless of their type (both junction and edge types), will be processed. This is the default.</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContainerType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para>Specifies how the specified container source classes and object tables will be processed.</para>
		/// <para>Exclude source classes—Containers based on the specified source classes and object tables will not be expanded, while other containers will be expanded. This is the default.</para>
		/// <para>Include source classes—Containers based on the specified source classes and object tables will be expanded.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "EXCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Container Sources</para>
		/// <para>The container source class (or classes) and object table (or tables) that will be excluded or included depending on the rule process.</para>
		/// <para>When Rule Process is set to Exclude source classes (inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot; in Python), no particular container source class or object table can be specified. In this case, all containers in the generated diagrams regardless of their source class or object table will be expanded. When Rule Process is set to Include source classes (inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot; in Python), the particular container source class (or classes) and object table (or tables) to be expanded must be specified.</para>
		/// <para>When running the Exclude source classes option (inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot; in Python), the containers belonging to the specified source classes or object tables will not be expanded in the generated diagrams; however, container features and container objects that don&apos;t belong to those source classes and tables will be expanded. Conversely, when running the Include source classes option (inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot; in Python), the containers belonging to the specified source classes and object tables will be expanded in the generated diagrams; however, container features and container objects that don&apos;t belong to those source classes and object tables will not be expanded.</para>
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

		/// <summary>
		/// <para>Container Type</para>
		/// </summary>
		public enum ContainerTypeEnum 
		{
			/// <summary>
			/// <para>Junctions only—Only junction container source classes or object tables (polygon container source classes, point container source classes, or container junction object tables) will be processed.</para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—Only edge container source classes or object tables (linear container source classes or container edge object tables) will be processed.</para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("Edges only")]
			Edges_only,

			/// <summary>
			/// <para>Both junctions and edges—All container source classes and object tables regardless of their type (both junction and edge types), will be processed. This is the default.</para>
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
			/// <para>Exclude source classes—Containers based on the specified source classes and object tables will not be expanded, while other containers will be expanded. This is the default.</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("Exclude source classes")]
			Exclude_source_classes,

			/// <summary>
			/// <para>Include source classes—Containers based on the specified source classes and object tables will be expanded.</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("Include source classes")]
			Include_source_classes,

		}

#endregion
	}
}
