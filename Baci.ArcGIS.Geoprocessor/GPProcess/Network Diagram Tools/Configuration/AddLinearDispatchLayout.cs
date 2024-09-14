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
	/// <para>Add Linear Dispatch Layout</para>
	/// <para>Add Linear Dispatch Layout</para>
	/// <para>Adds the Linear Dispatch Layout algorithm to the list of layouts to be automatically chained at the end of the building of diagrams based on a given template. This tool also presets the Linear Dispatch Layout algorithm parameters for any diagram based on that template.</para>
	/// </summary>
	public class AddLinearDispatchLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template to modify.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>Specifies whether the layout algorithm will automatically execute when generating diagrams based on the specified template.</para>
		/// <para>Checked—The added layout algorithm will automatically run during the generation of any diagram that is based on the Input Diagram Template parameter. This is the default.The parameter values specified for the layout algorithm are used to run the layout during diagram generation. They are also loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para>Unchecked—All the parameter values currently specified for the added layout algorithm will be loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
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
		/// <para>Tool Excute Name : nd.AddLinearDispatchLayout</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddLinearDispatchLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, JunctionPlacementType, IsUnitAbsolute, MaximumShiftAbsolute, MaximumShiftProportional, MinimumShiftAbsolute, MinimumShiftProportional, IterationsNumber, IsPathPreserved, AreLeavesMoved, AreLeavesExpanded, ExpandShiftAbsolute, ExpandShiftProportional, OutUtilityNetwork, OutTemplateName };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template to modify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to modify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>Specifies whether the layout algorithm will automatically execute when generating diagrams based on the specified template.</para>
		/// <para>Checked—The added layout algorithm will automatically run during the generation of any diagram that is based on the Input Diagram Template parameter. This is the default.The parameter values specified for the layout algorithm are used to run the layout during diagram generation. They are also loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para>Unchecked—All the parameter values currently specified for the added layout algorithm will be loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Junctions Placement</para>
		/// <para>Specifies how the junctions will be moved.</para>
		/// <para>Equal distance—All junctions with two connected edges will be moved so the distances between them and their two connected junctions are equal. This is the default.</para>
		/// <para>User define distance—All junctions with two connected edges will be moved so there is a minimum distance (Minimum Shift parameter value) between them and the other end of the edges to which they connect. This occurs at the end of the layout execution.</para>
		/// <para>Iterative distance—All junctions with two connected edges will be moved slightly according to the Number of Iterations and Maximum Shift parameter values.</para>
		/// <para><see cref="JunctionPlacementTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JunctionPlacementType { get; set; } = "EQUAL_DISTANCE";

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
		public object IsUnitAbsolute { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Shift</para>
		/// <para>The maximum distance the junctions with two connections will be spaced from the junctions to which they connect. The default is 2 in the units of the diagram's coordinate system. At the time this distance is reached, junctions will not be moved during following iterations. This parameter can only be used with the Iterative distance junction placement type and absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaximumShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Maximum Shift</para>
		/// <para>The maximum distance the junctions with two connections will be spaced from the junctions to which they connect. The default is 2. At the time this distance is reached, junctions will not be moved during following iterations. This parameter can only be used with the Iterative distance junction placement type and proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Minimum Shift</para>
		/// <para>The minimum distance that will separate each junction with two connected edges from its two edge extremities after the layout execution. The default is 2 in the units of the diagram's coordinate system. When this parameter value is too large, the junctions with two connections are moved so the distances between each moved junction and its edge extremities are equal along the path defined by its two connected edges. This parameter can only be used with the User define distance junction placement type and absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinimumShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Minimum Shift</para>
		/// <para>The minimum distance that will separate each junction with two connected edges from its two edge extremities after the layout execution. The default is 2. When this parameter value is too large, the junctions with two connections are moved so the distances between each moved junction and its edge extremities are equal along the path defined by its two connected edges. This parameter is used with the User define distance junction placement type and proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinimumShiftProportional { get; set; } = "2";

		/// <summary>
		/// <para>Number of Iterations</para>
		/// <para>The number of iterations to process. The default is 5. This parameter can only be used with the Iterative distance junction placement type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object IterationsNumber { get; set; } = "5";

		/// <summary>
		/// <para>Preserve path</para>
		/// <para>Specifies how vertices along edges will be processed.</para>
		/// <para>Checked—All vertices along the connected edges will be preserved, and new vertices will be added at the moved junctions&apos; original locations. This is the default.</para>
		/// <para>Unchecked—Vertices along edges will not be preserved.</para>
		/// <para><see cref="IsPathPreservedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsPathPreserved { get; set; } = "true";

		/// <summary>
		/// <para>Move leaves</para>
		/// <para>Specifies whether leaf junctions—junctions with one connection—will be moved during the algorithm execution.</para>
		/// <para>Checked—Leaf junctions will be moved.</para>
		/// <para>Unchecked—Leaf junctions will not be moved. This is the default unless the specified input network diagram is based on a template for which the Linear Dispatch Layout algorithm has been configured with another parameter value.</para>
		/// <para><see cref="AreLeavesMovedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreLeavesMoved { get; set; } = "false";

		/// <summary>
		/// <para>Expand leaves</para>
		/// <para>Specifies whether leaf junctions will be expanded.</para>
		/// <para>Checked—Leaf junctions will be expanded. The Maximum Expand Shift parameter value specifies the maximum distance the leaf junctions can be expanded from the junctions to which they connect.</para>
		/// <para>Unchecked—Leaf junctions will not be expanded. This is the default unless the specified input network diagram is based on a template for which the Linear Dispatch Layout algorithm has been configured with another parameter value.</para>
		/// <para><see cref="AreLeavesExpandedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreLeavesExpanded { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Expand Shift</para>
		/// <para>The maximum distance leaf junctions will be expanded from the junctions to which they connect. The default is 2 in the units of the diagram's coordinate system unless the specified input network diagram is based on a template for which the Linear Dispatch Layout algorithm has been configured with another parameter value. At the time this distance is reached, leaf junctions will not be moved during following iterations. This parameter can only be used with the Expand leaves parameter and absolute units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ExpandShiftAbsolute { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Maximum Expand Shift</para>
		/// <para>The maximum distance the leaf junctions will be expanded from the junctions to which they connect. The default is 2 unless the specified input network diagram is based on a template for which the Linear Dispatch Layout algorithm has been configured with another parameter value. At the time this distance is reached, leaf junctions will not be moved during following iterations. This parameter can only be used with the Expand leaves parameter and proportional units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ExpandShiftProportional { get; set; } = "2";

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

		#region InnerClass

		/// <summary>
		/// <para>Active</para>
		/// </summary>
		public enum IsActiveEnum 
		{
			/// <summary>
			/// <para>Checked—The added layout algorithm will automatically run during the generation of any diagram that is based on the Input Diagram Template parameter. This is the default.The parameter values specified for the layout algorithm are used to run the layout during diagram generation. They are also loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para>Unchecked—All the parameter values currently specified for the added layout algorithm will be loaded by default when the algorithm is to be run on any diagram based on the input template.</para>
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
			/// <para>Equal distance—All junctions with two connected edges will be moved so the distances between them and their two connected junctions are equal. This is the default.</para>
			/// </summary>
			[GPValue("EQUAL_DISTANCE")]
			[Description("Equal distance")]
			Equal_distance,

			/// <summary>
			/// <para>User define distance—All junctions with two connected edges will be moved so there is a minimum distance (Minimum Shift parameter value) between them and the other end of the edges to which they connect. This occurs at the end of the layout execution.</para>
			/// </summary>
			[GPValue("USER_DEFINE_DISTANCE")]
			[Description("User define distance")]
			User_define_distance,

			/// <summary>
			/// <para>Iterative distance—All junctions with two connected edges will be moved slightly according to the Number of Iterations and Maximum Shift parameter values.</para>
			/// </summary>
			[GPValue("ITERATIVE_DISTANCE")]
			[Description("Iterative distance")]
			Iterative_distance,

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
		/// <para>Preserve path</para>
		/// </summary>
		public enum IsPathPreservedEnum 
		{
			/// <summary>
			/// <para>Checked—All vertices along the connected edges will be preserved, and new vertices will be added at the moved junctions&apos; original locations. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_PATH")]
			PRESERVE_PATH,

			/// <summary>
			/// <para>Unchecked—Vertices along edges will not be preserved.</para>
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
			/// <para>Checked—Leaf junctions will be moved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MOVE_LEAVES")]
			MOVE_LEAVES,

			/// <summary>
			/// <para>Unchecked—Leaf junctions will not be moved. This is the default unless the specified input network diagram is based on a template for which the Linear Dispatch Layout algorithm has been configured with another parameter value.</para>
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
			/// <para>Checked—Leaf junctions will be expanded. The Maximum Expand Shift parameter value specifies the maximum distance the leaf junctions can be expanded from the junctions to which they connect.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPAND_LEAVES")]
			EXPAND_LEAVES,

			/// <summary>
			/// <para>Unchecked—Leaf junctions will not be expanded. This is the default unless the specified input network diagram is based on a template for which the Linear Dispatch Layout algorithm has been configured with another parameter value.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EXPAND_LEAVES")]
			DO_NOT_EXPAND_LEAVES,

		}

#endregion
	}
}
