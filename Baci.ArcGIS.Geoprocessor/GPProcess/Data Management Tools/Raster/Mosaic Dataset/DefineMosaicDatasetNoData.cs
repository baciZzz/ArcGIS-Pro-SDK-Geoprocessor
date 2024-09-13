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
	/// <para>Define Mosaic Dataset NoData</para>
	/// <para>定义镶嵌数据集 NoData</para>
	/// <para>指定要表示为 NoData 的一个或多个值。</para>
	/// </summary>
	public class DefineMosaicDatasetNoData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>希望更新 NoData 值的镶嵌数据集。</para>
		/// </param>
		/// <param name="NumBands">
		/// <para>Number of Bands</para>
		/// <para>镶嵌数据集内的波段数。</para>
		/// </param>
		public DefineMosaicDatasetNoData(object InMosaicDataset, object NumBands)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.NumBands = NumBands;
		}

		/// <summary>
		/// <para>Tool Display Name : 定义镶嵌数据集 NoData</para>
		/// </summary>
		public override string DisplayName() => "定义镶嵌数据集 NoData";

		/// <summary>
		/// <para>Tool Name : DefineMosaicDatasetNoData</para>
		/// </summary>
		public override string ToolName() => "DefineMosaicDatasetNoData";

		/// <summary>
		/// <para>Tool Excute Name : management.DefineMosaicDatasetNoData</para>
		/// </summary>
		public override string ExcuteName() => "management.DefineMosaicDatasetNoData";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, NumBands, BandsForNodataValue!, BandsForValidDataRange!, WhereClause!, CompositeNodataValue!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>希望更新 NoData 值的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>镶嵌数据集内的波段数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumBands { get; set; }

		/// <summary>
		/// <para>Bands for NoData Value</para>
		/// <para>为每个波段指定 NoData 值。每个波段都可定义唯一的 NoData 值，也可为所有波段指定相同的值。从下拉列表中选择波段，然后输入一个值或多个值。如果选择多个 NoData 值，则用空格分隔各值。</para>
		/// <para>如果镶嵌数据集内每个栅格的函数链都包含“波段合成”函数，或者如果添加的栅格数据的栅格类型会向每个栅格的函数链添加“波段合成”函数，则所有指定的值都将应用于所有波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? BandsForNodataValue { get; set; }

		/// <summary>
		/// <para>Bands For Valid Data Range</para>
		/// <para>指定为每个波段显示的值范围。会将此范围外的值划分为 NoData。处理波段合成时，该范围将应用到所有波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? BandsForValidDataRange { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中选择特定栅格的 SQL 语句。只有所选栅格的 NoData 值会更改。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Composite NoData value from each band</para>
		/// <para>选择是否所有波段必须为 NoData，才能将像素划分为 NoData。</para>
		/// <para>未选中 - 如果任一波段具有 NoData 像素，则将像素划分为 NoData。  这是默认设置。</para>
		/// <para>选中 - 所有波段必须具有 NoData 像素，才能将像素划分为 NoData。</para>
		/// <para><see cref="CompositeNodataValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompositeNodataValue { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DefineMosaicDatasetNoData SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Composite NoData value from each band</para>
		/// </summary>
		public enum CompositeNodataValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPOSITE_NODATA")]
			COMPOSITE_NODATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPOSITE_NODATA")]
			NO_COMPOSITE_NODATA,

		}

#endregion
	}
}
