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
	/// <para>Create Space Time Cube</para>
	/// <para>Summarizes a set of points into a netCDF data structure by aggregating them into space-time bins.  Within each bin, the points are counted, and specified attributes are aggregated.  For all bin locations, the trend for counts and summary field values are evaluated.</para>
	/// </summary>
	public class CreateSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>The input point feature class that will be aggregated into space-time bins.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The output netCDF data cube that will be created to contain counts and summaries of the input feature point data.</para>
		/// </param>
		/// <param name="DistanceInterval">
		/// <para>Distance Interval</para>
		/// <para>The size of the bins will be used to aggregate the Point Layer. All points that fall within the same Distance Interval and Time Interval will be aggregated.</para>
		/// <para>The distance that will determine the bin size.</para>
		/// </param>
		/// <param name="TimeStepInterval">
		/// <para>Time Interval</para>
		/// <para>The number of seconds, minutes, hours, days, weeks, or years that will represent a single time step. All points within the same Time Interval and Distance Interval will be aggregated. Examples of valid entries for this parameter are 1 Weeks, 13 Days, or 1 Months.</para>
		/// </param>
		public CreateSpaceTimeCube(object PointLayer, object OutputName, object DistanceInterval, object TimeStepInterval)
		{
			this.PointLayer = PointLayer;
			this.OutputName = OutputName;
			this.DistanceInterval = DistanceInterval;
			this.TimeStepInterval = TimeStepInterval;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Space Time Cube</para>
		/// </summary>
		public override string DisplayName => "Create Space Time Cube";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCube</para>
		/// </summary>
		public override string ToolName => "CreateSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CreateSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.CreateSpaceTimeCube";

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
		public override object[] Parameters => new object[] { PointLayer, OutputName, DistanceInterval, TimeStepInterval, TimeStepIntervalAlignment!, ReferenceTime!, SummaryFields!, Output! };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>The input point feature class that will be aggregated into space-time bins.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The output netCDF data cube that will be created to contain counts and summaries of the input feature point data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Distance Interval</para>
		/// <para>The size of the bins will be used to aggregate the Point Layer. All points that fall within the same Distance Interval and Time Interval will be aggregated.</para>
		/// <para>The distance that will determine the bin size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object DistanceInterval { get; set; }

		/// <summary>
		/// <para>Time Interval</para>
		/// <para>The number of seconds, minutes, hours, days, weeks, or years that will represent a single time step. All points within the same Time Interval and Distance Interval will be aggregated. Examples of valid entries for this parameter are 1 Weeks, 13 Days, or 1 Months.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Interval Alignment</para>
		/// <para>Specifies how aggregation will occur based on the Time Interval (time_step_interval in Python) parameter.</para>
		/// <para>End time—Time steps will align to the last time event and aggregate back in time.</para>
		/// <para>Start time—Time steps will align to the first time event and aggregate forward in time.</para>
		/// <para>Reference time—Time steps will align to a specified date or time. If all points in the input features have a time stamp larger than the specified reference time (or it falls exactly on the start time of the input features), the time-step interval will begin with that reference time and aggregate forward in time (as occurs with the Start time alignment). If all points in the input features have a time stamp smaller than the specified reference time (or it falls exactly on the end time of the input features), the time-step interval will end with that reference time and aggregate backward in time (as occurs with the End time alignment). If the specified reference time is in the middle of the time extent of the data, a time-step interval will be created ending with the reference time provided (as occurs with the End time alignment); additional intervals will be created both before and after the reference time until the full time extent of the data is covered.</para>
		/// <para><see cref="TimeStepIntervalAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeStepIntervalAlignment { get; set; }

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>The date or time that will be used to align the time-step intervals. For example, to bin the data weekly, Monday to Sunday, set a reference time of Sunday at midnight to ensure that bins break between Sunday and Monday at midnight.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ReferenceTime { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The numeric field containing attribute values that will be used to calculate the specified statistic when aggregating into a space time cube. Multiple statistic and field combinations can be specified. Null values are excluded from all statistical calculations.</para>
		/// <para>Available statistic types are the following:</para>
		/// <para>Sum—Adds the total value for the specified field within each bin.</para>
		/// <para>Mean—Calculates the average for the specified field within each bin.</para>
		/// <para>Minimum—Finds the smallest value for all records of the specified field within each bin.</para>
		/// <para>Maximum—Finds the largest value for all records of the specified field within each bin.</para>
		/// <para>Standard deviation—Finds the standard deviation on values in the specified field within each bin.</para>
		/// <para>Available fill types are the following:</para>
		/// <para>Zeros—Fills empty bins with zeros.</para>
		/// <para>Spatial_Neighbors—Fills empty bins with the average value of spatial neighbors.</para>
		/// <para>Space Time Neighbors—Fills empty bins with the average value of space-time neighbors.</para>
		/// <para>Temporal Trend—Fills empty bins using an interpolated univariate spline algorithm.</para>
		/// <para>Null values present in any of the summary fields will result in those features being excluded from the analysis. If count of points in each bin is part of your analysis strategy, consider creating separate cubes, one for the count (without summary fields) and one for summary fields. If the set of null values is different for each summary field, consider creating a separate cube for each summary field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCube SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Interval Alignment</para>
		/// </summary>
		public enum TimeStepIntervalAlignmentEnum 
		{
			/// <summary>
			/// <para>End time—Time steps will align to the last time event and aggregate back in time.</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("End time")]
			End_time,

			/// <summary>
			/// <para>Start time—Time steps will align to the first time event and aggregate forward in time.</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("Start time")]
			Start_time,

			/// <summary>
			/// <para>Reference time—Time steps will align to a specified date or time. If all points in the input features have a time stamp larger than the specified reference time (or it falls exactly on the start time of the input features), the time-step interval will begin with that reference time and aggregate forward in time (as occurs with the Start time alignment). If all points in the input features have a time stamp smaller than the specified reference time (or it falls exactly on the end time of the input features), the time-step interval will end with that reference time and aggregate backward in time (as occurs with the End time alignment). If the specified reference time is in the middle of the time extent of the data, a time-step interval will be created ending with the reference time provided (as occurs with the End time alignment); additional intervals will be created both before and after the reference time until the full time extent of the data is covered.</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("Reference time")]
			Reference_time,

		}

#endregion
	}
}
