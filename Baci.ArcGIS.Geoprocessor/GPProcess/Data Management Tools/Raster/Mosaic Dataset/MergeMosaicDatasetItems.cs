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
	/// <para>Merge Mosaic Dataset Items</para>
	/// <para>合并镶嵌数据集项目</para>
	/// <para>将镶嵌数据集中的多个项目分组为一个项目。</para>
	/// </summary>
	public class MergeMosaicDatasetItems : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要合并的项目所在的镶嵌数据集。</para>
		/// </param>
		public MergeMosaicDatasetItems(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并镶嵌数据集项目</para>
		/// </summary>
		public override string DisplayName() => "合并镶嵌数据集项目";

		/// <summary>
		/// <para>Tool Name : MergeMosaicDatasetItems</para>
		/// </summary>
		public override string ToolName() => "MergeMosaicDatasetItems";

		/// <summary>
		/// <para>Tool Excute Name : management.MergeMosaicDatasetItems</para>
		/// </summary>
		public override string ExcuteName() => "management.MergeMosaicDatasetItems";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause!, BlockField!, MaxRowsPerMergedItems!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>想要合并的项目所在的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中选择要合并的特定栅格的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Block Field</para>
		/// <para>属性表中希望用于对图像进行分组的字段。只能将日期、数值和字符串字段指定为块字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID")]
		[Category("Advanced Options")]
		public object? BlockField { get; set; }

		/// <summary>
		/// <para>Maximum Allowed Rows Per Merged Item</para>
		/// <para>限制要合并的项目数。如果超出最大值，该工具将创建多个合并项目。默认值为 1000 行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object? MaxRowsPerMergedItems { get; set; } = "1000";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

	}
}
