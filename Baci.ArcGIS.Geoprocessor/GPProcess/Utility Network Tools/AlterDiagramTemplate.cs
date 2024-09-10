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
	/// <para>Alter Diagram Template</para>
	/// <para>Alter the properties of the Diagram Template</para>
	/// </summary>
	[Obsolete()]
	public class AlterDiagramTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
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
		/// <para>Tool Excute Name : un.AlterDiagramTemplate</para>
		/// </summary>
		public override string ExcuteName() => "un.AlterDiagramTemplate";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, OutName, IsDefaultTemplate, AreRulesAndLayoutsRemoved, AreVerticesKept, ContainerMargin, OutUtilityNetwork, OutTemplateName, IsDiagramStorageEnabled, IsDiagramExtensionEnabled, Description, AreLayerDefinitionsRemoved };

		/// <summary>
		/// <para>Input Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Diagram Template Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Default template</para>
		/// <para><see cref="IsDefaultTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsDefaultTemplate { get; set; } = "false";

		/// <summary>
		/// <para>Remove the diagram template rule and layout definitions</para>
		/// <para><see cref="AreRulesAndLayoutsRemovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreRulesAndLayoutsRemoved { get; set; } = "false";

		/// <summary>
		/// <para>Keep initial vertices on edges</para>
		/// <para><see cref="AreVerticesKeptEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object AreVerticesKept { get; set; } = "false";

		/// <summary>
		/// <para>Container Margin</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Template General Definitions")]
		public object ContainerMargin { get; set; } = "0 Unknown";

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

		/// <summary>
		/// <para>Enable to store diagrams</para>
		/// <para><see cref="IsDiagramStorageEnabledEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object IsDiagramStorageEnabled { get; set; } = "true";

		/// <summary>
		/// <para>Enable to extend diagrams</para>
		/// <para><see cref="IsDiagramExtensionEnabledEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object IsDiagramExtensionEnabled { get; set; } = "false";

		/// <summary>
		/// <para>Description</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Reset the diagram template layer definition to default</para>
		/// <para><see cref="AreLayerDefinitionsRemovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreLayerDefinitionsRemoved { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Default template</para>
		/// </summary>
		public enum IsDefaultTemplateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFAULT_TEMPLATE")]
			DEFAULT_TEMPLATE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_RULES_AND_LAYOUTS")]
			REMOVE_RULES_AND_LAYOUTS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_VERTICES")]
			KEEP_VERTICES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_KEEP_VERTICES")]
			DO_NOT_KEEP_VERTICES,

		}

		/// <summary>
		/// <para>Enable to store diagrams</para>
		/// </summary>
		public enum IsDiagramStorageEnabledEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_DIAGRAM_STORAGE")]
			ENABLE_DIAGRAM_STORAGE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_DIAGRAM_STORAGE")]
			DISABLE_DIAGRAM_STORAGE,

		}

		/// <summary>
		/// <para>Enable to extend diagrams</para>
		/// </summary>
		public enum IsDiagramExtensionEnabledEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_DIAGRAM_EXTENSION")]
			ENABLE_DIAGRAM_EXTENSION,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_LAYER_DEFINITIONS")]
			REMOVE_LAYER_DEFINITIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_REMOVE_LAYER_DEFINITIONS")]
			DO_NOT_REMOVE_LAYER_DEFINITIONS,

		}

#endregion
	}
}
