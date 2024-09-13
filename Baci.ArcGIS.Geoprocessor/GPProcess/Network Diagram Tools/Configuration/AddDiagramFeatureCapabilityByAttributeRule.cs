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
	/// <para>Add Diagram Feature Capability By Attribute Rule</para>
	/// <para>添加按属性逻辑示意图要素功能规则</para>
	/// <para>用于将逻辑示意图规则添加到逻辑示意图模板，以便对逻辑示意图中当前显示的逻辑示意图要素分配特定功能。 稍后在规则序列中执行的其他规则将会使用此功能。 将按属性从网络源类或对象表对待处理的逻辑示意图要素进行查询。</para>
	/// </summary>
	public class AddDiagramFeatureCapabilityByAttributeRule : AbstractGPProcess
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
		/// <param name="NetworkSource">
		/// <para>Network Source</para>
		/// <para>此网络源类或对象表可引用与系统将为其分配特定功能的逻辑示意图要素相关联的要素。</para>
		/// </param>
		/// <param name="WhereClause">
		/// <para>Expression</para>
		/// <para>此 SQL 表达式用于过滤掉指定网络源要素类或对象表中的感兴趣要素或对象。 有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </param>
		/// <param name="Capability">
		/// <para>Capability</para>
		/// <para>指定将在规则执行结束时分配至所查询逻辑示意图要素的功能。 规则序列中稍后执行的其他规则将使用此功能。</para>
		/// <para>阻止相关容器折叠—系统将标记所有已查询的要素，以阻止其父容器被规则序列中稍后执行的“折叠容器”规则折叠。 这是默认设置。</para>
		/// <para>允许相关容器折叠—系统将标记所有已查询的要素，以允许通过规则序列中稍后执行的“折叠容器”规则折叠其相关容器。</para>
		/// <para>阻止减少交汇点—系统将标记所有已查询的交汇点，以阻止在规则序列中稍后执行的“减少交汇点”规则减少这些交汇点。</para>
		/// <para>允许减少交汇点—系统将标记所有已查询的交汇点，以允许在规则序列中稍后执行的“减少交汇点”规则减少这些交汇点。</para>
		/// <para><see cref="CapabilityEnum"/></para>
		/// </param>
		public AddDiagramFeatureCapabilityByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object NetworkSource, object WhereClause, object Capability)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.NetworkSource = NetworkSource;
			this.WhereClause = WhereClause;
			this.Capability = Capability;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加按属性逻辑示意图要素功能规则</para>
		/// </summary>
		public override string DisplayName() => "添加按属性逻辑示意图要素功能规则";

		/// <summary>
		/// <para>Tool Name : AddDiagramFeatureCapabilityByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddDiagramFeatureCapabilityByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddDiagramFeatureCapabilityByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddDiagramFeatureCapabilityByAttributeRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, NetworkSource, WhereClause, Capability, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Network Source</para>
		/// <para>此网络源类或对象表可引用与系统将为其分配特定功能的逻辑示意图要素相关联的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>此 SQL 表达式用于过滤掉指定网络源要素类或对象表中的感兴趣要素或对象。 有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Capability</para>
		/// <para>指定将在规则执行结束时分配至所查询逻辑示意图要素的功能。 规则序列中稍后执行的其他规则将使用此功能。</para>
		/// <para>阻止相关容器折叠—系统将标记所有已查询的要素，以阻止其父容器被规则序列中稍后执行的“折叠容器”规则折叠。 这是默认设置。</para>
		/// <para>允许相关容器折叠—系统将标记所有已查询的要素，以允许通过规则序列中稍后执行的“折叠容器”规则折叠其相关容器。</para>
		/// <para>阻止减少交汇点—系统将标记所有已查询的交汇点，以阻止在规则序列中稍后执行的“减少交汇点”规则减少这些交汇点。</para>
		/// <para>允许减少交汇点—系统将标记所有已查询的交汇点，以允许在规则序列中稍后执行的“减少交汇点”规则减少这些交汇点。</para>
		/// <para><see cref="CapabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Capability { get; set; } = "PREVENT_TO_COLLAPSE_CONTAINER";

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
		/// <para>Capability</para>
		/// </summary>
		public enum CapabilityEnum 
		{
			/// <summary>
			/// <para>允许相关容器折叠—系统将标记所有已查询的要素，以允许通过规则序列中稍后执行的“折叠容器”规则折叠其相关容器。</para>
			/// </summary>
			[GPValue("ALLOW_TO_COLLAPSE_CONTAINER")]
			[Description("允许相关容器折叠")]
			Allow_related_container_to_collapse,

			/// <summary>
			/// <para>阻止相关容器折叠—系统将标记所有已查询的要素，以阻止其父容器被规则序列中稍后执行的“折叠容器”规则折叠。 这是默认设置。</para>
			/// </summary>
			[GPValue("PREVENT_TO_COLLAPSE_CONTAINER")]
			[Description("阻止相关容器折叠")]
			Prevent_related_container_from_collapse,

			/// <summary>
			/// <para>允许减少交汇点—系统将标记所有已查询的交汇点，以允许在规则序列中稍后执行的“减少交汇点”规则减少这些交汇点。</para>
			/// </summary>
			[GPValue("ALLOW_TO_REDUCE_JUNCTION")]
			[Description("允许减少交汇点")]
			Allow_reduce_junction,

			/// <summary>
			/// <para>阻止减少交汇点—系统将标记所有已查询的交汇点，以阻止在规则序列中稍后执行的“减少交汇点”规则减少这些交汇点。</para>
			/// </summary>
			[GPValue("PREVENT_TO_REDUCE_JUNCTION")]
			[Description("阻止减少交汇点")]
			Prevent_reduce_junction,

		}

#endregion
	}
}
