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
	/// <para>Spaces out collinear edges or collinear portions of edges (edge segments) inside a given buffer zone.</para>
	/// </summary>
	public class ApplyPartialOverlappingEdgesLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		/// <param name="BufferWidthAbsolute">
		/// <para>Buffer Width</para>
		/// <para>The width of the buffer zone in which to search for collinear edge segments.</para>
		/// </param>
		/// <param name="OffsetAbsolute">
		/// <para>Offset</para>
		/// <para>The distance that will separate the detected edge segments.</para>
		/// </param>
		public ApplyPartialOverlappingEdgesLayout(object InNetworkDiagramLayer, object BufferWidthAbsolute, object OffsetAbsolute)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.BufferWidthAbsolute = BufferWidthAbsolute;
			this.OffsetAbsolute = OffsetAbsolute;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Partial Overlapping Edges Layout</para>
		/// </summary>
		public override string DisplayName => "Apply Partial Overlapping Edges Layout";

		/// <summary>
		/// <para>Tool Name : ApplyPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ToolName => "ApplyPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ExcuteName => "nd.ApplyPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkDiagramLayer, BufferWidthAbsolute, OffsetAbsolute, OptimizeEdges!, OutNetworkDiagramLayer!, RunAsync! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Buffer Width</para>
		/// <para>The width of the buffer zone in which to search for collinear edge segments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BufferWidthAbsolute { get; set; }

		/// <summary>
		/// <para>Offset</para>
		/// <para>The distance that will separate the detected edge segments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; }

		/// <summary>
		/// <para>Optimize edges</para>
		/// <para>Specifies how segments will be placed along edges:</para>
		/// <para>Checked—The placement of segments will be optimized in each set of collinear segments. This is done by focusing on their connections instead of their positions. Segments that cross each other can be repositioned so they do not cross.</para>
		/// <para>Unchecked—The initial position of each segment will be maintained in the collinear segment set and crossings will be preserved. This is the default.</para>
		/// <para><see cref="OptimizeEdgesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OptimizeEdges { get; set; } = "false";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>Specifies whether the layout algorithm will run asynchronously or synchronously on the server.</para>
		/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out (for example, Partial Overlapping Edges) and applying to large diagrams (more than 25,000 features).</para>
		/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service default time-out value of 600 seconds. This is the default.</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? RunAsync { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Optimize edges</para>
		/// </summary>
		public enum OptimizeEdgesEnum 
		{
			/// <summary>
			/// <para>Checked—The placement of segments will be optimized in each set of collinear segments. This is done by focusing on their connections instead of their positions. Segments that cross each other can be repositioned so they do not cross.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OPTIMIZE_EDGES")]
			OPTIMIZE_EDGES,

			/// <summary>
			/// <para>Unchecked—The initial position of each segment will be maintained in the collinear segment set and crossings will be preserved. This is the default.</para>
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
			/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out (for example, Partial Overlapping Edges) and applying to large diagrams (more than 25,000 features).</para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service default time-out value of 600 seconds. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

#endregion
	}
}
