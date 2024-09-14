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
	/// <para>转换时区</para>
	/// <para>将日期字段中所记录的时间值从一个时区转换到另一个时区。</para>
	/// </summary>
	public class ConvertTimeZone : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含时间戳的输入要素类或表将变换到其他时区。</para>
		/// </param>
		/// <param name="InputTimeField">
		/// <para>Input Time Field</para>
		/// <para>包含时间戳的输入字段将变换到其他时区。</para>
		/// </param>
		/// <param name="InputTimeZone">
		/// <para>Input Time Zone</para>
		/// <para>获得时间戳的输入时区。</para>
		/// </param>
		/// <param name="OutputTimeField">
		/// <para>Output Time Field</para>
		/// <para>存储变换到所需输出时区的时间戳的输出字段。</para>
		/// </param>
		/// <param name="OutputTimeZone">
		/// <para>Output Time Zone</para>
		/// <para>时间戳将要变换到的时区。默认情况下，输出时区与输入时区相同。</para>
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
		/// <para>Tool Display Name : 转换时区</para>
		/// </summary>
		public override string DisplayName() => "转换时区";

		/// <summary>
		/// <para>Tool Name : ConvertTimeZone</para>
		/// </summary>
		public override string ToolName() => "ConvertTimeZone";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertTimeZone</para>
		/// </summary>
		public override string ExcuteName() => "management.ConvertTimeZone";

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
		public override object[] Parameters() => new object[] { InTable, InputTimeField, InputTimeZone, OutputTimeField, OutputTimeZone, InputDst, OutputDst, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含时间戳的输入要素类或表将变换到其他时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Time Field</para>
		/// <para>包含时间戳的输入字段将变换到其他时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object InputTimeField { get; set; }

		/// <summary>
		/// <para>Input Time Zone</para>
		/// <para>获得时间戳的输入时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputTimeZone { get; set; } = "Pacific_Standard_Time";

		/// <summary>
		/// <para>Output Time Field</para>
		/// <para>存储变换到所需输出时区的时间戳的输出字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTimeField { get; set; }

		/// <summary>
		/// <para>Output Time Zone</para>
		/// <para>时间戳将要变换到的时区。默认情况下，输出时区与输入时区相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputTimeZone { get; set; } = "UTC";

		/// <summary>
		/// <para>Input time field values are adjusted for Daylight Saving Time</para>
		/// <para>指示是否在输入时区中按照“夏令时”规则收集时间戳。在读取时间值进行时区转换时，将调整时间值以反映“夏令时”期间的时间变更。</para>
		/// <para>默认情况下此选项处于选中状态，输入时间值会进行相应调整，以反映输入时区所采用的“夏令时”规则。</para>
		/// <para>选中 - 按“夏令时”调整输入时间值。</para>
		/// <para>未选中 - 不按“夏令时”调整输入时间值。</para>
		/// <para><see cref="InputDstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Daylight Saving Time")]
		public object InputDst { get; set; } = "true";

		/// <summary>
		/// <para>Output time field values are adjusted for Daylight Saving Time</para>
		/// <para>说明输出时间值是否会反映输出时区中因实行“夏令时”规则而导致的时间变更。</para>
		/// <para>默认情况下此选项处于选中状态，输出时间值会进行相应调整，以反映输出时区所采用的“夏令时”规则。</para>
		/// <para>选中 - 按输出时区中的“夏令时”调整输出时间值。</para>
		/// <para>未选中 - 不按输出时区中的“夏令时”调整输出时间值。</para>
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
		public ConvertTimeZone SetEnviroment(object workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INPUT_ADJUSTED_FOR_DST")]
			INPUT_ADJUSTED_FOR_DST,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_ADJUSTED_FOR_DST")]
			OUTPUT_ADJUSTED_FOR_DST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("OUTPUT_NOT_ADJUSTED_FOR_DST")]
			OUTPUT_NOT_ADJUSTED_FOR_DST,

		}

#endregion
	}
}
