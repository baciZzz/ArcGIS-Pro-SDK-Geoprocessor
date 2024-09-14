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
	/// <para>转换时间字段</para>
	/// <para>将存储在字符串或数值字段中的时间值转换为日期字段。此工具也可用于将以字符串、数值或日期字段形式存储的时间值转换为如一周中周几或一年中第几个月等自定义格式。</para>
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
		/// <para>包含着含有要转换的时间值的字段的图层或表。</para>
		/// </param>
		/// <param name="InputTimeField">
		/// <para>Input Time Field</para>
		/// <para>含有时间值的字段。可能的类型有短整型、长整型、浮点型、双精度、文本或日期。</para>
		/// </param>
		/// <param name="OutputTimeField">
		/// <para>Output Time Field</para>
		/// <para>用于要存储转换的时间值的输出字段的名称。</para>
		/// </param>
		public ConvertTimeField(object InTable, object InputTimeField, object OutputTimeField)
		{
			this.InTable = InTable;
			this.InputTimeField = InputTimeField;
			this.OutputTimeField = OutputTimeField;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换时间字段</para>
		/// </summary>
		public override string DisplayName() => "转换时间字段";

		/// <summary>
		/// <para>Tool Name : ConvertTimeField</para>
		/// </summary>
		public override string ToolName() => "ConvertTimeField";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertTimeField</para>
		/// </summary>
		public override string ExcuteName() => "management.ConvertTimeField";

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
		public override object[] Parameters() => new object[] { InTable, InputTimeField, InputTimeFormat, OutputTimeField, OutputTimeType, OutputTimeFormat, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含着含有要转换的时间值的字段的图层或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Time Field</para>
		/// <para>含有时间值的字段。可能的类型有短整型、长整型、浮点型、双精度、文本或日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object InputTimeField { get; set; }

		/// <summary>
		/// <para>Input Time Format</para>
		/// <para>输入时间字段中的时间值所使用的存储格式。可以从下拉列表中选择标准时间格式，也可以输入自定义格式。格式字符串区分大小写。</para>
		/// <para>如果时间字段的数据类型为日期，则不需要时间格式。</para>
		/// <para>如果时间字段的数据类型是数值（短整型、长整型、浮点型或双精度），将在下拉列表中提供标准数值时间格式。</para>
		/// <para>如果时间字段的数据类型是字符串，将在下拉列表中提供标准字符串时间格式。对于字符串字段来说，您也可以选择为其指定自定义时间格式。例如，可采用标准格式将时间值存储在字符串字段中，如 yyyy/MM/dd HH:mm:ss 或以自定义格式存储，如 dd/MM/yyyy HH:mm:ss。如果使用自定义格式，您还可以指定 a.m.、p.m. 指示符。以下列出了部分常用格式：</para>
		/// <para>yyyy - 年，以四位数表示。</para>
		/// <para>MM - 数字形式的月，且个位数有前导零。</para>
		/// <para>MMM - 月，以三个字母的缩略形式表示。</para>
		/// <para>dd - 数字形式的每月日期，且个位数有前导零。</para>
		/// <para>ddd - 星期，以三个字母的缩略形式表示。</para>
		/// <para>hh - 小时，且个位数小时具有前导零；12 小时制。</para>
		/// <para>HH - 小时，且个位数小时具有前导零；24 小时制。</para>
		/// <para>mm - 分钟，且个位数分钟有前导零。</para>
		/// <para>ss - 秒，且个位数秒有前导零。</para>
		/// <para>t - 单字符时间标记字符串，例如，A 或 P。</para>
		/// <para>tt - 多字符时间标记字符串，例如，AM 或 PM。</para>
		/// <para>unix_us - Unix 时间，以微秒为单位。</para>
		/// <para>unix_ms - Unix 时间，以毫秒为单位。</para>
		/// <para>unix_s - Unix 时间，以秒为单位。</para>
		/// <para>unix_hex - 以十六进制表示的 Unix 时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object InputTimeFormat { get; set; }

		/// <summary>
		/// <para>Output Time Field</para>
		/// <para>用于要存储转换的时间值的输出字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTimeField { get; set; }

		/// <summary>
		/// <para>Output Time Type</para>
		/// <para>输出时间字段的数据类型。</para>
		/// <para>日期—日期和/或时间</para>
		/// <para>文本—任何字符串</para>
		/// <para>长整型（大整数）—介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>短整型（小整数）—介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>双精度（双精度）—介于 -2.2E308 和 1.8E308 之间的小数</para>
		/// <para>浮点型（单精度）—介于 -3.4E38 和 1.2E38 之间的小数</para>
		/// <para><see cref="OutputTimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputTimeType { get; set; } = "DATE";

		/// <summary>
		/// <para>Output Time Format</para>
		/// <para>保存输出时间值时使用的格式。输出时间格式列表取决于为输出时间字段指定的输出数据类型。如果输出时间字段的数据类型不是日期，也可以使用自定义格式。有关自定义格式的列表，请参阅“输入时间格式”的说明。如果输出时间字段的数据类型长度不足以存储转换的时间值，将会截断输出值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutputTimeFormat { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertTimeField SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Time Type</para>
		/// </summary>
		public enum OutputTimeTypeEnum 
		{
			/// <summary>
			/// <para>日期—日期和/或时间</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>文本—任何字符串</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本")]
			Text,

			/// <summary>
			/// <para>长整型（大整数）—介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（大整数）")]
			LONG,

			/// <summary>
			/// <para>短整型（小整数）—介于 -32,768 和 32,767 之间的整数。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（小整数）")]
			SHORT,

			/// <summary>
			/// <para>双精度（双精度）—介于 -2.2E308 和 1.8E308 之间的小数</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度（双精度）")]
			DOUBLE,

			/// <summary>
			/// <para>浮点型（单精度）—介于 -3.4E38 和 1.2E38 之间的小数</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型（单精度）")]
			FLOAT,

		}

#endregion
	}
}
