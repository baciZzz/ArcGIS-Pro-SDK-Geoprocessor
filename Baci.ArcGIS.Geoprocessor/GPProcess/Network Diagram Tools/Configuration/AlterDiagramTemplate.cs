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
	/// <para>更改逻辑示意图模板</para>
	/// <para>更改逻辑示意图模板的属性，例如其名称、如何处理沿输入网络边的折点、是否可存储或扩展相关逻辑示意图、这些逻辑示意图中容器及其内容之间的边距、移除其规则和布局定义，以及将示意图图层定义重置为默认设置。</para>
	/// </summary>
	public class AlterDiagramTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>要更改的逻辑示意图模板的 utility network or trace network。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>要更改的逻辑示意图模板的名称。</para>
		/// </param>
		public AlterDiagramTemplate(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改逻辑示意图模板</para>
		/// </summary>
		public override string DisplayName() => "更改逻辑示意图模板";

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
		/// <para>要更改的逻辑示意图模板的 utility network or trace network。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要更改的逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>New Template Name</para>
		/// <para>模板的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutName { get; set; }

		/// <summary>
		/// <para>Default template</para>
		/// <para>用于指定模板的默认状态。</para>
		/// <para>选中 - 输入逻辑示意图模板将为默认模板。</para>
		/// <para>未选中 - 输入逻辑示意图模板将不会成为默认模板。这是默认设置。</para>
		/// <para>如果未指定模板，则默认模板是生成逻辑示意图时使用的模板。如果未指定其他模板，则其也是使用 utility network or trace network 选项卡组的数据选项卡上的新建逻辑示意图时使用的模板。</para>
		/// <para><see cref="IsDefaultTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsDefaultTemplate { get; set; } = "false";

		/// <summary>
		/// <para>Remove the diagram template rule and layout definitions</para>
		/// <para>用于指定是否将移除模板规则和布局定义。</para>
		/// <para>选中 - 将移除与输入逻辑示意图模板相关的规则和布局定义。</para>
		/// <para>未选中 - 将不会移除与输入逻辑示意图模板相关的规则和布局定义。这是默认设置。</para>
		/// <para><see cref="AreRulesAndLayoutsRemovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreRulesAndLayoutsRemoved { get; set; } = "false";

		/// <summary>
		/// <para>Keep initial vertices on edges</para>
		/// <para>指定如何在基于模板的逻辑示意图中管理沿 GIS 边的折点。</para>
		/// <para>选中 - 沿 GIS 边显示的所有折点将保留在每个基于模板的网络逻辑示意图中的相关边上。</para>
		/// <para>未选中 - 逻辑示意图边将绘制为其连接交汇点之间的直线。这是默认设置。</para>
		/// <para>为了提高性能质量，请仅在需要时选中此参数。例如，如果将模板配置为在逻辑示意图生成时运行自动布局，则选中此选项将对相对主线和部分重叠边逻辑示意图布局非常有意义。其他逻辑示意图布局在执行时不使用逻辑示意图边几何。</para>
		/// <para><see cref="AreVerticesKeptEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object? AreVerticesKept { get; set; } = "false";

		/// <summary>
		/// <para>Container Margin</para>
		/// <para>容器和容器边界内所有交汇点的中心之间的最小距离。</para>
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
		/// <para>指定是否能够存储基于模板的逻辑示意图。</para>
		/// <para>选中 - 能够存储基于模板的逻辑示意图。这是默认设置。</para>
		/// <para>未选中 - 无法存储基于模板的逻辑示意图。</para>
		/// <para><see cref="IsDiagramStorageEnabledEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object? IsDiagramStorageEnabled { get; set; } = "true";

		/// <summary>
		/// <para>Enable to extend diagram</para>
		/// <para>指定是否能够扩展基于模板的逻辑示意图。</para>
		/// <para>选中 - 可以按连通性、可遍历性、包含或附件来扩展基于模板的逻辑示意图。</para>
		/// <para>未选中 - 无法扩展基于模板的逻辑示意图。这是默认设置。</para>
		/// <para><see cref="IsDiagramExtensionEnabledEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Template General Definitions")]
		public object? IsDiagramExtensionEnabled { get; set; } = "false";

		/// <summary>
		/// <para>Description</para>
		/// <para>模板的描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Reset the diagram template layer definition to default</para>
		/// <para>指定是否将逻辑示意图模板图层定义重置为默认值。</para>
		/// <para>选中 - 将与输入逻辑示意图模板相关的示意图图层定义重置为默认值（移除）。</para>
		/// <para>未选中 - 将不会移除与输入逻辑示意图模板相关的逻辑示意图图层定义。这是默认设置。</para>
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
		/// <para>Enable diagram storage</para>
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
		/// <para>Enable to extend diagram</para>
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
