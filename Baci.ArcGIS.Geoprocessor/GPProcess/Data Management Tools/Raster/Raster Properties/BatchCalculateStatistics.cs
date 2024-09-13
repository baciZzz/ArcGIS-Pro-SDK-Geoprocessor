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
	/// <para>Batch Calculate Statistics</para>
	/// <para>批量计算统计数据</para>
	/// <para>计算多个栅格数据集的统计数据。</para>
	/// </summary>
	public class BatchCalculateStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasterDatasets">
		/// <para>Input Raster Datasets</para>
		/// <para>输入栅格数据集。</para>
		/// </param>
		public BatchCalculateStatistics(object InputRasterDatasets)
		{
			this.InputRasterDatasets = InputRasterDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : 批量计算统计数据</para>
		/// </summary>
		public override string DisplayName() => "批量计算统计数据";

		/// <summary>
		/// <para>Tool Name : BatchCalculateStatistics</para>
		/// </summary>
		public override string ToolName() => "BatchCalculateStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchCalculateStatistics</para>
		/// </summary>
		public override string ExcuteName() => "management.BatchCalculateStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "rasterStatistics", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasterDatasets, NumberOfColumnsToSkip!, NumberOfRowsToSkip!, IgnoreValues!, SkipExisting!, BatchCalculateStatisticsSucceeded! };

		/// <summary>
		/// <para>Input Raster Datasets</para>
		/// <para>输入栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasterDatasets { get; set; }

		/// <summary>
		/// <para>X Skip Factor</para>
		/// <para>样本之间水平像素的数量。</para>
		/// <para>在计算统计值时使用的那部分栅格由跳跃因子控制。特定输入值可指示水平或垂直跳跃因子，值为 1 时使用每个像素，值为 2 时则每隔一个像素使用一个。此跳跃因子的取值范围只能从 1 至栅格中列/行的数量。</para>
		/// <para>此值必须大于零并小于等于栅格中的列数。默认值为 1 或者为上次使用的跳跃因子。</para>
		/// <para>对于储存在文件地理数据库或企业级地理数据库中的栅格数据集，它们的跳跃因子并不相同。首先，如果 x 和 y 跳跃因子不同，则使用两者中较小的一个来作为 x 和 y 共同的跳跃因子。其次，跳跃因子同与其最接近的金字塔等级相关联。如果跳跃因子不等于金字塔图层中像素的数量，则该数量向下舍入至下一个金字塔等级，并使用那些统计值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfColumnsToSkip { get; set; } = "1";

		/// <summary>
		/// <para>Y Skip Factor</para>
		/// <para>样本之间垂直像素的数量。</para>
		/// <para>在计算统计值时使用的那部分栅格由跳跃因子控制。特定输入值可指示水平或垂直跳跃因子，值为 1 时使用每个像素，值为 2 时则每隔一个像素使用一个。此跳跃因子的取值范围只能从 1 至栅格中列/行的数量。</para>
		/// <para>此值必须大于零并小于等于栅格中的行数。默认值为 1 或者为上次使用的 y 跳跃因子。</para>
		/// <para>对于储存在文件地理数据库或企业级地理数据库中的栅格数据集，它们的跳跃因子并不相同。首先，如果 x 和 y 跳跃因子不同，则使用两者中较小的一个来作为 x 和 y 共同的跳跃因子。其次，跳跃因子同与其最接近的金字塔等级相关联。如果跳跃因子不等于金字塔图层中像素的数量，则该数量向下舍入至下一个金字塔等级，并使用那些统计值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfRowsToSkip { get; set; } = "1";

		/// <summary>
		/// <para>Ignore values</para>
		/// <para>排除在统计值计算之外的像素值。</para>
		/// <para>默认情况下没有值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? IgnoreValues { get; set; }

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>指定是在缺少统计数据的位置进行计算，还是重新生成统计数据（即使已经存在）。</para>
		/// <para>取消选中 - 即使统计数据已经存在仍要重新计算，现有统计数据将被覆盖。 这是默认设置。</para>
		/// <para>选中 - 只有当统计数据不存在时才会计算统计数据。</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SkipExisting { get; set; }

		/// <summary>
		/// <para>Batch Calculate Statistics Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? BatchCalculateStatisticsSucceeded { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchCalculateStatistics SetEnviroment(object? rasterStatistics = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum SkipExistingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

		}

#endregion
	}
}
