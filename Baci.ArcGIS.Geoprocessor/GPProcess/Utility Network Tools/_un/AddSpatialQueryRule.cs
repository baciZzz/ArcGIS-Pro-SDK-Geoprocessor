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
	/// <para>Add Spatial Query Rule</para>
	/// <para>Add a spatial query rule to a diagram template</para>
	/// </summary>
	[Obsolete()]
	public class AddSpatialQueryRule : AbstractGPProcess
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
		/// <param name="AddedFeatures">
		/// <para>Add Features</para>
		/// </param>
		/// <param name="OverlapType">
		/// <para>Relationship</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </param>
		/// <param name="ExistingFeatures">
		/// <para>Existing Features</para>
		/// </param>
		public AddSpatialQueryRule(object InUtilityNetwork, object TemplateName, object IsActive, object AddedFeatures, object OverlapType, object ExistingFeatures)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
			this.IsActive = IsActive;
			this.AddedFeatures = AddedFeatures;
			this.OverlapType = OverlapType;
			this.ExistingFeatures = ExistingFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Spatial Query Rule</para>
		/// </summary>
		public override string DisplayName => "Add Spatial Query Rule";

		/// <summary>
		/// <para>Tool Name : AddSpatialQueryRule</para>
		/// </summary>
		public override string ToolName => "AddSpatialQueryRule";

		/// <summary>
		/// <para>Tool Excute Name : un.AddSpatialQueryRule</para>
		/// </summary>
		public override string ExcuteName => "un.AddSpatialQueryRule";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, TemplateName, IsActive, AddedFeatures, OverlapType, ExistingFeatures, SearchDistance!, AddedWhereClause!, ExistingWhereClause!, Description!, OutUtilityNetwork!, OutTemplateName! };

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
		/// <para>Add Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object AddedFeatures { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Existing Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object ExistingFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Added Features Query Definition</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? AddedWhereClause { get; set; }

		/// <summary>
		/// <para>Existing Features Query Definition</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? ExistingWhereClause { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

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
		/// <para>Relationship</para>
		/// </summary>
		public enum OverlapTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("INTERSECT")]
			INTERSECT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WITHIN_A_DISTANCE")]
			[Description("WITHIN_A_DISTANCE")]
			WITHIN_A_DISTANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("CONTAINS")]
			CONTAINS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("WITHIN")]
			WITHIN,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BOUNDARY_TOUCHES")]
			[Description("BOUNDARY_TOUCHES")]
			BOUNDARY_TOUCHES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SHARE_A_LINE_SEGMENT_WITH")]
			[Description("SHARE_A_LINE_SEGMENT_WITH")]
			SHARE_A_LINE_SEGMENT_WITH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CROSSED_BY_THE_OUTLINE_OF")]
			[Description("CROSSED_BY_THE_OUTLINE_OF")]
			CROSSED_BY_THE_OUTLINE_OF,

		}

#endregion
	}
}
