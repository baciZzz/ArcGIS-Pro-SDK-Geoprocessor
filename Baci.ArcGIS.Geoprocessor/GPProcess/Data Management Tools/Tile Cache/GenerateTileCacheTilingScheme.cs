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
	/// <para>Creates a tiling scheme file based on the information from the source dataset. The tiling scheme file will then be used in the Manage Tile Cache tool when creating cache tiles.</para>
	/// </summary>
	public class GenerateTileCacheTilingScheme : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Data Source</para>
		/// <para>The source to be used to generate the tiling scheme. It can be a raster dataset, a mosaic dataset, or a map.</para>
		/// </param>
		/// <param name="OutTilingScheme">
		/// <para>Output Tiling Scheme</para>
		/// <para>The path and file name for the output tiling scheme to be created.</para>
		/// </param>
		/// <param name="TilingSchemeGenerationMethod">
		/// <para>Generation Method</para>
		/// <para>Choose to use a new or predefined tiling scheme. You can define a new tiling scheme with this tool or browse to a predefined tiling scheme file (.xml).</para>
		/// <para>New—Define a new tiling scheme using other parameters in this tool to define scale levels, image format, storage format, and so on. This is the default.</para>
		/// <para>Predefined—Use a tiling scheme .xml file that already exists on disk.</para>
		/// <para><see cref="TilingSchemeGenerationMethodEnum"/></para>
		/// </param>
		/// <param name="NumberOfScales">
		/// <para>Number of Scales</para>
		/// <para>The number of scale levels to be created in the tiling scheme.</para>
		/// </param>
		public GenerateTileCacheTilingScheme(object InDataset, object OutTilingScheme, object TilingSchemeGenerationMethod, object NumberOfScales)
		{
			this.InDataset = InDataset;
			this.OutTilingScheme = OutTilingScheme;
			this.TilingSchemeGenerationMethod = TilingSchemeGenerationMethod;
			this.NumberOfScales = NumberOfScales;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Tile Cache Tiling Scheme</para>
		/// </summary>
		public override string DisplayName => "Generate Tile Cache Tiling Scheme";

		/// <summary>
		/// <para>Tool Name : GenerateTileCacheTilingScheme</para>
		/// </summary>
		public override string ToolName => "GenerateTileCacheTilingScheme";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTileCacheTilingScheme</para>
		/// </summary>
		public override string ExcuteName => "management.GenerateTileCacheTilingScheme";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutTilingScheme, TilingSchemeGenerationMethod, NumberOfScales, PredefinedTilingScheme, Scales, ScalesType, TileOrigin, Dpi, TileSize, TileFormat, TileCompressionQuality, StorageFormat, LercError };

		/// <summary>
		/// <para>Input Data Source</para>
		/// <para>The source to be used to generate the tiling scheme. It can be a raster dataset, a mosaic dataset, or a map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Tiling Scheme</para>
		/// <para>The path and file name for the output tiling scheme to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutTilingScheme { get; set; }

		/// <summary>
		/// <para>Generation Method</para>
		/// <para>Choose to use a new or predefined tiling scheme. You can define a new tiling scheme with this tool or browse to a predefined tiling scheme file (.xml).</para>
		/// <para>New—Define a new tiling scheme using other parameters in this tool to define scale levels, image format, storage format, and so on. This is the default.</para>
		/// <para>Predefined—Use a tiling scheme .xml file that already exists on disk.</para>
		/// <para><see cref="TilingSchemeGenerationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingSchemeGenerationMethod { get; set; } = "NEW";

		/// <summary>
		/// <para>Number of Scales</para>
		/// <para>The number of scale levels to be created in the tiling scheme.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfScales { get; set; }

		/// <summary>
		/// <para>Predefined Tiling Scheme</para>
		/// <para>Path to a predefined tiling scheme file (usually named conf.xml). This parameter is enabled only when the Predefined option is chosen as the tiling scheme generation method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object PredefinedTilingScheme { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>Scale levels to be included in the tiling scheme. By default, these are not represented as fractions. Instead, use 500 to represent a scale of 1:500, and so on. The value entered in the Number of Scales parameter generates a set of default scale levels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>Determines the units of the Scales parameter.</para>
		/// <para>Checked—The values of the Scales parameter are pixel sizes. This is the default.</para>
		/// <para>Unchecked—The values of the Scales parameter are scale levels.</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ScalesType { get; set; } = "false";

		/// <summary>
		/// <para>Tile Origin in map units</para>
		/// <para>The origin (upper left corner) of the tiling scheme in the coordinates of the spatial reference of the source dataset. The extent of the source dataset must be within (but does not need to coincide) this region.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Advanced Options")]
		public object TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Dots (Pixels) Per Inch</para>
		/// <para>The dots per inch of the intended output device. If a DPI is chosen that does not match the resolution of the output device, typically a display monitor, the scale of the tile will appear incorrect. The default value is 96.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object Dpi { get; set; } = "96";

		/// <summary>
		/// <para>Tile Size (in pixels)</para>
		/// <para>The width and height of the cache tiles in pixels. The default is 256 by 256.</para>
		/// <para>For the best balance between performance and manageability, avoid deviating from widths of 256 or 512.</para>
		/// <para>128 by 128 pixels— Tile width and height of 128 pixels.</para>
		/// <para>256 by 256 pixels—Tile width and height of 256 pixels.</para>
		/// <para>512 by 512 pixels—Tile width and height of 512 pixels.</para>
		/// <para>1024 by 1024 pixels—Tile width and height of 1024 pixels.</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TileSize { get; set; } = "256 x 256";

		/// <summary>
		/// <para>Tile Format</para>
		/// <para>The file format for the tiles in the cache.</para>
		/// <para>PNG—Creates PNG format with varying bit depths. The bit depths are optimized according to the color variation and transparency values in each tile.</para>
		/// <para>PNG-8—A lossless, 8-bit color, image format that uses an indexed color palette and an alpha table. Each pixel stores a value (0 to 255) that is used to look up the color in the color palette and the transparency in the alpha table. 8-bit PNGs are similar to GIF images and provide the best support for a transparent background by most web browsers.</para>
		/// <para>PNG-24—A lossless, three-channel image format that supports large color variations (16 million colors) and has limited support for transparency. Each pixel contains three 8-bit color channels, and the file header contains the single color that represents the transparent background. The color representing the transparent background color can be set in the application. Versions of Internet Explorer prior to version 7 do not support this type of transparency. Caches using PNG24 are significantly larger than those using PNG8 or JPEG, so will take more disk space and require greater bandwidth to serve clients.</para>
		/// <para>PNG-32—A lossless, four-channel image format that supports large color variations (16 million colors) and transparency. Each pixel contains three 8-bit color channels and one 8-bit alpha channel that represents the level of transparency for each pixel. While the PNG32 format allows for partially transparent pixels in the range from 0 to 255, the ArcGIS Server cache generation tool only writes fully transparent (0) or fully opaque (255) values in the transparency channel. Caches using PNG32 are significantly larger than the other supported formats, so will take more disk space and require greater bandwidth to serve clients.</para>
		/// <para>JPEG—A lossy, three-channel image format that supports large color variations (16 million colors) but does not support transparency. Each pixel contains three 8-bit color channels. Caches using JPEG provide control over output quality and size.</para>
		/// <para>Mixed compression—Creates PNG32 anywhere that transparency is detected (in other words, anyplace where the data frame background is visible), but creates JPEG for the remaining tiles. This keeps the average file size down while providing you with a clean overlay on top of other caches. This is the default.</para>
		/// <para>LERC compression—Limited Error Raster Compression (LERC) is an efficient lossy compression method recommended for single-band or elevation data with a large pixel depth (12 bit to 32 bit). Compresses between 10:1 and 20:1.</para>
		/// <para><see cref="TileFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TileFormat { get; set; } = "MIXED";

		/// <summary>
		/// <para>Tile Compression Quality</para>
		/// <para>Enter a value between 1 and 100 for the JPEG or Mixed compression quality. The default value is 75.</para>
		/// <para>Compression is supported only for Mixed and JPEG format. Choosing a higher value will result in higher-quality images, but the file sizes will be larger. Using a lower value will result in lower-quality images with smaller file sizes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object TileCompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Storage Format</para>
		/// <para>Determines the storage format of tiles.</para>
		/// <para>Compact—Group tiles into large files called bundles. This storage format is more efficient in terms of storage and mobility. This is the default.</para>
		/// <para>Exploded—Each tile is stored as an individual file.Note that this format cannot be used with tile packages.</para>
		/// <para><see cref="StorageFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object StorageFormat { get; set; } = "COMPACT";

		/// <summary>
		/// <para>LERC Error</para>
		/// <para>Set the maximum tolerance in pixel values when compressing with LERC.</para>
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
			/// <para>New—Define a new tiling scheme using other parameters in this tool to define scale levels, image format, storage format, and so on. This is the default.</para>
			/// </summary>
			[GPValue("NEW")]
			[Description("New")]
			New,

			/// <summary>
			/// <para>Predefined—Use a tiling scheme .xml file that already exists on disk.</para>
			/// </summary>
			[GPValue("PREDEFINED")]
			[Description("Predefined")]
			Predefined,

		}

		/// <summary>
		/// <para>Cell Size</para>
		/// </summary>
		public enum ScalesTypeEnum 
		{
			/// <summary>
			/// <para>Checked—The values of the Scales parameter are pixel sizes. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CELL_SIZE")]
			CELL_SIZE,

			/// <summary>
			/// <para>Unchecked—The values of the Scales parameter are scale levels.</para>
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
			/// <para>128 by 128 pixels— Tile width and height of 128 pixels.</para>
			/// </summary>
			[GPValue("128 x 128")]
			[Description("128 by 128 pixels")]
			_128_by_128_pixels,

			/// <summary>
			/// <para>256 by 256 pixels—Tile width and height of 256 pixels.</para>
			/// </summary>
			[GPValue("256 x 256")]
			[Description("256 by 256 pixels")]
			_256_by_256_pixels,

			/// <summary>
			/// <para>512 by 512 pixels—Tile width and height of 512 pixels.</para>
			/// </summary>
			[GPValue("512 x 512")]
			[Description("512 by 512 pixels")]
			_512_by_512_pixels,

			/// <summary>
			/// <para>1024 by 1024 pixels—Tile width and height of 1024 pixels.</para>
			/// </summary>
			[GPValue("1024 x 1024")]
			[Description("1024 by 1024 pixels")]
			_1024_by_1024_pixels,

		}

		/// <summary>
		/// <para>Tile Format</para>
		/// </summary>
		public enum TileFormatEnum 
		{
			/// <summary>
			/// <para>PNG—Creates PNG format with varying bit depths. The bit depths are optimized according to the color variation and transparency values in each tile.</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>PNG-8—A lossless, 8-bit color, image format that uses an indexed color palette and an alpha table. Each pixel stores a value (0 to 255) that is used to look up the color in the color palette and the transparency in the alpha table. 8-bit PNGs are similar to GIF images and provide the best support for a transparent background by most web browsers.</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG-8")]
			PNG8,

			/// <summary>
			/// <para>PNG-24—A lossless, three-channel image format that supports large color variations (16 million colors) and has limited support for transparency. Each pixel contains three 8-bit color channels, and the file header contains the single color that represents the transparent background. The color representing the transparent background color can be set in the application. Versions of Internet Explorer prior to version 7 do not support this type of transparency. Caches using PNG24 are significantly larger than those using PNG8 or JPEG, so will take more disk space and require greater bandwidth to serve clients.</para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG-24")]
			PNG24,

			/// <summary>
			/// <para>PNG-32—A lossless, four-channel image format that supports large color variations (16 million colors) and transparency. Each pixel contains three 8-bit color channels and one 8-bit alpha channel that represents the level of transparency for each pixel. While the PNG32 format allows for partially transparent pixels in the range from 0 to 255, the ArcGIS Server cache generation tool only writes fully transparent (0) or fully opaque (255) values in the transparency channel. Caches using PNG32 are significantly larger than the other supported formats, so will take more disk space and require greater bandwidth to serve clients.</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG-32")]
			PNG32,

			/// <summary>
			/// <para>JPEG—A lossy, three-channel image format that supports large color variations (16 million colors) but does not support transparency. Each pixel contains three 8-bit color channels. Caches using JPEG provide control over output quality and size.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>Mixed compression—Creates PNG32 anywhere that transparency is detected (in other words, anyplace where the data frame background is visible), but creates JPEG for the remaining tiles. This keeps the average file size down while providing you with a clean overlay on top of other caches. This is the default.</para>
			/// </summary>
			[GPValue("MIXED")]
			[Description("Mixed compression")]
			Mixed_compression,

			/// <summary>
			/// <para>LERC compression—Limited Error Raster Compression (LERC) is an efficient lossy compression method recommended for single-band or elevation data with a large pixel depth (12 bit to 32 bit). Compresses between 10:1 and 20:1.</para>
			/// </summary>
			[GPValue("LERC")]
			[Description("LERC compression")]
			LERC_compression,

		}

		/// <summary>
		/// <para>Storage Format</para>
		/// </summary>
		public enum StorageFormatEnum 
		{
			/// <summary>
			/// <para>Compact—Group tiles into large files called bundles. This storage format is more efficient in terms of storage and mobility. This is the default.</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("Compact")]
			Compact,

			/// <summary>
			/// <para>Exploded—Each tile is stored as an individual file.Note that this format cannot be used with tile packages.</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("Exploded")]
			Exploded,

		}

#endregion
	}
}
