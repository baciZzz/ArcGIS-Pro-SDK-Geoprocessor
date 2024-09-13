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
	/// <para>Delete Mosaic Dataset</para>
	/// <para>Delete Mosaic Dataset</para>
	/// <para>Deletes a mosaic dataset, its overviews, and its item cache from disk.</para>
	/// </summary>
	public class DeleteMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to delete.</para>
		/// </param>
		public DeleteMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName() => "Delete Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : DeleteMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "DeleteMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, DeleteOverviewImages!, DeleteItemCache!, OutResults! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Delete Overview Images</para>
		/// <para>Deletes all overviews associated with the mosaic dataset.</para>
		/// <para>Checked—Delete the overviews associated with the mosaic dataset. This is the default.</para>
		/// <para>Unchecked—Do not delete the overviews.</para>
		/// <para><see cref="DeleteOverviewImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteOverviewImages { get; set; } = "true";

		/// <summary>
		/// <para>Delete Item Cache</para>
		/// <para>Delete the item cache associated with the mosaic dataset.</para>
		/// <para>Checked—Delete the item cache associated with the mosaic dataset. This is the default.</para>
		/// <para>Unchecked—Do not delete the item cache.</para>
		/// <para><see cref="DeleteItemCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteItemCache { get; set; } = "true";

		/// <summary>
		/// <para>Delete Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? OutResults { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Delete Overview Images</para>
		/// </summary>
		public enum DeleteOverviewImagesEnum 
		{
			/// <summary>
			/// <para>Checked—Delete the overviews associated with the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_OVERVIEW_IMAGES")]
			DELETE_OVERVIEW_IMAGES,

			/// <summary>
			/// <para>Unchecked—Do not delete the overviews.</para>
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
			/// <para>Checked—Delete the item cache associated with the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_ITEM_CACHE")]
			DELETE_ITEM_CACHE,

			/// <summary>
			/// <para>Unchecked—Do not delete the item cache.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_ITEM_CACHE")]
			NO_DELETE_ITEM_CACHE,

		}

#endregion
	}
}
