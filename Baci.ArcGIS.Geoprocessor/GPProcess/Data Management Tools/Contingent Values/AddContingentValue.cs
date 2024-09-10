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
	/// <para>Add Contingent Value</para>
	/// <para>Adds a contingent value to a field group on a feature class or table.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddContingentValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>The input geodatabase feature class or table to which the contingent value will be added.</para>
		/// </param>
		/// <param name="FieldGroupName">
		/// <para>Field Group Name</para>
		/// <para>The field group to which the contingent value will be added.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Values</para>
		/// <para>The field name, field value type, and associated field values to be used for the new contingent value.</para>
		/// <para>Field Name—The name of the field that participates in the field group</para>
		/// <para>Field Value Type—The type of contingent value. The Any and Null types will ignore any value specified in the Field Value field.</para>
		/// <para>Any—The value can be any field value.</para>
		/// <para>Null—The value is null.</para>
		/// <para>Coded Value—The value is from a coded value domain.</para>
		/// <para>Range—The value is a min/max subset of a range domain.</para>
		/// <para>Field Value—The specific field value. If the Field Value Type is Coded Value, specify the code description. If the Field Value Type is Range, specify the minimum and maximum values in the format min;max (for example, 10;100).</para>
		/// </param>
		public AddContingentValue(object TargetTable, object FieldGroupName, object Values)
		{
			this.TargetTable = TargetTable;
			this.FieldGroupName = FieldGroupName;
			this.Values = Values;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Contingent Value</para>
		/// </summary>
		public override string DisplayName() => "Add Contingent Value";

		/// <summary>
		/// <para>Tool Name : AddContingentValue</para>
		/// </summary>
		public override string ToolName() => "AddContingentValue";

		/// <summary>
		/// <para>Tool Excute Name : management.AddContingentValue</para>
		/// </summary>
		public override string ExcuteName() => "management.AddContingentValue";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetTable, FieldGroupName, Values, Subtype, RetireValue, OutTable };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>The input geodatabase feature class or table to which the contingent value will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>The field group to which the contingent value will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldGroupName { get; set; }

		/// <summary>
		/// <para>Values</para>
		/// <para>The field name, field value type, and associated field values to be used for the new contingent value.</para>
		/// <para>Field Name—The name of the field that participates in the field group</para>
		/// <para>Field Value Type—The type of contingent value. The Any and Null types will ignore any value specified in the Field Value field.</para>
		/// <para>Any—The value can be any field value.</para>
		/// <para>Null—The value is null.</para>
		/// <para>Coded Value—The value is from a coded value domain.</para>
		/// <para>Range—The value is a min/max subset of a range domain.</para>
		/// <para>Field Value—The specific field value. If the Field Value Type is Coded Value, specify the code description. If the Field Value Type is Range, specify the minimum and maximum values in the format min;max (for example, 10;100).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object Values { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The input table subtype to which the contingent value will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Subtype { get; set; }

		/// <summary>
		/// <para>Retire Value</para>
		/// <para>Specifies whether the contingent value will be retired. The contingent value is considered retired when it is no longer created but can still be used in an existing field. When a contingent value is retired, it will still be shown in the list of valid values for a field, such as in the Attribute pane, but it will be inactive and you won&apos;t be able to select it as a field value. An example is using asbestos as a building material. New construction cannot use asbestos as a building material, but existing structures may still have this attribute.</para>
		/// <para>Checked—The contingent value will be retired.</para>
		/// <para>Unchecked—The contingent value will not be retired. This is the default.</para>
		/// <para><see cref="RetireValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RetireValue { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddContingentValue SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Retire Value</para>
		/// </summary>
		public enum RetireValueEnum 
		{
			/// <summary>
			/// <para>Checked—The contingent value will be retired.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RETIRE")]
			RETIRE,

			/// <summary>
			/// <para>Unchecked—The contingent value will not be retired. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RETIRE")]
			DO_NOT_RETIRE,

		}

#endregion
	}
}
