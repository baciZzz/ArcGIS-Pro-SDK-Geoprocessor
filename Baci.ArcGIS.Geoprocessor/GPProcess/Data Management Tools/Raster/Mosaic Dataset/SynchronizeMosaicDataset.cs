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
	/// <para>Synchronize Mosaic Dataset</para>
	/// <para>Keeps your mosaic dataset up to date. In addition to syncing data, you can update overviews if the underlying imagery has been changed, generate new overviews and cache, and restore the original configuration of mosaic dataset items. You can also remove paths to source data with this tool. To repair paths, you need to use the Repair Mosaic Dataset Paths  tool.</para>
	/// </summary>
	public class SynchronizeMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset you want to synchronize.</para>
		/// </param>
		public SynchronizeMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Synchronize Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName() => "Synchronize Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : SynchronizeMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "SynchronizeMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.SynchronizeMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.SynchronizeMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "rasterStatistics" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, NewItems, SyncOnlyStale, UpdateCellsizeRanges, UpdateBoundary, UpdateOverviews, BuildPyramids, CalculateStatistics, BuildThumbnails, BuildItemCache, RebuildRaster, UpdateFields, FieldsToUpdate, ExistingItems, BrokenItems, SkipExistingItems, RefreshAggregateInfo, EstimateStatistics, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset you want to synchronize.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select which mosaic dataset items will be synchronized. If an expression is not provided, all dataset items will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Update With New Items</para>
		/// <para>Choose whether to include new items when synchronizing and specify which options to use under the Update With New Items Options submenu. If you choose to use this option, the item&apos;s workspace will be searched for new data. When data is added to the mosaic dataset, it will use the same raster type as the other items in the same workspace.</para>
		/// <para>Unchecked—New items will not be added when synchronizing. This is the default.</para>
		/// <para>Checked—Update the mosaic dataset with new items in the workspaces. Optionally, you can modify the existing items by not choosing the Skip Existing Items parameter.</para>
		/// <para><see cref="NewItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object NewItems { get; set; } = "false";

		/// <summary>
		/// <para>Synchronize Stale Items Only</para>
		/// <para>Choose whether to update mosaic dataset items where the underlying raster datasets have been modified due to synchronizing. For example, building pyramids or updating the georeferencing of rasters will affect how the overviews are rendered.</para>
		/// <para>Checked—Only update the items where the underlying raster datasets have been modified. This is the default.</para>
		/// <para>Unchecked—Update all of the items in the mosaic dataset.</para>
		/// <para><see cref="SyncOnlyStaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object SyncOnlyStale { get; set; } = "true";

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// <para>Update cell size ranges for the mosaic dataset.</para>
		/// <para>Checked—Recalculate the cell size ranges for the entire mosaic dataset but only for items that have an invalid visibility. This is the default.</para>
		/// <para>Unchecked—Do not recalculate the cell size ranges.</para>
		/// <para><see cref="UpdateCellsizeRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object UpdateCellsizeRanges { get; set; } = "true";

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>Update the polygon that shows the full extent of the mosaic dataset. Choose this option if syncing will change the extent of the mosaic dataset.</para>
		/// <para>Checked—The boundary will be rebuilt after the mosaic dataset is synchronized. This is the default.</para>
		/// <para>Unchecked—The boundary will not be rebuilt.</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Update Overviews</para>
		/// <para>Choose whether to update any obsolete overviews. The overview becomes obsolete if any underlying rasters have been modified due to synchronizing.</para>
		/// <para>Unchecked—The overviews will not be rebuilt. This is the default.</para>
		/// <para>Checked—The affected overviews will be rebuilt after the mosaic dataset is synchronized.</para>
		/// <para><see cref="UpdateOverviewsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object UpdateOverviews { get; set; } = "false";

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// <para>Choose whether to build pyramids for the specified mosaic dataset items. Pyramids can be built for each raster item in the mosaic dataset. Pyramids can improve the speed at which each raster is displayed.</para>
		/// <para>Unchecked—Pyramids will not be generated. This is the default.</para>
		/// <para>Checked—Pyramids will be generated for all the mosaic raster items that were updated due to synchronization.</para>
		/// <para>Pyramids will not be built for items that were added due to synchronization.</para>
		/// <para><see cref="BuildPyramidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object BuildPyramids { get; set; } = "false";

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// <para>Choose whether to calculate statistics for the specified mosaic dataset items. Statistics are required for your mosaic dataset when performing certain tasks, such as applying a contrast stretch.</para>
		/// <para>Unchecked—Statistics will not be calculated. This is the default.</para>
		/// <para>Checked—Statistics will be calculated for the mosaic dataset items that were updated due to synchronization.</para>
		/// <para>Statistics will not be calculated for items that were added due to synchronization.</para>
		/// <para><see cref="CalculateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object CalculateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// <para>Choose whether to build thumbnails for the specified mosaic dataset items. Thumbnails are small, highly resampled images that can be created for each raster item in the mosaic definition. Thumbnails can be accessed when the mosaic dataset is accessed as an image service and will display as part of the item description.</para>
		/// <para>Unchecked—No thumbnails will be created or updated. This is the default.</para>
		/// <para>Checked—Thumbnails will be generated or updated for all the raster items that were updated due to synchronization.</para>
		/// <para>Thumbnails will not be built for items that were added due to synchronization.</para>
		/// <para><see cref="BuildThumbnailsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object BuildThumbnails { get; set; } = "false";

		/// <summary>
		/// <para>Build Item Cache</para>
		/// <para>Choose whether to build a cache for the specified mosaic dataset items. A cache can be created when you&apos;ve added data using the LAS, Terrain, or LAS dataset raster types.</para>
		/// <para>For more information about building cache for LAS, Terrain, or LAS Datasets, see Adding lidar data to a mosaic dataset.</para>
		/// <para>Unchecked—No cache will be created or updated. This is the default.</para>
		/// <para>Checked—The cache will be generated or updated for all the raster items specified by this tool.</para>
		/// <para>The cache will not be built for items that were added due to synchronization.</para>
		/// <para><see cref="BuildItemCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object BuildItemCache { get; set; } = "false";

		/// <summary>
		/// <para>Rebuild Raster From Data Source</para>
		/// <para>Choose whether to rebuild the raster items from the data source using the original raster type.</para>
		/// <para>Checked—Rebuild the rasters from the source data. You will lose any changes that you have performed on the mosaic dataset. This is the default.</para>
		/// <para>Unchecked—Do not rebuild the rasters. Other primary fields are reset if Update Fields is checked.</para>
		/// <para>This will only affect items that will be synchronized. This parameter is not applicable if Update With New Items has been checked on.</para>
		/// <para><see cref="RebuildRasterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object RebuildRaster { get; set; } = "true";

		/// <summary>
		/// <para>Update Fields</para>
		/// <para>Choose whether to update the fields in the table. This will only affect items that will be synchronized.</para>
		/// <para>Checked—Update the fields from the source files. This is the default.</para>
		/// <para>Unchecked—Do not reset the fields in the table from the source.</para>
		/// <para>If you choose to update the fields, you can control which fields are updated by selecting them in the Fields To Update parameter. If you made edits to some of the fields, you may want to unselect them in the Fields To Update parameter.</para>
		/// <para><see cref="UpdateFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object UpdateFields { get; set; } = "true";

		/// <summary>
		/// <para>Fields To Update</para>
		/// <para>Choose which fields should be updated.</para>
		/// <para>This parameter is only valid if Update Fields is checked.</para>
		/// <para>If you made edits to some of the fields, you may want to unselect them.</para>
		/// <para>The RASTER field can be refreshed, even if the Rebuild Raster From Data Source check box is unchecked. However, if Rebuild Raster From Data Source is checked, the RASTER field is rebuilt, even if this option is unchecked here.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Update Existing Item Options")]
		public object FieldsToUpdate { get; set; }

		/// <summary>
		/// <para>Update Existing Items</para>
		/// <para>Choose whether to update existing items in your mosaic dataset. If you choose this option, you need to specify which options to update in Update Existing Items Options.</para>
		/// <para>Checked—Existing items will be updated with the parameters you chose to update. This is the default.</para>
		/// <para>Unchecked—Existing items will not be updated.</para>
		/// <para><see cref="ExistingItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExistingItems { get; set; } = "true";

		/// <summary>
		/// <para>Remove Items With Broken Data Source</para>
		/// <para>Choose whether to remove any broken links.</para>
		/// <para>Make sure that all your network connections are working properly—this tool will remove any items that cannot be accessed.</para>
		/// <para>Unchecked—Items that have broken links will not be removed from the mosaic dataset. This is the default.</para>
		/// <para>Checked—Items that have broken links will be removed from the mosaic dataset.</para>
		/// <para><see cref="BrokenItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BrokenItems { get; set; } = "false";

		/// <summary>
		/// <para>Skip Existing Items</para>
		/// <para>If the Update With New Items option is checked on, you can also choose whether to skip or update existing mosaic dataset items with the modified files from disk.</para>
		/// <para>Checked—While adding new mosaic dataset items, the tool will not update existing mosaic dataset items. This is the default.</para>
		/// <para>Unchecked—While adding new mosaic dataset items, the tool will update mosaic dataset items that correspond to modified files on disk.</para>
		/// <para><see cref="SkipExistingItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update With New Item Options")]
		public object SkipExistingItems { get; set; } = "true";

		/// <summary>
		/// <para>Refresh Aggregate Information</para>
		/// <para>Choose whether to include data that may have been removed from the mosaic dataset.</para>
		/// <para>Unchecked—When synchronizing, do not include any rasters that may have been removed from the mosaic dataset. This is the default.</para>
		/// <para>Checked—When synchronizing, include rasters that may have been removed from the mosaic dataset. To use the Refresh Aggregate Information parameter, theUpdate Existing Items must be unchecked.</para>
		/// <para><see cref="RefreshAggregateInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RefreshAggregateInfo { get; set; } = "false";

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// <para>Choose whether to estimate statistics on the mosaic dataset.</para>
		/// <para>Unchecked—When synchronizing, do not estimate statistics on the mosaic dataset. This is the default.</para>
		/// <para>Checked—When synchronizing, estimate statistics on the mosaic dataset.</para>
		/// <para><see cref="EstimateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object EstimateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SynchronizeMosaicDataset SetEnviroment(object parallelProcessingFactor = null , object rasterStatistics = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, rasterStatistics: rasterStatistics);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update With New Items</para>
		/// </summary>
		public enum NewItemsEnum 
		{
			/// <summary>
			/// <para>Checked—Update the mosaic dataset with new items in the workspaces. Optionally, you can modify the existing items by not choosing the Skip Existing Items parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_WITH_NEW_ITEMS")]
			UPDATE_WITH_NEW_ITEMS,

			/// <summary>
			/// <para>Unchecked—New items will not be added when synchronizing. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_NEW_ITEMS")]
			NO_NEW_ITEMS,

		}

		/// <summary>
		/// <para>Synchronize Stale Items Only</para>
		/// </summary>
		public enum SyncOnlyStaleEnum 
		{
			/// <summary>
			/// <para>Checked—Only update the items where the underlying raster datasets have been modified. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SYNC_STALE")]
			SYNC_STALE,

			/// <summary>
			/// <para>Unchecked—Update all of the items in the mosaic dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SYNC_ALL")]
			SYNC_ALL,

		}

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// </summary>
		public enum UpdateCellsizeRangesEnum 
		{
			/// <summary>
			/// <para>Checked—Recalculate the cell size ranges for the entire mosaic dataset but only for items that have an invalid visibility. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_CELL_SIZES")]
			UPDATE_CELL_SIZES,

			/// <summary>
			/// <para>Unchecked—Do not recalculate the cell size ranges.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CELL_SIZES")]
			NO_CELL_SIZES,

		}

		/// <summary>
		/// <para>Update Boundary</para>
		/// </summary>
		public enum UpdateBoundaryEnum 
		{
			/// <summary>
			/// <para>Checked—The boundary will be rebuilt after the mosaic dataset is synchronized. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para>Unchecked—The boundary will not be rebuilt.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

		/// <summary>
		/// <para>Update Overviews</para>
		/// </summary>
		public enum UpdateOverviewsEnum 
		{
			/// <summary>
			/// <para>Checked—The affected overviews will be rebuilt after the mosaic dataset is synchronized.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_OVERVIEWS")]
			UPDATE_OVERVIEWS,

			/// <summary>
			/// <para>Unchecked—The overviews will not be rebuilt. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERVIEWS")]
			NO_OVERVIEWS,

		}

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// </summary>
		public enum BuildPyramidsEnum 
		{
			/// <summary>
			/// <para>Checked—Pyramids will be generated for all the mosaic raster items that were updated due to synchronization.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_PYRAMIDS")]
			BUILD_PYRAMIDS,

			/// <summary>
			/// <para>Unchecked—Pyramids will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PYRAMIDS")]
			NO_PYRAMIDS,

		}

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// </summary>
		public enum CalculateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be calculated for the mosaic dataset items that were updated due to synchronization.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CALCULATE_STATISTICS")]
			CALCULATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be calculated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// </summary>
		public enum BuildThumbnailsEnum 
		{
			/// <summary>
			/// <para>Checked—Thumbnails will be generated or updated for all the raster items that were updated due to synchronization.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_THUMBNAILS")]
			BUILD_THUMBNAILS,

			/// <summary>
			/// <para>Unchecked—No thumbnails will be created or updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_THUMBNAILS")]
			NO_THUMBNAILS,

		}

		/// <summary>
		/// <para>Build Item Cache</para>
		/// </summary>
		public enum BuildItemCacheEnum 
		{
			/// <summary>
			/// <para>Checked—The cache will be generated or updated for all the raster items specified by this tool.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_ITEM_CACHE")]
			BUILD_ITEM_CACHE,

			/// <summary>
			/// <para>Unchecked—No cache will be created or updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ITEM_CACHE")]
			NO_ITEM_CACHE,

		}

		/// <summary>
		/// <para>Rebuild Raster From Data Source</para>
		/// </summary>
		public enum RebuildRasterEnum 
		{
			/// <summary>
			/// <para>Checked—Rebuild the rasters from the source data. You will lose any changes that you have performed on the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REBUILD_RASTER")]
			REBUILD_RASTER,

			/// <summary>
			/// <para>Unchecked—Do not rebuild the rasters. Other primary fields are reset if Update Fields is checked.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RASTER")]
			NO_RASTER,

		}

		/// <summary>
		/// <para>Update Fields</para>
		/// </summary>
		public enum UpdateFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Update the fields from the source files. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_FIELDS")]
			UPDATE_FIELDS,

			/// <summary>
			/// <para>Unchecked—Do not reset the fields in the table from the source.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELDS")]
			NO_FIELDS,

		}

		/// <summary>
		/// <para>Update Existing Items</para>
		/// </summary>
		public enum ExistingItemsEnum 
		{
			/// <summary>
			/// <para>Checked—Existing items will be updated with the parameters you chose to update. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_EXISTING_ITEMS")]
			UPDATE_EXISTING_ITEMS,

			/// <summary>
			/// <para>Unchecked—Existing items will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_EXISTING_ITEMS")]
			IGNORE_EXISTING_ITEMS,

		}

		/// <summary>
		/// <para>Remove Items With Broken Data Source</para>
		/// </summary>
		public enum BrokenItemsEnum 
		{
			/// <summary>
			/// <para>Checked—Items that have broken links will be removed from the mosaic dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_BROKEN_ITEMS")]
			REMOVE_BROKEN_ITEMS,

			/// <summary>
			/// <para>Unchecked—Items that have broken links will not be removed from the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_BROKEN_ITEMS")]
			IGNORE_BROKEN_ITEMS,

		}

		/// <summary>
		/// <para>Skip Existing Items</para>
		/// </summary>
		public enum SkipExistingItemsEnum 
		{
			/// <summary>
			/// <para>Checked—While adding new mosaic dataset items, the tool will not update existing mosaic dataset items. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING_ITEMS")]
			SKIP_EXISTING_ITEMS,

			/// <summary>
			/// <para>Unchecked—While adding new mosaic dataset items, the tool will update mosaic dataset items that correspond to modified files on disk.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE_EXISTING_ITEMS")]
			OVERWRITE_EXISTING_ITEMS,

		}

		/// <summary>
		/// <para>Refresh Aggregate Information</para>
		/// </summary>
		public enum RefreshAggregateInfoEnum 
		{
			/// <summary>
			/// <para>Checked—When synchronizing, include rasters that may have been removed from the mosaic dataset. To use the Refresh Aggregate Information parameter, theUpdate Existing Items must be unchecked.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REFRESH_INFO")]
			REFRESH_INFO,

			/// <summary>
			/// <para>Unchecked—When synchronizing, do not include any rasters that may have been removed from the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REFRESH_INFO")]
			NO_REFRESH_INFO,

		}

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// </summary>
		public enum EstimateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—When synchronizing, estimate statistics on the mosaic dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE_STATISTICS")]
			ESTIMATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—When synchronizing, do not estimate statistics on the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

#endregion
	}
}
