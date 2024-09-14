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
	/// <para>Analyze Changes Using LandTrendr</para>
	/// <para>使用 LandTrendr 分析变化</para>
	/// <para>使用基于 Landsat 的干扰和恢复趋势检测 (LandTrendr) 方法评估像素值随时间的变化，并生成包含模型结果的变化分析栅格。</para>
	/// </summary>
	public class AnalyzeChangesUsingLandTrendr : AbstractGPProcess
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
		/// <para>包含来自 LandTrendr 分析的模型信息的输出变化分析栅格。</para>
		/// </param>
		public AnalyzeChangesUsingLandTrendr(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用 LandTrendr 分析变化</para>
		/// </summary>
		public override string DisplayName() => "使用 LandTrendr 分析变化";

		/// <summary>
		/// <para>Tool Name : AnalyzeChangesUsingLandTrendr</para>
		/// </summary>
		public override string ToolName() => "AnalyzeChangesUsingLandTrendr";

		/// <summary>
		/// <para>Tool Excute Name : ia.AnalyzeChangesUsingLandTrendr</para>
		/// </summary>
		public override string ExcuteName() => "ia.AnalyzeChangesUsingLandTrendr";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, ProcessingBand!, SnappingDate!, MaxNumSegments!, VertexCountOvershoot!, SpikeThreshold!, RecoveryThreshold!, PreventOneYearRecovery!, RecoveryTrend!, MinNumObservations!, BestModelProportion!, PvalueThreshold!, OutputOtherBands! };

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
		/// <para>包含来自 LandTrendr 分析的模型信息的输出变化分析栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Processing Band Name</para>
		/// <para>用于随时间分割像素值轨线的图像波段名称。 请选择最能捕获您要观测的要素变化的波段名称。</para>
		/// <para>如果未指定波段值并且输入为多波段影像，则将使用多波段图像中的第一个波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ProcessingBand { get; set; }

		/// <summary>
		/// <para>Snapping Date</para>
		/// <para>用于在输入多维数据集中针对每年识别一个剖切片的日期。 将使用日期最接近捕捉日期的剖切片。 如果输入数据集包含次年数据，则此参数为必填项。</para>
		/// <para>默认值为 06-30 或 June 30，大约是某一日历年的年中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SnappingDate { get; set; } = "06-30";

		/// <summary>
		/// <para>Maximum Number of Segments</para>
		/// <para>要拟合到每个像素的时间序列的最大段数。 默认值为 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object? MaxNumSegments { get; set; } = "5";

		/// <summary>
		/// <para>Vertex Count Overshoot Threshold</para>
		/// <para>在标识折点的初始阶段，超出 max_num_segments + 1 的附加折点数可用于拟合模型。 在建模过程的后期，附加折点数将减少为 max_num_segments + 1。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object? VertexCountOvershoot { get; set; } = "2";

		/// <summary>
		/// <para>Spike Threshold</para>
		/// <para>用于衰减像素值轨线中的峰值或异常的阈值。 该值的范围必须介于 0 到 1 之间，其中 1 表示没有衰减。 默认值为 0.9。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpikeThreshold { get; set; } = "0.9";

		/// <summary>
		/// <para>Recovery Threshold</para>
		/// <para>恢复阈值，以年为单位。 如果某段的恢复率快于 1/recovery threshold，则该段将被放弃，并且不会包含在时间序列模型中。 该值必须介于 0 到 1 之间。 默认值为 0.25。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? RecoveryThreshold { get; set; } = "0.25";

		/// <summary>
		/// <para>Prevent One Year Recovery</para>
		/// <para>指定是否将排除呈现一年恢复的段。</para>
		/// <para>选中 - 将排除呈现一年恢复的段。 这是默认设置。</para>
		/// <para>未选中 - 将不排除呈现一年恢复的段。</para>
		/// <para><see cref="PreventOneYearRecoveryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PreventOneYearRecovery { get; set; } = "true";

		/// <summary>
		/// <para>Recovery Has Increasing Trend</para>
		/// <para>指定恢复是否具有上升（正）趋势。</para>
		/// <para>选中 - 恢复呈现上升趋势。 这是默认设置。</para>
		/// <para>未选中 - 恢复呈现下降趋势。</para>
		/// <para><see cref="RecoveryTrendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RecoveryTrend { get; set; } = "true";

		/// <summary>
		/// <para>Minimum Number of Observations</para>
		/// <para>执行拟合所需的最小有效观测点数。 输入多维数据集中的年数必须等于或大于此值。 默认值为 6。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 2)]
		[Category("Advanced Fitting Options")]
		public object? MinNumObservations { get; set; } = "6";

		/// <summary>
		/// <para>Best Model Proportion</para>
		/// <para>最佳模型比例值。 在模型选择过程中，该工具将计算每个模型的 p 值，并根据此比例值来识别折点最多的模型，同时保持最小（最显著）p 值。 值为 1 表示模型的 p 值最低，但折点数量可能不多。 默认值为 1.25。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Fitting Options")]
		public object? BestModelProportion { get; set; } = "1.25";

		/// <summary>
		/// <para>P-Value Threshold</para>
		/// <para>要选择的模型的 p 值阈值。 在模型拟合的初始阶段中检测到折点后，该工具将拟合每个段并计算 p 值以确定模型的显著性。 在下次迭代中，模型会将段数减 1 并重新计算 p 值。 由此继续，如果 p 值小于此参数中指定的值，则将选择该模型，并且该工具将停止搜索更好的模型。 如果未选择此类模型，则该工具将选择 p 值小于 lowest p-value × best model proportion value 的模型。 默认值为 0.01。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Fitting Options")]
		public object? PvalueThreshold { get; set; } = "0.01";

		/// <summary>
		/// <para>Include Other Bands</para>
		/// <para>指定结果中是否将包含其他波段。</para>
		/// <para>选中 - 结果中将包含其他波段。 还会将处理波段参数中指定的初始分割波段的分割和折点信息拟合到多波段图像中的其余波段。 模型结果将首先包含分割波段，然后包含其余波段。</para>
		/// <para>未选中 - 结果中将不包含其他波段。 这是默认设置。</para>
		/// <para><see cref="OutputOtherBandsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutputOtherBands { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeChangesUsingLandTrendr SetEnviroment(object? cellSize = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Prevent One Year Recovery</para>
		/// </summary>
		public enum PreventOneYearRecoveryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PREVENT_ONE_YEAR_RECOVERY")]
			PREVENT_ONE_YEAR_RECOVERY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALLOW_ONE_YEAR_RECOVERY")]
			ALLOW_ONE_YEAR_RECOVERY,

		}

		/// <summary>
		/// <para>Recovery Has Increasing Trend</para>
		/// </summary>
		public enum RecoveryTrendEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCREASING_TREND")]
			INCREASING_TREND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DECREASING_TREND")]
			DECREASING_TREND,

		}

		/// <summary>
		/// <para>Include Other Bands</para>
		/// </summary>
		public enum OutputOtherBandsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_OTHER_BANDS")]
			INCLUDE_OTHER_BANDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_OTHER_BANDS")]
			EXCLUDE_OTHER_BANDS,

		}

#endregion
	}
}
