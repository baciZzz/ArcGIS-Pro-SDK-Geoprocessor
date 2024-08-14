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
	/// <para>Create Map Tile Package</para>
	/// <para>Generates tiles from a map and packages the tiles to create a single compressed tile package (.tpkx file).</para>
	/// </summary>
	public class CreateMapTilePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The map from which tiles will be generated and packaged.</para>
		/// </param>
		/// <param name="ServiceType">
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>Specifies whether the tiling scheme will be generated from an existing map service or whether map tiles will be generated for ArcGIS Online, Bing Maps, and Google Maps.</para>
		/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme will be used. This is the default.The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay cache tiles with tiles from these online mapping services. ArcGIS Desktop includes this tiling scheme as a built-in option when loading a tiling scheme. When you choose this tiling scheme, the source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system.</para>
		/// <para>The ArcGIS Online/Bing Maps/Google Maps tiling scheme is required if you&apos;ll be overlaying the package with ArcGIS Online, Bing Maps, or Google Maps. One advantage of the ArcGIS Online/Bing Maps/Google Maps tiling scheme is that it is widely known in the web mapping world, so the tiles will match those of other organizations that have used this tiling scheme. Even if you don&apos;t plan to overlay any of these well-known map services, you may choose the tiling scheme for its interoperability potential.</para>
		/// <para>The ArcGIS Online/Bing Maps/Google Maps tiling scheme may contain scales that will be zoomed in too far to be of use in your map. Packaging for large scales can take up time and disk storage space. For example, the largest scale in the tiling scheme is about 1:1,000. Packaging the entire continental United States at this scale can take weeks and require hundreds of gigabytes of storage. If you aren&apos;t prepared to package at this scale level, remove this scale level when you create the tile package.</para>
		/// <para>Unchecked—A tiling scheme from an existing map service will be used.Choose this option if your organization has created a tiling scheme for an existing service on the server and you want to match it. Matching tiling schemes ensures that the tiles will overlay correctly in your ArcGIS Runtime application.</para>
		/// <para>If you choose this option, use the same coordinate system for the source map as the map with the tiling scheme you&apos;re importing.</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output map tile package.</para>
		/// </param>
		/// <param name="FormatType">
		/// <para>Tiling Format</para>
		/// <para>Specifies the format that will be used for the generated tiles.</para>
		/// <para>PNG—The correct format (PNG 8, PNG 24, or PNG 32) will be used based on the specified Level of Detail value. This is the default.</para>
		/// <para>PNG 8 bit—PNG8 format will be used. Use this format for overlay services that need to have a transparent background, such as roads and boundaries. PNG 8 creates tiles of very small size on disk with no loss of information. Do not use PNG 8 if the map contains more than 256 colors. Imagery, hillshades, gradient fills, transparency, and antialiasing can easily use more than 256 colors in a map. Even symbols such as highway shields may have subtle antialiasing around the edges that unexpectedly adds colors to a map.</para>
		/// <para>PNG 24 bit—PNG24 format will be used. Use this format for overlay services, such as roads and boundaries, that have more than 256 colors (if fewer than 256 colors, use PNG 8).</para>
		/// <para>PNG 32 bit—PNG32 format will be used. Use this format for overlay services, such as roads and boundaries, that have more than 256 colors. PNG 32 is a good choice for overlay services that have antialiasing enabled on lines or text. PNG 32 creates larger tiles on disk than PNG 24.</para>
		/// <para>JPEG—JPEG format will be used. Use this format for basemap services that have large color variation and do not need a transparent background. For example, raster imagery and detailed vector basemaps tend to work well with JPEG. JPEG is a lossy image format. It attempts to selectively remove data without affecting the appearance of the image. This can cause very small tile sizes on disk, but if a map contains vector line work or labels, it may produce too much noise or blurry area around the lines. If this is the case, you can raise the compression value from the default of 75. A higher value, such as 90, may balance an acceptable quality of line work with the small tile size benefit of the JPEG.If you are willing to accept a minor amount of noise in the images, you may save large amounts of disk space with JPEG. The smaller tile size also means the application can download the tiles faster.</para>
		/// <para>Mixed—JPEG format will be used in the center of the package and PNG 32 will be used on the edge of the package. Use mixed mode when you want to cleanly overlay raster packages on other layers.When a mixed package is created, PNG 32 tiles are created where transparency is detected (in other words, where the map background is visible). The rest of the tiles are built using JPEG. This keeps the average file size down while providing a clean overlay on top of other packages. If you do not use the mixed mode package in this scenario, a nontransparent collar around the periphery of the image where it overlaps the other package will be visible.</para>
		/// <para><see cref="FormatTypeEnum"/></para>
		/// </param>
		/// <param name="LevelOfDetail">
		/// <para>Maximum Level Of Detail</para>
		/// <para>The integer representation corresponding to the number of scales used to define a cache tiling scheme. This scale value defines the maximum level up to which the cache tiles will be generated in the tile package. Larger values reflect larger scales that show more detail but require more storage space. Smaller values reflect smaller scales that show less detail and require less storage space. Possible values are from 1 to 23. The default value is 1. The maximum level of detail value must be greater than the minimum level of detail value.</para>
		/// </param>
		public CreateMapTilePackage(object InMap, object ServiceType, object OutputFile, object FormatType, object LevelOfDetail)
		{
			this.InMap = InMap;
			this.ServiceType = ServiceType;
			this.OutputFile = OutputFile;
			this.FormatType = FormatType;
			this.LevelOfDetail = LevelOfDetail;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Map Tile Package</para>
		/// </summary>
		public override string DisplayName => "Create Map Tile Package";

		/// <summary>
		/// <para>Tool Name : CreateMapTilePackage</para>
		/// </summary>
		public override string ToolName => "CreateMapTilePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMapTilePackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreateMapTilePackage";

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
		public override string[] ValidEnvironments => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMap, ServiceType, OutputFile, FormatType, LevelOfDetail, ServiceFile!, Summary!, Tags!, Extent!, CompressionQuality!, PackageType!, MinLevelOfDetail!, AreaOfInterest! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map from which tiles will be generated and packaged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>Specifies whether the tiling scheme will be generated from an existing map service or whether map tiles will be generated for ArcGIS Online, Bing Maps, and Google Maps.</para>
		/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme will be used. This is the default.The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay cache tiles with tiles from these online mapping services. ArcGIS Desktop includes this tiling scheme as a built-in option when loading a tiling scheme. When you choose this tiling scheme, the source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system.</para>
		/// <para>The ArcGIS Online/Bing Maps/Google Maps tiling scheme is required if you&apos;ll be overlaying the package with ArcGIS Online, Bing Maps, or Google Maps. One advantage of the ArcGIS Online/Bing Maps/Google Maps tiling scheme is that it is widely known in the web mapping world, so the tiles will match those of other organizations that have used this tiling scheme. Even if you don&apos;t plan to overlay any of these well-known map services, you may choose the tiling scheme for its interoperability potential.</para>
		/// <para>The ArcGIS Online/Bing Maps/Google Maps tiling scheme may contain scales that will be zoomed in too far to be of use in your map. Packaging for large scales can take up time and disk storage space. For example, the largest scale in the tiling scheme is about 1:1,000. Packaging the entire continental United States at this scale can take weeks and require hundreds of gigabytes of storage. If you aren&apos;t prepared to package at this scale level, remove this scale level when you create the tile package.</para>
		/// <para>Unchecked—A tiling scheme from an existing map service will be used.Choose this option if your organization has created a tiling scheme for an existing service on the server and you want to match it. Matching tiling schemes ensures that the tiles will overlay correctly in your ArcGIS Runtime application.</para>
		/// <para>If you choose this option, use the same coordinate system for the source map as the map with the tiling scheme you&apos;re importing.</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ServiceType { get; set; } = "true";

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output map tile package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Tiling Format</para>
		/// <para>Specifies the format that will be used for the generated tiles.</para>
		/// <para>PNG—The correct format (PNG 8, PNG 24, or PNG 32) will be used based on the specified Level of Detail value. This is the default.</para>
		/// <para>PNG 8 bit—PNG8 format will be used. Use this format for overlay services that need to have a transparent background, such as roads and boundaries. PNG 8 creates tiles of very small size on disk with no loss of information. Do not use PNG 8 if the map contains more than 256 colors. Imagery, hillshades, gradient fills, transparency, and antialiasing can easily use more than 256 colors in a map. Even symbols such as highway shields may have subtle antialiasing around the edges that unexpectedly adds colors to a map.</para>
		/// <para>PNG 24 bit—PNG24 format will be used. Use this format for overlay services, such as roads and boundaries, that have more than 256 colors (if fewer than 256 colors, use PNG 8).</para>
		/// <para>PNG 32 bit—PNG32 format will be used. Use this format for overlay services, such as roads and boundaries, that have more than 256 colors. PNG 32 is a good choice for overlay services that have antialiasing enabled on lines or text. PNG 32 creates larger tiles on disk than PNG 24.</para>
		/// <para>JPEG—JPEG format will be used. Use this format for basemap services that have large color variation and do not need a transparent background. For example, raster imagery and detailed vector basemaps tend to work well with JPEG. JPEG is a lossy image format. It attempts to selectively remove data without affecting the appearance of the image. This can cause very small tile sizes on disk, but if a map contains vector line work or labels, it may produce too much noise or blurry area around the lines. If this is the case, you can raise the compression value from the default of 75. A higher value, such as 90, may balance an acceptable quality of line work with the small tile size benefit of the JPEG.If you are willing to accept a minor amount of noise in the images, you may save large amounts of disk space with JPEG. The smaller tile size also means the application can download the tiles faster.</para>
		/// <para>Mixed—JPEG format will be used in the center of the package and PNG 32 will be used on the edge of the package. Use mixed mode when you want to cleanly overlay raster packages on other layers.When a mixed package is created, PNG 32 tiles are created where transparency is detected (in other words, where the map background is visible). The rest of the tiles are built using JPEG. This keeps the average file size down while providing a clean overlay on top of other packages. If you do not use the mixed mode package in this scenario, a nontransparent collar around the periphery of the image where it overlaps the other package will be visible.</para>
		/// <para><see cref="FormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FormatType { get; set; } = "PNG";

		/// <summary>
		/// <para>Maximum Level Of Detail</para>
		/// <para>The integer representation corresponding to the number of scales used to define a cache tiling scheme. This scale value defines the maximum level up to which the cache tiles will be generated in the tile package. Larger values reflect larger scales that show more detail but require more storage space. Smaller values reflect smaller scales that show less detail and require less storage space. Possible values are from 1 to 23. The default value is 1. The maximum level of detail value must be greater than the minimum level of detail value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object LevelOfDetail { get; set; } = "1";

		/// <summary>
		/// <para>Service</para>
		/// <para>The name of the map service or the .xml files that will be used for the tiling scheme. This parameter is required only when the Package for ArcGIS Online | Bing Maps | Google Maps parameter is unchecked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? ServiceFile { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Adds summary information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Adds tag information to the properties of the package. Multiple tags can be added, separated by a comma or semicolon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>Specifies the extent that will be used to select or clip features.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>A value between 1 and 100 for the JPEG compression quality. The default value is 75 for JPEG tile format and zero for other formats.</para>
		/// <para>Compression is supported only for JPEG and mixed formats. Choosing a higher value will result in a larger file size with a higher-quality image. Choosing a lower value will result in a smaller file size with a lower-quality image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Package type</para>
		/// <para>Specifies the type of tile package that will be created.</para>
		/// <para>tpk—Tiles will be stored using Compact storage format. This format is supported across the ArcGIS platform.</para>
		/// <para>tpkx—Tiles will be stored using CompactV2 storage format, which provides better performance on network shares and cloud store directories. This package structure type is supported by newer versions of ArcGIS products such as ArcGIS Online 7.1, ArcGIS Enterprise 10.7, and ArcGIS Runtime 100.5. This is the default.</para>
		/// <para><see cref="PackageTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PackageType { get; set; } = "tpkx";

		/// <summary>
		/// <para>Minimum Level Of Detail</para>
		/// <para>The integer representation corresponding to the number of scales used to define a cache tiling scheme. This scale value defines the level at which the cache tiles begin to be available and generated in the tile package. Possible values are from 0 to 23. The default value is 0. The minimum level of detail value must be less than or equal to the maximum level of detail value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? MinLevelOfDetail { get; set; } = "0";

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>A feature set that constrains where tiles are created. Use an area of interest to create tiles for irregularly shaped areas or multipart features. The areas outside the bounding box of area of interest features will not be cached. If no value is provided for this parameter, the area of interest will be the full extent of the input map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateMapTilePackage SetEnviroment(object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// </summary>
		public enum ServiceTypeEnum 
		{
			/// <summary>
			/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme will be used. This is the default.The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay cache tiles with tiles from these online mapping services. ArcGIS Desktop includes this tiling scheme as a built-in option when loading a tiling scheme. When you choose this tiling scheme, the source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLINE")]
			ONLINE,

			/// <summary>
			/// <para>Unchecked—A tiling scheme from an existing map service will be used.Choose this option if your organization has created a tiling scheme for an existing service on the server and you want to match it. Matching tiling schemes ensures that the tiles will overlay correctly in your ArcGIS Runtime application.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXISTING")]
			EXISTING,

		}

		/// <summary>
		/// <para>Tiling Format</para>
		/// </summary>
		public enum FormatTypeEnum 
		{
			/// <summary>
			/// <para>PNG—The correct format (PNG 8, PNG 24, or PNG 32) will be used based on the specified Level of Detail value. This is the default.</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>PNG 8 bit—PNG8 format will be used. Use this format for overlay services that need to have a transparent background, such as roads and boundaries. PNG 8 creates tiles of very small size on disk with no loss of information. Do not use PNG 8 if the map contains more than 256 colors. Imagery, hillshades, gradient fills, transparency, and antialiasing can easily use more than 256 colors in a map. Even symbols such as highway shields may have subtle antialiasing around the edges that unexpectedly adds colors to a map.</para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG 8 bit")]
			PNG_8_bit,

			/// <summary>
			/// <para>PNG 24 bit—PNG24 format will be used. Use this format for overlay services, such as roads and boundaries, that have more than 256 colors (if fewer than 256 colors, use PNG 8).</para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG 24 bit")]
			PNG_24_bit,

			/// <summary>
			/// <para>PNG 32 bit—PNG32 format will be used. Use this format for overlay services, such as roads and boundaries, that have more than 256 colors. PNG 32 is a good choice for overlay services that have antialiasing enabled on lines or text. PNG 32 creates larger tiles on disk than PNG 24.</para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG 32 bit")]
			PNG_32_bit,

			/// <summary>
			/// <para>JPEG—JPEG format will be used. Use this format for basemap services that have large color variation and do not need a transparent background. For example, raster imagery and detailed vector basemaps tend to work well with JPEG. JPEG is a lossy image format. It attempts to selectively remove data without affecting the appearance of the image. This can cause very small tile sizes on disk, but if a map contains vector line work or labels, it may produce too much noise or blurry area around the lines. If this is the case, you can raise the compression value from the default of 75. A higher value, such as 90, may balance an acceptable quality of line work with the small tile size benefit of the JPEG.If you are willing to accept a minor amount of noise in the images, you may save large amounts of disk space with JPEG. The smaller tile size also means the application can download the tiles faster.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>Mixed—JPEG format will be used in the center of the package and PNG 32 will be used on the edge of the package. Use mixed mode when you want to cleanly overlay raster packages on other layers.When a mixed package is created, PNG 32 tiles are created where transparency is detected (in other words, where the map background is visible). The rest of the tiles are built using JPEG. This keeps the average file size down while providing a clean overlay on top of other packages. If you do not use the mixed mode package in this scenario, a nontransparent collar around the periphery of the image where it overlaps the other package will be visible.</para>
			/// </summary>
			[GPValue("MIXED")]
			[Description("Mixed")]
			Mixed,

		}

		/// <summary>
		/// <para>Package type</para>
		/// </summary>
		public enum PackageTypeEnum 
		{
			/// <summary>
			/// <para>tpk—Tiles will be stored using Compact storage format. This format is supported across the ArcGIS platform.</para>
			/// </summary>
			[GPValue("tpk")]
			[Description("tpk")]
			tpk,

			/// <summary>
			/// <para>tpkx—Tiles will be stored using CompactV2 storage format, which provides better performance on network shares and cloud store directories. This package structure type is supported by newer versions of ArcGIS products such as ArcGIS Online 7.1, ArcGIS Enterprise 10.7, and ArcGIS Runtime 100.5. This is the default.</para>
			/// </summary>
			[GPValue("tpkx")]
			[Description("tpkx")]
			tpkx,

		}

#endregion
	}
}
