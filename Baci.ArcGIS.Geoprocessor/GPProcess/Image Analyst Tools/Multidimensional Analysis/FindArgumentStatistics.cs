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
	/// <para>Find Argument Statistics</para>
	/// <para>Extracts the dimension value  or band index at which a given statistic is attained for each pixel in a multidimensional or multiband raster.</para>
	/// </summary>
	public class FindArgumentStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Multidimensional or Multiband Raster</para>
		/// <para>The input multidimensional or multiband raster to be analyzed.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output raster dataset.</para>
		/// </param>
		public FindArgumentStatistics(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Argument Statistics</para>
		/// </summary>
		public override string DisplayName() => "Find Argument Statistics";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Dimension, DimensionDef, IntervalKeyword, Variables, StatisticsType, Min, Max, MultipleOccurrence, IgnoreNodata };

		/// <summary>
		/// <para>Input Multidimensional or Multiband Raster</para>
		/// <para>The input multidimensional or multiband raster to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The dimension from which the statistic will be extracted. If the input raster is not a multidimensional raster, this parameter is not required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Dimension Definition</para>
		/// <para>Specifies how the statistic will be extracted from the dimension.</para>
		/// <para>All—The statistic will be extracted across all dimensions. This is the default.</para>
		/// <para>Interval Keyword—The statistic will be extracted from the time dimension according to the interval keyword.</para>
		/// <para><see cref="DimensionDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DimensionDef { get; set; } = "ALL";

		/// <summary>
		/// <para>Keyword Interval</para>
		/// <para>The unit of time for which the statistic will be extracted.</para>
		/// <para>For example, you have five years of daily sea surface temperature data and you want to know the year in which the maximum temperature was observed. Set Statisitcs Type to Argument of the maximum, set Dimension Definition to Interval Keyword, and set Keyword Interval to Yearly.</para>
		/// <para>Alternatively, if you want to know the month in which the maximum temperature was consistently observed, set Statistics Type to Argument of the maximum, setDimension Definition to Interval Keyword, and set Keyword Interval to Recurring Monthly. This will generate a raster in which each pixel contains the month in which the statistic was reached across the five-year record (08/18/2018, 08/25/2016, 08/07/2013, for example).</para>
		/// <para>This parameter is required when the Dimension parameter is set to StdTime and the Dimension Definition parameter is set to Interval Keyword.</para>
		/// <para><see cref="IntervalKeywordEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalKeyword { get; set; }

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>The variable or variables to be analyzed. If the input raster is not multidimensional, the pixel values of the multiband raster are considered the variable. If the input raster is multidimensional and no variable is specified, all variables with the selected dimension will be analyzed.</para>
		/// <para>For example, to find the years in which temperature values were highest, specify temperature as the variable to be analyzed. If you do not specify any variables and you have both temperature and precipitation variables, both variables will be analyzed, and the output multidimensional raster will include both variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Statistics Type</para>
		/// <para>Specifies the statistic to extract from the variable or variables along the given dimension.</para>
		/// <para>Argument of the minimum—The dimension value at which the minimum variable value is reached will be extracted. This is the default.</para>
		/// <para>Argument of the maximum—The dimension value at which the maximum variable value is reached will be extracted.</para>
		/// <para>Argument of the median—The dimension value at which the median variable value is reached will be extracted.</para>
		/// <para>Duration—The longest dimension duration value between the minimum and maximum variable values will be extracted.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; } = "ARGUMENT_MIN";

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>The minimum variable value to be used to extract the duration.</para>
		/// <para>This parameter is required when the Statistics Type parameter is set to Duration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Min { get; set; }

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>The maximum variable value to be used to extract the duration.</para>
		/// <para>This parameter is required when the Statistics Type parameter is set to Duration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Max { get; set; }

		/// <summary>
		/// <para>Multiple Occurrence Value</para>
		/// <para>The pixel value to use to indicate that a given argument statistic was reached more than once in the input raster dataset. If not specified, the pixel value will be the value of the dimension the first time the argument statistic is reached.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MultipleOccurrence { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindArgumentStatistics SetEnviroment(object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
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
			/// <para>All—The statistic will be extracted across all dimensions. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Interval Keyword—The statistic will be extracted from the time dimension according to the interval keyword.</para>
			/// </summary>
			[GPValue("INTERVAL_KEYWORD")]
			[Description("Interval Keyword")]
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
			[Description("Hourly")]
			Hourly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DAILY")]
			[Description("Daily")]
			Daily,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WEEKLY")]
			[Description("Weekly")]
			Weekly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MONTHLY")]
			[Description("Monthly")]
			Monthly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("QUARTERLY")]
			[Description("Quarterly")]
			Quarterly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("YEARLY")]
			[Description("Yearly")]
			Yearly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_DAILY")]
			[Description("Recurring Daily")]
			Recurring_Daily,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_WEEKLY")]
			[Description("Recurring Weekly")]
			Recurring_Weekly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_MONTHLY")]
			[Description("Recurring Monthly")]
			Recurring_Monthly,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECURRING_QUARTERLY")]
			[Description("Recurring Quarterly")]
			Recurring_Quarterly,

		}

		/// <summary>
		/// <para>Statistics Type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Argument of the minimum—The dimension value at which the minimum variable value is reached will be extracted. This is the default.</para>
			/// </summary>
			[GPValue("ARGUMENT_MIN")]
			[Description("Argument of the minimum")]
			Argument_of_the_minimum,

			/// <summary>
			/// <para>Argument of the maximum—The dimension value at which the maximum variable value is reached will be extracted.</para>
			/// </summary>
			[GPValue("ARGUMENT_MAX")]
			[Description("Argument of the maximum")]
			Argument_of_the_maximum,

			/// <summary>
			/// <para>Argument of the median—The dimension value at which the median variable value is reached will be extracted.</para>
			/// </summary>
			[GPValue("ARGUMENT_MEDIAN")]
			[Description("Argument of the median")]
			Argument_of_the_median,

			/// <summary>
			/// <para>Duration—The longest dimension duration value between the minimum and maximum variable values will be extracted.</para>
			/// </summary>
			[GPValue("DURATION")]
			[Description("Duration")]
			Duration,

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

#endregion
	}
}
