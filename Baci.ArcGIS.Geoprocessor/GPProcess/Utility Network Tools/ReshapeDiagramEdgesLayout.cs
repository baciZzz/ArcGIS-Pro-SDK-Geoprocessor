using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Reshape Diagram Edges Layout</para>
	/// <para>Apply the reshape diagram edges layout to a diagram</para>
	/// </summary>
	[Obsolete()]
	public class ReshapeDiagramEdgesLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// </param>
		public ReshapeDiagramEdgesLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Reshape Diagram Edges Layout</para>
		/// </summary>
		public override string DisplayName => "Reshape Diagram Edges Layout";

		/// <summary>
		/// <para>Tool Name : ReshapeDiagramEdgesLayout</para>
		/// </summary>
		public override string ToolName => "ReshapeDiagramEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.ReshapeDiagramEdgesLayout</para>
		/// </summary>
		public override string ExcuteName => "un.ReshapeDiagramEdgesLayout";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkDiagramLayer, AreContainersPreserved!, ReshapeType!, IsPathPreserved!, OffsetBetweenSegmentAbsolute!, BreakpointAbsolute!, ShiftBetweenEdgeAbsolute!, AngleThreshold!, OutNetworkDiagramLayer!, CircularArcRadius!, CircularArcPosition!, RunAsync! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Reshape Operation</para>
		/// <para><see cref="ReshapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReshapeType { get; set; } = "SQUARE_EDGES";

		/// <summary>
		/// <para>Preserve path</para>
		/// <para><see cref="IsPathPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsPathPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Offset Between Edges</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? OffsetBetweenSegmentAbsolute { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Break Point Position</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? BreakpointAbsolute { get; set; } = "8.66 Unknown";

		/// <summary>
		/// <para>Offset Between Edges</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ShiftBetweenEdgeAbsolute { get; set; } = "0.5 Unknown";

		/// <summary>
		/// <para>Angle Threshold</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AngleThreshold { get; set; } = "0";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Circular Arc Radius</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CircularArcRadius { get; set; } = "5 Unknown";

		/// <summary>
		/// <para>Circular Arc Position</para>
		/// <para><see cref="CircularArcPositionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CircularArcPosition { get; set; } = "RIGHT_OF_VERTICAL_SEGMENT";

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
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
		/// <para>Reshape Operation</para>
		/// </summary>
		public enum ReshapeTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("REMOVE_VERTICES")]
			[Description("REMOVE_VERTICES")]
			REMOVE_VERTICES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SQUARE_EDGES")]
			[Description("SQUARE_EDGES")]
			SQUARE_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SEPARATE_OVERLAPPING_EDGES")]
			[Description("SEPARATE_OVERLAPPING_EDGES")]
			SEPARATE_OVERLAPPING_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("REDUCE_VERTICES_BY_ANGLE")]
			[Description("REDUCE_VERTICES_BY_ANGLE")]
			REDUCE_VERTICES_BY_ANGLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MARK_CROSSING_EDGES")]
			[Description("MARK_CROSSING_EDGES")]
			MARK_CROSSING_EDGES,

		}

		/// <summary>
		/// <para>Preserve path</para>
		/// </summary>
		public enum IsPathPreservedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_PATH")]
			PRESERVE_PATH,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("LEFT_OF_VERTICAL_SEGMENT")]
			[Description("LEFT_OF_VERTICAL_SEGMENT")]
			LEFT_OF_VERTICAL_SEGMENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RIGHT_OF_VERTICAL_SEGMENT")]
			[Description("RIGHT_OF_VERTICAL_SEGMENT")]
			RIGHT_OF_VERTICAL_SEGMENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ABOVE_HORIZONTAL_SEGMENT")]
			[Description("ABOVE_HORIZONTAL_SEGMENT")]
			ABOVE_HORIZONTAL_SEGMENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BELOW_HORIZONTAL_SEGMENT")]
			[Description("BELOW_HORIZONTAL_SEGMENT")]
			BELOW_HORIZONTAL_SEGMENT,

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
