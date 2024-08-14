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
	/// <para>Evaluates if the input data has a selection and if a certain number of records are selected.</para>
	/// </summary>
	public class SelectionExistsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>Input layer or table view to evaluate.</para>
		/// </param>
		/// <param name="SelectionCondition">
		/// <para>Selection Condition</para>
		/// <para>Specifies the selection condition that will be used for the field values of the records matching the SQL expression.</para>
		/// <para>Exists—Checks whether the field value exists for the records matching the SQL expression. This is the default.</para>
		/// <para>No Selection—Checks whether none of the records matching the SQL expression are selected.</para>
		/// <para>All Selected—Checks whether all of the records matching the SQL expression are selected.</para>
		/// <para>Is Equal to—Checks whether the field value of the records matching the SQL expression is equal to the count value.</para>
		/// <para>Is Between—Checks whether the field value of the records matching the SQL expression is between the minimum count value and maximum count value.</para>
		/// <para>Is Less Than—Checks whether the field value of the records matching the SQL expression is equal to the count value.</para>
		/// <para>Is Greater Than—Checks whether the field value of the records matching the SQL expression is greater than the count value.</para>
		/// <para>Is Not Equal to—Checks whether the field value of the records matching the SQL expression is not equal to the count value.</para>
		/// <para><para/></para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </param>
		public SelectionExistsIfThenElse(object InLayerOrView, object SelectionCondition)
		{
			this.InLayerOrView = InLayerOrView;
			this.SelectionCondition = SelectionCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : If Selection Exists</para>
		/// </summary>
		public override string DisplayName => "If Selection Exists";

		/// <summary>
		/// <para>Tool Name : SelectionExistsIfThenElse</para>
		/// </summary>
		public override string ToolName => "SelectionExistsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.SelectionExistsIfThenElse</para>
		/// </summary>
		public override string ExcuteName => "mb.SelectionExistsIfThenElse";

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
		public override object[] Parameters => new object[] { InLayerOrView, SelectionCondition, Count!, CountMin!, CountMax!, True!, False! };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>Input layer or table view to evaluate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Selection Condition</para>
		/// <para>Specifies the selection condition that will be used for the field values of the records matching the SQL expression.</para>
		/// <para>Exists—Checks whether the field value exists for the records matching the SQL expression. This is the default.</para>
		/// <para>No Selection—Checks whether none of the records matching the SQL expression are selected.</para>
		/// <para>All Selected—Checks whether all of the records matching the SQL expression are selected.</para>
		/// <para>Is Equal to—Checks whether the field value of the records matching the SQL expression is equal to the count value.</para>
		/// <para>Is Between—Checks whether the field value of the records matching the SQL expression is between the minimum count value and maximum count value.</para>
		/// <para>Is Less Than—Checks whether the field value of the records matching the SQL expression is equal to the count value.</para>
		/// <para>Is Greater Than—Checks whether the field value of the records matching the SQL expression is greater than the count value.</para>
		/// <para>Is Not Equal to—Checks whether the field value of the records matching the SQL expression is not equal to the count value.</para>
		/// <para><para/></para>
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
		/// <para>Selection Condition</para>
		/// </summary>
		public enum SelectionConditionEnum 
		{
			/// <summary>
			/// <para>Exists—Checks whether the field value exists for the records matching the SQL expression. This is the default.</para>
			/// </summary>
			[GPValue("EXISTS")]
			[Description("Exists")]
			Exists,

			/// <summary>
			/// <para>No Selection—Checks whether none of the records matching the SQL expression are selected.</para>
			/// </summary>
			[GPValue("NO_SELECTION")]
			[Description("No Selection")]
			No_Selection,

			/// <summary>
			/// <para>All Selected—Checks whether all of the records matching the SQL expression are selected.</para>
			/// </summary>
			[GPValue("ALL_SELECTED")]
			[Description("All Selected")]
			All_Selected,

			/// <summary>
			/// <para>Is Equal to—Checks whether the field value of the records matching the SQL expression is equal to the count value.</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("Is Equal to")]
			Is_Equal_to,

			/// <summary>
			/// <para>Is Between—Checks whether the field value of the records matching the SQL expression is between the minimum count value and maximum count value.</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("Is Between")]
			Is_Between,

			/// <summary>
			/// <para>Is Less Than—Checks whether the field value of the records matching the SQL expression is equal to the count value.</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("Is Less Than")]
			Is_Less_Than,

			/// <summary>
			/// <para>Is Greater Than—Checks whether the field value of the records matching the SQL expression is greater than the count value.</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("Is Greater Than")]
			Is_Greater_Than,

			/// <summary>
			/// <para>Is Not Equal to—Checks whether the field value of the records matching the SQL expression is not equal to the count value.</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("Is Not Equal to")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
