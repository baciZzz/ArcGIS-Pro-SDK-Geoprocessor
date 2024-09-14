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
	/// <para>Apply Angle Directed Layout</para>
	/// <para>Moves a diagram's edges in specified alignment directions.</para>
	/// </summary>
	public class ApplyAngleDirectedLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplyAngleDirectedLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Angle Directed Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Angle Directed Layout";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, IterationsNumber, NumberOfDirections, OutNetworkDiagramLayer, RunAsync };

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
		/// <para>Number of Iterations</para>
		/// <para>The number of iterations to process. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object IterationsNumber { get; set; } = "1";

		/// <summary>
		/// <para>Number of Directions</para>
		/// <para>The number of directions that will be used to align the diagram edges and their connected junctions.</para>
		/// <para>12 directions—The edges will move so they progressively approach one of the 12 axes, starting with the edge&apos;s origin junction and inclined at 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, or 360 degrees.</para>
		/// <para>8 directions—The edges will move so they progressively approach one of the 8 axes, starting with the edge&apos;s origin junction and inclined at 45, 90, 135, 180, 225, 270, 315, or 360 degrees. This is the default.</para>
		/// <para>4 directions—The edges will move so they progressively approach one of the 4 axes, starting with the edge&apos;s origin junction and inclined at 90, 180, 270, or 360 degrees.</para>
		/// <para><see cref="NumberOfDirectionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NumberOfDirections { get; set; } = "EIGHT_DIRECTIONS";

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
		/// <para>Number of Directions</para>
		/// </summary>
		public enum NumberOfDirectionsEnum 
		{
			/// <summary>
			/// <para>12 directions—The edges will move so they progressively approach one of the 12 axes, starting with the edge&apos;s origin junction and inclined at 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, or 360 degrees.</para>
			/// </summary>
			[GPValue("TWELVE_DIRECTIONS")]
			[Description("12 directions")]
			_12_directions,

			/// <summary>
			/// <para>8 directions—The edges will move so they progressively approach one of the 8 axes, starting with the edge&apos;s origin junction and inclined at 45, 90, 135, 180, 225, 270, 315, or 360 degrees. This is the default.</para>
			/// </summary>
			[GPValue("EIGHT_DIRECTIONS")]
			[Description("8 directions")]
			_8_directions,

			/// <summary>
			/// <para>4 directions—The edges will move so they progressively approach one of the 4 axes, starting with the edge&apos;s origin junction and inclined at 90, 180, 270, or 360 degrees.</para>
			/// </summary>
			[GPValue("FOUR_DIRECTIONS")]
			[Description("4 directions")]
			_4_directions,

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
