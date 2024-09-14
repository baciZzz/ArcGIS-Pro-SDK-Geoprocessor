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
	/// <para>Export Map Server Cache</para>
	/// <para>Export Map Server Cache</para>
	/// <para>Exports tiles from a map image layer cache as a cache dataset or tile package to a folder on disk. The tiles can be imported into other caches, or they can be accessed from ArcGIS Desktop or mobile devices as a raster dataset, independent from their parent service.</para>
	/// </summary>
	public class ExportMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map image layer with the cache tiles to be exported. You can choose it by browsing to the desired service in a portal or you can drag a web tile layer from the Portal tab in the Project pane to supply this parameter.</para>
		/// </param>
		/// <param name="TargetCachePath">
		/// <para>Target Cache Path</para>
		/// <para>The folder into which the cache will be exported. This folder does not have to be a registered server cache directory. The ArcGIS Server account must have write access to the target cache folder. If the server account cannot be granted write access to the destination folder but the ArcGIS Desktop or ArcGIS Pro client has write access to it, choose the Copy data from server parameter.</para>
		/// </param>
		/// <param name="ExportCacheType">
		/// <para>Export cache type</para>
		/// <para>Exports a cache as a cache dataset or a tile package. Tile packages are suitable for ArcGIS Runtime and ArcGIS Mobile deployments.</para>
		/// <para>Cache dataset—A map or image service cache that is generated using ArcGIS Server. It can be used in ArcGIS Desktop and by ArcGIS Server map or image services. This is the default.</para>
		/// <para>Tile package—A single compressed file where the cache dataset is added as a layer and consolidated so that it can be shared. In can be used in ArcGIS Desktop, ArcGIS Runtime, and mobile apps.</para>
		/// <para><see cref="ExportCacheTypeEnum"/></para>
		/// </param>
		/// <param name="CopyDataFromServer">
		/// <para>Copy data from server</para>
		/// <para>Check this parameter only if the ArcGIS Server account cannot be granted write access to the target folder and the ArcGIS Desktop or ArcGIS Pro client has write access to it. The software exports the tiles in the server output directory before moving them to the target folder.</para>
		/// <para>Checked—Tiles are placed in the server output directory and are then moved to the target folder. The ArcGIS Desktop client must have write access to the target folder.</para>
		/// <para>Unchecked—Tiles are exported directly into the target folder. The ArcGIS Server account must have write access to the target folder.</para>
		/// <para><see cref="CopyDataFromServerEnum"/></para>
		/// </param>
		/// <param name="StorageFormatType">
		/// <para>Storage Format Type</para>
		/// <para>The storage format of the exported cache.</para>
		/// <para>Compact— Tiles are grouped in bundle and bundlex files to save space on disk and allow for faster copying of caches. If the Export cache type parameter is set to Tile package, this is the default.</para>
		/// <para>Compact V2— Tiles are grouped in bundle files only. This format provides better performance on network shares and cloudstore directories. If the Export cache type parameter is set to Tile package then the extension of the tile package is (.tpkx),which is supported by newer versions of the ArcGIS Platform such as ArcGIS Online, ArcGIS Enterprise 11 and ArcGIS Runtime 100.5.</para>
		/// <para>Exploded—Each tile is stored as an individual file (the way caches were stored prior to ArcGIS Server).</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be exported.</para>
		/// </param>
		public ExportMapServerCache(object InputService, object TargetCachePath, object ExportCacheType, object CopyDataFromServer, object StorageFormatType, object Scales)
		{
			this.InputService = InputService;
			this.TargetCachePath = TargetCachePath;
			this.ExportCacheType = ExportCacheType;
			this.CopyDataFromServer = CopyDataFromServer;
			this.StorageFormatType = StorageFormatType;
			this.Scales = Scales;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Map Server Cache</para>
		/// </summary>
		public override string DisplayName() => "Export Map Server Cache";

		/// <summary>
		/// <para>Tool Name : ExportMapServerCache</para>
		/// </summary>
		public override string ToolName() => "ExportMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.ExportMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.ExportMapServerCache";

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
		public override object[] Parameters() => new object[] { InputService, TargetCachePath, ExportCacheType, CopyDataFromServer, StorageFormatType, Scales, NumOfCachingServiceInstances!, AreaOfInterest!, ExportExtent!, Overwrite!, OutputCachePath! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map image layer with the cache tiles to be exported. You can choose it by browsing to the desired service in a portal or you can drag a web tile layer from the Portal tab in the Project pane to supply this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Target Cache Path</para>
		/// <para>The folder into which the cache will be exported. This folder does not have to be a registered server cache directory. The ArcGIS Server account must have write access to the target cache folder. If the server account cannot be granted write access to the destination folder but the ArcGIS Desktop or ArcGIS Pro client has write access to it, choose the Copy data from server parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetCachePath { get; set; }

		/// <summary>
		/// <para>Export cache type</para>
		/// <para>Exports a cache as a cache dataset or a tile package. Tile packages are suitable for ArcGIS Runtime and ArcGIS Mobile deployments.</para>
		/// <para>Cache dataset—A map or image service cache that is generated using ArcGIS Server. It can be used in ArcGIS Desktop and by ArcGIS Server map or image services. This is the default.</para>
		/// <para>Tile package—A single compressed file where the cache dataset is added as a layer and consolidated so that it can be shared. In can be used in ArcGIS Desktop, ArcGIS Runtime, and mobile apps.</para>
		/// <para><see cref="ExportCacheTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportCacheType { get; set; } = "CACHE_DATASET";

		/// <summary>
		/// <para>Copy data from server</para>
		/// <para>Check this parameter only if the ArcGIS Server account cannot be granted write access to the target folder and the ArcGIS Desktop or ArcGIS Pro client has write access to it. The software exports the tiles in the server output directory before moving them to the target folder.</para>
		/// <para>Checked—Tiles are placed in the server output directory and are then moved to the target folder. The ArcGIS Desktop client must have write access to the target folder.</para>
		/// <para>Unchecked—Tiles are exported directly into the target folder. The ArcGIS Server account must have write access to the target folder.</para>
		/// <para><see cref="CopyDataFromServerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CopyDataFromServer { get; set; } = "false";

		/// <summary>
		/// <para>Storage Format Type</para>
		/// <para>The storage format of the exported cache.</para>
		/// <para>Compact— Tiles are grouped in bundle and bundlex files to save space on disk and allow for faster copying of caches. If the Export cache type parameter is set to Tile package, this is the default.</para>
		/// <para>Compact V2— Tiles are grouped in bundle files only. This format provides better performance on network shares and cloudstore directories. If the Export cache type parameter is set to Tile package then the extension of the tile package is (.tpkx),which is supported by newer versions of the ArcGIS Platform such as ArcGIS Online, ArcGIS Enterprise 11 and ArcGIS Runtime 100.5.</para>
		/// <para>Exploded—Each tile is stored as an individual file (the way caches were stored prior to ArcGIS Server).</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageFormatType { get; set; } = "COMPACT";

		/// <summary>
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>Specifies the number of instances that will be used to update or generate the tiles. The value for this parameter is set to unlimited (-1) and cannot be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>An area of interest that spatially constrains where tiles are exported from the cache. This parameter is useful if you want to export irregularly shaped areas, as the tool clips the cache dataset at pixel resolution.</para>
		/// <para>If you do not specify an area of interest, the full extent of the map is exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Export Extent</para>
		/// <para>A rectangular extent defining the tiles to be exported. By default, the extent is set to the full extent of the map service into which you are importing. Note that the optional parameter on this tool, Area Of Interest, allows you to alternatively import using a polygon. It is recommended that you not provide values for both parameters for a job. If values are provided for both parameters, the Area Of Interest parameter takes precedence over Import Extent.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object? ExportExtent { get; set; }

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// <para>Specifies whether the images in the receiving cache will be merged with the tiles from the originating cache or overwritten by them.</para>
		/// <para>Checked—The export replaces all pixels in the area of interest, effectively overwriting tiles in the destination cache with tiles from the originating cache.</para>
		/// <para>Unchecked—When the tiles are exported, transparent pixels in the originating cache are ignored by default. This results in a merged or blended image in the destination cache. This is the default.</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Output Cache Path</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputCachePath { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Export cache type</para>
		/// </summary>
		public enum ExportCacheTypeEnum 
		{
			/// <summary>
			/// <para>Tile package—A single compressed file where the cache dataset is added as a layer and consolidated so that it can be shared. In can be used in ArcGIS Desktop, ArcGIS Runtime, and mobile apps.</para>
			/// </summary>
			[GPValue("TILE_PACKAGE")]
			[Description("Tile package")]
			Tile_package,

			/// <summary>
			/// <para>Cache dataset—A map or image service cache that is generated using ArcGIS Server. It can be used in ArcGIS Desktop and by ArcGIS Server map or image services. This is the default.</para>
			/// </summary>
			[GPValue("CACHE_DATASET")]
			[Description("Cache dataset")]
			Cache_dataset,

		}

		/// <summary>
		/// <para>Copy data from server</para>
		/// </summary>
		public enum CopyDataFromServerEnum 
		{
			/// <summary>
			/// <para>Checked—Tiles are placed in the server output directory and are then moved to the target folder. The ArcGIS Desktop client must have write access to the target folder.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COPY_DATA")]
			COPY_DATA,

			/// <summary>
			/// <para>Unchecked—Tiles are exported directly into the target folder. The ArcGIS Server account must have write access to the target folder.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_COPY")]
			DO_NOT_COPY,

		}

		/// <summary>
		/// <para>Storage Format Type</para>
		/// </summary>
		public enum StorageFormatTypeEnum 
		{
			/// <summary>
			/// <para>Compact V2— Tiles are grouped in bundle files only. This format provides better performance on network shares and cloudstore directories. If the Export cache type parameter is set to Tile package then the extension of the tile package is (.tpkx),which is supported by newer versions of the ArcGIS Platform such as ArcGIS Online, ArcGIS Enterprise 11 and ArcGIS Runtime 100.5.</para>
			/// </summary>
			[GPValue("COMPACT_V2")]
			[Description("Compact V2")]
			Compact_V2,

			/// <summary>
			/// <para>Compact— Tiles are grouped in bundle and bundlex files to save space on disk and allow for faster copying of caches. If the Export cache type parameter is set to Tile package, this is the default.</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("Compact")]
			Compact,

			/// <summary>
			/// <para>Exploded—Each tile is stored as an individual file (the way caches were stored prior to ArcGIS Server).</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("Exploded")]
			Exploded,

		}

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para>Checked—The export replaces all pixels in the area of interest, effectively overwriting tiles in the destination cache with tiles from the originating cache.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para>Unchecked—When the tiles are exported, transparent pixels in the originating cache are ignored by default. This results in a merged or blended image in the destination cache. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
