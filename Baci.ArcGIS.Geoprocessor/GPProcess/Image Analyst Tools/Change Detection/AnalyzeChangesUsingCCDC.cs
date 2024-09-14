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
	/// <para>Analyze Changes Using CCDC</para>
	/// <para>使用 CCDC 分析变化</para>
	/// <para>使用连续变化检测和分类 (CCDC) 方法评估像素值随时间的变化，并生成包含模型结果的变化分析。</para>
	/// </summary>
	public class AnalyzeChangesUsingCCDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </param>
		/// <param name="OutCcdcResult">
		/// <para>Output CCDC Analysis Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// <para>包含来自 CCDC 分析的模型信息的输出变化分析栅格。</para>
		/// </param>
		public AnalyzeChangesUsingCCDC(object InMultidimensionalRaster, object OutCcdcResult)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutCcdcResult = OutCcdcResult;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用 CCDC 分析变化</para>
		/// </summary>
		public override string DisplayName() => "使用 CCDC 分析变化";

		/// <summary>
		/// <para>Tool Name : AnalyzeChangesUsingCCDC</para>
		/// </summary>
		public override string ToolName() => "AnalyzeChangesUsingCCDC";

		/// <summary>
		/// <para>Tool Excute Name : ia.AnalyzeChangesUsingCCDC</para>
		/// </summary>
		public override string ExcuteName() => "ia.AnalyzeChangesUsingCCDC";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutCcdcResult, Bands, TmaskBands, ChiSquaredThreshold, MinAnomalyObservations, UpdateFrequency };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output CCDC Analysis Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// <para>包含来自 CCDC 分析的模型信息的输出变化分析栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutCcdcResult { get; set; }

		/// <summary>
		/// <para>Bands for Detecting Change</para>
		/// <para>用于变化检测的波段 ID。如果未提供波段 ID，则将使用输入栅格数据集中的所有波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Bands { get; set; }

		/// <summary>
		/// <para>Bands for Temporal Masking</para>
		/// <para>要在时间掩膜 (Tmask) 中使用的波段 ID。建议使用绿色波段和 SWIR 波段。如果未提供波段 ID，则不会进行任何掩膜。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TmaskBands { get; set; }

		/// <summary>
		/// <para>Chi-squared Threshold for Detecting Changes</para>
		/// <para>卡方统计变化概率阈值。如果观测值算得的变化概率高于此阈值，则将其标记为异常，即潜在的变化事件。默认值为 0.99。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object ChiSquaredThreshold { get; set; } = "0.99";

		/// <summary>
		/// <para>Minimum Consecutive Anomaly Observations</para>
		/// <para>在事件被视为变化之前必须进行的最小连续异常观测次数。像素必须针对指定数量的连续时间片标记为异常，然后才能将其视为真正的变化。默认值为 6。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object MinAnomalyObservations { get; set; } = "6";

		/// <summary>
		/// <para>Updating Fitting Frequency (in years)</para>
		/// <para>使用新观测值更新时间序列模型的频率（以年为单位）。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object UpdateFrequency { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeChangesUsingCCDC SetEnviroment(object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
