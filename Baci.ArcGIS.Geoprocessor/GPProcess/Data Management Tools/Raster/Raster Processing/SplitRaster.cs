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
	/// <para>Split Raster</para>
	/// <para>分割栅格</para>
	/// <para>按照块或面中的要素将栅格数据集分为多个更小的部分。</para>
	/// </summary>
	public class SplitRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要进行分割的栅格。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>新栅格数据集的目标。</para>
		/// </param>
		/// <param name="OutBaseName">
		/// <para>Output Base Name</para>
		/// <para>您将创建的每个栅格数据集的前缀。将对每个前缀追加一个数字（从 0 开始）。</para>
		/// </param>
		/// <param name="SplitMethod">
		/// <para>Split Method</para>
		/// <para>确定如何分割栅格数据集。</para>
		/// <para>块大小—指定分块的宽度和高度。</para>
		/// <para>块数量— 指定块的宽度和高度。</para>
		/// <para>面要素— 使用要素类中的各个面几何来分割栅格。</para>
		/// <para><see cref="SplitMethodEnum"/></para>
		/// </param>
		/// <param name="Format">
		/// <para>Output Format</para>
		/// <para>输出栅格数据集的格式。</para>
		/// <para>Geotiff (*.tif)—标记图像文件格式。这是默认设置。</para>
		/// <para>Bitmap (*.bmp)—Microsoft 位图。</para>
		/// <para>ENVI (*.dat)—ENVI DAT。</para>
		/// <para>Esri BIL (*.bil)—Esri 波段按行交叉。</para>
		/// <para>Esri BIP (*.bip)—Esri 波段按像素交叉。</para>
		/// <para>Esri BSQ (*.bsq)—Esri 波段顺序格式。</para>
		/// <para>GIF (*.gif)—图形交换格式。</para>
		/// <para>Esri GRID—Esri Grid。</para>
		/// <para>ERDAS IMAGINE (*.img)—ERDAS IMAGINE。</para>
		/// <para>JPEG 2000 (*.jp2)—JPEG 2000。</para>
		/// <para>JPEG (*.jpeg)—联合图像专家组。</para>
		/// <para>PNG (*.png)—可移植网络图形。</para>
		/// </param>
		public SplitRaster(object InRaster, object OutFolder, object OutBaseName, object SplitMethod, object Format)
		{
			this.InRaster = InRaster;
			this.OutFolder = OutFolder;
			this.OutBaseName = OutBaseName;
			this.SplitMethod = SplitMethod;
			this.Format = Format;
		}

		/// <summary>
		/// <para>Tool Display Name : 分割栅格</para>
		/// </summary>
		public override string DisplayName() => "分割栅格";

		/// <summary>
		/// <para>Tool Name : SplitRaster</para>
		/// </summary>
		public override string ToolName() => "SplitRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.SplitRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.SplitRaster";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "snapRaster", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFolder, OutBaseName, SplitMethod, Format, ResamplingType!, NumRasters!, TileSize!, Overlap!, Units!, CellSize!, Origin!, SplitPolygonFeatureClass!, ClipType!, TemplateExtent!, NodataValue!, DerivedOutFolder! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要进行分割的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>新栅格数据集的目标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>您将创建的每个栅格数据集的前缀。将对每个前缀追加一个数字（从 0 开始）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Split Method</para>
		/// <para>确定如何分割栅格数据集。</para>
		/// <para>块大小—指定分块的宽度和高度。</para>
		/// <para>块数量— 指定块的宽度和高度。</para>
		/// <para>面要素— 使用要素类中的各个面几何来分割栅格。</para>
		/// <para><see cref="SplitMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitMethod { get; set; } = "SIZE_OF_TILE";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>输出栅格数据集的格式。</para>
		/// <para>Geotiff (*.tif)—标记图像文件格式。这是默认设置。</para>
		/// <para>Bitmap (*.bmp)—Microsoft 位图。</para>
		/// <para>ENVI (*.dat)—ENVI DAT。</para>
		/// <para>Esri BIL (*.bil)—Esri 波段按行交叉。</para>
		/// <para>Esri BIP (*.bip)—Esri 波段按像素交叉。</para>
		/// <para>Esri BSQ (*.bsq)—Esri 波段顺序格式。</para>
		/// <para>GIF (*.gif)—图形交换格式。</para>
		/// <para>Esri GRID—Esri Grid。</para>
		/// <para>ERDAS IMAGINE (*.img)—ERDAS IMAGINE。</para>
		/// <para>JPEG 2000 (*.jp2)—JPEG 2000。</para>
		/// <para>JPEG (*.jpeg)—联合图像专家组。</para>
		/// <para>PNG (*.png)—可移植网络图形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>根据您拥有的数据类型选择相应的技术。</para>
		/// <para>最近—最快的重采样方法，可最大程度减少像素值的变化。适用于离散数据，例如土地覆被。</para>
		/// <para>双线性法—可采用平均化（距离权重）周围 4 个像素的值计算每个像素的值。适用于连续数据。</para>
		/// <para>三次—通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。生成平滑影像，但可创建位于源数据中超出范围外的值。适用于连续数据。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Number of Output Rasters</para>
		/// <para>要将栅格数据集分割成的列 (x) 数和行 (y) 数。X 坐标是列数，Y 坐标是行数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? NumRasters { get; set; } = "1 1";

		/// <summary>
		/// <para>Size of Output Rasters</para>
		/// <para>输出分块的 x 尺寸和 y 尺寸。默认的测量单位是像素。可通过输出栅格大小和重叠的单位参数来更改测量单位。X 坐标是输出块的 X（水平）维度，Y 坐标是输出块的 Y（垂直）维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? TileSize { get; set; } = "2048 2048";

		/// <summary>
		/// <para>Overlap</para>
		/// <para>这些分块不必完全对齐；使用此参数设置分块之间的重叠数量。默认的测量单位是像素。可通过输出栅格大小和重叠的单位参数来更改测量单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Other Options")]
		public object? Overlap { get; set; } = "0";

		/// <summary>
		/// <para>Units for Output Raster Size and Overlap</para>
		/// <para>设置输出栅格大小参数和重叠参数的测量单位。</para>
		/// <para>像素—单位为像素。这是默认设置。</para>
		/// <para>米—单位为米。</para>
		/// <para>英尺—单位为英尺。</para>
		/// <para>度—单位为十进制度。</para>
		/// <para>英里—单位为英里。</para>
		/// <para>千米—单位为千米。</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Other Options")]
		public object? Units { get; set; } = "PIXELS";

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>输出栅格的空间分辨率。如果留空，输出像元大小将与输入栅格相匹配。更改像元大小值时，分块大小将重置为图像大小，分块计数将重置为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Other Options")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Lower left origin</para>
		/// <para>更改左下角原点的坐标，即切片方案的开始位置。如果留空，左下角原点将与输入栅格相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Other Options")]
		public object? Origin { get; set; }

		/// <summary>
		/// <para>Split Polygon Feature Class</para>
		/// <para>将用于分割栅格数据集的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? SplitPolygonFeatureClass { get; set; }

		/// <summary>
		/// <para>Clip Type</para>
		/// <para>在分割栅格数据集之前，限制其范围。</para>
		/// <para>无— 使用输入栅格数据集的全图范围。</para>
		/// <para>范围—指定裁剪边界的边界框。</para>
		/// <para>要素类—指定用于裁剪范围的要素类。</para>
		/// <para><see cref="ClipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Clipping Options")]
		public object? ClipType { get; set; } = "NONE";

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>用于定义裁剪边界的范围或数据集。数据集可以是一个栅格或一个要素类。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Clipping Options")]
		public object? TemplateExtent { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>具有指定值的所有像素将在输出栅格数据集中被设置为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Other Options")]
		public object? NodataValue { get; set; }

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitRaster SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? snapRaster = null , object? tileSize = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, snapRaster: snapRaster, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Split Method</para>
		/// </summary>
		public enum SplitMethodEnum 
		{
			/// <summary>
			/// <para>块大小—指定分块的宽度和高度。</para>
			/// </summary>
			[GPValue("SIZE_OF_TILE")]
			[Description("块大小")]
			Size_of_tile,

			/// <summary>
			/// <para>块数量— 指定块的宽度和高度。</para>
			/// </summary>
			[GPValue("NUMBER_OF_TILES")]
			[Description("块数量")]
			Number_of_tiles,

			/// <summary>
			/// <para>面要素— 使用要素类中的各个面几何来分割栅格。</para>
			/// </summary>
			[GPValue("POLYGON_FEATURES")]
			[Description("面要素")]
			Polygon_features,

		}

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>最近—最快的重采样方法，可最大程度减少像素值的变化。适用于离散数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最近")]
			Nearest,

			/// <summary>
			/// <para>双线性法—可采用平均化（距离权重）周围 4 个像素的值计算每个像素的值。适用于连续数据。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性法")]
			Bilinear,

			/// <summary>
			/// <para>三次—通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。生成平滑影像，但可创建位于源数据中超出范围外的值。适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

		}

		/// <summary>
		/// <para>Units for Output Raster Size and Overlap</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>像素—单位为像素。这是默认设置。</para>
			/// </summary>
			[GPValue("PIXELS")]
			[Description("像素")]
			Pixels,

			/// <summary>
			/// <para>米—单位为米。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英尺—单位为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>度—单位为十进制度。</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("度")]
			Degrees,

			/// <summary>
			/// <para>千米—单位为千米。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英里—单位为英里。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

		}

		/// <summary>
		/// <para>Clip Type</para>
		/// </summary>
		public enum ClipTypeEnum 
		{
			/// <summary>
			/// <para>无— 使用输入栅格数据集的全图范围。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>范围—指定裁剪边界的边界框。</para>
			/// </summary>
			[GPValue("EXTENT")]
			[Description("范围")]
			Extent,

			/// <summary>
			/// <para>要素类—指定用于裁剪范围的要素类。</para>
			/// </summary>
			[GPValue("FEATURE_CLASS")]
			[Description("要素类")]
			Feature_class,

		}

#endregion
	}
}
