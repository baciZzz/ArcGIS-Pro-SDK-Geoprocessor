using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Create Map Server Cache</para>
	/// <para>创建地图服务器缓存</para>
	/// <para>为地图或影像服务缓存创建切片方案和备用文件夹。 运行此工具后，使用管理地图服务器缓存切片工具以将切片添加到缓存。</para>
	/// </summary>
	public class CreateMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>要进行缓存的地图或影像图层。 您可以通过拖动目录窗口中的地图或影像图层来提供此参数。</para>
		/// </param>
		/// <param name="ServiceCacheDirectory">
		/// <para>Service Cache Directory</para>
		/// <para>用于缓存的父目录。 此目录必须是已注册的 ArcGIS Server 缓存目录。</para>
		/// </param>
		/// <param name="TilingSchemeType">
		/// <para>Tiling Scheme</para>
		/// <para>指定切片方案的定义方式。 使用此工具可以定义一个新的切片方案，也可以浏览到一个预定义的切片方案文件 (.xml)。 可以通过运行生成地图服务器缓存切片方案工具来创建预定义方案。</para>
		/// <para>新建—将使用此工具中的其他参数来定义切片方案，从而对比例级别、图像格式和存储格式等设置加以定义。 这是默认设置。</para>
		/// <para>预定义—切片方案将使用 .xml 文件进行定义。 也可使用生成地图服务器缓存切片方案工具创建一个切片方案文件。</para>
		/// <para><see cref="TilingSchemeTypeEnum"/></para>
		/// </param>
		/// <param name="ScalesType">
		/// <para>Scales Type</para>
		/// <para>指定切片的比例调整方式。</para>
		/// <para>标准—系统将根据比例级数（Python 中的 num_of_scales）参数中指定的数字自动生成比例。 该比例将采用从 1:1,000,000 递增或递减一半的级别，并将最接近于源地图文档范围的级别作为起始比例。 例如，如果源地图文档的范围是 1:121,000,000 并且定义了 3 个比例级别，则该地图服务将创建一个缓存，其比例级别可以是 1:128,000,000、1:64,000,000 和 1:32,000,000。 这是默认设置。</para>
		/// <para>自定义—缓存设计器将用于确定比例。</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </param>
		/// <param name="NumOfScales">
		/// <para>Number of Scales</para>
		/// <para>要在缓存中创建的比例级数。 如果要创建一个自定义的比例列表，则此选项不可用。</para>
		/// </param>
		/// <param name="DotsPerInch">
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>专用输出设备的每英寸点数 (DPI)。 如果所选择的 DPI 与输出设备的分辨率不匹配，则地图切片将显示错误比例。 默认值为 96。</para>
		/// </param>
		/// <param name="TileSize">
		/// <para>Tile Size (in pixels)</para>
		/// <para>指定缓存切片的宽度和高度（以像素为单位）。 为在性能和可管理性之间寻求最佳平衡，应避免偏离标准宽度 256 x 256 或 512 x 512。</para>
		/// <para>128 x 128—128 x 128 像素。</para>
		/// <para>256 x 256—256 x 256 像素。 这是默认设置。</para>
		/// <para>512 x 512—512 x 512 像素。</para>
		/// <para>1024 x 1024—1024 x 1024 像素。</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </param>
		public CreateMapServerCache(object InputService, object ServiceCacheDirectory, object TilingSchemeType, object ScalesType, object NumOfScales, object DotsPerInch, object TileSize)
		{
			this.InputService = InputService;
			this.ServiceCacheDirectory = ServiceCacheDirectory;
			this.TilingSchemeType = TilingSchemeType;
			this.ScalesType = ScalesType;
			this.NumOfScales = NumOfScales;
			this.DotsPerInch = DotsPerInch;
			this.TileSize = TileSize;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建地图服务器缓存</para>
		/// </summary>
		public override string DisplayName() => "创建地图服务器缓存";

		/// <summary>
		/// <para>Tool Name : CreateMapServerCache</para>
		/// </summary>
		public override string ToolName() => "CreateMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.CreateMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.CreateMapServerCache";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputService, ServiceCacheDirectory, TilingSchemeType, ScalesType, NumOfScales, DotsPerInch, TileSize, PredefinedTilingScheme, TileOrigin, Scales, CacheTileFormat, TileCompressionQuality, StorageFormat, OutServiceUrl };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>要进行缓存的地图或影像图层。 您可以通过拖动目录窗口中的地图或影像图层来提供此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Service Cache Directory</para>
		/// <para>用于缓存的父目录。 此目录必须是已注册的 ArcGIS Server 缓存目录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ServiceCacheDirectory { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para>指定切片方案的定义方式。 使用此工具可以定义一个新的切片方案，也可以浏览到一个预定义的切片方案文件 (.xml)。 可以通过运行生成地图服务器缓存切片方案工具来创建预定义方案。</para>
		/// <para>新建—将使用此工具中的其他参数来定义切片方案，从而对比例级别、图像格式和存储格式等设置加以定义。 这是默认设置。</para>
		/// <para>预定义—切片方案将使用 .xml 文件进行定义。 也可使用生成地图服务器缓存切片方案工具创建一个切片方案文件。</para>
		/// <para><see cref="TilingSchemeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingSchemeType { get; set; } = "NEW";

		/// <summary>
		/// <para>Scales Type</para>
		/// <para>指定切片的比例调整方式。</para>
		/// <para>标准—系统将根据比例级数（Python 中的 num_of_scales）参数中指定的数字自动生成比例。 该比例将采用从 1:1,000,000 递增或递减一半的级别，并将最接近于源地图文档范围的级别作为起始比例。 例如，如果源地图文档的范围是 1:121,000,000 并且定义了 3 个比例级别，则该地图服务将创建一个缓存，其比例级别可以是 1:128,000,000、1:64,000,000 和 1:32,000,000。 这是默认设置。</para>
		/// <para>自定义—缓存设计器将用于确定比例。</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ScalesType { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Number of Scales</para>
		/// <para>要在缓存中创建的比例级数。 如果要创建一个自定义的比例列表，则此选项不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumOfScales { get; set; }

		/// <summary>
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>专用输出设备的每英寸点数 (DPI)。 如果所选择的 DPI 与输出设备的分辨率不匹配，则地图切片将显示错误比例。 默认值为 96。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object DotsPerInch { get; set; } = "96";

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// <para>指定缓存切片的宽度和高度（以像素为单位）。 为在性能和可管理性之间寻求最佳平衡，应避免偏离标准宽度 256 x 256 或 512 x 512。</para>
		/// <para>128 x 128—128 x 128 像素。</para>
		/// <para>256 x 256—256 x 256 像素。 这是默认设置。</para>
		/// <para>512 x 512—512 x 512 像素。</para>
		/// <para>1024 x 1024—1024 x 1024 像素。</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TileSize { get; set; } = "256 x 256";

		/// <summary>
		/// <para>Predefined Tiling Scheme</para>
		/// <para>预定义切片方案文件（通常名为 conf.xml）的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object PredefinedTilingScheme { get; set; }

		/// <summary>
		/// <para>Tiling origin in map units</para>
		/// <para>切片方案原点（左上角），采用源地图文档空间参考的坐标值。 源地图文档的范围必须在此区域内（但不必与该区域重合）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Scales</para>
		/// <para>用于缓存的比例级别。 不使用分数表示比例级别， 而是使用 500 表示比例 1:500，依此类推。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Cache Tile Format</para>
		/// <para>指定缓存切片格式。</para>
		/// <para>PNG—使用不同位深度的 PNG 格式。 并且已根据切片中的颜色变化和透明度值对位深度进行了优化。 这是默认设置。</para>
		/// <para>PNG8—一种无损 8 位彩色图像格式，使用索引调色板和 alpha 表。 每个像素都存储一个值（0 到 255），用于查看调色板中的颜色和 alpha 表中的透明度。 8 位 PNG 图像类似于 GIF 图像，且大多数 Web 浏览器支持在 PNG 图像中使用透明背景。</para>
		/// <para>PNG24—一种无损三通道图像格式，支持大量的颜色变化（1600 万个颜色），并对透明度提供有限的支持。 每个像素包含三条 8 位颜色通道，并且文件头中包含用于表示透明背景的单一颜色。 早于版本 7 的 Internet Explorer 版本不支持此透明类型。 采用 PNG24 的缓存比采用 PNG8 或 JPEG 的缓存大得多，并且需要使用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
		/// <para>PNG32—一种无损四通道图像格式，支持大量的颜色变化（1600 万个颜色），并支持透明度。 每个像素包含三条 8 位颜色通道和一条表示每个像素的透明度级别的 8 位 alpha 通道。 虽然 PNG32 格式允许部分透明像素位于范围 0 到 255 之间，但是 ArcGIS Server 缓存生成工具仅将完全透明值 (0) 或完全不透明值 (255) 写入透明度通道。 采用 PNG32 的缓存比采用其他受支持的格式的缓存大得多，并且需要使用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
		/// <para>JPEG—一种有损三通道图像格式，支持大量的颜色变化（1600 万个颜色），但不支持透明度。 每个像素包含三条 8 位颜色通道。 采用 JPEG 的缓存可控制输出质量和大小。</para>
		/// <para>混合—PNG32 格式将在检测到透明度的所有位置（也就是数据框背景可见的所有位置）进行创建。 系统将为其余的切片创建 JPEG 格式。 这可降低平均文件大小，同时可在其他缓存上进行完全叠加。</para>
		/// <para><see cref="CacheTileFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CacheTileFormat { get; set; } = "PNG";

		/// <summary>
		/// <para>Tile Compression Quality</para>
		/// <para>JPEG 压缩质量 (1-100)。 对于 JPEG 切片格式，默认值为 75；对于其他切片格式，默认值为 0。</para>
		/// <para>仅 JPEG 格式支持压缩。 如果选择较高的值，则生成的文件较大，但图像质量较好。 如果选择较低的值，则生成的文件较小，但图像质量较差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object TileCompressionQuality { get; set; } = "0";

		/// <summary>
		/// <para>Storage Format</para>
		/// <para>指定切片的存储格式。</para>
		/// <para>紧凑型—切片将分组到较大的包文件中。 此存储格式在存储和移动性方面比较高效。 这是默认设置。</para>
		/// <para>松散型—每个切片都将存储为单独的文件。</para>
		/// <para><see cref="StorageFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageFormat { get; set; } = "COMPACT";

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutServiceUrl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeTypeEnum 
		{
			/// <summary>
			/// <para>新建—将使用此工具中的其他参数来定义切片方案，从而对比例级别、图像格式和存储格式等设置加以定义。 这是默认设置。</para>
			/// </summary>
			[GPValue("NEW")]
			[Description("新建")]
			New,

			/// <summary>
			/// <para>预定义—切片方案将使用 .xml 文件进行定义。 也可使用生成地图服务器缓存切片方案工具创建一个切片方案文件。</para>
			/// </summary>
			[GPValue("PREDEFINED")]
			[Description("预定义")]
			Predefined,

		}

		/// <summary>
		/// <para>Scales Type</para>
		/// </summary>
		public enum ScalesTypeEnum 
		{
			/// <summary>
			/// <para>标准—系统将根据比例级数（Python 中的 num_of_scales）参数中指定的数字自动生成比例。 该比例将采用从 1:1,000,000 递增或递减一半的级别，并将最接近于源地图文档范围的级别作为起始比例。 例如，如果源地图文档的范围是 1:121,000,000 并且定义了 3 个比例级别，则该地图服务将创建一个缓存，其比例级别可以是 1:128,000,000、1:64,000,000 和 1:32,000,000。 这是默认设置。</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("标准")]
			Standard,

			/// <summary>
			/// <para>自定义—缓存设计器将用于确定比例。</para>
			/// </summary>
			[GPValue("CUSTOM")]
			[Description("自定义")]
			Custom,

		}

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// </summary>
		public enum TileSizeEnum 
		{
			/// <summary>
			/// <para>128 x 128—128 x 128 像素。</para>
			/// </summary>
			[GPValue("128 x 128")]
			[Description("128 x 128")]
			_128_by_128,

			/// <summary>
			/// <para>256 x 256—256 x 256 像素。 这是默认设置。</para>
			/// </summary>
			[GPValue("256 x 256")]
			[Description("256 x 256")]
			_256_by_256,

			/// <summary>
			/// <para>512 x 512—512 x 512 像素。</para>
			/// </summary>
			[GPValue("512 x 512")]
			[Description("512 x 512")]
			_512_by_512,

			/// <summary>
			/// <para>1024 x 1024—1024 x 1024 像素。</para>
			/// </summary>
			[GPValue("1024 x 1024")]
			[Description("1024 x 1024")]
			_1024_by_1024,

		}

		/// <summary>
		/// <para>Cache Tile Format</para>
		/// </summary>
		public enum CacheTileFormatEnum 
		{
			/// <summary>
			/// <para>PNG—使用不同位深度的 PNG 格式。 并且已根据切片中的颜色变化和透明度值对位深度进行了优化。 这是默认设置。</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>PNG8—一种无损 8 位彩色图像格式，使用索引调色板和 alpha 表。 每个像素都存储一个值（0 到 255），用于查看调色板中的颜色和 alpha 表中的透明度。 8 位 PNG 图像类似于 GIF 图像，且大多数 Web 浏览器支持在 PNG 图像中使用透明背景。</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG8")]
			PNG8,

			/// <summary>
			/// <para>PNG24—一种无损三通道图像格式，支持大量的颜色变化（1600 万个颜色），并对透明度提供有限的支持。 每个像素包含三条 8 位颜色通道，并且文件头中包含用于表示透明背景的单一颜色。 早于版本 7 的 Internet Explorer 版本不支持此透明类型。 采用 PNG24 的缓存比采用 PNG8 或 JPEG 的缓存大得多，并且需要使用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG24")]
			PNG24,

			/// <summary>
			/// <para>PNG32—一种无损四通道图像格式，支持大量的颜色变化（1600 万个颜色），并支持透明度。 每个像素包含三条 8 位颜色通道和一条表示每个像素的透明度级别的 8 位 alpha 通道。 虽然 PNG32 格式允许部分透明像素位于范围 0 到 255 之间，但是 ArcGIS Server 缓存生成工具仅将完全透明值 (0) 或完全不透明值 (255) 写入透明度通道。 采用 PNG32 的缓存比采用其他受支持的格式的缓存大得多，并且需要使用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG32")]
			PNG32,

			/// <summary>
			/// <para>JPEG—一种有损三通道图像格式，支持大量的颜色变化（1600 万个颜色），但不支持透明度。 每个像素包含三条 8 位颜色通道。 采用 JPEG 的缓存可控制输出质量和大小。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>混合—PNG32 格式将在检测到透明度的所有位置（也就是数据框背景可见的所有位置）进行创建。 系统将为其余的切片创建 JPEG 格式。 这可降低平均文件大小，同时可在其他缓存上进行完全叠加。</para>
			/// </summary>
			[GPValue("MIXED")]
			[Description("混合")]
			Mixed,

		}

		/// <summary>
		/// <para>Storage Format</para>
		/// </summary>
		public enum StorageFormatEnum 
		{
			/// <summary>
			/// <para>紧凑型—切片将分组到较大的包文件中。 此存储格式在存储和移动性方面比较高效。 这是默认设置。</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("紧凑型")]
			Compact,

		}

#endregion
	}
}
