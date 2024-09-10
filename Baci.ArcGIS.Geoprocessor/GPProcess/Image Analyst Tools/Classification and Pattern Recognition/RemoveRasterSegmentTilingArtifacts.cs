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
	/// <para>Remove Raster Segment Tiling Artifacts</para>
	/// <para>Corrects segments or objects cut by tile boundaries during the segmentation process performed as a raster function. This tool is helpful for some regional processes, such as image segmentation, that have inconsistencies near image tile boundaries.</para>
	/// </summary>
	public class RemoveRasterSegmentTilingArtifacts : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSegmentedRaster">
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>Select the segmented raster with the tiling artifacts that you want to remove.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Segmented Raster</para>
		/// <para>The path and name of the segmented raster from which you are removing tiling artifacts.</para>
		/// </param>
		public RemoveRasterSegmentTilingArtifacts(object InSegmentedRaster, object OutRasterDataset)
		{
			this.InSegmentedRaster = InSegmentedRaster;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Raster Segment Tiling Artifacts</para>
		/// </summary>
		public override string DisplayName() => "Remove Raster Segment Tiling Artifacts";

		/// <summary>
		/// <para>Tool Name : RemoveRasterSegmentTilingArtifacts</para>
		/// </summary>
		public override string ToolName() => "RemoveRasterSegmentTilingArtifacts";

		/// <summary>
		/// <para>Tool Excute Name : ia.RemoveRasterSegmentTilingArtifacts</para>
		/// </summary>
		public override string ExcuteName() => "ia.RemoveRasterSegmentTilingArtifacts";

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
		public override object[] Parameters() => new object[] { InSegmentedRaster, OutRasterDataset, Tilesizex, Tilesizey };

		/// <summary>
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>Select the segmented raster with the tiling artifacts that you want to remove.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSegmentedRaster { get; set; }

		/// <summary>
		/// <para>Output Segmented Raster</para>
		/// <para>The path and name of the segmented raster from which you are removing tiling artifacts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Tile width used for segmentation</para>
		/// <para>Specify the tile width from Segment Mean Shift. If left blank, the default is 512 pixels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Tilesizex { get; set; } = "512";

		/// <summary>
		/// <para>Tile height used for segmentation</para>
		/// <para>Specify the tile height from Segment Mean Shift. If left blank, the default is 512 pixels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Tilesizey { get; set; } = "512";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveRasterSegmentTilingArtifacts SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
