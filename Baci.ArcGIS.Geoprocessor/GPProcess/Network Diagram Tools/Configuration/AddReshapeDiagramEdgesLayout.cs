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
	/// <para>Add Reshape Diagram Edges Layout</para>
	/// <para>添加修整逻辑示意图边布局</para>
	/// <para>用于将“修整逻辑示意图边布局”算法添加到基于给定模板构建逻辑示意图结束时自动进行链接的布局列表。此工具还会针对基于该模板的任意逻辑示意图预设“修整逻辑示意图边布局”算法参数。</para>
	/// </summary>
	public class AddReshapeDiagramEdgesLayout : AbstractGPProcess
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
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动运行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数值生成任何逻辑示意图的过程中自动运行。 这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。 如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
		/// <para>未选中 - 如果要对基于输入模板的任何逻辑示意图运行此算法，则还将默认加载当前为添加的布局逻辑示意图指定的所有参数值。</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		public AddReshapeDiagramEdgesLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加修整逻辑示意图边布局</para>
		/// </summary>
		public override string DisplayName() => "添加修整逻辑示意图边布局";

		/// <summary>
		/// <para>Tool Name : AddReshapeDiagramEdgesLayout</para>
		/// </summary>
		public override string ToolName() => "AddReshapeDiagramEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddReshapeDiagramEdgesLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddReshapeDiagramEdgesLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved!, ReshapeType!, IsPathPreserved!, OffsetBetweenSegmentAbsolute!, BreakpointAbsolute!, ShiftBetweenEdgeAbsolute!, AngleThreshold!, OutUtilityNetwork!, OutTemplateName!, CircularArcRadius!, CircularArcPosition! };

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
		/// <para>指定是否将在基于指定模板生成逻辑示意图时自动运行布局算法。</para>
		/// <para>选中 - 添加的布局算法会在基于输入逻辑示意图模板参数值生成任何逻辑示意图的过程中自动运行。 这是默认设置。为布局算法指定的参数值是在生成逻辑示意图的过程中用于运行布局的参数值。 如果要对基于输入模板的任何逻辑示意图运行此算法，则还会默认加载这些参数值。</para>
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
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行布局算法。 这是默认设置。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Reshape Operation</para>
		/// <para>指定边的修整方法。</para>
		/// <para>移除折点—将移除逻辑示意图中的所有沿边折点。</para>
		/// <para>方边—折点将沿逻辑示意图边放置，且这些边将显示为直角。这是默认设置。</para>
		/// <para>分离重叠边—当连接相同起始和末端交汇点的边发生重叠时，将对边进行分离。</para>
		/// <para>按角度减少折点—根据关联于折点的线段之间的角度减少沿逻辑示意图边显示的部分或所有折点。</para>
		/// <para>标记交叉边—将标记出彼此相交成直角的水平和垂直逻辑示意图边并修整其几何，以在相交位置显示圆弧。</para>
		/// <para><see cref="ReshapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReshapeType { get; set; } = "SQUARE_EDGES";

		/// <summary>
		/// <para>Preserve path</para>
		/// <para>针对要组成方形的边，指定是否要保留沿这些边的折点。仅当修整操作为方边时，才能使用此参数。</para>
		/// <para>选中 - 将考虑任意边的方向，并将保留沿该边的折点（从第一个折点到最后一个折点）。这是默认设置。</para>
		/// <para>未选中 - 不会考虑沿逻辑示意图边的折点；将在执行过程中移除折点。</para>
		/// <para><see cref="IsPathPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsPathPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Offset Between Edges</para>
		/// <para>关联于相同交汇点的方边各平行线段之间的间距。默认值为 5（采用逻辑示意图坐标系的单位）。仅当修整操作为方边时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? OffsetBetweenSegmentAbsolute { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Break Point Position</para>
		/// <para>当关联于交汇点的边组成方形时，各交汇点与沿这些边的第一个或最后一个中断点之间的最大距离。默认值为 8.66（采用逻辑示意图坐标系的单位）。仅当修整操作为方边时，才能使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? BreakpointAbsolute { get; set; } = "8.66 Unknown";

		/// <summary>
		/// <para>Offset Between Edges</para>
		/// <para>两条边之间的绝对间距。默认值为 0.5（采用逻辑示意图坐标系的单位）。仅当修整操作为分离重叠边时，才能使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ShiftBetweenEdgeAbsolute { get; set; } = "0.5 Unknown";

		/// <summary>
		/// <para>Angle Threshold</para>
		/// <para>由入射线段构成的角度，并根据此角度减少与这些线段相关的折点。角度越大，则将减少的折点数越少。默认值为 160 度。仅当修整操作为按角度减少折点时，才能使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AngleThreshold { get; set; } = "0";

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
		/// <para>Circular Arc Radius</para>
		/// <para>将向交叉边位置添加的圆弧的半径。默认值为 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CircularArcRadius { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Circular Arc Position</para>
		/// <para>指定将放置圆弧的线段。</para>
		/// <para>垂直线段左侧—圆弧将放置在垂直线段左侧。</para>
		/// <para>垂直线段右侧—圆弧将放置在垂直线段右侧。</para>
		/// <para>水平线段上方—圆弧将放置在水平线段上方。</para>
		/// <para>水平线段下方—圆弧将放置在水平线段下方。</para>
		/// <para><see cref="CircularArcPositionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CircularArcPosition { get; set; } = "RIGHT_OF_VERTICAL_SEGMENT";

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
		/// <para>Reshape Operation</para>
		/// </summary>
		public enum ReshapeTypeEnum 
		{
			/// <summary>
			/// <para>移除折点—将移除逻辑示意图中的所有沿边折点。</para>
			/// </summary>
			[GPValue("REMOVE_VERTICES")]
			[Description("移除折点")]
			Remove_vertices,

			/// <summary>
			/// <para>方边—折点将沿逻辑示意图边放置，且这些边将显示为直角。这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE_EDGES")]
			[Description("方边")]
			Square_edges,

			/// <summary>
			/// <para>分离重叠边—当连接相同起始和末端交汇点的边发生重叠时，将对边进行分离。</para>
			/// </summary>
			[GPValue("SEPARATE_OVERLAPPING_EDGES")]
			[Description("分离重叠边")]
			Separate_overlapping_edges,

			/// <summary>
			/// <para>按角度减少折点—根据关联于折点的线段之间的角度减少沿逻辑示意图边显示的部分或所有折点。</para>
			/// </summary>
			[GPValue("REDUCE_VERTICES_BY_ANGLE")]
			[Description("按角度减少折点")]
			Reduce_vertices_by_angle,

			/// <summary>
			/// <para>标记交叉边—将标记出彼此相交成直角的水平和垂直逻辑示意图边并修整其几何，以在相交位置显示圆弧。</para>
			/// </summary>
			[GPValue("MARK_CROSSING_EDGES")]
			[Description("标记交叉边")]
			Mark_crossing_edges,

		}

		/// <summary>
		/// <para>Preserve path</para>
		/// </summary>
		public enum IsPathPreservedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_PATH")]
			PRESERVE_PATH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_PATH")]
			IGNORE_PATH,

		}

		/// <summary>
		/// <para>Circular Arc Position</para>
		/// </summary>
		public enum CircularArcPositionEnum 
		{
			/// <summary>
			/// <para>垂直线段左侧—圆弧将放置在垂直线段左侧。</para>
			/// </summary>
			[GPValue("LEFT_OF_VERTICAL_SEGMENT")]
			[Description("垂直线段左侧")]
			Left_of_vertical_segment,

			/// <summary>
			/// <para>垂直线段右侧—圆弧将放置在垂直线段右侧。</para>
			/// </summary>
			[GPValue("RIGHT_OF_VERTICAL_SEGMENT")]
			[Description("垂直线段右侧")]
			Right_of_vertical_segment,

			/// <summary>
			/// <para>水平线段上方—圆弧将放置在水平线段上方。</para>
			/// </summary>
			[GPValue("ABOVE_HORIZONTAL_SEGMENT")]
			[Description("水平线段上方")]
			Above_horizontal_segment,

			/// <summary>
			/// <para>水平线段下方—圆弧将放置在水平线段下方。</para>
			/// </summary>
			[GPValue("BELOW_HORIZONTAL_SEGMENT")]
			[Description("水平线段下方")]
			Below_horizontal_segment,

		}

#endregion
	}
}
