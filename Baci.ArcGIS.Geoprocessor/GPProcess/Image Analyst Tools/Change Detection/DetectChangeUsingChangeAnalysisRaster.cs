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
	/// <para>使用更改分析栅格检测更改</para>
	/// <para>可以利用使用 CCDC 分析变化或使用 LandTrendr 分析变化工具的输出变化分析栅格来生成包含像素变化信息的栅格。</para>
	/// </summary>
	public class DetectChangeUsingChangeAnalysisRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InChangeAnalysisRaster">
		/// <para>Input Change Analysis Raster</para>
		/// <para>通过使用 CCDC 分析变化工具或使用 LandTrendr 分析变化工具生成的变化分析栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>包含检测变化信息的输出栅格。</para>
		/// </param>
		/// <param name="ChangeType">
		/// <para>Change Type</para>
		/// <para>指定要为每个像素计算的变化信息。</para>
		/// <para>最新变化的时间—每个像素都将包含其在时间序列中最近变化的日期。 这是默认设置。</para>
		/// <para>最早变化的日期—每个像素都将包含其在时间序列中最早变化的日期。</para>
		/// <para>最大变化的日期—每个像素都将包含其在时间序列中最显著变化的日期。</para>
		/// <para>变化次数—每个像素都将包含其在时间序列中发生变化的总次数。</para>
		/// <para>最长变化的时间—每个像素将包含时间序列中位于最长过渡段的起点或终点处的变化日期。</para>
		/// <para>最短变化的时间—每个像素将包含时间序列中位于最短过渡段的起点或终点处的变化日期。</para>
		/// <para>最快变化的时间—每个像素将包含位于最快发生的过渡起点或终点的变化日期。</para>
		/// <para>最慢变化的时间—每个像素将包含位于最慢发生的过渡起点或终点的变化日期。</para>
		/// <para><see cref="ChangeTypeEnum"/></para>
		/// </param>
		public DetectChangeUsingChangeAnalysisRaster(object InChangeAnalysisRaster, object OutRaster, object ChangeType)
		{
			this.InChangeAnalysisRaster = InChangeAnalysisRaster;
			this.OutRaster = OutRaster;
			this.ChangeType = ChangeType;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用更改分析栅格检测更改</para>
		/// </summary>
		public override string DisplayName() => "使用更改分析栅格检测更改";

		/// <summary>
		/// <para>Tool Name : DetectChangeUsingChangeAnalysisRaster</para>
		/// </summary>
		public override string ToolName() => "DetectChangeUsingChangeAnalysisRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.DetectChangeUsingChangeAnalysisRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.DetectChangeUsingChangeAnalysisRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InChangeAnalysisRaster, OutRaster, ChangeType, MaxNumberChanges, SegmentDate, ChangeDirection, FilterByYear, MinYear, MaxYear, FilterByDuration, MinDuration, MaxDuration, FilterByMagnitude, MinMagnitude, MaxMagnitude, FilterByStartValue, MinStartValue, MaxStartValue, FilterByEndValue, MinEndValue, MaxEndValue };

		/// <summary>
		/// <para>Input Change Analysis Raster</para>
		/// <para>通过使用 CCDC 分析变化工具或使用 LandTrendr 分析变化工具生成的变化分析栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InChangeAnalysisRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>包含检测变化信息的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Change Type</para>
		/// <para>指定要为每个像素计算的变化信息。</para>
		/// <para>最新变化的时间—每个像素都将包含其在时间序列中最近变化的日期。 这是默认设置。</para>
		/// <para>最早变化的日期—每个像素都将包含其在时间序列中最早变化的日期。</para>
		/// <para>最大变化的日期—每个像素都将包含其在时间序列中最显著变化的日期。</para>
		/// <para>变化次数—每个像素都将包含其在时间序列中发生变化的总次数。</para>
		/// <para>最长变化的时间—每个像素将包含时间序列中位于最长过渡段的起点或终点处的变化日期。</para>
		/// <para>最短变化的时间—每个像素将包含时间序列中位于最短过渡段的起点或终点处的变化日期。</para>
		/// <para>最快变化的时间—每个像素将包含位于最快发生的过渡起点或终点的变化日期。</para>
		/// <para>最慢变化的时间—每个像素将包含位于最慢发生的过渡起点或终点的变化日期。</para>
		/// <para><see cref="ChangeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ChangeType { get; set; } = "TIME_OF_LATEST_CHANGE";

		/// <summary>
		/// <para>Maximum Number of Changes</para>
		/// <para>要计算的每个像素的最大变化次数。 该数字与输出栅格中的波段数相对应。 默认值为 1，表示将仅计算一个变化日期，且输出栅格将仅包含一个波段。</para>
		/// <para>当变化类型参数设置为变化次数时，此参数将处于非活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object MaxNumberChanges { get; set; } = "1";

		/// <summary>
		/// <para>Segment Date</para>
		/// <para>指定是提取位于变化段的起点还是终点处的日期。</para>
		/// <para>仅当输入变化分析栅格是来自使用 LandTrendr 分析变化工具的输出时，此参数才可用。</para>
		/// <para>段起点—将提取位于变化段的起点处的日期。 这是默认设置。</para>
		/// <para>段终点—将提取位于变化段的终点处的日期。</para>
		/// <para><see cref="SegmentDateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SegmentDate { get; set; } = "BEGINNING_OF_SEGMENT";

		/// <summary>
		/// <para>Change Direction</para>
		/// <para>指定要在分析中包含的变化方向。</para>
		/// <para>仅当输入变化分析栅格是来自使用 LandTrendr 分析变化工具的输出时，此参数才可用。</para>
		/// <para>全部方向—所有变化方向将包含在输出中。 这是默认设置。</para>
		/// <para>递增—输出中仅包含正向或递增方向的变化。</para>
		/// <para>递减—输出中仅包含负向或递减方向的变化。</para>
		/// <para><see cref="ChangeDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ChangeDirection { get; set; } = "ALL";

		/// <summary>
		/// <para>Filter by Year</para>
		/// <para>指定是否按年范围过滤输出。</para>
		/// <para>选中 - 将过滤结果，以仅在输出中包含特定年范围内发生的变化。</para>
		/// <para>未选中 - 不会按年对结果进行过滤。 这是默认设置。</para>
		/// <para><see cref="FilterByYearEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object FilterByYear { get; set; } = "false";

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>用于过滤结果的最早年份。 选中按年过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object MinYear { get; set; }

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>用于过滤结果的最近年份。</para>
		/// <para>选中按年过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object MaxYear { get; set; }

		/// <summary>
		/// <para>Filter by Duration</para>
		/// <para>指定是否按变化持续时间对结果进行过滤。</para>
		/// <para>仅当输入变化分析栅格是来自使用 LandTrendr 分析变化工具的输出时，此参数才处于活动状态。</para>
		/// <para>选中 - 将按持续时间过滤结果，以仅在输出中包含持续给定时间的变化。</para>
		/// <para>未选中 - 不会按持续时间对结果进行过滤。 这是默认设置。</para>
		/// <para><see cref="FilterByDurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object FilterByDuration { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  Duration (in years)</para>
		/// <para>将包含在结果中的最小连续年数。</para>
		/// <para>当选中按持续时间过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Filter By Attributes")]
		public object MinDuration { get; set; }

		/// <summary>
		/// <para>Maximum  Duration (in years)</para>
		/// <para>将包含在结果中的最大连续年数。</para>
		/// <para>当选中按持续时间过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Filter By Attributes")]
		public object MaxDuration { get; set; }

		/// <summary>
		/// <para>Filter by Magnitude</para>
		/// <para>指定是否按变化量级对结果进行过滤。</para>
		/// <para>选中 - 将按量级过滤结果，以仅在输出中包含给定量级的变化。</para>
		/// <para>未选中 - 不会按量级对结果进行过滤。 这是默认设置。</para>
		/// <para>指定是否按变化量级对结果进行过滤。</para>
		/// <para>FILTER_BY_MAGNITUDE—将按量级过滤结果，以仅在输出中包含给定量级的变化。</para>
		/// <para>NO_FILTER_BY_MAGNITUDE—不会按量级对结果进行过滤。 这是默认设置。</para>
		/// <para><see cref="FilterByMagnitudeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object FilterByMagnitude { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  Magnitude</para>
		/// <para>将包含在结果中的最小量级。</para>
		/// <para>当选中按量级过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Filter By Attributes")]
		public object MinMagnitude { get; set; }

		/// <summary>
		/// <para>Maximum  Magnitude</para>
		/// <para>将包含在结果中的最大量级。</para>
		/// <para>当选中按持续时间过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Filter By Attributes")]
		public object MaxMagnitude { get; set; }

		/// <summary>
		/// <para>Filter by Start Value</para>
		/// <para>指定是否按起始值对结果进行过滤。</para>
		/// <para>仅当输入变化分析栅格是来自使用 LandTrendr 分析变化工具的输出时，此参数才处于活动状态。</para>
		/// <para>选中 - 将按起始值过滤结果，以仅在输出中包含给定起始值的变化。</para>
		/// <para>未选中 - 不会按起始值对结果进行过滤。 这是默认设置。</para>
		/// <para><see cref="FilterByStartValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object FilterByStartValue { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  Start Value</para>
		/// <para>将包含在结果中的最小起始值。</para>
		/// <para>选中按起始值过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object MinStartValue { get; set; }

		/// <summary>
		/// <para>Maximum  Start Value</para>
		/// <para>将包含在结果中的最大起始值。</para>
		/// <para>选中按起始值过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object MaxStartValue { get; set; }

		/// <summary>
		/// <para>Filter by End Value</para>
		/// <para>指定是否按结束值对结果进行过滤。</para>
		/// <para>仅当输入变化分析栅格是来自使用 LandTrendr 分析变化工具的输出时，此参数才处于活动状态。</para>
		/// <para>选中 - 将按结束值过滤结果，以仅在输出中包含给定结束值的变化。</para>
		/// <para>未选中 - 不会按结束值对结果进行过滤。 这是默认设置。</para>
		/// <para><see cref="FilterByEndValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filter By Attributes")]
		public object FilterByEndValue { get; set; } = "false";

		/// <summary>
		/// <para>Minimum  End Value</para>
		/// <para>将包含在结果中的最小结束值。</para>
		/// <para>选中按结束值过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object MinEndValue { get; set; }

		/// <summary>
		/// <para>Maximum  End Value</para>
		/// <para>将包含在结果中的最大结束值。</para>
		/// <para>选中按结束值过滤参数时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Filter By Attributes")]
		public object MaxEndValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectChangeUsingChangeAnalysisRaster SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
			/// <para>最新变化的时间—每个像素都将包含其在时间序列中最近变化的日期。 这是默认设置。</para>
			/// </summary>
			[GPValue("TIME_OF_LATEST_CHANGE")]
			[Description("最新变化的时间")]
			Time_of_latest_change,

			/// <summary>
			/// <para>最早变化的日期—每个像素都将包含其在时间序列中最早变化的日期。</para>
			/// </summary>
			[GPValue("TIME_OF_EARLIEST_CHANGE")]
			[Description("最早变化的日期")]
			Time_of_earliest_change,

			/// <summary>
			/// <para>最大变化的日期—每个像素都将包含其在时间序列中最显著变化的日期。</para>
			/// </summary>
			[GPValue("TIME_OF_LARGEST_CHANGE")]
			[Description("最大变化的日期")]
			Time_of_largest_change,

			/// <summary>
			/// <para>变化次数—每个像素都将包含其在时间序列中发生变化的总次数。</para>
			/// </summary>
			[GPValue("NUM_OF_CHANGES")]
			[Description("变化次数")]
			Number_of_changes,

			/// <summary>
			/// <para>最长变化的时间—每个像素将包含时间序列中位于最长过渡段的起点或终点处的变化日期。</para>
			/// </summary>
			[GPValue("TIME_OF_LONGEST_CHANGE")]
			[Description("最长变化的时间")]
			Time_of_longest_change,

			/// <summary>
			/// <para>最短变化的时间—每个像素将包含时间序列中位于最短过渡段的起点或终点处的变化日期。</para>
			/// </summary>
			[GPValue("TIME_OF_SHORTEST_CHANGE")]
			[Description("最短变化的时间")]
			Time_of_shortest_change,

			/// <summary>
			/// <para>最快变化的时间—每个像素将包含位于最快发生的过渡起点或终点的变化日期。</para>
			/// </summary>
			[GPValue("TIME_OF_FASTEST_CHANGE")]
			[Description("最快变化的时间")]
			Time_of_fastest_change,

			/// <summary>
			/// <para>最慢变化的时间—每个像素将包含位于最慢发生的过渡起点或终点的变化日期。</para>
			/// </summary>
			[GPValue("TIME_OF_SLOWEST_CHANGE")]
			[Description("最慢变化的时间")]
			Time_of_slowest_change,

		}

		/// <summary>
		/// <para>Segment Date</para>
		/// </summary>
		public enum SegmentDateEnum 
		{
			/// <summary>
			/// <para>段起点—将提取位于变化段的起点处的日期。 这是默认设置。</para>
			/// </summary>
			[GPValue("BEGINNING_OF_SEGMENT")]
			[Description("段起点")]
			Beginning_of_segment,

			/// <summary>
			/// <para>段终点—将提取位于变化段的终点处的日期。</para>
			/// </summary>
			[GPValue("END_OF_SEGMENT")]
			[Description("段终点")]
			End_of_segment,

		}

		/// <summary>
		/// <para>Change Direction</para>
		/// </summary>
		public enum ChangeDirectionEnum 
		{
			/// <summary>
			/// <para>全部方向—所有变化方向将包含在输出中。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部方向")]
			All_directions,

			/// <summary>
			/// <para>递增—输出中仅包含正向或递增方向的变化。</para>
			/// </summary>
			[GPValue("INCREASE")]
			[Description("递增")]
			Increasing,

			/// <summary>
			/// <para>递减—输出中仅包含负向或递减方向的变化。</para>
			/// </summary>
			[GPValue("DECREASE")]
			[Description("递减")]
			Decreasing,

		}

		/// <summary>
		/// <para>Filter by Year</para>
		/// </summary>
		public enum FilterByYearEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_YEAR")]
			FILTER_BY_YEAR,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_DURATION")]
			FILTER_BY_DURATION,

			/// <summary>
			/// <para></para>
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
			/// <para>FILTER_BY_MAGNITUDE—将按量级过滤结果，以仅在输出中包含给定量级的变化。</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_MAGNITUDE")]
			FILTER_BY_MAGNITUDE,

			/// <summary>
			/// <para>NO_FILTER_BY_MAGNITUDE—不会按量级对结果进行过滤。 这是默认设置。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_START_VALUE")]
			FILTER_BY_START_VALUE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_END_VALUE")]
			FILTER_BY_END_VALUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER_BY_END_VALUE")]
			NO_FILTER_BY_END_VALUE,

		}

#endregion
	}
}
