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
	/// <para>Apply Angle Directed Layout</para>
	/// <para>应用遵循角度布局</para>
	/// <para>用于沿指定对齐方向移动逻辑示意图的边。</para>
	/// </summary>
	public class ApplyAngleDirectedLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		public ApplyAngleDirectedLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用遵循角度布局</para>
		/// </summary>
		public override string DisplayName() => "应用遵循角度布局";

		/// <summary>
		/// <para>Tool Name : ApplyAngleDirectedLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyAngleDirectedLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyAngleDirectedLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyAngleDirectedLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, IterationsNumber!, NumberOfDirections!, OutNetworkDiagramLayer!, RunAsync! };

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
		/// <para>Number of Iterations</para>
		/// <para>要处理的迭代次数。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? IterationsNumber { get; set; } = "1";

		/// <summary>
		/// <para>Number of Directions</para>
		/// <para>对齐逻辑示意图边及其连接的交汇点将使用的方向数。</para>
		/// <para>12 个方向—将移动边，以使其逐渐接近 12 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 30 度、60 度、90 度、120 度、150 度、180 度、210 度、240 度、270 度、300 度、330 度或 360 度）。</para>
		/// <para>8 个方向—将移动边，以使其逐渐接近 8 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 45 度、90 度、135 度、180 度、225 度、270 度、315 度或 360 度）。这是默认设置。</para>
		/// <para>4 个方向—将移动边，以使其逐渐接近 4 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 90 度、180 度、270 度或 360 度）。</para>
		/// <para><see cref="NumberOfDirectionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NumberOfDirections { get; set; } = "EIGHT_DIRECTIONS";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

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
		/// <para>Number of Directions</para>
		/// </summary>
		public enum NumberOfDirectionsEnum 
		{
			/// <summary>
			/// <para>12 个方向—将移动边，以使其逐渐接近 12 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 30 度、60 度、90 度、120 度、150 度、180 度、210 度、240 度、270 度、300 度、330 度或 360 度）。</para>
			/// </summary>
			[GPValue("TWELVE_DIRECTIONS")]
			[Description("12 个方向")]
			_12_directions,

			/// <summary>
			/// <para>8 个方向—将移动边，以使其逐渐接近 8 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 45 度、90 度、135 度、180 度、225 度、270 度、315 度或 360 度）。这是默认设置。</para>
			/// </summary>
			[GPValue("EIGHT_DIRECTIONS")]
			[Description("8 个方向")]
			_8_directions,

			/// <summary>
			/// <para>4 个方向—将移动边，以使其逐渐接近 4 个轴中的一个（轴从边的起始交汇点处开始，倾斜角度分别为 90 度、180 度、270 度或 360 度）。</para>
			/// </summary>
			[GPValue("FOUR_DIRECTIONS")]
			[Description("4 个方向")]
			_4_directions,

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
