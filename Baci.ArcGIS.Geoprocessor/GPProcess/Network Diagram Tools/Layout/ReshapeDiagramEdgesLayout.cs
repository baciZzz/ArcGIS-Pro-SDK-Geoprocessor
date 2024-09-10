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
	/// <para>Reshape Diagram Edges Layout</para>
	/// <para>Processes simple operations on vertices along edges.</para>
	/// </summary>
	public class ReshapeDiagramEdgesLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ReshapeDiagramEdgesLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Reshape Diagram Edges Layout</para>
		/// </summary>
		public override string DisplayName() => "Reshape Diagram Edges Layout";

		/// <summary>
		/// <para>Tool Name : ReshapeDiagramEdgesLayout</para>
		/// </summary>
		public override string ToolName() => "ReshapeDiagramEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ReshapeDiagramEdgesLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ReshapeDiagramEdgesLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, ReshapeType, IsPathPreserved, OffsetBetweenSegmentAbsolute, BreakpointAbsolute, ShiftBetweenEdgeAbsolute, AngleThreshold, OutNetworkDiagramLayer, CircularArcRadius, CircularArcPosition, RunAsync };

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
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Reshape Operation</para>
		/// <para>Specifies how edges will be reshaped.</para>
		/// <para>Remove vertices—Vertices along any edges in the diagram will be removed.</para>
		/// <para>Square edges—Vertices will be placed along diagram edges, and the edges will be displayed with right angles. This is the default.</para>
		/// <para>Separate overlapping edges—Edges that connect the same origin and extremity junctions will be separated when they are overlapping.</para>
		/// <para>Reduce vertices by angle—Some or all vertices displayed along diagram edges will be reduced according to the angle that separates the segments incident to those vertices.</para>
		/// <para>Mark crossing edges—The horizontal and vertical diagram edges that cross each other at a right angle in the diagram will be marked, and the geometry of one of the crossing edges will be reshaped to display a circular arc at this location.</para>
		/// <para><see cref="ReshapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReshapeType { get; set; } = "SQUARE_EDGES";

		/// <summary>
		/// <para>Preserve path</para>
		/// <para>Specifies whether vertices along the edges that are going to be squared will be preserved. This parameter can only be used when Reshape Operation is Square edges.</para>
		/// <para>Checked—The direction of any edge will be considered, and vertices along that edge will be preserved from the first vertex to the last. This is the default.</para>
		/// <para>Unchecked—Vertices along the diagram edges will not be considered, and the vertices will be removed during execution.</para>
		/// <para><see cref="IsPathPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsPathPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Offset Between Edges</para>
		/// <para>The spacing that will separate parallel segments of squared edges incident to the same junction. The default is 5 in the units of the diagram's coordinate system. This parameter can only be used when Reshape Operation is Square edges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object OffsetBetweenSegmentAbsolute { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Break Point Position</para>
		/// <para>The maximum distance between each junction to the first or last break point along edges incident to that junction when those edges are squared. The default is 8.66 in the units of the diagram's coordinate system. This parameter can only be used when Reshape Operation is Square edges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object BreakpointAbsolute { get; set; } = "8.66 Unknown";

		/// <summary>
		/// <para>Offset Between Edges</para>
		/// <para>The absolute spacing that will separate two edges. The default is 0.5 in the units of the diagram's coordinate system. This parameter can only be used when Reshape Operation is Separate overlapping edges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ShiftBetweenEdgeAbsolute { get; set; } = "0.5 Unknown";

		/// <summary>
		/// <para>Angle Threshold</para>
		/// <para>The angle formed by the incident segments over which the vertex related to these segments is reduced. The wider the angle, the fewer number of vertices will be reduced. The default is 160 degrees. This parameter can only be used when Reshape Operation is Reduce vertices by angle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AngleThreshold { get; set; } = "0";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Circular Arc Radius</para>
		/// <para>The radius of the circular arc that will be added to the crossing edge locations. The default is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object CircularArcRadius { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Circular Arc Position</para>
		/// <para>Specifies the segment on which a circular arc will be placed.</para>
		/// <para>Left of vertical segment—A circular arc will be placed to the left of the vertical segment.</para>
		/// <para>Right of vertical segment—A circular arc will be placed to the right of the vertical segment.</para>
		/// <para>Above horizontal segment—A circular arc will be placed above the horizontal segment.</para>
		/// <para>Below horizontal segment—A circular arc will be placed below the horizontal segment.</para>
		/// <para><see cref="CircularArcPositionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CircularArcPosition { get; set; } = "RIGHT_OF_VERTICAL_SEGMENT";

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
		/// <para>Reshape Operation</para>
		/// </summary>
		public enum ReshapeTypeEnum 
		{
			/// <summary>
			/// <para>Remove vertices—Vertices along any edges in the diagram will be removed.</para>
			/// </summary>
			[GPValue("REMOVE_VERTICES")]
			[Description("Remove vertices")]
			Remove_vertices,

			/// <summary>
			/// <para>Square edges—Vertices will be placed along diagram edges, and the edges will be displayed with right angles. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE_EDGES")]
			[Description("Square edges")]
			Square_edges,

			/// <summary>
			/// <para>Separate overlapping edges—Edges that connect the same origin and extremity junctions will be separated when they are overlapping.</para>
			/// </summary>
			[GPValue("SEPARATE_OVERLAPPING_EDGES")]
			[Description("Separate overlapping edges")]
			Separate_overlapping_edges,

			/// <summary>
			/// <para>Reduce vertices by angle—Some or all vertices displayed along diagram edges will be reduced according to the angle that separates the segments incident to those vertices.</para>
			/// </summary>
			[GPValue("REDUCE_VERTICES_BY_ANGLE")]
			[Description("Reduce vertices by angle")]
			Reduce_vertices_by_angle,

			/// <summary>
			/// <para>Mark crossing edges—The horizontal and vertical diagram edges that cross each other at a right angle in the diagram will be marked, and the geometry of one of the crossing edges will be reshaped to display a circular arc at this location.</para>
			/// </summary>
			[GPValue("MARK_CROSSING_EDGES")]
			[Description("Mark crossing edges")]
			Mark_crossing_edges,

		}

		/// <summary>
		/// <para>Preserve path</para>
		/// </summary>
		public enum IsPathPreservedEnum 
		{
			/// <summary>
			/// <para>Checked—The direction of any edge will be considered, and vertices along that edge will be preserved from the first vertex to the last. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_PATH")]
			PRESERVE_PATH,

			/// <summary>
			/// <para>Unchecked—Vertices along the diagram edges will not be considered, and the vertices will be removed during execution.</para>
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
			/// <para>Left of vertical segment—A circular arc will be placed to the left of the vertical segment.</para>
			/// </summary>
			[GPValue("LEFT_OF_VERTICAL_SEGMENT")]
			[Description("Left of vertical segment")]
			Left_of_vertical_segment,

			/// <summary>
			/// <para>Right of vertical segment—A circular arc will be placed to the right of the vertical segment.</para>
			/// </summary>
			[GPValue("RIGHT_OF_VERTICAL_SEGMENT")]
			[Description("Right of vertical segment")]
			Right_of_vertical_segment,

			/// <summary>
			/// <para>Above horizontal segment—A circular arc will be placed above the horizontal segment.</para>
			/// </summary>
			[GPValue("ABOVE_HORIZONTAL_SEGMENT")]
			[Description("Above horizontal segment")]
			Above_horizontal_segment,

			/// <summary>
			/// <para>Below horizontal segment—A circular arc will be placed below the horizontal segment.</para>
			/// </summary>
			[GPValue("BELOW_HORIZONTAL_SEGMENT")]
			[Description("Below horizontal segment")]
			Below_horizontal_segment,

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
