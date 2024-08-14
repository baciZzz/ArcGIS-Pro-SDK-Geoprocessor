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
	/// <para>Convert Time Field</para>
	/// <para>Transfers date and time values stored in a field to another field.  The tool can be used to convert between different field types (text, numeric, or date fields) or to convert the values to a different format such as dd/MM/yy HH:mm:ss to yyyy-MM-dd.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ConvertTimeField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The layer or table that contains the field containing the time values that will be converted.</para>
		/// </param>
		/// <param name="InputTimeField">
		/// <para>Input Time Field</para>
		/// <para>The field containing the time values. The field can be of type short, long, float, double, text, or date.</para>
		/// </param>
		/// <param name="OutputTimeField">
		/// <para>Output Time Field Name</para>
		/// <para>The name of the field to be added in which the converted time values will be stored.</para>
		/// </param>
		public ConvertTimeField(object InTable, object InputTimeField, object OutputTimeField)
		{
			this.InTable = InTable;
			this.InputTimeField = InputTimeField;
			this.OutputTimeField = OutputTimeField;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Time Field</para>
		/// </summary>
		public override string DisplayName => "Convert Time Field";

		/// <summary>
		/// <para>Tool Name : ConvertTimeField</para>
		/// </summary>
		public override string ToolName => "ConvertTimeField";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertTimeField</para>
		/// </summary>
		public override string ExcuteName => "management.ConvertTimeField";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, InputTimeField, InputTimeFormat!, OutputTimeField, OutputTimeType!, OutputTimeFormat!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The layer or table that contains the field containing the time values that will be converted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Time Field</para>
		/// <para>The field containing the time values. The field can be of type short, long, float, double, text, or date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InputTimeField { get; set; }

		/// <summary>
		/// <para>Input Time Format</para>
		/// <para>The format of the time values in the Input Time Field parameter value. You can choose a standard time format from the drop-down list or specify a custom format. The parameter is not supported when the input time field is of type date.</para>
		/// <para>The format strings are case sensitive.</para>
		/// <para>If the data type of the time field is date, no time format is required.</para>
		/// <para>If the data type of the time field is numeric (short, long, float, or double), a list of standard numeric time formats is provided in the drop-down list.</para>
		/// <para>If the data type of the time field is string, a list of standard string time formats is provided in the drop-down list. For string fields, you can also specify a custom time format. For example, the time values may have been stored in a string field in one of the standard formats such as yyyy/MM/dd HH:mm:ss or in a custom format such as dd/MM/yyyy HH:mm:ss. For the custom format, you can also specify the a.m. or p.m. designator. Some commonly used formats are listed below:</para>
		/// <para>yyyy—Year represented by four digits</para>
		/// <para>MM—Month as digits with leading zero for single-digit months</para>
		/// <para>MMM—Month as a three-letter abbreviation</para>
		/// <para>dd—Day of month as digits with leading zero for single-digit days</para>
		/// <para>ddd—Day of week as a three-letter abbreviation</para>
		/// <para>hh—Hours with leading zero for single-digit hours; 12-hour clock</para>
		/// <para>HH—Hours with leading zero for single-digit hours; 24-hour clock</para>
		/// <para>mm—Minutes with leading zero for single-digit minutes</para>
		/// <para>ss—Seconds with leading zero for single-digit seconds</para>
		/// <para>t—One character time marker string, such as A or P</para>
		/// <para>tt—Multicharacter time marker string, such as AM or PM</para>
		/// <para>unix_us—Unix time in microseconds</para>
		/// <para>unix_ms—Unix time in milliseconds</para>
		/// <para>unix_s—Unix time in seconds</para>
		/// <para>unix_hex—Unix time in hexadecimal</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InputTimeFormat { get; set; }

		/// <summary>
		/// <para>Output Time Field Name</para>
		/// <para>The name of the field to be added in which the converted time values will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTimeField { get; set; }

		/// <summary>
		/// <para>Output Time Field Type</para>
		/// <para>Specifies the field type of the output time field.</para>
		/// <para>Date—The field type will be date. Date fields support date and time values.</para>
		/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
		/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
		/// <para>Double (64-bit floating point)—The field type will be double. Double fields support fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para><see cref="OutputTimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputTimeType { get; set; } = "DATE";

		/// <summary>
		/// <para>Output Time Format</para>
		/// <para>The format of the output time values. Supported output time formats depend on the Output Time Field Type parameter value. A custom format can also be used to convert the value to a different format or to extract a portion of the value (such as the year). For a list of custom formats, see the Input Time Format parameter help. This parameter is not used when the Output Time Field Type parameter value is Date.</para>
		/// <para>If the data type of the output time field isn&apos;t long enough to store the converted time value, the output value will be truncated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutputTimeFormat { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertTimeField SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Time Field Type</para>
		/// </summary>
		public enum OutputTimeTypeEnum 
		{
			/// <summary>
			/// <para>Date—The field type will be date. Date fields support date and time values.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (32-bit integer)")]
			LONG,

			/// <summary>
			/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (16-bit integer)")]
			SHORT,

			/// <summary>
			/// <para>Double (64-bit floating point)—The field type will be double. Double fields support fractional numbers between -2.2E308 and 1.8E308.</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double (64-bit floating point)")]
			DOUBLE,

			/// <summary>
			/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float (32-bit floating point)")]
			FLOAT,

		}

#endregion
	}
}
