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
	/// <para>Add Remove Feature By Attribute Rule</para>
	/// <para>添加按属性移除要素规则</para>
	/// <para>用于添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中自动移除逻辑示意图要素。 从给定网络源类或对象表按属性对待移除要素进行查询。 您也可以根据连接限制删除功能。</para>
	/// </summary>
	public class AddRemoveFeatureByAttributeRule : AbstractGPProcess
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
		/// <para>Network Source to Remove</para>
		/// <para>要处理的网络源类或对象表。 与属于此源类或对象表的网络要素或对象相关的所有逻辑示意图要素均为移除的候选项。</para>
		/// </param>
		public AddRemoveFeatureByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object NetworkSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.NetworkSource = NetworkSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加按属性移除要素规则</para>
		/// </summary>
		public override string DisplayName() => "添加按属性移除要素规则";

		/// <summary>
		/// <para>Tool Name : AddRemoveFeatureByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddRemoveFeatureByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddRemoveFeatureByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddRemoveFeatureByAttributeRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, NetworkSource, WhereClause!, Description!, OutUtilityNetwork!, OutTemplateName!, UnconnectedJunctions!, OneConnectedJunction! };

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
		/// <para>Network Source to Remove</para>
		/// <para>要处理的网络源类或对象表。 与属于此源类或对象表的网络要素或对象相关的所有逻辑示意图要素均为移除的候选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>SQL 表达式，用于从基于输入模板的逻辑示意图内的元素移除候选项中选择网络元素的子集。 有关 SQL 语法的详细信息，请参阅帮助主题在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
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

		/// <summary>
		/// <para>Junctions must be unconnected</para>
		/// <para>指定逻辑示意图交汇点和图容器是否必须断开连接才能删除。</para>
		/// <para>选中 - 逻辑示意图交汇点和图容器必须断开连接才能删除。</para>
		/// <para>取消选中 - 逻辑示意图交汇点和图容器不必断开连接即可删除。 这是默认设置。</para>
		/// <para>此参数仅在要移除的网络源参数值与网络逻辑示意图中的交汇点或容器相对应时，才处于活动状态。</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// <para>指定逻辑示意图交汇点和图容器是否必须连接到一个单个逻辑示意图交汇点或图容器才能删除。</para>
		/// <para>选中 - 逻辑示意图交汇点和图容器必须连接到一个单个逻辑示意图交汇点或图容器才能删除。</para>
		/// <para>取消选中 - 逻辑示意图交汇点和图容器不必连接到一个单个逻辑示意图交汇点或图容器即可删除。 这是默认设置。</para>
		/// <para>此参数仅在要移除的网络源参数值与网络逻辑示意图中的交汇点或容器相对应时，才处于活动状态。</para>
		/// <para><see cref="OneConnectedJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? OneConnectedJunction { get; set; } = "false";

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
		/// <para>Junctions must be unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_UNCONNECTED")]
			MUST_BE_UNCONNECTED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

		/// <summary>
		/// <para>Junctions must be connected to a single junction</para>
		/// </summary>
		public enum OneConnectedJunctionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MUST_BE_CONNECTED_TO_SINGLE_JUNCTION")]
			MUST_BE_CONNECTED_TO_SINGLE_JUNCTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONSTRAINT")]
			NO_CONSTRAINT,

		}

#endregion
	}
}
