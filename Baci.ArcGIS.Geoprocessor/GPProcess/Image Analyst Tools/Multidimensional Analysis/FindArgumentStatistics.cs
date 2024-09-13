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
	/// <para>Find Argument Statistics</para>
	/// <para>查找参数统计信息</para>
	/// <para>用于为多维或多波段栅格中的每个像素提取达到给定统计量的维度值或波段指数。</para>
	/// </summary>
	public class FindArgumentStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Multidimensional or Multiband Raster</para>
		/// <para>要分析的输入多维或多波段栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格数据集。</para>
		/// </param>
		public FindArgumentStatistics(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找参数统计信息</para>
		/// </summary>
		public override string DisplayName() => "查找参数统计信息";

		/// <summary>
		/// <para>Tool Name : FindArgumentStatistics</para>
		/// </summary>
		public override string ToolName() => "FindArgumentStatistics";

		/// <summary>
		/// <para>Tool Excute Name : ia.FindArgumentStatistics</para>
		/// </summary>
		public override string ExcuteName() => "ia.FindArgumentStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Dimension!, DimensionDef!, IntervalKeyword!, Variables!, StatisticsType!, Min!, Max!, MultipleOccurrence!, IgnoreNodata!, Value!, Comparison!, Occurrence! };

		/// <summary>
		/// <para>Input Multidimensional or Multiband Raster</para>
		/// <para>要分析的输入多维或多波段栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>将从中提取统计数据的维度。 如果输入栅格不是多维栅格，则不需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Dimension { get; set; }

		/// <summary>
		/// <para>Dimension Definition</para>
		/// <para>指定如何从维度中提取统计数据。</para>
		/// <para>全部—将跨所有维度提取统计数据。 这是默认设置。</para>
		/// <para>间隔关键字—系统将根据间隔关键字从时间维度中提取统计数据。</para>
		/// <para><see cref="DimensionDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DimensionDef { get; set; } = "ALL";

		/// <summary>
		/// <para>Keyword Interval</para>
		/// <para>将用于提取统计数据的时间单位。</para>
		/// <para>例如，您拥有五年的每日海面温度数据，且您希望知道观测到最高温度的年份。 将统计类型设置为参数最大值，将维度定义设置为间隔关键字，并将关键字间隔设置为每年。</para>
		/// <para>或者，如果您想知道在哪个月份可以一直观测到最高温度，请将统计类型设置为参数最大值，将维度定义设置为间隔关键字，并将关键字间隔设置为每月循环。 该操作将生成一个栅格，其中每个像素都包含五年记录中达到统计数据的月份（例如 08/18/2018、08/25/2016、08/07/2013）。</para>
		/// <para>当维度参数设置为 StdTime 且维度定义参数设置为间隔关键字时，此参数为必需项。</para>
		/// <para><see cref="IntervalKeywordEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IntervalKeyword { get; set; }

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>要分析的一个或多个变量。 如果输入栅格不是多维栅格，则系统会将多波段栅格的像素值视为变量。 如果输入栅格是多维栅格，且未指定任何变量，则系统将分析具有所选维度的全部变量。</para>
		/// <para>例如，要查找温度值最高的年份，请将温度指定为要分析的变量。 如果您没有指定任何变量，并且您同时拥有温度和降水量变量，则将分析这两个变量，并且输出多维栅格将包含两个变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>指定要沿给定维度从一个或多个变量中提取的统计数据。</para>
		/// <para>参数最小值—将提取达到最小变量值时的维度值。 这是默认设置。</para>
		/// <para>参数最大值—将提取达到最大变量值时的维度值。</para>
		/// <para>参数中值—将提取达到变量中值时的维度值。</para>
		/// <para>持续时间—将提取最小变量值和最大变量值之间的最长维度持续时间值。</para>
		/// <para>值参数—将提取达到指定变量值时的维度值。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StatisticsType { get; set; } = "ARGUMENT_MIN";

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>用于提取持续时间的最小变量值。</para>
		/// <para>当统计类型参数设置为持续时间时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Min { get; set; }

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>用于提取持续时间的最大变量值。</para>
		/// <para>当统计类型参数设置为持续时间时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Max { get; set; }

		/// <summary>
		/// <para>Multiple Occurrence Value</para>
		/// <para>用于表示输入栅格数据集中多次达到给定参数统计数据的像素值。 如果未指定，则像素值将为由出现参数指定的维度值（第一次或最后一次出现）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MultipleOccurrence { get; set; }

		/// <summary>
		/// <para>Ignore NoData</para>
		/// <para>指定分析中是否忽略 NoData 值。</para>
		/// <para>已选中 - 分析将包括沿给定维度的所有有效像素，并忽略所有 NoData 像素。 这是默认设置。</para>
		/// <para>未选中 - 如果沿给定维度的像素包含任意 NoData 值，则分析结果将变为 NoData。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Argument Value</para>
		/// <para>将用于执行比较以提取维度值的值。</para>
		/// <para>当统计类型参数设置为值参数时，此参数为必需项。</para>
		/// <para>将用于执行比较以提取维度值的值。</para>
		/// <para>当将 statistics_type 参数设置为 ARGUMENT_VALUE 时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Value { get; set; }

		/// <summary>
		/// <para>Comparison</para>
		/// <para>指定将用于提取维度值的比较类型。</para>
		/// <para>等于—提取的维度等于指定值。 这是默认设置。</para>
		/// <para>大于—提取的维度大于指定值。</para>
		/// <para>小于—提取的维度小于指定值。</para>
		/// <para><see cref="ComparisonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Comparison { get; set; } = "EQUAL_TO";

		/// <summary>
		/// <para>Occurrence</para>
		/// <para>指定是在第一次还是最后一次达到参数统计信息时返回维度值。</para>
		/// <para>第一次出现—将在第一次达到参数统计信息时返回维度值。 这是默认设置。</para>
		/// <para>最后一次出现—将在最后一次达到参数统计信息时返回维度值。</para>
		/// <para><see cref="OccurrenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Occurrence { get; set; } = "FIRST_OCCURRENCE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindArgumentStatistics SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dimension Definition</para>
		/// </summary>
		public enum DimensionDefEnum 
		{
			/// <summary>
			/// <para>全部—将跨所有维度提取统计数据。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>间隔关键字—系统将根据间隔关键字从时间维度中提取统计数据。</para>
			/// </summary>
			[GPValue("INTERVAL_KEYWORD")]
			[Description("间隔关键字")]
			Interval_Keyword,

		}

		/// <summary>
		/// <para>Keyword Interval</para>
		/// </summary>
		public enum IntervalKeywordEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("HOURLY")]
			[Description("每小时")]
			Hourly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DAILY")]
			[Description("每天")]
			Daily,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WEEKLY")]
			[Description("每周")]
			Weekly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MONTHLY")]
			[Description("每月")]
			Monthly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("QUARTERLY")]
			[Description("季度")]
			Quarterly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("YEARLY")]
			[Description("每年")]
			Yearly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_DAILY")]
			[Description("每天循环")]
			Recurring_Daily,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_WEEKLY")]
			[Description("每周循环")]
			Recurring_Weekly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_MONTHLY")]
			[Description("每月循环")]
			Recurring_Monthly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_QUARTERLY")]
			[Description("每季度循环")]
			Recurring_Quarterly,

		}

		/// <summary>
		/// <para>Statistics Type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>参数最小值—将提取达到最小变量值时的维度值。 这是默认设置。</para>
			/// </summary>
			[GPValue("ARGUMENT_MIN")]
			[Description("参数最小值")]
			Argument_of_the_minimum,

			/// <summary>
			/// <para>参数最大值—将提取达到最大变量值时的维度值。</para>
			/// </summary>
			[GPValue("ARGUMENT_MAX")]
			[Description("参数最大值")]
			Argument_of_the_maximum,

			/// <summary>
			/// <para>参数中值—将提取达到变量中值时的维度值。</para>
			/// </summary>
			[GPValue("ARGUMENT_MEDIAN")]
			[Description("参数中值")]
			Argument_of_the_median,

			/// <summary>
			/// <para>持续时间—将提取最小变量值和最大变量值之间的最长维度持续时间值。</para>
			/// </summary>
			[GPValue("DURATION")]
			[Description("持续时间")]
			Duration,

			/// <summary>
			/// <para>值参数—将提取达到指定变量值时的维度值。</para>
			/// </summary>
			[GPValue("ARGUMENT_VALUE")]
			[Description("值参数")]
			Argument_of_the_value,

		}

		/// <summary>
		/// <para>Ignore NoData</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Comparison</para>
		/// </summary>
		public enum ComparisonEnum 
		{
			/// <summary>
			/// <para>等于—提取的维度等于指定值。 这是默认设置。</para>
			/// </summary>
			[GPValue("EQUAL_TO")]
			[Description("等于")]
			Equal_to,

			/// <summary>
			/// <para>大于—提取的维度大于指定值。</para>
			/// </summary>
			[GPValue("GREATER_THAN")]
			[Description("大于")]
			Greater_than,

			/// <summary>
			/// <para>小于—提取的维度小于指定值。</para>
			/// </summary>
			[GPValue("SMALLER_THAN")]
			[Description("小于")]
			Smaller_than,

		}

		/// <summary>
		/// <para>Occurrence</para>
		/// </summary>
		public enum OccurrenceEnum 
		{
			/// <summary>
			/// <para>第一次出现—将在第一次达到参数统计信息时返回维度值。 这是默认设置。</para>
			/// </summary>
			[GPValue("FIRST_OCCURRENCE")]
			[Description("第一次出现")]
			First_occurrence,

			/// <summary>
			/// <para>最后一次出现—将在最后一次达到参数统计信息时返回维度值。</para>
			/// </summary>
			[GPValue("LAST_OCCURRENCE")]
			[Description("最后一次出现")]
			Last_occurrence,

		}

#endregion
	}
}
