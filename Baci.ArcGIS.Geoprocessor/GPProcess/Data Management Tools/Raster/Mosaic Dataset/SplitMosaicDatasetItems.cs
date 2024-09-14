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
	/// <para>Split Mosaic Dataset Items</para>
	/// <para>分割镶嵌数据集项目</para>
	/// <para>对使用合并镶嵌数据集项目合并在一起的镶嵌数据集项目进行分割。</para>
	/// </summary>
	public class SplitMosaicDatasetItems : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>包含要分割的项目的镶嵌数据集。</para>
		/// </param>
		public SplitMosaicDatasetItems(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 分割镶嵌数据集项目</para>
		/// </summary>
		public override string DisplayName() => "分割镶嵌数据集项目";

		/// <summary>
		/// <para>Tool Name : SplitMosaicDatasetItems</para>
		/// </summary>
		public override string ToolName() => "SplitMosaicDatasetItems";

		/// <summary>
		/// <para>Tool Excute Name : management.SplitMosaicDatasetItems</para>
		/// </summary>
		public override string ExcuteName() => "management.SplitMosaicDatasetItems";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>包含要分割的项目的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于选择要分割项目的 SQL 表达式。</para>
		/// <para>如果查询未包含先前合并的任何项目，则该工具将返回错误。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

	}
}
