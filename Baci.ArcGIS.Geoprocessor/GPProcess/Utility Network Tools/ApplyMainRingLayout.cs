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
	/// <para>Apply Main Ring Layout</para>
	/// <para>Apply Main Ring Layout</para>
	/// <para>Apply the main ring layout to a diagram</para>
	/// </summary>
	[Obsolete()]
	public class ApplyMainRingLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// </param>
		public ApplyMainRingLayout(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Main Ring Layout</para>
		/// </summary>
		public override string DisplayName() => "Apply Main Ring Layout";

		/// <summary>
		/// <para>Tool Name : ApplyMainRingLayout</para>
		/// </summary>
		public override string ToolName() => "ApplyMainRingLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.ApplyMainRingLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.ApplyMainRingLayout";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, AreContainersPreserved, RingType, IsUnitAbsolute, RingWidthAbsolute, RingWidthProportional, RingHeightAbsolute, RingHeightProportional, TreeType, PerpendicularAbsolute, PerpendicularProportional, AlongAbsolute, AlongProportional, BreakpointPosition, EdgeDisplayType, OutNetworkDiagramLayer, RunAsync, OffsetAbsolute, OffsetProportional };

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
		/// <para>Ring Type</para>
		/// <para><see cref="RingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RingType { get; set; } = "ELLIPSE";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Ring Width</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object RingWidthAbsolute { get; set; } = "50 Unknown";

		/// <summary>
		/// <para>Ring Width</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RingWidthProportional { get; set; } = "50";

		/// <summary>
		/// <para>Ring Height</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object RingHeightAbsolute { get; set; } = "20 Unknown";

		/// <summary>
		/// <para>Ring Height</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RingHeightProportional { get; set; } = "20";

		/// <summary>
		/// <para>Hierarchical Tree Type</para>
		/// <para><see cref="TreeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TreeType { get; set; } = "SMART_TREE";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PerpendicularAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Perpendicular to the Direction</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PerpendicularProportional { get; set; } = "2";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object AlongAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Between Junctions Along the Direction</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AlongProportional { get; set; } = "2";

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
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object RunAsync { get; set; } = "false";

		/// <summary>
		/// <para>Offset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object OffsetAbsolute { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Offset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object OffsetProportional { get; set; } = "0";

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
		/// <para>Ring Type</para>
		/// </summary>
		public enum RingTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ELLIPSE")]
			[Description("ELLIPSE")]
			ELLIPSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECTANGLE")]
			[Description("RECTANGLE")]
			RECTANGLE,

		}

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// </summary>
		public enum IsUnitAbsoluteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ABSOLUTE_UNIT")]
			ABSOLUTE_UNIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PROPORTIONAL_UNIT")]
			PROPORTIONAL_UNIT,

		}

		/// <summary>
		/// <para>Hierarchical Tree Type</para>
		/// </summary>
		public enum TreeTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BOTH_SIDES")]
			[Description("BOTH_SIDES")]
			BOTH_SIDES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("LEFT_SIDE")]
			[Description("LEFT_SIDE")]
			LEFT_SIDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RIGHT_SIDE")]
			[Description("RIGHT_SIDE")]
			RIGHT_SIDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SMART_TREE")]
			[Description("SMART_TREE")]
			SMART_TREE,

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
			[GPValue("ORTHOGONAL_EDGES")]
			[Description("ORTHOGONAL_EDGES")]
			ORTHOGONAL_EDGES,

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
