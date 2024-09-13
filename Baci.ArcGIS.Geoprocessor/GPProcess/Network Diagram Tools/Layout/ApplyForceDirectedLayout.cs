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
	/// <para>Apply Force Directed Layout</para>
	/// <para>应用力导向布局</para>
	/// <para>用于突出显示网络逻辑示意图中包含的闭合线。</para>
	/// </summary>
	public class ApplyForceDirectedLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyForceDirectedLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用力导向布局</para>
		/// </summary>
		public override string DisplayName() => "应用力导向布局";

		/// <summary>
		/// <para>Tool Name : ApplyForceDirectedLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyForceDirectedLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyForceDirectedLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyForceDirectedLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, IterationsNumber, RepelFactor, DegreeFreedom, OutNetworkDiagramLayer, BreakpointPosition, EdgeDisplayType, RunAsync };

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
		/// <para>未选中 - 将对逻辑示意图中的内容要素和非内容要素执行布局算法。这是默认设置。</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// <para>要处理的迭代次数。默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object IterationsNumber { get; set; } = "20";

		/// <summary>
		/// <para>Repel Factor</para>
		/// <para>用于在接近的逻辑示意图交汇点之间添加距离。排斥系数越大，则将在接近重叠的逻辑示意图交汇点之间添加的距离越大。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RepelFactor { get; set; } = "1";

		/// <summary>
		/// <para>Degree of Freedom</para>
		/// <para>指定每次算法迭代过程中，用于移动逻辑示意图交汇点的面积。</para>
		/// <para>低—用于移动逻辑示意图交汇点的面积将受到限制。这是默认设置。</para>
		/// <para>高—用于移动逻辑示意图交汇点的面积将比较大。</para>
		/// <para>中—用于移动逻辑示意图交汇点的面积将为中等大小。</para>
		/// <para><see cref="DegreeFreedomEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DegreeFreedom { get; set; } = "LOW";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// <para>边显示类型设置为弯曲边（Python 中的 edges_display_type = &quot;CURVED_EDGES&quot;）时，将沿逻辑示意图边插入的用于计算弯曲边几何的两个拐点的相对位置。以介于 15 和 40 之间的百分比表示；默认值为 30。例如，如果中断点相对位置 (%) 参数值为介于 15 和 40 之间的 N，则以下情况适用：</para>
		/// <para>X 为边的自交汇点的 x 坐标，Y 为水平树边的至交汇点的 y 坐标：</para>
		/// <para>第一个拐点将定位在 [XY] 线段长度的 N％</para>
		/// <para>第二个拐点将定位在 [XY] 线段长度的 (100 - N)％</para>
		/// <para>Y 为边的自交汇点的 y 坐标，X 为垂直树边的至交汇点的 x 坐标：</para>
		/// <para>第一个拐点将定位在 [YX] 线段长度的 N％</para>
		/// <para>第二个拐点将定位在 [XY] 线段长度的 (100 - N)％</para>
		/// <para>上述自交汇点和至交汇点的概念与树方向相关；与网络要素或对象边的拓扑无关。</para>
		/// <para>边显示类型参数设置为规则边（Python 中的 edges_display_type = &quot;REGULAR_EDGES&quot;）时，将忽略该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para>指定逻辑示意图边的显示类型。</para>
		/// <para>规则边—所有逻辑示意图边均显示为直线。这是默认设置。</para>
		/// <para>弯曲边—所有逻辑示意图边均显示为曲线。</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeDisplayType { get; set; } = "REGULAR_EDGES";

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
		/// <para>Degree of Freedom</para>
		/// </summary>
		public enum DegreeFreedomEnum 
		{
			/// <summary>
			/// <para>低—用于移动逻辑示意图交汇点的面积将受到限制。这是默认设置。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低")]
			Low,

			/// <summary>
			/// <para>中—用于移动逻辑示意图交汇点的面积将为中等大小。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中")]
			Medium,

			/// <summary>
			/// <para>高—用于移动逻辑示意图交汇点的面积将比较大。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高")]
			High,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para>规则边—所有逻辑示意图边均显示为直线。这是默认设置。</para>
			/// </summary>
			[GPValue("REGULAR_EDGES")]
			[Description("规则边")]
			Regular_edges,

			/// <summary>
			/// <para>弯曲边—所有逻辑示意图边均显示为曲线。</para>
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
