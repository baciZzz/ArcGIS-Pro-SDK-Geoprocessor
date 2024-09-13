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
	/// <para>Add Mainline Tree Layout</para>
	/// <para>Add Mainline Tree Layout</para>
	/// <para>Add a mainline tree layout to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddMainlineTreeLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		public AddMainlineTreeLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Mainline Tree Layout</para>
		/// </summary>
		public override string DisplayName() => "Add Mainline Tree Layout";

		/// <summary>
		/// <para>Tool Name : AddMainlineTreeLayout</para>
		/// </summary>
		public override string ToolName() => "AddMainlineTreeLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.AddMainlineTreeLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.AddMainlineTreeLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AreContainersPreserved, TreeDirection, BranchesPlacement, IsUnitAbsolute, PerpendicularAbsolute, PerpendicularProportional, AlongAbsolute, AlongProportional, DisjoinedGraphAbsolute, DisjoinedGraphProportional, AreEdgesOrthogonal, BreakpointPosition, OutUtilityNetwork, OutTemplateName, EdgeDisplayType, OffsetAbsolute, OffsetProportional };

		/// <summary>
		/// <para>Input Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Preserve container layout</para>
		/// <para><see cref="AreContainersPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreContainersPreserved { get; set; } = "false";

		/// <summary>
		/// <para>Tree Direction</para>
		/// <para><see cref="TreeDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TreeDirection { get; set; } = "FROM_LEFT_TO_RIGHT";

		/// <summary>
		/// <para>Branches Placement</para>
		/// <para><see cref="BranchesPlacementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BranchesPlacement { get; set; } = "BOTH_SIDES";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsUnitAbsolute { get; set; } = "false";

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
		/// <para>Between Disjoined Graphs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object DisjoinedGraphAbsolute { get; set; } = "4 Unknown";

		/// <summary>
		/// <para>Between Disjoined Graphs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DisjoinedGraphProportional { get; set; } = "4";

		/// <summary>
		/// <para>Orthogonally display edges</para>
		/// <para><see cref="AreEdgesOrthogonalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreEdgesOrthogonal { get; set; } = "false";

		/// <summary>
		/// <para>Break Point Relative Position (%)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BreakpointPosition { get; set; } = "30";

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutTemplateName { get; set; }

		/// <summary>
		/// <para>Edge Display Type</para>
		/// <para><see cref="EdgeDisplayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeDisplayType { get; set; } = "REGULAR_EDGES";

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
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INACTIVE")]
			INACTIVE,

		}

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
		/// <para>Tree Direction</para>
		/// </summary>
		public enum TreeDirectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_LEFT_TO_RIGHT")]
			[Description("FROM_LEFT_TO_RIGHT")]
			FROM_LEFT_TO_RIGHT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_RIGHT_TO_LEFT")]
			[Description("FROM_RIGHT_TO_LEFT")]
			FROM_RIGHT_TO_LEFT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_BOTTOM_TO_TOP")]
			[Description("FROM_BOTTOM_TO_TOP")]
			FROM_BOTTOM_TO_TOP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_TOP_TO_BOTTOM")]
			[Description("FROM_TOP_TO_BOTTOM")]
			FROM_TOP_TO_BOTTOM,

		}

		/// <summary>
		/// <para>Branches Placement</para>
		/// </summary>
		public enum BranchesPlacementEnum 
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
		/// <para>Orthogonally display edges</para>
		/// </summary>
		public enum AreEdgesOrthogonalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ORTHOGONAL_EDGES")]
			ORTHOGONAL_EDGES,

			/// <summary>
			/// <para></para>
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

#endregion
	}
}
