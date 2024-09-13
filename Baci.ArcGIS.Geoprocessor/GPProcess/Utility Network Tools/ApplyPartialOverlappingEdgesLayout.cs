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
	/// <para>Apply Partial Overlapping Edges Layout</para>
	/// <para>Apply Partial Overlapping Edges Layout</para>
	/// <para>Apply the partial overlapping edges to a diagram</para>
	/// </summary>
	[Obsolete()]
	public class ApplyPartialOverlappingEdgesLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// </param>
		/// <param name="BufferWidthAbsolute">
		/// <para>Buffer Width</para>
		/// </param>
		/// <param name="OffsetAbsolute">
		/// <para>Offset</para>
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
		public override string DisplayName() => "Apply Partial Overlapping Edges Layout";

		/// <summary>
		/// <para>Tool Name : ApplyPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.ApplyPartialOverlappingEdgesLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.ApplyPartialOverlappingEdgesLayout";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, BufferWidthAbsolute, OffsetAbsolute, OptimizeEdges!, OutNetworkDiagramLayer!, RunAsync! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Buffer Width</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BufferWidthAbsolute { get; set; }

		/// <summary>
		/// <para>Offset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; }

		/// <summary>
		/// <para>Optimize edges</para>
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
