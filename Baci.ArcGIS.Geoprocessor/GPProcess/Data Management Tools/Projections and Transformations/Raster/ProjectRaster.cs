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
	/// <para>Project Raster</para>
	/// <para>投影栅格</para>
	/// <para>用于将栅格数据集从一种坐标系变换到另一种坐标系。</para>
	/// </summary>
	public class ProjectRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>将变换为新投影的栅格数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>将要创建的带有新投影的栅格数据集。</para>
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
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </param>
		/// <param name="OutCoorSystem">
		/// <para>Output Coordinate System</para>
		/// <para>新栅格数据集的坐标系。</para>
		/// </param>
		public ProjectRaster(object InRaster, object OutRaster, object OutCoorSystem)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.OutCoorSystem = OutCoorSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 投影栅格</para>
		/// </summary>
		public override string DisplayName() => "投影栅格";

		/// <summary>
		/// <para>Tool Name : ProjectRaster</para>
		/// </summary>
		public override string ToolName() => "ProjectRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.ProjectRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.ProjectRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, OutCoorSystem, ResamplingType!, CellSize!, GeographicTransform!, RegistrationPoint!, InCoorSystem!, Vertical! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>将变换为新投影的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>将要创建的带有新投影的栅格数据集。</para>
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
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>新栅格数据集的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoorSystem { get; set; }

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
		/// <para>Output Cell Size</para>
		/// <para>使用现有栅格数据集的新栅格的像元大小或指定其宽度 (x) 和高度 (y)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCellSizeXY()]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>从一个地理系统或基准面投影到另一个地理系统或基准面时的地理变换。输入坐标系和输出坐标系的基准面不同时需要进行变换。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? GeographicTransform { get; set; }

		/// <summary>
		/// <para>Registration Point</para>
		/// <para>用于对输出像元进行定位的左下角的点。该点的坐标不必位于一角，也不必落入栅格数据集中。</para>
		/// <para>捕捉栅格环境设置参数将优先于配准点参数。要设置配准点，请确保尚未设置捕捉栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? RegistrationPoint { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>输入栅格数据集的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InCoorSystem { get; set; }

		/// <summary>
		/// <para>Vertical</para>
		/// <para>指定是否将应用垂直变换。</para>
		/// <para>此选项在输入坐标系和输出坐标系都具有垂直坐标系且输入栅格的坐标具有 Z 值时处于活动状态。</para>
		/// <para>当选中垂直时，地理变换参数可以包括椭圆体变换和垂直基准面之间的变换。例如，~NAD_1983_To_NAVD88_CONUS_GEOID12B_Height + NAD_1983_To_WGS_1984_1 可将在 NAD 1983 基准面（具有 NAVD 1988 高度）上定义的几何折点变换为 WGS 1984 椭圆体（具有表示椭圆体高度的 Z 值）上的折点。波形符 (~) 表示变换的反转方向。</para>
		/// <para>未选中 - 不应用垂直变换。几何坐标的 Z 值将被忽略，并且 z 值将不会进行修改。这是默认设置。</para>
		/// <para>选中 - 将应用地理变换参数中指定的变换。投影栅格工具将变换几何坐标的 X、Y 和 Z 值。</para>
		/// <para>许多垂直变换需要附加数据文件，而这些文件必须通过 ArcGIS Coordinate Systems Data 安装包进行安装。</para>
		/// <para><see cref="VerticalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Vertical { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ProjectRaster SetEnviroment(object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

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

		/// <summary>
		/// <para>Vertical</para>
		/// </summary>
		public enum VerticalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VERTICAL")]
			VERTICAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VERTICAL")]
			NO_VERTICAL,

		}

#endregion
	}
}
