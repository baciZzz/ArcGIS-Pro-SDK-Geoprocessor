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
	/// <para>Add Spatial Query Rule</para>
	/// <para>Add Spatial Query Rule</para>
	/// <para>Adds a diagram rule that automatically appends new network features to the diagrams based on their location relative to the network features currently represented in the diagram.</para>
	/// </summary>
	public class AddSpatialQueryRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template that will be modified.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template that will be modified.</para>
		/// </param>
		/// <param name="IsActive">
		/// <para>Active</para>
		/// <para>Specifies whether the rule will be active when generating and updating diagrams based on the specified template.</para>
		/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
		/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </param>
		/// <param name="AddedFeatures">
		/// <para>Add Features</para>
		/// <para>The source feature class to which features will be added.</para>
		/// </param>
		/// <param name="OverlapType">
		/// <para>Relationship</para>
		/// <para>Specifies the spatial relationship between the features.</para>
		/// <para>Intersect— The features in the Add Features source feature class will be appended to the diagram if they intersect one of the Existing Features. This is the default.</para>
		/// <para>Within a distance— The features in the Add Features source feature class will be appended to the diagram if they are within the specified distance (using Euclidean distance) of one of the Existing Features. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Contains | Is contained of— The features in the Add Features source feature class will be appended to the diagram if they contain features from or are contained in the Existing Features.</para>
		/// <para>Within— The features in the Add Features source feature class will be appended to the diagram if they are within Existing Features.</para>
		/// <para>Boundary touches— The features in the Add Features source feature class will be appended to the diagram if they have a boundary that touches one of the Existing Features. When the Existing Features are lines or polygons, the boundary of the Add Features input feature can only touch the boundary of one of the Existing Features, and no part of the input feature can cross the boundary of one of the Existing Features.</para>
		/// <para>Share a line segment with— The features in the Add Features source feature class will be appended to the diagram if they share a line segment with one of the Existing Features. The added and existing features must be line or polygon.</para>
		/// <para>Crossed by the outline of— The features in the Add Features source feature class will be appended to the diagram if they are crossed by the outline of one of the Existing Features. The added and existing features must be lines or polygons. If polygons are used for the Existing Features, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be appended; lines that share a line segment will not.</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </param>
		/// <param name="ExistingFeatures">
		/// <para>Existing Features</para>
		/// <para>The source feature class on which the spatial query will execute.</para>
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
		public override string DisplayName() => "Add Spatial Query Rule";

		/// <summary>
		/// <para>Tool Name : AddSpatialQueryRule</para>
		/// </summary>
		public override string ToolName() => "AddSpatialQueryRule";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddSpatialQueryRule</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddSpatialQueryRule";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, IsActive, AddedFeatures, OverlapType, ExistingFeatures, SearchDistance!, AddedWhereClause!, ExistingWhereClause!, Description!, OutUtilityNetwork!, OutTemplateName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network containing the diagram template that will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template that will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Active</para>
		/// <para>Specifies whether the rule will be active when generating and updating diagrams based on the specified template.</para>
		/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
		/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
		/// <para><see cref="IsActiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsActive { get; set; } = "true";

		/// <summary>
		/// <para>Add Features</para>
		/// <para>The source feature class to which features will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object AddedFeatures { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>Specifies the spatial relationship between the features.</para>
		/// <para>Intersect— The features in the Add Features source feature class will be appended to the diagram if they intersect one of the Existing Features. This is the default.</para>
		/// <para>Within a distance— The features in the Add Features source feature class will be appended to the diagram if they are within the specified distance (using Euclidean distance) of one of the Existing Features. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Contains | Is contained of— The features in the Add Features source feature class will be appended to the diagram if they contain features from or are contained in the Existing Features.</para>
		/// <para>Within— The features in the Add Features source feature class will be appended to the diagram if they are within Existing Features.</para>
		/// <para>Boundary touches— The features in the Add Features source feature class will be appended to the diagram if they have a boundary that touches one of the Existing Features. When the Existing Features are lines or polygons, the boundary of the Add Features input feature can only touch the boundary of one of the Existing Features, and no part of the input feature can cross the boundary of one of the Existing Features.</para>
		/// <para>Share a line segment with— The features in the Add Features source feature class will be appended to the diagram if they share a line segment with one of the Existing Features. The added and existing features must be line or polygon.</para>
		/// <para>Crossed by the outline of— The features in the Add Features source feature class will be appended to the diagram if they are crossed by the outline of one of the Existing Features. The added and existing features must be lines or polygons. If polygons are used for the Existing Features, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be appended; lines that share a line segment will not.</para>
		/// <para><see cref="OverlapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Existing Features</para>
		/// <para>The source feature class on which the spatial query will execute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object ExistingFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance between features in the Existing Features parameter and features in the Add Features parameter. This parameter is only valid if the Relationship parameter is set to Intersect, Within a distance, Contains, or Within</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Added Features Query Definition</para>
		/// <para>The SQL query that will be used to filter the features to be added to the diagram. Without an SQL query, the features based on the specified source class that are spatially related to the specified existing features will be appended to the diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? AddedWhereClause { get; set; }

		/// <summary>
		/// <para>Existing Features Query Definition</para>
		/// <para>The SQL query that will be used to filter the features existing in the diagram. Without an SQL query, the features based on the specified source class that exist in the diagram will be considered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? ExistingWhereClause { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the rule.</para>
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
			/// <para>Checked—The added rule will become active during the generation and update of any diagrams based on the input template. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ACTIVE")]
			ACTIVE,

			/// <summary>
			/// <para>Unchecked—The added rule will not become active during the generation or update of any diagrams based on the input template.</para>
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
			/// <para>Intersect— The features in the Add Features source feature class will be appended to the diagram if they intersect one of the Existing Features. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Within a distance— The features in the Add Features source feature class will be appended to the diagram if they are within the specified distance (using Euclidean distance) of one of the Existing Features. Use the Search Distance parameter to specify the distance.</para>
			/// </summary>
			[GPValue("WITHIN_A_DISTANCE")]
			[Description("Within a distance")]
			Within_a_distance,

			/// <summary>
			/// <para>Contains | Is contained of— The features in the Add Features source feature class will be appended to the diagram if they contain features from or are contained in the Existing Features.</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("Contains | Is contained of")]
			CONTAINS,

			/// <summary>
			/// <para>Within a distance— The features in the Add Features source feature class will be appended to the diagram if they are within the specified distance (using Euclidean distance) of one of the Existing Features. Use the Search Distance parameter to specify the distance.</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("Within")]
			Within,

			/// <summary>
			/// <para>Boundary touches— The features in the Add Features source feature class will be appended to the diagram if they have a boundary that touches one of the Existing Features. When the Existing Features are lines or polygons, the boundary of the Add Features input feature can only touch the boundary of one of the Existing Features, and no part of the input feature can cross the boundary of one of the Existing Features.</para>
			/// </summary>
			[GPValue("BOUNDARY_TOUCHES")]
			[Description("Boundary touches")]
			Boundary_touches,

			/// <summary>
			/// <para>Share a line segment with— The features in the Add Features source feature class will be appended to the diagram if they share a line segment with one of the Existing Features. The added and existing features must be line or polygon.</para>
			/// </summary>
			[GPValue("SHARE_A_LINE_SEGMENT_WITH")]
			[Description("Share a line segment with")]
			Share_a_line_segment_with,

			/// <summary>
			/// <para>Crossed by the outline of— The features in the Add Features source feature class will be appended to the diagram if they are crossed by the outline of one of the Existing Features. The added and existing features must be lines or polygons. If polygons are used for the Existing Features, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be appended; lines that share a line segment will not.</para>
			/// </summary>
			[GPValue("CROSSED_BY_THE_OUTLINE_OF")]
			[Description("Crossed by the outline of")]
			Crossed_by_the_outline_of,

		}

#endregion
	}
}
