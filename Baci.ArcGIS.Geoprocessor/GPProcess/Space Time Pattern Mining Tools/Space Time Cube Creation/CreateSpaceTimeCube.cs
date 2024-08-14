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
	/// <para>Create Space Time Cube By Aggregating Points</para>
	/// <para>Summarizes a set of points into a netCDF data structure by aggregating them into space-time bins.  Within each bin, the points are counted, and specified attributes are aggregated.  For all bin locations, the trend for counts and summary field values are evaluated.</para>
	/// </summary>
	public class CreateSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point feature class to be aggregated into space-time bins.</para>
		/// </param>
		/// <param name="OutputCube">
		/// <para>Output Space Time Cube</para>
		/// <para>The output netCDF data cube that will be created to contain counts and summaries of the input feature point data.</para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>The field containing the date and time (timestamp) for each point. This field must be of type Date.</para>
		/// </param>
		public CreateSpaceTimeCube(object InFeatures, object OutputCube, object TimeField)
		{
			this.InFeatures = InFeatures;
			this.OutputCube = OutputCube;
			this.TimeField = TimeField;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Space Time Cube By Aggregating Points</para>
		/// </summary>
		public override string DisplayName => "Create Space Time Cube By Aggregating Points";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCube</para>
		/// </summary>
		public override string ToolName => "CreateSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CreateSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName => "stpm.CreateSpaceTimeCube";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutputCube, TimeField, TemplateCube, TimeStepInterval, TimeStepAlignment, ReferenceTime, DistanceInterval, SummaryFields, AggregationShapeType, DefinedPolygonLocations, LocationId };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point feature class to be aggregated into space-time bins.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>The output netCDF data cube that will be created to contain counts and summaries of the input feature point data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The field containing the date and time (timestamp) for each point. This field must be of type Date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Template Cube</para>
		/// <para>A reference space-time cube used to define the Output Space Time Cube extent of analysis, bin dimensions, and bin alignment. Time Step Interval, Distance Interval, and Reference Time information are also obtained from the template cube. This template cube must be a netCDF (.nc) file that has been created using this tool.</para>
		/// <para>A space-time cube created by aggregating into Defined locations cannot be used as a Template Cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object TemplateCube { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>The number of seconds, minutes, hours, days, weeks, or years that will represent a single time step. All points within the same Time Step Interval and Distance Interval will be aggregated. (When a Template Cube is provided, this parameter is ignored, and the Time Step Interval value is obtained from the template cube.)</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>Defines how aggregation will occur based on a given Time Step Interval. If a Template Cube is provided, the Time Step Alignment associated with the Template Cube overrides this parameter setting and the Time Step Alignment of the Template Cube is used.</para>
		/// <para>End time—Time steps align to the last time event and aggregate back in time.</para>
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
		/// <para>The date/time to use to align the time-step intervals. If you want to bin your data weekly from Monday to Sunday, for example, you could set a reference time of Sunday at midnight to ensure bins break between Sunday and Monday at midnight. (When a Template Cube is provided, this parameter is disabled and the Reference Time is based on the Template Cube.)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ReferenceTime { get; set; }

		/// <summary>
		/// <para>Distance Interval</para>
		/// <para>The size of the bins used to aggregate the Input Features. All points that fall within the same Distance Interval and Time Step Interval will be aggregated. When aggregating into a hexagon grid, this distance is used as the height to construct the hexagon polygons. (When a Template Cube is provided, this parameter is disabled and the distance interval value will be based on the Template Cube.)</para>
		/// <para><see cref="DistanceIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceInterval { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The numeric field containing attribute values used to calculate the specified statistic when aggregating into a space-time cube. Multiple statistic and field combinations can be specified. Null values in any of the fields specified will result in that feature being dropped from the output cube. If there are null values present in your input features, it is highly recommended that you run the Fill Missing Values tool before creating a space-time cube.</para>
		/// <para>Available statistic types are:</para>
		/// <para>SUM-Adds the total value for the specified field within each bin.</para>
		/// <para>MEAN-Calculates the average for the specified field within each bin.</para>
		/// <para>MIN-Finds the smallest value for all records of the specified field within each bin.</para>
		/// <para>MAX-Finds the largest value for all records of the specified field within each bin.</para>
		/// <para>STD-Finds the standard deviation on values in the specified field within each bin.</para>
		/// <para>MEDIAN-Finds the sorted middle value of all records of the specified field within each bin.</para>
		/// <para>Available fill types are:</para>
		/// <para>ZEROS-Fills empty bins with zeros.</para>
		/// <para>SPATIAL_NEIGHBORS-Fills empty bins with the average value of spatial neighbors</para>
		/// <para>SPACE_TIME_NEIGHBORS-Fills empty bins with the average value of space time neighbors.</para>
		/// <para>TEMPORAL_TREND-Fills empty bins using an interpolated univariate spline algorithm.</para>
		/// <para>Null values present in any of the summary field records will result in those features being excluded from the output cube. If there are null values present in your Input Features, it is highly recommended that you run the Fill Missing Values tool first. If, after running the Fill Missing Values tool, there are still null values present and having the count of points in each bin is part of your analysis strategy, you may want to consider creating separate cubes, one for the count (without Summary Fields) and one for Summary Fields. If the set of null values is different for each summary field, you may also consider creating a separate cube for each summary field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Aggregation Shape Type</para>
		/// <para>The shape of the polygon mesh into which the input feature point data will be aggregated.</para>
		/// <para>Fishnet grid—The input features will be aggregated into a grid of square (fishnet) cells.</para>
		/// <para>Hexagon grid—The input features will be aggregated into a grid of hexagonal cells.</para>
		/// <para>Defined locations—The input features will be aggregated into the locations provided.</para>
		/// <para><see cref="AggregationShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationShapeType { get; set; } = "FISHNET_GRID";

		/// <summary>
		/// <para>Defined Polygon Locations</para>
		/// <para>The polygon features into which the input point data will be aggregated. These can represent county boundaries, police beats, or sales territories for example.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object DefinedPolygonLocations { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>The field containing the ID number for each unique location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object LocationId { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCube SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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
			/// <para>End time—Time steps align to the last time event and aggregate back in time.</para>
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

		/// <summary>
		/// <para>Distance Interval</para>
		/// </summary>
		public enum DistanceIntervalEnum 
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
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Aggregation Shape Type</para>
		/// </summary>
		public enum AggregationShapeTypeEnum 
		{
			/// <summary>
			/// <para>Fishnet grid—The input features will be aggregated into a grid of square (fishnet) cells.</para>
			/// </summary>
			[GPValue("FISHNET_GRID")]
			[Description("Fishnet grid")]
			Fishnet_grid,

			/// <summary>
			/// <para>Hexagon grid—The input features will be aggregated into a grid of hexagonal cells.</para>
			/// </summary>
			[GPValue("HEXAGON_GRID")]
			[Description("Hexagon grid")]
			Hexagon_grid,

			/// <summary>
			/// <para>Defined locations—The input features will be aggregated into the locations provided.</para>
			/// </summary>
			[GPValue("DEFINED_LOCATIONS")]
			[Description("Defined locations")]
			Defined_locations,

		}

#endregion
	}
}
