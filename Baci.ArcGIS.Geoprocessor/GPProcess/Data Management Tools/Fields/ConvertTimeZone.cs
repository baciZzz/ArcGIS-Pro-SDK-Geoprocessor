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
	/// <para>Convert Time Zone</para>
	/// <para>Converts time values recorded in a date field from one time zone to another time zone.</para>
	/// </summary>
	public class ConvertTimeZone : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input feature class or table that contains the time stamps that will be transformed to a different time zone.</para>
		/// </param>
		/// <param name="InputTimeField">
		/// <para>Input Time Field</para>
		/// <para>The input field that contains the time stamps that will be transformed to a different time zone.</para>
		/// </param>
		/// <param name="InputTimeZone">
		/// <para>Input Time Zone</para>
		/// <para>The input time zone in which the time stamps were collected.</para>
		/// </param>
		/// <param name="OutputTimeField">
		/// <para>Output Time Field</para>
		/// <para>The output field in which the time stamps transformed to the desired output time zone will be stored.</para>
		/// </param>
		/// <param name="OutputTimeZone">
		/// <para>Output Time Zone</para>
		/// <para>The time zone to which the time stamps will be transformed. By default, the output time zone is the same as the input time zone.</para>
		/// </param>
		public ConvertTimeZone(object InTable, object InputTimeField, object InputTimeZone, object OutputTimeField, object OutputTimeZone)
		{
			this.InTable = InTable;
			this.InputTimeField = InputTimeField;
			this.InputTimeZone = InputTimeZone;
			this.OutputTimeField = OutputTimeField;
			this.OutputTimeZone = OutputTimeZone;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Time Zone</para>
		/// </summary>
		public override string DisplayName => "Convert Time Zone";

		/// <summary>
		/// <para>Tool Name : ConvertTimeZone</para>
		/// </summary>
		public override string ToolName => "ConvertTimeZone";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertTimeZone</para>
		/// </summary>
		public override string ExcuteName => "management.ConvertTimeZone";

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
		public override object[] Parameters => new object[] { InTable, InputTimeField, InputTimeZone, OutputTimeField, OutputTimeZone, InputDst, OutputDst, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input feature class or table that contains the time stamps that will be transformed to a different time zone.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Time Field</para>
		/// <para>The input field that contains the time stamps that will be transformed to a different time zone.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object InputTimeField { get; set; }

		/// <summary>
		/// <para>Input Time Zone</para>
		/// <para>The input time zone in which the time stamps were collected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputTimeZone { get; set; } = "Pacific_Standard_Time";

		/// <summary>
		/// <para>Output Time Field</para>
		/// <para>The output field in which the time stamps transformed to the desired output time zone will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTimeField { get; set; }

		/// <summary>
		/// <para>Output Time Zone</para>
		/// <para>The time zone to which the time stamps will be transformed. By default, the output time zone is the same as the input time zone.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputTimeZone { get; set; } = "UTC";

		/// <summary>
		/// <para>Input time field values are adjusted for Daylight Saving Time</para>
		/// <para>Indicates whether the time stamps were collected while observing Daylight Saving Time rules in the input time zone. When reading the time values to convert the time zone, the time values will be adjusted to account for the shift in time during Daylight Saving Time.</para>
		/// <para>By default, this option is checked and the input time values are adjusted to account for the shift in time due to the Daylight Saving Time rules observed in the input time zone.</para>
		/// <para>Checked—The input time values are adjusted for Daylight Saving Time.</para>
		/// <para>Unchecked—The input time values are not adjusted for Daylight Saving Time.</para>
		/// <para><see cref="InputDstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Daylight Saving Time")]
		public object InputDst { get; set; } = "true";

		/// <summary>
		/// <para>Output time field values are adjusted for Daylight Saving Time</para>
		/// <para>Indicates whether the output time values will account for the shift in time due to the Daylight Saving Time rules observed in the output time zone.</para>
		/// <para>By default, this option is checked and the output time values are adjusted to account for the shift in time due to the Daylight Saving Time rules observed in the output time zone.</para>
		/// <para>Checked—The output time values are adjusted for Daylight Saving Time in the output time zone.</para>
		/// <para>Unchecked—The output time values are not adjusted for Daylight Saving Time in the output time zone.</para>
		/// <para><see cref="OutputDstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Daylight Saving Time")]
		public object OutputDst { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertTimeZone SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input time field values are adjusted for Daylight Saving Time</para>
		/// </summary>
		public enum InputDstEnum 
		{
			/// <summary>
			/// <para>Checked—The input time values are adjusted for Daylight Saving Time.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INPUT_ADJUSTED_FOR_DST")]
			INPUT_ADJUSTED_FOR_DST,

			/// <summary>
			/// <para>Unchecked—The input time values are not adjusted for Daylight Saving Time.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INPUT_NOT_ADJUSTED_FOR_DST")]
			INPUT_NOT_ADJUSTED_FOR_DST,

		}

		/// <summary>
		/// <para>Output time field values are adjusted for Daylight Saving Time</para>
		/// </summary>
		public enum OutputDstEnum 
		{
			/// <summary>
			/// <para>Checked—The output time values are adjusted for Daylight Saving Time in the output time zone.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_ADJUSTED_FOR_DST")]
			OUTPUT_ADJUSTED_FOR_DST,

			/// <summary>
			/// <para>Unchecked—The output time values are not adjusted for Daylight Saving Time in the output time zone.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OUTPUT_NOT_ADJUSTED_FOR_DST")]
			OUTPUT_NOT_ADJUSTED_FOR_DST,

		}

#endregion
	}
}
