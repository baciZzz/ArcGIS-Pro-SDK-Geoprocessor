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
	/// <para>Create Raster Dataset</para>
	/// <para>创建栅格数据集</para>
	/// <para>创建空的栅格数据集。</para>
	/// </summary>
	public class CreateRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>用于存储栅格数据集的文件夹或地理数据库。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>要创建的数据集的名称、位置和格式。</para>
		/// <para>以文件格式存储栅格数据集时，需要指定文件扩展名，具体如下：</para>
		/// <para>Esri BIL 为 .bil</para>
		/// <para>Esri BIP 为 .bip</para>
		/// <para>BMP 的 .bmp</para>
		/// <para>Esri BSQ 为 .bsq</para>
		/// <para>ENVI DAT 为 .dat</para>
		/// <para>GIF 为 .gif</para>
		/// <para>ERDAS IMAGINE 为 .img</para>
		/// <para>JPEG 为 .jpg</para>
		/// <para>JPEG 2000 为 .jp2</para>
		/// <para>PNG 为 .png</para>
		/// <para>TIFF 为 .tif</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量。</para>
		/// </param>
		/// <param name="PixelType">
		/// <para>Pixel Type</para>
		/// <para>输出栅格数据集的位深度（辐射分辨率）。 如果未指定，则将使用 8 位无符号整数的默认像素类型创建栅格数据集。</para>
		/// <para>并非所有栅格格式都支持全部数据类型。 请参阅受支持的传感器列表帮助主题确定所用格式是否支持所需数据类型。</para>
		/// <para>1 位—1 位无符号整数。 值可以为 0 或 1。</para>
		/// <para>2 位—2 位无符号整数。 支持的值为 0 到 3。</para>
		/// <para>4 位—4 位无符号整数。 支持的值为 0 到 15。</para>
		/// <para>8 位无符号—8 位无符号数据类型。 支持的值为 0 到 255。</para>
		/// <para>8 位带符号—8 位有符号数据类型。 支持的值为 -128 到 127。</para>
		/// <para>16 位无符号—16 位无符号数据类型。 取值范围为 0 到 65,535。</para>
		/// <para>16 位带符号—16 位有符号数据类型。 取值范围为 -32,768 到 32,767。</para>
		/// <para>32 位无符号—32 位无符号数据类型。 取值范围为 0 到 4,294,967,295。</para>
		/// <para>32 位带符号—32 位有符号数据类型。 取值范围为 -2,147,483,648 到 2,147,483,647。</para>
		/// <para>32 位浮点—支持小数的 32 位数据类型。</para>
		/// <para>64 位—支持小数的 64 位数据类型。</para>
		/// </param>
		/// <param name="NumberOfBands">
		/// <para>Number of Bands</para>
		/// <para>输出栅格数据集的波段数。</para>
		/// </param>
		public CreateRasterDataset(object OutPath, object OutName, object PixelType, object NumberOfBands)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
			this.PixelType = PixelType;
			this.NumberOfBands = NumberOfBands;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建栅格数据集</para>
		/// </summary>
		public override string DisplayName() => "创建栅格数据集";

		/// <summary>
		/// <para>Tool Name : CreateRasterDataset</para>
		/// </summary>
		public override string ToolName() => "CreateRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRasterDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRasterDataset";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "pyramid", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, Cellsize, PixelType, RasterSpatialReference, NumberOfBands, ConfigKeyword, Pyramids, TileSize, Compression, PyramidOrigin, OutRasterDataset };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>用于存储栅格数据集的文件夹或地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>要创建的数据集的名称、位置和格式。</para>
		/// <para>以文件格式存储栅格数据集时，需要指定文件扩展名，具体如下：</para>
		/// <para>Esri BIL 为 .bil</para>
		/// <para>Esri BIP 为 .bip</para>
		/// <para>BMP 的 .bmp</para>
		/// <para>Esri BSQ 为 .bsq</para>
		/// <para>ENVI DAT 为 .dat</para>
		/// <para>GIF 为 .gif</para>
		/// <para>ERDAS IMAGINE 为 .img</para>
		/// <para>JPEG 为 .jpg</para>
		/// <para>JPEG 2000 为 .jp2</para>
		/// <para>PNG 为 .png</para>
		/// <para>TIFF 为 .tif</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储到 JPEG 文件、JPEG 2000 文件、TIFF 文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>新栅格数据集的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Cellsize { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>输出栅格数据集的位深度（辐射分辨率）。 如果未指定，则将使用 8 位无符号整数的默认像素类型创建栅格数据集。</para>
		/// <para>并非所有栅格格式都支持全部数据类型。 请参阅受支持的传感器列表帮助主题确定所用格式是否支持所需数据类型。</para>
		/// <para>1 位—1 位无符号整数。 值可以为 0 或 1。</para>
		/// <para>2 位—2 位无符号整数。 支持的值为 0 到 3。</para>
		/// <para>4 位—4 位无符号整数。 支持的值为 0 到 15。</para>
		/// <para>8 位无符号—8 位无符号数据类型。 支持的值为 0 到 255。</para>
		/// <para>8 位带符号—8 位有符号数据类型。 支持的值为 -128 到 127。</para>
		/// <para>16 位无符号—16 位无符号数据类型。 取值范围为 0 到 65,535。</para>
		/// <para>16 位带符号—16 位有符号数据类型。 取值范围为 -32,768 到 32,767。</para>
		/// <para>32 位无符号—32 位无符号数据类型。 取值范围为 0 到 4,294,967,295。</para>
		/// <para>32 位带符号—32 位有符号数据类型。 取值范围为 -2,147,483,648 到 2,147,483,647。</para>
		/// <para>32 位浮点—支持小数的 32 位数据类型。</para>
		/// <para>64 位—支持小数的 64 位数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PixelType { get; set; } = "8_BIT_UNSIGNED";

		/// <summary>
		/// <para>Spatial Reference for Raster</para>
		/// <para>输出栅格数据集的坐标系。</para>
		/// <para>若未指定坐标系，则将使用环境设置中设置的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object RasterSpatialReference { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>输出栅格数据集的波段数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfBands { get; set; } = "1";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>指定文件地理数据库或企业级地理数据库的存储参数（配置）。 配置关键字由数据库管理员进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Settings (optional)")]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Create pyramids</para>
		/// <para>创建金字塔。</para>
		/// <para>对于金字塔等级，可指定 -1 或更高等级的数字。 值为 0 时将不构建任何金字塔，值为 -1 时将自动确定要创建的金字塔图层的正确数量。</para>
		/// <para>“金字塔重采样技术”用于定义在构建金字塔时如何对数据进行重采样。</para>
		/// <para>NEAREST - 对于具有色彩映射表（如土地利用或伪彩色图像）的标称数据或栅格数据集，应使用最邻近法。</para>
		/// <para>BILINEAR - 双线性插值法最适用于诸如卫星影像或航空摄影这样的连续数据。</para>
		/// <para>CUBIC - 三次卷积插值法最适用于处理卫星影像或航空摄影等诸如此类的连续数据。 它与双线性插值法类似；不过，它会使用更大的矩阵对数据进行重采样。</para>
		/// <para>“金字塔压缩类型”用于定义压缩金字塔时使用的方法。</para>
		/// <para>DEFAULT - 将使用通常由栅格数据集格式使用的压缩类型。</para>
		/// <para>LZ77 - 无损压缩。 将不会更改栅格中的单元值。</para>
		/// <para>JPEG - 有损压缩。</para>
		/// <para>NONE - 无数据压缩。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvPyramid()]
		[Category("Geodatabase Settings (optional)")]
		public object Pyramids { get; set; } = "PYRAMIDS -1 NEAREST DEFAULT 75 NO_SKIP NO_SIPS";

		/// <summary>
		/// <para>Tile size</para>
		/// <para>指定分块的大小。</para>
		/// <para>切片宽度决定了您可以在各切片中存储的像素数目。 切片宽度以 x 像素数指定。 默认切片宽度为 128。</para>
		/// <para>切片高度决定了您可以在各切片中存储的像素数目。 切片高度以 y 像素数指定。 默认切片高度为 128。</para>
		/// <para>只有地理数据库和企业级地理数据库使用切片大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvTileSize()]
		[Category("Geodatabase Settings (optional)")]
		public object TileSize { get; set; } = "128 128";

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定用于存储栅格数据集的压缩类型。</para>
		/// <para>LZ77—保留所有栅格像元值的无损压缩。</para>
		/// <para>Jpeg—使用公共 JPEG 压缩算法的有损压缩。 如果选择 JPEG，还可以指定压缩质量。 压缩质量的有效值范围是 0 到 100。 这种压缩方式可用于 JPEG 文件和 TIFF 文件。</para>
		/// <para>Jpeg 2000—有损压缩。</para>
		/// <para>Packbits—用于 TIFF 文件的 PackBits 压缩。</para>
		/// <para>Lzw—保留所有栅格像元值的无损压缩。</para>
		/// <para>Rle—用于 IMG 文件的游程编码。</para>
		/// <para>Ccitt Group 3—用于 1 位数据的无损压缩。</para>
		/// <para>Ccitt Group 4—用于 1 位数据的无损压缩。</para>
		/// <para>Ccitt 1D—用于 1 位数据的无损压缩。</para>
		/// <para>无—不会发生任何压缩。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvCompression()]
		[Category("Geodatabase Settings (optional)")]
		public object Compression { get; set; } = "LZ77";

		/// <summary>
		/// <para>Pyramid Reference Point</para>
		/// <para>栅格金字塔的初始位置。 如果计划在文件地理数据库或企业级地理数据库中构建大的镶嵌数据集，尤其要计划随着时间的推移对这些镶嵌数据进行镶嵌处理时（例如，更新），建议您指定此项。</para>
		/// <para>金字塔参考点应设置在栅格数据集的左上角。</para>
		/// <para>为文件地理数据库或企业级地理数据库设置此点时，如果使用新的镶嵌栅格数据集进行更新，将使用部分构建金字塔。 部分构建金字塔更新了由于新的镶嵌数据集导致的金字塔的不存在部分。 因此，最好设置金字塔参考点，以便整个栅格镶嵌都位于此点的右下方。 不过，金字塔参考点不应设置得过大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Geodatabase Settings (optional)")]
		public object PyramidOrigin { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRasterDataset SetEnviroment(object compression = null, object configKeyword = null, object pyramid = null, double[] tileSize = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, pyramid: pyramid, tileSize: tileSize);
			return this;
		}

	}
}
