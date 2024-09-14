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
	/// <para>Assign Default To Field</para>
	/// <para>Assign Default To Field</para>
	/// <para>Creates a default value for a specified field.  When a new row is added to the table or feature class, the specified field will be set to this default value.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AssignDefaultToField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or feature class that will have a default value added to one of its fields.</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>The field to which the default value will be added each time a new row is added to the table or feature class.</para>
		/// </param>
		public AssignDefaultToField(object InTable, object FieldName)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : Assign Default To Field</para>
		/// </summary>
		public override string DisplayName() => "Assign Default To Field";

		/// <summary>
		/// <para>Tool Name : AssignDefaultToField</para>
		/// </summary>
		public override string ToolName() => "AssignDefaultToField";

		/// <summary>
		/// <para>Tool Excute Name : management.AssignDefaultToField</para>
		/// </summary>
		public override string ExcuteName() => "management.AssignDefaultToField";

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
		public override object[] Parameters() => new object[] { InTable, FieldName, DefaultValue, SubtypeCode, ClearValue, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or feature class that will have a default value added to one of its fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The field to which the default value will be added each time a new row is added to the table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Default Value</para>
		/// <para>The default value to be added to each new table or feature class. The value entered must match the data type of the field. If the field chosen has a coded value domain assigned to it, the values from the coded domain will be included in the parameter value list..</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DefaultValue { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The subtypes that can participate in the default value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object SubtypeCode { get; set; }

		/// <summary>
		/// <para>Clear Value</para>
		/// <para>Specifies whether the default value for either the field or the subtype will be cleared. The Default Value parameter must be empty to clear the default value of the field. To clear the default value for the subtype, leave the Default Value parameter empty and specify the subtype to be cleared.</para>
		/// <para>Checked—The default value will be cleared (set to null). The default value parameter must be empty.</para>
		/// <para>Unchecked—The default value will not be cleared. This is the default.</para>
		/// <para><see cref="ClearValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClearValue { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AssignDefaultToField SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clear Value</para>
		/// </summary>
		public enum ClearValueEnum 
		{
			/// <summary>
			/// <para>Checked—The default value will be cleared (set to null). The default value parameter must be empty.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_VALUE")]
			CLEAR_VALUE,

			/// <summary>
			/// <para>Unchecked—The default value will not be cleared. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR")]
			DO_NOT_CLEAR,

		}

#endregion
	}
}
