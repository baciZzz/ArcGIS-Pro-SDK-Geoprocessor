using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Summary Statistics</para>
	/// <para>汇总统计数据</para>
	/// <para>为表中字段计算汇总统计数据。</para>
	/// </summary>
	public class Statistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含用于计算统计数据的字段的输入表。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出表用于存储计算的统计数据。</para>
		/// </param>
		/// <param name="StatisticsFields">
		/// <para>Statistics Field(s)</para>
		/// <para>指定包含用于计算指定统计数据的属性值的一个或多个数值字段。 可以指定多项统计和字段组合。 空值将被排除在所有统计计算之外。</para>
		/// <para>可使用第一种和最后一种统计来对文本属性字段进行汇总。 可使用任何一种统计来对数值属性字段进行汇总。</para>
		/// <para>可用统计类型如下：</para>
		/// <para>总和 - 将指定字段的值相加在一起。</para>
		/// <para>平均值 - 将计算指定字段的平均值。</para>
		/// <para>最小值 - 将查找指定字段所有记录的最小值。</para>
		/// <para>最大值 - 将查找指定字段所有记录的最大值。</para>
		/// <para>范围 - 将计算指定字段的值范围（最大值 - 最小值）。</para>
		/// <para>标准差 - 将计算指定字段中值的标准差。</para>
		/// <para>计数 - 将查找统计计算中包括的值的数目。 计数包括除空值外的所有值。 要确定字段中的空值数，请在相应字段上创建计数，然后在另一个不包含空值的字段上创建计数（例如 OID，如果存在的话），然后将这两个值相减。</para>
		/// <para>第一个 - 将使用输入中第一条记录的指定字段值。</para>
		/// <para>最后一个 - 将使用输入中最后一条记录的指定字段值。</para>
		/// <para>中值 - 将计算指定字段所有记录的中值。</para>
		/// <para>方差 - 将计算指定字段所有记录的方差。</para>
		/// <para>唯一值 - 将计算指定字段的唯一值数量。</para>
		/// </param>
		public Statistics(object InTable, object OutTable, object StatisticsFields)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.StatisticsFields = StatisticsFields;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总统计数据</para>
		/// </summary>
		public override string DisplayName() => "汇总统计数据";

		/// <summary>
		/// <para>Tool Name : Statistics</para>
		/// </summary>
		public override string ToolName() => "Statistics";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Statistics</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Statistics";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutTable, StatisticsFields, CaseField };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含用于计算统计数据的字段的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表用于存储计算的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Statistics Field(s)</para>
		/// <para>指定包含用于计算指定统计数据的属性值的一个或多个数值字段。 可以指定多项统计和字段组合。 空值将被排除在所有统计计算之外。</para>
		/// <para>可使用第一种和最后一种统计来对文本属性字段进行汇总。 可使用任何一种统计来对数值属性字段进行汇总。</para>
		/// <para>可用统计类型如下：</para>
		/// <para>总和 - 将指定字段的值相加在一起。</para>
		/// <para>平均值 - 将计算指定字段的平均值。</para>
		/// <para>最小值 - 将查找指定字段所有记录的最小值。</para>
		/// <para>最大值 - 将查找指定字段所有记录的最大值。</para>
		/// <para>范围 - 将计算指定字段的值范围（最大值 - 最小值）。</para>
		/// <para>标准差 - 将计算指定字段中值的标准差。</para>
		/// <para>计数 - 将查找统计计算中包括的值的数目。 计数包括除空值外的所有值。 要确定字段中的空值数，请在相应字段上创建计数，然后在另一个不包含空值的字段上创建计数（例如 OID，如果存在的话），然后将这两个值相减。</para>
		/// <para>第一个 - 将使用输入中第一条记录的指定字段值。</para>
		/// <para>最后一个 - 将使用输入中最后一条记录的指定字段值。</para>
		/// <para>中值 - 将计算指定字段所有记录的中值。</para>
		/// <para>方差 - 将计算指定字段所有记录的方差。</para>
		/// <para>唯一值 - 将计算指定字段的唯一值数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object StatisticsFields { get; set; }

		/// <summary>
		/// <para>Case field</para>
		/// <para>“输入”中用于为每个唯一属性值（如果指定多个字段，则为属性值组合）单独计算统计数据的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Statistics SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
