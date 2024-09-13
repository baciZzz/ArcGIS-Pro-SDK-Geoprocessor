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
	/// <para>LAS Dataset Statistics</para>
	/// <para>LAS 数据集统计数据</para>
	/// <para>计算或更新 LAS 数据集的统计数据并生成可选的统计数据报表。</para>
	/// </summary>
	public class LasDatasetStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		public LasDatasetStatistics(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS 数据集统计数据</para>
		/// </summary>
		public override string DisplayName() => "LAS 数据集统计数据";

		/// <summary>
		/// <para>Tool Name : LasDatasetStatistics</para>
		/// </summary>
		public override string ToolName() => "LasDatasetStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.LasDatasetStatistics</para>
		/// </summary>
		public override string ExcuteName() => "management.LasDatasetStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, CalculationType!, OutFile!, SummaryLevel!, Delimiter!, DecimalSeparator!, DerivedLasDataset! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>指定是否针对所有激光雷达文件或仅针对那些没有统计数据的文件计算统计数据：</para>
		/// <para>选中 - 将跳过包含最新统计数据的 LAS 文件，仅为新添加的 LAS 文件或自初始计算后更新的 LAS 文件计算统计数据。这是默认设置。</para>
		/// <para>未选中 - 为所有 LAS 文件（包括具有最新统计数据的 LAS 文件）计算统计数据。这适合于在 ArcGIS 未检测到的外部应用程序中修改了 LAS 文件的情况。</para>
		/// <para><see cref="CalculationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CalculationType { get; set; } = "true";

		/// <summary>
		/// <para>Output Statistics Report Text File</para>
		/// <para>包含 LAS 数据集统计数据汇总的输出文本文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETextFile()]
		public object? OutFile { get; set; }

		/// <summary>
		/// <para>Summary Level</para>
		/// <para>指定包含在报表中的汇总类型。</para>
		/// <para>聚合所有文件的统计数据—报表将汇总整个 LAS 数据集的统计数据。这是默认设置。</para>
		/// <para>每个 LAS 文件的统计数据—报表将汇总 LAS 数据集引用的 LAS 文件的统计数据。</para>
		/// <para><see cref="SummaryLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SummaryLevel { get; set; } = "DATASET";

		/// <summary>
		/// <para>Delimiter</para>
		/// <para>将用于指示文本文件表的列中输入条目间隔的分隔符。</para>
		/// <para>空格—空格将用于分隔字段值。 这是默认设置。</para>
		/// <para>逗号—逗号将用于分隔字段值。 如果小数分隔符也是逗号，则此选项不适用。</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Delimiter { get; set; } = "COMMA";

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>文本文件中将用于区分数字的整数部分与其小数部分的小数分隔符。</para>
		/// <para>点—将使用点作为小数字符。 这是默认设置。</para>
		/// <para>逗号—将使用逗号作为小数字符。</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasDatasetStatistics SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum CalculationTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING_STATS")]
			SKIP_EXISTING_STATS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE_EXISTING_STATS")]
			OVERWRITE_EXISTING_STATS,

		}

		/// <summary>
		/// <para>Summary Level</para>
		/// </summary>
		public enum SummaryLevelEnum 
		{
			/// <summary>
			/// <para>聚合所有文件的统计数据—报表将汇总整个 LAS 数据集的统计数据。这是默认设置。</para>
			/// </summary>
			[GPValue("DATASET")]
			[Description("聚合所有文件的统计数据")]
			Aggregate_Statistics_for_All_Files,

			/// <summary>
			/// <para>每个 LAS 文件的统计数据—报表将汇总 LAS 数据集引用的 LAS 文件的统计数据。</para>
			/// </summary>
			[GPValue("LAS_FILES")]
			[Description("每个 LAS 文件的统计数据")]
			Statistics_for_Each_LAS_File,

		}

		/// <summary>
		/// <para>Delimiter</para>
		/// </summary>
		public enum DelimiterEnum 
		{
			/// <summary>
			/// <para>逗号—逗号将用于分隔字段值。 如果小数分隔符也是逗号，则此选项不适用。</para>
			/// </summary>
			[GPValue("COMMA")]
			[Description("逗号")]
			Comma,

			/// <summary>
			/// <para>空格—空格将用于分隔字段值。 这是默认设置。</para>
			/// </summary>
			[GPValue("SPACE")]
			[Description("空格")]
			Space,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>点—将使用点作为小数字符。 这是默认设置。</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>逗号—将使用逗号作为小数字符。</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("逗号")]
			Comma,

		}

#endregion
	}
}
