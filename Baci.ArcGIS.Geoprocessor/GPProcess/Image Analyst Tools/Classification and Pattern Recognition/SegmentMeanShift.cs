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
	/// <para>Mean Shift 影像分割</para>
	/// <para>将相邻并具有相似光谱特征的像素组合到一个分割块中。</para>
	/// </summary>
	public class SegmentMeanShift : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要分割的栅格数据集。它可以是多光谱影像或灰度影像。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>为输出数据集指定名称和扩展名。</para>
		/// <para>如果输入是一个多光谱影像，则输出将为 8 位的 RGB 影像。如果输入是一个灰度影像，则输出将为 8 位的灰度影像。</para>
		/// </param>
		public SegmentMeanShift(object InRaster, object OutRasterDataset)
		{
			this.InRaster = InRaster;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Mean Shift 影像分割</para>
		/// </summary>
		public override string DisplayName() => "Mean Shift 影像分割";

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
		public override object[] Parameters() => new object[] { InRaster, OutRasterDataset, SpectralDetail, SpatialDetail, MinSegmentSize, BandIndexes, MaxSegmentSize };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要分割的栅格数据集。它可以是多光谱影像或灰度影像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>为输出数据集指定名称和扩展名。</para>
		/// <para>如果输入是一个多光谱影像，则输出将为 8 位的 RGB 影像。如果输入是一个灰度影像，则输出将为 8 位的灰度影像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Spectral Detail</para>
		/// <para>为影像中要素的光谱差异指定的重要性级别。</para>
		/// <para>值的有效范围从 1.0 到 20.0。 如果具有希望单独分类的要素并且其光谱特性相似，则适合使用较高的值。 值越小，创建的光谱性输出越为平滑。 例如，在森林场景中使用的光谱详细级别越高，树种之间的差异就越大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpectralDetail { get; set; } = "15.5";

		/// <summary>
		/// <para>Spatial Detail</para>
		/// <para>为影像中要素之间的邻近性指定的重要性级别。</para>
		/// <para>值的有效范围从 1.0 到 20。 如果感兴趣要素小且聚集在一起，则适合使用较高的值。 值越小，创建的空间性输出越为平滑。 例如，在城市场景中，可以使用较小的空间细节对不可渗透表面进行分类，也可以使用较高的空间细节将建筑物和道路归为不同的类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object SpatialDetail { get; set; } = "15";

		/// <summary>
		/// <para>Minimum Segment Size In Pixels</para>
		/// <para>最小分割大小。将小于此大小的分割与其最适合的邻近分割合并。这与工程的最小制图单位有关。</para>
		/// <para>单位为像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MinSegmentSize { get; set; } = "20";

		/// <summary>
		/// <para>Band Indexes</para>
		/// <para>用于分割影像的波段，以空格分隔。如果未指定波段索引，则按照以下标准进行确定：</para>
		/// <para>如果栅格仅有 3 个波段，则使用这 3 个波段</para>
		/// <para>如果栅格具有 3 个以上波段，则工具将根据栅格的属性分配红色、绿色和蓝色波段。</para>
		/// <para>如果栅格数据集的属性中未标识红色、绿色和蓝色波段，则使用波段 1、2 和 3。</para>
		/// <para>波段顺序不会对结果产生影响。</para>
		/// <para>选择最能区分感兴趣要素的波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BandIndexes { get; set; }

		/// <summary>
		/// <para>Maximum Segment Size In Pixels</para>
		/// <para>最大分割大小。将分割大于指定大小的分割。使用此参数可防止较大分割在输出栅格中导致的伪影。</para>
		/// <para>单位为像素。</para>
		/// <para>默认值为 -1，表示不限制分割大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxSegmentSize { get; set; } = "-1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SegmentMeanShift SetEnviroment(object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
