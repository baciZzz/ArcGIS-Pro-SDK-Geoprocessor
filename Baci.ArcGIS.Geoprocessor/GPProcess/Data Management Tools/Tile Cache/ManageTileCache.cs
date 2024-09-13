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
	/// <para>Manage Tile Cache</para>
	/// <para>Manage Tile Cache</para>
	/// <para>Creates a tile cache or updates tiles in an existing tile cache. You can use this tool to create tiles, replace missing tiles, overwrite outdated tiles, and delete tiles.</para>
	/// </summary>
	public class ManageTileCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCacheLocation">
		/// <para>Cache Location</para>
		/// <para>The folder in which the cache dataset is created, the raster layer, or the path to an existing tile cache.</para>
		/// </param>
		/// <param name="ManageMode">
		/// <para>Manage Mode</para>
		/// <para>Specifies the mode that will be used to manage the cache.</para>
		/// <para>Recreate all tiles—Existing tiles will be replaced and new tiles will be added if the extent has changed or if layers have been added to a multilayer cache.</para>
		/// <para>Recreate empty tiles—Only tiles that are empty will be created. Existing tiles will be left unchanged.</para>
		/// <para>Delete tiles—Tiles will be deleted from the cache. The cache folder structure will not be deleted.</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </param>
		public ManageTileCache(object InCacheLocation, object ManageMode)
		{
			this.InCacheLocation = InCacheLocation;
			this.ManageMode = ManageMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Tile Cache</para>
		/// </summary>
		public override string DisplayName() => "Manage Tile Cache";

		/// <summary>
		/// <para>Tool Name : ManageTileCache</para>
		/// </summary>
		public override string ToolName() => "ManageTileCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ManageTileCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ManageTileCache";

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
		public override object[] Parameters() => new object[] { InCacheLocation, ManageMode, InCacheName!, InDatasource!, TilingScheme!, ImportTilingScheme!, Scales!, AreaOfInterest!, MaxCellSize!, MinCachedScale!, MaxCachedScale!, OutCacheLocation! };

		/// <summary>
		/// <para>Cache Location</para>
		/// <para>The folder in which the cache dataset is created, the raster layer, or the path to an existing tile cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InCacheLocation { get; set; }

		/// <summary>
		/// <para>Manage Mode</para>
		/// <para>Specifies the mode that will be used to manage the cache.</para>
		/// <para>Recreate all tiles—Existing tiles will be replaced and new tiles will be added if the extent has changed or if layers have been added to a multilayer cache.</para>
		/// <para>Recreate empty tiles—Only tiles that are empty will be created. Existing tiles will be left unchanged.</para>
		/// <para>Delete tiles—Tiles will be deleted from the cache. The cache folder structure will not be deleted.</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ManageMode { get; set; } = "RECREATE_ALL_TILES";

		/// <summary>
		/// <para>Cache Name</para>
		/// <para>The name of the cache dataset to be created in the cache location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InCacheName { get; set; }

		/// <summary>
		/// <para>Input Data Source</para>
		/// <para>A raster dataset, mosaic dataset, or map file.</para>
		/// <para>This parameter is not required when the Manage Mode parameter is set to Delete tiles.</para>
		/// <para>A map file (.mapx) cannot contain a map service or image service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InDatasource { get; set; }

		/// <summary>
		/// <para>Input Tiling Scheme</para>
		/// <para>Specifies the tiling scheme that will be used.</para>
		/// <para>ArcGIS Online scheme—The default ArcGIS Online tiling scheme will be used.</para>
		/// <para>Import scheme—An existing tiling scheme will be imported and used.</para>
		/// <para>Elevation tiling scheme—The elevation services tiling scheme will be used.</para>
		/// <para>WGS84 Version 2 tiling scheme—The WGS84 version 2 tiling scheme will be used.</para>
		/// <para>WGS84 Version 2 elevation tiling scheme— The WGS84 version 2 tiling scheme will be used to build a tile cache for elevation data.</para>
		/// <para><see cref="TilingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TilingScheme { get; set; } = "ARCGISONLINE_SCHEME";

		/// <summary>
		/// <para>Import Tiling Scheme</para>
		/// <para>The path to an existing scheme file (.xml) or to a tiling scheme imported from an existing image service or map service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ImportTilingScheme { get; set; }

		/// <summary>
		/// <para>Scales [Pixel Size] (Estimated Disk Space)</para>
		/// <para>The scale levels at which tiles will be created or deleted, depending on the value of the Manage Mode parameter. The pixel size is based on the spatial reference of the tiling scheme.</para>
		/// <para>By default, only the values for Minimum Cached Scale and Maximum Cached Scale will be used.</para>
		/// <para>Altering the value of either the Minimum Cached Scale or the Maximum Cached Scale parameter will check on or off the appropriate scale values.</para>
		/// <para>Scales that are checked on and are not within the range of the Minimum Cached Scale or Maximum Cached Scale parameter values will be ignored when generating the cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Scales { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>Defines an area of interest to constrain where tiles will be created or deleted.</para>
		/// <para>It can be a feature class, or it can be a feature set that you interactively define.</para>
		/// <para>This parameter is useful if you want to manage tiles for irregularly shaped areas. It&apos;s also useful when you want to precache some areas and leave less-visited areas uncached.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Maximum Source Cell Size</para>
		/// <para>The value that defines the visibility of the data source for which the cache will be generated. By default, the value is empty.</para>
		/// <para>If the value is empty, the following apply:</para>
		/// <para>For levels of cache that lie within the visibility ranges of the data source, the cache will be generated from the data source.</para>
		/// <para>For levels of cache that fall outside the visibility of the data source, the cache will be generated from the previous level of cache.</para>
		/// <para>If the value is greater than zero, the following apply:</para>
		/// <para>For levels with cell sizes smaller than or equal to the Maximum Source Cell Size (max_cell_size) value, the cache will be generated from the data source.</para>
		/// <para>For levels with cell sizes greater than the Maximum Source Cell Size (max_cell_size) value, the cache will be generated from the previous level of cache.</para>
		/// <para>The unit of the Maximum Source Cell Size value should be the same as the unit of the cell size of the source dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxCellSize { get; set; }

		/// <summary>
		/// <para>Minimum Cached Scale</para>
		/// <para>The minimum scale at which tiles will be created. This value does not have to be the smallest scale in the tiling scheme. The minimum cache scale will determine which scales are used when generating cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object? MinCachedScale { get; set; }

		/// <summary>
		/// <para>Maximum Cached Scale</para>
		/// <para>The maximum scale at which tiles will be created. This does not have to be the largest scale in the tiling scheme. The maximum cache scale will determine which scales are used when generating cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object? MaxCachedScale { get; set; }

		/// <summary>
		/// <para>Cache Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutCacheLocation { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageTileCache SetEnviroment(object? parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Manage Mode</para>
		/// </summary>
		public enum ManageModeEnum 
		{
			/// <summary>
			/// <para>Recreate all tiles—Existing tiles will be replaced and new tiles will be added if the extent has changed or if layers have been added to a multilayer cache.</para>
			/// </summary>
			[GPValue("RECREATE_ALL_TILES")]
			[Description("Recreate all tiles")]
			Recreate_all_tiles,

			/// <summary>
			/// <para>Recreate empty tiles—Only tiles that are empty will be created. Existing tiles will be left unchanged.</para>
			/// </summary>
			[GPValue("RECREATE_EMPTY_TILES")]
			[Description("Recreate empty tiles")]
			Recreate_empty_tiles,

			/// <summary>
			/// <para>Delete tiles—Tiles will be deleted from the cache. The cache folder structure will not be deleted.</para>
			/// </summary>
			[GPValue("DELETE_TILES")]
			[Description("Delete tiles")]
			Delete_tiles,

		}

		/// <summary>
		/// <para>Input Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeEnum 
		{
			/// <summary>
			/// <para>ArcGIS Online scheme—The default ArcGIS Online tiling scheme will be used.</para>
			/// </summary>
			[GPValue("ARCGISONLINE_SCHEME")]
			[Description("ArcGIS Online scheme")]
			ArcGIS_Online_scheme,

			/// <summary>
			/// <para>Elevation tiling scheme—The elevation services tiling scheme will be used.</para>
			/// </summary>
			[GPValue("ARCGISONLINE_ELEVATION_SCHEME")]
			[Description("Elevation tiling scheme")]
			Elevation_tiling_scheme,

			/// <summary>
			/// <para>WGS84 Version 2 tiling scheme—The WGS84 version 2 tiling scheme will be used.</para>
			/// </summary>
			[GPValue("WGS84_V2_SCHEME")]
			[Description("WGS84 Version 2 tiling scheme")]
			WGS84_Version_2_tiling_scheme,

			/// <summary>
			/// <para>WGS84 Version 2 elevation tiling scheme— The WGS84 version 2 tiling scheme will be used to build a tile cache for elevation data.</para>
			/// </summary>
			[GPValue("WGS84_V2_ELEVATION_SCHEME")]
			[Description("WGS84 Version 2 elevation tiling scheme")]
			WGS84_Version_2_elevation_tiling_scheme,

			/// <summary>
			/// <para>Import scheme—An existing tiling scheme will be imported and used.</para>
			/// </summary>
			[GPValue("IMPORT_SCHEME")]
			[Description("Import scheme")]
			Import_scheme,

		}

#endregion
	}
}
