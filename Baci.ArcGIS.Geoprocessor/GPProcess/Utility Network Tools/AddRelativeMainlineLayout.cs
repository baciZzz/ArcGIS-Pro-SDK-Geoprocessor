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
	/// <para>Add Relative Mainline Layout</para>
	/// <para>Add Relative Mainline Layout</para>
	/// <para>Add the relative mainline layout to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddRelativeMainlineLayout : AbstractGPProcess
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
		/// <param name="LineAttribute">
		/// <para>Line Attribute</para>
		/// </param>
		public AddRelativeMainlineLayout(object InUtilityNetwork, object TemplateName, object IsActive, object LineAttribute)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.LineAttribute = LineAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Relative Mainline Layout</para>
		/// </summary>
		public override string DisplayName() => "Add Relative Mainline Layout";

		/// <summary>
		/// <para>Tool Name : AddRelativeMainlineLayout</para>
		/// </summary>
		public override string ToolName() => "AddRelativeMainlineLayout";

		/// <summary>
		/// <para>Tool Excute Name : un.AddRelativeMainlineLayout</para>
		/// </summary>
		public override string ExcuteName() => "un.AddRelativeMainlineLayout";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, LineAttribute, MainlineDirection!, OffsetBetweenBranches!, BreakpointAngle!, TypeAttribute!, MainlineValues!, BranchValues!, ExcludedValues!, IsCompressing!, CompressionRatio!, MinimalDistance!, AlignmentAttribute!, InitialDistances!, LengthAttribute!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Line Attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LineAttribute { get; set; }

		/// <summary>
		/// <para>Direction</para>
		/// <para><see cref="MainlineDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MainlineDirection { get; set; } = "FROM_LEFT_TO_RIGHT";

		/// <summary>
		/// <para>Offset Between Branches</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? OffsetBetweenBranches { get; set; } = "2 Unknown";

		/// <summary>
		/// <para>Break Point angle (in degree)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BreakpointAngle { get; set; } = "45";

		/// <summary>
		/// <para>Type Attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Line Classification")]
		public object? TypeAttribute { get; set; }

		/// <summary>
		/// <para>Mainline Values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object? MainlineValues { get; set; }

		/// <summary>
		/// <para>Branch Values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object? BranchValues { get; set; }

		/// <summary>
		/// <para>Excluded Values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Line Classification")]
		public object? ExcludedValues { get; set; }

		/// <summary>
		/// <para>Compression along the direction</para>
		/// <para><see cref="IsCompressingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Compression")]
		public object? IsCompressing { get; set; } = "false";

		/// <summary>
		/// <para>Ratio (%)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Line Compression")]
		public object? CompressionRatio { get; set; } = "0";

		/// <summary>
		/// <para>Minimal Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Line Compression")]
		public object? MinimalDistance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Alignment Attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? AlignmentAttribute { get; set; }

		/// <summary>
		/// <para>Initial Distances</para>
		/// <para><see cref="InitialDistancesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? InitialDistances { get; set; } = "FROM_CURRENT_EDGE_GEOMETRY";

		/// <summary>
		/// <para>Length Attribute</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object? LengthAttribute { get; set; }

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
		/// <para>Direction</para>
		/// </summary>
		public enum MainlineDirectionEnum 
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
			[GPValue("FROM_TOP_TO_BOTTOM")]
			[Description("FROM_TOP_TO_BOTTOM")]
			FROM_TOP_TO_BOTTOM,

		}

		/// <summary>
		/// <para>Compression along the direction</para>
		/// </summary>
		public enum IsCompressingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_COMPRESSION")]
			USE_COMPRESSION,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("FROM_CURRENT_EDGE_GEOMETRY")]
			[Description("FROM_CURRENT_EDGE_GEOMETRY")]
			FROM_CURRENT_EDGE_GEOMETRY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_ATTRIBUTE_EDGE")]
			[Description("FROM_ATTRIBUTE_EDGE")]
			FROM_ATTRIBUTE_EDGE,

		}

#endregion
	}
}
