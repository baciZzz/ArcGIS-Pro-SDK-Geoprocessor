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
	/// <para>Add Collapse Container By Attribute Rule</para>
	/// <para>添加按属性折叠容器规则</para>
	/// <para>将逻辑示意图规则添加到示意图模板指定的规则序列中，以便在构建示意图期间自动折叠与容器相关的所有内容。可基于其属性通过 SQL 查询对含待折叠内容的容器进行识别。</para>
	/// </summary>
	public class AddCollapseContainerByAttributeRule : AbstractGPProcess
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
		/// <param name="ContainerSource">
		/// <para>Container Source</para>
		/// <para>引用容器的容器源类或对象表，执行折叠容器规则期间要折叠该容器的内容。</para>
		/// </param>
		public AddCollapseContainerByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object ContainerSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.ContainerSource = ContainerSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加按属性折叠容器规则</para>
		/// </summary>
		public override string DisplayName() => "添加按属性折叠容器规则";

		/// <summary>
		/// <para>Tool Name : AddCollapseContainerByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddCollapseContainerByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddCollapseContainerByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddCollapseContainerByAttributeRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, ContainerSource, WhereClause, Description, OutUtilityNetwork, OutTemplateName, ReconnectedEdgesOption };

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
		/// <para>Container Source</para>
		/// <para>引用容器的容器源类或对象表，执行折叠容器规则期间要折叠该容器的内容。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object ContainerSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择此源类或对象表中容器子集的 SQL 表达式，将在生成的逻辑示意图中折叠其内容。有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

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
