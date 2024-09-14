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
	/// <para>Apply Smart Tree Layout</para>
	/// <para>Apply Smart Tree Layout</para>
	/// <para>Arranges diagram features hierarchically and places them in a smart tree.</para>
	/// </summary>
	public class ApplySmartTreeLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplySmartTreeLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Smart Tree Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Smart Tree Layout";

		/// <summary>
		/// <para>Tool Name : ApplySmartTreeLayout</para>
		/// </summary>
		public override string ToolName() => "ApplySmartTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplySmartTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplySmartTreeLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, TreeDirection!, IsUnitAbsolute!, SubtreeAbsolute!, SubtreeProportional!, PerpendicularAbsolute!, PerpendicularProportional!, AlongAbsolute!, AlongProportional!, DisjoinedGraphAbsolute!, DisjoinedGraphProportional!, AreEdgesOrthogonal!, BreakpointPosition!, OutNetworkDiagramLayer!, EdgeDisplayType!, RunAsync!, OffsetAbsolute!, OffsetProportional! };

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
		/// <para>Tree Direction</para>
		/// <para>Specifies the direction of the tree.</para>
		/// <para>From left to right—The tree will be drawn from left to right. This is the default.</para>
		/// <para>From right to left—The tree will be drawn from right to left.</para>
		/// <para>From bottom to top—The tree will be drawn from bottom to top.</para>
		/// <para>From top to bottom—The tree will be drawn from top to bottom.</para>
		/// <para><see cref="TreeDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TreeDirection { get; set; } = "FROM_LEFT_TO_RIGHT";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para>Specifies how parameters representing distances will be interpreted.</para>
		/// <para>Checked—The layout algorithm will interpret any distance values as linear units.</para>
		/// <para>Unchecked—The layout algorithm will interpret any distance values as relative units to an estimation of the average of the junction sizes in the current diagram extent. This is the default.</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Between Subtrees</para>
		/// <para>The spacing between two neighboring subtrees—that is, the spacing between diagram junctions that are displayed perpendicular to the smart tree direction and belong to a different subtree. The default is in the units of the diagram's coordinate system. This parameter can only be used with absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SubtreeAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Subtrees</para>
		/// <para>The spacing between two neighboring subtrees—that is, the spacing between diagram junctions that are displayed perpendicular to the smart tree direction and belong to a different subtree. The default is 2. This parameter can only be used with proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SubtreeProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// <para>The spacing between diagram junctions that are displayed perpendicular to the smart tree direction and belong to the same subtree level. The default is 2 in the units of the diagram's coordinate system. This parameter can only be used with absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? PerpendicularAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// <para>The spacing between diagram junctions that are displayed perpendicular to the smart tree direction and belong to the same subtree level. The default is 2. This parameter can only be used with proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PerpendicularProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// <para>The spacing between diagram junctions that are displayed along the smart tree direction. The default is 2 in the units of the diagram's coordinate system. This parameter can only be used with absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? AlongAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// <para>The spacing between diagram junctions that are displayed along the smart tree direction. The default is 2. This parameter can only be used with proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AlongProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>The minimum spacing that will separate features belonging to disjoined graphs when the diagram contains such graphs. This parameter is used with absolute units. The default is 4 in the units of the diagram's coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? DisjoinedGraphAbsolute { get; set; } = "4 Unknown";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// <para>The minimum spacing that will separate features belonging to disjoined graphs when the diagram contains such graphs. This parameter is used with proportional units. The default is 4.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? DisjoinedGraphProportional { get; set; } = "4";

		/// <summary>
		/// <para>Orthogonally display edges</para>
		/// <para>Specifies how diagram edges that are related to the tree branches will display.This parameter is deprecated at ArcGIS Pro 3.0. It is systematically ignored regardless of its value when the edge_display_type parameter is specified. However, to maintain compatibility with ArcGIS Pro 2.1, it remains enabled when the edge_display_type parameter is not specified.</para>
		/// <para>ORTHOGONAL_EDGES—All diagram edges related to the tree branches will display with right angles.</para>
		/// <para>SLANTED_EDGES—All diagram edges related to the tree branches will not display with right angles. This is the default.</para>
		/// <para><see cref="AreEdgesOrthogonalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreEdgesOrthogonal { get; set; } = "false";

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// <para>The relative position of the break point that will be inserted along the diagram edges when Edge Display Type is set to Regular edges (edge_display_type = &quot;REGULAR_EDGES&quot; in Python) or Edge Display Type is set to Orthogonal edges (edge_display_type = &quot;ORTHOGONAL_EDGES&quot; in Python). It is a percentage between 0 and 100.</para>
		/// <para>With a Break Point Relative Position (%) value of 0, the break point is positioned at the x-coordinate of the edge&apos;s from junction and at the y-coordinate of the edge&apos;s to junction for a horizontal tree. It is positioned at the y-coordinate of the edge&apos;s from junction and at the x-coordinate of the edge&apos;s to junction for a vertical tree.</para>
		/// <para>With a Break Point Relative Position (%) value of 100, there is no break point inserted on the diagram edges; each diagram edge directly connects its from and to junctions.</para>
		/// <para>With a Break Point Relative Position (%) value of N between 0 and 100, the break point is positioned at N% of the length of the [XY] segment, X being the x-coordinate of the edge&apos;s from junction and Y being the y-coordinate of the edge&apos;s to junction for a horizontal tree. It is positioned at N% of the length of the [YX] segment, Y being the y-coordinate of the edge&apos;s from junction and X being the x-coordinate of the edge&apos;s to junction for a vertical tree.</para>
		/// <para>The relative position of the two inflection points that will be inserted along the diagram edges to compute the curved edges geometry when Edge Display Type is set to Curved edges (edge_display_type = &quot;CURVED_EDGES&quot; in Python). It is a percentage between 15 and 40. With a Break Point Relative Position (%) value of N between 15 and 40:</para>
		/// <para>X being the x-coordinate of the edge&apos;s from junction and Y being the y-coordinate of the edge&apos;s to junction for a horizontal tree:</para>
		/// <para>The first inflection point will be positioned at N% of the length of the [XY] segment.</para>
		/// <para>The second inflection point will be positioned at (100 - N)% of the length of the [XY] segment.</para>
		/// <para>Y being the y-coordinate of the edge&apos;s from junction and X being the x-coordinate of the edge&apos;s to junction for a vertical tree:</para>
		/// <para>The first inflection point will be positioned at N% of the length of the [YX] segment.</para>
		/// <para>The second inflection point will be positioned at (100 - N)% of the length of the [XY] segment.</para>
		/// <para>The concept of the from and to junctions above is relative to the tree direction; it has nothing to do with the real topology of the edge feature or edge object in the network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para>Specifies the type of display for the diagram edges related to the tree branches.</para>
		/// <para>Regular edges—All diagram edges related to the tree branches will not display with right angles. This is the default.</para>
		/// <para>Orthogonal edges—All diagram edges related to the tree branches will display with right angles.</para>
		/// <para>Curved edges—All diagram edges related to the tree branches will be curved.</para>
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

		/// <summary>
		/// <para>Absolute Offset</para>
		/// <para>The offset that will be used to separate overlapping segments when using absolute units and Edge Display Type is set to Orthogonal edges. The value cannot exceed 10 percent of the smallest value specified for the other spacing parameters. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? OffsetAbsolute { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Proportional Offset</para>
		/// <para>The offset that will be used to separate overlapping segments when using proportional units and Edge Display Type is set to Orthogonal edges. It is a double value that cannot exceed 10 percent of the smallest value specified for the other spacing parameters. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? OffsetProportional { get; set; } = "0";

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
		/// <para>Tree Direction</para>
		/// </summary>
		public enum TreeDirectionEnum 
		{
			/// <summary>
			/// <para>From left to right—The tree will be drawn from left to right. This is the default.</para>
			/// </summary>
			[GPValue("FROM_LEFT_TO_RIGHT")]
			[Description("From left to right")]
			From_left_to_right,

			/// <summary>
			/// <para>From right to left—The tree will be drawn from right to left.</para>
			/// </summary>
			[GPValue("FROM_RIGHT_TO_LEFT")]
			[Description("From right to left")]
			From_right_to_left,

			/// <summary>
			/// <para>From bottom to top—The tree will be drawn from bottom to top.</para>
			/// </summary>
			[GPValue("FROM_BOTTOM_TO_TOP")]
			[Description("From bottom to top")]
			From_bottom_to_top,

			/// <summary>
			/// <para>From top to bottom—The tree will be drawn from top to bottom.</para>
			/// </summary>
			[GPValue("FROM_TOP_TO_BOTTOM")]
			[Description("From top to bottom")]
			From_top_to_bottom,

		}

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// </summary>
		public enum IsUnitAbsoluteEnum 
		{
			/// <summary>
			/// <para>Checked—The layout algorithm will interpret any distance values as linear units.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ABSOLUTE_UNIT")]
			ABSOLUTE_UNIT,

			/// <summary>
			/// <para>Unchecked—The layout algorithm will interpret any distance values as relative units to an estimation of the average of the junction sizes in the current diagram extent. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PROPORTIONAL_UNIT")]
			PROPORTIONAL_UNIT,

		}

		/// <summary>
		/// <para>Orthogonally display edges</para>
		/// </summary>
		public enum AreEdgesOrthogonalEnum 
		{
			/// <summary>
			/// <para>ORTHOGONAL_EDGES—All diagram edges related to the tree branches will display with right angles.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ORTHOGONAL_EDGES")]
			ORTHOGONAL_EDGES,

			/// <summary>
			/// <para>SLANTED_EDGES—All diagram edges related to the tree branches will not display with right angles. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SLANTED_EDGES")]
			SLANTED_EDGES,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para>Regular edges—All diagram edges related to the tree branches will not display with right angles. This is the default.</para>
			/// </summary>
			[GPValue("REGULAR_EDGES")]
			[Description("Regular edges")]
			Regular_edges,

			/// <summary>
			/// <para>Orthogonal edges—All diagram edges related to the tree branches will display with right angles.</para>
			/// </summary>
			[GPValue("ORTHOGONAL_EDGES")]
			[Description("Orthogonal edges")]
			Orthogonal_edges,

			/// <summary>
			/// <para>Curved edges—All diagram edges related to the tree branches will be curved.</para>
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
