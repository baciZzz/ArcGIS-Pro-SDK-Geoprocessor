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
	/// <para>If Field Value Is</para>
	/// <para>Evaluates if the values in an attribute field match a specified value, expression, or second field.</para>
	/// </summary>
	public class FieldValueIsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>Input element to be evaluated.</para>
		/// </param>
		/// <param name="SelectionCondition">
		/// <para>Selection Condition</para>
		/// <para>The selection condition to use for the field values of the records matching the SQL expression.</para>
		/// <para>Exists—Checks if any records match the SQL expression. This is the default.</para>
		/// <para>No Selection—Checks if none of the records match the SQL expression.</para>
		/// <para>All Selected—Checks if all of the records match the SQL expression.</para>
		/// <para>Is Equal to—Checks if the number of records that match the SQL expression is equal to the Count value.</para>
		/// <para>Is Between—Checks if the number of records that match the SQL expression is between the Minimum Count value and Maximum Count value.</para>
		/// <para>Is Less Than—Checks if the number of records that match the SQL expression is less than the Count value.</para>
		/// <para>Is Greater Than—Checks if the number of records that match the SQL expression is greater than the Count value.</para>
		/// <para>Is Not Equal to—Checks if the number of records that match the SQL expression is not equal to the Count value.</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </param>
		public FieldValueIsIfThenElse(object InData, object SelectionCondition)
		{
			this.InData = InData;
			this.SelectionCondition = SelectionCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : If Field Value Is</para>
		/// </summary>
		public override string DisplayName() => "If Field Value Is";

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
		/// <para>Input element to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records. For more information on SQL syntax see SQL reference for query expressions used in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Invert Where Clause</para>
		/// <para>Specifies whether the expression will be used as is, or the opposite of the expression will be used.</para>
		/// <para>Unchecked—The query will be used as is. This is the default.</para>
		/// <para>Checked—The opposite of the query will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
		/// <para><see cref="InvertWhereClauseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InvertWhereClause { get; set; }

		/// <summary>
		/// <para>Selection Condition</para>
		/// <para>The selection condition to use for the field values of the records matching the SQL expression.</para>
		/// <para>Exists—Checks if any records match the SQL expression. This is the default.</para>
		/// <para>No Selection—Checks if none of the records match the SQL expression.</para>
		/// <para>All Selected—Checks if all of the records match the SQL expression.</para>
		/// <para>Is Equal to—Checks if the number of records that match the SQL expression is equal to the Count value.</para>
		/// <para>Is Between—Checks if the number of records that match the SQL expression is between the Minimum Count value and Maximum Count value.</para>
		/// <para>Is Less Than—Checks if the number of records that match the SQL expression is less than the Count value.</para>
		/// <para>Is Greater Than—Checks if the number of records that match the SQL expression is greater than the Count value.</para>
		/// <para>Is Not Equal to—Checks if the number of records that match the SQL expression is not equal to the Count value.</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCondition { get; set; } = "EXISTS";

		/// <summary>
		/// <para>Count</para>
		/// <para>The integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Count { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Count</para>
		/// <para>The minimum integer count value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CountMin { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Count</para>
		/// <para>The maximum integer count value.</para>
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
			/// <para>Checked—The opposite of the query will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para>Unchecked—The query will be used as is. This is the default.</para>
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
			/// <para>Exists—Checks if any records match the SQL expression. This is the default.</para>
			/// </summary>
			[GPValue("EXISTS")]
			[Description("Exists")]
			Exists,

			/// <summary>
			/// <para>No Selection—Checks if none of the records match the SQL expression.</para>
			/// </summary>
			[GPValue("NO_SELECTION")]
			[Description("No Selection")]
			No_Selection,

			/// <summary>
			/// <para>All Selected—Checks if all of the records match the SQL expression.</para>
			/// </summary>
			[GPValue("ALL_SELECTED")]
			[Description("All Selected")]
			All_Selected,

			/// <summary>
			/// <para>Is Equal to—Checks if the number of records that match the SQL expression is equal to the Count value.</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("Is Equal to")]
			Is_Equal_to,

			/// <summary>
			/// <para>Is Between—Checks if the number of records that match the SQL expression is between the Minimum Count value and Maximum Count value.</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("Is Between")]
			Is_Between,

			/// <summary>
			/// <para>Is Less Than—Checks if the number of records that match the SQL expression is less than the Count value.</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("Is Less Than")]
			Is_Less_Than,

			/// <summary>
			/// <para>Is Greater Than—Checks if the number of records that match the SQL expression is greater than the Count value.</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("Is Greater Than")]
			Is_Greater_Than,

			/// <summary>
			/// <para>Is Not Equal to—Checks if the number of records that match the SQL expression is not equal to the Count value.</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("Is Not Equal to")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
