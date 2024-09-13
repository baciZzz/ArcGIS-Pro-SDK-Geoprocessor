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
	/// <para>Apply Force Directed Layout</para>
	/// <para>Emphasizes loops contained in a network diagram.</para>
	/// </summary>
	public class ApplyForceDirectedLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplyForceDirectedLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Force Directed Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Force Directed Layout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, IterationsNumber!, RepelFactor!, DegreeFreedom!, OutNetworkDiagramLayer!, BreakpointPosition!, EdgeDisplayType!, RunAsync! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para>Specifies how the algorithm will process containers.</para>
		/// <para>Checked—The layout algorithm will execute on the top graph of the diagram so containers are preserved.</para>
		/// <para>Unchecked—The layout algorithm will execute on both content and noncontent features in the diagram. This is the default.</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// <para>The number of iterations to process. The default is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? IterationsNumber { get; set; } = "20";

		/// <summary>
		/// <para>Repel Factor</para>
		/// <para>Adds distance between diagram junctions that are close together. The larger the repel factor, the greater the distance that will be added between nearly overlapping diagram junctions. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? RepelFactor { get; set; } = "1";

		/// <summary>
		/// <para>Degree of Freedom</para>
		/// <para>Specifies the area used to move the diagram junctions during each algorithm iteration.</para>
		/// <para>Low—The area used to move the diagram junctions will be limited. This is the default.</para>
		/// <para>High—The area used to move the diagram junctions will be large.</para>
		/// <para>Medium—The area used to move the diagram junctions will be moderate.</para>
		/// <para><see cref="DegreeFreedomEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DegreeFreedom { get; set; } = "LOW";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// <para>The relative position of the two inflexion points that will be inserted along the diagram edges to compute the curved edges geometry when Edge Display Type is set to Curved edges (edges_display_type = &quot;CURVED_EDGES&quot; in Python). It is a percentage between 15 and 40; the default is 30. For example, with a Break Point Relative Position (%) parameter value of N between 15 and 40, the following is true:</para>
		/// <para>X being the x-coordinate of the edge&apos;s from junction and Y being the y-coordinate of the edge&apos;s to junction for a horizontal tree:</para>
		/// <para>The first inflexion point will be positioned at N% of the length of the [XY] segment</para>
		/// <para>The second inflexion point will be positioned at (100 - N)% of the length of the [XY] segment</para>
		/// <para>Y being the y-coordinate of the edge&apos;s from junction and X being the x-coordinate of the edge&apos;s to junction for a vertical tree:</para>
		/// <para>The first inflexion point will be positioned at N% of the length of the [YX] segment</para>
		/// <para>The second inflexion point will be positioned at (100 - N)% of the length of the [XY] segment</para>
		/// <para>The concept of the from and to junctions above is relative to the tree direction; it is not related to the topology of the network feature or object edge.</para>
		/// <para>This parameter is ignored when the Edge Display Type parameter is set to Regular edges (edges_display_type = &quot;REGULAR_EDGES&quot; in Python).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para>Specifies the type of display for the diagram edges.</para>
		/// <para>Regular edges—All diagram edges display as straight lines. This is the default.</para>
		/// <para>Curved edges—All diagram edges are curved.</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EdgeDisplayType { get; set; } = "REGULAR_EDGES";

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
		/// <para>Preserve container layout</para>
		/// </summary>
		public enum AreContainersPreservedEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will execute on the top graph of the diagram so containers are preserved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_CONTAINERS")]
			PRESERVE_CONTAINERS,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will execute on both content and noncontent features in the diagram. This is the default.</para>
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
			/// <para>Low—The area used to move the diagram junctions will be limited. This is the default.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low")]
			Low,

			/// <summary>
			/// <para>Medium—The area used to move the diagram junctions will be moderate.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>High—The area used to move the diagram junctions will be large.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para>Regular edges—All diagram edges display as straight lines. This is the default.</para>
			/// </summary>
			[GPValue("REGULAR_EDGES")]
			[Description("Regular edges")]
			Regular_edges,

			/// <summary>
			/// <para>Curved edges—All diagram edges are curved.</para>
			/// </summary>
			[GPValue("CURVED_EDGES")]
			[Description("Curved edges")]
			Curved_edges,

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
