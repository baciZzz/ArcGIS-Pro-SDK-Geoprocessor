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
	/// <para>Analyze Changes Using CCDC</para>
	/// <para>Evaluates changes in pixel values over time using the Continuous Change Detection and Classification (CCDC) method and generates a change analysis raster containing the model results.</para>
	/// </summary>
	public class AnalyzeChangesUsingCCDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </param>
		/// <param name="OutCcdcResult">
		/// <para>Output CCDC Analysis Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// <para>The output change analysis raster containing model information from the CCDC analysis.</para>
		/// </param>
		public AnalyzeChangesUsingCCDC(object InMultidimensionalRaster, object OutCcdcResult)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutCcdcResult = OutCcdcResult;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Changes Using CCDC</para>
		/// </summary>
		public override string DisplayName() => "Analyze Changes Using CCDC";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutCcdcResult, Bands!, TmaskBands!, ChiSquaredThreshold!, MinAnomalyObservations!, UpdateFrequency! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output CCDC Analysis Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// <para>The output change analysis raster containing model information from the CCDC analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutCcdcResult { get; set; }

		/// <summary>
		/// <para>Bands for Detecting Change</para>
		/// <para>The band IDs to use for change detection. If no band IDs are provided, all the bands from the input raster dataset will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Bands { get; set; }

		/// <summary>
		/// <para>Bands for Temporal Masking</para>
		/// <para>The band IDs to be used in the temporal mask (Tmask). It is recommended that you use the green band and the SWIR band. If no band IDs are provided, no masking will occur.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TmaskBands { get; set; }

		/// <summary>
		/// <para>Chi-squared Threshold for Detecting Changes</para>
		/// <para>The chi-square statistic change probability threshold. If an observation has a calculated change probability that is above this threshold, it is flagged as an anomaly, which is a potential change event. The default value is 0.99.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object? ChiSquaredThreshold { get; set; } = "0.99";

		/// <summary>
		/// <para>Minimum Consecutive Anomaly Observations</para>
		/// <para>The minimum number of consecutive anomaly observations that must occur before an event is considered a change. A pixel must be flagged as an anomaly for the specified number of consecutive time slices before it is considered a true change. The default value is 6.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object? MinAnomalyObservations { get; set; } = "6";

		/// <summary>
		/// <para>Updating Fitting Frequency (in years)</para>
		/// <para>The frequency, in years, at which to update the time series model with new observations. The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object? UpdateFrequency { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeChangesUsingCCDC SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
