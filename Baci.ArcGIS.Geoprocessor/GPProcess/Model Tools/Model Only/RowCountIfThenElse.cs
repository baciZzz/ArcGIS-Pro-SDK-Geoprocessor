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
	/// <para>If Row Count Is</para>
	/// <para>Evaluates the row count of the input data and checks whether it matches a specified value.</para>
	/// </summary>
	public class RowCountIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>The input layer or table view to evaluate.</para>
		/// </param>
		/// <param name="CountCondition">
		/// <para>Count Condition</para>
		/// <para>Specifies the condition to be used to test the field values of the records matching the SQL expression.</para>
		/// <para>Is Equal to—Checks if the row count is equal to the Count value.</para>
		/// <para>Is Between—Checks if the row count is between the Minimum Count value and Maximum Count value.</para>
		/// <para>Is Less Than—Checks if the row count is less than the Count value.</para>
		/// <para>Is Greater Than—Checks if the row count is greater than the Count value.</para>
		/// <para>Is Not Equal to—Checks if the row count is not equal to the Count value.</para>
		/// <para><see cref="CountConditionEnum"/></para>
		/// </param>
		public RowCountIfThenElse(object InLayerOrView, object CountCondition)
		{
			this.InLayerOrView = InLayerOrView;
			this.CountCondition = CountCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : If Row Count Is</para>
		/// </summary>
		public override string DisplayName() => "If Row Count Is";

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
		public override object[] Parameters() => new object[] { InLayerOrView, CountCondition, Count!, CountMin!, CountMax!, True!, False! };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>The input layer or table view to evaluate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Count Condition</para>
		/// <para>Specifies the condition to be used to test the field values of the records matching the SQL expression.</para>
		/// <para>Is Equal to—Checks if the row count is equal to the Count value.</para>
		/// <para>Is Between—Checks if the row count is between the Minimum Count value and Maximum Count value.</para>
		/// <para>Is Less Than—Checks if the row count is less than the Count value.</para>
		/// <para>Is Greater Than—Checks if the row count is greater than the Count value.</para>
		/// <para>Is Not Equal to—Checks if the row count is not equal to the Count value.</para>
		/// <para><see cref="CountConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CountCondition { get; set; } = "IS_EQUAL_TO";

		/// <summary>
		/// <para>Count</para>
		/// <para>The integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Count { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Count</para>
		/// <para>The minimum integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CountMin { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Count</para>
		/// <para>The maximum integer count value.</para>
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
		/// <para>Count Condition</para>
		/// </summary>
		public enum CountConditionEnum 
		{
			/// <summary>
			/// <para>Is Equal to—Checks if the row count is equal to the Count value.</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("Is Equal to")]
			Is_Equal_to,

			/// <summary>
			/// <para>Is Between—Checks if the row count is between the Minimum Count value and Maximum Count value.</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("Is Between")]
			Is_Between,

			/// <summary>
			/// <para>Is Less Than—Checks if the row count is less than the Count value.</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("Is Less Than")]
			Is_Less_Than,

			/// <summary>
			/// <para>Is Greater Than—Checks if the row count is greater than the Count value.</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("Is Greater Than")]
			Is_Greater_Than,

			/// <summary>
			/// <para>Is Not Equal to—Checks if the row count is not equal to the Count value.</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("Is Not Equal to")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
