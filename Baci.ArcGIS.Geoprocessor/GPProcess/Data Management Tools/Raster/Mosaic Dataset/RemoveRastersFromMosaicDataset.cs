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
	/// <para>Removes selected raster datasets from a mosaic dataset.</para>
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
		/// <para>The mosaic dataset containing the rasters you want to remove</para>
		/// </param>
		public RemoveRastersFromMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Rasters From Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName => "Remove Rasters From Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : RemoveRastersFromMosaicDataset</para>
		/// </summary>
		public override string ToolName => "RemoveRastersFromMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveRastersFromMosaicDataset</para>
		/// </summary>
		public override string ExcuteName => "management.RemoveRastersFromMosaicDataset";

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
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, WhereClause, UpdateBoundary, MarkOverviewsItems, DeleteOverviewImages, DeleteItemCache, RemoveItems, UpdateCellsizeRanges, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset containing the rasters you want to remove</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select the raster datasets that you want removed from the mosaic dataset.</para>
		/// <para>There must be a selection or a query specified; otherwise, the tool will not run. If you want to delete all the records from the mosaic dataset, specify a query that would select all the rasters, such as &quot;OBJECTID&gt;=0&quot;.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>Updates the boundary polygon of a mosaic dataset. By default, the boundary merges all the footprint polygons to create a single boundary representing the extent of the valid pixels.</para>
		/// <para>Checked—The boundary will be updated. This is the default.</para>
		/// <para>Unchecked—The boundary will not be updated.</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Mark Affected Overviews</para>
		/// <para>When the rasters in a mosaic catalog have been removed, any overviews created using those rasters may no longer be accurate; therefore, they can be identified so they can be updated or removed if they are no longer needed.</para>
		/// <para>Checked—The affected overviews will be identified. This is the default.</para>
		/// <para>Unchecked—The affected overviews will not be identified.</para>
		/// <para><see cref="MarkOverviewsItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object MarkOverviewsItems { get; set; } = "true";

		/// <summary>
		/// <para>Delete Overview Images</para>
		/// <para>Remove overviews associated with the selected rasters.</para>
		/// <para>Checked—Delete overviews associated with the selected rasters. This is the default.</para>
		/// <para>Unchecked—Do not delete the overviews associated with the selected rasters.</para>
		/// <para><see cref="DeleteOverviewImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteOverviewImages { get; set; } = "true";

		/// <summary>
		/// <para>Delete Item Cache</para>
		/// <para>Remove cache that is based on any source raster datasets that you are removing from the mosaic dataset.</para>
		/// <para>Checked—Remove the item and its corresponding cache. This is the default.</para>
		/// <para>Unchecked—Keep the cache as part of the mosaic dataset.</para>
		/// <para><see cref="DeleteItemCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteItemCache { get; set; } = "true";

		/// <summary>
		/// <para>Remove Mosaic Dataset Items</para>
		/// <para>Remove item, cache, overviews, and raster datasets. Or, remove only the cache and overviews, and keep the raster datasets.</para>
		/// <para>Checked—Remove the item from the mosaic dataset. This is the default.</para>
		/// <para>Unchecked—Remove the item cache and any associated overviews, but not the item itself.</para>
		/// <para><see cref="RemoveItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object RemoveItems { get; set; } = "true";

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// <para>Update cell size ranges for the mosaic dataset. Choose this option if you are removing all of the imagery at a specific cell size.</para>
		/// <para>Checked—Update the cell size ranges. This is the default.</para>
		/// <para>Unchecked—Do not update the cell size ranges.</para>
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
		public RemoveRastersFromMosaicDataset SetEnviroment(object extent = null )
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
			/// <para>Checked—The boundary will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para>Unchecked—The boundary will not be updated.</para>
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
			/// <para>Checked—The affected overviews will be identified. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MARK_OVERVIEW_ITEMS")]
			MARK_OVERVIEW_ITEMS,

			/// <summary>
			/// <para>Unchecked—The affected overviews will not be identified.</para>
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
			/// <para>Checked—Delete overviews associated with the selected rasters. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_OVERVIEW_IMAGES")]
			DELETE_OVERVIEW_IMAGES,

			/// <summary>
			/// <para>Unchecked—Do not delete the overviews associated with the selected rasters.</para>
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
			/// <para>Checked—Remove the item and its corresponding cache. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_ITEM_CACHE")]
			DELETE_ITEM_CACHE,

			/// <summary>
			/// <para>Unchecked—Keep the cache as part of the mosaic dataset.</para>
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
			/// <para>Checked—Remove the item from the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_MOSAICDATASET_ITEMS")]
			REMOVE_MOSAICDATASET_ITEMS,

			/// <summary>
			/// <para>Unchecked—Remove the item cache and any associated overviews, but not the item itself.</para>
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
			/// <para>Checked—Update the cell size ranges. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_CELL_SIZES")]
			UPDATE_CELL_SIZES,

			/// <summary>
			/// <para>Unchecked—Do not update the cell size ranges.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CELL_SIZES")]
			NO_CELL_SIZES,

		}

#endregion
	}
}
