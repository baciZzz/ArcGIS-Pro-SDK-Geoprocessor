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
	/// <para>Import Map Server Cache</para>
	/// <para>Imports tiles from a folder on disk into a map image layer cache.</para>
	/// </summary>
	public class ImportMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map image layer with the cache tiles to be imported. You can choose it by browsing to the desired service in a portal, or you can drag a web tile layer from the Portal tab in the Project pane to supply this parameter.</para>
		/// </param>
		/// <param name="SourceCacheType">
		/// <para>Source Cache Type</para>
		/// <para>Imports a cache from a cache dataset or tile package to a cached map or image service running on the server.</para>
		/// <para>Map or image service cache—A map or image service cache that is generated using ArcGIS Server. It can be used in ArcGIS Desktop and by ArcGIS Server map or image services.</para>
		/// <para>Tile package—A single compressed file where the cache dataset is added as a layer and consolidated so that it can be shared. It can be used in ArcGIS Desktop, ArcGIS Runtime, and mobile apps.</para>
		/// <para><see cref="SourceCacheTypeEnum"/></para>
		/// </param>
		public ImportMapServerCache(object InputService, object SourceCacheType)
		{
			this.InputService = InputService;
			this.SourceCacheType = SourceCacheType;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Map Server Cache</para>
		/// </summary>
		public override string DisplayName => "Import Map Server Cache";

		/// <summary>
		/// <para>Tool Name : ImportMapServerCache</para>
		/// </summary>
		public override string ToolName => "ImportMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.ImportMapServerCache</para>
		/// </summary>
		public override string ExcuteName => "server.ImportMapServerCache";

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
		public override object[] Parameters => new object[] { InputService, SourceCacheType, SourceCacheDataset, SourceTilePackage, UploadDataToServer, Scales, NumOfCachingServiceInstances, AreaOfInterest, ImportExtent, Overwrite, OutJobUrl };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map image layer with the cache tiles to be imported. You can choose it by browsing to the desired service in a portal, or you can drag a web tile layer from the Portal tab in the Project pane to supply this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Source Cache Type</para>
		/// <para>Imports a cache from a cache dataset or tile package to a cached map or image service running on the server.</para>
		/// <para>Map or image service cache—A map or image service cache that is generated using ArcGIS Server. It can be used in ArcGIS Desktop and by ArcGIS Server map or image services.</para>
		/// <para>Tile package—A single compressed file where the cache dataset is added as a layer and consolidated so that it can be shared. It can be used in ArcGIS Desktop, ArcGIS Runtime, and mobile apps.</para>
		/// <para><see cref="SourceCacheTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SourceCacheType { get; set; } = "CACHE_DATASET";

		/// <summary>
		/// <para>Source Cache Dataset</para>
		/// <para>The path to the tiles that will be imported. This is represented by a raster dataset icon when you are browsing. You do not have to specify a registered server cache directory; most of the time you'll specify a location on disk where tiles have been previously exported. This location should be accessible to the ArcGIS Server account. If the ArcGIS Server account cannot be granted access to this location, check the Upload data to server parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object SourceCacheDataset { get; set; }

		/// <summary>
		/// <para>Source Tile Package</para>
		/// <para>The path to the tile package that will be imported. This location should be accessible to the ArcGIS Server account. Importing a tile package file to a cached map or image service automatically enables the Upload data to server parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object SourceTilePackage { get; set; }

		/// <summary>
		/// <para>Upload data to server</para>
		/// <para>Check this parameter if the ArcGIS Server account does not have read access to the source cache. The tool will upload the source cache to the ArcGIS Server uploads directory before moving it to the ArcGIS Server cache directory.</para>
		/// <para>Checked—Tiles are placed in the server uploads directory and are then moved to the server cache directory. This is active by default when the Source Cache Type parameter is set to TILE_PACKAGE.</para>
		/// <para>Unchecked—Tiles are imported directly into the server cache directory. The ArcGIS Server account must have read access to the source cache.</para>
		/// <para><see cref="UploadDataToServerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UploadDataToServer { get; set; } = "false";

		/// <summary>
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be imported.</para>
		/// <para>By default, the scales listed in the tool dialog box are between the minimum and maximum cached scales for the service. To update the scale range, go to the Service EditorCaching tab and use the sliders to update the minimum and maximum cached scales.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>Specifies the number of instances that will be used to update or generate the tiles. The value for this parameter is set to unlimited (-1) and cannot be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>An area of interest polygon that spatially constrains where tiles are imported into the cache. This parameter is useful if you want to import tiles for irregularly shaped areas, as the tool clips the cache dataset, which intersects the polygon at pixel resolution and imports it to the service cache directory.</para>
		/// <para>If you do not provide a value for this parameter, the value of the Import Extent parameter will be used. The default is to use the full extent of the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Import Extent</para>
		/// <para>A rectangular extent defining the tiles to be imported into the cache. By default, the extent is set to the full extent of the map service into which you are importing. Note that the optional parameter on this tool, Area Of Interest, allows you to spatially constrain the imported tiles using an irregular shape. If values are provided for both parameters, the Area Of Interest parameter takes precedence over Import Extent.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object ImportExtent { get; set; }

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// <para>Specifies whether the images in the destination cache will be merged with the tiles from the originating cache or overwritten by them.</para>
		/// <para>Checked—The import replaces all pixels in the area of interest, effectively overwriting tiles in the destination cache with tiles from the originating cache.</para>
		/// <para>Unchecked—When the tiles are imported, transparent pixels in the originating cache are ignored by default. This results in a merged or blended image in the destination cache. This is the default.</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutJobUrl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Source Cache Type</para>
		/// </summary>
		public enum SourceCacheTypeEnum 
		{
			/// <summary>
			/// <para>Map or image service cache—A map or image service cache that is generated using ArcGIS Server. It can be used in ArcGIS Desktop and by ArcGIS Server map or image services.</para>
			/// </summary>
			[GPValue("CACHE_DATASET")]
			[Description("Map or image service cache")]
			Map_or_image_service_cache,

			/// <summary>
			/// <para>Tile package—A single compressed file where the cache dataset is added as a layer and consolidated so that it can be shared. It can be used in ArcGIS Desktop, ArcGIS Runtime, and mobile apps.</para>
			/// </summary>
			[GPValue("TILE_PACKAGE")]
			[Description("Tile package")]
			Tile_package,

		}

		/// <summary>
		/// <para>Upload data to server</para>
		/// </summary>
		public enum UploadDataToServerEnum 
		{
			/// <summary>
			/// <para>Checked—Tiles are placed in the server uploads directory and are then moved to the server cache directory. This is active by default when the Source Cache Type parameter is set to TILE_PACKAGE.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPLOAD_DATA")]
			UPLOAD_DATA,

			/// <summary>
			/// <para>Unchecked—Tiles are imported directly into the server cache directory. The ArcGIS Server account must have read access to the source cache.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_UPLOAD")]
			DO_NOT_UPLOAD,

		}

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para>Checked—The import replaces all pixels in the area of interest, effectively overwriting tiles in the destination cache with tiles from the originating cache.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para>Unchecked—When the tiles are imported, transparent pixels in the originating cache are ignored by default. This results in a merged or blended image in the destination cache. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
