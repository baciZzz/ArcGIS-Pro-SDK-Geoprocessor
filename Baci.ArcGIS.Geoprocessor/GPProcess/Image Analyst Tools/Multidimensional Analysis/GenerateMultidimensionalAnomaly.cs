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
	/// <para>Generate Multidimensional Anomaly</para>
	/// <para>生成多维异常</para>
	/// <para>用于计算现有多维栅格中每个剖切的异常，以生成新的多维栅格。</para>
	/// </summary>
	public class GenerateMultidimensionalAnomaly : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </param>
		public GenerateMultidimensionalAnomaly(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成多维异常</para>
		/// </summary>
		public override string DisplayName() => "生成多维异常";

		/// <summary>
		/// <para>Tool Name : GenerateMultidimensionalAnomaly</para>
		/// </summary>
		public override string ToolName() => "GenerateMultidimensionalAnomaly";

		/// <summary>
		/// <para>Tool Excute Name : ia.GenerateMultidimensionalAnomaly</para>
		/// </summary>
		public override string ExcuteName() => "ia.GenerateMultidimensionalAnomaly";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Variables, Method, CalculationInterval, IgnoreNodata, ReferenceMeanRaster };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>将计算异常的一个或多个变量。如果未指定变量，则将分析具有时间维度的所有变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Anomaly Calculation Method</para>
		/// <para>指定将用于计算异常的方法。</para>
		/// <para>与平均值的差值—将计算像素值与该像素值跨由间隔定义的剖切片的平均值之差。这是默认设置。</para>
		/// <para>与平均值的百分比差值—将计算像素值与该像素值跨剖切片（由间隔定义）的平均值的百分比差值。</para>
		/// <para>平均值百分比—将计算平均值的百分比。</para>
		/// <para>z 得分—将计算每个像素的 z 得分。z 得分为 0 表示像素值等于平均值。z 得分为 1 表示像素值与平均值相差 1 个标准差。如果 z 得分是 2，则像素值与平均值相差 2 个标准差，依此类推。</para>
		/// <para>与中值的差值—将计算像素值与该像素值跨由间隔定义的剖切片的数学中值之差。</para>
		/// <para>与中值的百分比差值—将计算像素值与该像素值跨由间隔定义的剖切片的数学中值的百分比差值。</para>
		/// <para>中值的百分比—将计算数学中值的百分比。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "DIFFERENCE_FROM_MEAN";

		/// <summary>
		/// <para>Mean Calculation Interval</para>
		/// <para>指定将用于计算平均值的时间间隔。</para>
		/// <para>所有—针对每个像素在所有剖切片上计算平均值。</para>
		/// <para>每年—针对每个像素计算每年平均值。</para>
		/// <para>每月循环—针对每个像素计算每月平均值。</para>
		/// <para>每周循环—针对每个像素计算每周平均值。</para>
		/// <para>每天循环—针对每个像素计算每日平均值。</para>
		/// <para>每小时—针对每个像素计算每小时平均值。</para>
		/// <para>外部栅格—将引用包含每个像素的平均值或中间值的现有栅格数据集。</para>
		/// <para><see cref="CalculationIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CalculationInterval { get; set; } = "ALL";

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
		/// <para>Input External Raster</para>
		/// <para>参考栅格数据集，其中包含之前针对每个像素计算的平均值。将以与该平均值进行比较的方式来计算异常。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object ReferenceMeanRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateMultidimensionalAnomaly SetEnviroment(object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
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
			/// <para>与平均值的差值—将计算像素值与该像素值跨由间隔定义的剖切片的平均值之差。这是默认设置。</para>
			/// </summary>
			[GPValue("DIFFERENCE_FROM_MEAN")]
			[Description("与平均值的差值")]
			Difference_From_Mean,

			/// <summary>
			/// <para>与平均值的百分比差值—将计算像素值与该像素值跨剖切片（由间隔定义）的平均值的百分比差值。</para>
			/// </summary>
			[GPValue("PERCENT_DIFFERENCE_FROM_MEAN")]
			[Description("与平均值的百分比差值")]
			Percent_Difference_From_Mean,

			/// <summary>
			/// <para>平均值百分比—将计算平均值的百分比。</para>
			/// </summary>
			[GPValue("PERCENT_OF_MEAN")]
			[Description("平均值百分比")]
			Percent_Of_Mean,

			/// <summary>
			/// <para>z 得分—将计算每个像素的 z 得分。z 得分为 0 表示像素值等于平均值。z 得分为 1 表示像素值与平均值相差 1 个标准差。如果 z 得分是 2，则像素值与平均值相差 2 个标准差，依此类推。</para>
			/// </summary>
			[GPValue("Z_SCORE")]
			[Description("z 得分")]
			Z_SCORE,

			/// <summary>
			/// <para>与中值的差值—将计算像素值与该像素值跨由间隔定义的剖切片的数学中值之差。</para>
			/// </summary>
			[GPValue("DIFFERENCE_FROM_MEDIAN")]
			[Description("与中值的差值")]
			Difference_From_Median,

			/// <summary>
			/// <para>与中值的百分比差值—将计算像素值与该像素值跨由间隔定义的剖切片的数学中值的百分比差值。</para>
			/// </summary>
			[GPValue("PERCENT_DIFFERENCE_FROM_MEDIAN")]
			[Description("与中值的百分比差值")]
			Percent_Difference_From_Median,

			/// <summary>
			/// <para>中值的百分比—将计算数学中值的百分比。</para>
			/// </summary>
			[GPValue("PERCENT_OF_MEDIAN")]
			[Description("中值的百分比")]
			Percent_Of_Median,

		}

		/// <summary>
		/// <para>Mean Calculation Interval</para>
		/// </summary>
		public enum CalculationIntervalEnum 
		{
			/// <summary>
			/// <para>所有—针对每个像素在所有剖切片上计算平均值。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>每年—针对每个像素计算每年平均值。</para>
			/// </summary>
			[GPValue("YEARLY")]
			[Description("每年")]
			Yearly,

			/// <summary>
			/// <para>每月循环—针对每个像素计算每月平均值。</para>
			/// </summary>
			[GPValue("RECURRING_MONTHLY")]
			[Description("每月循环")]
			Recurring_monthly,

			/// <summary>
			/// <para>每周循环—针对每个像素计算每周平均值。</para>
			/// </summary>
			[GPValue("RECURRING_WEEKLY")]
			[Description("每周循环")]
			Recurring_weekly,

			/// <summary>
			/// <para>每天循环—针对每个像素计算每日平均值。</para>
			/// </summary>
			[GPValue("RECURRING_DAILY")]
			[Description("每天循环")]
			Recurring_daily,

			/// <summary>
			/// <para>每小时—针对每个像素计算每小时平均值。</para>
			/// </summary>
			[GPValue("HOURLY")]
			[Description("每小时")]
			Hourly,

			/// <summary>
			/// <para>外部栅格—将引用包含每个像素的平均值或中间值的现有栅格数据集。</para>
			/// </summary>
			[GPValue("EXTERNAL_RASTER")]
			[Description("外部栅格")]
			External_raster,

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

#endregion
	}
}
