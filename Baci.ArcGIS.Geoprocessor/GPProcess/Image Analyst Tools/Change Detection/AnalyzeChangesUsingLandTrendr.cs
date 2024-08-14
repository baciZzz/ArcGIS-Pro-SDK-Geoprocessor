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
	/// <para>Evaluates changes in pixel values over time using the Landsat-based detection of trends in disturbance and recovery (LandTrendr) method and generates a change analysis raster containing the model results.</para>
	/// </summary>
	public class AnalyzeChangesUsingLandTrendr : AbstractGPProcess
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
		/// <para>The output change analysis raster containing model information from the LandTrendr analysis.</para>
		/// </param>
		public AnalyzeChangesUsingLandTrendr(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Changes Using LandTrendr</para>
		/// </summary>
		public override string DisplayName => "Analyze Changes Using LandTrendr";

		/// <summary>
		/// <para>Tool Name : AnalyzeChangesUsingLandTrendr</para>
		/// </summary>
		public override string ToolName => "AnalyzeChangesUsingLandTrendr";

		/// <summary>
		/// <para>Tool Excute Name : ia.AnalyzeChangesUsingLandTrendr</para>
		/// </summary>
		public override string ExcuteName => "ia.AnalyzeChangesUsingLandTrendr";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, ProcessingBand, SnappingDate, MaxNumSegments, VertexCountOvershoot, SpikeThreshold, RecoveryThreshold, PreventOneYearRecovery, RecoveryTrend, MinNumObservations, BestModelProportion, PvalueThreshold, OutputOtherBands };

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
		/// <para>The output change analysis raster containing model information from the LandTrendr analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Processing Band Name</para>
		/// <para>The image band name to use for segmenting the pixel value trajectories over time. Choose the band name that will best capture the changes in the feature you want to observe.</para>
		/// <para>If no band value is specified and the input is multiband imagery, the first band in the multiband image will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ProcessingBand { get; set; }

		/// <summary>
		/// <para>Snapping Date</para>
		/// <para>The date used to identify a slice for each year in the input multidimensional dataset. The slice with the date closest to the snapping date will be used. This parameter is required if the input dataset contains sub-yearly data.</para>
		/// <para>The default is 06-30, or June 30, which is approximately midway through a calendar year.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SnappingDate { get; set; } = "06-30";

		/// <summary>
		/// <para>Maximum Number of Segments</para>
		/// <para>The maximum number of segments to be fitted to the time series for each pixel. The default is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MaxNumSegments { get; set; } = "5";

		/// <summary>
		/// <para>Vertex Count Overshoot Threshold</para>
		/// <para>The number of additional vertices beyond max_num_segments + 1 that can be used to fit the model during the initial stage of identifying vertices. Later in the modeling process, the number of additional vertices will be reduced to max_num_segments + 1. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object VertexCountOvershoot { get; set; } = "2";

		/// <summary>
		/// <para>Spike Threshold</para>
		/// <para>The threshold to use for dampening spikes or anomalies in the pixel value trajectory. The value must range between 0 and 1 in which 1 means no dampening. The default is 0.9.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpikeThreshold { get; set; } = "0.9";

		/// <summary>
		/// <para>Recovery Threshold</para>
		/// <para>The recovery threshold value in years. If a segment has a recovery rate that is faster than 1/recovery threshold, the segment is discarded and not included in the time series model. The value must range between 0 and 1. The default is 0.25.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RecoveryThreshold { get; set; } = "0.25";

		/// <summary>
		/// <para>Prevent One Year Recovery</para>
		/// <para>Specifies whether segments that exhibit a one year recovery will be excluded.</para>
		/// <para>Checked—Segments that exhibit a one year recovery will be excluded. This is the default.</para>
		/// <para>Unchecked—Segments that exhibit a one year recovery will be not be excluded.</para>
		/// <para><see cref="PreventOneYearRecoveryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreventOneYearRecovery { get; set; } = "true";

		/// <summary>
		/// <para>Recovery Has Increasing Trend</para>
		/// <para>Specifies whether the recovery has an increasing (positive) trend.</para>
		/// <para>Checked—The recovery has an increasing trend. This is the default.</para>
		/// <para>Unchecked—The recovery has a decreasing trend.</para>
		/// <para><see cref="RecoveryTrendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RecoveryTrend { get; set; } = "true";

		/// <summary>
		/// <para>Minimum Number of Observations</para>
		/// <para>The minimum number of valid observations required to perform fitting. The number of years in the input multidimensional dataset must be equal to or greater than this value. The default is 6.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Advanced Fitting Options")]
		public object MinNumObservations { get; set; } = "6";

		/// <summary>
		/// <para>Best Model Proportion</para>
		/// <para>The best model proportion value. During the model selection process, the tool will calculate the p-value for each model and identify a model that has the most vertices while maintaining the smallest (most significant) p-value based on this proportion value. A value of 1 means the model has the lowest p-value but may not have a high number of vertices. The default is 1.25.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Fitting Options")]
		public object BestModelProportion { get; set; } = "1.25";

		/// <summary>
		/// <para>P-Value Threshold</para>
		/// <para>The p-value threshold for a model to be selected. After the vertices are detected in the initial stage of the model fitting, the tool will fit each segment and calculate the p-value to determine the significance of the model. On the next iteration, the model will decrease the number of segments by one and recalculate the p-value. This will continue and, if the p-value is smaller than the value specified in this parameter, the model will be selected and the tool will stop searching for a better model. If no such model is selected, the tool will select a model with a p-value smaller than the lowest p-value × best model proportion value. The default is 0.01.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Fitting Options")]
		public object PvalueThreshold { get; set; } = "0.01";

		/// <summary>
		/// <para>Include Other Bands</para>
		/// <para>Specifies whether other bands will be included in the results.</para>
		/// <para>Checked—Other bands will be included in the results. The segmentation and vertices information from the initial segmentation band specified in the Processing Band parameter will also be fitted to the remaining bands in the multiband images. The model results will include the segmentation band first, then the remaining bands.</para>
		/// <para>Unchecked—Other bands will not be included in the results. This is the default.</para>
		/// <para><see cref="OutputOtherBandsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OutputOtherBands { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeChangesUsingLandTrendr SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
			/// <para>Checked—Segments that exhibit a one year recovery will be excluded. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PREVENT_ONE_YEAR_RECOVERY")]
			PREVENT_ONE_YEAR_RECOVERY,

			/// <summary>
			/// <para>Unchecked—Segments that exhibit a one year recovery will be not be excluded.</para>
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
			/// <para>Checked—The recovery has an increasing trend. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCREASING_TREND")]
			INCREASING_TREND,

			/// <summary>
			/// <para>Unchecked—The recovery has a decreasing trend.</para>
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
			/// <para>Checked—Other bands will be included in the results. The segmentation and vertices information from the initial segmentation band specified in the Processing Band parameter will also be fitted to the remaining bands in the multiband images. The model results will include the segmentation band first, then the remaining bands.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_OTHER_BANDS")]
			INCLUDE_OTHER_BANDS,

			/// <summary>
			/// <para>Unchecked—Other bands will not be included in the results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_OTHER_BANDS")]
			EXCLUDE_OTHER_BANDS,

		}

#endregion
	}
}
