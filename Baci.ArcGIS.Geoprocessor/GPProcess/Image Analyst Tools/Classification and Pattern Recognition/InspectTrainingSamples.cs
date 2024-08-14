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
	/// <para>Inspect Training Samples</para>
	/// <para>Estimates the accuracy of individual training samples. The cross validation accuracy is computed using the previously generated classification training result in an .ecd file and the training samples. Outputs include a raster dataset containing the misclassified class values and a training sample dataset with the accuracy score for each training sample.</para>
	/// </summary>
	public class InspectTrainingSamples : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster to be classified.</para>
		/// </param>
		/// <param name="InTrainingFeatures">
		/// <para>Input Training Sample File</para>
		/// <para>A training sample feature class created in the Training Samples Manager pane.</para>
		/// </param>
		/// <param name="InClassifierDefinition">
		/// <para>Input Classifier Definition File</para>
		/// <para>The .ecd output classifier file from any of the train classifier tools. The .ecd file is a JSON file that contains attribute information, statistics, or other information needed for the classifier.</para>
		/// </param>
		/// <param name="OutTrainingFeatureClass">
		/// <para>Output Training Sample Feature Class with Score</para>
		/// <para>The output individual training samples saved as a feature class. The associated attribute table contains an addition field listing the accuracy score.</para>
		/// </param>
		/// <param name="OutMisclassifiedRaster">
		/// <para>Output Misclassified Raster</para>
		/// <para>The output misclassified raster having NoData outside training samples. In training samples, correctly classified pixels are represented as NoData, and misclassified pixels are represented by their class value. The results is an index map of misclassified class values.</para>
		/// </param>
		public InspectTrainingSamples(object InRaster, object InTrainingFeatures, object InClassifierDefinition, object OutTrainingFeatureClass, object OutMisclassifiedRaster)
		{
			this.InRaster = InRaster;
			this.InTrainingFeatures = InTrainingFeatures;
			this.InClassifierDefinition = InClassifierDefinition;
			this.OutTrainingFeatureClass = OutTrainingFeatureClass;
			this.OutMisclassifiedRaster = OutMisclassifiedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Inspect Training Samples</para>
		/// </summary>
		public override string DisplayName => "Inspect Training Samples";

		/// <summary>
		/// <para>Tool Name : InspectTrainingSamples</para>
		/// </summary>
		public override string ToolName => "InspectTrainingSamples";

		/// <summary>
		/// <para>Tool Excute Name : ia.InspectTrainingSamples</para>
		/// </summary>
		public override string ExcuteName => "ia.InspectTrainingSamples";

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
		public override string[] ValidEnvironments => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, InTrainingFeatures, InClassifierDefinition, OutTrainingFeatureClass, OutMisclassifiedRaster, InAdditionalRaster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster to be classified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Training Sample File</para>
		/// <para>A training sample feature class created in the Training Samples Manager pane.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTrainingFeatures { get; set; }

		/// <summary>
		/// <para>Input Classifier Definition File</para>
		/// <para>The .ecd output classifier file from any of the train classifier tools. The .ecd file is a JSON file that contains attribute information, statistics, or other information needed for the classifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Output Training Sample Feature Class with Score</para>
		/// <para>The output individual training samples saved as a feature class. The associated attribute table contains an addition field listing the accuracy score.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Misclassified Raster</para>
		/// <para>The output misclassified raster having NoData outside training samples. In training samples, correctly classified pixels are represented as NoData, and misclassified pixels are represented by their class value. The results is an index map of misclassified class values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMisclassifiedRaster { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>Ancillary raster datasets, such as a multispectral image or a DEM, will be incorporated to generate attributes and other required information for the classifier. This raster is necessary when calculating attributes such as mean or standard deviation. This parameter is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InspectTrainingSamples SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
