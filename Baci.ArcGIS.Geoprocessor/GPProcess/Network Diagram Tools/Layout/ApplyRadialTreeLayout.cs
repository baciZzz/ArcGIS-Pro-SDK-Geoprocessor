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
	/// <para>Apply Radial Tree Layout</para>
	/// <para>应用径向树布局</para>
	/// <para>用于按等级排列逻辑示意图要素并将其置于径向树中。</para>
	/// </summary>
	public class ApplyRadialTreeLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyRadialTreeLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用径向树布局</para>
		/// </summary>
		public override string DisplayName() => "应用径向树布局";

		/// <summary>
		/// <para>Tool Name : ApplyRadialTreeLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyRadialTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyRadialTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyRadialTreeLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, IsUnitAbsolute, InitialRadiusAbsolute, InitialRadiusProportional, DisjoinedGraphAbsolute, DisjoinedGraphProportional, RadiusFactor, OutNetworkDiagramLayer, RunAsync };

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
