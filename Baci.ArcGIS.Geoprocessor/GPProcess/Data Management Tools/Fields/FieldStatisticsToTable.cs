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
	/// <para>Field Statistics To Table</para>
	/// <para>字段统计数据转表</para>
	/// <para>为表或要素类中的一个或多个输入字段创建描述性统计表。</para>
	/// </summary>
	public class FieldStatisticsToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含用于创建统计数据表的字段的输入表。</para>
		/// </param>
		/// <param name="InFields">
		/// <para>Input Fields</para>
		/// <para>包含用于计算统计数据的值的字段。</para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>要创建输出表的位置。 位置可以为地理数据库、文件夹或要素数据集。</para>
		/// </param>
		/// <param name="OutTables">
		/// <para>Output Tables</para>
		/// <para>包含统计数据的输出表。 字段类型列用于指定将包含在每个输出表中的字段类型，每个输出表的名称在输出名称列中提供。 例如，您可以创建一个包含所有字段类型的汇总表，或者您可以为数值、文本和日期字段类型创建单独的汇总表。</para>
		/// <para>可用于字段类型列的选择如下：</para>
		/// <para>数值 - 将创建输入数值字段（短整型、长整型、浮点型和双精度型）汇总表。</para>
		/// <para>文本 - 将创建输入文本字段（文本型）汇总表。</para>
		/// <para>日期 - 将创建输入日期字段（日期型）汇总表。</para>
		/// <para>全部 - 将创建输入的所有数值、文本和日期字段的汇总表。 包含适用于多种字段类型的统计数据的输出字段将保存为文本型。 不适用于文本和日期型字段的输出统计数据将为空。</para>
		/// </param>
		public FieldStatisticsToTable(object InTable, object InFields, object OutLocation, object OutTables)
		{
			this.InTable = InTable;
			this.InFields = InFields;
			this.OutLocation = OutLocation;
			this.OutTables = OutTables;
		}

		/// <summary>
		/// <para>Tool Display Name : 字段统计数据转表</para>
		/// </summary>
		public override string DisplayName() => "字段统计数据转表";

		/// <summary>
		/// <para>Tool Name : FieldStatisticsToTable</para>
		/// </summary>
		public override string ToolName() => "FieldStatisticsToTable";

		/// <summary>
		/// <para>Tool Excute Name : management.FieldStatisticsToTable</para>
		/// </summary>
		public override string ExcuteName() => "management.FieldStatisticsToTable";

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
		public override object[] Parameters() => new object[] { InTable, InFields, OutLocation, OutTables, GroupByField!, OutStatistics!, OutNumeric!, OutText!, OutDate!, OutAll! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含用于创建统计数据表的字段的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Fields</para>
		/// <para>包含用于计算统计数据的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Float", "Double", "Text", "Long", "Date")]
		public object InFields { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>要创建输出表的位置。 位置可以为地理数据库、文件夹或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output Tables</para>
		/// <para>包含统计数据的输出表。 字段类型列用于指定将包含在每个输出表中的字段类型，每个输出表的名称在输出名称列中提供。 例如，您可以创建一个包含所有字段类型的汇总表，或者您可以为数值、文本和日期字段类型创建单独的汇总表。</para>
		/// <para>可用于字段类型列的选择如下：</para>
		/// <para>数值 - 将创建输入数值字段（短整型、长整型、浮点型和双精度型）汇总表。</para>
		/// <para>文本 - 将创建输入文本字段（文本型）汇总表。</para>
		/// <para>日期 - 将创建输入日期字段（日期型）汇总表。</para>
		/// <para>全部 - 将创建输入的所有数值、文本和日期字段的汇总表。 包含适用于多种字段类型的统计数据的输出字段将保存为文本型。 不适用于文本和日期型字段的输出统计数据将为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object OutTables { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>将用于对行进行分组的字段。 如果提供了分组依据字段，则输入的每个字段将在输出表中显示为一行，各分组依据字段中每个唯一值都会显示一次。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Text", "Long", "Date")]
		public object? GroupByField { get; set; }

		/// <summary>
		/// <para>Output Statistics</para>
		/// <para>指定将汇总的统计数据以及包含统计数据的输出字段名称。 将在统计列中提供统计数据，并在输出字段名称列中提供输出字段的名称。 如果没有提供任何值，则系统将为针对所有输入字段计算所有适用的统计数据。</para>
		/// <para>统计列提供了以下可用选项（仅适用于输入字段的统计数据才可用）：</para>
		/// <para>字段名称 - 字段的名称。</para>
		/// <para>别名 - 字段的别名。</para>
		/// <para>字段类型 - 字段的字段类型（短整型、长整型、双精度型、浮点型、文本型或日期型）。</para>
		/// <para>空 - 字段中包含空值的记录数。</para>
		/// <para>最小值 - 字段中的最小值。</para>
		/// <para>最大值 - 字段中的最大值。</para>
		/// <para>平均值 - 字段中所有值的平均值（总和除以总计数）。 要计算日期字段的平均日期，通过计算日期与参考日期（例如 1900-01-01）之间的差（以毫秒为单位），将每个日期转换为数字。</para>
		/// <para>标准差 - 字段中值的标准差。 它被计算为方差的平方根，其中方差是每个值与字段平均值的平方差的平均值。</para>
		/// <para>中值 - 字段中所有值的中位数。 中位数是值的排序列表中的中间值。 如果有偶数个值，则中位数是分布中两个中间值的平均值。</para>
		/// <para>计数 - 字段中非空值的数目。</para>
		/// <para>唯一值数 - 字段的唯一值数量。</para>
		/// <para>众数 - 字段中最常出现的值。</para>
		/// <para>最不常见 - 字段中最不常见的值。</para>
		/// <para>异常值 - 字段中具有异常值的记录数量。 异常值是大于字段值的第三四分位数或低于第一四分位数的四分位距的 1.5 倍的值。</para>
		/// <para>总和 - 字段内所有值的总和。</para>
		/// <para>范围 - 字段中最大和最小值之间的差。</para>
		/// <para>四分位距 - 字段中第一四分位数和第三四分位数值之间的范围。 这表示数据中间一半的范围。</para>
		/// <para>第一四分位数 - 字段中第一四分位数的值。 四分位数将值的排序列表分为四组，每组包含相等数量的值。 第一四分位数是升序的第一组的上限。</para>
		/// <para>第三四分位数 - 字段中第三四分位数的值。 四分位数将值的排序列表分为四组，每组包含相等数量的值。 第三四分位数是升序的第三组的上限。</para>
		/// <para>变化系数 - 字段中值的变化系数。 变化系数是值相对分布的度量。 计算方法为标准差除以字段的平均值。</para>
		/// <para>偏度 - 字段中值的偏度。 偏度测量分布的对称性。 偏度的计算方法是三阶矩（三次方数据值的平均值）除以三次方标准差。</para>
		/// <para>峰度 - 字段中值的峰度。 峰度描述了分布与正态分布的尾部相比的尾重，有助于识别极值的频率。 峰度的计算方法是：四阶矩（数据值的平均值取四次方）除以标准差的四次方。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? OutStatistics { get; set; }

		/// <summary>
		/// <para>Output Table for Numeric Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutNumeric { get; set; }

		/// <summary>
		/// <para>Output Table for Text Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutText { get; set; }

		/// <summary>
		/// <para>Output Table for Date Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutDate { get; set; }

		/// <summary>
		/// <para>Output Table for All Fields</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutAll { get; set; }

	}
}
