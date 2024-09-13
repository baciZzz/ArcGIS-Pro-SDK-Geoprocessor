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
	/// <para>Add Linear Dispatch Layout</para>
	/// <para>Add Linear Dispatch Layout</para>
	/// <para>Add a linear dispatch layout to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddLinearDispatchLayout : AbstractGPProcess
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
		public AddLinearDispatchLayout(object InUtilityNetwork, object TemplateName, object IsActive)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Linear Dispatch Layout</para>
		/// </summary>
		public override string DisplayName() => "Add Linear Dispatch Layout";

		/// <summary>
		/// <para>Tool Name : AddLinearDispatchLayout</para>
		/// </summary>
		public override string ToolName() => "AddLinearDispatchLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.AddLinearDispatchLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.AddLinearDispatchLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, JunctionPlacementType!, IsUnitAbsolute!, MaximumShiftAbsolute!, MaximumShiftProportional!, MinimumShiftAbsolute!, MinimumShiftProportional!, IterationsNumber!, IsPathPreserved!, AreLeavesMoved!, AreLeavesExpanded!, ExpandShiftAbsolute!, ExpandShiftProportional!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Junctions Placement</para>
		/// <para><see cref="JunctionPlacementTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JunctionPlacementType { get; set; } = "EQUAL_DISTANCE";

		/// <summary>
		/// <para>Spacing values interpreted as absolute units in the diagram coordinate system</para>
		/// <para><see cref="IsUnitAbsoluteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Shift</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaximumShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Maximum Shift</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Minimum Shift</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Minimum Shift</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? IterationsNumber { get; set; } = "5";

		/// <summary>
		/// <para>Preserve path</para>
		/// <para><see cref="IsPathPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsPathPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Move leaves</para>
		/// <para><see cref="AreLeavesMovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreLeavesMoved { get; set; } = "false";

		/// <summary>
		/// <para>Expand leaves</para>
		/// <para><see cref="AreLeavesExpandedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreLeavesExpanded { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Expand Shift</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ExpandShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Maximum Expand Shift</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ExpandShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

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
		/// <para>Junctions Placement</para>
		/// </summary>
		public enum JunctionPlacementTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EQUAL_DISTANCE")]
			[Description("EQUAL_DISTANCE")]
			EQUAL_DISTANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("USER_DEFINE_DISTANCE")]
			[Description("USER_DEFINE_DISTANCE")]
			USER_DEFINE_DISTANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ITERATIVE_DISTANCE")]
			[Description("ITERATIVE_DISTANCE")]
			ITERATIVE_DISTANCE,

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
		/// <para>Move leaves</para>
		/// </summary>
		public enum AreLeavesMovedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MOVE_LEAVES")]
			MOVE_LEAVES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_MOVE_LEAVES")]
			DO_NOT_MOVE_LEAVES,

		}

		/// <summary>
		/// <para>Expand leaves</para>
		/// </summary>
		public enum AreLeavesExpandedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPAND_LEAVES")]
			EXPAND_LEAVES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EXPAND_LEAVES")]
			DO_NOT_EXPAND_LEAVES,

		}

#endregion
	}
}
