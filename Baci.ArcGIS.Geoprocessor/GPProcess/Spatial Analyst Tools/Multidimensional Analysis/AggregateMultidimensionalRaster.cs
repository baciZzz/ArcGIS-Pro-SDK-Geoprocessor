using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Aggregate Multidimensional Raster</para>
	/// <para>Generates a multidimensional raster dataset by combining existing multidimensional raster variables along a dimension.</para>
	/// </summary>
	public class AggregateMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </param>
		/// <param name="Dimension">
		/// <para>Dimension</para>
		/// <para>The aggregation dimension. This is the dimension along which the variables will be aggregated.</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </param>
		public AggregateMultidimensionalRaster(object InMultidimensionalRaster, object Dimension, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.Dimension = Dimension;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate Multidimensional Raster</para>
		/// </summary>
		public override string DisplayName => "Aggregate Multidimensional Raster";

		/// <summary>
		/// <para>Tool Name : AggregateMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName => "AggregateMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.AggregateMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName => "sa.AggregateMultidimensionalRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMultidimensionalRaster, Dimension, OutMultidimensionalRaster, AggregationMethod, Variables, AggregationDef, IntervalKeyword, IntervalValue, IntervalUnit, IntervalRanges, AggregationFunction, IgnoreNodata, Dimensionless, PercentileValue, PercentileInterpolationType };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The aggregation dimension. This is the dimension along which the variables will be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Aggregation Method</para>
		/// <para>Specifies the mathematical method that will be used to combine the aggregated slices in an interval.</para>
		/// <para>Mean—The mean of a pixel&apos;s values will be calculated across all slices in the interval. This is the default.</para>
		/// <para>Maximum—The maximum value of a pixel will be calculated across all slices in the interval.</para>
		/// <para>Majority—The pixel value that occurred most frequently will be calculated across all slices in the interval.</para>
		/// <para>Minimum—The minimum value of a pixel will be calculated across all slices in the interval.</para>
		/// <para>Minority—The pixel value that occurred least frequently will be calculated across all slices in the interval.</para>
		/// <para>Median—The median value of a pixel will be calculated across all slices in the interval.</para>
		/// <para>Percentile—The percentile of values for a pixel will be calculated across all slices in the interval. The 90th percentile is calculated by default. You can specify other values (from 0 to 100) using the Percentile value parameter.</para>
		/// <para>Range—The range of values for a pixel will be calculated across all slices in the interval.</para>
		/// <para>Standard Deviation—The standard deviation of a pixel&apos;s values will be calculated across all slices in the interval.</para>
		/// <para>Sum—The sum of a pixel&apos;s values will be calculated across all slices in the interval.</para>
		/// <para>Variety—The number of unique pixel values will be calculated across all slices in the interval.</para>
		/// <para>Custom—The pixel value will be calculated based on a custom raster function.</para>
		/// <para>When the method is set to Custom, the Aggregation Function parameter becomes active.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationMethod { get; set; } = "MEAN";

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>The variable or variables that will be aggregated along the given dimension. If no variable is specified, all variables with the selected dimension will be aggregated.</para>
		/// <para>For example, to aggregate daily temperature data into monthly average values, specify temperature as the variable to be aggregated. If you do not specify any variables and you have both daily temperature and daily precipitation variables, both variables will be aggregated into monthly averages and the output multidimensional raster will include both variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Aggregation Definition</para>
		/// <para>Specifies the dimension interval for which the data will be aggregated.</para>
		/// <para>All—The data values will be aggregated across all slices. This is the default.</para>
		/// <para>Interval Keyword—The variable data will be aggregated using a commonly known interval.</para>
		/// <para>Interval Value—The variable data will be aggregated using a user-specified interval and unit.</para>
		/// <para>Interval Ranges—The variable data will be aggregated between specified pairs of values or dates.</para>
		/// <para><see cref="AggregationDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationDef { get; set; } = "ALL";

		/// <summary>
		/// <para>Keyword Interval</para>
		/// <para>Specifies the keyword interval that will be used when aggregating along the dimension. This parameter is required when the Aggregation Definition parameter is set to Interval Keyword and the aggregation must be across time.</para>
		/// <para>Hourly—The data values will be aggregated into hourly time steps, and the result will include every hour in the time series.</para>
		/// <para>Daily—The data values will be aggregated into daily time steps, and the result will include every day in the time series.</para>
		/// <para>Weekly—The data values will be aggregated into weekly time steps, and the result will include every week in the time series.</para>
		/// <para>Dekadly—The data values will be aggregated into 3 periods of 10 days each. The last period can contain more or fewer than 10 days. The output will include 3 slices for each month.</para>
		/// <para>Pentadly—The data values will be aggregated into 6 periods of 5 days each. The last period can contain more or fewer than 5 days. The output will include 6 slices for each month.</para>
		/// <para>Monthly—The data values will be aggregated into monthly time steps, and the result will include every month in the time series.</para>
		/// <para>Quarterly—The data values will be aggregated into quarterly time steps, and the result will include every quarter in the time series.</para>
		/// <para>Yearly—The data values will be aggregated into yearly time steps, and the result will include every year in the time series.</para>
		/// <para>Recurring daily—The data values will be aggregated into daily time steps, and the result will include one aggregated value per Julian day. The output will include, at most, 366 daily time slices.</para>
		/// <para>Recurring weekly—The data values will be aggregated into weekly time steps, and the result will include one aggregated value per week. The output will include, at most, 53 weekly time slices.</para>
		/// <para>Recurring monthly—The data values will be aggregated into monthly time steps, and the result will include one aggregated value per month. The output will include, at most, 12 monthly time slices.</para>
		/// <para>Recurring quarterly—The data values will be aggregated into quarterly time steps, and the result will include one aggregated value per quarter. The output will include, at most, 4 quarterly time slices.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalKeyword { get; set; }

		/// <summary>
		/// <para>Value Interval</para>
		/// <para>The size of the interval that will be used for the aggregation. This parameter is required when the Aggregation Definition parameter is set to Interval Value.</para>
		/// <para>For example, to aggregate 30 years of monthly temperature data into 5-year increments, enter 5 as the Value Interval, and specify Unit as Years.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object IntervalValue { get; set; }

		/// <summary>
		/// <para>Unit</para>
		/// <para>The unit that will be used for the Value Interval parameter. This parameter is required when the Dimension parameter is a time field and the Aggregation Definition parameter is set to Interval Value.</para>
		/// <para>If you are aggregating anything other than time, this option will not be available and the unit for the interval value will match the variable unit of the input multidimensional raster data.</para>
		/// <para>Hours—The data values will be aggregated into hourly time slices at the interval provided.</para>
		/// <para>Days—The data values will be aggregated into daily time slices at the interval provided.</para>
		/// <para>Weeks—The data values will be aggregated into weekly time slices at the interval provided.</para>
		/// <para>Months—The data values will be aggregated into monthly time slices at the interval provided.</para>
		/// <para>Years—The data values will be aggregated into yearly time slices at the interval provided.</para>
		/// <para><see cref="IntervalUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalUnit { get; set; }

		/// <summary>
		/// <para>Range</para>
		/// <para>Interval ranges specified in a value table will be used to aggregate groups of values. The value table consists of pairs of minimum and maximum range values, with data type Double or Date.</para>
		/// <para>This parameter is required when the Aggregation Definition parameter is set to Interval Ranges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object IntervalRanges { get; set; }

		/// <summary>
		/// <para>Aggregation Function</para>
		/// <para>A custom raster function that will be used to compute the pixel values of the aggregated rasters. The input is a raster function JSON object or an .rft.xml file created from a function chain or a custom Python raster function.</para>
		/// <para>This parameter is required when the Aggregation Method parameter is set to Custom.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object AggregationFunction { get; set; }

		/// <summary>
		/// <para>Ignore NoData</para>
		/// <para>Specifies whether NoData values are ignored in the analysis.</para>
		/// <para>Checked—The analysis will include all valid pixels along a given dimension and ignore any NoData pixels. This is the default.</para>
		/// <para>Unchecked—The analysis will result in NoData if there are any NoData values for the pixels along the given dimension.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Dimensionless</para>
		/// <para>Specifies whether the layer will have dimension values. This parameter is only active if a single slice is selected to create a layer.</para>
		/// <para>Checked—The layer will not have dimension values.</para>
		/// <para>Unchecked—The layer will have dimension values. This is the default.</para>
		/// <para><see cref="DimensionlessEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Dimensionless { get; set; } = "false";

		/// <summary>
		/// <para>Percentile value</para>
		/// <para>The percentile to calculate. The default is 90, indicating the 90th percentile.</para>
		/// <para>The values can range from 0 to 100. The 0th percentile is essentially equivalent to the minimum statistic, and the 100th percentile is equivalent to maximum. A value of 50 will produce essentially the same result as the median statistic.</para>
		/// <para>This option is only available if the Statistics type parameter is set to Percentile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PercentileValue { get; set; } = "90";

		/// <summary>
		/// <para>Percentile interpolation type</para>
		/// <para>Specifies the method of percentile interpolation that will be used when there is an even number of values from the input raster to be calculated.</para>
		/// <para>Nearest—The nearest available value to the desired percentile will be used. In this case, the output pixel type will be the same as that of the input value raster.</para>
		/// <para>Linear—The weighted average of the two surrounding values from the desired percentile will be used. In this case, the output pixel type will be floating point.</para>
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
			/// <para>All—The data values will be aggregated across all slices. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Interval Keyword—The variable data will be aggregated using a commonly known interval.</para>
			/// </summary>
			[GPValue("INTERVAL_KEYWORD")]
			[Description("Interval Keyword")]
			Interval_Keyword,

			/// <summary>
			/// <para>Interval Value—The variable data will be aggregated using a user-specified interval and unit.</para>
			/// </summary>
			[GPValue("INTERVAL_VALUE")]
			[Description("Interval Value")]
			Interval_Value,

			/// <summary>
			/// <para>Interval Ranges—The variable data will be aggregated between specified pairs of values or dates.</para>
			/// </summary>
			[GPValue("INTERVAL_RANGES")]
			[Description("Interval Ranges")]
			Interval_Ranges,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum IntervalUnitEnum 
		{
			/// <summary>
			/// <para>Hours—The data values will be aggregated into hourly time slices at the interval provided.</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—The data values will be aggregated into daily time slices at the interval provided.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Weeks—The data values will be aggregated into weekly time slices at the interval provided.</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para>Months—The data values will be aggregated into monthly time slices at the interval provided.</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para>Years—The data values will be aggregated into yearly time slices at the interval provided.</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Ignore NoData</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para>Checked—The analysis will include all valid pixels along a given dimension and ignore any NoData pixels. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—The analysis will result in NoData if there are any NoData values for the pixels along the given dimension.</para>
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
			/// <para>Checked—The layer will not have dimension values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIMENSIONS")]
			NO_DIMENSIONS,

			/// <summary>
			/// <para>Unchecked—The layer will have dimension values. This is the default.</para>
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
			/// <para>Nearest—The nearest available value to the desired percentile will be used. In this case, the output pixel type will be the same as that of the input value raster.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Linear—The weighted average of the two surrounding values from the desired percentile will be used. In this case, the output pixel type will be floating point.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

		}

#endregion
	}
}
