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
	/// <para>If Value Is</para>
	/// <para>如果值为</para>
	/// <para>可使用定义的比较运算符对输入值与单一值、值列表或值范围进行估算。</para>
	/// </summary>
	public class ValueIsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public ValueIsIfThenElse()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : 如果值为</para>
		/// </summary>
		public override string DisplayName() => "如果值为";

		/// <summary>
		/// <para>Tool Name : ValueIsIfThenElse</para>
		/// </summary>
		public override string ToolName() => "ValueIsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.ValueIsIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.ValueIsIfThenElse";

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
		public override object[] Parameters() => new object[] { InputValue, ValueTest, ComparisonType, Values, RangeValues, ComparisonValue, True, False };

		/// <summary>
		/// <para>Input Value</para>
		/// <para>要评估的输入值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPType()]
		public object InputValue { get; set; }

		/// <summary>
		/// <para>Value Test</para>
		/// <para>指定要使用的比较运算符的类型。</para>
		/// <para>至少等于一个值—确定输入值是否等于任何一个比较值。这是默认设置。</para>
		/// <para>至少不匹配一个值—确定输入值是否不等于任何一个比较值。</para>
		/// <para>不匹配每个值—确定输入值是否不等于每个比较值。</para>
		/// <para>在任何一个值范围之内—确定输入值是否位于比较值的任何一个范围之内。</para>
		/// <para>不在任何值范围之內— 确定输入值是否不在比较值的任何范围之内。</para>
		/// <para>小于—确定输入值是否小于比较值。</para>
		/// <para>大于—确定输入值是否大于比较值。</para>
		/// <para>小于或等于—确定输入值是否小于或等于比较值。</para>
		/// <para>大于或等于—确定输入值是否大于或等于比较值。</para>
		/// <para>为空—确定输入值是否为空。</para>
		/// <para><see cref="ValueTestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValueTest { get; set; } = "IS_EQUAL_TO_ANY";

		/// <summary>
		/// <para>Comparison Type</para>
		/// <para>指定要使用的数据比较类型。</para>
		/// <para>不区分大小写的字符串—作为不区分大小写的字符串，将输入值与比较值进行比较。这是默认设置。</para>
		/// <para>区分大小写的字符串—作为区分大小写的字符串，将输入值与比较值进行比较。</para>
		/// <para>Long—作为长整型，将输入数值与比较值进行比较。</para>
		/// <para>双精度— 作为双精度型，将输入数值与比较值进行比较。</para>
		/// <para>自动数据类型检测—检查输入数据类型，并执行等效数据类型比较。例如，输入值与比较值之间的比较使用字符串型的字符串比较、长整型的长整型比较，以及双精度型的双精度型比较。所有其他输入数据类型将使用默认字符串比较方法。</para>
		/// <para><see cref="ComparisonTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ComparisonType { get; set; } = "STRING_CASE_INSENSITIVE";

		/// <summary>
		/// <para>Values</para>
		/// <para>要与输入值进行比较的值列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Values { get; set; }

		/// <summary>
		/// <para>Range Values</para>
		/// <para>指定要与输入值进行比较的范围值。</para>
		/// <para>最小值 - 将输入值与范围内的最小值进行比较。</para>
		/// <para>最大值 - 将输入值与范围内的最大值进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object RangeValues { get; set; }

		/// <summary>
		/// <para>Comparison Value</para>
		/// <para>要与输入值进行比较的单个值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPType()]
		public object ComparisonValue { get; set; }

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
		/// <para>Value Test</para>
		/// </summary>
		public enum ValueTestEnum 
		{
			/// <summary>
			/// <para>至少等于一个值—确定输入值是否等于任何一个比较值。这是默认设置。</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO_ANY")]
			[Description("至少等于一个值")]
			Is_equal_to_at_least_one_value,

			/// <summary>
			/// <para>至少不匹配一个值—确定输入值是否不等于任何一个比较值。</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO_ANY")]
			[Description("至少不匹配一个值")]
			Does__not_match_at_least_one_value,

			/// <summary>
			/// <para>不匹配每个值—确定输入值是否不等于每个比较值。</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO_ALL")]
			[Description("不匹配每个值")]
			Does_not_match_every_value,

			/// <summary>
			/// <para>在任何一个值范围之内—确定输入值是否位于比较值的任何一个范围之内。</para>
			/// </summary>
			[GPValue("IS_BETWEEN_ANY")]
			[Description("在任何一个值范围之内")]
			Is_between_any_one_range_of_values,

			/// <summary>
			/// <para>不在任何值范围之內— 确定输入值是否不在比较值的任何范围之内。</para>
			/// </summary>
			[GPValue("IS_NOT_BETWEEN_ANY")]
			[Description("不在任何值范围之內")]
			Is_not_between_any_range_of_values,

			/// <summary>
			/// <para>小于—确定输入值是否小于比较值。</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("小于")]
			Is_less_than,

			/// <summary>
			/// <para>大于—确定输入值是否大于比较值。</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("大于")]
			Is_greater_than,

			/// <summary>
			/// <para>小于或等于—确定输入值是否小于或等于比较值。</para>
			/// </summary>
			[GPValue("IS_LESS_THAN_OR_EQUAL")]
			[Description("小于或等于")]
			Is_less_than_or_equal_to,

			/// <summary>
			/// <para>大于或等于—确定输入值是否大于或等于比较值。</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN_OR_EQUAL")]
			[Description("大于或等于")]
			Is_greater_than_or_equal_to,

			/// <summary>
			/// <para>为空—确定输入值是否为空。</para>
			/// </summary>
			[GPValue("IS_EMPTY")]
			[Description("为空")]
			Is_empty,

		}

		/// <summary>
		/// <para>Comparison Type</para>
		/// </summary>
		public enum ComparisonTypeEnum 
		{
			/// <summary>
			/// <para>不区分大小写的字符串—作为不区分大小写的字符串，将输入值与比较值进行比较。这是默认设置。</para>
			/// </summary>
			[GPValue("STRING_CASE_INSENSITIVE")]
			[Description("不区分大小写的字符串")]
			Case_insensitive_string,

			/// <summary>
			/// <para>区分大小写的字符串—作为区分大小写的字符串，将输入值与比较值进行比较。</para>
			/// </summary>
			[GPValue("STRING_CASE_SENSITIVE")]
			[Description("区分大小写的字符串")]
			Case_sensitive_string,

			/// <summary>
			/// <para>Long—作为长整型，将输入数值与比较值进行比较。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long")]
			Long,

			/// <summary>
			/// <para>双精度— 作为双精度型，将输入数值与比较值进行比较。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度")]
			Double,

			/// <summary>
			/// <para>自动数据类型检测—检查输入数据类型，并执行等效数据类型比较。例如，输入值与比较值之间的比较使用字符串型的字符串比较、长整型的长整型比较，以及双精度型的双精度型比较。所有其他输入数据类型将使用默认字符串比较方法。</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("自动数据类型检测")]
			Automatic_data_type_detection,

		}

#endregion
	}
}
