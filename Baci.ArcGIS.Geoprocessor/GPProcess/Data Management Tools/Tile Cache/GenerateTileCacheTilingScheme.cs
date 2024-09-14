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
	/// <para>Generate Tile Cache Tiling Scheme</para>
	/// <para>生成切片缓存切片方案</para>
	/// <para>基于源数据集的信息创建切片方案文件。当创建缓存切片时，切片方案文件随后可在管理切片缓存工具中使用。</para>
	/// </summary>
	public class GenerateTileCacheTilingScheme : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Data Source</para>
		/// <para>将用来生成切片方案的源。它可以是栅格数据集、镶嵌数据集或地图。</para>
		/// </param>
		/// <param name="OutTilingScheme">
		/// <para>Output Tiling Scheme</para>
		/// <para>要创建的输出切片方案的路径和文件名。</para>
		/// </param>
		/// <param name="TilingSchemeGenerationMethod">
		/// <para>Generation Method</para>
		/// <para>选择采用新的切片方案还是预定义切片方案。使用此工具可以定义一个新的切片方案，也可以浏览到一个预定义的切片方案文件 (.xml)。</para>
		/// <para>新建—使用此工具中的其他参数来定义一个新的切片方案，从而对比例级别、图像格式和存储格式等设置加以定义。这是默认设置。</para>
		/// <para>预定义—使用磁盘上已存在的切片方案 .xml 文件。</para>
		/// <para><see cref="TilingSchemeGenerationMethodEnum"/></para>
		/// </param>
		/// <param name="NumberOfScales">
		/// <para>Number of Scales</para>
		/// <para>要在切片方案中创建的比例级数。</para>
		/// </param>
		public GenerateTileCacheTilingScheme(object InDataset, object OutTilingScheme, object TilingSchemeGenerationMethod, object NumberOfScales)
		{
			this.InDataset = InDataset;
			this.OutTilingScheme = OutTilingScheme;
			this.TilingSchemeGenerationMethod = TilingSchemeGenerationMethod;
			this.NumberOfScales = NumberOfScales;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成切片缓存切片方案</para>
		/// </summary>
		public override string DisplayName() => "生成切片缓存切片方案";

		/// <summary>
		/// <para>Tool Name : GenerateTileCacheTilingScheme</para>
		/// </summary>
		public override string ToolName() => "GenerateTileCacheTilingScheme";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTileCacheTilingScheme</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateTileCacheTilingScheme";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutTilingScheme, TilingSchemeGenerationMethod, NumberOfScales, PredefinedTilingScheme, Scales, ScalesType, TileOrigin, Dpi, TileSize, TileFormat, TileCompressionQuality, StorageFormat, LercError };

		/// <summary>
		/// <para>Input Data Source</para>
		/// <para>将用来生成切片方案的源。它可以是栅格数据集、镶嵌数据集或地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Tiling Scheme</para>
		/// <para>要创建的输出切片方案的路径和文件名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutTilingScheme { get; set; }

		/// <summary>
		/// <para>Generation Method</para>
		/// <para>选择采用新的切片方案还是预定义切片方案。使用此工具可以定义一个新的切片方案，也可以浏览到一个预定义的切片方案文件 (.xml)。</para>
		/// <para>新建—使用此工具中的其他参数来定义一个新的切片方案，从而对比例级别、图像格式和存储格式等设置加以定义。这是默认设置。</para>
		/// <para>预定义—使用磁盘上已存在的切片方案 .xml 文件。</para>
		/// <para><see cref="TilingSchemeGenerationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingSchemeGenerationMethod { get; set; } = "NEW";

		/// <summary>
		/// <para>Number of Scales</para>
		/// <para>要在切片方案中创建的比例级数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfScales { get; set; }

		/// <summary>
		/// <para>Predefined Tiling Scheme</para>
		/// <para>预定义切片方案文件（通常名为 conf.xml）的路径。仅当预定义选项被选为切片方案生成方法时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object PredefinedTilingScheme { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>要包含在切片方案中的比例级别。默认情况下，不使用分数表示比例级别。而是使用 500 表示比例 1:500，依此类推。在比例级数参数中输入的值将会生成一组默认比例级别。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>确定比例参数的单位。</para>
		/// <para>选中 - 比例参数值为像素大小。这是默认设置。</para>
		/// <para>取消选中 - 比例参数值为比例级别。</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ScalesType { get; set; } = "false";

		/// <summary>
		/// <para>Tile Origin in map units</para>
		/// <para>切片方案原点（左上角），采用源数据集空间参考的坐标值。源数据集的范围必须在此原点范围内（但不必与原点重合）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Advanced Options")]
		public object TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Dots (Pixels) Per Inch</para>
		/// <para>专用输出设备的每英寸点数。如果所选择的 DPI 与输出设备（通常是显示器）的分辨率不匹配，则切片将显示错误比例。默认值为 96。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object Dpi { get; set; } = "96";

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// <para>缓存切片的宽度和高度（以像素为单位）。默认值为 256 x 256。</para>
		/// <para>为在性能和可管理性之间寻求最佳平衡，应避免偏离宽度值 256 或 512。</para>
		/// <para>128 x 128 像素— 切片宽度和高度为 128 像素。</para>
		/// <para>256 x 256 像素—切片宽度和高度为 256 像素。</para>
		/// <para>512 x 512 像素—切片宽度和高度为 512 像素。</para>
		/// <para>1024 x 1024 像素—切片宽度和高度为 1024 像素。</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TileSize { get; set; } = "256 x 256";

		/// <summary>
		/// <para>Tile Format</para>
		/// <para>缓存中切片的文件格式。</para>
		/// <para>PNG—使用不同的位深度创建 PNG 格式。已根据每个切片中的颜色变化和透明度值对位深度进行了优化。</para>
		/// <para>PNG-8—一种无损 8 位彩色图像格式，使用索引调色板和 alpha 表。每个像素都存储一个值（0 到 255），用于查看调色板中的颜色和 alpha 表中的透明度。8 位 PNG 类似于 GIF 图像，并对多数 Web 浏览器的透明背景提供最佳支持。</para>
		/// <para>PNG-24—一种无损三通道图像格式，支持大量的颜色变化（1600 万个颜色），并对透明度提供有限的支持。每个像素包含三条 8 位颜色通道，并且文件头中包含用于表示透明背景的单一颜色。可在应用程序中对表示透明背景色的颜色进行设置。版本 7 之前的 Internet Explorer 版本不支持此透明类型。采用 PNG24 的缓存比采用 PNG8 或 JPEG 的缓存大得多，所以需要占用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
		/// <para>PNG-32—一种无损四通道图像格式，支持大量的颜色变化（1600 万个颜色），并支持透明度。每个像素包含三条 8 位颜色通道和一条表示每个像素的透明度级别的 8 位 alpha 通道。虽然 PNG32 格式允许部分透明像素位于范围 0 到 255 之间，但是 ArcGIS Server 缓存生成工具仅将完全透明值 (0) 或完全不透明值 (255) 写入透明度通道。采用 PNG32 的缓存比采用其他受支持格式的缓存大得多，所以需要占用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
		/// <para>JPEG—一种有损三通道图像格式，支持大量的颜色变化（1600 万个颜色），但不支持透明度。每个像素包含三条 8 位颜色通道。采用 JPEG 的缓存可对输出质量和大小加以控制。</para>
		/// <para>MIXED 压缩—在检测到透明度的所有位置（也就是数据框背景可见的所有位置）创建 PNG32，而为其余切片创建 JPEG。这可降低平均文件大小，同时可在其他缓存上进行完全叠加。这是默认设置。</para>
		/// <para>LERC 压缩—有限错误栅格压缩 (LERC) 是一种高效的有损压缩方法，适用于较大像素深度的单波段或高程数据（12 位到 32 位）。压缩为 10:1 到 20:1。</para>
		/// <para><see cref="TileFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TileFormat { get; set; } = "MIXED";

		/// <summary>
		/// <para>Tile Compression Quality</para>
		/// <para>针对 JPEG 或 MIXED 压缩质量输入一个介于 1 和 100 之间的值。默认值为 75。</para>
		/// <para>只有 MIXED 和 JPEG 格式支持压缩。选择较高的值，则图像质量也较高，但文件会较大。使用较低的值，则图像质量也较低且文件较小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object TileCompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Storage Format</para>
		/// <para>确定切片的存储格式。</para>
		/// <para>压缩—将切片分组到较大的包文件中。此存储格式在存储和移动性方面更高效。这是默认设置。</para>
		/// <para>松散型—每个切片都以单个文件的形式存储。请注意，此格式无法用于切片包。</para>
		/// <para><see cref="StorageFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object StorageFormat { get; set; } = "COMPACT";

		/// <summary>
		/// <para>LERC Error</para>
		/// <para>设置通过 LERC 进行压缩时像素值的最大容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object LercError { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Generation Method</para>
		/// </summary>
		public enum TilingSchemeGenerationMethodEnum 
		{
			/// <summary>
			/// <para>新建—使用此工具中的其他参数来定义一个新的切片方案，从而对比例级别、图像格式和存储格式等设置加以定义。这是默认设置。</para>
			/// </summary>
			[GPValue("NEW")]
			[Description("新建")]
			New,

			/// <summary>
			/// <para>预定义—使用磁盘上已存在的切片方案 .xml 文件。</para>
			/// </summary>
			[GPValue("PREDEFINED")]
			[Description("预定义")]
			Predefined,

		}

		/// <summary>
		/// <para>Cell Size</para>
		/// </summary>
		public enum ScalesTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CELL_SIZE")]
			CELL_SIZE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SCALE")]
			SCALE,

		}

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// </summary>
		public enum TileSizeEnum 
		{
			/// <summary>
			/// <para>128 x 128 像素— 切片宽度和高度为 128 像素。</para>
			/// </summary>
			[GPValue("128 x 128")]
			[Description("128 x 128 像素")]
			_128_by_128_pixels,

			/// <summary>
			/// <para>256 x 256 像素—切片宽度和高度为 256 像素。</para>
			/// </summary>
			[GPValue("256 x 256")]
			[Description("256 x 256 像素")]
			_256_by_256_pixels,

			/// <summary>
			/// <para>512 x 512 像素—切片宽度和高度为 512 像素。</para>
			/// </summary>
			[GPValue("512 x 512")]
			[Description("512 x 512 像素")]
			_512_by_512_pixels,

			/// <summary>
			/// <para>1024 x 1024 像素—切片宽度和高度为 1024 像素。</para>
			/// </summary>
			[GPValue("1024 x 1024")]
			[Description("1024 x 1024 像素")]
			_1024_by_1024_pixels,

		}

		/// <summary>
		/// <para>Tile Format</para>
		/// </summary>
		public enum TileFormatEnum 
		{
			/// <summary>
			/// <para>PNG—使用不同的位深度创建 PNG 格式。已根据每个切片中的颜色变化和透明度值对位深度进行了优化。</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>PNG-8—一种无损 8 位彩色图像格式，使用索引调色板和 alpha 表。每个像素都存储一个值（0 到 255），用于查看调色板中的颜色和 alpha 表中的透明度。8 位 PNG 类似于 GIF 图像，并对多数 Web 浏览器的透明背景提供最佳支持。</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG-8")]
			PNG8,

			/// <summary>
			/// <para>PNG-24—一种无损三通道图像格式，支持大量的颜色变化（1600 万个颜色），并对透明度提供有限的支持。每个像素包含三条 8 位颜色通道，并且文件头中包含用于表示透明背景的单一颜色。可在应用程序中对表示透明背景色的颜色进行设置。版本 7 之前的 Internet Explorer 版本不支持此透明类型。采用 PNG24 的缓存比采用 PNG8 或 JPEG 的缓存大得多，所以需要占用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG-24")]
			PNG24,

			/// <summary>
			/// <para>PNG-32—一种无损四通道图像格式，支持大量的颜色变化（1600 万个颜色），并支持透明度。每个像素包含三条 8 位颜色通道和一条表示每个像素的透明度级别的 8 位 alpha 通道。虽然 PNG32 格式允许部分透明像素位于范围 0 到 255 之间，但是 ArcGIS Server 缓存生成工具仅将完全透明值 (0) 或完全不透明值 (255) 写入透明度通道。采用 PNG32 的缓存比采用其他受支持格式的缓存大得多，所以需要占用更多磁盘空间和更大带宽才能为客户端提供服务。</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG-32")]
			PNG32,

			/// <summary>
			/// <para>JPEG—一种有损三通道图像格式，支持大量的颜色变化（1600 万个颜色），但不支持透明度。每个像素包含三条 8 位颜色通道。采用 JPEG 的缓存可对输出质量和大小加以控制。</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>MIXED 压缩—在检测到透明度的所有位置（也就是数据框背景可见的所有位置）创建 PNG32，而为其余切片创建 JPEG。这可降低平均文件大小，同时可在其他缓存上进行完全叠加。这是默认设置。</para>
			/// </summary>
			[GPValue("MIXED")]
			[Description("MIXED 压缩")]
			Mixed_compression,

			/// <summary>
			/// <para>LERC 压缩—有限错误栅格压缩 (LERC) 是一种高效的有损压缩方法，适用于较大像素深度的单波段或高程数据（12 位到 32 位）。压缩为 10:1 到 20:1。</para>
			/// </summary>
			[GPValue("LERC")]
			[Description("LERC 压缩")]
			LERC_compression,

		}

		/// <summary>
		/// <para>Storage Format</para>
		/// </summary>
		public enum StorageFormatEnum 
		{
			/// <summary>
			/// <para>压缩—将切片分组到较大的包文件中。此存储格式在存储和移动性方面更高效。这是默认设置。</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("压缩")]
			Compact,

			/// <summary>
			/// <para>松散型—每个切片都以单个文件的形式存储。请注意，此格式无法用于切片包。</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("松散型")]
			Exploded,

		}

#endregion
	}
}
