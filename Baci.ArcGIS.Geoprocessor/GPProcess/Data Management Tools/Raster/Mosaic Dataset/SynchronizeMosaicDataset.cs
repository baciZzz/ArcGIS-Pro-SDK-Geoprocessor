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
	/// <para>同步镶嵌数据集</para>
	/// <para>使镶嵌数据集保持最新状态。除同步数据外，还可更新概视图（如果基础影像发生更改）、生成新的概视图和缓存以及恢复镶嵌数据集项目的原始配置。您也可使用此工具移除源数据的路径。要修复路径，需使用修复镶嵌数据集路径工具。</para>
	/// </summary>
	public class SynchronizeMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要同步的镶嵌数据集。</para>
		/// </param>
		public SynchronizeMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 同步镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "同步镶嵌数据集";

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
		/// <para>想要同步的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于选择要同步的镶嵌数据集项目的 SQL 表达式。如果不提供表达式，将更新所有数据集项目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Update With New Items</para>
		/// <para>选择同步时是否包含新项目，然后在使用新项目进行更新选项子菜单下指定要使用的选项。如果选择使用此选项，则将为新数据搜索项目的工作空间。当数据添加到镶嵌数据集后，其使用的栅格类型将与同一工作空间内的其他项目相同。</para>
		/// <para>取消选中 - 同步时不会添加新项目。这是默认设置。</para>
		/// <para>选中 - 更新工作空间中包含新项目的镶嵌数据集。或者，可通过不选择跳过现有项目参数来更改现有项目。</para>
		/// <para><see cref="NewItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object NewItems { get; set; } = "false";

		/// <summary>
		/// <para>Synchronize Stale Items Only</para>
		/// <para>选择是否更新基础栅格数据集已因同步发生更改的镶嵌数据集项目。例如，构建金字塔或更新栅格的地理配准将影响概视图的渲染方式。</para>
		/// <para>选中 - 仅更新基础栅格数据集已被修改的项目。这是默认设置。</para>
		/// <para>未选中 - 更新镶嵌数据集中的所有项目。</para>
		/// <para><see cref="SyncOnlyStaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object SyncOnlyStale { get; set; } = "true";

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// <para>更新镶嵌数据集的像元大小范围。</para>
		/// <para>选中 - 重新计算整个镶嵌数据集的像元大小范围，但仅限可见性无效的项目。这是默认设置。</para>
		/// <para>未选中 - 不重新计算像元大小范围。</para>
		/// <para><see cref="UpdateCellsizeRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object UpdateCellsizeRanges { get; set; } = "true";

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>更新显示镶嵌数据集全图范围的面。如果同步将更改镶嵌数据集的范围，则选择此选项。</para>
		/// <para>选中 - 同步镶嵌数据集后重新构建边界。这是默认设置。</para>
		/// <para>未选中 - 不重新构建边界。</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Update Overviews</para>
		/// <para>选择是否更新所有废弃的概视图。如果有任何基础栅格因同步而发生更改，概视图则会被废弃。</para>
		/// <para>未选中 - 不重新构建概视图。这是默认设置。</para>
		/// <para>选中 - 同步镶嵌数据集后重新构建受影响的概视图。</para>
		/// <para><see cref="UpdateOverviewsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object UpdateOverviews { get; set; } = "false";

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// <para>选择是否为指定的镶嵌数据集项构建金字塔。可以为镶嵌数据集中的每个栅格项目构建金字塔。金字塔可以提高每个栅格的显示速度。</para>
		/// <para>未选中 - 不生成金字塔。这是默认设置。</para>
		/// <para>选中 - 将为因同步而更新的所有镶嵌栅格项目生成金字塔。</para>
		/// <para>不会为因同步而添加的项目构建金字塔。</para>
		/// <para><see cref="BuildPyramidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object BuildPyramids { get; set; } = "false";

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// <para>选择是否为指定的镶嵌数据集项计算统计数据。在执行某些任务时（如应用对比度拉伸），需要对镶嵌数据集进行统计。</para>
		/// <para>未选中 - 不计算统计数据。这是默认设置。</para>
		/// <para>选中 - 为因同步而更新的镶嵌数据集项目计算统计数据。</para>
		/// <para>不会为因同步而添加的项目计算统计数据。</para>
		/// <para><see cref="CalculateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object CalculateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// <para>选择是否为指定的镶嵌数据集项构建缩略图。缩略图是可为镶嵌定义中的每个栅格项目创建的较小的高度重采样图像。可在以影像服务形式访问镶嵌数据集时访问缩略图，缩略图将显示为项目描述的一部分。</para>
		/// <para>未选中 - 不创建或更新任何缩略图。这是默认设置。</para>
		/// <para>选中 - 为因同步而更新的所有栅格项目生成或更新缩略图。</para>
		/// <para>不会为因同步而添加的项目构建缩略图。</para>
		/// <para><see cref="BuildThumbnailsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object BuildThumbnails { get; set; } = "false";

		/// <summary>
		/// <para>Build Item Cache</para>
		/// <para>选择是否为指定的镶嵌数据集项构建缓存。在使用 LAS、Terrain 或 LAS 数据集栅格类型添加数据时，可以创建缓存。</para>
		/// <para>有关为 LAS、Terrain 或 LAS 数据集构建缓存的详细信息，请参阅将激光雷达数据添加到镶嵌数据集。</para>
		/// <para>未选中 - 不创建或更新任何缓存。这是默认设置。</para>
		/// <para>选中 - 为此工具指定的所有栅格项目生成或更新缓存。</para>
		/// <para>不会为因同步而添加的项目构建缓存。</para>
		/// <para><see cref="BuildItemCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object BuildItemCache { get; set; } = "false";

		/// <summary>
		/// <para>Rebuild Raster From Data Source</para>
		/// <para>选择是否使用原始栅格类型从数据源重新构建栅格项目。</para>
		/// <para>选中 - 从源数据重新构建栅格。您将失去对镶嵌数据集执行的所有更改。这是默认设置。</para>
		/// <para>未选中 - 不重新构建栅格。如果选中更新字段，则会重置其他主字段。</para>
		/// <para>此操作仅影响要同步的项目。如果选中使用新项目进行更新，则此参数不适用。</para>
		/// <para><see cref="RebuildRasterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object RebuildRaster { get; set; } = "true";

		/// <summary>
		/// <para>Update Fields</para>
		/// <para>选择是否更新表中的字段。此操作仅影响要同步的项目。</para>
		/// <para>选中 - 更新源文件中的字段。这是默认设置。</para>
		/// <para>未选中 - 不重置源文件中表内的字段。</para>
		/// <para>如果选择更新字段，则可通过在待更新字段参数中选择要更新的字段来控制它们。如果已编辑某些字段，则可能需要在待更新字段参数中对其取消选择。</para>
		/// <para><see cref="UpdateFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update Existing Item Options")]
		public object UpdateFields { get; set; } = "true";

		/// <summary>
		/// <para>Fields To Update</para>
		/// <para>选择应更新的字段。</para>
		/// <para>此参数仅在选中更新字段时才有效。</para>
		/// <para>如果已编辑某些字段，则可能需要对其取消选择。</para>
		/// <para>即使取消选中基于数据源重新构建栅格复选框，也可刷新 RASTER 字段。但是，如果已选中基于数据源重新构建栅格，那么即使此处取消选中此选项，也会重新构建 RASTER 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Update Existing Item Options")]
		public object FieldsToUpdate { get; set; }

		/// <summary>
		/// <para>Update Existing Items</para>
		/// <para>选择是否要在镶嵌数据集内更新现有项目。如果选择此选项，则需要指定要在更新现有项目选项内更新的选项。</para>
		/// <para>选中 - 使用选择更新的参数更新现有项目。这是默认设置。</para>
		/// <para>未选中 - 不更新现有项目。</para>
		/// <para><see cref="ExistingItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExistingItems { get; set; } = "true";

		/// <summary>
		/// <para>Remove Items With Broken Data Source</para>
		/// <para>选择是否要移除所有损坏的链接。</para>
		/// <para>请确保所有网络连接正常工作，因为此工具会移除无法访问的所有项目。</para>
		/// <para>未选中 - 不会从镶嵌数据集移除链接已损坏的项目。这是默认设置。</para>
		/// <para>选中 - 将从镶嵌数据集移除链接已损坏的项目。</para>
		/// <para><see cref="BrokenItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BrokenItems { get; set; } = "false";

		/// <summary>
		/// <para>Skip Existing Items</para>
		/// <para>如果选中了使用新项目进行更新选项，则还可选择是跳过现有镶嵌数据集项目，还是使用磁盘上的已修改文件对这些现有项目进行更新。</para>
		/// <para>选中 - 添加新镶嵌数据集项目时，此工具将不更新现有镶嵌数据集项目。这是默认设置。</para>
		/// <para>未选中 - 添加新镶嵌数据集项目时，此工具将更新与磁盘上的已修改文件相对应的镶嵌数据集项目。</para>
		/// <para><see cref="SkipExistingItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Update With New Item Options")]
		public object SkipExistingItems { get; set; } = "true";

		/// <summary>
		/// <para>Refresh Aggregate Information</para>
		/// <para>选择是否包含已从镶嵌数据集中移除的数据。</para>
		/// <para>未选中 - 同步时，不包含任何已从镶嵌数据集中移除的栅格。这是默认设置。</para>
		/// <para>选中 - 同步时，包含已从镶嵌数据集中移除的栅格。要使用刷新聚合信息参数，必须取消选中更新现有项目。</para>
		/// <para><see cref="RefreshAggregateInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RefreshAggregateInfo { get; set; } = "false";

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// <para>选择是否估算镶嵌数据集的统计数据。</para>
		/// <para>未选中 - 同步时不估算镶嵌数据集的统计数据。这是默认设置。</para>
		/// <para>选中 - 同步时估算镶嵌数据集的统计数据。</para>
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
		public SynchronizeMosaicDataset SetEnviroment(object parallelProcessingFactor = null, object rasterStatistics = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_WITH_NEW_ITEMS")]
			UPDATE_WITH_NEW_ITEMS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SYNC_STALE")]
			SYNC_STALE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_CELL_SIZES")]
			UPDATE_CELL_SIZES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_OVERVIEWS")]
			UPDATE_OVERVIEWS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_PYRAMIDS")]
			BUILD_PYRAMIDS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CALCULATE_STATISTICS")]
			CALCULATE_STATISTICS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_THUMBNAILS")]
			BUILD_THUMBNAILS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_ITEM_CACHE")]
			BUILD_ITEM_CACHE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REBUILD_RASTER")]
			REBUILD_RASTER,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_FIELDS")]
			UPDATE_FIELDS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_EXISTING_ITEMS")]
			UPDATE_EXISTING_ITEMS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_BROKEN_ITEMS")]
			REMOVE_BROKEN_ITEMS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING_ITEMS")]
			SKIP_EXISTING_ITEMS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REFRESH_INFO")]
			REFRESH_INFO,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE_STATISTICS")]
			ESTIMATE_STATISTICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

#endregion
	}
}
