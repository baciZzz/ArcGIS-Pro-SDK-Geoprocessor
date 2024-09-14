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
	/// <para>删除镶嵌数据集</para>
	/// <para>从磁盘删除镶嵌数据集、其概视图和其项目缓存。</para>
	/// </summary>
	public class DeleteMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要删除的镶嵌数据集。</para>
		/// </param>
		public DeleteMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "删除镶嵌数据集";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, DeleteOverviewImages!, DeleteItemCache!, OutResults! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>想要删除的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Delete Overview Images</para>
		/// <para>删除所有与镶嵌数据集相关的概视图。</para>
		/// <para>选中 - 删除与镶嵌数据集相关的概视图。这是默认设置。</para>
		/// <para>未选中 - 不会删除这些概视图。</para>
		/// <para><see cref="DeleteOverviewImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteOverviewImages { get; set; } = "true";

		/// <summary>
		/// <para>Delete Item Cache</para>
		/// <para>删除与镶嵌数据集相关的项目缓存。</para>
		/// <para>选中 - 删除与镶嵌数据集相关的项目缓存。这是默认设置。</para>
		/// <para>未选中 - 不会删除这些项目缓存。</para>
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

#endregion
	}
}
