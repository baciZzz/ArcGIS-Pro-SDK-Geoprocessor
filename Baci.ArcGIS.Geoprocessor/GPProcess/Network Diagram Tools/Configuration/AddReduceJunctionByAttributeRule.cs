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
	/// <para>Add Reduce Junction By Attribute Rule</para>
	/// <para>添加按属性减少交汇点规则</para>
	/// <para>用于添加逻辑示意图规则，以在基于现有模板构建逻辑示意图的过程中自动减少逻辑示意图交汇点。根据所连接的其他交汇点的数量，按属性从给定网络交汇点源类或对象表对待减少交汇点进行查询。</para>
	/// </summary>
	public class AddReduceJunctionByAttributeRule : AbstractGPProcess
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
		/// <para>Junction Source to Reduce</para>
		/// <para>要处理的网络交汇点源类或对象表。与属于此源类或对象表的网络交汇点相关的所有逻辑示意图交汇点均为减少的候选项。</para>
		/// </param>
		public AddReduceJunctionByAttributeRule(object InUtilityNetwork, object TemplateName, object IsActive, object JunctionSource)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.JunctionSource = JunctionSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加按属性减少交汇点规则</para>
		/// </summary>
		public override string DisplayName() => "添加按属性减少交汇点规则";

		/// <summary>
		/// <para>Tool Name : AddReduceJunctionByAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddReduceJunctionByAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddReduceJunctionByAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddReduceJunctionByAttributeRule";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, JunctionSource, WhereClause!, ConnectivityOptions!, UnconnectedJunctions!, OneConnectedJunction!, TwoConnectedJunctions!, EdgesAttributes!, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Junction Source to Reduce</para>
		/// <para>要处理的网络交汇点源类或对象表。与属于此源类或对象表的网络交汇点相关的所有逻辑示意图交汇点均为减少的候选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JunctionSource { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>SQL 表达式，用于从基于输入模板的逻辑示意图内的候选减少的交汇点中选择网络交汇点的子集。有关 SQL 语法的详细信息，请参阅帮助主题在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Reduce Junctions With</para>
		/// <para>指定将要减少的交汇点连接数。</para>
		/// <para>最多两个连接交汇点—将考虑具有两个或更少连接的交汇点。在这种情况下，将会根据待减少的候选交汇点连接数执行特定过程。这是默认设置。</para>
		/// <para>最少三个连接交汇点—将考虑具有三个或更多连接的交汇点。在这种情况下，将执行上游追踪以确定是否减少候选交汇点连接。</para>
		/// <para><see cref="ConnectivityOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? ConnectivityOptions { get; set; } = "MAX_2_CONNECTED_JUNCTIONS";

		/// <summary>
		/// <para>Reduce if unconnected</para>
		/// <para>指定是否将减少每个未连接的网络逻辑示意图交汇点候选项。此参数仅在减少交汇点被设置为最多两个连接交汇点时处于活动状态。</para>
		/// <para>选中 - 未连接的网络逻辑示意图交汇点候选项将被减少。每个交汇点将被移除。</para>
		/// <para>未选中 - 未连接的网络逻辑示意图交汇点候选项不会被减少；它们将被保留。这是默认设置。</para>
		/// <para><see cref="UnconnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? UnconnectedJunctions { get; set; } = "false";

		/// <summary>
		/// <para>Reduce if connected to a single junction</para>
		/// <para>指定是否将减少连接到单个交汇点的每个网络逻辑示意图交汇点减少候选项。此参数仅在减少交汇点被设置为最多两个连接交汇点时处于活动状态。</para>
		/// <para>选中 - 将减少连接到单个交汇点的网络逻辑示意图交汇点减少候选项。每一个交汇点及其事件边均会被减少到单个连接交汇点。</para>
		/// <para>未选中 - 将不会减少连接到单个交汇点的网络逻辑示意图交汇点减少候选项；它们将被保留。这是默认设置。</para>
		/// <para><see cref="OneConnectedJunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? OneConnectedJunction { get; set; } = "false";

		/// <summary>
		/// <para>Reduce if connected to 2 different junctions</para>
		/// <para>指定是否将减少连接到其他两个交汇点的每个网络逻辑示意图交汇点减少候选项。此参数仅在减少交汇点被设置为最多两个连接交汇点时处于活动状态。</para>
		/// <para>选中 - 将减少连接其他两个交汇点的网络逻辑示意图交汇点减少候选项。每个交汇点及其事件边均会被减少到超跨度边（减少边）。这是默认设置。</para>
		/// <para>未选中 - 将不会减少连接其他两个交汇点的网络逻辑示意图交汇点减少候选项；它们将被保留。</para>
		/// <para><see cref="TwoConnectedJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Connectivity constraints")]
		public object? TwoConnectedJunctions { get; set; } = "true";

		/// <summary>
		/// <para>Edge Attribute Names</para>
		/// <para>邻近交汇点减少候选项的边属性的别名。</para>
		/// <para>仅当每个指定属性别名的所有相邻边具有相同值时，交汇点才会减少。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Connected edges constraints")]
		public object? EdgesAttributes { get; set; }

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
		/// <para>Reduce Junctions With</para>
		/// </summary>
		public enum ConnectivityOptionsEnum 
		{
			/// <summary>
			/// <para>最多两个连接交汇点—将考虑具有两个或更少连接的交汇点。在这种情况下，将会根据待减少的候选交汇点连接数执行特定过程。这是默认设置。</para>
			/// </summary>
			[GPValue("MAX_2_CONNECTED_JUNCTIONS")]
			[Description("最多两个连接交汇点")]
			Maximum_two_connected_junctions,

			/// <summary>
			/// <para>最少三个连接交汇点—将考虑具有三个或更多连接的交汇点。在这种情况下，将执行上游追踪以确定是否减少候选交汇点连接。</para>
			/// </summary>
			[GPValue("MIN_3_CONNECTED_JUNCTIONS")]
			[Description("最少三个连接交汇点")]
			Minimum_three_connected_junctions,

		}

		/// <summary>
		/// <para>Reduce if unconnected</para>
		/// </summary>
		public enum UnconnectedJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_UNCONNECTED_JCT")]
			REDUCE_UNCONNECTED_JCT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_UNCONNECTED_JCT")]
			KEEP_UNCONNECTED_JCT,

		}

		/// <summary>
		/// <para>Reduce if connected to a single junction</para>
		/// </summary>
		public enum OneConnectedJunctionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_JCT_TO_1JCT")]
			REDUCE_JCT_TO_1JCT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_JCT_TO_1JCT")]
			KEEP_JCT_TO_1JCT,

		}

		/// <summary>
		/// <para>Reduce if connected to 2 different junctions</para>
		/// </summary>
		public enum TwoConnectedJunctionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REDUCE_JCT_TO_2JCTS")]
			REDUCE_JCT_TO_2JCTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_JCT_TO_2JCTS")]
			KEEP_JCT_TO_2JCTS,

		}

#endregion
	}
}
