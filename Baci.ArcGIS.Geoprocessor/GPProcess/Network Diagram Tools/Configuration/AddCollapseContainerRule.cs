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
	/// <para>添加折叠容器规则</para>
	/// <para>用于添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中自动折叠容器内容。该规则可以折叠逻辑示意图中容器的全部内容。</para>
	/// </summary>
	public class AddCollapseContainerRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板的名称。</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="ContainerType">
		/// <para>Container Type</para>
		/// <para>指定规则将进行处理的容器源类或对象表的几何类型。</para>
		/// <para>仅交汇点—折叠容器规则将仅处理交汇点容器源类和对象表。仅会处理面容器源类、点容器源类和容器交汇点对象表。</para>
		/// <para>仅边—折叠容器规则将仅处理边容器源类和对象表。仅会处理线性容器源类或容器边对象表。</para>
		/// <para>交汇点和边—折叠容器规则将处理任何容器源类和对象表，无论它们的类型如何。交汇点和边类型均被处理。这是默认设置。</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>指定处理指定容器源类和对象表的方式。</para>
		/// <para>排除源类—将不会折叠所有基于指定源类和对象表的容器，但将折叠其他容器。这是默认设置。</para>
		/// <para>包括源类—将折叠所有基于指定源类和对象表的容器。</para>
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
		/// <para>Tool Display Name : 添加折叠容器规则</para>
		/// </summary>
		public override string DisplayName() => "添加折叠容器规则";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainerType, InverseSourceSelection, ContainerSources, Description, OutUtilityNetwork, OutTemplateName, ReconnectedEdgesOption };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Container Type</para>
		/// <para>指定规则将进行处理的容器源类或对象表的几何类型。</para>
		/// <para>仅交汇点—折叠容器规则将仅处理交汇点容器源类和对象表。仅会处理面容器源类、点容器源类和容器交汇点对象表。</para>
		/// <para>仅边—折叠容器规则将仅处理边容器源类和对象表。仅会处理线性容器源类或容器边对象表。</para>
		/// <para>交汇点和边—折叠容器规则将处理任何容器源类和对象表，无论它们的类型如何。交汇点和边类型均被处理。这是默认设置。</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContainerType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para>指定处理指定容器源类和对象表的方式。</para>
		/// <para>排除源类—将不会折叠所有基于指定源类和对象表的容器，但将折叠其他容器。这是默认设置。</para>
		/// <para>包括源类—将折叠所有基于指定源类和对象表的容器。</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "EXCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Container Sources</para>
		/// <para>“折叠容器”规则执行过程中，将排除或包括的容器源类和对象表，具体取决于所选规则流程。</para>
		/// <para>如果规则过程为排除源类（Python 中的 inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot;），可以对规则进行配置，无需指定特定网络源类或对象表；在这种情况下，其将在生成的逻辑示意图中折叠任何容器源类和对象表的内容。但是，如果规则过程为包括源类（Python 中的 inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot;），必须指定特定的容器源类或要折叠的对象表。</para>
		/// <para>排除源类（Python 中的 inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot;）时，与属于指定类或对象表的任何容器要素或容器对象相关的内容将不会在生成的逻辑示意图中折叠，而与不属于那些类和对象的容器要素和容器对象相关的内容表将被折叠。相反，当规则过程为包括源类（Python 中的 inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot;）时，与属于指定源类和对象表的任何容器要素或容器对象相关的内容将不会在生成的逻辑示意图中折叠，而与不属于那些源类和对象的容器要素和容器对象相关的内容表将不会被折叠。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object ContainerSources { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>规则的描述。</para>
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

		/// <summary>
		/// <para>Aggregate reconnected edges</para>
		/// <para>用于指定规则是否将聚合重新连接到已折叠容器交汇点的边。</para>
		/// <para>未选中 - 任何连接内容交汇点的边都将被保留，并重新连接到已折叠容器交汇点。</para>
		/// <para>选中 - 任何连接内容交汇点的边都将替换为重新连接到已折叠容器交汇点的缩减边。此外，将在相同缩减边下系统地对两个已折叠交汇点之间的多条边进行聚合。这是默认设置。</para>
		/// <para><see cref="ReconnectedEdgesOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReconnectedEdgesOption { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para></para>
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
			/// <para>仅交汇点—折叠容器规则将仅处理交汇点容器源类和对象表。仅会处理面容器源类、点容器源类和容器交汇点对象表。</para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边—折叠容器规则将仅处理边容器源类和对象表。仅会处理线性容器源类或容器边对象表。</para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("仅边")]
			Edges_only,

			/// <summary>
			/// <para>交汇点和边—折叠容器规则将处理任何容器源类和对象表，无论它们的类型如何。交汇点和边类型均被处理。这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

		}

		/// <summary>
		/// <para>Rule Process</para>
		/// </summary>
		public enum InverseSourceSelectionEnum 
		{
			/// <summary>
			/// <para>排除源类—将不会折叠所有基于指定源类和对象表的容器，但将折叠其他容器。这是默认设置。</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("排除源类")]
			Exclude_source_classes,

			/// <summary>
			/// <para>包括源类—将折叠所有基于指定源类和对象表的容器。</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("包括源类")]
			Include_source_classes,

		}

		/// <summary>
		/// <para>Aggregate reconnected edges</para>
		/// </summary>
		public enum ReconnectedEdgesOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AGGREGATE_RECONNECTED_EDGES")]
			AGGREGATE_RECONNECTED_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_AGGREGATE_RECONNECTED_EDGES")]
			DONT_AGGREGATE_RECONNECTED_EDGES,

		}

#endregion
	}
}
