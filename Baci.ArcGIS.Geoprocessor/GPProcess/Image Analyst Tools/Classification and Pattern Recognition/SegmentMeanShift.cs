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
	/// <para>Segment Mean Shift</para>
	/// <para>Segment Mean Shift</para>
	/// <para>Groups into segments adjacent pixels that have similar spectral characteristics.</para>
	/// </summary>
	public class SegmentMeanShift : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to segment. This can be a multispectral or grayscale image.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>Specify a name and extension for the output dataset.</para>
		/// <para>If the input was a multispectral image, the output will be an 8-bit RGB image. If the input was a grayscale image, the output will be an 8-bit grayscale image.</para>
		/// </param>
		public SegmentMeanShift(object InRaster, object OutRasterDataset)
		{
			this.InRaster = InRaster;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Segment Mean Shift</para>
		/// </summary>
		public override string DisplayName() => "Segment Mean Shift";

		/// <summary>
		/// <para>Tool Name : SegmentMeanShift</para>
		/// </summary>
		public override string ToolName() => "SegmentMeanShift";

		/// <summary>
		/// <para>Tool Excute Name : ia.SegmentMeanShift</para>
		/// </summary>
		public override string ExcuteName() => "ia.SegmentMeanShift";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRasterDataset, SpectralDetail!, SpatialDetail!, MinSegmentSize!, BandIndexes!, MaxSegmentSize! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to segment. This can be a multispectral or grayscale image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>Specify a name and extension for the output dataset.</para>
		/// <para>If the input was a multispectral image, the output will be an 8-bit RGB image. If the input was a grayscale image, the output will be an 8-bit grayscale image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Spectral Detail</para>
		/// <para>The level of importance given to the spectral differences of features in the imagery.</para>
		/// <para>Valid values range from 1.0 to 20.0. A higher value is appropriate when there are features to classify separately that have similar spectral characteristics. Smaller values create spectrally smoother outputs. For example, with higher spectral detail in a forested scene, there will be greater discrimination between the tree species.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpectralDetail { get; set; } = "15.5";

		/// <summary>
		/// <para>Spatial Detail</para>
		/// <para>The level of importance given to the proximity between features in the imagery.</para>
		/// <para>Valid values range from 1.0 to 20. A higher value is appropriate for a scene in which the features of interest are small and clustered together. Smaller values create spatially smoother outputs. For example, in an urban scene, impervious surfaces can be classified using a smaller spatial detail, or buildings and roads can be classified as separate classes using a higher spatial detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SpatialDetail { get; set; } = "15";

		/// <summary>
		/// <para>Minimum Segment Size In Pixels</para>
		/// <para>The minimum size of a segment. Merge segments smaller than this size with their best fitting neighbor segment. This is related to the minimum mapping unit for your project.</para>
		/// <para>Units are in pixels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinSegmentSize { get; set; } = "20";

		/// <summary>
		/// <para>Band Indexes</para>
		/// <para>The bands that will be used to segment the imagery, separated by a space. If no band indexes are specified, they are determined by the following criteria:</para>
		/// <para>If the raster has only 3 bands, those 3 bands are used</para>
		/// <para>If the raster has more than 3 bands, the tool assigns the red, green, and blue bands according to the raster&apos;s properties.</para>
		/// <para>If the red, green, and blue bands are not identified in the raster dataset&apos;s properties, bands 1, 2, and 3 are used.</para>
		/// <para>The band order will not change the result.</para>
		/// <para>Select bands that offer the most differentiation between the features of interest.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BandIndexes { get; set; }

		/// <summary>
		/// <para>Maximum Segment Size In Pixels</para>
		/// <para>The maximum size of a segment. Segments that are larger than the specified size will be divided. Use this parameter to prevent artifacts in the output raster resulting from large segments.</para>
		/// <para>Units are in pixels.</para>
		/// <para>The default value is -1, meaning there is no limit on the segment size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxSegmentSize { get; set; } = "-1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SegmentMeanShift SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
