using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Join Features</para>
	/// <para>Joins attributes from one layer to another based on spatial, temporal, or attribute relationships, or a combination of those relationships.</para>
	/// </summary>
	public class JoinFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetLayer">
		/// <para>Target Layer</para>
		/// <para>Contains the target features. The attributes from the target features and the attributes from the joined features will be transferred to the output.</para>
		/// </param>
		/// <param name="JoinLayer">
		/// <para>Join Layer</para>
		/// <para>Contains the join features. The attributes from the join features will be joined to the attributes of the target features. See the explanation of the Join Operation (join_operation in Python) parameter for details about how the aggregation of joined attributes are affected by the type of join operation.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="JoinOperation">
		/// <para>Join Operation</para>
		/// <para>Specifies how joins between the Target Layer values and the Join Layer values will be handled in the output if multiple join features are found that have the same spatial relationship with a single target feature.</para>
		/// <para>Join one to one—The attributes from the multiple join features will be aggregated. For example, if a point target feature is found in two separate polygon join features, the attributes from the two polygons will be aggregated before being transferred to the output point feature class. If one polygon has an attribute value of 3 and the other has a value of 7, and the summary statistic sum is specified for that field, the aggregated value in the output feature class will be 10. This is the default, and only the count statistic is returned.</para>
		/// <para>Join one to many—The output feature class will contain multiple copies (records) of the target feature. For example, if a single-point target feature is found in two separate polygon join features, the output feature class will contain two copies of the target feature: one record with the attributes of one polygon and another record with the attributes of the other polygon. There are no summary statistics available with this method.</para>
		/// <para><see cref="JoinOperationEnum"/></para>
		/// </param>
		public JoinFeatures(object TargetLayer, object JoinLayer, object OutputName, object JoinOperation)
		{
			this.TargetLayer = TargetLayer;
			this.JoinLayer = JoinLayer;
			this.OutputName = OutputName;
			this.JoinOperation = JoinOperation;
		}

		/// <summary>
		/// <para>Tool Display Name : Join Features</para>
		/// </summary>
		public override string DisplayName => "Join Features";

		/// <summary>
		/// <para>Tool Name : JoinFeatures</para>
		/// </summary>
		public override string ToolName => "JoinFeatures";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.JoinFeatures</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.JoinFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { TargetLayer, JoinLayer, OutputName, JoinOperation, SpatialRelationship, SpatialNearDistance, TemporalRelationship, TemporalNearDistance, AttributeRelationship, SummaryFields, JoinCondition, Output, DataStore, KeepAllTargetFeatures };

		/// <summary>
		/// <para>Target Layer</para>
		/// <para>Contains the target features. The attributes from the target features and the attributes from the joined features will be transferred to the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object TargetLayer { get; set; }

		/// <summary>
		/// <para>Join Layer</para>
		/// <para>Contains the join features. The attributes from the join features will be joined to the attributes of the target features. See the explanation of the Join Operation (join_operation in Python) parameter for details about how the aggregation of joined attributes are affected by the type of join operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object JoinLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Join Operation</para>
		/// <para>Specifies how joins between the Target Layer values and the Join Layer values will be handled in the output if multiple join features are found that have the same spatial relationship with a single target feature.</para>
		/// <para>Join one to one—The attributes from the multiple join features will be aggregated. For example, if a point target feature is found in two separate polygon join features, the attributes from the two polygons will be aggregated before being transferred to the output point feature class. If one polygon has an attribute value of 3 and the other has a value of 7, and the summary statistic sum is specified for that field, the aggregated value in the output feature class will be 10. This is the default, and only the count statistic is returned.</para>
		/// <para>Join one to many—The output feature class will contain multiple copies (records) of the target feature. For example, if a single-point target feature is found in two separate polygon join features, the output feature class will contain two copies of the target feature: one record with the attributes of one polygon and another record with the attributes of the other polygon. There are no summary statistics available with this method.</para>
		/// <para><see cref="JoinOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinOperation { get; set; } = "JOIN_ONE_TO_ONE";

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>Specifies the criteria that will be used to spatially join features.</para>
		/// <para>Intersects—The features in the join features will be matched if they intersect a target feature. This is the default.</para>
		/// <para>Equals— The features in the join features will be matched if they are the same geometry as a target feature.</para>
		/// <para>Planar Near—The features in the join features will be matched if they are within a specified distance of a target feature. The distance is measured using planar distance. Specify a distance in the Spatial Near Distance parameter.</para>
		/// <para>Geodesic Near—The features in the join features will be matched if they are within a specified distance of a target feature. The distance is measured geodesically. Specify a distance in the Spatial Near Distance parameter. This option is available with ArcGIS Enterprise 10.7 or later.</para>
		/// <para>Contains—The features in the join features will be matched if a target feature contains them. The target features must be polygons or polylines. The join features can only be polygons when the target features are also polygons. A polygon can contain any feature type. A polyline can contain only polylines and points. A point cannot contain any feature, not even a point. If the join feature is entirely on the boundary of the target feature (no part is properly inside or outside), the feature will not be matched.</para>
		/// <para>Within—The features in the join features will be matched if a target feature is within them. It is the opposite of the contains relationship. For this option, the target features can only be polygons when the join features are also polygons. A point can be a join feature only if a point is also a target feature. If the entirety of the feature in the join features is on the boundary of the target feature, the feature will not be matched.</para>
		/// <para>Touches—The features in the join features will be matched if they have a boundary that touches a target feature. When the target and join features are lines or polygons, the boundary of the join feature can only touch the boundary of the target feature, and no part of the join feature can cross the boundary of the target feature.</para>
		/// <para>Crosses—The features in the join features will be matched if a target feature is crossed by their outline. The join and target features must be lines or polygons. If polygons are used for the join or target features, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be matched, but lines that share a line segment will not.</para>
		/// <para>Overlaps—The features in the join features will be matched if they overlap a target feature.</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialRelationship { get; set; }

		/// <summary>
		/// <para>Spatial Near Distance</para>
		/// <para>The distance from a target feature within which join features will be considered for the spatial join. A search radius is only valid when the Spatial Relationship parameter value is Planar Near or Geodesic Near.</para>
		/// <para><see cref="SpatialNearDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SpatialNearDistance { get; set; }

		/// <summary>
		/// <para>Temporal Relationship</para>
		/// <para>Specifies the time criteria that will be used to match features.</para>
		/// <para>Meets—When a target time interval end is equal to the join time interval start, the target time meets the join time.</para>
		/// <para>Met by—When a target time interval start is equal to the join time interval end, the target time is met by the join time.</para>
		/// <para>Overlaps—When a target time interval starts and ends before the start and end of the join time interval, the target time overlaps the join time.</para>
		/// <para>Overlapped by—When a target time interval starts and ends after the start and end time of the join time interval, the target time is overlapped by the join time.</para>
		/// <para>During—When a target time occurs between the start and end of the join time interval, the target time is during the join time.</para>
		/// <para>Contains—When a join feature time occurs between the start and end of the target time interval, the target time contains the join time.</para>
		/// <para>Equals—Two times are considered equal if their instants or intervals are identical.</para>
		/// <para>Finishes—When a target time ends at the same time as a join time, and the target time started after the join time, the target time finishes the join time.</para>
		/// <para>Finished by—When a join feature time ends at the same time as a target time, and the join time started after the target time, the target time is finished by the join time.</para>
		/// <para>Starts—When a target time starts at the same time as the join time interval and ends before the join time interval ends, the target time starts the join time.</para>
		/// <para>Started by—When a target interval time starts at the same time as the join time and ends after the join time, the target time is started by the join time.</para>
		/// <para>Intersects—When any part of a target time occurs at the same time as the join time, the target time intersects the join time.</para>
		/// <para>Near—When a target time is within a specified range of time from the join time, the target time is near the join time.</para>
		/// <para>Near before—When a target time is before the join time but within a specified range of time from the join time, the target time is near before the join time. This option is available with ArcGIS Enterprise 10.6 or later.</para>
		/// <para>Near after—When a target time is after the join time but within a specified range of time from the join time, the target time is near after the join time. This option is available with ArcGIS Enterprise 10.6 or later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TemporalRelationship { get; set; }

		/// <summary>
		/// <para>Temporal Near Distance</para>
		/// <para>The distance in time from a target feature within which join features will be considered for the spatial join. A time is only valid when the Temporal Relationship parameter value is Near, Near Before, or Near After and both features are time enabled.</para>
		/// <para><see cref="TemporalNearDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TemporalNearDistance { get; set; }

		/// <summary>
		/// <para>Attribute Relationship</para>
		/// <para>Joins features based on values in an attribute field. Specify the attribute field from the target layer that matches an attribute field from the join layer.</para>
		/// <para>Target Field—An attribute field from the target layer containing values to match.</para>
		/// <para>Join Field—An attribute field from the join layer containing values to match.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AttributeRelationship { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Join Condition</para>
		/// <para>Applies a condition to specified fields. Only features with fields that meet these conditions will be joined.</para>
		/// <para>For example, you could apply a join condition to features in which the HealthSpending attribute in the join layer is more than 20 percent of the Income attribute in the target layer. In 10.5 and 10.5.1, the join condition to use to apply this expression is join[&quot;HealthSpending&quot;] &gt; target[&quot;Income&quot;] * .2. In 10.6 and later, use an Arcade expression such as $join[&quot;HealthSpending&quot;] &gt; $target[&quot;Income&quot;] * .2.</para>
		/// <para><para/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Options")]
		public object JoinCondition { get; set; }

		/// <summary>
		/// <para>Output_Feature_Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// <para>Specifies whether all target features will be maintained in the output feature class (known as a left outer join) or only those that have the specified relationships with the join features (inner join).</para>
		/// <para>Checked—All target features will be maintained in the output (outer join).</para>
		/// <para>Unchecked—Only those target features that have the specified relationships will be maintained in the output feature class (inner join). Any point features not within the polygon features will be excluded from the output. This is the default.</para>
		/// <para><see cref="KeepAllTargetFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object KeepAllTargetFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JoinFeatures SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Join Operation</para>
		/// </summary>
		public enum JoinOperationEnum 
		{
			/// <summary>
			/// <para>Join one to one—The attributes from the multiple join features will be aggregated. For example, if a point target feature is found in two separate polygon join features, the attributes from the two polygons will be aggregated before being transferred to the output point feature class. If one polygon has an attribute value of 3 and the other has a value of 7, and the summary statistic sum is specified for that field, the aggregated value in the output feature class will be 10. This is the default, and only the count statistic is returned.</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_ONE")]
			[Description("Join one to one")]
			Join_one_to_one,

			/// <summary>
			/// <para>Join one to many—The output feature class will contain multiple copies (records) of the target feature. For example, if a single-point target feature is found in two separate polygon join features, the output feature class will contain two copies of the target feature: one record with the attributes of one polygon and another record with the attributes of the other polygon. There are no summary statistics available with this method.</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_MANY")]
			[Description("Join one to many")]
			Join_one_to_many,

		}

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>Equals— The features in the join features will be matched if they are the same geometry as a target feature.</para>
			/// </summary>
			[GPValue("EQUALS")]
			[Description("Equals")]
			Equals,

			/// <summary>
			/// <para>Intersects—The features in the join features will be matched if they intersect a target feature. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECTS")]
			[Description("Intersects")]
			Intersects,

			/// <summary>
			/// <para>Contains—The features in the join features will be matched if a target feature contains them. The target features must be polygons or polylines. The join features can only be polygons when the target features are also polygons. A polygon can contain any feature type. A polyline can contain only polylines and points. A point cannot contain any feature, not even a point. If the join feature is entirely on the boundary of the target feature (no part is properly inside or outside), the feature will not be matched.</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("Contains")]
			Contains,

			/// <summary>
			/// <para>Within—The features in the join features will be matched if a target feature is within them. It is the opposite of the contains relationship. For this option, the target features can only be polygons when the join features are also polygons. A point can be a join feature only if a point is also a target feature. If the entirety of the feature in the join features is on the boundary of the target feature, the feature will not be matched.</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("Within")]
			Within,

			/// <summary>
			/// <para>Crosses—The features in the join features will be matched if a target feature is crossed by their outline. The join and target features must be lines or polygons. If polygons are used for the join or target features, the polygon&apos;s boundary (line) will be used. Lines that cross at a point will be matched, but lines that share a line segment will not.</para>
			/// </summary>
			[GPValue("CROSSES")]
			[Description("Crosses")]
			Crosses,

			/// <summary>
			/// <para>Touches—The features in the join features will be matched if they have a boundary that touches a target feature. When the target and join features are lines or polygons, the boundary of the join feature can only touch the boundary of the target feature, and no part of the join feature can cross the boundary of the target feature.</para>
			/// </summary>
			[GPValue("TOUCHES")]
			[Description("Touches")]
			Touches,

			/// <summary>
			/// <para>Overlaps—The features in the join features will be matched if they overlap a target feature.</para>
			/// </summary>
			[GPValue("OVERLAPS")]
			[Description("Overlaps")]
			Overlaps,

			/// <summary>
			/// <para>Planar Near—The features in the join features will be matched if they are within a specified distance of a target feature. The distance is measured using planar distance. Specify a distance in the Spatial Near Distance parameter.</para>
			/// </summary>
			[GPValue("NEAR")]
			[Description("Planar Near")]
			Planar_Near,

			/// <summary>
			/// <para>Geodesic Near—The features in the join features will be matched if they are within a specified distance of a target feature. The distance is measured geodesically. Specify a distance in the Spatial Near Distance parameter. This option is available with ArcGIS Enterprise 10.7 or later.</para>
			/// </summary>
			[GPValue("NEAR_GEODESIC")]
			[Description("Geodesic Near")]
			Geodesic_Near,

		}

		/// <summary>
		/// <para>Spatial Near Distance</para>
		/// </summary>
		public enum SpatialNearDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

		/// <summary>
		/// <para>Temporal Near Distance</para>
		/// </summary>
		public enum TemporalNearDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// </summary>
		public enum KeepAllTargetFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—All target features will be maintained in the output (outer join).</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para>Unchecked—Only those target features that have the specified relationships will be maintained in the output feature class (inner join). Any point features not within the polygon features will be excluded from the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_COMMON")]
			KEEP_COMMON,

		}

#endregion
	}
}
