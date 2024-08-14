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
	/// <para>Apply Relative Mainline Layout</para>
	/// <para>Arranges the network diagram features in the active diagram along parallel straight lines.</para>
	/// </summary>
	public class ApplyRelativeMainlineLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		/// <param name="LineAttribute">
		/// <para>Line Attribute</para>
		/// <para>The name of the network attribute that will be used to identify the lines that comprise the straight lines. This network attribute must exist in the network line classes. Its values must be the same for all the edges that comprise a straight line, for example, Line 1, Line 2, and so on.</para>
		/// </param>
		public ApplyRelativeMainlineLayout(object InNetworkDiagramLayer, object LineAttribute)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.LineAttribute = LineAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Relative Mainline Layout</para>
		/// </summary>
		public override string DisplayName => "Apply Relative Mainline Layout";

		/// <summary>
		/// <para>Tool Name : ApplyRelativeMainlineLayout</para>
		/// </summary>
		public override string ToolName => "ApplyRelativeMainlineLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyRelativeMainlineLayout</para>
		/// </summary>
		public override string ExcuteName => "nd.ApplyRelativeMainlineLayout";

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
		public override object[] Parameters => new object[] { InNetworkDiagramLayer, LineAttribute, MainlineDirection!, OffsetBetweenBranches!, BreakpointAngle!, TypeAttribute!, MainlineValues!, BranchValues!, ExcludedValues!, IsCompressing!, CompressionRatio!, MinimalDistance!, AlignmentAttribute!, InitialDistances!, LengthAttribute!, OutNetworkDiagramLayer!, RunAsync! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Line Attribute</para>
		/// <para>The name of the network attribute that will be used to identify the lines that comprise the straight lines. This network attribute must exist in the network line classes. Its values must be the same for all the edges that comprise a straight line, for example, Line 1, Line 2, and so on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LineAttribute { get; set; }

		/// <summary>
		/// <para>Direction</para>
		/// <para>Specifies the direction of the main line.</para>
		/// <para>From left to right—The main line will be drawn as a horizontal line starting from the left and ending on the right. This is the default.</para>
		/// <para>From top to bottom—The main line will be drawn as a vertical line starting from the top and ending at the bottom.</para>
		/// <para><see cref="MainlineDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MainlineDirection { get; set; } = "FROM_LEFT_TO_RIGHT";

		/// <summary>
		/// <para>Offset Between Branches</para>
		/// <para>The spacing between two adjacent branches along the axis perpendicular to the direction of the lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? OffsetBetweenBranches { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Break Point Angle (in degrees)</para>
		/// <para>The angle that will be used to position the break point on the branches. It is a value between 30 and 90 degrees that is combined with the Offset Between Branches parameter value to compute this position. When the break point angle value is 90 degrees, each branch displays orthogonally.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BreakpointAngle { get; set; } = "45";

		/// <summary>
		/// <para>Type Attribute</para>
		/// <para>The name of the network attribute that will be used to qualify the lines. This network attribute may exist in the network line classes.</para>
		/// <para>The Type Attribute and Line Attribute parameter values can be the same.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Line Classification")]
		public object? TypeAttribute { get; set; }

		/// <summary>
		/// <para>Mainline Values</para>
		/// <para>The Type Attribute values that identify the main lines. When such values exist, they must be the same for any edge that comprises the main lines, regardless of their related network feature line classes or edge object tables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object? MainlineValues { get; set; }

		/// <summary>
		/// <para>Branch Values</para>
		/// <para>The Type Attribute values that identify the branches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object? BranchValues { get; set; }

		/// <summary>
		/// <para>Excluded Values</para>
		/// <para>The Type Attribute values that identify the edges that will be excluded from the straight lines (crossovers or ladders).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object? ExcludedValues { get; set; }

		/// <summary>
		/// <para>Compression along the direction</para>
		/// <para>Specifies whether the graph will be compressed.</para>
		/// <para>Checked—Compression will be used. An additional step is executed at the end of the process to reduce the distances between adjacent groups of neighbor junctions along the direction while maintaining relative positioning between these groups. Neighbor junctions are junctions that are geographically close to each other without being directly connected.</para>
		/// <para>Unchecked—Compression will not be used. This is the default.</para>
		/// <para><see cref="IsCompressingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Compression")]
		public object? IsCompressing { get; set; } = "false";

		/// <summary>
		/// <para>Ratio (%)</para>
		/// <para>A value between 0 and 100 that is applied to the length of any edge after subtracting the minimal distance of its length. When Ratio (%) is 100, the distance between each detected junction group is equal to the minimal distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Line Compression")]
		public object? CompressionRatio { get; set; } = "0";

		/// <summary>
		/// <para>Minimal Distance</para>
		/// <para>The minimal distance between two adjacent groups of neighbor junctions. This minimal distance is also used to group neighbor junctions based on their projection along the direction axis. Two junctions projected on this axis will belong to the same group when the distance between the two projected points is less than this distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Line Compression")]
		public object? MinimalDistance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Alignment Attribute</para>
		/// <para>The name of the network attribute that will be used to align lines that are split. The algorithm aligns lines with the same attribute value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? AlignmentAttribute { get; set; }

		/// <summary>
		/// <para>Initial Distances</para>
		/// <para>Specifies how the length of the diagram edges will be assessed. This length determines the positions of the junctions along the direction. The distances between the connected junctions along the direction are not equidistant; they are relative to each other and depend on the current edge length and the length of the shortest edge.</para>
		/// <para>From current edge geometry— The distances will be computed from the current edge geometry. This is the default.</para>
		/// <para>From attribute edge—The distances will be computed from a given attribute that exists on an edge.</para>
		/// <para><see cref="InitialDistancesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? InitialDistances { get; set; } = "FROM_CURRENT_EDGE_GEOMETRY";

		/// <summary>
		/// <para>Length Attribute</para>
		/// <para>The network attribute from which the distances will be computed when Initial Distances is From attribute edge.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? LengthAttribute { get; set; }

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
		/// <para>Direction</para>
		/// </summary>
		public enum MainlineDirectionEnum 
		{
			/// <summary>
			/// <para>From left to right—The main line will be drawn as a horizontal line starting from the left and ending on the right. This is the default.</para>
			/// </summary>
			[GPValue("FROM_LEFT_TO_RIGHT")]
			[Description("From left to right")]
			From_left_to_right,

			/// <summary>
			/// <para>From top to bottom—The main line will be drawn as a vertical line starting from the top and ending at the bottom.</para>
			/// </summary>
			[GPValue("FROM_TOP_TO_BOTTOM")]
			[Description("From top to bottom")]
			From_top_to_bottom,

		}

		/// <summary>
		/// <para>Compression along the direction</para>
		/// </summary>
		public enum IsCompressingEnum 
		{
			/// <summary>
			/// <para>Checked—Compression will be used. An additional step is executed at the end of the process to reduce the distances between adjacent groups of neighbor junctions along the direction while maintaining relative positioning between these groups. Neighbor junctions are junctions that are geographically close to each other without being directly connected.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_COMPRESSION")]
			USE_COMPRESSION,

			/// <summary>
			/// <para>Unchecked—Compression will not be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_COMPRESSION")]
			DO_NOT_USE_COMPRESSION,

		}

		/// <summary>
		/// <para>Initial Distances</para>
		/// </summary>
		public enum InitialDistancesEnum 
		{
			/// <summary>
			/// <para>From current edge geometry— The distances will be computed from the current edge geometry. This is the default.</para>
			/// </summary>
			[GPValue("FROM_CURRENT_EDGE_GEOMETRY")]
			[Description("From current edge geometry")]
			From_current_edge_geometry,

			/// <summary>
			/// <para>From attribute edge—The distances will be computed from a given attribute that exists on an edge.</para>
			/// </summary>
			[GPValue("FROM_ATTRIBUTE_EDGE")]
			[Description("From attribute edge")]
			From_attribute_edge,

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
