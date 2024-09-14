using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Field Value Is</para>
	/// <para>如果字段值为</para>
	/// <para>用于评估属性字段中的值是否与指定的值、表达式或第二个字段相匹配。</para>
	/// </summary>
	public class FieldValueIsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>要评估的输入元素。</para>
		/// </param>
		/// <param name="SelectionCondition">
		/// <para>Selection Condition</para>
		/// <para>用于匹配 SQL 表达式的记录字段值的选择条件。</para>
		/// <para>Exists—用于检查是否存在与 SQL 表达式匹配的记录。这是默认设置。</para>
		/// <para>无选择内容—用于检查是否不存在与 SQL 表达式匹配的记录。</para>
		/// <para>全部选中—用于检查是否所有记录均与 SQL 表达式匹配。</para>
		/// <para>等于—用于检查与 SQL 表达式匹配的记录数是否等于“计数”值。</para>
		/// <para>介于—用于检查与 SQL 表达式匹配的记录数是否介于“最小计数”值和“最大计数”值之间。</para>
		/// <para>小于—用于检查与 SQL 表达式匹配的记录数是否小于“计数”值。</para>
		/// <para>大于—用于检查与 SQL 表达式匹配的记录数是否大于“计数”值。</para>
		/// <para>不等于—用于检查与 SQL 表达式匹配的记录数是否与“计数”值不相等。</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </param>
		public FieldValueIsIfThenElse(object InData, object SelectionCondition)
		{
			this.InData = InData;
			this.SelectionCondition = SelectionCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果字段值为</para>
		/// </summary>
		public override string DisplayName() => "如果字段值为";

		/// <summary>
		/// <para>Tool Name : FieldValueIsIfThenElse</para>
		/// </summary>
		public override string ToolName() => "FieldValueIsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.FieldValueIsIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.FieldValueIsIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, WhereClause, InvertWhereClause, SelectionCondition, Count, CountMin, CountMax, True, False };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>要评估的输入元素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Invert Where Clause</para>
		/// <para>指定是按原样使用表达式，还是使用与表达式相反的表达式。</para>
		/// <para>未选中 - 将按原样使用查询。这是默认设置。</para>
		/// <para>选中 - 将反转查询。如果使用选择类型参数，则将先反转选择，然后再将其与现有选择组合。</para>
		/// <para><see cref="InvertWhereClauseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InvertWhereClause { get; set; }

		/// <summary>
		/// <para>Selection Condition</para>
		/// <para>用于匹配 SQL 表达式的记录字段值的选择条件。</para>
		/// <para>Exists—用于检查是否存在与 SQL 表达式匹配的记录。这是默认设置。</para>
		/// <para>无选择内容—用于检查是否不存在与 SQL 表达式匹配的记录。</para>
		/// <para>全部选中—用于检查是否所有记录均与 SQL 表达式匹配。</para>
		/// <para>等于—用于检查与 SQL 表达式匹配的记录数是否等于“计数”值。</para>
		/// <para>介于—用于检查与 SQL 表达式匹配的记录数是否介于“最小计数”值和“最大计数”值之间。</para>
		/// <para>小于—用于检查与 SQL 表达式匹配的记录数是否小于“计数”值。</para>
		/// <para>大于—用于检查与 SQL 表达式匹配的记录数是否大于“计数”值。</para>
		/// <para>不等于—用于检查与 SQL 表达式匹配的记录数是否与“计数”值不相等。</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCondition { get; set; } = "EXISTS";

		/// <summary>
		/// <para>Count</para>
		/// <para>整型计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Count { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Count</para>
		/// <para>最小整型计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CountMin { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Count</para>
		/// <para>最大整型计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CountMax { get; set; } = "0";

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Invert Where Clause</para>
		/// </summary>
		public enum InvertWhereClauseEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_INVERT")]
			NON_INVERT,

		}

		/// <summary>
		/// <para>Selection Condition</para>
		/// </summary>
		public enum SelectionConditionEnum 
		{
			/// <summary>
			/// <para>Exists—用于检查是否存在与 SQL 表达式匹配的记录。这是默认设置。</para>
			/// </summary>
			[GPValue("EXISTS")]
			[Description("Exists")]
			Exists,

			/// <summary>
			/// <para>无选择内容—用于检查是否不存在与 SQL 表达式匹配的记录。</para>
			/// </summary>
			[GPValue("NO_SELECTION")]
			[Description("无选择内容")]
			No_Selection,

			/// <summary>
			/// <para>全部选中—用于检查是否所有记录均与 SQL 表达式匹配。</para>
			/// </summary>
			[GPValue("ALL_SELECTED")]
			[Description("全部选中")]
			All_Selected,

			/// <summary>
			/// <para>等于—用于检查与 SQL 表达式匹配的记录数是否等于“计数”值。</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("等于")]
			Is_Equal_to,

			/// <summary>
			/// <para>介于—用于检查与 SQL 表达式匹配的记录数是否介于“最小计数”值和“最大计数”值之间。</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("介于")]
			Is_Between,

			/// <summary>
			/// <para>小于—用于检查与 SQL 表达式匹配的记录数是否小于“计数”值。</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("小于")]
			Is_Less_Than,

			/// <summary>
			/// <para>大于—用于检查与 SQL 表达式匹配的记录数是否大于“计数”值。</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("大于")]
			Is_Greater_Than,

			/// <summary>
			/// <para>不等于—用于检查与 SQL 表达式匹配的记录数是否与“计数”值不相等。</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("不等于")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
