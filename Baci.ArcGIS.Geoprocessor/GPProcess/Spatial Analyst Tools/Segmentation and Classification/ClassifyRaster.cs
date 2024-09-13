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
	/// <para>Classify Raster</para>
	/// <para>Classify Raster</para>
	/// <para>Classifies a raster dataset based on an Esri classifier definition file (.ecd) and raster dataset inputs.</para>
	/// </summary>
	public class ClassifyRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// </param>
		/// <param name="InClassifierDefinition">
		/// <para>Input Classifier Definition File</para>
		/// <para>The input Esri classifier definition file (.ecd) containing the statistics for the chosen attributes for the classifier.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Classified Raster</para>
		/// <para>The path and name of the classified image you are creating.</para>
		/// <para>The output classified raster is defined by the input raster dataset and .ecd file inputs.</para>
		/// </param>
		public ClassifyRaster(object InRaster, object InClassifierDefinition, object OutRasterDataset)
		{
			this.InRaster = InRaster;
			this.InClassifierDefinition = InClassifierDefinition;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Raster</para>
		/// </summary>
		public override string DisplayName() => "Classify Raster";

		/// <summary>
		/// <para>Tool Name : ClassifyRaster</para>
		/// </summary>
		public override string ToolName() => "ClassifyRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.ClassifyRaster</para>
		/// </summary>
		public override string ExcuteName() => "sa.ClassifyRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InClassifierDefinition, OutRasterDataset, InAdditionalRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Classifier Definition File</para>
		/// <para>The input Esri classifier definition file (.ecd) containing the statistics for the chosen attributes for the classifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// <para>The path and name of the classified image you are creating.</para>
		/// <para>The output classified raster is defined by the input raster dataset and .ecd file inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>Ancillary raster datasets, such as a multispectral image or a DEM, will be incorporated to generate attributes and other required information for the classifier. This raster is necessary when calculating attributes such as mean or standard deviation. This parameter is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyRaster SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
