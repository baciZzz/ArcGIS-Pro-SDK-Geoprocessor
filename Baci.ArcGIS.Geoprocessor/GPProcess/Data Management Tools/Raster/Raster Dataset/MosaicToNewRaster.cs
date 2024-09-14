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
	/// <para>Mosaic To New Raster</para>
	/// <para>镶嵌至新栅格</para>
	/// <para>将多个栅格数据集合并到一个新的栅格数据集中。</para>
	/// </summary>
	public class MosaicToNewRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasters">
		/// <para>Input Rasters</para>
		/// <para>待合并的栅格数据集。输入必须具有相同的波段数和相同的位深度。</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>用于存储栅格的文件夹或地理数据库。</para>
		/// </param>
		/// <param name="RasterDatasetNameWithExtension">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>您正在创建的数据集名称。</para>
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
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </param>
		/// <param name="NumberOfBands">
		/// <para>Number of Bands</para>
		/// <para>输出栅格将具有的波段数。</para>
		/// </param>
		public MosaicToNewRaster(object InputRasters, object OutputLocation, object RasterDatasetNameWithExtension, object NumberOfBands)
		{
			this.InputRasters = InputRasters;
			this.OutputLocation = OutputLocation;
			this.RasterDatasetNameWithExtension = RasterDatasetNameWithExtension;
			this.NumberOfBands = NumberOfBands;
		}

		/// <summary>
		/// <para>Tool Display Name : 镶嵌至新栅格</para>
		/// </summary>
		public override string DisplayName() => "镶嵌至新栅格";

		/// <summary>
		/// <para>Tool Name : MosaicToNewRaster</para>
		/// </summary>
		public override string ToolName() => "MosaicToNewRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.MosaicToNewRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.MosaicToNewRaster";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "nodata", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasters, OutputLocation, RasterDatasetNameWithExtension, CoordinateSystemForTheRaster!, PixelType!, Cellsize!, NumberOfBands, MosaicMethod!, MosaicColormapMode!, OutputRasterDataset! };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>待合并的栅格数据集。输入必须具有相同的波段数和相同的位深度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasters { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>用于存储栅格的文件夹或地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>您正在创建的数据集名称。</para>
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
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RasterDatasetNameWithExtension { get; set; }

		/// <summary>
		/// <para>Spatial Reference for  Raster</para>
		/// <para>输出栅格数据集的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystemForTheRaster { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>镶嵌数据集的位深度或辐射分辨率。</para>
		/// <para>如果不设置像素类型，将使用默认值 8 位，而输出结果可能会不正确。</para>
		/// <para>1 位—像素类型为 1 位无符号整数。 值可以为 0 或 1。</para>
		/// <para>2 位—像素类型为 2 位无符号整数。 受支持的值范围为 0 到 3。</para>
		/// <para>4 位—像素类型为 4 位无符号整数。 受支持的值范围为 0 到 15。</para>
		/// <para>8 位无符号—像素类型为 8 位无符号数据类型。 受支持的值范围为 0 到 255。</para>
		/// <para>8 位有符号—像素类型为 8 位有符号数据类型。 受支持的值范围为 -128 到 127。</para>
		/// <para>16 位无符号—像素类型为 16 位无符号数据类型。 取值范围为 0 到 65,535。</para>
		/// <para>16 位有符号—像素类型为 16 位有符号数据类型。 取值范围为 -32,768 到 32,767。</para>
		/// <para>32 位无符号—像素类型为 32 位无符号数据类型。 取值范围为 0 到 4,294,967,295。</para>
		/// <para>32 位有符号—像素类型为 32 位有符号数据类型。 取值范围为 -2,147,483,648 到 2,147,483,647。</para>
		/// <para>32 位浮点—像素类型为支持小数的 32 位数据类型。</para>
		/// <para>64 位—像素类型为支持小数的 64 位数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PixelType { get; set; } = "8_BIT_UNSIGNED";

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>将用于新建栅格数据集的像素大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>输出栅格将具有的波段数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfBands { get; set; }

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>用于镶嵌重叠的方法。</para>
		/// <para>First—叠置区域的输出像元值为镶嵌到该位置的第一个栅格数据集中的值。</para>
		/// <para>Last—叠置区域的输出像元值为镶嵌到该位置的最后一个栅格数据集中的值。这是默认设置。</para>
		/// <para>Blend—叠置区域的输出像元值为叠置区域中各像元值的水平加权计算结果。</para>
		/// <para>Mean—重叠区域的输出像元值为叠置像元的平均值。</para>
		/// <para>最小值—重叠区域的输出像元值为叠置像元的最小值。</para>
		/// <para>Maximum—重叠区域的输出像元值为叠置像元的最大值。</para>
		/// <para>总和—重叠区域的输出像元值为叠置像元的总和。</para>
		/// <para>有关各镶嵌运算符的详细信息，请参阅“镶嵌运算符”帮助主题。</para>
		/// <para><see cref="MosaicMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MosaicMethod { get; set; } = "LAST";

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// <para>输入栅格数据集具有色彩映射表时应用。</para>
		/// <para>指定对输入栅格中应用于镶嵌输出的色彩映射表进行选择的方法。</para>
		/// <para>First—列表中第一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。 这是默认设置。</para>
		/// <para>Last—列表中最后一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。</para>
		/// <para>匹配—镶嵌时将考虑所有色彩映射表。 如果已经使用了所有可能的值（对于位深度），则该工具将与具有最接近的可用色彩的值进行匹配。</para>
		/// <para>拒绝—仅镶嵌不具有关联色彩映射表的栅格数据集。</para>
		/// <para>有关各色彩映射表模式的详细信息，请参阅“镶嵌色彩映射表模式”帮助主题。</para>
		/// <para><see cref="MosaicColormapModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MosaicColormapMode { get; set; } = "FIRST";

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutputRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MosaicToNewRaster SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? nodata = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? tileSize = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, nodata: nodata, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// </summary>
		public enum MosaicMethodEnum 
		{
			/// <summary>
			/// <para>First—叠置区域的输出像元值为镶嵌到该位置的第一个栅格数据集中的值。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—叠置区域的输出像元值为镶嵌到该位置的最后一个栅格数据集中的值。这是默认设置。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Blend—叠置区域的输出像元值为叠置区域中各像元值的水平加权计算结果。</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("Blend")]
			Blend,

			/// <summary>
			/// <para>Mean—重叠区域的输出像元值为叠置像元的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>最小值—重叠区域的输出像元值为叠置像元的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>Maximum—重叠区域的输出像元值为叠置像元的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>总和—重叠区域的输出像元值为叠置像元的总和。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

		}

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// </summary>
		public enum MosaicColormapModeEnum 
		{
			/// <summary>
			/// <para>拒绝—仅镶嵌不具有关联色彩映射表的栅格数据集。</para>
			/// </summary>
			[GPValue("REJECT")]
			[Description("拒绝")]
			Reject,

			/// <summary>
			/// <para>First—列表中第一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。 这是默认设置。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—列表中最后一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>匹配—镶嵌时将考虑所有色彩映射表。 如果已经使用了所有可能的值（对于位深度），则该工具将与具有最接近的可用色彩的值进行匹配。</para>
			/// </summary>
			[GPValue("MATCH")]
			[Description("匹配")]
			Match,

		}

#endregion
	}
}
