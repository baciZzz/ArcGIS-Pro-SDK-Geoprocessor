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
	/// <para>Predict Using Regression Model</para>
	/// <para>Predicts data values using the output from the Train Random Trees Regression Model tool.</para>
	/// </summary>
	public class PredictUsingRegressionModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>The single-band, multidimensional, or multiband raster datasets, or mosaic datasets containing explanatory variables.</para>
		/// </param>
		/// <param name="InRegressionDefinition">
		/// <para>Input Regression Definition File</para>
		/// <para>A JSON format file that contains attribute information, statistics, or other information from the regression model. The file has an .ecd extension. The file is the output of the Train Random Trees Regression Model tool.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output predicted raster</para>
		/// <para>A raster of the predicted values.</para>
		/// </param>
		public PredictUsingRegressionModel(object InRasters, object InRegressionDefinition, object OutRasterDataset)
		{
			this.InRasters = InRasters;
			this.InRegressionDefinition = InRegressionDefinition;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Predict Using Regression Model</para>
		/// </summary>
		public override string DisplayName => "Predict Using Regression Model";

		/// <summary>
		/// <para>Tool Name : PredictUsingRegressionModel</para>
		/// </summary>
		public override string ToolName => "PredictUsingRegressionModel";

		/// <summary>
		/// <para>Tool Excute Name : ia.PredictUsingRegressionModel</para>
		/// </summary>
		public override string ExcuteName => "ia.PredictUsingRegressionModel";

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
		public override string[] ValidEnvironments => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "gpuID", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasters, InRegressionDefinition, OutRasterDataset };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The single-band, multidimensional, or multiband raster datasets, or mosaic datasets containing explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Input Regression Definition File</para>
		/// <para>A JSON format file that contains attribute information, statistics, or other information from the regression model. The file has an .ecd extension. The file is the output of the Train Random Trees Regression Model tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InRegressionDefinition { get; set; }

		/// <summary>
		/// <para>Output predicted raster</para>
		/// <para>A raster of the predicted values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PredictUsingRegressionModel SetEnviroment(object cellSize = null , object compression = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
