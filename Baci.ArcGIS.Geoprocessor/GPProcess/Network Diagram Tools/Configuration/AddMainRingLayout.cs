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
	/// <para>Add Main Ring Layout</para>
	/// <para>添加主环布局</para>
	/// <para>用于将“主环布局”算法添加到基于给定模板构建逻辑示意图结束时自动进行链接的布局列表。此工具还会针对基于该模板的任意逻辑示意图预设“主环布局”算法参数。</para>
	/// </summary>
	public class AddMainRingLayout : AbstractGPProcess
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
		public AddMainRingLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加主环布局</para>
		/// </summary>
		public override string DisplayName() => "添加主环布局";

		/// <summary>
		/// <para>Tool Name : AddMainRingLayout</para>
		/// </summary>
		public override string ToolName() => "AddMainRingLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddMainRingLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddMainRingLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved, RingType, IsUnitAbsolute, RingWidthAbsolute, RingWidthProportional, RingHeightAbsolute, RingHeightProportional, TreeType, PerpendicularAbsolute, PerpendicularProportional, AlongAbsolute, AlongProportional, BreakpointPosition, EdgeDisplayType, OutUtilityNetwork, OutTemplateName, OffsetAbsolute, OffsetProportional };

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
		/// <para>Ring Type</para>
		/// <para>指定环的类型。</para>
		/// <para>椭圆形—检测到的主环的逻辑示意图要素将沿椭圆显示。这是默认设置。</para>
		/// <para>矩形—检测到的主环的逻辑示意图要素将沿矩形显示。</para>
		/// <para><see cref="RingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RingType { get; set; } = "ELLIPSE";

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
		/// <para>Ring Width</para>
		/// <para>环的宽度。默认值为逻辑示意图坐标系中的单位。此参数只能与绝对单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object RingWidthAbsolute { get; set; } = "50 Unknown";

		/// <summary>
		/// <para>Ring Width</para>
		/// <para>环的宽度。默认值为 50。此参数只能与比例单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RingWidthProportional { get; set; } = "50";

		/// <summary>
		/// <para>Ring Height</para>
		/// <para>环的高度。默认值为逻辑示意图坐标系中的单位。此参数只能与绝对单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object RingHeightAbsolute { get; set; } = "20 Unknown";

		/// <summary>
		/// <para>Ring Height</para>
		/// <para>环的高度。默认值为 20。此参数只能与比例单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RingHeightProportional { get; set; } = "20";

		/// <summary>
		/// <para>Hierarchical Tree Type</para>
		/// <para>用于指定如何定位来自主环交汇点的树。</para>
		/// <para>主线树的两侧—将沿主线显示每棵树，并将其相关分支排列在此主线的左右两侧。</para>
		/// <para>主线树的左侧—将沿主线按等级显示每棵树，并将其相关分支排列在此主线的左侧。</para>
		/// <para>主线树的右侧—将沿主线按等级显示每棵树，并将其相关分支排列在此主线的右侧。</para>
		/// <para>智能树—将以智能树的形式按等级显示每棵树。这是默认设置。</para>
		/// <para><see cref="TreeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TreeType { get; set; } = "SMART_TREE";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// <para>垂直于树方向显示并且属于相同子树级别的逻辑示意图交汇点之间的间距。默认值为 2（采用逻辑示意图坐标系的单位）。此参数只能与绝对单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PerpendicularAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// <para>垂直于树方向显示并且属于相同子树级别的逻辑示意图交汇点之间的间距。默认值为 2。此参数只能与比例单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PerpendicularProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// <para>沿树方向显示的逻辑示意图交汇点之间的间距。默认值为 2（采用逻辑示意图坐标系的单位）。此参数只能与绝对单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object AlongAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// <para>沿树方向显示的逻辑示意图交汇点之间的间距。默认值为 2。此参数只能与比例单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AlongProportional { get; set; } = "2";

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// <para>当边显示类型为规则边（在 Python 中为 edge_display_type = &quot;REGULAR_EDGES&quot;）或边显示类型为正交边（在 Python 中为 edge_display_type = &quot;ORTHOGONAL_EDGES&quot;）时，将沿逻辑示意图边插入的中断点的相对位置。以 0 至 100 之间的百分比来表示。</para>
		/// <para>当中断点相对位置 (%) 的值为 0 时，中断点位于边的自交汇点的 x 坐标，以及水平树边的至交汇点的 y 坐标。中断点位于边的自交汇点的 y 坐标，以及垂直树边的至交汇点的 x 坐标。</para>
		/// <para>当中断点相对位置 (%) 的值为 100 时，即表示未在逻辑示意图边上插入任何中断点；每条逻辑示意图边直接连接其自和至交汇点。</para>
		/// <para>当中断点相对位置 (%) 的值为介于 0 至 100 之间的 N 时，中断点位于 [XY] 线段长度的 N%，其中 X 表示边的自交汇点的 x 坐标，Y 表示水平树边的至交汇点的 y 坐标。中断点位于 [YX] 线段长度的 N%，其中 Y 表示边的自交汇点的 y 坐标，X 表示垂直树边的至交汇点的 x 坐标。</para>
		/// <para>当边显示类型为弯曲边（在 Python 中为 edge_display_type = &quot;CURVED_EDGES&quot;）时，将沿逻辑示意图边插入、用于计算弯曲边几何的两个拐点的相对位置。以 15 至 40 之间的百分比来表示。如果中断点相对位置 (%) 值为介于 15 至 40 之间的 N：</para>
		/// <para>X 为边的自交汇点的 x 坐标，Y 为水平树边的至交汇点的 y 坐标：</para>
		/// <para>第一个拐点将定位在 [XY] 线段长度的 N％。</para>
		/// <para>第二个拐点将定位在 [XY] 线段长度的 (100 - N)％。</para>
		/// <para>Y 为边的自交汇点的 y 坐标，X 为垂直树边的至交汇点的 x 坐标：</para>
		/// <para>第一个拐点将定位在 [YX] 线段长度的 N％。</para>
		/// <para>第二个拐点将定位在 [XY] 线段长度的 (100 - N)％。</para>
		/// <para>上述自和至交汇点的概念与树方向相关；它与网络中的边要素或边对象的真实拓扑无关。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para>指定与树分支相关的逻辑示意图边的显示类型。</para>
		/// <para>规则边—与树分支相关的所有逻辑示意图边将不会显示为直角。这是默认设置。</para>
		/// <para>正交边—与树分支相关的所有逻辑示意图边将显示为直角。</para>
		/// <para>弯曲边—与树分支相关的所有逻辑示意图边将显示为曲线。</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeDisplayType { get; set; } = "REGULAR_EDGES";

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
		/// <para>Absolute Offset</para>
		/// <para>此偏移用于在使用绝对单位和边显示类型为正交边时分隔重叠线段。该值不能超过为其他间距参数指定的最小值的 10%。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Proportional Offset</para>
		/// <para>此偏移用于在使用比例单位和边显示类型为正交边时分隔重叠线段。它是一个双精度值，不能超过为其他间距参数指定的最小值的 10%。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object OffsetProportional { get; set; } = "0";

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
		/// <para>Ring Type</para>
		/// </summary>
		public enum RingTypeEnum 
		{
			/// <summary>
			/// <para>椭圆形—检测到的主环的逻辑示意图要素将沿椭圆显示。这是默认设置。</para>
			/// </summary>
			[GPValue("ELLIPSE")]
			[Description("椭圆形")]
			Ellipse,

			/// <summary>
			/// <para>矩形—检测到的主环的逻辑示意图要素将沿矩形显示。</para>
			/// </summary>
			[GPValue("RECTANGLE")]
			[Description("矩形")]
			Rectangle,

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

		/// <summary>
		/// <para>Hierarchical Tree Type</para>
		/// </summary>
		public enum TreeTypeEnum 
		{
			/// <summary>
			/// <para>主线树的两侧—将沿主线显示每棵树，并将其相关分支排列在此主线的左右两侧。</para>
			/// </summary>
			[GPValue("BOTH_SIDES")]
			[Description("主线树的两侧")]
			Both_sides_of_main_line_tree,

			/// <summary>
			/// <para>主线树的左侧—将沿主线按等级显示每棵树，并将其相关分支排列在此主线的左侧。</para>
			/// </summary>
			[GPValue("LEFT_SIDE")]
			[Description("主线树的左侧")]
			Left_side_of_main_line_tree,

			/// <summary>
			/// <para>主线树的右侧—将沿主线按等级显示每棵树，并将其相关分支排列在此主线的右侧。</para>
			/// </summary>
			[GPValue("RIGHT_SIDE")]
			[Description("主线树的右侧")]
			Right_side_of_main_line_tree,

			/// <summary>
			/// <para>智能树—将以智能树的形式按等级显示每棵树。这是默认设置。</para>
			/// </summary>
			[GPValue("SMART_TREE")]
			[Description("智能树")]
			Smart_tree,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para>规则边—与树分支相关的所有逻辑示意图边将不会显示为直角。这是默认设置。</para>
			/// </summary>
			[GPValue("REGULAR_EDGES")]
			[Description("规则边")]
			Regular_edges,

			/// <summary>
			/// <para>正交边—与树分支相关的所有逻辑示意图边将显示为直角。</para>
			/// </summary>
			[GPValue("ORTHOGONAL_EDGES")]
			[Description("正交边")]
			Orthogonal_edges,

			/// <summary>
			/// <para>弯曲边—与树分支相关的所有逻辑示意图边将显示为曲线。</para>
			/// </summary>
			[GPValue("CURVED_EDGES")]
			[Description("弯曲边")]
			Curved_edges,

		}

#endregion
	}
}
