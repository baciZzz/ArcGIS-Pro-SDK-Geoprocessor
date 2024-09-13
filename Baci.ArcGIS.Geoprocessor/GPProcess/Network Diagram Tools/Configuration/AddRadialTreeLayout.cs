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
	/// <para>Add Radial Tree Layout</para>
	/// <para>添加径向树布局</para>
	/// <para>用于将“径向树布局”算法添加到基于给定模板构建逻辑示意图结束时自动进行链接的布局列表。此工具还会针对基于该模板的任意逻辑示意图预设“径向树布局”算法参数。</para>
	/// </summary>
	public class AddRadialTreeLayout : AbstractGPProcess
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
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动执行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数生成任何逻辑示意图的过程中自动运行。这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		public AddRadialTreeLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加径向树布局</para>
		/// </summary>
		public override string DisplayName() => "添加径向树布局";

		/// <summary>
		/// <para>Tool Name : AddRadialTreeLayout</para>
		/// </summary>
		public override string ToolName() => "AddRadialTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddRadialTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddRadialTreeLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved, IsUnitAbsolute, InitialRadiusAbsolute, InitialRadiusProportional, DisjoinedGraphAbsolute, DisjoinedGraphProportional, RadiusFactor, OutUtilityNetwork, OutTemplateName };

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
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动执行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数生成任何逻辑示意图的过程中自动运行。这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>指定算法将如何处理容器。</para>
		/// <para>选中 - 将对逻辑示意图的上方图执行布局算法，以保留容器。</para>
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行布局算法。这是默认设置。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para>指定将如何解释表示距离的参数。</para>
		/// <para>选中 - 布局算法会按线性单位来解释任意距离值。</para>
		/// <para>未选中 - 布局算法会将所有距离值解释为当前逻辑示意图范围内交汇点大小的估算平均值的相对单位。这是默认设置。</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Initial Radius</para>
		/// <para>圆心为径向树根交汇点的第一个同心圆的半径；即，放置属于第一个级别的逻辑示意图交汇点的圆的半径。默认值为 5（采用逻辑示意图坐标系的单位）。此参数只能与绝对单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object InitialRadiusAbsolute { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Initial Radius</para>
		/// <para>圆心为径向树根交汇点的第一个同心圆的半径；即，放置属于第一个级别的逻辑示意图交汇点的圆的半径。默认值为 5。此参数只能与比例单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object InitialRadiusProportional { get; set; } = "5";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>当逻辑示意图包含不相交图形时，属于此类图形的要素之间的最小间距。此参数与绝对单位搭配使用。默认值为 4（采用逻辑示意图坐标系的单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object DisjoinedGraphAbsolute { get; set; } = "10 Unknown";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>当逻辑示意图包含不相交图形时，属于此类图形的要素之间的最小间距。此参数与比例单位搭配使用。默认值为 4。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DisjoinedGraphProportional { get; set; } = "10";

		/// <summary>
		/// <para>Radius Factor</para>
		/// <para>用来增大或减小每个同心圆半径的倍乘系数。还表示分隔各级别同心圆的距离。如果使用的半径系数小于 1，则用来分隔级别 (n) 与级别 (n+1) 逻辑示意图交汇点的距离会逐渐减小。如果该系数大于 1，则不同级别间的距离会逐渐增大。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RadiusFactor { get; set; } = "1";

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
		/// <para>Preserve container layout</para>
		/// </summary>
		public enum AreContainersPreservedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// </summary>
		public enum IsUnitAbsoluteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ABSOLUTE_UNIT")]
			ABSOLUTE_UNIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PROPORTIONAL_UNIT")]
			PROPORTIONAL_UNIT,

		}

#endregion
	}
}
