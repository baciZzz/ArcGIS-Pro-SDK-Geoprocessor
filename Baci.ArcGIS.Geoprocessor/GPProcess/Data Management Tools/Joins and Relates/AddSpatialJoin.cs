using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Add Spatial Join</para>
	/// <para>Add Spatial Join</para>
	/// <para>Joins attributes from one feature to another based on the spatial relationship. The target features and the joined attributes from the join features will be joined.  The join is temporary.</para>
	/// </summary>
	public class AddSpatialJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>The attributes from the target features and the attributes from the joined features will be joined to the target features layer. However, a subset of attributes can be defined using the Field Map parameter.</para>
		/// </param>
		/// <param name="JoinFeatures">
		/// <para>Join Features</para>
		/// <para>The attributes from the join features will be joined to the attributes of the target features. See the explanation of the Join Operation parameter for details on how the aggregation of joined attributes are affected by the type of join operation.</para>
		/// </param>
		public AddSpatialJoin(object TargetFeatures, object JoinFeatures)
		{
			this.TargetFeatures = TargetFeatures;
			this.JoinFeatures = JoinFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Spatial Join</para>
		/// </summary>
		public override string DisplayName() => "Add Spatial Join";

		/// <summary>
		/// <para>Tool Name : AddSpatialJoin</para>
		/// </summary>
		public override string ToolName() => "AddSpatialJoin";

		/// <summary>
		/// <para>Tool Excute Name : management.AddSpatialJoin</para>
		/// </summary>
		public override string ExcuteName() => "management.AddSpatialJoin";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatures, JoinFeatures, OutFeatureClass!, JoinOperation!, JoinType!, FieldMapping!, MatchOption!, SearchRadius!, DistanceFieldName! };

		/// <summary>
		/// <para>Target Features</para>
		/// <para>The attributes from the target features and the attributes from the joined features will be joined to the target features layer. However, a subset of attributes can be defined using the Field Map parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Join Features</para>
		/// <para>The attributes from the join features will be joined to the attributes of the target features. See the explanation of the Join Operation parameter for details on how the aggregation of joined attributes are affected by the type of join operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		public object JoinFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Join Operation</para>
		/// <para>The operation that will join the target features and join features in the output feature class if multiple join features are found that have the same spatial relationship with a single target feature.</para>
		/// <para>Join one to one—If multiple join features are found that have the same spatial relationship with a single target feature, the attributes from the multiple join features will be aggregated using a field map merge rule. For example, if a point target feature is found in two separate polygon join features, the attributes from the two polygons will be aggregated before being transferred to the output point feature class. If one polygon has an attribute value of 3 and the other has a value of 7, and a Sum merge rule is specified, the aggregated value will be 10. This is the default.</para>
		/// <para>Join one to many—If multiple join features are found that have the same spatial relationship with a single target feature, the join will contain multiple copies (records) of the target feature. For example, if a single point target feature is found in two separate polygon join features, the input features layer will contain two copies of the target feature: one record with the attributes of one polygon and another record with the attributes of the other polygon.</para>
		/// <para><see cref="JoinOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinOperation { get; set; } = "JOIN_ONE_TO_ONE";

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// <para>Specifies whether only target features with a spatial relationship with a join feature (known as an inner join) will be preserved or all target features will be preserved, even without a spatial relationship with the join features (known as an outer join).</para>
		/// <para>Checked—All features in the target features layer will be preserved. This is the default.</para>
		/// <para>Unchecked—Only those features in the target features layer with a spatial relationship with a join feature will be preserved.</para>
		/// <para><see cref="JoinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? JoinType { get; set; } = "true";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>The attribute fields that will be in the output with the corresponding field properties and source fields. By default, all fields from the inputs will be included.</para>
		/// <para>Fields can be added, deleted, renamed, and reordered, and you can change their properties.</para>
		/// <para>Merge rules allow you to specify how values from two or more input fields are merged or combined into a single output value. There are several merge rules you can use to determine how the output field will be populated with values.</para>
		/// <para>First—Use the input fields&apos; first value.</para>
		/// <para>Last—Use the input fields&apos; last value.</para>
		/// <para>Join—Concatenate (join) the input field values.</para>
		/// <para>Sum—Calculate the total of the input field values.</para>
		/// <para>Mean—Calculate the mean (average) of the input field values.</para>
		/// <para>Median—Calculate the median (middle) of the input field values.</para>
		/// <para>Mode—Use the value with the highest frequency.</para>
		/// <para>Min—Use the minimum value of all the input field values.</para>
		/// <para>Max—Use the maximum value of all the input field values.</para>
		/// <para>Standard deviation—Use the standard deviation classification method on all the input field values.</para>
		/// <para>Count—Find the number of records included in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		[Category("Fields")]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Match Option</para>
		/// <para>Specifies the criteria that will be used to match rows.</para>
		/// <para>Intersect—The features in the join features will be matched if they intersect a target feature. This is the default. Specify a distance in the Search Radius parameter.</para>
		/// <para>Intersect 3D— The features in the join features will be matched if they intersect a target feature in three-dimensional space (x, y, and z). Specify a distance in the Search Radius parameter.</para>
		/// <para>Within a distance—The features in the join features will be matched if they are within a specified distance of a target feature. Specify a distance in the Search Radius parameter.</para>
		/// <para>Within a distance geodesic—Same as Within a distance except that geodesic distance is used rather than planar distance. Choose this if your data covers a large geographic extent or the coordinate system of the inputs is unsuitable for distance calculations.</para>
		/// <para>Within a distance 3D—The features in the join features will be matched if they are within a specified distance of a target feature in three-dimensional space. Specify a distance in the Search Radius parameter.</para>
		/// <para>Contains—The features in the join features will be matched if a target feature contains them. The target features must be polygons or polylines. For this option, the target features cannot be points, and the join features can only be polygons when the target features are also polygons.</para>
		/// <para>Completely contains—The features in the join features will be matched if a target feature completely contains them. Polygon can completely contain any feature. Point cannot completely contain any feature, not even a point. Polyline can completely contain only polyline and point.</para>
		/// <para>Contains Clementini—This spatial relationship yields the same results as Completely contains with the exception that if the join feature is entirely on the boundary of the target feature (no part is properly inside or outside) the feature will not be matched. Clementini defines the boundary polygon as the line separating inside and outside, the boundary of a line is defined as its end points, and the boundary of a point is always empty.</para>
		/// <para>Within—The features in the join features will be matched if a target feature is within them. It is opposite to Contains. For this option, the target features can only be polygons when the join features are also polygons. Point can be join feature only if point is target.</para>
		/// <para>Completely within—The features in the join features will be matched if a target feature is completely within them. This is opposite to Completely contains.</para>
		/// <para>Within Clementini—The result will be identical to Within except if the entirety of the feature in the join features is on the boundary of the target feature, the feature will not be matched. Clementini defines the boundary polygon as the line separating inside and outside, the boundary of a line is defined as its end points, and the boundary of a point is always empty.</para>
		/// <para>Are identical to—The features in the join features will be matched if they are identical to a target feature. Both join and target feature must be of same shape type—point-to-point, line-to-line, and polygon-to-polygon.</para>
		/// <para>Boundary touches—The features in the join features will be matched if they have a boundary that touches a target feature. When the target and join features are lines or polygons, the boundary of the join feature can only touch the boundary of the target feature and no part of the join feature can cross the boundary of the target feature.</para>
		/// <para>Share a line segment with—The features in the join features will be matched if they share a line segment with a target feature. The join and target features must be lines or polygons.</para>
		/// <para>Crossed by the outline of—The features in the join features will be matched if a target feature is crossed by their outline. The join and target features must be lines or polygons. If polygons are used for the join or target features, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be matched, not lines that share a line segment.</para>
		/// <para>Have their center in—The features in the join features will be matched if a target feature&apos;s center falls within them. The center of the feature is calculated as follows: for polygon and multipoint the geometry&apos;s centroid is used, and for line input the geometry&apos;s midpoint is used. Specify a distance in the Search Radius parameter.</para>
		/// <para>Closest—The feature in the join features that is closest to a target feature is matched. See the usage tip for more information. Specify a distance in the Search Radius parameter.</para>
		/// <para>Closest geodesic—Same as Closest except that geodesic distance is used rather than planar distance. Choose this if your data covers a large geographic extent or the coordinate system of the inputs is unsuitable for distance calculations</para>
		/// <para>Largest overlap—The feature in the join features will be matched with the target feature with the largest overlap.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MatchOption { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>Join features within this distance of a target feature will be considered for the spatial join. A search radius is only valid when the spatial relationship is specified (the Match Option parameter is set to Intersect, Within a distance, Within a distance geodesic, Have their center in, Closest, or Closest geodesic). For example, using a search radius of 100 meters with the Within a distance spatial relationship will join feature within 100 meters of a target feature. For the three Within a distance relationships, if no value is specified for Search Radius, a distance of 0 is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Distance Field Name</para>
		/// <para>The name of a field, which will be added to the join, that contains the distance between the target feature and the closest join feature. This parameter is only valid when the spatial relationship is specified (Match Option is set to Closest or Closest geodesic). The value of this field is -1 if no feature is matched within a search radius. If no field name is specified, the field will not be added to the join.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DistanceFieldName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSpatialJoin SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? configKeyword = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Join Operation</para>
		/// </summary>
		public enum JoinOperationEnum 
		{
			/// <summary>
			/// <para>Join one to one—If multiple join features are found that have the same spatial relationship with a single target feature, the attributes from the multiple join features will be aggregated using a field map merge rule. For example, if a point target feature is found in two separate polygon join features, the attributes from the two polygons will be aggregated before being transferred to the output point feature class. If one polygon has an attribute value of 3 and the other has a value of 7, and a Sum merge rule is specified, the aggregated value will be 10. This is the default.</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_ONE")]
			[Description("Join one to one")]
			Join_one_to_one,

			/// <summary>
			/// <para>Join one to many—If multiple join features are found that have the same spatial relationship with a single target feature, the join will contain multiple copies (records) of the target feature. For example, if a single point target feature is found in two separate polygon join features, the input features layer will contain two copies of the target feature: one record with the attributes of one polygon and another record with the attributes of the other polygon.</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_MANY")]
			[Description("Join one to many")]
			Join_one_to_many,

		}

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// </summary>
		public enum JoinTypeEnum 
		{
			/// <summary>
			/// <para>Checked—All features in the target features layer will be preserved. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para>Unchecked—Only those features in the target features layer with a spatial relationship with a join feature will be preserved.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_COMMON")]
			KEEP_COMMON,

		}

#endregion
	}
}
