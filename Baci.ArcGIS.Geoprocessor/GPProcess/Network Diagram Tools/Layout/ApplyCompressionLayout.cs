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
	/// <para>Apply Compression Layout</para>
	/// <para>Compresses the diagram features toward the middle of the diagram.</para>
	/// </summary>
	public class ApplyCompressionLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplyCompressionLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Compression Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Compression Layout";

		/// <summary>
		/// <para>Tool Name : ApplyCompressionLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyCompressionLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyCompressionLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyCompressionLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, GroupingDistanceAbsolute, VerticesRemovalRule, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>Specifies how containers will be processed by the Compression layout algorithm.</para>
		/// <para>Checked—The Compression layout algorithm will execute on the top graph of the diagram so containers are preserved. This is the default.</para>
		/// <para>Unchecked—The Compression layout algorithm will execute on both content and noncontent features in the diagram.</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Distance for Grouping</para>
		/// <para>The grouping distance is used to determine whether two connected junctions are close enough to be considered part of the same junctions group. A junctions group represents many junctions that are moved as a group during execution. The group can contain both junctions and containers. To group two junctions, they must also be connected in the diagram by an edge. The default is 20 units in the diagram's coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object GroupingDistanceAbsolute { get; set; } = "20 Unknown";

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// <para>Specifies which vertices along edges in the diagram will be removed.</para>
		/// <para>All vertices—All vertices on all edges will be removed from the diagram.</para>
		/// <para>All outer vertices—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, a vertex is added at the intersection of the edge and container polygon. This is the default.</para>
		/// <para>All outer vertices except the first one—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, the first (or last) outside vertex is preserved on edges that intersect a container polygon. A vertex is automatically inserted at the intersection of the edges and container polygons.</para>
		/// <para><see cref="VerticesRemovalRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VerticesRemovalRule { get; set; } = "OUTER";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>Specifies whether the layout algorithm will run asynchronously or synchronously on the server.</para>
		/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out—for example, Partial Overlapping Edges—and applying to large diagrams—more than 25,000 features.</para>
		/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service time-out: 600 seconds by default. This is the default.</para>
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
			/// <para>Checked—The Compression layout algorithm will execute on the top graph of the diagram so containers are preserved. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para>Unchecked—The Compression layout algorithm will execute on both content and noncontent features in the diagram.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_CONTAINERS")]
			IGNORE_CONTAINERS,

		}

		/// <summary>
		/// <para>Vertex Removal Rule</para>
		/// </summary>
		public enum VerticesRemovalRuleEnum 
		{
			/// <summary>
			/// <para>All vertices—All vertices on all edges will be removed from the diagram.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All vertices")]
			All_vertices,

			/// <summary>
			/// <para>All outer vertices—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, a vertex is added at the intersection of the edge and container polygon. This is the default.</para>
			/// </summary>
			[GPValue("OUTER")]
			[Description("All outer vertices")]
			All_outer_vertices,

			/// <summary>
			/// <para>All outer vertices except the first one—Any edge vertices that are within the detected junctions&apos; groups will be maintained, while edge vertices that are outside will be removed.When there are containers in the diagram that have edges that intersect the container polygons, the first (or last) outside vertex is preserved on edges that intersect a container polygon. A vertex is automatically inserted at the intersection of the edges and container polygons.</para>
			/// </summary>
			[GPValue("OUTER_EXCEPT_FIRST")]
			[Description("All outer vertices except the first one")]
			All_outer_vertices_except_the_first_one,

		}

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will run asynchronously on the server. This option dedicates server resources to run the layout algorithm with a longer time-out. Running asynchronously is recommended when executing layouts that are time consuming and may exceed the server time-out—for example, Partial Overlapping Edges—and applying to large diagrams—more than 25,000 features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will run synchronously on the server. It can fail without completion if its execution exceeds the service time-out: 600 seconds by default. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

#endregion
	}
}
