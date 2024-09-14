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
	/// <para>Apply Geo Positions Layout</para>
	/// <para>Apply Geo Positions Layout</para>
	/// <para>Moves each diagram junction and edge feature so they match the geographical positions of the associated network features.</para>
	/// </summary>
	public class ApplyGeoPositionsLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </param>
		public ApplyGeoPositionsLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Geo Positions Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Geo Positions Layout";

		/// <summary>
		/// <para>Tool Name : ApplyGeoPositionsLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyGeoPositionsLayout";

		/// <summary>
		/// <para>Tool Excute Name : nd.ApplyGeoPositionsLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.ApplyGeoPositionsLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, RestoreEdgesGeoPositions, OutNetworkDiagramLayer, RunAsync };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to which the layout will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Restore edges geographic positions</para>
		/// <para>Indicates whether or not diagram edges will be restored to the geographic position of their vertices:</para>
		/// <para>Checked—Vertices along diagram edges will be restored when possible, moving them to match the geographic positions of the network features. This is the default.</para>
		/// <para>Unchecked—Vertices along diagram edges will not be restored. They will appear as straight lines between their connecting junctions.</para>
		/// <para><see cref="RestoreEdgesGeoPositionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RestoreEdgesGeoPositions { get; set; } = "true";

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
		/// <para>Restore edges geographic positions</para>
		/// </summary>
		public enum RestoreEdgesGeoPositionsEnum 
		{
			/// <summary>
			/// <para>Checked—Vertices along diagram edges will be restored when possible, moving them to match the geographic positions of the network features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RESTORE_EDGES_GEO_POSITIONS")]
			RESTORE_EDGES_GEO_POSITIONS,

			/// <summary>
			/// <para>Unchecked—Vertices along diagram edges will not be restored. They will appear as straight lines between their connecting junctions.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RESTORE_EDGES_GEO_POSITIONS")]
			DO_NOT_RESTORE_EDGES_GEO_POSITIONS,

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
