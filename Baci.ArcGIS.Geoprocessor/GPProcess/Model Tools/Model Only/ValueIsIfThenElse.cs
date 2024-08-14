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
	/// <para>Evaluates an input value compared to a single value, a list of values, or a range of values using a defined comparison operator.</para>
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
		/// <para>Tool Display Name : If Value Is</para>
		/// </summary>
		public override string DisplayName => "If Value Is";

		/// <summary>
		/// <para>Tool Name : ValueIsIfThenElse</para>
		/// </summary>
		public override string ToolName => "ValueIsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.ValueIsIfThenElse</para>
		/// </summary>
		public override string ExcuteName => "mb.ValueIsIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputValue!, ValueTest!, ComparisonType!, Values!, RangeValues!, ComparisonValue!, True!, False! };

		/// <summary>
		/// <para>Input Value</para>
		/// <para>The input value to evaluate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPType()]
		public object? InputValue { get; set; }

		/// <summary>
		/// <para>Value Test</para>
		/// <para>Specifies the type of comparison operator to use.</para>
		/// <para>Is equal to at least one value—Determine whether the input value is equal to any one of the comparison values. This is the default.</para>
		/// <para>Does not match at least one value—Determine whether the input value is not equal to any one of the comparison values.</para>
		/// <para>Does not match every value—Determine whether the input value is not equal to every comparison value.</para>
		/// <para>Is between any one range of values—Determine whether the input value is between any one range of comparison values.</para>
		/// <para>Is not between any range of values— Determine whether the input value is not between any range of comparison values.</para>
		/// <para>Is less than—Determine whether the input value is less than the comparison value.</para>
		/// <para>Is greater than—Determine whether the input value is greater than the comparison value.</para>
		/// <para>Is less than or equal to—Determine whether the input value is less than or equal to the comparison value.</para>
		/// <para>Is greater than or equal to—Determine whether the input value is greater than or equal to the comparison value.</para>
		/// <para>Is empty—Determine whether the input value is empty.</para>
		/// <para><see cref="ValueTestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ValueTest { get; set; } = "IS_EQUAL_TO_ANY";

		/// <summary>
		/// <para>Comparison Type</para>
		/// <para>Specifies the type of data comparison to use.</para>
		/// <para>Case insensitive string—The input value is compared to the comparison values as a case insensitive string. This is the default.</para>
		/// <para>Case sensitive string—The input value is compared to the comparison values as a case sensitive string.</para>
		/// <para>Long—The input numeric value is compared to the comparison values as a Long type.</para>
		/// <para>Double— The input numeric value is compared to the comparison values as a Double type.</para>
		/// <para>Automatic data type detection—The input data type is checked and an equivalent data type comparison is performed. For example, compare the input and comparison values using string comparison for string type, long for long, and double for double. All other input data types use the default string comparison method.</para>
		/// <para><see cref="ComparisonTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComparisonType { get; set; } = "STRING_CASE_INSENSITIVE";

		/// <summary>
		/// <para>Values</para>
		/// <para>The list of values to compare to the input value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Values { get; set; }

		/// <summary>
		/// <para>Range Values</para>
		/// <para>Specifies the range values to compare to the input value.</para>
		/// <para>Minimum—The input value is compared to the minimum value in the range.</para>
		/// <para>Maximum—The input value is compared to the maximum value in the range.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? RangeValues { get; set; }

		/// <summary>
		/// <para>Comparison Value</para>
		/// <para>The single value to compare to the input value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPType()]
		public object? ComparisonValue { get; set; }

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
		/// <para>Value Test</para>
		/// </summary>
		public enum ValueTestEnum 
		{
			/// <summary>
			/// <para>Is equal to at least one value—Determine whether the input value is equal to any one of the comparison values. This is the default.</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO_ANY")]
			[Description("Is equal to at least one value")]
			Is_equal_to_at_least_one_value,

			/// <summary>
			/// <para>Does not match at least one value—Determine whether the input value is not equal to any one of the comparison values.</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO_ANY")]
			[Description("Does not match at least one value")]
			Does_not_match_at_least_one_value,

			/// <summary>
			/// <para>Does not match every value—Determine whether the input value is not equal to every comparison value.</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO_ALL")]
			[Description("Does not match every value")]
			Does_not_match_every_value,

			/// <summary>
			/// <para>Is between any one range of values—Determine whether the input value is between any one range of comparison values.</para>
			/// </summary>
			[GPValue("IS_BETWEEN_ANY")]
			[Description("Is between any one range of values")]
			Is_between_any_one_range_of_values,

			/// <summary>
			/// <para>Is not between any range of values— Determine whether the input value is not between any range of comparison values.</para>
			/// </summary>
			[GPValue("IS_NOT_BETWEEN_ANY")]
			[Description("Is not between any range of values")]
			Is_not_between_any_range_of_values,

			/// <summary>
			/// <para>Is less than—Determine whether the input value is less than the comparison value.</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("Is less than")]
			Is_less_than,

			/// <summary>
			/// <para>Is greater than—Determine whether the input value is greater than the comparison value.</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("Is greater than")]
			Is_greater_than,

			/// <summary>
			/// <para>Is less than or equal to—Determine whether the input value is less than or equal to the comparison value.</para>
			/// </summary>
			[GPValue("IS_LESS_THAN_OR_EQUAL")]
			[Description("Is less than or equal to")]
			Is_less_than_or_equal_to,

			/// <summary>
			/// <para>Is greater than or equal to—Determine whether the input value is greater than or equal to the comparison value.</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN_OR_EQUAL")]
			[Description("Is greater than or equal to")]
			Is_greater_than_or_equal_to,

			/// <summary>
			/// <para>Is empty—Determine whether the input value is empty.</para>
			/// </summary>
			[GPValue("IS_EMPTY")]
			[Description("Is empty")]
			Is_empty,

		}

		/// <summary>
		/// <para>Comparison Type</para>
		/// </summary>
		public enum ComparisonTypeEnum 
		{
			/// <summary>
			/// <para>Case insensitive string—The input value is compared to the comparison values as a case insensitive string. This is the default.</para>
			/// </summary>
			[GPValue("STRING_CASE_INSENSITIVE")]
			[Description("Case insensitive string")]
			Case_insensitive_string,

			/// <summary>
			/// <para>Case sensitive string—The input value is compared to the comparison values as a case sensitive string.</para>
			/// </summary>
			[GPValue("STRING_CASE_SENSITIVE")]
			[Description("Case sensitive string")]
			Case_sensitive_string,

			/// <summary>
			/// <para>Long—The input numeric value is compared to the comparison values as a Long type.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long")]
			Long,

			/// <summary>
			/// <para>Double— The input numeric value is compared to the comparison values as a Double type.</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double")]
			Double,

			/// <summary>
			/// <para>Automatic data type detection—The input data type is checked and an equivalent data type comparison is performed. For example, compare the input and comparison values using string comparison for string type, long for long, and double for double. All other input data types use the default string comparison method.</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("Automatic data type detection")]
			Automatic_data_type_detection,

		}

#endregion
	}
}
