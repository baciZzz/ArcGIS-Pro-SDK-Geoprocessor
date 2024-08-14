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
	/// <para>Add Remove Feature Rule</para>
	/// <para>Adds a diagram rule to automatically remove diagram features during diagram building based on an existing template. This rule removes diagram features based on different network source classes and object tables.</para>
	/// <para></para>
	/// <para></para>
	/// <para></para>
	/// <para>You can constrain the removal of features based on connectivity.</para>
	/// </summary>
	public class AddRemoveFeatureRule : AbstractGPProcess
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
		/// <param name="SourceType">
		/// <para>Source Type</para>
		/// <para>Specifies the geometry type of the source class or object table to be processed.</para>
		/// <para>Junctions only—Only junction source classes or object tables (network polygon source classes, network point source classes, or junction object tables) will be processed.</para>
		/// <para>Edges only—Only edge source classes or object tables (network line source classes or edge object tables) will be processed.</para>
		/// <para>Both junctions and edges—Both junction and edge types will be processed. This is the default.</para>
		/// <para><see cref="SourceTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>Specifies how the specified network source classes and object tables will be processed.</para>
		/// <para>Exclude source classes—Features and objects based on the specified network source classes and object tables will not be removed, while other features and objects will be removed.</para>
		/// <para>Include source classes—Features and objects based on the specified network source classes and object tables will be removed. This is the default.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		/// <param name="NetworkSource">
		/// <para>Network Sources</para>
		/// <para>The network source class (or classes) and object table (or tables) that will be excluded or included depending on the rule process.</para>
		/// <para>By default, Rule Process parameter is set to Include source classes, and one or more network source classes or object tables will be processed. All diagram features related to network features and objects that belong to those classes and object tables will be removed.</para>
		/// <para>When specifying the SystemJunctions class among the network source classes, the rule will systematically process both system junctions and system junction objects.</para>
		/// </param>
		public AddRemoveFeatureRule(object InUtilityNetwork, object TemplateName, object IsActive, object SourceType, object InverseSourceSelection, object NetworkSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.SourceType = SourceType;
			this.InverseSourceSelection = InverseSourceSelection;
			this.NetworkSource = NetworkSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Remove Feature Rule</para>
		/// </summary>
		public override string DisplayName => "Add Remove Feature Rule";

		/// <summary>
		/// <para>Tool Name : AddRemoveFeatureRule</para>
		/// </summary>
		public override string ToolName => "AddRemoveFeatureRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddRemoveFeatureRule</para>
		/// </summary>
		public override string ExcuteName => "nd.AddRemoveFeatureRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, SourceType, InverseSourceSelection, NetworkSource, Description!, OutUtilityNetwork!, OutTemplateName!, UnconnectedJunctions!, OneConnectedJunction! };

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
		/// <para>Source Type</para>
		/// <para>Specifies the geometry type of the source class or object table to be processed.</para>
		/// <para>Junctions only—Only junction source classes or object tables (network polygon source classes, network point source classes, or junction object tables) will be processed.</para>
		/// <para>Edges only—Only edge source classes or object tables (network line source classes or edge object tables) will be processed.</para>
		/// <para>Both junctions and edges—Both junction and edge types will be processed. This is the default.</para>
		/// <para><see cref="SourceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SourceType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para>Specifies how the specified network source classes and object tables will be processed.</para>
		/// <para>Exclude source classes—Features and objects based on the specified network source classes and object tables will not be removed, while other features and objects will be removed.</para>
		/// <para>Include source classes—Features and objects based on the specified network source classes and object tables will be removed. This is the default.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "INCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Network Sources</para>
		/// <para>The network source class (or classes) and object table (or tables) that will be excluded or included depending on the rule process.</para>
		/// <para>By default, Rule Process parameter is set to Include source classes, and one or more network source classes or object tables will be processed. All diagram features related to network features and objects that belong to those classes and object tables will be removed.</para>
		/// <para>When specifying the SystemJunctions class among the network source classes, the rule will systematically process both system junctions and system junction objects.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object NetworkSource { get; set; }

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
		/// <para>Specifies whether diagram junction and diagram container candidates must be unconnected to be removed.</para>
		/// <para>Checked—Diagram junction and diagram container candidates must be unconnected to be removed.</para>
		/// <para>Unchecked—Neither diagram junction nor diagram container candidates need to be unconnected to be removed. This is the default.</para>
		/// <para>This parameter is active only when the Source Type parameter is set to Junctions only.</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// <para>Specifies whether diagram junction and diagram container candidates must be connected to a single diagram junction or diagram container to be removed.</para>
		/// <para>Checked—Diagram junction and diagram container candidates must be connected to a single diagram junction or diagram container to be removed.</para>
		/// <para>Unchecked—Neither diagram junction nor diagram container candidates need to be connected to a single diagram junction or diagram container to be removed. This is the default.</para>
		/// <para>This parameter is active only when the Source Type parameter is set to Junctions only.</para>
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
		/// <para>Source Type</para>
		/// </summary>
		public enum SourceTypeEnum 
		{
			/// <summary>
			/// <para>Junctions only—Only junction source classes or object tables (network polygon source classes, network point source classes, or junction object tables) will be processed.</para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("Junctions only")]
			Junctions_only,

			/// <summary>
			/// <para>Edges only—Only edge source classes or object tables (network line source classes or edge object tables) will be processed.</para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("Edges only")]
			Edges_only,

			/// <summary>
			/// <para>Both junctions and edges—Both junction and edge types will be processed. This is the default.</para>
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
			/// <para>Exclude source classes—Features and objects based on the specified network source classes and object tables will not be removed, while other features and objects will be removed.</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("Exclude source classes")]
			Exclude_source_classes,

			/// <summary>
			/// <para>Include source classes—Features and objects based on the specified network source classes and object tables will be removed. This is the default.</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("Include source classes")]
			Include_source_classes,

		}

		/// <summary>
		/// <para>Junctions must be unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para>Checked—Diagram junction and diagram container candidates must be unconnected to be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_UNCONNECTED")]
			MUST_BE_UNCONNECTED,

			/// <summary>
			/// <para>Unchecked—Neither diagram junction nor diagram container candidates need to be unconnected to be removed. This is the default.</para>
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
			/// <para>Checked—Diagram junction and diagram container candidates must be connected to a single diagram junction or diagram container to be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_CONNECTED_TO_SINGLE_JUNCTION")]
			MUST_BE_CONNECTED_TO_SINGLE_JUNCTION,

			/// <summary>
			/// <para>Unchecked—Neither diagram junction nor diagram container candidates need to be connected to a single diagram junction or diagram container to be removed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

#endregion
	}
}
