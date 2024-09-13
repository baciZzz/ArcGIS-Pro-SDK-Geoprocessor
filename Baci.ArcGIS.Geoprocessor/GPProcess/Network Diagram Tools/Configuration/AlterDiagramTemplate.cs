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
	/// <para>Alter Diagram Template</para>
	/// <para>Alter Diagram Template</para>
	/// <para>Alters the properties of a diagram template such as its name, how it handles vertices along input network edges, whether the related diagrams can be stored or extended, the margin between containers and their contents in these diagrams, the removal of its rule and layout, and the reset of the diagram layer definition to default.</para>
	/// </summary>
	public class AlterDiagramTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network of the diagram template to alter.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to alter.</para>
		/// </param>
		public AlterDiagramTemplate(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Diagram Template</para>
		/// </summary>
		public override string DisplayName() => "Alter Diagram Template";

		/// <summary>
		/// <para>Tool Name : AlterDiagramTemplate</para>
		/// </summary>
		public override string ToolName() => "AlterDiagramTemplate";

		/// <summary>
		/// <para>Tool Excute Name : nd.AlterDiagramTemplate</para>
		/// </summary>
		public override string ExcuteName() => "nd.AlterDiagramTemplate";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, OutName!, IsDefaultTemplate!, AreRulesAndLayoutsRemoved!, AreVerticesKept!, ContainerMargin!, OutUtilityNetwork!, OutTemplateName!, IsDiagramStorageEnabled!, IsDiagramExtensionEnabled!, Description!, AreLayerDefinitionsRemoved! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network of the diagram template to alter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to alter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>New Template Name</para>
		/// <para>The new name of the template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutName { get; set; }

		/// <summary>
		/// <para>Default template</para>
		/// <para>Specifies the default status of the template.</para>
		/// <para>Checked—The input diagram template will be the default template.</para>
		/// <para>Unchecked—The input diagram template will not be the default template. This is the default.</para>
		/// <para>The default template is the one used when generating a diagram if a template is not specified. It is also the template used when using New Diagram on the Data tab on the utility network or trace network tab set if another template is not specified.</para>
		/// <para><see cref="IsDefaultTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsDefaultTemplate { get; set; } = "false";

		/// <summary>
		/// <para>Remove the diagram template rule and layout definitions</para>
		/// <para>Specifies whether the template rule and layout definitions will be removed.</para>
		/// <para>Checked—The rule and layout definitions related to the input diagram template will be removed.</para>
		/// <para>Unchecked—The rule and layout definitions related to the input diagram template will not be removed. This is the default.</para>
		/// <para><see cref="AreRulesAndLayoutsRemovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreRulesAndLayoutsRemoved { get; set; } = "false";

		/// <summary>
		/// <para>Keep initial vertices on edges</para>
		/// <para>Specifies how vertices along the GIS edges will be managed in the diagrams based on the template.</para>
		/// <para>Checked—All vertices that display along GIS edges will be preserved on the associated edges in each network diagram based on the template.</para>
		/// <para>Unchecked—Diagram edges will be drawn as straight lines between their connected junctions. This is the default.</para>
		/// <para>For performance quality, check this parameter only when needed. If your template is configured to run an automatic layout at diagram generation, for example, checking this option makes sense for the Relative Mainline and Partial Overlapping Edges diagram layouts. The other diagram layouts don&apos;t use diagram edges geometry when they execute.</para>
		/// <para><see cref="AreVerticesKeptEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object? AreVerticesKept { get; set; } = "false";

		/// <summary>
		/// <para>Container Margin</para>
		/// <para>The minimum distance between the center of any junctions inside the container and the container border.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Template General Definitions")]
		public object? ContainerMargin { get; set; } = "0 Unknown";

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
		/// <para>Enable diagram storage</para>
		/// <para>Specifies whether the diagrams based on the template can be stored.</para>
		/// <para>Checked—The diagrams based on the template can be stored. This is the default.</para>
		/// <para>Unchecked—The diagrams based on the template cannot be stored.</para>
		/// <para><see cref="IsDiagramStorageEnabledEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object? IsDiagramStorageEnabled { get; set; } = "true";

		/// <summary>
		/// <para>Enable to extend diagram</para>
		/// <para>Specifies whether the diagrams based on the template can be extended.</para>
		/// <para>Checked—The diagrams based on the template can be extended by connectivity, traversability, containment, or attachment.</para>
		/// <para>Unchecked—The diagrams based on the template cannot be extended. This is the default.</para>
		/// <para><see cref="IsDiagramExtensionEnabledEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object? IsDiagramExtensionEnabled { get; set; } = "false";

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Reset the diagram template layer definition to default</para>
		/// <para>Specifies whether the diagram template layer definition will be reset to default.</para>
		/// <para>Checked—The diagram layer definition related to the input diagram template will be reset to default (removed).</para>
		/// <para>Unchecked—The diagram layer definition related to the input diagram template will not be removed. This is the default.</para>
		/// <para><see cref="AreLayerDefinitionsRemovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreLayerDefinitionsRemoved { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Default template</para>
		/// </summary>
		public enum IsDefaultTemplateEnum 
		{
			/// <summary>
			/// <para>Checked—The input diagram template will be the default template.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFAULT_TEMPLATE")]
			DEFAULT_TEMPLATE,

			/// <summary>
			/// <para>Unchecked—The input diagram template will not be the default template. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_DEFAULT_TEMPLATE")]
			NOT_DEFAULT_TEMPLATE,

		}

		/// <summary>
		/// <para>Remove the diagram template rule and layout definitions</para>
		/// </summary>
		public enum AreRulesAndLayoutsRemovedEnum 
		{
			/// <summary>
			/// <para>Checked—The rule and layout definitions related to the input diagram template will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_RULES_AND_LAYOUTS")]
			REMOVE_RULES_AND_LAYOUTS,

			/// <summary>
			/// <para>Unchecked—The rule and layout definitions related to the input diagram template will not be removed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REMOVE_RULES_AND_LAYOUTS")]
			DO_NOT_REMOVE_RULES_AND_LAYOUTS,

		}

		/// <summary>
		/// <para>Keep initial vertices on edges</para>
		/// </summary>
		public enum AreVerticesKeptEnum 
		{
			/// <summary>
			/// <para>Checked—All vertices that display along GIS edges will be preserved on the associated edges in each network diagram based on the template.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_VERTICES")]
			KEEP_VERTICES,

			/// <summary>
			/// <para>Unchecked—Diagram edges will be drawn as straight lines between their connected junctions. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_KEEP_VERTICES")]
			DO_NOT_KEEP_VERTICES,

		}

		/// <summary>
		/// <para>Enable diagram storage</para>
		/// </summary>
		public enum IsDiagramStorageEnabledEnum 
		{
			/// <summary>
			/// <para>Checked—The diagrams based on the template can be stored. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_DIAGRAM_STORAGE")]
			ENABLE_DIAGRAM_STORAGE,

			/// <summary>
			/// <para>Unchecked—The diagrams based on the template cannot be stored.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_DIAGRAM_STORAGE")]
			DISABLE_DIAGRAM_STORAGE,

		}

		/// <summary>
		/// <para>Enable to extend diagram</para>
		/// </summary>
		public enum IsDiagramExtensionEnabledEnum 
		{
			/// <summary>
			/// <para>Checked—The diagrams based on the template can be extended by connectivity, traversability, containment, or attachment.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_DIAGRAM_EXTENSION")]
			ENABLE_DIAGRAM_EXTENSION,

			/// <summary>
			/// <para>Unchecked—The diagrams based on the template cannot be extended. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_DIAGRAM_EXTENSION")]
			DISABLE_DIAGRAM_EXTENSION,

		}

		/// <summary>
		/// <para>Reset the diagram template layer definition to default</para>
		/// </summary>
		public enum AreLayerDefinitionsRemovedEnum 
		{
			/// <summary>
			/// <para>Checked—The diagram layer definition related to the input diagram template will be reset to default (removed).</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_LAYER_DEFINITIONS")]
			REMOVE_LAYER_DEFINITIONS,

			/// <summary>
			/// <para>Unchecked—The diagram layer definition related to the input diagram template will not be removed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REMOVE_LAYER_DEFINITIONS")]
			DO_NOT_REMOVE_LAYER_DEFINITIONS,

		}

#endregion
	}
}
