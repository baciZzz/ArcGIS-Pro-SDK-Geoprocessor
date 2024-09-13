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
	/// <para>Add Set Root Junction By Attribute Rule</para>
	/// <para>添加按属性设置根交汇点规则</para>
	/// <para>用于添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中自动标记逻辑示意图交汇点。此规则可指定基于特定交汇点源类或对象表的根交汇点，并使用其属性进行过滤。</para>
	/// </summary>
	public class AddSetRootJunctionByAttributeRule : AbstractGPProcess
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
		/// <param name="JunctionSource">
		/// <para>Junction Source to Select</para>
		/// <para>要处理的网络交汇点源类或对象表。与属于此源类或对象表的网络要素相关的所有逻辑示意图交汇点均为根交汇点候选项。</para>
		/// </param>
		public AddSetRootJunctionByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object JunctionSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.JunctionSource = JunctionSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加按属性设置根交汇点规则</para>
		/// </summary>
		public override string DisplayName() => "添加按属性设置根交汇点规则";

		/// <summary>
		/// <para>Tool Name : AddSetRootJunctionByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddSetRootJunctionByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddSetRootJunctionByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddSetRootJunctionByAttributeRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, JunctionSource, WhereClause!, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Junction Source to Select</para>
		/// <para>要处理的网络交汇点源类或对象表。与属于此源类或对象表的网络要素相关的所有逻辑示意图交汇点均为根交汇点候选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JunctionSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>可选 SQL 表达式，用于从根交汇点候选项中过滤出基于输入模板的逻辑示意图中的预期根交汇点。有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

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

#endregion
	}
}
