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
	/// <para>Apply Linear Dispatch Layout</para>
	/// <para>应用线性分派布局</para>
	/// <para>在视觉上过于接近、重叠或重合的逻辑示意图交汇点之间添加空间。</para>
	/// </summary>
	public class ApplyLinearDispatchLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyLinearDispatchLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用线性分派布局</para>
		/// </summary>
		public override string DisplayName() => "应用线性分派布局";

		/// <summary>
		/// <para>Tool Name : ApplyLinearDispatchLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyLinearDispatchLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyLinearDispatchLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyLinearDispatchLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, JunctionPlacementType, IsUnitAbsolute, MaximumShiftAbsolute, MaximumShiftProportional, MinimumShiftAbsolute, MinimumShiftProportional, IterationsNumber, IsPathPreserved, AreLeavesMoved, AreLeavesExpanded, ExpandShiftAbsolute, ExpandShiftProportional, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Junctions Placement</para>
		/// <para>指定交汇点的移动方式。</para>
		/// <para>等距—所有具有两条连接边的交汇点将移动，以使其之间的距离以及其两个连接交汇点相同。这是默认设置。</para>
		/// <para>用户定义距离—所有具有两条连接边的交汇点将移动，以使其与其连接的边的另一端之间为最小距离（最小平移参数值）。这发生在布局执行结束时。</para>
		/// <para>迭代距离—所有具有两个连接边的交汇点将根据迭代次数和最大平移参数值稍稍移动。</para>
		/// <para><see cref="JunctionPlacementTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JunctionPlacementType { get; set; } = "EQUAL_DISTANCE";

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
		/// <para>Maximum Shift</para>
		/// <para>具有两个连接的交汇点与其连接的交汇点间隔的最大距离。默认值为 2（采用逻辑示意图坐标系的单位）。达到此距离后，后续迭代过程中将不再移动交汇点。此参数只能与迭代距离交汇点放置类型和绝对单位一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaximumShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Maximum Shift</para>
		/// <para>具有两个连接的交汇点与其连接的交汇点间隔的最大距离。默认值为 2。达到此距离后，后续迭代过程中将不再移动交汇点。此参数只能与迭代距离交汇点放置类型和比例单位一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Minimum Shift</para>
		/// <para>布局执行后，对于每个具有两个连接边的交汇点，从其两个边端点对其进行分隔的最小距离。默认值为 2（采用逻辑示意图坐标系的单位）。如果此参数值过大，则将移动具有两个连接的交汇点，以使每个移动后的交汇点在沿其两个连接边所定义的路径上与其边端点之间的距离相等。此参数只能与用户定义距离交汇点放置类型和绝对单位一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinimumShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Minimum Shift</para>
		/// <para>布局执行后，对于每个具有两个连接边的交汇点，确定从其两个边端点对其进行分隔的最小距离。默认值为 2。如果此参数值过大，则将移动具有两个连接的交汇点，以使每个移动后的交汇点在沿其两个连接边所定义的路径上与其边端点之间的距离相等。此参数将与用户定义距离交汇点放置类型和比例单位一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinimumShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// <para>要处理的迭代次数。默认值为 5。此参数只能与迭代距离交汇点放置类型一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object IterationsNumber { get; set; } = "5";

		/// <summary>
		/// <para>Preserve path</para>
		/// <para>指定如何对沿边的折点进行处理。</para>
		/// <para>选中 - 将保留所有沿已连接边的折点，并将在已移动交汇点的原始位置处添加新折点。这是默认设置。</para>
		/// <para>未选中 - 将不保留沿边的折点。</para>
		/// <para><see cref="IsPathPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsPathPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Move leaves</para>
		/// <para>指定在算法执行过程中是否移动叶交汇点（包含一个连接的交汇点）。</para>
		/// <para>选中 - 将移动叶交汇点。</para>
		/// <para>未选中 - 将不移动叶交汇点。这是默认设置，除非指定的输入网络逻辑示意图基于相应模板，通过另一参数值对该模板的线性分派布局算法进行了配置。</para>
		/// <para><see cref="AreLeavesMovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreLeavesMoved { get; set; } = "false";

		/// <summary>
		/// <para>Expand leaves</para>
		/// <para>指定是否展开叶交汇点。</para>
		/// <para>选中 - 将展开叶交汇点。最大展开平移参数值指定可以在叶交汇点与其连接的交汇点之间展开的最大距离。</para>
		/// <para>未选中 - 不会展开叶交汇点。这是默认设置，除非指定的输入网络逻辑示意图基于相应模板，通过另一参数值对该模板的线性分派布局算法进行了配置。</para>
		/// <para><see cref="AreLeavesExpandedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreLeavesExpanded { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Expand Shift</para>
		/// <para>必须在叶交汇点与其连接的交汇点之间展开的最大距离。默认值为 2（采用逻辑示意图坐标系的单位），除非指定的输入网络逻辑示意图基于相应模板，通过另一参数值对该模板的线性分派布局算法进行了配置。达到此距离后，后续迭代过程中将不再移动叶交汇点。此参数只能与展开叶参数和绝对单位一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ExpandShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Maximum Expand Shift</para>
		/// <para>必须在叶交汇点与其连接的交汇点之间展开的最大距离。默认值为 2，除非指定的输入网络逻辑示意图基于相应模板，通过另一参数值对该模板的线性分派布局算法进行了配置。达到此距离后，后续迭代过程中将不再移动叶交汇点。此参数只能与展开叶参数和比例单位一起使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ExpandShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>指定布局算法在服务器上将异步运行还是同步运行。</para>
		/// <para>选中 - 布局算法将在服务器上异步运行。服务器资源可通过该选项来运行超时较长的布局算法。当执行耗时且可能导致服务器超时的布局（例如，部分重叠边）并应用于大型逻辑示意图（超过 25,000 个要素）时，建议进行异步运行。</para>
		/// <para>未选中 - 布局算法将在服务器上同步运行。如果执行时超过服务超时值（默认为 600 秒），则布局算法可能失败，无法完成。这是默认设置。</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object RunAsync { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Junctions Placement</para>
		/// </summary>
		public enum JunctionPlacementTypeEnum 
		{
			/// <summary>
			/// <para>等距—所有具有两条连接边的交汇点将移动，以使其之间的距离以及其两个连接交汇点相同。这是默认设置。</para>
			/// </summary>
			[GPValue("EQUAL_DISTANCE")]
			[Description("等距")]
			Equal_distance,

			/// <summary>
			/// <para>用户定义距离—所有具有两条连接边的交汇点将移动，以使其与其连接的边的另一端之间为最小距离（最小平移参数值）。这发生在布局执行结束时。</para>
			/// </summary>
			[GPValue("USER_DEFINE_DISTANCE")]
			[Description("用户定义距离")]
			User_define_distance,

			/// <summary>
			/// <para>迭代距离—所有具有两个连接边的交汇点将根据迭代次数和最大平移参数值稍稍移动。</para>
			/// </summary>
			[GPValue("ITERATIVE_DISTANCE")]
			[Description("迭代距离")]
			Iterative_distance,

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
		/// <para>Move leaves</para>
		/// </summary>
		public enum AreLeavesMovedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MOVE_LEAVES")]
			MOVE_LEAVES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_MOVE_LEAVES")]
			DO_NOT_MOVE_LEAVES,

		}

		/// <summary>
		/// <para>Expand leaves</para>
		/// </summary>
		public enum AreLeavesExpandedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPAND_LEAVES")]
			EXPAND_LEAVES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EXPAND_LEAVES")]
			DO_NOT_EXPAND_LEAVES,

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
