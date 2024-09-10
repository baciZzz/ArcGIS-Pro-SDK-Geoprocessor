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
	/// <para>Export Tile Cache</para>
	/// <para>Exports tiles from an existing tile cache to a new tile cache or a tile package. The tiles can be either independently imported into other caches or accessed from ArcGIS Pro or mobile devices.</para>
	/// </summary>
	public class ExportTileCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCacheSource">
		/// <para>Input Tile Cache</para>
		/// <para>An existing tile cache to be exported.</para>
		/// </param>
		/// <param name="InTargetCacheFolder">
		/// <para>Output Tile Cache Location</para>
		/// <para>The output folder into which the tile cache or tile package will be exported.</para>
		/// </param>
		/// <param name="InTargetCacheName">
		/// <para>Output Tile Cache Name</para>
		/// <para>The name of the exported tile cache or tile package.</para>
		/// </param>
		public ExportTileCache(object InCacheSource, object InTargetCacheFolder, object InTargetCacheName)
		{
			this.InCacheSource = InCacheSource;
			this.InTargetCacheFolder = InTargetCacheFolder;
			this.InTargetCacheName = InTargetCacheName;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Tile Cache</para>
		/// </summary>
		public override string DisplayName() => "Export Tile Cache";

		/// <summary>
		/// <para>Tool Name : ExportTileCache</para>
		/// </summary>
		public override string ToolName() => "ExportTileCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportTileCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportTileCache";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCacheSource, InTargetCacheFolder, InTargetCacheName, ExportCacheType, StorageFormatType, Scales, AreaOfInterest, OutCache };

		/// <summary>
		/// <para>Input Tile Cache</para>
		/// <para>An existing tile cache to be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InCacheSource { get; set; }

		/// <summary>
		/// <para>Output Tile Cache Location</para>
		/// <para>The output folder into which the tile cache or tile package will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InTargetCacheFolder { get; set; }

		/// <summary>
		/// <para>Output Tile Cache Name</para>
		/// <para>The name of the exported tile cache or tile package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InTargetCacheName { get; set; }

		/// <summary>
		/// <para>Export Cache As</para>
		/// <para>Specifies whether the cache will be exported as a tile cache or a tile package. Tile packages are suitable for ArcGIS Runtime and ArcGIS Mobile deployments.</para>
		/// <para>Tile cache—The cache will be exported as a stand-alone cache raster dataset. This is the default.</para>
		/// <para>Tile package (tpk)—The cache will be exported as a single compressed file (.tpk) in which the cache dataset is added as a layer and consolidated so that it can be shared easily. This type can be used in ArcMap as well as in ArcGIS Runtime and ArcGIS Mobile applications.</para>
		/// <para>Tile package (tpkx)—The cache will be exported using Compact_v2 storage format (.tpkx), which provides better performance on network shares and cloud storage directories. This improved and simplified package structure type is supported by newer versions of the ArcGIS platform such as ArcGIS Online, ArcGIS Pro 2.3, ArcGIS Enterprise 10.7, and ArcGIS Runtime 100.5.</para>
		/// <para><see cref="ExportCacheTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportCacheType { get; set; } = "TILE_CACHE";

		/// <summary>
		/// <para>Storage Format</para>
		/// <para>Determines the storage format of tiles.</para>
		/// <para>Compact—Group tiles into large files called bundles. This storage format is more efficient in terms of storage and mobility.</para>
		/// <para>Compact v2— Tiles are grouped in bundle files only. This format provides better performance on network shares and cloudstore directories. If the Export cache type parameter is set to Tile package (tpkx) then the extension of the tile package is (.tpkx), which is supported by newer versions of the ArcGIS Platform such as ArcGIS Online, ArcGIS Enterprise 10.9 and ArcGIS Runtime 100.5.This is the default.</para>
		/// <para>Exploded—Each tile is stored as an individual file. Note that this format cannot be used with tile packages.</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageFormatType { get; set; } = "COMPACT_V2";

		/// <summary>
		/// <para>Scales [Pixel Size] (Estimated Disk Space)</para>
		/// <para>A list of scale levels at which tiles will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>An area of interest that spatially constrains where tiles will be exported from the cache.</para>
		/// <para>The area of interest can be a feature class or a feature that you draw on the map.</para>
		/// <para>This parameter is useful if you want to export irregularly shaped areas, as the tool clips the cache dataset at pixel resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Output Tile Cache</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutCache { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTileCache SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Cache As</para>
		/// </summary>
		public enum ExportCacheTypeEnum 
		{
			/// <summary>
			/// <para>Tile cache—The cache will be exported as a stand-alone cache raster dataset. This is the default.</para>
			/// </summary>
			[GPValue("TILE_CACHE")]
			[Description("Tile cache")]
			Tile_cache,

			/// <summary>
			/// <para>Tile package (tpk)—The cache will be exported as a single compressed file (.tpk) in which the cache dataset is added as a layer and consolidated so that it can be shared easily. This type can be used in ArcMap as well as in ArcGIS Runtime and ArcGIS Mobile applications.</para>
			/// </summary>
			[GPValue("TILE_PACKAGE")]
			[Description("Tile package (tpk)")]
			TILE_PACKAGE,

			/// <summary>
			/// <para>Tile package (tpkx)—The cache will be exported using Compact_v2 storage format (.tpkx), which provides better performance on network shares and cloud storage directories. This improved and simplified package structure type is supported by newer versions of the ArcGIS platform such as ArcGIS Online, ArcGIS Pro 2.3, ArcGIS Enterprise 10.7, and ArcGIS Runtime 100.5.</para>
			/// </summary>
			[GPValue("TILE_PACKAGE_TPKX")]
			[Description("Tile package (tpkx)")]
			TILE_PACKAGE_TPKX,

		}

		/// <summary>
		/// <para>Storage Format</para>
		/// </summary>
		public enum StorageFormatTypeEnum 
		{
			/// <summary>
			/// <para>Compact—Group tiles into large files called bundles. This storage format is more efficient in terms of storage and mobility.</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("Compact")]
			Compact,

			/// <summary>
			/// <para>Exploded—Each tile is stored as an individual file. Note that this format cannot be used with tile packages.</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("Exploded")]
			Exploded,

			/// <summary>
			/// <para>Compact v2— Tiles are grouped in bundle files only. This format provides better performance on network shares and cloudstore directories. If the Export cache type parameter is set to Tile package (tpkx) then the extension of the tile package is (.tpkx), which is supported by newer versions of the ArcGIS Platform such as ArcGIS Online, ArcGIS Enterprise 10.9 and ArcGIS Runtime 100.5.This is the default.</para>
			/// </summary>
			[GPValue("COMPACT_V2")]
			[Description("Compact v2")]
			Compact_v2,

		}

#endregion
	}
}
