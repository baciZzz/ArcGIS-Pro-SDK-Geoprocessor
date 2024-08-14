using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Detect Change Using Change Analysis Raster</para>
	/// <para>Generates a raster containing pixel change information using the output change analysis raster from the Analyze Changes Using CCDC tool or the Analyze Changes Using LandTrendr tool.</para>
	/// </summary>
	public class DetectChangeUsingChangeAnalysisRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InChangeAnalysisRaster">
		/// <para>Input Change Analysis Raster</para>
		/// <para>The change analysis raster generated from the Analyze Changes Using CCDC tool or the Analyze Changes Using LandTrendr tool.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output raster containing the detected change information.</para>
		/// </param>
		/// <param name="ChangeType">
		/// <para>Change Type</para>
		/// <para>Specifies the change information that will be calculated for each pixel.</para>
		/// <para>Time of latest change—Each pixel will contain the date of its most recent change in the time series. This is the default.</para>
		/// <para>Time of earliest change—Each pixel will contain the date of its earliest change in the time series.</para>
		/// <para>Time of largest change—Each pixel will contain the date of its most significant change in the time series.</para>
		/// <para>Number of changes—Each pixel will contain the total number of times it changed in the time series.</para>
		/// <para>Time of longest change—Each pixel will contain the date of change at the beginning or end of the longest transition segment in the time series.</para>
		/// <para>Time of shortest change—Each pixel will contain the date of change at the beginning or end of the shortest transition segment in the time series.</para>
		/// <para>Time of fastest change—Each pixel will contain the date of change at the beginning or end of the transition that occurred most quickly.</para>
		/// <para>Time of slowest change—Each pixel will contain the date of change at the beginning or end of the transition that occurred most slowly.</para>
		/// <para><see cref="ChangeTypeEnum"/></para>
		/// </param>
		public DetectChangeUsingChangeAnalysisRaster(object InChangeAnalysisRaster, object OutRaster, object ChangeType)
		{
			this.InChangeAnalysisRaster = InChangeAnalysisRaster;
			this.OutRaster = OutRaster;
			this.ChangeType = ChangeType;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Change Using Change Analysis Raster</para>
		/// </summary>
		public override string DisplayName => "Detect Change Using Change Analysis Raster";

		/// <summary>
		/// <para>Tool Name : DetectChangeUsingChangeAnalysisRaster</para>
		/// </summary>
		public override string ToolName => "DetectChangeUsingChangeAnalysisRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.DetectChangeUsingChangeAnalysisRaster</para>
		/// </summary>
		public override string ExcuteName => "ia.DetectChangeUsingChangeAnalysisRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InChangeAnalysisRaster, OutRaster, ChangeType, MaxNumberChanges!, SegmentDate!, ChangeDirection!, FilterByYear!, MinYear!, MaxYear!, FilterByDuration!, MinDuration!, MaxDuration!, FilterByMagnitude!, MinMagnitude!, MaxMagnitude!, FilterByStartValue!, MinStartValue!, MaxStartValue!, FilterByEndValue!, MinEndValue!, MaxEndValue! };

		/// <summary>
		/// <para>Input Change Analysis Raster</para>
		/// <para>The change analysis raster generated from the Analyze Changes Using CCDC tool or the Analyze Changes Using LandTrendr tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InChangeAnalysisRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output raster containing the detected change information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Change Type</para>
		/// <para>Specifies the change information that will be calculated for each pixel.</para>
		/// <para>Time of latest change—Each pixel will contain the date of its most recent change in the time series. This is the default.</para>
		/// <para>Time of earliest change—Each pixel will contain the date of its earliest change in the time series.</para>
		/// <para>Time of largest change—Each pixel will contain the date of its most significant change in the time series.</para>
		/// <para>Number of changes—Each pixel will contain the total number of times it changed in the time series.</para>
		/// <para>Time of longest change—Each pixel will contain the date of change at the beginning or end of the longest transition segment in the time series.</para>
		/// <para>Time of shortest change—Each pixel will contain the date of change at the beginning or end of the shortest transition segment in the time series.</para>
		/// <para>Time of fastest change—Each pixel will contain the date of change at the beginning or end of the transition that occurred most quickly.</para>
		/// <para>Time of slowest change—Each pixel will contain the date of change at the beginning or end of the transition that occurred most slowly.</para>
		/// <para><see cref="ChangeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ChangeType { get; set; } = "TIME_OF_LATEST_CHANGE";

		/// <summary>
		/// <para>Maximum Number of Changes</para>
		/// <para>The maximum number of changes per pixel that will be calculated. This number corresponds to the number of bands in the output raster. The default is 1, meaning only one change date will be calculated, and the output raster will contain only one band.</para>
		/// <para>This parameter is not active when the Change Type parameter is set to Number of changes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? MaxNumberChanges { get; set; } = "1";

		/// <summary>
		/// <para>Segment Date</para>
		/// <para>Specifies whether the date at the beginning of a change segment will be extracted or at the end.</para>
		/// <para>This parameter is available only when the input change analysis raster is the output from the Analyze Changes Using LandTrendr tool.</para>
		/// <para>Beginning of segment—The date at the beginning of a change segment will be extracted. This is the default.</para>
		/// <para>End of segment—The date at the end of a change segment will be extracted.</para>
		/// <para><see cref="SegmentDateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SegmentDate { get; set; } = "BEGINNING_OF_SEGMENT";

		/// <summary>
		/// <para>Change Direction</para>
		/// <para>Specifies the direction of change that will be included in the analysis.</para>
		/// <para>This parameter is available only when the input change analysis raster is the output from the Analyze Changes Using LandTrendr tool.</para>
		/// <para>All directions—All change directions will be included in the output. This is the default.</para>
		/// <para>Increasing—Only change in the positive or increasing direction will be included in the output.</para>
		/// <para>Decreasing—Only change in the negative or decreasing direction will be included in the output.</para>
		/// <para><see cref="ChangeDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ChangeDirection { get; set; } = "ALL";

		/// <summary>
		/// <para>Filter by Year</para>
		/// <para>Specifies whether the output will be filtered by a range of years.</para>
		/// <para>Checked—Results will be filtered so that only changes that occurred within a specific range of years will be included in the output.</para>
		/// <para>Unchecked—Results will not be filtered by year. This is the default.</para>
		/// <para><see cref="FilterByYearEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object? FilterByYear { get; set; } = "false";

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>The earliest year that will be used to filter results. This parameter is required if the Filter by Year parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MinYear { get; set; }

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>The latest year that will be used to filter results.</para>
		/// <para>This parameter is required if the Filter by Year parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MaxYear { get; set; }

		/// <summary>
		/// <para>Filter by Duration</para>
		/// <para>Specifies whether results will be filtered by the change duration.</para>
		/// <para>This parameter is active only when the input change analysis raster is the output from the Analyze Changes Using LandTrendr tool.</para>
		/// <para>Checked—Results will be filtered by duration so that only the changes that lasted a given amount of time will be included in the output.</para>
		/// <para>Unchecked—Results will not be filtered by duration. This is the default.</para>
		/// <para><see cref="FilterByDurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object? FilterByDuration { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  Duration (in years)</para>
		/// <para>The minimum number of consecutive years that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by Duration parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MinDuration { get; set; }

		/// <summary>
		/// <para>Maximum  Duration (in years)</para>
		/// <para>The maximum number of consecutive years that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by Duration parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MaxDuration { get; set; }

		/// <summary>
		/// <para>Filter by Magnitude</para>
		/// <para>Specifies whether results will be filtered by change magnitude.</para>
		/// <para>Checked—Results will be filtered by magnitude so that only the changes of a given magnitude will be included in the output.</para>
		/// <para>Unchecked—Results will not be filtered by magnitude. This is the default.</para>
		/// <para>Specifies whether results will be filtered by change magnitude.</para>
		/// <para>FILTER_BY_MAGNITUDE—Results will be filtered by magnitude so that only the changes of a given magnitude will be included in the output.</para>
		/// <para>NO_FILTER_BY_MAGNITUDE—Results will not be filtered by magnitude. This is the default.</para>
		/// <para><see cref="FilterByMagnitudeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object? FilterByMagnitude { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  Magnitude</para>
		/// <para>The minimum magnitude that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by Magnitude parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MinMagnitude { get; set; }

		/// <summary>
		/// <para>Maximum  Magnitude</para>
		/// <para>The maximum magnitude that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by Duration parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MaxMagnitude { get; set; }

		/// <summary>
		/// <para>Filter by Start Value</para>
		/// <para>Specifies whether results will be filtered by start value.</para>
		/// <para>This parameter is active only when the input change analysis raster is the output from the Analyze Changes Using LandTrendr tool.</para>
		/// <para>Checked—Results will be filtered by start value so that only the changes of a given start value will be included in the output.</para>
		/// <para>Unchecked—Results will not be filtered by start value. This is the default.</para>
		/// <para><see cref="FilterByStartValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object? FilterByStartValue { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  Start Value</para>
		/// <para>The minimum start value that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by Start Value parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MinStartValue { get; set; }

		/// <summary>
		/// <para>Maximum  Start Value</para>
		/// <para>The maximum start value that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by Start Value parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MaxStartValue { get; set; }

		/// <summary>
		/// <para>Filter by End Value</para>
		/// <para>Specifies whether results will be filtered by end value.</para>
		/// <para>This parameter is active only when the input change analysis raster is the output from the Analyze Changes Using LandTrendr tool.</para>
		/// <para>Checked—Results will be filtered by end value so that only the changes of a given end value will be included in the output.</para>
		/// <para>Unchecked—Results will not be filtered by end value. This is the default.</para>
		/// <para><see cref="FilterByEndValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object? FilterByEndValue { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  End Value</para>
		/// <para>The minimum end value that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by End Value parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MinEndValue { get; set; }

		/// <summary>
		/// <para>Maximum  End Value</para>
		/// <para>The maximum end value that will be included in the results.</para>
		/// <para>This parameter is required if the Filter by End Value parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object? MaxEndValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectChangeUsingChangeAnalysisRaster SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change Type</para>
		/// </summary>
		public enum ChangeTypeEnum 
		{
			/// <summary>
			/// <para>Time of latest change—Each pixel will contain the date of its most recent change in the time series. This is the default.</para>
			/// </summary>
			[GPValue("TIME_OF_LATEST_CHANGE")]
			[Description("Time of latest change")]
			Time_of_latest_change,

			/// <summary>
			/// <para>Time of earliest change—Each pixel will contain the date of its earliest change in the time series.</para>
			/// </summary>
			[GPValue("TIME_OF_EARLIEST_CHANGE")]
			[Description("Time of earliest change")]
			Time_of_earliest_change,

			/// <summary>
			/// <para>Time of largest change—Each pixel will contain the date of its most significant change in the time series.</para>
			/// </summary>
			[GPValue("TIME_OF_LARGEST_CHANGE")]
			[Description("Time of largest change")]
			Time_of_largest_change,

			/// <summary>
			/// <para>Number of changes—Each pixel will contain the total number of times it changed in the time series.</para>
			/// </summary>
			[GPValue("NUM_OF_CHANGES")]
			[Description("Number of changes")]
			Number_of_changes,

			/// <summary>
			/// <para>Time of longest change—Each pixel will contain the date of change at the beginning or end of the longest transition segment in the time series.</para>
			/// </summary>
			[GPValue("TIME_OF_LONGEST_CHANGE")]
			[Description("Time of longest change")]
			Time_of_longest_change,

			/// <summary>
			/// <para>Time of shortest change—Each pixel will contain the date of change at the beginning or end of the shortest transition segment in the time series.</para>
			/// </summary>
			[GPValue("TIME_OF_SHORTEST_CHANGE")]
			[Description("Time of shortest change")]
			Time_of_shortest_change,

			/// <summary>
			/// <para>Time of fastest change—Each pixel will contain the date of change at the beginning or end of the transition that occurred most quickly.</para>
			/// </summary>
			[GPValue("TIME_OF_FASTEST_CHANGE")]
			[Description("Time of fastest change")]
			Time_of_fastest_change,

			/// <summary>
			/// <para>Time of slowest change—Each pixel will contain the date of change at the beginning or end of the transition that occurred most slowly.</para>
			/// </summary>
			[GPValue("TIME_OF_SLOWEST_CHANGE")]
			[Description("Time of slowest change")]
			Time_of_slowest_change,

		}

		/// <summary>
		/// <para>Segment Date</para>
		/// </summary>
		public enum SegmentDateEnum 
		{
			/// <summary>
			/// <para>Beginning of segment—The date at the beginning of a change segment will be extracted. This is the default.</para>
			/// </summary>
			[GPValue("BEGINNING_OF_SEGMENT")]
			[Description("Beginning of segment")]
			Beginning_of_segment,

			/// <summary>
			/// <para>End of segment—The date at the end of a change segment will be extracted.</para>
			/// </summary>
			[GPValue("END_OF_SEGMENT")]
			[Description("End of segment")]
			End_of_segment,

		}

		/// <summary>
		/// <para>Change Direction</para>
		/// </summary>
		public enum ChangeDirectionEnum 
		{
			/// <summary>
			/// <para>All directions—All change directions will be included in the output. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All directions")]
			All_directions,

			/// <summary>
			/// <para>Increasing—Only change in the positive or increasing direction will be included in the output.</para>
			/// </summary>
			[GPValue("INCREASE")]
			[Description("Increasing")]
			Increasing,

			/// <summary>
			/// <para>Decreasing—Only change in the negative or decreasing direction will be included in the output.</para>
			/// </summary>
			[GPValue("DECREASE")]
			[Description("Decreasing")]
			Decreasing,

		}

		/// <summary>
		/// <para>Filter by Year</para>
		/// </summary>
		public enum FilterByYearEnum 
		{
			/// <summary>
			/// <para>Checked—Results will be filtered so that only changes that occurred within a specific range of years will be included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_YEAR")]
			FILTER_BY_YEAR,

			/// <summary>
			/// <para>Unchecked—Results will not be filtered by year. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER_BY_YEAR")]
			NO_FILTER_BY_YEAR,

		}

		/// <summary>
		/// <para>Filter by Duration</para>
		/// </summary>
		public enum FilterByDurationEnum 
		{
			/// <summary>
			/// <para>Checked—Results will be filtered by duration so that only the changes that lasted a given amount of time will be included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_DURATION")]
			FILTER_BY_DURATION,

			/// <summary>
			/// <para>Unchecked—Results will not be filtered by duration. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER_BY_DURATION")]
			NO_FILTER_BY_DURATION,

		}

		/// <summary>
		/// <para>Filter by Magnitude</para>
		/// </summary>
		public enum FilterByMagnitudeEnum 
		{
			/// <summary>
			/// <para>FILTER_BY_MAGNITUDE—Results will be filtered by magnitude so that only the changes of a given magnitude will be included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_MAGNITUDE")]
			FILTER_BY_MAGNITUDE,

			/// <summary>
			/// <para>NO_FILTER_BY_MAGNITUDE—Results will not be filtered by magnitude. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER_BY_MAGNITUDE")]
			NO_FILTER_BY_MAGNITUDE,

		}

		/// <summary>
		/// <para>Filter by Start Value</para>
		/// </summary>
		public enum FilterByStartValueEnum 
		{
			/// <summary>
			/// <para>Checked—Results will be filtered by start value so that only the changes of a given start value will be included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_START_VALUE")]
			FILTER_BY_START_VALUE,

			/// <summary>
			/// <para>Unchecked—Results will not be filtered by start value. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER_BY_START_VALUE")]
			NO_FILTER_BY_START_VALUE,

		}

		/// <summary>
		/// <para>Filter by End Value</para>
		/// </summary>
		public enum FilterByEndValueEnum 
		{
			/// <summary>
			/// <para>Checked—Results will be filtered by end value so that only the changes of a given end value will be included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_END_VALUE")]
			FILTER_BY_END_VALUE,

			/// <summary>
			/// <para>Unchecked—Results will not be filtered by end value. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER_BY_END_VALUE")]
			NO_FILTER_BY_END_VALUE,

		}

#endregion
	}
}
