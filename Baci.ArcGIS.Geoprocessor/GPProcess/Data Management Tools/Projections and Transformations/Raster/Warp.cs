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
	/// <para>Warp</para>
	/// <para>扭曲</para>
	/// <para>使用源控制点和目标控制点转换栅格数据集。这与地理配准的方法类似。</para>
	/// </summary>
	public class Warp : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要转换的栅格。</para>
		/// </param>
		/// <param name="SourceControlPoints">
		/// <para>Source Control Points</para>
		/// <para>要扭曲的栅格的坐标。</para>
		/// </param>
		/// <param name="TargetControlPoints">
		/// <para>Target Control Points</para>
		/// <para>待扭曲的源栅格的坐标系。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可以指定压缩类型和压缩质量。</para>
		/// <para>以文件格式存储栅格数据集时，请指定文件扩展名，具体如下：</para>
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
		public Warp(object InRaster, object SourceControlPoints, object TargetControlPoints, object OutRaster)
		{
			this.InRaster = InRaster;
			this.SourceControlPoints = SourceControlPoints;
			this.TargetControlPoints = TargetControlPoints;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 扭曲</para>
		/// </summary>
		public override string DisplayName() => "扭曲";

		/// <summary>
		/// <para>Tool Name : 扭曲</para>
		/// </summary>
		public override string ToolName() => "扭曲";

		/// <summary>
		/// <para>Tool Excute Name : management.Warp</para>
		/// </summary>
		public override string ExcuteName() => "management.Warp";

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
		public override object[] Parameters() => new object[] { InRaster, SourceControlPoints, TargetControlPoints, OutRaster, TransformationType!, ResamplingType! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要转换的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Source Control Points</para>
		/// <para>要扭曲的栅格的坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object SourceControlPoints { get; set; }

		/// <summary>
		/// <para>Target Control Points</para>
		/// <para>待扭曲的源栅格的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TargetControlPoints { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可以指定压缩类型和压缩质量。</para>
		/// <para>以文件格式存储栅格数据集时，请指定文件扩展名，具体如下：</para>
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
		/// <para>Transformation Type</para>
		/// <para>指定用于平移栅格数据集的变换方法。</para>
		/// <para>仅平移—零阶多项式将用于平移数据。 当已对数据进行地理配准但通过微小的平移可以更好的排列数据时，通常使用该多项式。 执行零阶多项式平移只需要一个连接线。</para>
		/// <para>相似变换—将使用尝试保存原始栅格形状的一阶变换。 RMS 错误会高于其他多项式变换，因为保存形状比最佳大小更重要。</para>
		/// <para>仿射变换—将使用一阶多项式（仿射）以将输入点拟合为平面。</para>
		/// <para>二阶多项式变换—将使用二阶多项式以将输入点拟合为稍微复杂一些的曲面。</para>
		/// <para>三阶多项式变换—将使用三阶多项式以将输入点拟合为更为复杂的曲面。</para>
		/// <para>优化全局精度和局部精度—结合多项式变换和不规则三角网 (TIN) 插值法对全局和局部精度进行优化。</para>
		/// <para>样条函数变换—将源控制点准确地变换为目标控制点。 在输出中，控制点是准确的，只是控制点之间的栅格像素则不准确。</para>
		/// <para>射影变换—将扭曲线以使其保持平直。 进行变换时，之前平行的线可能不再保持平行。 投影变换尤其适用于倾斜的影像、扫描的地图和一些影像产品。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>指定将使用的重采样技术。 默认设置为最邻近。</para>
		/// <para>最邻近—将使用最近相邻要素技术。 因为没有新值创建，此方法可将像素值的更改内容最小化，这是最快的重采样技术。 适用于离散数据，例如土地覆被。</para>
		/// <para>双线性插值法—将使用双线性插值技术。 其采用平均化（距离权重）周围四个像素的值计算每个像素的值。 适用于连续数据。</para>
		/// <para>三次卷积插值法—将使用三次卷积插值技术。 其通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此操作将生成平滑影像，但可创建位于源数据中超出范围外的值。 适用于连续数据。</para>
		/// <para>众数重采样法—将使用众数重采样技术。 其基于 3 x 3 窗口中出现频率最高的值来确定每个像素的值。 适用于离散数据。</para>
		/// <para>最邻近和众数选项用于分类数据，如土地利用分类。 最邻近选项是默认选项。 其速度最快并且不会改变像素值。 请勿对连续数据（如高程表面）使用其中任何一个选项。</para>
		/// <para>双线性和三次选项最适用于连续数据。 建议不要对分类数据使用其中任何一个选项，因为像素值可能被更改。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Warp SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transformation Type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>仅平移—零阶多项式将用于平移数据。 当已对数据进行地理配准但通过微小的平移可以更好的排列数据时，通常使用该多项式。 执行零阶多项式平移只需要一个连接线。</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("仅平移")]
			Shift_only,

			/// <summary>
			/// <para>相似变换—将使用尝试保存原始栅格形状的一阶变换。 RMS 错误会高于其他多项式变换，因为保存形状比最佳大小更重要。</para>
			/// </summary>
			[GPValue("POLYSIMILARITY")]
			[Description("相似变换")]
			Similarity_transformation,

			/// <summary>
			/// <para>仿射变换—将使用一阶多项式（仿射）以将输入点拟合为平面。</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("仿射变换")]
			Affine_transformation,

			/// <summary>
			/// <para>二阶多项式变换—将使用二阶多项式以将输入点拟合为稍微复杂一些的曲面。</para>
			/// </summary>
			[GPValue("POLYORDER2")]
			[Description("二阶多项式变换")]
			POLYORDER2,

			/// <summary>
			/// <para>三阶多项式变换—将使用三阶多项式以将输入点拟合为更为复杂的曲面。</para>
			/// </summary>
			[GPValue("POLYORDER3")]
			[Description("三阶多项式变换")]
			POLYORDER3,

			/// <summary>
			/// <para>优化全局精度和局部精度—结合多项式变换和不规则三角网 (TIN) 插值法对全局和局部精度进行优化。</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("优化全局精度和局部精度")]
			Optimize_for_global_and_local_accuracy,

			/// <summary>
			/// <para>样条函数变换—将源控制点准确地变换为目标控制点。 在输出中，控制点是准确的，只是控制点之间的栅格像素则不准确。</para>
			/// </summary>
			[GPValue("SPLINE")]
			[Description("样条函数变换")]
			Spline_transformation,

			/// <summary>
			/// <para>射影变换—将扭曲线以使其保持平直。 进行变换时，之前平行的线可能不再保持平行。 投影变换尤其适用于倾斜的影像、扫描的地图和一些影像产品。</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("射影变换")]
			Projective_transformation,

		}

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>最邻近—将使用最近相邻要素技术。 因为没有新值创建，此方法可将像素值的更改内容最小化，这是最快的重采样技术。 适用于离散数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest_neighbor,

			/// <summary>
			/// <para>双线性插值法—将使用双线性插值技术。 其采用平均化（距离权重）周围四个像素的值计算每个像素的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性插值法")]
			Bilinear_interpolation,

			/// <summary>
			/// <para>三次卷积插值法—将使用三次卷积插值技术。 其通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。 此操作将生成平滑影像，但可创建位于源数据中超出范围外的值。 适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次卷积插值法")]
			Cubic_convolution,

			/// <summary>
			/// <para>众数重采样法—将使用众数重采样技术。 其基于 3 x 3 窗口中出现频率最高的值来确定每个像素的值。 适用于离散数据。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数重采样法")]
			Majority_resampling,

		}

#endregion
	}
}
