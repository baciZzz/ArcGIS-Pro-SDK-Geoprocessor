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
	/// <para>Calculate Cell Size Ranges</para>
	/// <para>计算像元大小范围</para>
	/// <para>根据空间分辨率计算镶嵌数据集中栅格数据集的可见性等级。</para>
	/// </summary>
	public class CalculateCellSizeRanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>要为其计算可见性等级的镶嵌数据集。</para>
		/// </param>
		public CalculateCellSizeRanges(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算像元大小范围</para>
		/// </summary>
		public override string DisplayName() => "计算像元大小范围";

		/// <summary>
		/// <para>Tool Name : CalculateCellSizeRanges</para>
		/// </summary>
		public override string ToolName() => "CalculateCellSizeRanges";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateCellSizeRanges</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateCellSizeRanges";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause!, DoComputeMin!, DoComputeMax!, MaxRangeFactor!, CellSizeToleranceFactor!, UpdateMissingOnly!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>要为其计算可见性等级的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于在镶嵌数据集中选择要计算可见性等级的特定栅格的 SQL 表达式。如果未指定任何查询，则计算所有镶嵌数据集项目的像元尺寸范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Compute Minimum Cell Sizes</para>
		/// <para>计算镶嵌数据集中每个选定栅格数据集的最小像素大小。</para>
		/// <para>选中 - 计算最小像素大小。这是默认设置。</para>
		/// <para>未选中 - 不计算最小像素大小。</para>
		/// <para><see cref="DoComputeMinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? DoComputeMin { get; set; } = "true";

		/// <summary>
		/// <para>Compute Maximum Cell Sizes</para>
		/// <para>计算镶嵌数据集中每个选定栅格的最大像素大小。</para>
		/// <para>选中 - 计算最大像素大小。这是默认设置。</para>
		/// <para>未选中 - 不计算最大像素大小。</para>
		/// <para><see cref="DoComputeMaxEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? DoComputeMax { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Cell Size Range Factor</para>
		/// <para>设置应用于原始分辨率的倍增系数。默认值为 10，表示分辨率为 30 米的影像将在适用于 300 米的比例下可见。像元大小和比例的关系如下：</para>
		/// <para>像元大小 = 比例 * 0.0254 / 96</para>
		/// <para>比例 = 像元大小 * 96 / 0.0254</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object? MaxRangeFactor { get; set; } = "10";

		/// <summary>
		/// <para>Cell Size Tolerance Factor</para>
		/// <para>使用此系数将分辨率相似（即具有相同标称分辨率）的影像划分为一组。例如，可通过将此系数设为 0.1 将 1 m 影像和 0.9 m 影像组合在一起，因为它们之间的差距不超过各自的 10%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object? CellSizeToleranceFactor { get; set; } = "0.8";

		/// <summary>
		/// <para>Update Missing Values Only</para>
		/// <para>仅计算缺失像元大小范围的值。</para>
		/// <para>未选中 - 计算镶嵌数据集中选定栅格的最小及最大像元大小值。这是默认设置。</para>
		/// <para>选中 - 仅当像元大小的最小及最大值不存在时，才对其进行计算。</para>
		/// <para><see cref="UpdateMissingOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? UpdateMissingOnly { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateCellSizeRanges SetEnviroment(object? parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute Minimum Cell Sizes</para>
		/// </summary>
		public enum DoComputeMinEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MIN_CELL_SIZES")]
			MIN_CELL_SIZES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_CELL_SIZES")]
			NO_MIN_CELL_SIZES,

		}

		/// <summary>
		/// <para>Compute Maximum Cell Sizes</para>
		/// </summary>
		public enum DoComputeMaxEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MAX_CELL_SIZES")]
			MAX_CELL_SIZES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAX_CELL_SIZES")]
			NO_MAX_CELL_SIZES,

		}

		/// <summary>
		/// <para>Update Missing Values Only</para>
		/// </summary>
		public enum UpdateMissingOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_MISSING_ONLY")]
			UPDATE_MISSING_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("UPDATE_ALL")]
			UPDATE_ALL,

		}

#endregion
	}
}
