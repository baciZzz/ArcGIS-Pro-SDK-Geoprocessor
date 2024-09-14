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
	/// <para>将存储在一个字段中的日期和时间值传输到另一个字段。 该工具可用于在不同的字段类型（文本、数字或日期字段）之间进行转换，或将值转换为不同的格式（例如 dd/MM/yy HH:mm:ss 到 yyyy-MM-dd）。</para>
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
		/// <para>包含要转换时间值的字段的图层或表。</para>
		/// </param>
		/// <param name="InputTimeField">
		/// <para>Input Time Field</para>
		/// <para>含有时间值的字段。 字段类型可以是短型、长型、浮点型、双精度、文本或日期。</para>
		/// </param>
		/// <param name="OutputTimeField">
		/// <para>Output Time Field Name</para>
		/// <para>要添加的字段的名称，其将用于存储转换后的时间值。</para>
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
		public override object[] Parameters() => new object[] { InTable, InputTimeField, InputTimeFormat!, OutputTimeField, OutputTimeType!, OutputTimeFormat!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要转换时间值的字段的图层或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Time Field</para>
		/// <para>含有时间值的字段。 字段类型可以是短型、长型、浮点型、双精度、文本或日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object InputTimeField { get; set; }

		/// <summary>
		/// <para>Input Time Format</para>
		/// <para>输入时间字段参数值中时间值的格式。 可从下拉列表中选择标准时间格式，也可以指定自定义格式。 当输入时间字段为日期类型时，不支持该参数。</para>
		/// <para>格式字符串区分大小写。</para>
		/// <para>如果时间字段的数据类型为日期，则不需要时间格式。</para>
		/// <para>如果时间字段的数据类型是数值（短整型、长整型、浮点型或双精度），将在下拉列表中提供标准数值时间格式。</para>
		/// <para>如果时间字段的数据类型是字符串，将在下拉列表中提供标准字符串时间格式。 如果使用字符串字段，您也可以为其指定自定义时间格式。 例如，可采用标准格式将时间值存储在字符串字段中，如 yyyy/MM/dd HH:mm:ss 或以自定义格式存储，如 dd/MM/yyyy HH:mm:ss。 如果使用自定义格式，您还可以指定 a.m. 或 p.m. 指示符。 以下列出了部分常用格式：</para>
		/// <para>yyyy - 年，以四位数表示。</para>
		/// <para>MM - 数字形式的月份，个位数月份有前导零。</para>
		/// <para>MMM - 月，以三个字母的缩略形式表示。</para>
		/// <para>dd - 数字形式的每月日期，且单位数日期具有前导零。</para>
		/// <para>ddd - 星期，以三个字母的缩略形式表示。</para>
		/// <para>hh - 小时，且单位数小时具有前导零；12 小时制。</para>
		/// <para>HH - 小时，且单位数小时具有前导零；24 小时制。</para>
		/// <para>mm - 分钟，且单位数分钟有前导零。</para>
		/// <para>ss - 秒，且单位数秒有前导零。</para>
		/// <para>t - 单字符时间标记字符串，例如，A 或 P。</para>
		/// <para>tt - 多字符时间标记字符串，例如，AM 或 PM。</para>
		/// <para>unix_us - Unix 时间，以微秒为单位。</para>
		/// <para>unix_ms - Unix 时间，以毫秒为单位。</para>
		/// <para>unix_s - Unix 时间，以秒为单位。</para>
		/// <para>unix_hex - 以十六进制表示的 Unix 时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InputTimeFormat { get; set; }

		/// <summary>
		/// <para>Output Time Field Name</para>
		/// <para>要添加的字段的名称，其将用于存储转换后的时间值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTimeField { get; set; }

		/// <summary>
		/// <para>Output Time Field Type</para>
		/// <para>指定输出时间字段的字段类型。</para>
		/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
		/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
		/// <para>长整型（32 位整型）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>短整型（16 位整型）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>双精度型（64 位浮点型）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>浮点型（32 位浮点型）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para><see cref="OutputTimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputTimeType { get; set; } = "DATE";

		/// <summary>
		/// <para>Output Time Format</para>
		/// <para>输出时间值的格式。 支持的输出时间格式取决于输出时间字段类型参数值。 自定义格式还可用于将值转换为不同格式或提取值的一部分（例如年份）。 有关自定义格式的列表，请参阅输入时间格式参数帮助。 当输出时间字段类型参数值为日期时，不使用此参数。</para>
		/// <para>如果输出时间字段的数据类型长度不足以存储转换的时间值，将会截断输出值。</para>
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
		public ConvertTimeField SetEnviroment(object? workspace = null)
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
			/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本")]
			Text,

			/// <summary>
			/// <para>长整型（32 位整型）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（32 位整型）")]
			LONG,

			/// <summary>
			/// <para>短整型（16 位整型）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（16 位整型）")]
			SHORT,

			/// <summary>
			/// <para>双精度型（64 位浮点型）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型（64 位浮点型）")]
			DOUBLE,

			/// <summary>
			/// <para>浮点型（32 位浮点型）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型（32 位浮点型）")]
			FLOAT,

		}

#endregion
	}
}
