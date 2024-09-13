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
	/// <para>添加展开容器规则</para>
	/// <para>用于添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中自动展开容器内容。此规则将展开逻辑示意图中的所有容器内容。</para>
	/// </summary>
	public class AddExpandContainerRule : AbstractGPProcess
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
		/// <para>要修改的逻辑示意图模板名称</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。 这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="ContainersVisibility">
		/// <para>Keep containers visible</para>
		/// <para>指定容器展开后是否可见。</para>
		/// <para>选中 - 容器展开后仍然可见。这是默认设置。</para>
		/// <para>未选中 - 容器展开后将隐藏。</para>
		/// <para><see cref="ContainersVisibilityEnum"/></para>
		/// </param>
		/// <param name="ContainerType">
		/// <para>Container Type</para>
		/// <para>指定要处理的容器源类或对象表的几何类型。</para>
		/// <para>仅交汇点—仅会处理交汇点容器源类或对象表（面容器源类、点容器源类或容器交汇点对象表）。</para>
		/// <para>仅边—仅会处理边容器源类或对象表（线性容器源类或容器边对象表）。</para>
		/// <para>交汇点和边—所有容器源类和对象表，无论它们的类型如何（交汇点和边类型）都将被处理。这是默认设置。</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>指定如何处理指定的容器源类和对象表。</para>
		/// <para>排除源类—将不会展开基于指定源类和对象表的容器，但将展开其他容器。这是默认设置。</para>
		/// <para>包括源类—将展开基于指定源类和对象表的容器。</para>
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
		/// <para>Tool Display Name : 添加展开容器规则</para>
		/// </summary>
		public override string DisplayName() => "添加展开容器规则";

		/// <summary>
		/// <para>Tool Name : AddExpandContainerRule</para>
		/// </summary>
		public override string ToolName() => "AddExpandContainerRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddExpandContainerRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddExpandContainerRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainersVisibility, ContainerType, InverseSourceSelection, ContainerSources!, Description!, OutUtilityNetwork!, OutTemplateName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要修改的逻辑示意图模板名称</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>指定在基于指定模板生成并更新逻辑示意图时，规则是否将处于激活状态。</para>
		/// <para>选中 - 在基于输入模板生成并更新逻辑示意图的过程中，添加的规则将会变为激活状态。 这是默认设置。</para>
		/// <para>未选中 - 在基于输入模板生成或更新逻辑示意图的过程中，添加的规则将不会变为激活状态。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Keep containers visible</para>
		/// <para>指定容器展开后是否可见。</para>
		/// <para>选中 - 容器展开后仍然可见。这是默认设置。</para>
		/// <para>未选中 - 容器展开后将隐藏。</para>
		/// <para><see cref="ContainersVisibilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContainersVisibility { get; set; } = "true";

		/// <summary>
		/// <para>Container Type</para>
		/// <para>指定要处理的容器源类或对象表的几何类型。</para>
		/// <para>仅交汇点—仅会处理交汇点容器源类或对象表（面容器源类、点容器源类或容器交汇点对象表）。</para>
		/// <para>仅边—仅会处理边容器源类或对象表（线性容器源类或容器边对象表）。</para>
		/// <para>交汇点和边—所有容器源类和对象表，无论它们的类型如何（交汇点和边类型）都将被处理。这是默认设置。</para>
		/// <para><see cref="ContainerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContainerType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para>指定如何处理指定的容器源类和对象表。</para>
		/// <para>排除源类—将不会展开基于指定源类和对象表的容器，但将展开其他容器。这是默认设置。</para>
		/// <para>包括源类—将展开基于指定源类和对象表的容器。</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "EXCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Container Sources</para>
		/// <para>容器源类和对象表将根据规则过程而被排除或包括在内。</para>
		/// <para>当规则过程被设置为排除源类（Python 中的 inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot;）时，无法指定特定的容器源类或对象表。在这种情况下，将展开生成的逻辑示意图中的所有容器，无论其源类或对象表如何。当规则过程设置为包括源类（Python 中的 inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot;），必须指定特定的容器源类和要展开的对象表。</para>
		/// <para>运行排除源类选项（Python 中的 inverse_source_selection = &quot;EXCLUDE_SOURCE_CLASSES&quot;）时，将不会在生成的逻辑示意图中展开属于指定源类或对象表的容器；但是，将展开不属于这些源类和表的容器要素和容器对象。相反，当运行包括源类选项（Python 中的 inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot;）时，将不会在生成的逻辑示意图中展开属于指定源类和对象表的容器；但是，将不会展开不属于这些源类和对象表的容器要素和容器对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ContainerSources { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>规则的描述。</para>
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
		/// <para>Keep containers visible</para>
		/// </summary>
		public enum ContainersVisibilityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_VISIBLE")]
			KEEP_VISIBLE,

			/// <summary>
			/// <para></para>
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
			/// <para>仅交汇点—仅会处理交汇点容器源类或对象表（面容器源类、点容器源类或容器交汇点对象表）。</para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边—仅会处理边容器源类或对象表（线性容器源类或容器边对象表）。</para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("仅边")]
			Edges_only,

			/// <summary>
			/// <para>交汇点和边—所有容器源类和对象表，无论它们的类型如何（交汇点和边类型）都将被处理。这是默认设置。</para>
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
			/// <para>排除源类—将不会展开基于指定源类和对象表的容器，但将展开其他容器。这是默认设置。</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("排除源类")]
			Exclude_source_classes,

			/// <summary>
			/// <para>包括源类—将展开基于指定源类和对象表的容器。</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("包括源类")]
			Include_source_classes,

		}

#endregion
	}
}
