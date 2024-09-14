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
	/// <para>Rotate</para>
	/// <para>旋转</para>
	/// <para>围绕指定枢轴点转动栅格数据集。</para>
	/// </summary>
	public class Rotate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要旋转的栅格数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可以指定压缩类型和压缩质量。</para>
		/// <para>以文件格式存储栅格数据集时，需要指定文件扩展名，具体如下：</para>
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
		/// </param>
		/// <param name="Angle">
		/// <para>Angle</para>
		/// <para>指定一个介于 0 度到 360 度之间的值，将以此值对栅格进行顺时针旋转。若要逆时针旋转栅格，则需要将角度指定为负值。角度可以指定为整型值或浮点型值。</para>
		/// </param>
		public Rotate(object InRaster, object OutRaster, object Angle)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.Angle = Angle;
		}

		/// <summary>
		/// <para>Tool Display Name : 旋转</para>
		/// </summary>
		public override string DisplayName() => "旋转";

		/// <summary>
		/// <para>Tool Name : 旋转</para>
		/// </summary>
		public override string ToolName() => "旋转";

		/// <summary>
		/// <para>Tool Excute Name : management.Rotate</para>
		/// </summary>
		public override string ExcuteName() => "management.Rotate";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Angle, PivotPoint, ResamplingType, ClippingExtent };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要旋转的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可以指定压缩类型和压缩质量。</para>
		/// <para>以文件格式存储栅格数据集时，需要指定文件扩展名，具体如下：</para>
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
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Angle</para>
		/// <para>指定一个介于 0 度到 360 度之间的值，将以此值对栅格进行顺时针旋转。若要逆时针旋转栅格，则需要将角度指定为负值。角度可以指定为整型值或浮点型值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object Angle { get; set; }

		/// <summary>
		/// <para>Pivot Point</para>
		/// <para>栅格将围绕其进行旋转的点。如果留空，输入栅格数据集的左下角将用作枢轴。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object PivotPoint { get; set; }

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>要使用的重采样算法。 默认设置为最邻近。</para>
		/// <para>最邻近—最邻近法是最快的重采样方法；因为没有新值创建，此方法可将像素值的更改内容最小化。 适用于离散数据，例如土地覆被。</para>
		/// <para>双线性插值法—双线性插值可通过计算（距离权重）周围 4 像素的平均值来计算每个像素的值。 适用于连续数据。</para>
		/// <para>三次卷积插值法—三次卷积插值法通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此操作将生成平滑影像，但可创建位于源数据中超出范围外的值。 适用于连续数据。</para>
		/// <para>众数重采样法—众数重采样法基于 3 x 3 窗口中出现频率最高的值来确定每个像素的值。 适用于离散数据。</para>
		/// <para>最邻近和众数选项用于分类数据，如土地利用分类。 最邻近选项是默认设置，因为它是最快的插值法，同时也因为它不会更改像元值。 请勿对连续数据（如高程表面）使用其中任何一个选项。</para>
		/// <para>双线性选项和三次选项最适用于连续数据。 不建议对分类数据使用其中任何一个选项，因为像元值可能被更改。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Clipping Extent</para>
		/// <para>栅格数据集的处理范围。进行旋转前，源数据将裁剪为指定范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object ClippingExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Rotate SetEnviroment(object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
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
			/// <para>最邻近—最邻近法是最快的重采样方法；因为没有新值创建，此方法可将像素值的更改内容最小化。 适用于离散数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest_neighbor,

			/// <summary>
			/// <para>双线性插值法—双线性插值可通过计算（距离权重）周围 4 像素的平均值来计算每个像素的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性插值法")]
			Bilinear_interpolation,

			/// <summary>
			/// <para>三次卷积插值法—三次卷积插值法通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此操作将生成平滑影像，但可创建位于源数据中超出范围外的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次卷积插值法")]
			Cubic_convolution,

			/// <summary>
			/// <para>众数重采样法—众数重采样法基于 3 x 3 窗口中出现频率最高的值来确定每个像素的值。 适用于离散数据。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数重采样法")]
			Majority_resampling,

		}

#endregion
	}
}
