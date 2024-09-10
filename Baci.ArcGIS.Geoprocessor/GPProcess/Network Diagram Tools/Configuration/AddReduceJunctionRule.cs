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
	/// <para>Add Reduce Junction Rule</para>
	/// <para>Adds a diagram rule to automatically reduce diagram junctions during diagram building based on an existing template. This tool reduces junctions based on several network junction source classes and object tables according to the number of other junctions to which they are connected.</para>
	/// </summary>
	public class AddReduceJunctionRule : AbstractGPProcess
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
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>Specifies how the specified junction source classes and object tables will be processed.</para>
		/// <para>Exclude source classes—Junctions based on the specified source classes and object tables will not be processed, while other junctions will be processed.</para>
		/// <para>Include source classes—Only junctions based on the specified source classes and object tables will be processed. This is the default.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		public AddReduceJunctionRule(object InUtilityNetwork, object TemplateName, object IsActive, object InverseSourceSelection)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.InverseSourceSelection = InverseSourceSelection;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Reduce Junction Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Reduce Junction Rule";

		/// <summary>
		/// <para>Tool Name : AddReduceJunctionRule</para>
		/// </summary>
		public override string ToolName() => "AddReduceJunctionRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddReduceJunctionRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddReduceJunctionRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, InverseSourceSelection, JunctionSource, ConnectivityOptions, UnconnectedJunctions, OneConnectedJunction, TwoConnectedJunctions, EdgesAttributes, Description, OutUtilityNetwork, OutTemplateName };

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
		/// <para>Rule Process</para>
		/// <para>Specifies how the specified junction source classes and object tables will be processed.</para>
		/// <para>Exclude source classes—Junctions based on the specified source classes and object tables will not be processed, while other junctions will be processed.</para>
		/// <para>Include source classes—Only junctions based on the specified source classes and object tables will be processed. This is the default.</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "INCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Junction Sources</para>
		/// <para>A list of the network junction source class (or classes) and object table (or tables) that will be excluded or included depending on the rule process.</para>
		/// <para>When Rule Process is set to Include source classes (inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot; in Python), the default, one or more network junction source classes or object tables will be processed. All diagram junctions related to network junctions that belong to those source classes and object tables are reduction candidates.The Add Reduce Junction Rule tool will process the junction source classes and object tables in the order of this list, from the junction class or table with the highest priority—the first class or table in the list—to the junction class or table with the lowest priority—the last class or table in the list.</para>
		/// <para>When Rule Process is set to Exclude source classes (inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot; in Python), no particular junction source class or object table must be specified. In this case, all junctions in the generated diagrams, regardless of their source class or object table, will be reduced.</para>
		/// <para>When specifying the SystemJunctions class among the network junction source classes, the rule will systematically process both system junctions and system junction objects.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object JunctionSource { get; set; }

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
		public object ConnectivityOptions { get; set; } = "MAX_2_CONNECTED_JUNCTIONS";

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
		public object UnconnectedJunctions { get; set; } = "false";

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
		public object OneConnectedJunction { get; set; } = "false";

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
		public object TwoConnectedJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Edge Attribute Names</para>
		/// <para>The alias of the edge attributes adjacent to the junction reduction candidate.</para>
		/// <para>The junction will be reduced only when all of its adjacent edges have the same values for each specified attribute alias.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Connected edges constraints")]
		public object EdgesAttributes { get; set; }

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
		/// <para>Rule Process</para>
		/// </summary>
		public enum InverseSourceSelectionEnum 
		{
			/// <summary>
			/// <para>Exclude source classes—Junctions based on the specified source classes and object tables will not be processed, while other junctions will be processed.</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("Exclude source classes")]
			Exclude_source_classes,

			/// <summary>
			/// <para>Include source classes—Only junctions based on the specified source classes and object tables will be processed. This is the default.</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("Include source classes")]
			Include_source_classes,

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
