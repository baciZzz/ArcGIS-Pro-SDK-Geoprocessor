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
	/// <para>Aggregate Multidimensional Raster</para>
	/// <para>聚合多维栅格</para>
	/// <para>通过沿维度组合现有多维栅格变量来生成多维栅格数据集。</para>
	/// </summary>
	public class AggregateMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </param>
		/// <param name="Dimension">
		/// <para>Dimension</para>
		/// <para>聚合维度。 这是聚合变量时所沿的维度。</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </param>
		public AggregateMultidimensionalRaster(object InMultidimensionalRaster, object Dimension, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.Dimension = Dimension;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 聚合多维栅格</para>
		/// </summary>
		public override string DisplayName() => "聚合多维栅格";

		/// <summary>
		/// <para>Tool Name : AggregateMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "AggregateMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.AggregateMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.AggregateMultidimensionalRaster";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, Dimension, OutMultidimensionalRaster, AggregationMethod, Variables, AggregationDef, IntervalKeyword, IntervalValue, IntervalUnit, IntervalRanges, AggregationFunction, IgnoreNodata, Dimensionless, PercentileValue, PercentileInterpolationType };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>聚合维度。 这是聚合变量时所沿的维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Aggregation Method</para>
		/// <para>指定将用于组合间隔中的已聚合剖切的数学方法。</para>
		/// <para>平均值—将计算间隔中所有时间片的像素值的平均值。 这是默认设置。</para>
		/// <para>最大值—将计算间隔中所有时间片的像素的最大值。</para>
		/// <para>众数—将计算间隔中所有时间片最常出现的像素值。</para>
		/// <para>最小值—将计算间隔中所有时间片的像素的最小值。</para>
		/// <para>少数—将计算间隔中所有时间片最不常出现的像素值。</para>
		/// <para>中值—将计算间隔中所有时间片的像素的中值。</para>
		/// <para>百分比数—计算间隔中所有时间片的像素值百分比数。 默认情况下将计算 90% 百分比数。 您可以使用百分数值参数来指定其他值（从 0 到 100）。</para>
		/// <para>范围—计算间隔中所有时间片的像素值范围。</para>
		/// <para>标准差—将计算间隔中所有时间片的像素值的标准差。</para>
		/// <para>总和—将计算间隔中所有时间片的像素值总和。</para>
		/// <para>变异度—将计算间隔中所有时间片的唯一像素值的数量。</para>
		/// <para>自定义—将基于自定义栅格函数来计算像素值。</para>
		/// <para>当方法设置为自定义时，聚合函数参数变为活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationMethod { get; set; } = "MEAN";

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>将沿给定维度聚合的一个或多个变量。 如果未指定变量，则将使用所选维度聚合所有变量。</para>
		/// <para>例如，要将每日温度数据聚合到月平均值，请将温度指定为要聚合的变量。 如果您没有指定任何变量，并且您同时拥有每日温度和日降雨量变量，则这两个变量将聚合到月平均值，并且输出多维栅格将包含两个变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Aggregation Definition</para>
		/// <para>指定要为其聚合数据的维度间隔。</para>
		/// <para>全部—将聚合所有剖切的数据值。 这是默认设置。</para>
		/// <para>间隔关键字—变量数据将使用常用间隔进行聚合。</para>
		/// <para>间隔值—变量数据将使用用户指定的间隔和单位进行聚合。</para>
		/// <para>间隔范围—变量数据将在指定的值对或日期之间进行聚合。</para>
		/// <para><see cref="AggregationDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationDef { get; set; } = "ALL";

		/// <summary>
		/// <para>Keyword Interval</para>
		/// <para>指定沿维度聚合时将使用的关键字间隔。 当聚合定义参数设置为间隔关键字并且聚合必须跨时间时，此参数为必需项。</para>
		/// <para>每小时—数据值将聚合为每小时时间步长，且结果将包括时间序列中的每个小时。</para>
		/// <para>每天—数据值将聚合为每日时间步长，且结果将包括时间序列中的每一天。</para>
		/// <para>每周—数据值将聚合为每周时间步长，且结果将包括时间序列中的每周。</para>
		/// <para>每十年—数据值将聚合为 3 个周期，每个周期为 10 天。 最后一个周期所包含的天数可以多于或少于 10 天。 每个月的输出中将包括 3 个时间片。</para>
		/// <para>每五年—数据值将聚合为 6 个周期，每个周期为 5 天。 最后一个周期所包含的天数可以多于或少于 5 天。 对于每个月，输出中将包括 6 个时间片。</para>
		/// <para>每月—数据值将聚合为每月时间步长，且结果将包括时间序列中的每个月。</para>
		/// <para>季度—数据值将聚合为季度时间步长，且结果将包括时间序列中的每个季度。</para>
		/// <para>每年—数据值将聚合为年度时间步长，且结果将包括时间序列中的每年。</para>
		/// <para>每天循环—数据值将聚合为每日时间步长，且结果将包括每个儒略日的一个聚合值。 输出中最多包括 366 个每日时间片。</para>
		/// <para>每周循环—数据值将聚合为每周时间步长，且结果将包括每周的一个聚合值。 输出中最多包括 53 个每周时间片。</para>
		/// <para>每月循环—数据值将聚合为每月时间步长，且结果将包括每月的一个聚合值。 输出中最多包括 12 个每月时间片。</para>
		/// <para>每季度循环—数据值将聚合为季度时间步长，且结果将包括每季度的一个聚合值。 输出中最多包括 4 个季度时间片。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalKeyword { get; set; }

		/// <summary>
		/// <para>Value Interval</para>
		/// <para>将用于聚合的间隔大小。 当聚合定义参数设置为间隔值时，此参数为必需项。</para>
		/// <para>例如，要将 30 年的每月温度数据聚合到 5 年增量，请输入 5 作为值间隔，并将单位指定为年。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object IntervalValue { get; set; }

		/// <summary>
		/// <para>Unit</para>
		/// <para>将用于值间隔参数的单位。 当维度参数为时间字段并且聚合定义参数设置为间隔值时，此参数为必需项。</para>
		/// <para>如果要聚合除时间之外的任何内容，则此选项将不可用，并且间隔值的单位将与输入多维栅格数据的变量单位一致。</para>
		/// <para>小时—数据值将按提供的间隔聚合到每小时时间片。</para>
		/// <para>天—数据值将按提供的间隔聚合到每日时间片。</para>
		/// <para>周—数据值将按提供的间隔聚合到每周时间片。</para>
		/// <para>月—数据值将按提供的间隔聚合到每月时间片。</para>
		/// <para>年—数据值将按提供的间隔聚合到每年时间片。</para>
		/// <para><see cref="IntervalUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalUnit { get; set; }

		/// <summary>
		/// <para>Range</para>
		/// <para>在值表中指定的间隔范围将用于聚合值组。 值表由最小和最大范围值对组成，数据类型为双精度或日期。</para>
		/// <para>当聚合定义参数设置为间隔范围时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object IntervalRanges { get; set; }

		/// <summary>
		/// <para>Aggregation Function</para>
		/// <para>将用于计算聚合栅格的像素值的自定义栅格函数。 输入是栅格函数 JSON 对象或基于函数链或自定义 Python 栅格函数创建的 .rft.xml 文件。</para>
		/// <para>当聚合方法参数设置为自定义时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object AggregationFunction { get; set; }

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
		public object IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Dimensionless</para>
		/// <para>指定图层是否具有维度值。 仅当选择单个剖切片来创建图层时，此参数才处于活动状态。</para>
		/// <para>选中 - 图层没有维度值。</para>
		/// <para>未选中 - 图层具有维度值。 这是默认设置。</para>
		/// <para><see cref="DimensionlessEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Dimensionless { get; set; } = "false";

		/// <summary>
		/// <para>Percentile value</para>
		/// <para>要计算的百分比数。默认值为 90，指示 90%。</para>
		/// <para>取值范围为 0 到 100。0% 基本上等同于“最小值”统计数据，而 100% 则等同于“最大值”。值 50 所生成的结果基本等同于“中值”统计数据的结果。</para>
		/// <para>此选项仅在将统计类型参数设置为百分比数后可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile interpolation type</para>
		/// <para>指定输入栅格中要计算的值数为偶数时使用的百分位数插值方法。</para>
		/// <para>最邻近—将使用最接近所需的百分位数的可用值。 在这种情况下，输出像素类型与输入值栅格的像素类型相同。</para>
		/// <para>线性—将使用接近所需百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
		/// <para><see cref="PercentileInterpolationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PercentileInterpolationType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregateMultidimensionalRaster SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Aggregation Definition</para>
		/// </summary>
		public enum AggregationDefEnum 
		{
			/// <summary>
			/// <para>全部—将聚合所有剖切的数据值。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>间隔关键字—变量数据将使用常用间隔进行聚合。</para>
			/// </summary>
			[GPValue("INTERVAL_KEYWORD")]
			[Description("间隔关键字")]
			Interval_Keyword,

			/// <summary>
			/// <para>间隔值—变量数据将使用用户指定的间隔和单位进行聚合。</para>
			/// </summary>
			[GPValue("INTERVAL_VALUE")]
			[Description("间隔值")]
			Interval_Value,

			/// <summary>
			/// <para>间隔范围—变量数据将在指定的值对或日期之间进行聚合。</para>
			/// </summary>
			[GPValue("INTERVAL_RANGES")]
			[Description("间隔范围")]
			Interval_Ranges,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum IntervalUnitEnum 
		{
			/// <summary>
			/// <para>小时—数据值将按提供的间隔聚合到每小时时间片。</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>天—数据值将按提供的间隔聚合到每日时间片。</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>周—数据值将按提供的间隔聚合到每周时间片。</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para>月—数据值将按提供的间隔聚合到每月时间片。</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para>年—数据值将按提供的间隔聚合到每年时间片。</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("年")]
			Years,

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
		/// <para>Dimensionless</para>
		/// </summary>
		public enum DimensionlessEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIMENSIONS")]
			NO_DIMENSIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIMENSIONS")]
			DIMENSIONS,

		}

		/// <summary>
		/// <para>Percentile interpolation type</para>
		/// </summary>
		public enum PercentileInterpolationTypeEnum 
		{
			/// <summary>
			/// <para>最邻近—将使用最接近所需的百分位数的可用值。 在这种情况下，输出像素类型与输入值栅格的像素类型相同。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>线性—将使用接近所需百分位数的两个值的加权平均值。 在这种情况下，输出像素类型为浮点型。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

		}

#endregion
	}
}
