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
	/// <para>If Selection Exists</para>
	/// <para>如果选择已存在</para>
	/// <para>评估输入数据是否有选择以及是否选中了特定数量的记录。</para>
	/// </summary>
	public class SelectionExistsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>评估输入图层或表视图</para>
		/// </param>
		/// <param name="SelectionCondition">
		/// <para>Selection Condition</para>
		/// <para>指定将用于匹配 SQL 表达式的记录字段值的选择条件。</para>
		/// <para>Exists—检查是否存在与 SQL 表达式匹配的记录的字段值。 这是默认设置。</para>
		/// <para>无选择—检查是否未选择与 SQL 表达式匹配的任何记录。</para>
		/// <para>选择全部—检查是否选择与 SQL 表达式匹配的所有记录。</para>
		/// <para>等于—选择与 SQL 表达式匹配的记录的字段值是否等于计数值。</para>
		/// <para>介于—检查与 SQL 表达式匹配的记录的字段值是否介于最小计数值和最大计数值之间。</para>
		/// <para>小于—选择与 SQL 表达式匹配的记录的字段值是否等于计数值。</para>
		/// <para>大于—选择与 SQL 表达式匹配的记录的字段值是否大于计数值。</para>
		/// <para>不等于—选择与 SQL 表达式匹配的记录的字段值是否不等于计数值。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </param>
		public SelectionExistsIfThenElse(object InLayerOrView, object SelectionCondition)
		{
			this.InLayerOrView = InLayerOrView;
			this.SelectionCondition = SelectionCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果选择已存在</para>
		/// </summary>
		public override string DisplayName() => "如果选择已存在";

		/// <summary>
		/// <para>Tool Name : SelectionExistsIfThenElse</para>
		/// </summary>
		public override string ToolName() => "SelectionExistsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.SelectionExistsIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.SelectionExistsIfThenElse";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayerOrView, SelectionCondition, Count!, CountMin!, CountMax!, True!, False! };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>评估输入图层或表视图</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Selection Condition</para>
		/// <para>指定将用于匹配 SQL 表达式的记录字段值的选择条件。</para>
		/// <para>Exists—检查是否存在与 SQL 表达式匹配的记录的字段值。 这是默认设置。</para>
		/// <para>无选择—检查是否未选择与 SQL 表达式匹配的任何记录。</para>
		/// <para>选择全部—检查是否选择与 SQL 表达式匹配的所有记录。</para>
		/// <para>等于—选择与 SQL 表达式匹配的记录的字段值是否等于计数值。</para>
		/// <para>介于—检查与 SQL 表达式匹配的记录的字段值是否介于最小计数值和最大计数值之间。</para>
		/// <para>小于—选择与 SQL 表达式匹配的记录的字段值是否等于计数值。</para>
		/// <para>大于—选择与 SQL 表达式匹配的记录的字段值是否大于计数值。</para>
		/// <para>不等于—选择与 SQL 表达式匹配的记录的字段值是否不等于计数值。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCondition { get; set; } = "EXISTS";

		/// <summary>
		/// <para>Count</para>
		/// <para>整数计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Count { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Count</para>
		/// <para>最小整数计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CountMin { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Count</para>
		/// <para>最大整数计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CountMax { get; set; } = "0";

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Selection Condition</para>
		/// </summary>
		public enum SelectionConditionEnum 
		{
			/// <summary>
			/// <para>Exists—检查是否存在与 SQL 表达式匹配的记录的字段值。 这是默认设置。</para>
			/// </summary>
			[GPValue("EXISTS")]
			[Description("Exists")]
			Exists,

			/// <summary>
			/// <para>无选择—检查是否未选择与 SQL 表达式匹配的任何记录。</para>
			/// </summary>
			[GPValue("NO_SELECTION")]
			[Description("无选择")]
			No_Selection,

			/// <summary>
			/// <para>选择全部—检查是否选择与 SQL 表达式匹配的所有记录。</para>
			/// </summary>
			[GPValue("ALL_SELECTED")]
			[Description("选择全部")]
			All_Selected,

			/// <summary>
			/// <para>等于—选择与 SQL 表达式匹配的记录的字段值是否等于计数值。</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("等于")]
			Is_Equal_to,

			/// <summary>
			/// <para>介于—检查与 SQL 表达式匹配的记录的字段值是否介于最小计数值和最大计数值之间。</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("介于")]
			Is_Between,

			/// <summary>
			/// <para>小于—选择与 SQL 表达式匹配的记录的字段值是否等于计数值。</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("小于")]
			Is_Less_Than,

			/// <summary>
			/// <para>大于—选择与 SQL 表达式匹配的记录的字段值是否大于计数值。</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("大于")]
			Is_Greater_Than,

			/// <summary>
			/// <para>不等于—选择与 SQL 表达式匹配的记录的字段值是否不等于计数值。</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("不等于")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
