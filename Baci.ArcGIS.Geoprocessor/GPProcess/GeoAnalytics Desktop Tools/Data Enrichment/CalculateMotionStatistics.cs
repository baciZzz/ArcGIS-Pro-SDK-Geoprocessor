using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Calculate Motion Statistics</para>
	/// <para>Calculate Motion Statistics</para>
	/// <para>Calculates motion statistics for points in a time-enabled feature class.</para>
	/// </summary>
	public class CalculateMotionStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The time-enabled point features on which motion statistics will be calculated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class or layer containing the points with new fields for each motion statistic that was calculated.</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>One or more fields used to identify distinct entities.</para>
		/// </param>
		/// <param name="TrackHistoryWindow">
		/// <para>Track History Window</para>
		/// <para>The number of observations (including the current observation) that will be used for summary statistics. The default value is 3, which means that the summary statistics will be calculated at each point in a track using the current observation and the previous two observations. This parameter does not affect instantaneous statistics or idle classification.</para>
		/// </param>
		public CalculateMotionStatistics(object InputLayer, object OutFeatureClass, object TrackFields, object TrackHistoryWindow)
		{
			this.InputLayer = InputLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.TrackFields = TrackFields;
			this.TrackHistoryWindow = TrackHistoryWindow;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Motion Statistics</para>
		/// </summary>
		public override string DisplayName() => "Calculate Motion Statistics";

		/// <summary>
		/// <para>Tool Name : CalculateMotionStatistics</para>
		/// </summary>
		public override string ToolName() => "CalculateMotionStatistics";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CalculateMotionStatistics</para>
		/// </summary>
		public override string ExcuteName() => "gapro.CalculateMotionStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutFeatureClass, TrackFields, TrackHistoryWindow, MotionStatistics, DistanceMethod, IdleDistTolerance, IdleTimeTolerance, TimeBoundarySplit, TimeBoundaryReference, DistanceUnit, DurationUnit, SpeedUnit, AccelerationUnit, ElevationUnit };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The time-enabled point features on which motion statistics will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class or layer containing the points with new fields for each motion statistic that was calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>One or more fields used to identify distinct entities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Track History Window</para>
		/// <para>The number of observations (including the current observation) that will be used for summary statistics. The default value is 3, which means that the summary statistics will be calculated at each point in a track using the current observation and the previous two observations. This parameter does not affect instantaneous statistics or idle classification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object TrackHistoryWindow { get; set; }

		/// <summary>
		/// <para>Motion Statistics</para>
		/// <para>Specifies the group containing the statistics to be calculated and written to the result. If no value is provided, all statistics from all groups will be calculated.</para>
		/// <para>Distance—The distance between the current and previous observation and the maximum, minimum, average, and total distance in the track history window will be calculated.</para>
		/// <para>Duration—The duration between the current and previous observation and the maximum, minimum, average, and total duration in the track history window will be calculated.</para>
		/// <para>Speed—The speed of travel between the current and previous observation and the maximum, minimum, and average speed in the track history window will be calculated.</para>
		/// <para>Acceleration—The acceleration between the current speed and the previous speed and the maximum, minimum, and average acceleration in the track history window will be calculated.</para>
		/// <para>Elevation—The current elevation, the elevation change between the current and previous observation, and the maximum, minimum, average, and total elevation change in the track history window will be calculated.</para>
		/// <para>Slope—The slope between the current and previous observation and the maximum, minimum, and average slope in the track history window will be calculated.</para>
		/// <para>Idle—Whether an entity is currently idling, as well as the percentage idle time and total idle time in the track history window will be calculated.</para>
		/// <para>Bearing—The angle of travel between the previous observation and the current observation will be calculated.</para>
		/// <para><see cref="MotionStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object MotionStatistics { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies the distance measurement method that will be used when calculating motion statistics.</para>
		/// <para>Geodesic—Geodesic distance will be used.</para>
		/// <para>Planar—Planar distance will be used. This is the default.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; }

		/// <summary>
		/// <para>Idle Distance Tolerance</para>
		/// <para>The maximum distance that two sequential points in a track can be apart and still be considered idle. This parameter is used with the Idle Time Tolerance parameter to determine if an entity is idling. The Idle Distance Tolerance parameter is required if the Idle statistic group is specified in the Motion Statistics parameter or if statistics in all the groups will be calculated.</para>
		/// <para><see cref="IdleDistToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object IdleDistTolerance { get; set; }

		/// <summary>
		/// <para>Idle Time Tolerance</para>
		/// <para>The minimum duration that two sequential points in a track must be near each other to be considered idle. This parameter is used with the Idle Distance Tolerance parameter to determine if an entity is idling. The Idle Time Tolerance parameter is required if the Idle statistic group is specified in the Motion Statistics parameter or if statistics in all the groups will be calculated.</para>
		/// <para><see cref="IdleTimeToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object IdleTimeTolerance { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, starting on January 1, 1980, tracks will be split at the beginning of every day. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Options")]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>Specifies the unit of measure for distance values in the output feature class.</para>
		/// <para>Meters—The unit of measure will be meters. This is the default.</para>
		/// <para>Kilometers—The unit of measure will be kilometers.</para>
		/// <para>Miles—The unit of measure will be miles.</para>
		/// <para>Nautical Miles—The unit of measure will be nautical miles.</para>
		/// <para>Yards—The unit of measure will be yards.</para>
		/// <para>Feet—The unit of measure will be feet.</para>
		/// <para><see cref="DistanceUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object DistanceUnit { get; set; }

		/// <summary>
		/// <para>Duration Unit</para>
		/// <para>Specifies the unit of measure for duration values in the output feature class.</para>
		/// <para>Years—The unit of measure will years.</para>
		/// <para>Months—The unit of measure will be months.</para>
		/// <para>Weeks—The unit of measure will be weeks.</para>
		/// <para>Days—The unit of measure will be days.</para>
		/// <para>Hours—The unit of measure will be hours.</para>
		/// <para>Minutes—The unit of measure will be minutes.</para>
		/// <para>Seconds—The unit of measure will be seconds. This is the default.</para>
		/// <para>Milliseconds—The unit of measure will be milliseconds.</para>
		/// <para><see cref="DurationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object DurationUnit { get; set; }

		/// <summary>
		/// <para>Speed Unit</para>
		/// <para>Specifies the unit of measure for speed values in the output feature class.</para>
		/// <para>Meters Per Second—The unit of measure will be meters per second. This is the default.</para>
		/// <para>Miles Per Hour—The unit of measure will be miles per hour.</para>
		/// <para>Kilometers Per Hour—The unit of measure will be kilometers per hour.</para>
		/// <para>Feet Per Second—The unit of measure will be feet per second.</para>
		/// <para>Nautical Miles Per Hour—The unit of measure will be nautical miles per hour.</para>
		/// <para><see cref="SpeedUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object SpeedUnit { get; set; }

		/// <summary>
		/// <para>Acceleration Unit</para>
		/// <para>Specifies the unit of measure for acceleration values in the output feature class.</para>
		/// <para>Meters Per Second Squared—The unit of measure will be meters per second squared. This is the default.</para>
		/// <para>Feet Per Second Squared—The unit of measure will be feet per second squared.</para>
		/// <para><see cref="AccelerationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object AccelerationUnit { get; set; }

		/// <summary>
		/// <para>Elevation Unit</para>
		/// <para>Specifies the unit of measure for elevation values in the output feature class.</para>
		/// <para>Meters—The unit of measure will be meters. This is the default.</para>
		/// <para>Kilometers—The unit of measure will be kilometers.</para>
		/// <para>Miles—The unit of measure will be miles.</para>
		/// <para>Nautical Miles—The unit of measure will be nautical miles.</para>
		/// <para>Yards—The unit of measure will be yards.</para>
		/// <para>Feet—The unit of measure will be feet.</para>
		/// <para><see cref="ElevationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object ElevationUnit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateMotionStatistics SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Motion Statistics</para>
		/// </summary>
		public enum MotionStatisticsEnum 
		{
			/// <summary>
			/// <para>Distance—The distance between the current and previous observation and the maximum, minimum, average, and total distance in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Duration—The duration between the current and previous observation and the maximum, minimum, average, and total duration in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("DURATION")]
			[Description("Duration")]
			Duration,

			/// <summary>
			/// <para>Speed—The speed of travel between the current and previous observation and the maximum, minimum, and average speed in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("SPEED")]
			[Description("Speed")]
			Speed,

			/// <summary>
			/// <para>Acceleration—The acceleration between the current speed and the previous speed and the maximum, minimum, and average acceleration in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("ACCELERATION")]
			[Description("Acceleration")]
			Acceleration,

			/// <summary>
			/// <para>Elevation—The current elevation, the elevation change between the current and previous observation, and the maximum, minimum, average, and total elevation change in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

			/// <summary>
			/// <para>Slope—The slope between the current and previous observation and the maximum, minimum, and average slope in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("Slope")]
			Slope,

			/// <summary>
			/// <para>Bearing—The angle of travel between the previous observation and the current observation will be calculated.</para>
			/// </summary>
			[GPValue("BEARING")]
			[Description("Bearing")]
			Bearing,

			/// <summary>
			/// <para>Idle—Whether an entity is currently idling, as well as the percentage idle time and total idle time in the track history window will be calculated.</para>
			/// </summary>
			[GPValue("IDLE")]
			[Description("Idle")]
			Idle,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Planar—Planar distance will be used. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—Geodesic distance will be used.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Idle Distance Tolerance</para>
		/// </summary>
		public enum IdleDistToleranceEnum 
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
		/// <para>Idle Time Tolerance</para>
		/// </summary>
		public enum IdleTimeToleranceEnum 
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
		/// <para>Time Boundary Split</para>
		/// </summary>
		public enum TimeBoundarySplitEnum 
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
		/// <para>Distance Unit</para>
		/// </summary>
		public enum DistanceUnitEnum 
		{
			/// <summary>
			/// <para>Kilometers—The unit of measure will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—The unit of measure will be meters. This is the default.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Miles—The unit of measure will be miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical Miles—The unit of measure will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical Miles")]
			Nautical_Miles,

			/// <summary>
			/// <para>Yards—The unit of measure will be yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—The unit of measure will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

		}

		/// <summary>
		/// <para>Duration Unit</para>
		/// </summary>
		public enum DurationUnitEnum 
		{
			/// <summary>
			/// <para>Years—The unit of measure will years.</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("Years")]
			Years,

			/// <summary>
			/// <para>Months—The unit of measure will be months.</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para>Weeks—The unit of measure will be weeks.</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para>Days—The unit of measure will be days.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Hours—The unit of measure will be hours.</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Minutes—The unit of measure will be minutes.</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Seconds—The unit of measure will be seconds. This is the default.</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Milliseconds—The unit of measure will be milliseconds.</para>
			/// </summary>
			[GPValue("MILLISECONDS")]
			[Description("Milliseconds")]
			Milliseconds,

		}

		/// <summary>
		/// <para>Speed Unit</para>
		/// </summary>
		public enum SpeedUnitEnum 
		{
			/// <summary>
			/// <para>Meters Per Second—The unit of measure will be meters per second. This is the default.</para>
			/// </summary>
			[GPValue("METERS_PER_SECOND")]
			[Description("Meters Per Second")]
			Meters_Per_Second,

			/// <summary>
			/// <para>Miles Per Hour—The unit of measure will be miles per hour.</para>
			/// </summary>
			[GPValue("MILES_PER_HOUR")]
			[Description("Miles Per Hour")]
			Miles_Per_Hour,

			/// <summary>
			/// <para>Kilometers Per Hour—The unit of measure will be kilometers per hour.</para>
			/// </summary>
			[GPValue("KILOMETERS_PER_HOUR")]
			[Description("Kilometers Per Hour")]
			Kilometers_Per_Hour,

			/// <summary>
			/// <para>Feet Per Second—The unit of measure will be feet per second.</para>
			/// </summary>
			[GPValue("FEET_PER_SECOND")]
			[Description("Feet Per Second")]
			Feet_Per_Second,

			/// <summary>
			/// <para>Nautical Miles Per Hour—The unit of measure will be nautical miles per hour.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES_PER_HOUR")]
			[Description("Nautical Miles Per Hour")]
			Nautical_Miles_Per_Hour,

		}

		/// <summary>
		/// <para>Acceleration Unit</para>
		/// </summary>
		public enum AccelerationUnitEnum 
		{
			/// <summary>
			/// <para>Meters Per Second Squared—The unit of measure will be meters per second squared. This is the default.</para>
			/// </summary>
			[GPValue("METERS_PER_SECOND_SQUARED")]
			[Description("Meters Per Second Squared")]
			Meters_Per_Second_Squared,

			/// <summary>
			/// <para>Feet Per Second Squared—The unit of measure will be feet per second squared.</para>
			/// </summary>
			[GPValue("FEET_PER_SECOND_SQUARED")]
			[Description("Feet Per Second Squared")]
			Feet_Per_Second_Squared,

		}

		/// <summary>
		/// <para>Elevation Unit</para>
		/// </summary>
		public enum ElevationUnitEnum 
		{
			/// <summary>
			/// <para>Kilometers—The unit of measure will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—The unit of measure will be meters. This is the default.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Miles—The unit of measure will be miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical Miles—The unit of measure will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical Miles")]
			Nautical_Miles,

			/// <summary>
			/// <para>Yards—The unit of measure will be yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—The unit of measure will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

		}

#endregion
	}
}
