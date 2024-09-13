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
	/// <para>Apply Force Directed Layout</para>
	/// <para>Apply Force Directed Layout</para>
	/// <para>Apply the force directed layout to a diagram</para>
	/// </summary>
	[Obsolete()]
	public class ApplyForceDirectedLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
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
		/// <para>Tool Excute Name : un.ApplyForceDirectedLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.ApplyForceDirectedLayout";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, IterationsNumber, RepelFactor, DegreeFreedom, OutNetworkDiagramLayer, BreakpointPosition, EdgeDisplayType, RunAsync };

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
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object IterationsNumber { get; set; } = "20";

		/// <summary>
		/// <para>Repel Factor</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RepelFactor { get; set; } = "1";

		/// <summary>
		/// <para>Degree of Freedom</para>
		/// <para><see cref="DegreeFreedomEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DegreeFreedom { get; set; } = "LOW";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeDisplayType { get; set; } = "REGULAR_EDGES";

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
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
		/// <para>Degree of Freedom</para>
		/// </summary>
		public enum DegreeFreedomEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("LOW")]
			[Description("LOW")]
			LOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("MEDIUM")]
			MEDIUM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("HIGH")]
			HIGH,

		}

		/// <summary>
		/// <para>Edge Display Type</para>
		/// </summary>
		public enum EdgeDisplayTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("REGULAR_EDGES")]
			[Description("REGULAR_EDGES")]
			REGULAR_EDGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CURVED_EDGES")]
			[Description("CURVED_EDGES")]
			CURVED_EDGES,

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
