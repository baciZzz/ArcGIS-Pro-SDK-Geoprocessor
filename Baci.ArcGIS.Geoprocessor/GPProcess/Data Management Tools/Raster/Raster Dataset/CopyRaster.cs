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
	/// <para>Copy Raster</para>
	/// <para>复制栅格</para>
	/// <para>保存栅格数据集的副本或将镶嵌数据集转换成单个栅格数据集。</para>
	/// </summary>
	public class CopyRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要复制的栅格数据集或镶嵌数据集。</para>
		/// </param>
		/// <param name="OutRasterdataset">
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的栅格数据集的名称和格式。</para>
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
		/// <para>将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可以指定压缩类型和压缩质量。</para>
		/// </param>
		public CopyRaster(object InRaster, object OutRasterdataset)
		{
			this.InRaster = InRaster;
			this.OutRasterdataset = OutRasterdataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制栅格</para>
		/// </summary>
		public override string DisplayName() => "复制栅格";

		/// <summary>
		/// <para>Tool Name : CopyRaster</para>
		/// </summary>
		public override string ToolName() => "CopyRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.CopyRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.CopyRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRasterdataset, ConfigKeyword, BackgroundValue, NodataValue, OnebitToEightbit, ColormapToRGB, PixelType, ScalePixelValue, RGBToColormap, Format, Transform, ProcessAsMultidimensional, BuildMultidimensionalTranspose };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要复制的栅格数据集或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的栅格数据集的名称和格式。</para>
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
		/// <para>将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可以指定压缩类型和压缩质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRasterdataset { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>指定地理数据库的存储参数（配置）。 配置关键字由数据库管理员进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Ignore Background Value</para>
		/// <para>移除在栅格数据周围创建的不需要的值。指定的值与栅格数据集中的其他有用数据不同。例如，栅格边界上为零的值不同于栅格数据集内的零值。</para>
		/// <para>指定的像素值在输出栅格数据集中将被设置为 NoData。</para>
		/// <para>对于基于文件的栅格，要忽略背景值，必须将其设置为与 NoData 相同的值。企业级和地理数据库栅格无需经过此额外步骤即可忽略背景值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BackgroundValue { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>具有指定值的所有像素将在输出栅格数据集中被设置为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// <para>选择是否将输入 1 位栅格数据集转换为 8 位栅格数据集。 使用这种转换方法时，输入栅格数据集中的值 1 将在输出栅格数据集中更改为 255。 这在将 1 位栅格数据集导入地理数据库时十分有用。 1 位栅格数据集存储在文件系统中时包含 8 位金字塔图层，但在地理数据库中，1 位栅格数据集只能包含 1 位金字塔图层，这使得显示画面看起来没有吸引力。 通过在地理数据库中将数据转换为 8 位，可将金字塔图层构建为 8 位而非 1 位，从而在显示画面中生成适合的栅格数据集。</para>
		/// <para>未选中 - 不执行任何转换。 这是默认设置。</para>
		/// <para>选中 - 将转换输入栅格。</para>
		/// <para><see cref="OnebitToEightbitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OnebitToEightbit { get; set; } = "false";

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// <para>如果输入栅格数据集具有色彩映射表，则可将输出栅格数据集转换为三波段输出栅格数据集。 这在镶嵌包含不同色彩映射表的栅格时很有用。</para>
		/// <para>未选中 - 不发生任何转换。 这是默认设置。</para>
		/// <para>选中 - 将转换输入数据集。</para>
		/// <para><see cref="ColormapToRGBEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ColormapToRGB { get; set; } = "false";

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>指定要用于栅格数据集或镶嵌数据集的位深度或辐射分辨率。如果未定义，则将从第一个栅格数据集获取此值。</para>
		/// <para>1 位—1 位无符号整数。 值可以为 0 或 1。</para>
		/// <para>2 位—2 位无符号整数。 支持的值为 0 到 3。</para>
		/// <para>4 位—4 位无符号整数。 支持的值为 0 到 15。</para>
		/// <para>8 位无符号—8 位无符号数据类型。 支持的值为 0 到 255。</para>
		/// <para>8 位有符号—8 位有符号数据类型。 支持的值为 -128 到 127。</para>
		/// <para>16 位无符号—16 位无符号数据类型。 取值范围为 0 到 65,535。</para>
		/// <para>16 位有符号—16 位有符号数据类型。 取值范围为 -32,768 到 32,767。</para>
		/// <para>32 位无符号—32 位无符号数据类型。 取值范围为 0 到 4,294,967,295。</para>
		/// <para>32 位有符号—32 位有符号数据类型。 取值范围为 -2,147,483,648 到 2,147,483,647。</para>
		/// <para>32 位浮点—支持小数的 32 位数据类型。</para>
		/// <para>64 位—支持小数的 64 位数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PixelType { get; set; }

		/// <summary>
		/// <para>Scale Pixel Value</para>
		/// <para>指定是否将缩放像素值。当输出的像素类型不同于输入像素类型时（如从 16 位到 8 位），可将值缩放到符合新的范围；否则，会丢弃不符合新的像素范围的值。</para>
		/// <para>如果进行放大（如从 8 位到 16 位），8 位值的最小值和最大值会放大到 16 位范围中的最小值和最大值。如果进行缩小（如从 16 位到 8 位），16 位值的最小值和最大值会缩小到 8 位范围中的最小值和最大值。</para>
		/// <para>未选中 - 像素值保持不变且不会缩放。任何不符合值范围的值都会被丢弃。这是默认设置。</para>
		/// <para>选中 - 像素值会缩放到新的像素类型。在缩放像素深度时，栅格会显示相同的位深度，而值却缩放到指定的新的位深度。</para>
		/// <para><see cref="ScalePixelValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ScalePixelValue { get; set; } = "false";

		/// <summary>
		/// <para>RGB To Colormap</para>
		/// <para>指定是否将 8 位 3 波段 (RGB) 栅格数据集转换为带色彩映射表的单波段栅格数据集。此操作会抑制经常出现在扫描图像中的噪声，这非常适用于屏幕捕获、扫描的地图或扫描的文档。但并不建议将其用于卫星、航空影像或专题栅格数据。</para>
		/// <para>未选中 - 将不会转换 RGB 栅格数据集。</para>
		/// <para>选中 - 可将 RGB 栅格数据集转换为色彩映射表。</para>
		/// <para><see cref="RGBToColormapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RGBToColormap { get; set; } = "false";

		/// <summary>
		/// <para>Format</para>
		/// <para>指定输出栅格格式。</para>
		/// <para>TIFF 格式—输出格式将为 TIFF。</para>
		/// <para>Cloud Optimized GeoTIFF—输出格式将为 Cloud Optimized GeoTIFF。</para>
		/// <para>ERDAS IMAGINE 格式—输出格式将为 ERDAS IMAGINE。</para>
		/// <para>BMP 格式—输出格式将为 BMP。</para>
		/// <para>GIF 格式—输出格式将为 GIF。</para>
		/// <para>PNG 格式—输出格式将为 PNG。</para>
		/// <para>JPEG 格式—输出格式将为 JPEG。</para>
		/// <para>JPEG 2000 格式—输出格式将为 JPEG 2000。</para>
		/// <para>Esri Grid 格式—输出格式将为 Esri Grid。</para>
		/// <para>Esri BIL 格式—输出格式将为 Esri BIL。</para>
		/// <para>Esri BSQ 格式—输出格式将为 Esri BSQ。</para>
		/// <para>Esri BIP 格式—输出格式将为 Esri BIP。</para>
		/// <para>ENVI DAT 格式—输出格式将为 ENVI。</para>
		/// <para>云栅格格式—输出格式将为 CRF。</para>
		/// <para>元栅格格式—输出格式将为 MRF。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; }

		/// <summary>
		/// <para>Apply Transformation</para>
		/// <para>指定是否将与输入栅格关联的变换应用于输出。输入栅格可以具有与其相关联的变换，该变换未保存在输入中，例如作为坐标定位文件或者作为几何函数。</para>
		/// <para>未选中 - 不会将任何关联的变换应用于输出。</para>
		/// <para>选中 - 会将任何关联的变换应用于输出。</para>
		/// <para><see cref="TransformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Transform { get; set; } = "false";

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>指定是否将输入镶嵌数据集处理为多维栅格数据集。</para>
		/// <para>未选中 - 输入将不会被处理为多维栅格数据集。 如果输入是多维的，则将仅处理当前显示的切割片。 这是默认设置。</para>
		/// <para>已选中 - 输入将被处理为多维栅格数据集，并对所有切割片进行处理以生成新的多维栅格数据集。 要使用此选项，必须将输出格式设置为云栅格格式。</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Build Multidimensional Transpose</para>
		/// <para>指定是否为输入多维栅格数据集构建转置以优化数据访问。 转置将沿每个维度对多维数据进行分段，以优化访问所有切割片的像素值时的性能。</para>
		/// <para>未选中 - 将不会构建转置。 这是默认设置。</para>
		/// <para>已选中 - 将转置输入多维栅格数据集。 要使用此选项，必须选中以多维方式处理。</para>
		/// <para><see cref="BuildMultidimensionalTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildMultidimensionalTranspose { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyRaster SetEnviroment(object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// </summary>
		public enum OnebitToEightbitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OneBitTo8Bit")]
			OneBitTo8Bit,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// </summary>
		public enum ColormapToRGBEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ColormapToRGB")]
			ColormapToRGB,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Scale Pixel Value</para>
		/// </summary>
		public enum ScalePixelValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ScalePixelValue")]
			ScalePixelValue,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>RGB To Colormap</para>
		/// </summary>
		public enum RGBToColormapEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RGBToColormap")]
			RGBToColormap,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Apply Transformation</para>
		/// </summary>
		public enum TransformEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Transform")]
			Transform,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

		}

		/// <summary>
		/// <para>Build Multidimensional Transpose</para>
		/// </summary>
		public enum BuildMultidimensionalTransposeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRANSPOSE")]
			TRANSPOSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRANSPOSE")]
			NO_TRANSPOSE,

		}

#endregion
	}
}
