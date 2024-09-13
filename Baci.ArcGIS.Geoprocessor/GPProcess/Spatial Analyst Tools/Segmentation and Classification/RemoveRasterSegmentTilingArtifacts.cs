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
	/// <para>Remove Raster Segment Tiling Artifacts</para>
	/// <para>移除栅格影像分割块伪影</para>
	/// <para>校正作为栅格函数执行的分割过程中被切片边界切割的线段或对象。 该工具对于在影像切片边界附近会有不一致现象的某些区域过程（例如影像分割）有所帮助。</para>
	/// </summary>
	public class RemoveRasterSegmentTilingArtifacts : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSegmentedRaster">
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>选择要移除的带有块伪影的分割栅格。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Segmented Raster</para>
		/// <para>要从中移除块伪影的分割栅格的路径和名称。</para>
		/// </param>
		public RemoveRasterSegmentTilingArtifacts(object InSegmentedRaster, object OutRasterDataset)
		{
			this.InSegmentedRaster = InSegmentedRaster;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除栅格影像分割块伪影</para>
		/// </summary>
		public override string DisplayName() => "移除栅格影像分割块伪影";

		/// <summary>
		/// <para>Tool Name : RemoveRasterSegmentTilingArtifacts</para>
		/// </summary>
		public override string ToolName() => "RemoveRasterSegmentTilingArtifacts";

		/// <summary>
		/// <para>Tool Excute Name : sa.RemoveRasterSegmentTilingArtifacts</para>
		/// </summary>
		public override string ExcuteName() => "sa.RemoveRasterSegmentTilingArtifacts";

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
		public override object[] Parameters() => new object[] { InSegmentedRaster, OutRasterDataset, Tilesizex!, Tilesizey! };

		/// <summary>
		/// <para>Input Segmented RGB Or Gray Raster</para>
		/// <para>选择要移除的带有块伪影的分割栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSegmentedRaster { get; set; }

		/// <summary>
		/// <para>Output Segmented Raster</para>
		/// <para>要从中移除块伪影的分割栅格的路径和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Tile width used for segmentation</para>
		/// <para>指定 Mean Shift 影像分割的块宽度。如果留空，则默认宽度为 512 像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Tilesizex { get; set; } = "512";

		/// <summary>
		/// <para>Tile height used for segmentation</para>
		/// <para>指定 Mean Shift 影像分割的块高度。如果留空，则默认宽度为 512 像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Tilesizey { get; set; } = "512";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveRasterSegmentTilingArtifacts SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
