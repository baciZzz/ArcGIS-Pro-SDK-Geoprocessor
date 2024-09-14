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
	/// <para>Apply Partial Overlapping Edges Layout</para>
	/// <para>应用部分重叠边布局</para>
	/// <para>用于分隔给定缓冲区内的共线边或边的共线部分（边段）。</para>
	/// </summary>
	public class ApplyPartialOverlappingEdgesLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </param>
		/// <param name="BufferWidthAbsolute">
		/// <para>Buffer Width</para>
		/// <para>在其中搜索共线边段的缓冲区的宽度。</para>
		/// </param>
		/// <param name="OffsetAbsolute">
		/// <para>Offset</para>
		/// <para>将分隔检测到的边段的距离。</para>
		/// </param>
		public ApplyPartialOverlappingEdgesLayout(object InNetworkDiagramLayer, object BufferWidthAbsolute, object OffsetAbsolute)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.BufferWidthAbsolute = BufferWidthAbsolute;
			this.OffsetAbsolute = OffsetAbsolute;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用部分重叠边布局</para>
		/// </summary>
		public override string DisplayName() => "应用部分重叠边布局";

		/// <summary>
		/// <para>Tool Name : ApplyPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyPartialOverlappingEdgesLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, BufferWidthAbsolute, OffsetAbsolute, OptimizeEdges, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将应用布局的网络逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Buffer Width</para>
		/// <para>在其中搜索共线边段的缓冲区的宽度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BufferWidthAbsolute { get; set; }

		/// <summary>
		/// <para>Offset</para>
		/// <para>将分隔检测到的边段的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; }

		/// <summary>
		/// <para>Optimize edges</para>
		/// <para>指定将如何沿边放置线段：</para>
		/// <para>选中 - 将在每组共线段中优化线段的放置。可通过重点关注其连接而非其位置来实现上述操作。可以重新放置彼此交叉的线段，以使其处于不交叉的状态。</para>
		/// <para>未选中 - 每个线段的初始位置将保留在共线段集中，并且将保留交叉。这是默认设置。</para>
		/// <para><see cref="OptimizeEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OptimizeEdges { get; set; } = "false";

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
		/// <para>Optimize edges</para>
		/// </summary>
		public enum OptimizeEdgesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OPTIMIZE_EDGES")]
			OPTIMIZE_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_OPTIMIZE_EDGES")]
			DO_NOT_OPTIMIZE_EDGES,

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
