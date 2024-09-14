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
	/// <para>Merge Mosaic Dataset Items</para>
	/// <para>Groups multiple items in a mosaic dataset together as one item.</para>
	/// </summary>
	public class MergeMosaicDatasetItems : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that has the items that you want to merge.</para>
		/// </param>
		public MergeMosaicDatasetItems(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Mosaic Dataset Items</para>
		/// </summary>
		public override string DisplayName() => "Merge Mosaic Dataset Items";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, BlockField, MaxRowsPerMergedItems, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that has the items that you want to merge.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select specific rasters to merge in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Block Field</para>
		/// <para>The field in the attribute table that you want to use to group images. Only date, numeric, and string fields can be specified as Block fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID")]
		[Category("Advanced Options")]
		public object BlockField { get; set; }

		/// <summary>
		/// <para>Maximum Allowed Rows Per Merged Item</para>
		/// <para>Limits the number of items to merge. If the maximum is exceeded, the tool will create multiple merged items. The default is 1,000 rows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object MaxRowsPerMergedItems { get; set; } = "1000";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

	}
}
