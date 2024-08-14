using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Summarize Nearby</para>
	/// <para>Finds features that are within a specified distance of features in the input layer.</para>
	/// </summary>
	public class SummarizeNearby : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Sumnearbylayer">
		/// <para>Input Nearby Layer</para>
		/// <para>Point, line, or polygon features from which distances will be measured to features in the input summary layer.</para>
		/// </param>
		/// <param name="Summarylayer">
		/// <para>Input Summary Features</para>
		/// <para>Point, line, or polygon features. Features in this layer that are within the specified distance to features in the input nearby layer will be summarized.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		/// <param name="Neartype">
		/// <para>Distance Measurement</para>
		/// <para>Defines what kind of distance measurement you want to use: straight-line distance or by measuring travel time or travel distance along a street network using various modes of transportation known as travel modes.</para>
		/// <para>Straight-line—Use straight-line Euclidean measurement of distance. This is the default.</para>
		/// <para>Driving distance—Use distance as driven in an automobile.</para>
		/// <para>Driving time—Use distance covered during a specified driving time in an automobile.</para>
		/// <para>Trucking distance—Use distance as driven in a truck.</para>
		/// <para>Trucking time—Use distance covered during a specified driving time in a truck.</para>
		/// <para>Walking distance—Use distance as walked along a street.</para>
		/// <para>Walking time—Use distance covered during a specified walking time.</para>
		/// <para><see cref="NeartypeEnum"/></para>
		/// </param>
		/// <param name="Distances">
		/// <para>Distances</para>
		/// <para>A list of double values that defines the search distance (for straight-line and distance-based travel modes) or time (for time-based travel modes). You can enter a single distance value or multiple values. Features that are within (or equal to) the distances you enter will be summarized. The units of the distance values is supplied by the units parameter.</para>
		/// </param>
		/// <param name="Units">
		/// <para>Distance Units</para>
		/// <para>If the near type is straight-line or a distance-based travel mode, this is the linear unit to be used with the distance values specified in distances. Valid options include meters, kilometers, feet, yards, and miles.</para>
		/// <para>If the near type is a time-based travel mode, values include seconds, minutes, and hours.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Yards—Yards</para>
		/// <para>Seconds—Seconds</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Hours—Hours</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </param>
		public SummarizeNearby(object Sumnearbylayer, object Summarylayer, object Outputname, object Neartype, object Distances, object Units)
		{
			this.Sumnearbylayer = Sumnearbylayer;
			this.Summarylayer = Summarylayer;
			this.Outputname = Outputname;
			this.Neartype = Neartype;
			this.Distances = Distances;
			this.Units = Units;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Nearby</para>
		/// </summary>
		public override string DisplayName => "Summarize Nearby";

		/// <summary>
		/// <para>Tool Name : SummarizeNearby</para>
		/// </summary>
		public override string ToolName => "SummarizeNearby";

		/// <summary>
		/// <para>Tool Excute Name : sfa.SummarizeNearby</para>
		/// </summary>
		public override string ExcuteName => "sfa.SummarizeNearby";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Sumnearbylayer, Summarylayer, Outputname, Neartype, Distances, Units, Timeofday!, Timezonefortimeofday!, Returnboundaries!, Sumshape!, Shapeunits!, Summaryfields!, Groupbyfield!, Minoritymajority!, Percentshape!, Resultlayer!, Groupbysummary! };

		/// <summary>
		/// <para>Input Nearby Layer</para>
		/// <para>Point, line, or polygon features from which distances will be measured to features in the input summary layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object Sumnearbylayer { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>Point, line, or polygon features. Features in this layer that are within the specified distance to features in the input nearby layer will be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object Summarylayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Distance Measurement</para>
		/// <para>Defines what kind of distance measurement you want to use: straight-line distance or by measuring travel time or travel distance along a street network using various modes of transportation known as travel modes.</para>
		/// <para>Straight-line—Use straight-line Euclidean measurement of distance. This is the default.</para>
		/// <para>Driving distance—Use distance as driven in an automobile.</para>
		/// <para>Driving time—Use distance covered during a specified driving time in an automobile.</para>
		/// <para>Trucking distance—Use distance as driven in a truck.</para>
		/// <para>Trucking time—Use distance covered during a specified driving time in a truck.</para>
		/// <para>Walking distance—Use distance as walked along a street.</para>
		/// <para>Walking time—Use distance covered during a specified walking time.</para>
		/// <para><see cref="NeartypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Neartype { get; set; } = "STRAIGHTLINE";

		/// <summary>
		/// <para>Distances</para>
		/// <para>A list of double values that defines the search distance (for straight-line and distance-based travel modes) or time (for time-based travel modes). You can enter a single distance value or multiple values. Features that are within (or equal to) the distances you enter will be summarized. The units of the distance values is supplied by the units parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>If the near type is straight-line or a distance-based travel mode, this is the linear unit to be used with the distance values specified in distances. Valid options include meters, kilometers, feet, yards, and miles.</para>
		/// <para>If the near type is a time-based travel mode, values include seconds, minutes, and hours.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Yards—Yards</para>
		/// <para>Seconds—Seconds</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Hours—Hours</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Units { get; set; }

		/// <summary>
		/// <para>Time Of Day</para>
		/// <para>Specify whether travel times should consider traffic conditions. To use traffic in the analysis, you must set the near type to a travel-time-based mode. The time of day value represents the time at which travel begins, or departs, from the input points.</para>
		/// <para>Two kinds of traffic are supported: typical and live. Typical traffic references travel speeds that are made up of historical averages for each 5-minute interval spanning a week. Live traffic retrieves speeds from a traffic feed that processes phone probe records, sensors, and other data sources to record actual travel speeds and predict speeds for the near future.</para>
		/// <para>To ensure the task uses typical traffic in locations where it is available, choose a time and day of the week and convert the day of the week to one of the following dates from 1990:Although the dates representing days of the week are from 1990, typical traffic is calculated from recent traffic trends—usually over the last several months.</para>
		/// <para>Monday—1/1/1990</para>
		/// <para>Tuesday—1/2/1990</para>
		/// <para>Wednesday—1/3/1990</para>
		/// <para>Thursday—1/4/1990</para>
		/// <para>Friday—1/5/1990</para>
		/// <para>Saturday—1/6/1990</para>
		/// <para>Sunday—1/7/1990</para>
		/// <para>To use live traffic when and where it is available, choose a date and time within 12 hours of the current time. Esri saves live traffic data for 12 hours and references predictive data extending 12 hours into the future. If the time and date you specify for this parameter is outside the 24-hour time window, or the travel time in the analysis continues past the predictive data window, the task falls back to typical traffic speeds.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? Timeofday { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specify the time zone or zones of the chosen time of day. There are two options: GeoLocal (default) and UTC.</para>
		/// <para>Geolocal—The time of day value refers to the time zone or zones in which the input points are located. This option causes the analysis to have rolling start times across time zones. This is the default.</para>
		/// <para>Coordinated Universal Time (UTC)—The time of day value refers to Coordinated Universal Time (UTC). The start times for all points are simultaneous, regardless of time zones.</para>
		/// <para><see cref="TimezonefortimeofdayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Timezonefortimeofday { get; set; } = "GEOLOCAL";

		/// <summary>
		/// <para>Return boundaries</para>
		/// <para>Specifies whether the input geometries will be returned or the straight-line or travel mode buffer geometry.</para>
		/// <para>Checked—The output layer will contain areas defined by the specified near type. For example, if using a straight-line distance of 5 miles, the output will contain areas with a 5-mile radius around the input nearby layer features. This is the default.</para>
		/// <para>Unchecked—The output layer will contain the same features as the input nearby layer.</para>
		/// <para><see cref="ReturnboundariesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Returnboundaries { get; set; } = "true";

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// <para>Calculate statistics based on the shape of the input summary features, such as the length of lines or areas of polygons of the summary features within each polygon in the input summary layer.</para>
		/// <para>Checked—Calculate the shape summary attributes. This is the default.</para>
		/// <para>Unchecked—Do not calculate the shape summary attributes.</para>
		/// <para><see cref="SumshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Sumshape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>If summarizing the shape of the nearby features, specify the units of the shape summary.</para>
		/// <para>When the input summary features are polygons, the valid options are acres, hectares, square meters, square kilometers, square feet, square yards, and square miles.</para>
		/// <para>When the input summary features are lines, the valid options are meters, kilometers, feet, yards, and miles.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Yards—Yards</para>
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
		public object? Shapeunits { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>A list of field names and statistical summary type that you wish to calculate for all points within each polygon. The count of points within each polygon is always returned. The following statistic types are supported:</para>
		/// <para>Sum—The total value.</para>
		/// <para>Minimum—The smallest value.</para>
		/// <para>Max—The largest value.</para>
		/// <para>Mean—The average or mean value.</para>
		/// <para>Standard deviation—The standard deviation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Summaryfields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>This is a field from the input summary features you can use to calculate statistics separately for each unique attribute value. For example, suppose the input summary features contain point locations of businesses that store hazardous materials, and one of the fields is HazardClass containing codes that describe the type of hazardous material stored. To calculate summaries by each unique value of HazardClass, use it as the group by field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? Groupbyfield { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>This only applies when using a group by field. If checked, the minority (least dominant) or the majority (most dominant) attribute values for each group field within each boundary are calculated. Two new fields are added to the output layer prefixed with Majority_ and Minority_.</para>
		/// <para>Unchecked—Do not add minority and majority fields. This is the default.</para>
		/// <para>Checked—Add minority and majority fields.</para>
		/// <para><see cref="MinoritymajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Minoritymajority { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>This only applies when using a group by field. If checked, the percentage of each unique group value is calculated for each input nearby feature.</para>
		/// <para>Unchecked—Do not add percentage fields. This is the default.</para>
		/// <para>Checked—Add percentage fields.</para>
		/// <para><see cref="PercentshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Percentshape { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Resultlayer { get; set; }

		/// <summary>
		/// <para>Output Group Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? Groupbysummary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeNearby SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Measurement</para>
		/// </summary>
		public enum NeartypeEnum 
		{
			/// <summary>
			/// <para>Driving distance—Use distance as driven in an automobile.</para>
			/// </summary>
			[GPValue("DRIVINGDISTANCE")]
			[Description("Driving distance")]
			Driving_distance,

			/// <summary>
			/// <para>Driving time—Use distance covered during a specified driving time in an automobile.</para>
			/// </summary>
			[GPValue("DRIVINGTIME")]
			[Description("Driving time")]
			Driving_time,

			/// <summary>
			/// <para>Straight-line—Use straight-line Euclidean measurement of distance. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHTLINE")]
			[Description("Straight-line")]
			STRAIGHTLINE,

			/// <summary>
			/// <para>Trucking distance—Use distance as driven in a truck.</para>
			/// </summary>
			[GPValue("TRUCKINGDISTANCE")]
			[Description("Trucking distance")]
			Trucking_distance,

			/// <summary>
			/// <para>Trucking time—Use distance covered during a specified driving time in a truck.</para>
			/// </summary>
			[GPValue("TRUCKINGTIME")]
			[Description("Trucking time")]
			Trucking_time,

			/// <summary>
			/// <para>Walking distance—Use distance as walked along a street.</para>
			/// </summary>
			[GPValue("WALKINGDISTANCE")]
			[Description("Walking distance")]
			Walking_distance,

			/// <summary>
			/// <para>Walking time—Use distance covered during a specified walking time.</para>
			/// </summary>
			[GPValue("WALKINGTIME")]
			[Description("Walking time")]
			Walking_time,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum UnitsEnum 
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
		public enum TimezonefortimeofdayEnum 
		{
			/// <summary>
			/// <para>Coordinated Universal Time (UTC)—The time of day value refers to Coordinated Universal Time (UTC). The start times for all points are simultaneous, regardless of time zones.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("Coordinated Universal Time (UTC)")]
			UTC,

			/// <summary>
			/// <para>Geolocal—The time of day value refers to the time zone or zones in which the input points are located. This option causes the analysis to have rolling start times across time zones. This is the default.</para>
			/// </summary>
			[GPValue("GEOLOCAL")]
			[Description("Geolocal")]
			Geolocal,

		}

		/// <summary>
		/// <para>Return boundaries</para>
		/// </summary>
		public enum ReturnboundariesEnum 
		{
			/// <summary>
			/// <para>Checked—The output layer will contain areas defined by the specified near type. For example, if using a straight-line distance of 5 miles, the output will contain areas with a 5-mile radius around the input nearby layer features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RETURN_BOUNDARIES")]
			RETURN_BOUNDARIES,

			/// <summary>
			/// <para>Unchecked—The output layer will contain the same features as the input nearby layer.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RETURN_INPUT")]
			RETURN_INPUT,

		}

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// </summary>
		public enum SumshapeEnum 
		{
			/// <summary>
			/// <para>Checked—Calculate the shape summary attributes. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para>Unchecked—Do not calculate the shape summary attributes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum MinoritymajorityEnum 
		{
			/// <summary>
			/// <para>Checked—Add minority and majority fields.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para>Unchecked—Do not add minority and majority fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add group percentages</para>
		/// </summary>
		public enum PercentshapeEnum 
		{
			/// <summary>
			/// <para>Checked—Add percentage fields.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para>Unchecked—Do not add percentage fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
