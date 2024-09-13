using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Resample</para>
	/// <para>重采样</para>
	/// <para>更改栅格数据集的空间分辨率并针对所有新像素大小的聚合值或插值设置规则。</para>
	/// </summary>
	public class Resample : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>具有要更改的空间分辨率的栅格数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>正在创建的数据集的名称、位置和格式。</para>
		/// <para>.bil - Esri BIL</para>
		/// <para>.bip - Esri BIP</para>
		/// <para>.bmp - BMP</para>
		/// <para>.bsq - Esri BSQ</para>
		/// <para>.dat - ENVI DAT</para>
		/// <para>.gif - GIF</para>
		/// <para>.img - ERDAS IMAGINE</para>
		/// <para>.jpg - JPEG</para>
		/// <para>.jp2 - JPEG 2000</para>
		/// <para>.png - PNG</para>
		/// <para>.tif - TIFF</para>
		/// <para>.mrf - MRF</para>
		/// <para>.crf - CRF</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储为 JPEG、JPEG 2000 或 TIFF 格式时，可以指定压缩类型和压缩质量。</para>
		/// </param>
		public Resample(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 重采样</para>
		/// </summary>
		public override string DisplayName() => "重采样";

		/// <summary>
		/// <para>Tool Name : 重采样</para>
		/// </summary>
		public override string ToolName() => "重采样";

		/// <summary>
		/// <para>Tool Excute Name : management.Resample</para>
		/// </summary>
		public override string ExcuteName() => "management.Resample";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, CellSize, ResamplingType };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>具有要更改的空间分辨率的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>正在创建的数据集的名称、位置和格式。</para>
		/// <para>.bil - Esri BIL</para>
		/// <para>.bip - Esri BIP</para>
		/// <para>.bmp - BMP</para>
		/// <para>.bsq - Esri BSQ</para>
		/// <para>.dat - ENVI DAT</para>
		/// <para>.gif - GIF</para>
		/// <para>.img - ERDAS IMAGINE</para>
		/// <para>.jpg - JPEG</para>
		/// <para>.jp2 - JPEG 2000</para>
		/// <para>.png - PNG</para>
		/// <para>.tif - TIFF</para>
		/// <para>.mrf - MRF</para>
		/// <para>.crf - CRF</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储为 JPEG、JPEG 2000 或 TIFF 格式时，可以指定压缩类型和压缩质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>使用现有栅格数据集的新栅格的像元大小或指定其宽度 (x) 和高度 (y)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCellSizeXY()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>指定要使用的重采样技术。</para>
		/// <para>最近—最邻近法是最快的重采样方法；因为没有新值创建，此方法可将像素值的更改内容最小化。 适用于离散数据，例如土地覆被。</para>
		/// <para>双线性法—双线性插值可通过计算（距离权重）周围 4 像素的平均值来计算每个像素的值。 适用于连续数据。</para>
		/// <para>三次—三次卷积插值法通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此操作将生成平滑影像，但可创建位于源数据中超出范围外的值。 适用于连续数据。</para>
		/// <para>众数—众数重采样法基于 3 x 3 窗口中出现频率最高的值来确定每个像素的值。 适用于离散数据。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Resample SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>最近—最邻近法是最快的重采样方法；因为没有新值创建，此方法可将像素值的更改内容最小化。 适用于离散数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最近")]
			Nearest,

			/// <summary>
			/// <para>双线性法—双线性插值可通过计算（距离权重）周围 4 像素的平均值来计算每个像素的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性法")]
			Bilinear,

			/// <summary>
			/// <para>三次—三次卷积插值法通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此操作将生成平滑影像，但可创建位于源数据中超出范围外的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

			/// <summary>
			/// <para>众数—众数重采样法基于 3 x 3 窗口中出现频率最高的值来确定每个像素的值。 适用于离散数据。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

		}

#endregion
	}
}
