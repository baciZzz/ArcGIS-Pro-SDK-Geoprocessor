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
	/// <para>添加移除要素规则</para>
	/// <para>用于添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中自动移除逻辑示意图要素。此规则基于不同的网络源类和对象表移除逻辑示意图要素。</para>
	/// </summary>
	public class AddRemoveFeatureRule : AbstractGPProcess
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
		/// <param name="SourceType">
		/// <para>Source Type</para>
		/// <para>指定要处理的源类或对象表的几何类型。</para>
		/// <para>仅交汇点—仅会处理交汇点源类或对象表（网络面源类、网络点源类或交汇点对象表）。</para>
		/// <para>仅边—仅会处理边源类或对象表（网络线源类或边对象表）。</para>
		/// <para>交汇点和边—交汇点和边类型均被处理。这是默认设置。</para>
		/// <para><see cref="SourceTypeEnum"/></para>
		/// </param>
		/// <param name="InverseSourceSelection">
		/// <para>Rule Process</para>
		/// <para>指定如何处理指定的网络源类和对象表。</para>
		/// <para>排除源类—将不会移除基于指定网络源类和对象表的要素和对象，但将移除其他要素和对象。</para>
		/// <para>包括源类—基于指定网络源类和对象表的要素和对象将被移除。这是默认设置。</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </param>
		/// <param name="NetworkSource">
		/// <para>Network Sources</para>
		/// <para>网络源类和对象表将根据规则过程而被排除或包括在内。</para>
		/// <para>默认情况下，规则过程被设置为包括源类（Python 中的 inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot;），并将处理一或多个网络源类或对象表。与属于这些类和对象表的网络要素和对象有关的所有逻辑示意图要素都将被移除。</para>
		/// <para>在网络源类中指定 SystemJunctions 时，该规则将系统地处理系统交汇点和系统交汇点对象。</para>
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
		/// <para>Tool Display Name : 添加移除要素规则</para>
		/// </summary>
		public override string DisplayName() => "添加移除要素规则";

		/// <summary>
		/// <para>Tool Name : AddRemoveFeatureRule</para>
		/// </summary>
		public override string ToolName() => "AddRemoveFeatureRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddRemoveFeatureRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddRemoveFeatureRule";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, SourceType, InverseSourceSelection, NetworkSource, Description, OutUtilityNetwork, OutTemplateName };

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
		/// <para>Source Type</para>
		/// <para>指定要处理的源类或对象表的几何类型。</para>
		/// <para>仅交汇点—仅会处理交汇点源类或对象表（网络面源类、网络点源类或交汇点对象表）。</para>
		/// <para>仅边—仅会处理边源类或对象表（网络线源类或边对象表）。</para>
		/// <para>交汇点和边—交汇点和边类型均被处理。这是默认设置。</para>
		/// <para><see cref="SourceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SourceType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Rule Process</para>
		/// <para>指定如何处理指定的网络源类和对象表。</para>
		/// <para>排除源类—将不会移除基于指定网络源类和对象表的要素和对象，但将移除其他要素和对象。</para>
		/// <para>包括源类—基于指定网络源类和对象表的要素和对象将被移除。这是默认设置。</para>
		/// <para><see cref="InverseSourceSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InverseSourceSelection { get; set; } = "INCLUDE_SOURCE_CLASSES";

		/// <summary>
		/// <para>Network Sources</para>
		/// <para>网络源类和对象表将根据规则过程而被排除或包括在内。</para>
		/// <para>默认情况下，规则过程被设置为包括源类（Python 中的 inverse_source_selection = &quot;INCLUDE_SOURCE_CLASSES&quot;），并将处理一或多个网络源类或对象表。与属于这些类和对象表的网络要素和对象有关的所有逻辑示意图要素都将被移除。</para>
		/// <para>在网络源类中指定 SystemJunctions 时，该规则将系统地处理系统交汇点和系统交汇点对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object NetworkSource { get; set; }

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
		/// <para>Source Type</para>
		/// </summary>
		public enum SourceTypeEnum 
		{
			/// <summary>
			/// <para>仅交汇点—仅会处理交汇点源类或对象表（网络面源类、网络点源类或交汇点对象表）。</para>
			/// </summary>
			[GPValue("JUNCTIONS")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边—仅会处理边源类或对象表（网络线源类或边对象表）。</para>
			/// </summary>
			[GPValue("EDGES")]
			[Description("仅边")]
			Edges_only,

			/// <summary>
			/// <para>交汇点和边—交汇点和边类型均被处理。这是默认设置。</para>
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
			/// <para>排除源类—将不会移除基于指定网络源类和对象表的要素和对象，但将移除其他要素和对象。</para>
			/// </summary>
			[GPValue("EXCLUDE_SOURCE_CLASSES")]
			[Description("排除源类")]
			Exclude_source_classes,

			/// <summary>
			/// <para>包括源类—基于指定网络源类和对象表的要素和对象将被移除。这是默认设置。</para>
			/// </summary>
			[GPValue("INCLUDE_SOURCE_CLASSES")]
			[Description("包括源类")]
			Include_source_classes,

		}

#endregion
	}
}
