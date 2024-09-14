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
	/// <para>Apply Mainline Tree Layout</para>
	/// <para>应用主线树布局</para>
	/// <para>用于沿主线按等级排列逻辑示意图交汇点和边。</para>
	/// </summary>
	public class ApplyMainlineTreeLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyMainlineTreeLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用主线树布局</para>
		/// </summary>
		public override string DisplayName() => "应用主线树布局";

		/// <summary>
		/// <para>Tool Name : ApplyMainlineTreeLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyMainlineTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyMainlineTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyMainlineTreeLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, TreeDirection!, BranchesPlacement!, IsUnitAbsolute!, PerpendicularAbsolute!, PerpendicularProportional!, AlongAbsolute!, AlongProportional!, DisjoinedGraphAbsolute!, DisjoinedGraphProportional!, AreEdgesOrthogonal!, BreakpointPosition!, OutNetworkDiagramLayer!, EdgeDisplayType!, RunAsync!, OffsetAbsolute!, OffsetProportional! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>指定算法将如何处理容器。</para>
		/// <para>选中 - 将对逻辑示意图的上方图执行布局算法，以保留容器。</para>
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行布局算法。 这是默认设置。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Tree Direction</para>
		/// <para>指定主线的方向。</para>
		/// <para>从左到右—主线将绘制为从左侧开始并于右侧终止的水平线。这是默认设置。</para>
		/// <para>从右到左—主线将绘制为从右侧开始并于左侧终止的水平线。</para>
		/// <para>从下到上—主线将绘制为从底部开始并于顶部终止的垂直线。</para>
		/// <para>从上到下—主线将绘制为从顶部开始并于底部终止的垂直线。</para>
		/// <para><see cref="TreeDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TreeDirection { get; set; } = "FROM_LEFT_TO_RIGHT";

		/// <summary>
		/// <para>Branches Placement</para>
		/// <para>用于指定将如何针对主线分支的方向来相对放置主线分支。</para>
		/// <para>两侧—分支将放置在主线的左右两侧。这是默认设置。</para>
		/// <para>左侧—分支将只能放置在主线的左侧。</para>
		/// <para>右侧—分支将只能放置在主线的右侧。</para>
		/// <para><see cref="BranchesPlacementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BranchesPlacement { get; set; } = "BOTH_SIDES";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para>指定将如何解释表示距离的参数。</para>
		/// <para>选中 - 布局算法会按线性单位来解释任意距离值。</para>
		/// <para>未选中 - 布局算法会将所有距离值解释为当前逻辑示意图范围内交汇点大小的估算平均值的相对单位。 这是默认设置。</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// <para>沿垂直于主线的轴显示的逻辑示意图交汇点之间的间距。默认值为 2（采用逻辑示意图坐标系）。此参数只能与绝对单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? PerpendicularAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// <para>沿垂直于主线的轴显示的逻辑示意图交汇点之间的间距。默认值为 2。此参数只能与比例单位搭配使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PerpendicularProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// <para>沿主线显示的逻辑示意图交汇点之间的间距以及沿平行于此主线的轴显示的逻辑示意图交汇点之间的间距。此参数只能与绝对单位搭配使用。默认值为 2（采用逻辑示意图坐标系的单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? AlongAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// <para>沿主线显示的逻辑示意图交汇点之间的间距以及沿平行于此主线的轴显示的逻辑示意图交汇点之间的间距。此参数与比例单位搭配使用。默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AlongProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>当逻辑示意图包含不相交图形时，属于此类图形的要素之间的最小间距。 此参数与绝对单位搭配使用。 默认值为逻辑示意图坐标系中的 4 个单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? DisjoinedGraphAbsolute { get; set; } = "4 Unknown";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>当逻辑示意图包含不相交图形时，属于此类图形的要素之间的最小间距。 此参数与比例单位搭配使用。 默认值为 4。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? DisjoinedGraphProportional { get; set; } = "4";

		/// <summary>
		/// <para>Orthogonally display edges</para>
		/// <para>指定将如何显示与树分支相关的逻辑示意图边。此参数已在 ArcGIS Pro 3.0 中弃用。 如果指定了 edge_display_type 参数，则无论其值是多少，都会被系统忽略。 但是，为了保持与 ArcGIS Pro 2.1 的兼容性，如果未指定 edge_display_type 参数，则其将保持启用状态。</para>
		/// <para>ORTHOGONAL_EDGES—与树分支相关的所有逻辑示意图边将显示为直角。</para>
		/// <para>SLANTED_EDGES—与树分支相关的所有逻辑示意图边将不会显示为直角。 这是默认设置。</para>
		/// <para><see cref="AreEdgesOrthogonalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreEdgesOrthogonal { get; set; } = "false";

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// <para>当边显示类型设置为规则边（在 Python 中为 edge_display_type = &quot;REGULAR_EDGES&quot;）或边显示类型设置为正交边（在 Python 中为 edge_display_type = &quot;ORTHOGONAL_EDGES&quot;）时，将沿逻辑示意图边插入的中断点的相对位置。 以 0 至 100 之间的百分比来表示。</para>
		/// <para>当中断点相对位置 (%) 的值为 0 时，中断点位于边的自交汇点的 x 坐标，以及水平树边的至交汇点的 y 坐标。 中断点位于边的自交汇点的 y 坐标，以及垂直树边的至交汇点的 x 坐标。</para>
		/// <para>当中断点相对位置 (%) 的值为 100 时，即表示未在逻辑示意图边上插入任何中断点；每条逻辑示意图边直接连接其自和至交汇点。</para>
		/// <para>当中断点相对位置 (%) 的值为介于 0 至 100 之间的 N 时，中断点位于 [XY] 线段长度的 N%，其中 X 表示边的自交汇点的 x 坐标，Y 表示水平树边的至交汇点的 y 坐标。 中断点位于 [YX] 线段长度的 N%，其中 Y 表示边的自交汇点的 y 坐标，X 表示垂直树边的至交汇点的 x 坐标。</para>
		/// <para>当边显示类型设置为弯曲边（在 Python 中为 edge_display_type = &quot;CURVED_EDGES&quot;）时，将沿逻辑示意图边插入、用于计算弯曲边几何的两个拐点的相对位置。 以 15 至 40 之间的百分比来表示。 如果中断点相对位置 (%) 值为介于 15 至 40 之间的 N：</para>
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
		public object? BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para>指定与树分支相关的逻辑示意图边的显示类型。</para>
		/// <para>规则边—与树分支相关的所有逻辑示意图边将不会显示为直角。 这是默认设置。</para>
		/// <para>正交边—与树分支相关的所有逻辑示意图边将显示为直角。</para>
		/// <para>弯曲边—与树分支相关的所有逻辑示意图边将显示为曲线。</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EdgeDisplayType { get; set; } = "REGULAR_EDGES";

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>指定布局算法在服务器上将异步运行还是同步运行。</para>
		/// <para>选中 - 布局算法将在服务器上异步运行。 服务器资源可通过该选项来运行超时较长的布局算法。 当执行耗时且可能导致服务器超时的布局（例如，部分重叠边）并应用于大型逻辑示意图（超过 25,000 个要素）时，建议进行异步运行。</para>
		/// <para>未选中 - 布局算法将在服务器上同步运行。 如果执行时超过服务默认超时值（600 秒），则布局算法可能失败，无法完成。 这是默认设置。</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? RunAsync { get; set; } = "false";

		/// <summary>
		/// <para>Absolute Offset</para>
		/// <para>在使用绝对单位，并且边显示类型设置为正交边时，将使用此偏移分隔重叠线段。 该值不能超过为其他间距参数指定的最小值的 10%。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? OffsetAbsolute { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Proportional Offset</para>
		/// <para>在使用比例单位，并且边显示类型设置为正交边时，将使用此偏移分隔重叠线段。 它是一个双精度值，不能超过为其他间距参数指定的最小值的 10%。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? OffsetProportional { get; set; } = "0";

		#region InnerClass

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
		/// <para>Tree Direction</para>
		/// </summary>
		public enum TreeDirectionEnum 
		{
			/// <summary>
			/// <para>从左到右—主线将绘制为从左侧开始并于右侧终止的水平线。这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_LEFT_TO_RIGHT")]
			[Description("从左到右")]
			From_left_to_right,

			/// <summary>
			/// <para>从右到左—主线将绘制为从右侧开始并于左侧终止的水平线。</para>
			/// </summary>
			[GPValue("FROM_RIGHT_TO_LEFT")]
			[Description("从右到左")]
			From_right_to_left,

			/// <summary>
			/// <para>从下到上—主线将绘制为从底部开始并于顶部终止的垂直线。</para>
			/// </summary>
			[GPValue("FROM_BOTTOM_TO_TOP")]
			[Description("从下到上")]
			From_bottom_to_top,

			/// <summary>
			/// <para>从上到下—主线将绘制为从顶部开始并于底部终止的垂直线。</para>
			/// </summary>
			[GPValue("FROM_TOP_TO_BOTTOM")]
			[Description("从上到下")]
			From_top_to_bottom,

		}

		/// <summary>
		/// <para>Branches Placement</para>
		/// </summary>
		public enum BranchesPlacementEnum 
		{
			/// <summary>
			/// <para>两侧—分支将放置在主线的左右两侧。这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_SIDES")]
			[Description("两侧")]
			Both_sides,

			/// <summary>
			/// <para>左侧—分支将只能放置在主线的左侧。</para>
			/// </summary>
			[GPValue("LEFT_SIDE")]
			[Description("左侧")]
			Left_side,

			/// <summary>
			/// <para>右侧—分支将只能放置在主线的右侧。</para>
			/// </summary>
			[GPValue("RIGHT_SIDE")]
			[Description("右侧")]
			Right_side,

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
		/// <para>Orthogonally display edges</para>
		/// </summary>
		public enum AreEdgesOrthogonalEnum 
		{
			/// <summary>
			/// <para>ORTHOGONAL_EDGES—与树分支相关的所有逻辑示意图边将显示为直角。</para>
			/// </summary>
			[GPValue("true")]
			[Description("ORTHOGONAL_EDGES")]
			ORTHOGONAL_EDGES,

			/// <summary>
			/// <para>SLANTED_EDGES—与树分支相关的所有逻辑示意图边将不会显示为直角。 这是默认设置。</para>
			/// </summary>
			[GPValue("false")]
			[Description("SLANTED_EDGES")]
			SLANTED_EDGES,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para>规则边—与树分支相关的所有逻辑示意图边将不会显示为直角。 这是默认设置。</para>
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

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

#endregion
	}
}
