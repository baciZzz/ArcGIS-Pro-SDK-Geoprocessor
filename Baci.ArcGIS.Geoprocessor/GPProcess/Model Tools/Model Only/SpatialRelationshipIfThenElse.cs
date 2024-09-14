using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Spatial Relationship Is</para>
	/// <para>If Spatial Relationship Is</para>
	/// <para>Evaluates whether the inputs have a specified spatial relationship.</para>
	/// </summary>
	public class SpatialRelationshipIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features to evaluate.</para>
		/// </param>
		/// <param name="SelectionCondition">
		/// <para>Selection Condition</para>
		/// <para>Specifies the selection condition that will be used for the spatial relationship between the input and selecting features.</para>
		/// <para>Exists—Checks if the spatial relationship exists between any features in the input and selecting features. This is the default.</para>
		/// <para>No Selection—Checks if the spatial relationship does not exist between any of the input and selecting features.</para>
		/// <para>All Selected—Checks if the spatial relationship exists for all features in the input features.</para>
		/// <para>Is Equal to—Checks if the number of input features with the spatial relationship is equal to the Count value.</para>
		/// <para>Is Between—Checks if the number of input features with the spatial relationship is between the Minimum Count value and Maximum Count value.</para>
		/// <para>Is Less Than—Checks if the number of input features with the spatial relationship is less than the Count value.</para>
		/// <para>Is Greater Than—Checks if the field value of the records matching the SQL expression is greater than the Count value.</para>
		/// <para>Is Not Equal to—Checks if the number of input features with the spatial relationship is not equal to the Count value.</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </param>
		public SpatialRelationshipIfThenElse(object InFeatures, object SelectionCondition)
		{
			this.InFeatures = InFeatures;
			this.SelectionCondition = SelectionCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : If Spatial Relationship Is</para>
		/// </summary>
		public override string DisplayName() => "If Spatial Relationship Is";

		/// <summary>
		/// <para>Tool Name : SpatialRelationshipIfThenElse</para>
		/// </summary>
		public override string ToolName() => "SpatialRelationshipIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.SpatialRelationshipIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.SpatialRelationshipIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OverlapType, SelectFeatures, SearchDistance, InvertSpatialRelationship, SelectionCondition, Count, CountMin, CountMax, True, False };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to evaluate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>Specifies the spatial relationship to be evaluated.</para>
		/// <para>Intersect—The features in the input layer will be selected if they intersect a selecting feature. This is the default.</para>
		/// <para>Intersect 3D—The features in the input layer will be selected if they intersect a selecting feature in three-dimensional space (x, y, and z).</para>
		/// <para>Within a distance—The features in the input layer will be selected if they are within the specified distance (using Euclidean distance) of a selecting feature. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Within a distance 3D—The features in the input layer will be selected if they are within a specified distance of a selecting feature in three-dimensional space. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Within a distance geodesic—The features in the input layer will be selected if they are within a specified distance of a selecting feature. Distance between features will be calculated using a geodesic formula that takes into account the curvature of the spheroid and correctly handles data near and across the dateline and poles. Use the Search Distance parameter to specify the distance.</para>
		/// <para>Contains—The features in the input layer will be selected if they contain a selecting feature.</para>
		/// <para>Completely contains—The features in the input layer will be selected if they completely contain a selecting feature.</para>
		/// <para>Contains Clementini—This spatial relationship yields the same results as Completely contains with the exception that if the selecting feature is entirely on the boundary of the input feature (no part is properly inside or outside), the feature will not be selected. Clementini defines the boundary polygon as the line separating inside and outside, the boundary of a line is defined as its end points, and the boundary of a point is always empty.</para>
		/// <para>Within—The features in the input layer will be selected if they are within a selecting feature.</para>
		/// <para>Completely within—The features in the input layer will be selected if they are completely within or contained by a selecting feature.</para>
		/// <para>Within Clementini—The result will be identical to Within with the exception that if the entirety of the feature in the input layer is on the boundary of the feature in the selecting layer, the feature will not be selected. Clementini defines the boundary polygon as the line separating inside and outside, the boundary of a line is defined as its end points, and the boundary of a point is always empty.</para>
		/// <para>Are identical to—The features in the input layer will be selected if they are identical (in geometry) to a selecting feature.</para>
		/// <para>Boundary touches—The features in the input layer will be selected if they have a boundary that touches a selecting feature. When the input features are lines or polygons, the boundary of the input feature can only touch the boundary of the selecting feature, and no part of the input feature can cross the boundary of the selecting feature.</para>
		/// <para>Share a line segment with—The features in the input layer will be selected if they share a line segment with a selecting feature. The input and selecting features must be line or polygon.</para>
		/// <para>Crossed by the outline of—The features in the input layer will be selected if they are crossed by the outline of a selecting feature. The input and selecting features must be lines or polygons. If polygons are used for the input or selecting layer, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be selected; lines that share a line segment will not be selected.</para>
		/// <para>Have their center in—The features in the input layer will be selected if their center falls within a selecting feature. The center of the feature is calculated as follows: for polygon and multipoint, the geometry&apos;s centroid is used; for line input, the geometry&apos;s midpoint is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Selecting Features</para>
		/// <para>The features in the Input Features parameter will be selected based on their relationship to the features from this layer or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object SelectFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance that will be searched. This parameter is only valid if the Relationship parameter is set to Within a distance, Within a distance geodesic, Within a distance 3D, Intersect, Intersect 3D, Have their center in, or Contains.</para>
		/// <para>If the Within a distance geodesic option is selected, use a linear unit such as kilometers or miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Invert spatial relationship</para>
		/// <para>Specifies whether the spatial relationship evaluation result or the opposite result will be used. For example, this parameter can be used to get a list of features that do not intersect or are not within a given distance of features in another dataset.</para>
		/// <para>Unchecked—The query result will be used. This is the default.</para>
		/// <para>Checked—The opposite of the query result will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
		/// <para><see cref="InvertSpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InvertSpatialRelationship { get; set; } = "false";

		/// <summary>
		/// <para>Selection Condition</para>
		/// <para>Specifies the selection condition that will be used for the spatial relationship between the input and selecting features.</para>
		/// <para>Exists—Checks if the spatial relationship exists between any features in the input and selecting features. This is the default.</para>
		/// <para>No Selection—Checks if the spatial relationship does not exist between any of the input and selecting features.</para>
		/// <para>All Selected—Checks if the spatial relationship exists for all features in the input features.</para>
		/// <para>Is Equal to—Checks if the number of input features with the spatial relationship is equal to the Count value.</para>
		/// <para>Is Between—Checks if the number of input features with the spatial relationship is between the Minimum Count value and Maximum Count value.</para>
		/// <para>Is Less Than—Checks if the number of input features with the spatial relationship is less than the Count value.</para>
		/// <para>Is Greater Than—Checks if the field value of the records matching the SQL expression is greater than the Count value.</para>
		/// <para>Is Not Equal to—Checks if the number of input features with the spatial relationship is not equal to the Count value.</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCondition { get; set; } = "EXISTS";

		/// <summary>
		/// <para>Count</para>
		/// <para>The integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Count { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Count</para>
		/// <para>The minimum integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CountMin { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Count</para>
		/// <para>The maximum integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CountMax { get; set; } = "0";

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Invert spatial relationship</para>
		/// </summary>
		public enum InvertSpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>Checked—The opposite of the query result will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para>Unchecked—The query result will be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INVERT")]
			NOT_INVERT,

		}

		/// <summary>
		/// <para>Selection Condition</para>
		/// </summary>
		public enum SelectionConditionEnum 
		{
			/// <summary>
			/// <para>Exists—Checks if the spatial relationship exists between any features in the input and selecting features. This is the default.</para>
			/// </summary>
			[GPValue("EXISTS")]
			[Description("Exists")]
			Exists,

			/// <summary>
			/// <para>No Selection—Checks if the spatial relationship does not exist between any of the input and selecting features.</para>
			/// </summary>
			[GPValue("NO_SELECTION")]
			[Description("No Selection")]
			No_Selection,

			/// <summary>
			/// <para>All Selected—Checks if the spatial relationship exists for all features in the input features.</para>
			/// </summary>
			[GPValue("ALL_SELECTED")]
			[Description("All Selected")]
			All_Selected,

			/// <summary>
			/// <para>Is Equal to—Checks if the number of input features with the spatial relationship is equal to the Count value.</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("Is Equal to")]
			Is_Equal_to,

			/// <summary>
			/// <para>Is Between—Checks if the number of input features with the spatial relationship is between the Minimum Count value and Maximum Count value.</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("Is Between")]
			Is_Between,

			/// <summary>
			/// <para>Is Less Than—Checks if the number of input features with the spatial relationship is less than the Count value.</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("Is Less Than")]
			Is_Less_Than,

			/// <summary>
			/// <para>Is Greater Than—Checks if the field value of the records matching the SQL expression is greater than the Count value.</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("Is Greater Than")]
			Is_Greater_Than,

			/// <summary>
			/// <para>Is Not Equal to—Checks if the number of input features with the spatial relationship is not equal to the Count value.</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("Is Not Equal to")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
