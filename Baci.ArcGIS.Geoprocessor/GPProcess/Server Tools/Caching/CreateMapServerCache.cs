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
	/// <para>Creates the tiling scheme and preparatory folders for a map or image service cache. After running this tool, use the Manage Map Server Cache Tiles tool to add tiles to the cache.</para>
	/// </summary>
	public class CreateMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map or image layer to be cached. You can drag a map or image layer from the Catalog window to supply this parameter.</para>
		/// </param>
		/// <param name="ServiceCacheDirectory">
		/// <para>Service Cache Directory</para>
		/// <para>The parent directory for the cache. This must be a registered ArcGIS Server cache directory.</para>
		/// </param>
		/// <param name="TilingSchemeType">
		/// <para>Tiling Scheme</para>
		/// <para>Specifies how the tiling scheme will be defined. You can define a new tiling scheme with this tool or browse to a predefined tiling scheme file (.xml). A predefined scheme can be created by running the Generate Map Server Cache Tiling Scheme tool.</para>
		/// <para>New—The tiling scheme will be defined using other parameters in this tool to define scale levels, image format, storage format, and so on. This is the default.</para>
		/// <para>Predefined—The tiling scheme will be defined using an .xml file. You can create a tiling scheme file using the Generate Map Server Cache Tiling Scheme tool.</para>
		/// <para><see cref="TilingSchemeTypeEnum"/></para>
		/// </param>
		/// <param name="ScalesType">
		/// <para>Scales Type</para>
		/// <para>Specifies how the tiles will be scaled.</para>
		/// <para>Standard—The scales will be automatically generated based on the number specified in the Number of Scales (num_of_scales in Python) parameter. It will use levels that increase or decrease by half from 1:1,000,000 and will start with a level closest to the extent of the source map document. For example, if the source map document has an extent of 1:121,000,000 and three scale levels are defined, the map service will create a cache with scale levels at 1:128,000,000; 1:64,000,000; and 1:32,000,000. This is the default.</para>
		/// <para>Custom—The cache designer will determine the scales.</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </param>
		/// <param name="NumOfScales">
		/// <para>Number of Scales</para>
		/// <para>The number of scale levels to create in the cache. This option is disabled if you create a custom list of scales.</para>
		/// </param>
		/// <param name="DotsPerInch">
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>The dots per inch (DPI) of the intended output device. If a DPI is chosen that does not match the resolution of the output device, the scale of the map tile will appear incorrect. The default value is 96.</para>
		/// </param>
		/// <param name="TileSize">
		/// <para>Tile Size (in pixels)</para>
		/// <para>Specifies the width and height of the cache tiles in pixels. For the best balance between performance and manageability, avoid deviating from standard widths of 256 by 256 or 512 by 512.</para>
		/// <para>128 by 128—128 by 128 pixels.</para>
		/// <para>256 by 256—256 by 256 pixels. This is the default.</para>
		/// <para>512 by 512—512 by 512 pixels.</para>
		/// <para>1024 by 1024—1024 by 1024 pixels.</para>
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
		/// <para>Tool Display Name : Create Map Server Cache</para>
		/// </summary>
		public override string DisplayName => "Create Map Server Cache";

		/// <summary>
		/// <para>Tool Name : CreateMapServerCache</para>
		/// </summary>
		public override string ToolName => "CreateMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.CreateMapServerCache</para>
		/// </summary>
		public override string ExcuteName => "server.CreateMapServerCache";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputService, ServiceCacheDirectory, TilingSchemeType, ScalesType, NumOfScales!, DotsPerInch, TileSize, PredefinedTilingScheme!, TileOrigin!, Scales!, CacheTileFormat!, TileCompressionQuality!, StorageFormat!, OutServiceUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map or image layer to be cached. You can drag a map or image layer from the Catalog window to supply this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Service Cache Directory</para>
		/// <para>The parent directory for the cache. This must be a registered ArcGIS Server cache directory.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ServiceCacheDirectory { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para>Specifies how the tiling scheme will be defined. You can define a new tiling scheme with this tool or browse to a predefined tiling scheme file (.xml). A predefined scheme can be created by running the Generate Map Server Cache Tiling Scheme tool.</para>
		/// <para>New—The tiling scheme will be defined using other parameters in this tool to define scale levels, image format, storage format, and so on. This is the default.</para>
		/// <para>Predefined—The tiling scheme will be defined using an .xml file. You can create a tiling scheme file using the Generate Map Server Cache Tiling Scheme tool.</para>
		/// <para><see cref="TilingSchemeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingSchemeType { get; set; } = "NEW";

		/// <summary>
		/// <para>Scales Type</para>
		/// <para>Specifies how the tiles will be scaled.</para>
		/// <para>Standard—The scales will be automatically generated based on the number specified in the Number of Scales (num_of_scales in Python) parameter. It will use levels that increase or decrease by half from 1:1,000,000 and will start with a level closest to the extent of the source map document. For example, if the source map document has an extent of 1:121,000,000 and three scale levels are defined, the map service will create a cache with scale levels at 1:128,000,000; 1:64,000,000; and 1:32,000,000. This is the default.</para>
		/// <para>Custom—The cache designer will determine the scales.</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ScalesType { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Number of Scales</para>
		/// <para>The number of scale levels to create in the cache. This option is disabled if you create a custom list of scales.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumOfScales { get; set; }

		/// <summary>
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>The dots per inch (DPI) of the intended output device. If a DPI is chosen that does not match the resolution of the output device, the scale of the map tile will appear incorrect. The default value is 96.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object DotsPerInch { get; set; } = "96";

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// <para>Specifies the width and height of the cache tiles in pixels. For the best balance between performance and manageability, avoid deviating from standard widths of 256 by 256 or 512 by 512.</para>
		/// <para>128 by 128—128 by 128 pixels.</para>
		/// <para>256 by 256—256 by 256 pixels. This is the default.</para>
		/// <para>512 by 512—512 by 512 pixels.</para>
		/// <para>1024 by 1024—1024 by 1024 pixels.</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TileSize { get; set; } = "256 x 256";

		/// <summary>
		/// <para>Predefined Tiling Scheme</para>
		/// <para>The path to a predefined tiling scheme file (usually named conf.xml).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? PredefinedTilingScheme { get; set; }

		/// <summary>
		/// <para>Tiling origin in map units</para>
		/// <para>The origin (upper left corner) of the tiling scheme in the coordinates of the spatial reference of the source map document. The extent of the source map document must be within (but does not need to coincide with) this region.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Scales</para>
		/// <para>The scale levels available for the cache. These are not represented as fractions. Instead, use 500 to represent a scale of 1:500, for example.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Scales { get; set; }

		/// <summary>
		/// <para>Cache Tile Format</para>
		/// <para>Specifies the cache tile format.</para>
		/// <para>PNG—A PNG format with varying bit depths. The bit depths are optimized according to the color variation and transparency values in a tile. This is the default.</para>
		/// <para>PNG8—A lossless, 8-bit color, image format that uses an indexed color palette and an alpha table. Each pixel stores a value (0–255) that is used to look up the color in the color palette and the transparency in the alpha table. 8-bit PNG images are similar to GIF images, and most web browsers support transparent backgrounds in PNG images.</para>
		/// <para>PNG24—A lossless, three-channel image format that supports large color variations (16 million colors) and has limited support for transparency. Each pixel contains three 8-bit color channels, and the file header contains the single color that represents the transparent background. Versions of Internet Explorer earlier than version 7 do not support this type of transparency. Caches using PNG24 are significantly larger than those using PNG8 or JPEG and will use more disk space and require greater bandwidth to serve clients.</para>
		/// <para>PNG32—A lossless, four-channel image format that supports large color variations (16 million colors) and transparency. Each pixel contains three 8-bit color channels and one 8-bit alpha channel that represents the level of transparency for each pixel. While the PNG32 format allows for partially transparent pixels in the range from 0 to 255, the ArcGIS Server cache generation tool only writes fully transparent (0) or fully opaque (255) values in the transparency channel. Caches using PNG32 are significantly larger than the other supported formats and will use more disk space and require greater bandwidth to serve clients.</para>
		/// <para>JPEG—A lossy, three-channel image format that supports large color variations (16 million colors) but does not support transparency. Each pixel contains three 8-bit color channels. Caches using JPEG provide control over output quality and size.</para>
		/// <para>Mixed—The PNG32 format will be created anywhere that transparency is detected (that is, anywhere that the data frame background is visible). The JPEG format will be created for the remaining tiles. This keeps the average file size down while providing a clean overlay on top of other caches.</para>
		/// <para><see cref="CacheTileFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CacheTileFormat { get; set; } = "PNG";

		/// <summary>
		/// <para>Tile Compression Quality</para>
		/// <para>The JPEG compression quality (1–100). The default value is 75 for the JPEG tile format and 0 for other formats.</para>
		/// <para>Compression is supported only for the JPEG format. Choosing a higher value will result in a larger file size with a higher-quality image. Choosing a lower value will result in a smaller file size with a lower-quality image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? TileCompressionQuality { get; set; } = "0";

		/// <summary>
		/// <para>Storage Format</para>
		/// <para>Specifies the storage format of tiles.</para>
		/// <para>Compact—Tiles will be grouped into large files called bundles. This storage format is efficient in terms of storage and mobility. This is the default.</para>
		/// <para>Exploded—Each tile will be stored as a separate file.</para>
		/// <para><see cref="StorageFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StorageFormat { get; set; } = "COMPACT";

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutServiceUrl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeTypeEnum 
		{
			/// <summary>
			/// <para>New—The tiling scheme will be defined using other parameters in this tool to define scale levels, image format, storage format, and so on. This is the default.</para>
			/// </summary>
			[GPValue("NEW")]
			[Description("New")]
			New,

			/// <summary>
			/// <para>Predefined—The tiling scheme will be defined using an .xml file. You can create a tiling scheme file using the Generate Map Server Cache Tiling Scheme tool.</para>
			/// </summary>
			[GPValue("PREDEFINED")]
			[Description("Predefined")]
			Predefined,

		}

		/// <summary>
		/// <para>Scales Type</para>
		/// </summary>
		public enum ScalesTypeEnum 
		{
			/// <summary>
			/// <para>Standard—The scales will be automatically generated based on the number specified in the Number of Scales (num_of_scales in Python) parameter. It will use levels that increase or decrease by half from 1:1,000,000 and will start with a level closest to the extent of the source map document. For example, if the source map document has an extent of 1:121,000,000 and three scale levels are defined, the map service will create a cache with scale levels at 1:128,000,000; 1:64,000,000; and 1:32,000,000. This is the default.</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard")]
			Standard,

			/// <summary>
			/// <para>Custom—The cache designer will determine the scales.</para>
			/// </summary>
			[GPValue("CUSTOM")]
			[Description("Custom")]
			Custom,

		}

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// </summary>
		public enum TileSizeEnum 
		{
			/// <summary>
			/// <para>128 by 128—128 by 128 pixels.</para>
			/// </summary>
			[GPValue("128 x 128")]
			[Description("128 by 128")]
			_128_by_128,

			/// <summary>
			/// <para>256 by 256—256 by 256 pixels. This is the default.</para>
			/// </summary>
			[GPValue("256 x 256")]
			[Description("256 by 256")]
			_256_by_256,

			/// <summary>
			/// <para>512 by 512—512 by 512 pixels.</para>
			/// </summary>
			[GPValue("512 x 512")]
			[Description("512 by 512")]
			_512_by_512,

			/// <summary>
			/// <para>1024 by 1024—1024 by 1024 pixels.</para>
			/// </summary>
			[GPValue("1024 x 1024")]
			[Description("1024 by 1024")]
			_1024_by_1024,

		}

		/// <summary>
		/// <para>Cache Tile Format</para>
		/// </summary>
		public enum CacheTileFormatEnum 
		{
			/// <summary>
			/// <para>PNG—A PNG format with varying bit depths. The bit depths are optimized according to the color variation and transparency values in a tile. This is the default.</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>PNG8—A lossless, 8-bit color, image format that uses an indexed color palette and an alpha table. Each pixel stores a value (0–255) that is used to look up the color in the color palette and the transparency in the alpha table. 8-bit PNG images are similar to GIF images, and most web browsers support transparent backgrounds in PNG images.</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG8")]
			PNG8,

			/// <summary>
			/// <para>PNG24—A lossless, three-channel image format that supports large color variations (16 million colors) and has limited support for transparency. Each pixel contains three 8-bit color channels, and the file header contains the single color that represents the transparent background. Versions of Internet Explorer earlier than version 7 do not support this type of transparency. Caches using PNG24 are significantly larger than those using PNG8 or JPEG and will use more disk space and require greater bandwidth to serve clients.</para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG24")]
			PNG24,

			/// <summary>
			/// <para>PNG32—A lossless, four-channel image format that supports large color variations (16 million colors) and transparency. Each pixel contains three 8-bit color channels and one 8-bit alpha channel that represents the level of transparency for each pixel. While the PNG32 format allows for partially transparent pixels in the range from 0 to 255, the ArcGIS Server cache generation tool only writes fully transparent (0) or fully opaque (255) values in the transparency channel. Caches using PNG32 are significantly larger than the other supported formats and will use more disk space and require greater bandwidth to serve clients.</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG32")]
			PNG32,

			/// <summary>
			/// <para>JPEG—A lossy, three-channel image format that supports large color variations (16 million colors) but does not support transparency. Each pixel contains three 8-bit color channels. Caches using JPEG provide control over output quality and size.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>Mixed—The PNG32 format will be created anywhere that transparency is detected (that is, anywhere that the data frame background is visible). The JPEG format will be created for the remaining tiles. This keeps the average file size down while providing a clean overlay on top of other caches.</para>
			/// </summary>
			[GPValue("MIXED")]
			[Description("Mixed")]
			Mixed,

		}

		/// <summary>
		/// <para>Storage Format</para>
		/// </summary>
		public enum StorageFormatEnum 
		{
			/// <summary>
			/// <para>Compact—Tiles will be grouped into large files called bundles. This storage format is efficient in terms of storage and mobility. This is the default.</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("Compact")]
			Compact,

		}

#endregion
	}
}
