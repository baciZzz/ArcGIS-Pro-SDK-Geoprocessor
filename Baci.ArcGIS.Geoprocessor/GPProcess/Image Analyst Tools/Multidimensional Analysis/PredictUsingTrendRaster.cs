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
	/// <para>Predict Using Trend Raster</para>
	/// <para>使用趋势栅格预测</para>
	/// <para>使用来自生成趋势栅格工具的输出趋势栅格来计算预测多维栅格。</para>
	/// </summary>
	public class PredictUsingTrendRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Trend Raster</para>
		/// <para>来自生成趋势栅格工具的输入多维趋势栅格。</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </param>
		public PredictUsingTrendRaster(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用趋势栅格预测</para>
		/// </summary>
		public override string DisplayName() => "使用趋势栅格预测";

		/// <summary>
		/// <para>Tool Name : PredictUsingTrendRaster</para>
		/// </summary>
		public override string ToolName() => "PredictUsingTrendRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.PredictUsingTrendRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.PredictUsingTrendRaster";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Variables, DimensionDef, DimensionValues, Start, End, IntervalValue, IntervalUnit };

		/// <summary>
		/// <para>Input Trend Raster</para>
		/// <para>来自生成趋势栅格工具的输入多维趋势栅格。</para>
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
		/// <para>将在分析中预测的一个或多个变量。如果未指定任何变量，则将使用所有变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Dimension Definition</para>
		/// <para>指定用于提供预测维度值的方法。</para>
		/// <para>按值—将针对单个维度值或由值参数（在 Python 中为 dimension_values）定义的一系列维度值来计算预测。这是默认设置。例如，您要预测 2050、2100 和 2150 年的年降水量。</para>
		/// <para>按间隔—将针对由起始值和结束值定义的维度间隔来计算预测。例如，您要预测 2050 年到 2150 年之间每年的年降水量。</para>
		/// <para><see cref="DimensionDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DimensionDef { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Values</para>
		/// <para>预测中要使用的一个或多个维度值。</para>
		/// <para>时间、深度和高度值的格式必须与用于生成趋势栅格的维度值的格式相匹配。如果为 StdTime 维度生成了趋势栅格，则其格式应为 YYYY-MM-DDTHH:MM:SS，例如 2050-01-01T00:00:00。用分号分隔多个值。</para>
		/// <para>当维度定义参数设置为按值时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DimensionValues { get; set; }

		/// <summary>
		/// <para>Start</para>
		/// <para>预测中要使用的维度间隔的开始日期、高度或深度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Start { get; set; }

		/// <summary>
		/// <para>End</para>
		/// <para>预测中要使用的维度间隔的结束日期、高度或深度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object End { get; set; }

		/// <summary>
		/// <para>Value Interval</para>
		/// <para>要包含在预测中的两个维度值之间的步长数量。默认值为 1。</para>
		/// <para>例如，要预测每五年的温度值，请使用值 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object IntervalValue { get; set; }

		/// <summary>
		/// <para>Unit</para>
		/// <para>指定将用于间隔值的单位。仅当分析的维度是时间维度时，此参数才适用。</para>
		/// <para>小时—将在用开始、结束和值间隔参数描述的时间范围内计算每小时的预测。</para>
		/// <para>天—将在用开始、结束和值间隔参数描述的时间范围内计算每天的预测。</para>
		/// <para>周—将在用开始、结束和值间隔参数描述的时间范围内计算每周的预测。</para>
		/// <para>月—将在用开始、结束和值间隔参数描述的时间范围内计算每月的预测。</para>
		/// <para>年—将在用开始、结束和值间隔参数描述的时间范围内计算每年的预测。</para>
		/// <para><see cref="IntervalUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalUnit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PredictUsingTrendRaster SetEnviroment(object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
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
			/// <para>按值—将针对单个维度值或由值参数（在 Python 中为 dimension_values）定义的一系列维度值来计算预测。这是默认设置。例如，您要预测 2050、2100 和 2150 年的年降水量。</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("按值")]
			By_value,

			/// <summary>
			/// <para>按间隔—将针对由起始值和结束值定义的维度间隔来计算预测。例如，您要预测 2050 年到 2150 年之间每年的年降水量。</para>
			/// </summary>
			[GPValue("BY_INTERVAL")]
			[Description("按间隔")]
			By_interval,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum IntervalUnitEnum 
		{
			/// <summary>
			/// <para>小时—将在用开始、结束和值间隔参数描述的时间范围内计算每小时的预测。</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>天—将在用开始、结束和值间隔参数描述的时间范围内计算每天的预测。</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>周—将在用开始、结束和值间隔参数描述的时间范围内计算每周的预测。</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para>月—将在用开始、结束和值间隔参数描述的时间范围内计算每月的预测。</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para>年—将在用开始、结束和值间隔参数描述的时间范围内计算每年的预测。</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("年")]
			Years,

		}

#endregion
	}
}
