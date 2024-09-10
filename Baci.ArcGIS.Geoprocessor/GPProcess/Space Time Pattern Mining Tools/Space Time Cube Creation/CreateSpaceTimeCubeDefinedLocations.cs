using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Create Space Time Cube From Defined Locations</para>
	/// <para>Takes panel data or station data (defined locations where geography does not change but attributes are changing over time) and structures it into a netCDF data format by creating space-time bins.  For all locations, the trend for variables or summary fields is evaluated.</para>
	/// </summary>
	public class CreateSpaceTimeCubeDefinedLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point or polygon feature class to be converted into a space-time cube.</para>
		/// </param>
		/// <param name="OutputCube">
		/// <para>Output Space Time Cube</para>
		/// <para>The output netCDF data cube that will be created.</para>
		/// </param>
		/// <param name="LocationId">
		/// <para>Location ID</para>
		/// <para>An integer field containing the ID number for each unique location.</para>
		/// </param>
		/// <param name="TemporalAggregation">
		/// <para>Temporal Aggregation</para>
		/// <para>Determines if there will be aggregation of the data temporally.</para>
		/// <para>Unchecked—The space-time cube will be created using the existing temporal structure of your Input Features. For example, you have yearly data and want to create a cube with a yearly Time Step Interval. This is the default.</para>
		/// <para>Checked—The space-time cube will temporally aggregate your features based on the Time Step Interval you provide. For example, you have data that has been collected daily and want to create a cube with a weekly Time Step Interval.</para>
		/// <para><see cref="TemporalAggregationEnum"/></para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>The field containing the timestamp for each row in the dataset. This field must be of type Date.</para>
		/// </param>
		/// <param name="TimeStepInterval">
		/// <para>Time Step Interval</para>
		/// <para>The number of seconds, minutes, hours, days, weeks, or years that will represent a single time step. Examples of valid entries for this parameter are 1 Weeks, 13 Days, or 1 Months.</para>
		/// <para>If Temporal Aggregation is checked off, you are not aggregating temporally, and this parameter should be set to the existing temporal structure of your data.</para>
		/// <para>If Temporal Aggregation is checked on, you are aggregating temporally, and this parameter should be set to the Time Step Interval you want to create. All features within the same Time Step Interval will be aggregated.</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </param>
		public CreateSpaceTimeCubeDefinedLocations(object InFeatures, object OutputCube, object LocationId, object TemporalAggregation, object TimeField, object TimeStepInterval)
		{
			this.InFeatures = InFeatures;
			this.OutputCube = OutputCube;
			this.LocationId = LocationId;
			this.TemporalAggregation = TemporalAggregation;
			this.TimeField = TimeField;
			this.TimeStepInterval = TimeStepInterval;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Space Time Cube From Defined Locations</para>
		/// </summary>
		public override string DisplayName() => "Create Space Time Cube From Defined Locations";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCubeDefinedLocations</para>
		/// </summary>
		public override string ToolName() => "CreateSpaceTimeCubeDefinedLocations";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CreateSpaceTimeCubeDefinedLocations</para>
		/// </summary>
		public override string ExcuteName() => "stpm.CreateSpaceTimeCubeDefinedLocations";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputCube, LocationId, TemporalAggregation, TimeField, TimeStepInterval, TimeStepAlignment, ReferenceTime, Variables, SummaryFields, InRelatedTable, RelatedLocationId };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point or polygon feature class to be converted into a space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>The output netCDF data cube that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>An integer field containing the ID number for each unique location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object LocationId { get; set; }

		/// <summary>
		/// <para>Temporal Aggregation</para>
		/// <para>Determines if there will be aggregation of the data temporally.</para>
		/// <para>Unchecked—The space-time cube will be created using the existing temporal structure of your Input Features. For example, you have yearly data and want to create a cube with a yearly Time Step Interval. This is the default.</para>
		/// <para>Checked—The space-time cube will temporally aggregate your features based on the Time Step Interval you provide. For example, you have data that has been collected daily and want to create a cube with a weekly Time Step Interval.</para>
		/// <para><see cref="TemporalAggregationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TemporalAggregation { get; set; } = "false";

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The field containing the timestamp for each row in the dataset. This field must be of type Date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>The number of seconds, minutes, hours, days, weeks, or years that will represent a single time step. Examples of valid entries for this parameter are 1 Weeks, 13 Days, or 1 Months.</para>
		/// <para>If Temporal Aggregation is checked off, you are not aggregating temporally, and this parameter should be set to the existing temporal structure of your data.</para>
		/// <para>If Temporal Aggregation is checked on, you are aggregating temporally, and this parameter should be set to the Time Step Interval you want to create. All features within the same Time Step Interval will be aggregated.</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>Defines how the cube structure will occur based on a given Time Step Interval.</para>
		/// <para>End time—Time steps align to the last time event and aggregate back in time. This is the default.</para>
		/// <para>Start time—Time steps align to the first time event and aggregate forward in time.</para>
		/// <para>Reference time—Time steps align to a particular date/time that you specify. If all points in the input features have a timestamp larger than the Reference time you provide (or it falls exactly on the start time of the input features), the time-step interval will begin with that reference time and aggregate forward in time (as occurs with a Start time alignment). If all points in the input features have a timestamp smaller than the reference time you provide (or it falls exactly on the end time of the input features), the time-step interval will end with that reference time and aggregate backward in time (as occurs with an End time alignment). If the Reference time you provide is in the middle of the time extent of your data, a time-step interval will be created ending with the reference time provided (as occurs with an End time alignment); additional intervals will be created both before and after the reference time until the full time extent of your data is covered.</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeStepAlignment { get; set; } = "END_TIME";

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>The date/time to used to align the time-step intervals. If you want to bin your data weekly from Monday to Sunday, for example, you could set a reference time of Sunday at midnight to ensure bins break between Sunday and Monday at midnight.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ReferenceTime { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The numeric field containing attribute values that will be brought into the space-time cube.</para>
		/// <para>Available fill types are:</para>
		/// <para>DROP_LOCATIONS–Locations with missing data for any of the variables will be dropped from the output space-time cube.</para>
		/// <para>ZEROS–Fills empty bins with zeros.</para>
		/// <para>SPATIAL_NEIGHBORS–Fills empty bins with the average value of spatial neighbors.</para>
		/// <para>SPACE_TIME_NEIGHBORS–Fills empty bins with the average value of space time neighbors.</para>
		/// <para>TEMPORAL_TREND–Fills empty bins using an interpolated univariate spline algorithm.</para>
		/// <para>Null values present in any of the variable records will result in an empty bin. If there are null values present in your input features, it is highly recommended that you run the Fill Missing Values tool first.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The numeric field containing attribute values used to calculate the specified statistic when aggregating into a space-time cube. Multiple statistic and field combinations can be specified. Null values in any of the fields specified will result in that feature being dropped from the output cube. If there are null values present in your input features, it is highly recommended you run the Fill Missing Values tool before creating a space time cube.</para>
		/// <para>Available statistic types are:</para>
		/// <para>SUM–Adds the total value for the specified field within each bin.</para>
		/// <para>MEAN–Calculates the average for the specified field within each bin.</para>
		/// <para>MIN–Finds the smallest value for all records of the specified field within each bin.</para>
		/// <para>MAX–Finds the largest value for all records of the specified field within each bin.</para>
		/// <para>STD–Finds the standard deviation on values in the specified field within each bin.</para>
		/// <para>MEDIAN–Finds the sorted middle value of all records of the specified field within each bin.</para>
		/// <para>Available fill types are:</para>
		/// <para>ZEROS–Fills empty bins with zeros.</para>
		/// <para>SPATIAL_NEIGHBORS–Fills empty bins with the average value of spatial neighbors</para>
		/// <para>SPACE_TIME_NEIGHBORS–Fills empty bins with the average value of space time neighbors.</para>
		/// <para>TEMPORAL_TREND–Fills empty bins using an interpolated univariate spline algorithm.</para>
		/// <para>Null values present in any of the summary field records will result in those features being excluded from the output cube. If there are null values present in your Input Features, it is highly recommended that you run the Fill Missing Values tool first. If, after running the Fill Missing Values tool, there are still null values present and having the count of points in each bin is part of your analysis strategy, you may want to consider creating separate cubes, one for the count (without Summary Fields) and one for Summary Fields. If the set of null values is different for each summary field, you may also consider creating a separate cube for each summary field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>The table or table view to be related to the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object InRelatedTable { get; set; }

		/// <summary>
		/// <para>Related Location ID</para>
		/// <para>An integer field in the related table that contains the location ID on which the relate will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object RelatedLocationId { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCubeDefinedLocations SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Temporal Aggregation</para>
		/// </summary>
		public enum TemporalAggregationEnum 
		{
			/// <summary>
			/// <para>Checked—The space-time cube will temporally aggregate your features based on the Time Step Interval you provide. For example, you have data that has been collected daily and want to create a cube with a weekly Time Step Interval.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_TEMPORAL_AGGREGATION")]
			APPLY_TEMPORAL_AGGREGATION,

			/// <summary>
			/// <para>Unchecked—The space-time cube will be created using the existing temporal structure of your Input Features. For example, you have yearly data and want to create a cube with a yearly Time Step Interval. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TEMPORAL_AGGREGATION")]
			NO_TEMPORAL_AGGREGATION,

		}

		/// <summary>
		/// <para>Time Step Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
		{
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
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>End time—Time steps align to the last time event and aggregate back in time. This is the default.</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("End time")]
			End_time,

			/// <summary>
			/// <para>Start time—Time steps align to the first time event and aggregate forward in time.</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("Start time")]
			Start_time,

			/// <summary>
			/// <para>Reference time—Time steps align to a particular date/time that you specify. If all points in the input features have a timestamp larger than the Reference time you provide (or it falls exactly on the start time of the input features), the time-step interval will begin with that reference time and aggregate forward in time (as occurs with a Start time alignment). If all points in the input features have a timestamp smaller than the reference time you provide (or it falls exactly on the end time of the input features), the time-step interval will end with that reference time and aggregate backward in time (as occurs with an End time alignment). If the Reference time you provide is in the middle of the time extent of your data, a time-step interval will be created ending with the reference time provided (as occurs with an End time alignment); additional intervals will be created both before and after the reference time until the full time extent of your data is covered.</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("Reference time")]
			Reference_time,

		}

#endregion
	}
}
