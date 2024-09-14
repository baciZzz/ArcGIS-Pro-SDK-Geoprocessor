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
	/// <para>Remove Rasters From Mosaic Dataset</para>
	/// <para>从镶嵌数据集中移除栅格</para>
	/// <para>从镶嵌数据集中移除选定栅格数据集。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveRastersFromMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>包含要移除的栅格的镶嵌数据集</para>
		/// </param>
		public RemoveRastersFromMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 从镶嵌数据集中移除栅格</para>
		/// </summary>
		public override string DisplayName() => "从镶嵌数据集中移除栅格";

		/// <summary>
		/// <para>Tool Name : RemoveRastersFromMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "RemoveRastersFromMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveRastersFromMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveRastersFromMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, UpdateBoundary, MarkOverviewsItems, DeleteOverviewImages, DeleteItemCache, RemoveItems, UpdateCellsizeRanges, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>包含要移除的栅格的镶嵌数据集</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>SQL 表达式将选择要从镶嵌数据集中移除的栅格数据集。</para>
		/// <para>必须指定选择或查询，否则此工具不会运行。如果要从镶嵌数据集中删除所有记录，请指定一个用于选择所有栅格的查询，例如 &quot;OBJECTID&gt;=0&quot;。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>更新镶嵌数据集的边界面。默认情况下，边界会合并所有轮廓线面以创建一个表示有效像素范围的边界。</para>
		/// <para>选中 - 将更新边界。这是默认设置。</para>
		/// <para>取消选中 - 不更新边界。</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Mark Affected Overviews</para>
		/// <para>镶嵌目录中的栅格被移除后，任何使用这些栅格创建的金字塔可能都不再准确，因此，可将其识别出来以便更新，如果不再需要这些金字塔，也可以将其移除。</para>
		/// <para>选中 - 识别受影响的概视图。这是默认设置。</para>
		/// <para>取消选中 - 不识别受影响的概视图。</para>
		/// <para><see cref="MarkOverviewsItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object MarkOverviewsItems { get; set; } = "true";

		/// <summary>
		/// <para>Delete Overview Images</para>
		/// <para>移除与所选栅格相关的概视图。</para>
		/// <para>选中 - 删除与所选栅格相关的概视图。这是默认设置。</para>
		/// <para>取消选中 - 不删除与所选栅格相关的概视图。</para>
		/// <para><see cref="DeleteOverviewImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteOverviewImages { get; set; } = "true";

		/// <summary>
		/// <para>Delete Item Cache</para>
		/// <para>将基于任何要从镶嵌数据集中移除的源栅格数据集移除缓存。</para>
		/// <para>选中 - 移除项目及其相应缓存。这是默认设置。</para>
		/// <para>取消选中 - 将缓存保留为镶嵌数据集的一部分。</para>
		/// <para><see cref="DeleteItemCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteItemCache { get; set; } = "true";

		/// <summary>
		/// <para>Remove Mosaic Dataset Items</para>
		/// <para>移除项目、缓存、概视图和栅格数据集。或仅移除缓存和概视图，并保留栅格数据集。</para>
		/// <para>选中 - 从镶嵌数据集中移除项目。这是默认设置。</para>
		/// <para>取消选中 - 移除项目缓存和任何相关概视图，而不是项目本身。</para>
		/// <para><see cref="RemoveItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object RemoveItems { get; set; } = "true";

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// <para>更新镶嵌数据集的像元大小范围。如果要移除所有具有特定像元大小的图像，请选择此选项。</para>
		/// <para>选中 - 更新像元大小范围。这是默认设置。</para>
		/// <para>取消选中 - 不更新像元大小范围。</para>
		/// <para><see cref="UpdateCellsizeRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object UpdateCellsizeRanges { get; set; } = "true";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveRastersFromMosaicDataset SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

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
		/// <para>Mark Affected Overviews</para>
		/// </summary>
		public enum MarkOverviewsItemsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MARK_OVERVIEW_ITEMS")]
			MARK_OVERVIEW_ITEMS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MARK_OVERVIEW_ITEMS")]
			NO_MARK_OVERVIEW_ITEMS,

		}

		/// <summary>
		/// <para>Delete Overview Images</para>
		/// </summary>
		public enum DeleteOverviewImagesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_OVERVIEW_IMAGES")]
			DELETE_OVERVIEW_IMAGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_OVERVIEW_IMAGES")]
			NO_DELETE_OVERVIEW_IMAGES,

		}

		/// <summary>
		/// <para>Delete Item Cache</para>
		/// </summary>
		public enum DeleteItemCacheEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_ITEM_CACHE")]
			DELETE_ITEM_CACHE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_ITEM_CACHE")]
			NO_DELETE_ITEM_CACHE,

		}

		/// <summary>
		/// <para>Remove Mosaic Dataset Items</para>
		/// </summary>
		public enum RemoveItemsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_MOSAICDATASET_ITEMS")]
			REMOVE_MOSAICDATASET_ITEMS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REMOVE_MOSAICDATASET_ITEMS")]
			NO_REMOVE_MOSAICDATASET_ITEMS,

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

#endregion
	}
}
