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
	/// <para>If Row Count Is</para>
	/// <para>如果行计数为</para>
	/// <para>评估输入数据的行计数并检查其是否与指定的值匹配。</para>
	/// </summary>
	public class RowCountIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>评估输入图层或表视图。</para>
		/// </param>
		/// <param name="CountCondition">
		/// <para>Count Condition</para>
		/// <para>指定用于测试记录中的字段值与 SQL 表达式匹配的条件。</para>
		/// <para>等于—检查行计数是否等于计数值。</para>
		/// <para>介于—检查行计数是否介于最小计数值与最大计数值之间。</para>
		/// <para>小于—检查行计数是否小于计数值。</para>
		/// <para>大于—检查行计数是否大于计数值。</para>
		/// <para>不等于—检查行计数是否不等于计数值。</para>
		/// <para><see cref="CountConditionEnum"/></para>
		/// </param>
		public RowCountIfThenElse(object InLayerOrView, object CountCondition)
		{
			this.InLayerOrView = InLayerOrView;
			this.CountCondition = CountCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果行计数为</para>
		/// </summary>
		public override string DisplayName() => "如果行计数为";

		/// <summary>
		/// <para>Tool Name : RowCountIfThenElse</para>
		/// </summary>
		public override string ToolName() => "RowCountIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.RowCountIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.RowCountIfThenElse";

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
		public override object[] Parameters() => new object[] { InLayerOrView, CountCondition, Count, CountMin, CountMax, True, False };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>评估输入图层或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Count Condition</para>
		/// <para>指定用于测试记录中的字段值与 SQL 表达式匹配的条件。</para>
		/// <para>等于—检查行计数是否等于计数值。</para>
		/// <para>介于—检查行计数是否介于最小计数值与最大计数值之间。</para>
		/// <para>小于—检查行计数是否小于计数值。</para>
		/// <para>大于—检查行计数是否大于计数值。</para>
		/// <para>不等于—检查行计数是否不等于计数值。</para>
		/// <para><see cref="CountConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CountCondition { get; set; } = "IS_EQUAL_TO";

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
		/// <para>Count Condition</para>
		/// </summary>
		public enum CountConditionEnum 
		{
			/// <summary>
			/// <para>等于—检查行计数是否等于计数值。</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("等于")]
			Is_Equal_to,

			/// <summary>
			/// <para>介于—检查行计数是否介于最小计数值与最大计数值之间。</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("介于")]
			Is_Between,

			/// <summary>
			/// <para>小于—检查行计数是否小于计数值。</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("小于")]
			Is_Less_Than,

			/// <summary>
			/// <para>大于—检查行计数是否大于计数值。</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("大于")]
			Is_Greater_Than,

			/// <summary>
			/// <para>不等于—检查行计数是否不等于计数值。</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("不等于")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
