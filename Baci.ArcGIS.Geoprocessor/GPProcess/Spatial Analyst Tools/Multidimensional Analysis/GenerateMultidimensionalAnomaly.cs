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
	/// <para>Generate Multidimensional Anomaly</para>
	/// <para>Computes the anomaly for each slice in an existing multidimensional raster to generate a new multidimensional raster.</para>
	/// </summary>
	public class GenerateMultidimensionalAnomaly : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </param>
		public GenerateMultidimensionalAnomaly(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Multidimensional Anomaly</para>
		/// </summary>
		public override string DisplayName => "Generate Multidimensional Anomaly";

		/// <summary>
		/// <para>Tool Name : GenerateMultidimensionalAnomaly</para>
		/// </summary>
		public override string ToolName => "GenerateMultidimensionalAnomaly";

		/// <summary>
		/// <para>Tool Excute Name : sa.GenerateMultidimensionalAnomaly</para>
		/// </summary>
		public override string ExcuteName => "sa.GenerateMultidimensionalAnomaly";

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
		public override object[] Parameters => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Variables!, Method!, CalculationInterval!, IgnoreNodata!, ReferenceMeanRaster! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>The variable or variables for which anomalies will be calculated. If no variable is specified, all variables with a time dimension will be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Anomaly Calculation Method</para>
		/// <para>Specifies the method that will be used to calculate the anomaly.</para>
		/// <para>Difference From Mean—The difference between a pixel&apos;s value and the mean of that pixel&apos;s values across slices defined by the interval will be calculated. This is the default.</para>
		/// <para>Percent Difference From Mean—The percent difference between a pixel&apos;s value and the mean of that pixel&apos;s values across slices defined by the interval will be calculated.</para>
		/// <para>Percent Of Mean—The percent of the mean will be calculated.</para>
		/// <para>Z-score—The z-score for each pixel will be calculated. A z-score of 0 indicates the pixel&apos;s value is identical to the mean. A z-score of 1 indicates the pixel&apos;s value is 1 standard deviation from the mean. If a z-score is 2, the pixel&apos;s value is 2 standard deviations from the mean, and so on.</para>
		/// <para>Difference From Median—The difference between a pixel&apos;s value and the mathematical median of that pixel&apos;s values across slices defined by the interval will be calculated.</para>
		/// <para>Percent Difference From Median—The percent difference between a pixel&apos;s value and the mathematical median of that pixel&apos;s values across slices defined by the interval will be calculated.</para>
		/// <para>Percent Of Median—The percent of the mathematical median will be calculated.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "DIFFERENCE_FROM_MEAN";

		/// <summary>
		/// <para>Mean Calculation Interval</para>
		/// <para>Specifies the temporal interval that will be used to calculate the mean.</para>
		/// <para>All—The mean is calculated across all slices for each pixel.</para>
		/// <para>Yearly—The yearly mean is calculated for each pixel.</para>
		/// <para>Recurring monthly—The monthly mean is calculated for each pixel.</para>
		/// <para>Recurring weekly—The weekly mean is calculated for each pixel.</para>
		/// <para>Recurring daily—The daily mean is calculated for each pixel.</para>
		/// <para>Hourly—The hourly mean is calculated for each pixel.</para>
		/// <para>External raster—An existing raster dataset that contains the mean or median value for each pixel is referenced.</para>
		/// <para><see cref="CalculationIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalculationInterval { get; set; } = "ALL";

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
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Input External Raster</para>
		/// <para>The reference raster dataset that contains a previously calculated mean for each pixel. The anomalies will be calculated in comparison to this mean.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceMeanRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateMultidimensionalAnomaly SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Anomaly Calculation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Difference From Mean—The difference between a pixel&apos;s value and the mean of that pixel&apos;s values across slices defined by the interval will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("DIFFERENCE_FROM_MEAN")]
			[Description("Difference From Mean")]
			Difference_From_Mean,

			/// <summary>
			/// <para>Percent Difference From Mean—The percent difference between a pixel&apos;s value and the mean of that pixel&apos;s values across slices defined by the interval will be calculated.</para>
			/// </summary>
			[GPValue("PERCENT_DIFFERENCE_FROM_MEAN")]
			[Description("Percent Difference From Mean")]
			Percent_Difference_From_Mean,

			/// <summary>
			/// <para>Percent Of Mean—The percent of the mean will be calculated.</para>
			/// </summary>
			[GPValue("PERCENT_OF_MEAN")]
			[Description("Percent Of Mean")]
			Percent_Of_Mean,

			/// <summary>
			/// <para>Z-score—The z-score for each pixel will be calculated. A z-score of 0 indicates the pixel&apos;s value is identical to the mean. A z-score of 1 indicates the pixel&apos;s value is 1 standard deviation from the mean. If a z-score is 2, the pixel&apos;s value is 2 standard deviations from the mean, and so on.</para>
			/// </summary>
			[GPValue("Z_SCORE")]
			[Description("Z-score")]
			Z_SCORE,

			/// <summary>
			/// <para>Difference From Median—The difference between a pixel&apos;s value and the mathematical median of that pixel&apos;s values across slices defined by the interval will be calculated.</para>
			/// </summary>
			[GPValue("DIFFERENCE_FROM_MEDIAN")]
			[Description("Difference From Median")]
			Difference_From_Median,

			/// <summary>
			/// <para>Percent Difference From Median—The percent difference between a pixel&apos;s value and the mathematical median of that pixel&apos;s values across slices defined by the interval will be calculated.</para>
			/// </summary>
			[GPValue("PERCENT_DIFFERENCE_FROM_MEDIAN")]
			[Description("Percent Difference From Median")]
			Percent_Difference_From_Median,

			/// <summary>
			/// <para>Percent Of Median—The percent of the mathematical median will be calculated.</para>
			/// </summary>
			[GPValue("PERCENT_OF_MEDIAN")]
			[Description("Percent Of Median")]
			Percent_Of_Median,

		}

		/// <summary>
		/// <para>Mean Calculation Interval</para>
		/// </summary>
		public enum CalculationIntervalEnum 
		{
			/// <summary>
			/// <para>All—The mean is calculated across all slices for each pixel.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Yearly—The yearly mean is calculated for each pixel.</para>
			/// </summary>
			[GPValue("YEARLY")]
			[Description("Yearly")]
			Yearly,

			/// <summary>
			/// <para>Recurring monthly—The monthly mean is calculated for each pixel.</para>
			/// </summary>
			[GPValue("RECURRING_MONTHLY")]
			[Description("Recurring monthly")]
			Recurring_monthly,

			/// <summary>
			/// <para>Recurring weekly—The weekly mean is calculated for each pixel.</para>
			/// </summary>
			[GPValue("RECURRING_WEEKLY")]
			[Description("Recurring weekly")]
			Recurring_weekly,

			/// <summary>
			/// <para>Recurring daily—The daily mean is calculated for each pixel.</para>
			/// </summary>
			[GPValue("RECURRING_DAILY")]
			[Description("Recurring daily")]
			Recurring_daily,

			/// <summary>
			/// <para>Hourly—The hourly mean is calculated for each pixel.</para>
			/// </summary>
			[GPValue("HOURLY")]
			[Description("Hourly")]
			Hourly,

			/// <summary>
			/// <para>External raster—An existing raster dataset that contains the mean or median value for each pixel is referenced.</para>
			/// </summary>
			[GPValue("EXTERNAL_RASTER")]
			[Description("External raster")]
			External_raster,

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
