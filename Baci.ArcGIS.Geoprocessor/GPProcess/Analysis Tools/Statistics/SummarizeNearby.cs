using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Summarize Nearby</para>
	/// <para>Summarize Nearby</para>
	/// <para>Finds features that are within a specified distance of features in the input layer and calculates statistics for the nearby features. Distance can be measured as a straight-line distance, a drive-time distance (for example, within 10 minutes), or a drive distance (within 5 kilometers). Drive-time and drive distance measurements require that you are logged in to an  ArcGIS Online organizational account with Network Analysis privileges, and they consume credits.</para>
	/// </summary>
	public class SummarizeNearby : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point, line, or polygon features that will be buffered and those buffers used to summarize the input summary features.</para>
		/// </param>
		/// <param name="InSumFeatures">
		/// <para>Input Summary Features</para>
		/// <para>The point, line, or polygon features that will be summarized.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the buffered input features, the attributes of the input features, and new attributes about the number points, length of lines, and area of polygons inside each buffer and statistics about those features.</para>
		/// </param>
		/// <param name="DistanceType">
		/// <para>Distance Measurement</para>
		/// <para>Defines what kind of distance measurement to use in generating buffer areas around the input features. Both driving distance and driving time use the road network and honor such restrictions as one-way streets. Driving time honors the current posted speed limits.</para>
		/// <para>To use the drive-time and drive distance measurement options you must be logged in to an ArcGIS Online organizational account with Network Analysis privileges. Each time the tool runs successfully, service credits are debited from your subscription based on the service used and the results returned from the service. The ArcGIS Online service credits page provides details about service credits.</para>
		/// <para>All distance types except straight-line distance use ArcGIS Online routing and network services.</para>
		/// <para>Driving distance—The distance covered in a car or other similar small automobiles, such as pickup trucks. Travel follows all rules that are specific to cars.</para>
		/// <para>Driving time—The distance covered within a specified time in a car or other similar small automobiles, such as pickup trucks. Dynamic travel speeds based on traffic are used where it is available when you specify a time of day. Travel follows all rules that are specific to cars.</para>
		/// <para>Straight line—Euclidean or straight-line distance.</para>
		/// <para>Trucking distance—The distance covered along designated truck routes. Travel follows all rules for cars as well as rules specific to trucking.</para>
		/// <para>Trucking time—The distance covered within a specified time when traveling along designated truck routes. Dynamic travel speeds based on traffic are used where it is available when you specify a time of day. Travel follows all rules for cars as well as rules specific to trucking.</para>
		/// <para>Walking distance—The distance covered along paths and roads that allow pedestrian traffic.</para>
		/// <para>Walking time—The distance covered within a specified time when walking along paths and roads that allow pedestrian traffic.</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </param>
		/// <param name="Distances">
		/// <para>Distances</para>
		/// <para>Distance values define a search distance (for straight-line, driving, trucking, or walking distance) or travel time (for driving, trucking, or walking time). Features that are within (or equal to) the distances you enter will be summarized.</para>
		/// <para>Multiple values can be specified. One area around each input feature will be generated for each distance.</para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Units</para>
		/// <para>The units of the distance values.</para>
		/// <para>Miles—Miles</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Meters—Meters</para>
		/// <para>Hours—Hours</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Seconds—Seconds</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		public SummarizeNearby(object InFeatures, object InSumFeatures, object OutFeatureClass, object DistanceType, object Distances, object DistanceUnits)
		{
			this.InFeatures = InFeatures;
			this.InSumFeatures = InSumFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DistanceType = DistanceType;
			this.Distances = Distances;
			this.DistanceUnits = DistanceUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Nearby</para>
		/// </summary>
		public override string DisplayName() => "Summarize Nearby";

		/// <summary>
		/// <para>Tool Name : SummarizeNearby</para>
		/// </summary>
		public override string ToolName() => "SummarizeNearby";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SummarizeNearby</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SummarizeNearby";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InSumFeatures, OutFeatureClass, DistanceType, Distances, DistanceUnits, TimeOfDay!, TimeZone!, KeepAllPolygons!, SumFields!, SumShape!, ShapeUnit!, GroupField!, AddMinMaj!, AddGroupPercent!, OutputGroupedTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point, line, or polygon features that will be buffered and those buffers used to summarize the input summary features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>The point, line, or polygon features that will be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InSumFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the buffered input features, the attributes of the input features, and new attributes about the number points, length of lines, and area of polygons inside each buffer and statistics about those features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Measurement</para>
		/// <para>Defines what kind of distance measurement to use in generating buffer areas around the input features. Both driving distance and driving time use the road network and honor such restrictions as one-way streets. Driving time honors the current posted speed limits.</para>
		/// <para>To use the drive-time and drive distance measurement options you must be logged in to an ArcGIS Online organizational account with Network Analysis privileges. Each time the tool runs successfully, service credits are debited from your subscription based on the service used and the results returned from the service. The ArcGIS Online service credits page provides details about service credits.</para>
		/// <para>All distance types except straight-line distance use ArcGIS Online routing and network services.</para>
		/// <para>Driving distance—The distance covered in a car or other similar small automobiles, such as pickup trucks. Travel follows all rules that are specific to cars.</para>
		/// <para>Driving time—The distance covered within a specified time in a car or other similar small automobiles, such as pickup trucks. Dynamic travel speeds based on traffic are used where it is available when you specify a time of day. Travel follows all rules that are specific to cars.</para>
		/// <para>Straight line—Euclidean or straight-line distance.</para>
		/// <para>Trucking distance—The distance covered along designated truck routes. Travel follows all rules for cars as well as rules specific to trucking.</para>
		/// <para>Trucking time—The distance covered within a specified time when traveling along designated truck routes. Dynamic travel speeds based on traffic are used where it is available when you specify a time of day. Travel follows all rules for cars as well as rules specific to trucking.</para>
		/// <para>Walking distance—The distance covered along paths and roads that allow pedestrian traffic.</para>
		/// <para>Walking time—The distance covered within a specified time when walking along paths and roads that allow pedestrian traffic.</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>Distance values define a search distance (for straight-line, driving, trucking, or walking distance) or travel time (for driving, trucking, or walking time). Features that are within (or equal to) the distances you enter will be summarized.</para>
		/// <para>Multiple values can be specified. One area around each input feature will be generated for each distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The units of the distance values.</para>
		/// <para>Miles—Miles</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Meters—Meters</para>
		/// <para>Hours—Hours</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Seconds—Seconds</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>Specify whether travel times should consider traffic conditions. Traffic conditions, especially in urbanized areas, can significantly impact the area covered within a specified travel time. If no date or time is specified, the distance covered during a specified travel time will not be impacted by traffic.</para>
		/// <para>Traffic conditions may be live or typical (historical) based on the date and time specified for this parameter. Esri saves live traffic data for 12 hours and references predictive data extending 12 hours into the future. If the time and date you specify is within the 24-hour time window, live traffic is used. If it is outside the time window, typical or historic traffic is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone for the specified time of day. Time zones can be specified in local time or Coordinated Universal Time (UTC).</para>
		/// <para>Geolocal—The time of day refers to the local time zone or zones in which the input features are located. This option can cause the analysis to have rolling start times across time zones. This is the default.For example, setting a geolocal time of day to 9:00 a.m. causes the drive times for points in the Eastern Time Zone to start at 9:00 a.m. Eastern Time, and 9:00 a.m. Central Time for points in the Central Time Zone. (The start times are offset by an hour in real or UTC time.)</para>
		/// <para>UTC—The time of day refers to Coordinated Universal Time (UTC). The start times for all points are simultaneous, regardless of time zones.For example, setting a UTC time of day to 9:00 a.m. causes the drive times for points in the Eastern Time Zone to start at 4:00 a.m. Eastern Time, and 3:00 a.m. Central Time for points in the Central Time Zone. (The start times are simultaneous.)</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeZone { get; set; } = "GEOLOCAL";

		/// <summary>
		/// <para>Keep polygons with no points</para>
		/// <para>Determines if all buffers of the input features or only those intersecting or containing at least one input summary feature will be copied to the output feature class.</para>
		/// <para>Checked—All buffers will be copied to the output feature class. This is the default.</para>
		/// <para>Unchecked—Only buffers that intersect or contain at least one input summary feature will be copied to the output feature class.</para>
		/// <para><see cref="KeepAllPolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepAllPolygons { get; set; } = "true";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>A list of attribute field names from the input summary features and statistical summary types you want to calculate for those attribute fields for all points within each input feature buffer.</para>
		/// <para>Summary fields must be numeric. Text and other attribute field types are not supported.</para>
		/// <para>Statistic types include the following:</para>
		/// <para>Sum—Adds the total value of all the points in each buffer.</para>
		/// <para>Mean—Calculates the average of all the points in each buffer.</para>
		/// <para>Min—Finds the smallest value of all the points in each buffer.</para>
		/// <para>Max—Finds the largest value of all the points in each buffer.</para>
		/// <para>Stddev—Finds the standard deviation of all the points in each buffer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SumFields { get; set; }

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// <para>Determines if the output feature class will contain attributes for the number of points, length of lines, and area of polygon features summarized in each input feature buffer.</para>
		/// <para>Checked—Add shape summary attributes to the output feature class. This is the default.</para>
		/// <para>Unchecked—Do not add shape summary attributes to the output feature class.</para>
		/// <para><see cref="SumShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SumShape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>The unit in which to calculate shape summary attributes. If the input summary features are points, no shape unit is used, since only the count of points within each input feature buffer is added.</para>
		/// <para>If the input summary features are lines, specify a linear unit. If the input summary features are polygons, specify an areal unit.</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Acres—Acres</para>
		/// <para>Hectares—Hectares</para>
		/// <para>Square meters—Square meters</para>
		/// <para>Square kilometers—Square kilometers</para>
		/// <para>Square feet—Square feet</para>
		/// <para>Square yards—Square yards</para>
		/// <para>Square miles—Square miles</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShapeUnit { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>Attribute field from the input summary features used for grouping. Features that have the same group field value will be combined and summarized with other features with the same group field value.</para>
		/// <para>When you choose a group field, an additional output grouped table will be created and its location must be specified. This output grouped table is required when using a group field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>This option is only enabled if you have selected a group field. It allows you to determine which group field value is the minority (least dominant) and the majority (most dominant) within each input feature buffer.</para>
		/// <para>Unchecked—Do not add minority and majority fields to the output. This is the default.</para>
		/// <para>Checked—Add minority and majority fields to the output.</para>
		/// <para><see cref="AddMinMajEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddMinMaj { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>This option is only enabled if you have selected a group field. It allows you to determine the percentage of each attribute value within each group.</para>
		/// <para>Unchecked—Do not add a percentage attribute field to the output. This is the default.</para>
		/// <para>Checked—Add a percentage attribute field to the output.</para>
		/// <para><see cref="AddGroupPercentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddGroupPercent { get; set; } = "false";

		/// <summary>
		/// <para>Output Grouped Table</para>
		/// <para>If a group field is specified, the output grouped table is required.</para>
		/// <para>An output table that includes summary fields for each group of summary features for each input feature buffer. The table will have the following attribute fields:</para>
		/// <para>Join_ID—An ID corresponding to an ID field added to the output feature class.</para>
		/// <para>The group field.</para>
		/// <para>A shape summary field such as count of points or length of lines.</para>
		/// <para>One field for each of the summary fields.</para>
		/// <para>Percentage field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputGroupedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeNearby SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Measurement</para>
		/// </summary>
		public enum DistanceTypeEnum 
		{
			/// <summary>
			/// <para>Driving distance—The distance covered in a car or other similar small automobiles, such as pickup trucks. Travel follows all rules that are specific to cars.</para>
			/// </summary>
			[GPValue("DRIVING_DISTANCE")]
			[Description("Driving distance")]
			Driving_distance,

			/// <summary>
			/// <para>Driving time—The distance covered within a specified time in a car or other similar small automobiles, such as pickup trucks. Dynamic travel speeds based on traffic are used where it is available when you specify a time of day. Travel follows all rules that are specific to cars.</para>
			/// </summary>
			[GPValue("DRIVING_TIME")]
			[Description("Driving time")]
			Driving_time,

			/// <summary>
			/// <para>Straight line—Euclidean or straight-line distance.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINE")]
			[Description("Straight line")]
			Straight_line,

			/// <summary>
			/// <para>Trucking distance—The distance covered along designated truck routes. Travel follows all rules for cars as well as rules specific to trucking.</para>
			/// </summary>
			[GPValue("TRUCKING_DISTANCE")]
			[Description("Trucking distance")]
			Trucking_distance,

			/// <summary>
			/// <para>Trucking time—The distance covered within a specified time when traveling along designated truck routes. Dynamic travel speeds based on traffic are used where it is available when you specify a time of day. Travel follows all rules for cars as well as rules specific to trucking.</para>
			/// </summary>
			[GPValue("TRUCKING_TIME")]
			[Description("Trucking time")]
			Trucking_time,

			/// <summary>
			/// <para>Walking distance—The distance covered along paths and roads that allow pedestrian traffic.</para>
			/// </summary>
			[GPValue("WALKING_DISTANCE")]
			[Description("Walking distance")]
			Walking_distance,

			/// <summary>
			/// <para>Walking time—The distance covered within a specified time when walking along paths and roads that allow pedestrian traffic.</para>
			/// </summary>
			[GPValue("WALKING_TIME")]
			[Description("Walking time")]
			Walking_time,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—Meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—Kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—Feet</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—Yards</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—Miles</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Seconds—Seconds</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Minutes—Minutes</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Hours—Hours</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—The time of day refers to Coordinated Universal Time (UTC). The start times for all points are simultaneous, regardless of time zones.For example, setting a UTC time of day to 9:00 a.m. causes the drive times for points in the Eastern Time Zone to start at 4:00 a.m. Eastern Time, and 3:00 a.m. Central Time for points in the Central Time Zone. (The start times are simultaneous.)</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Geolocal—The time of day refers to the local time zone or zones in which the input features are located. This option can cause the analysis to have rolling start times across time zones. This is the default.For example, setting a geolocal time of day to 9:00 a.m. causes the drive times for points in the Eastern Time Zone to start at 9:00 a.m. Eastern Time, and 9:00 a.m. Central Time for points in the Central Time Zone. (The start times are offset by an hour in real or UTC time.)</para>
			/// </summary>
			[GPValue("GEOLOCAL")]
			[Description("Geolocal")]
			Geolocal,

		}

		/// <summary>
		/// <para>Keep polygons with no points</para>
		/// </summary>
		public enum KeepAllPolygonsEnum 
		{
			/// <summary>
			/// <para>Checked—All buffers will be copied to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para>Unchecked—Only buffers that intersect or contain at least one input summary feature will be copied to the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_INTERSECTING")]
			ONLY_INTERSECTING,

		}

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// </summary>
		public enum SumShapeEnum 
		{
			/// <summary>
			/// <para>Checked—Add shape summary attributes to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para>Unchecked—Do not add shape summary attributes to the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum AddMinMajEnum 
		{
			/// <summary>
			/// <para>Checked—Add minority and majority fields to the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para>Unchecked—Do not add minority and majority fields to the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add group percentages</para>
		/// </summary>
		public enum AddGroupPercentEnum 
		{
			/// <summary>
			/// <para>Checked—Add a percentage attribute field to the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para>Unchecked—Do not add a percentage attribute field to the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
