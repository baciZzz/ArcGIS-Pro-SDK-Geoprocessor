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
	/// <para>Calculate Field</para>
	/// <para>计算字段</para>
	/// <para>计算要素类、要素图层或栅格的字段值。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含将使用新计算更新的字段的表。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field Name (Existing or New)</para>
		/// <para>将使用新计算更新的字段。</para>
		/// <para>如果输入表中不存在具有指定名称的字段，则会添加该字段。</para>
		/// </param>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>用于创建将填充所选行的值的简单计算表达式。</para>
		/// </param>
		public CalculateField(object InTable, object Field, object Expression)
		{
			this.InTable = InTable;
			this.Field = Field;
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算字段</para>
		/// </summary>
		public override string DisplayName() => "计算字段";

		/// <summary>
		/// <para>Tool Name : CalculateField</para>
		/// </summary>
		public override string ToolName() => "CalculateField";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateField</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateField";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Field, Expression, ExpressionType!, CodeBlock!, OutTable!, FieldType!, EnforceDomains! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含将使用新计算更新的字段的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name (Existing or New)</para>
		/// <para>将使用新计算更新的字段。</para>
		/// <para>如果输入表中不存在具有指定名称的字段，则会添加该字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Geometry", "GUID")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于创建将填充所选行的值的简单计算表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Expression Type</para>
		/// <para>指定要使用的表达式类型。</para>
		/// <para>Python 3—将使用 Python 表达式类型。 这是默认设置。</para>
		/// <para>Arcade—将使用 Arcade 表达式类型。</para>
		/// <para>SQL—将使用 SQL 表达式类型。</para>
		/// <para>要了解有关 Python 表达式的详细信息，请参阅计算字段 Python 示例。</para>
		/// <para>要了解有关 Arcade 表达式的详细信息，请参阅 ArcGIS Arcade 指南。</para>
		/// <para>要了解有关 SQL 表达式的详细信息，请参阅计算字段值。</para>
		/// <para>SQL 表达式可用于加快要素服务和企业级地理数据库的计算速度。 使用该表达式可以将单次请求发送到服务器或数据库，而不必一次执行一个要素或一行的计算，从而显著提高计算速度。</para>
		/// <para>仅要素服务和企业级地理数据库支持 SQL 表达式。 对于其他格式，请使用 Python 或 Arcade 表达式。</para>
		/// <para><see cref="ExpressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExpressionType { get; set; } = "PYTHON3";

		/// <summary>
		/// <para>Code Block</para>
		/// <para>将为复杂表达式输入的代码块。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? CodeBlock { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定新字段的字段类型。 仅当输入表中不存在字段名称时才使用此参数。</para>
		/// <para>如果字段类型是文本，则新字段的长度为 512。 对于 shapefile 和 dBASE 文件，该字段的长度为 254。 可以使用更改字段工具调整新字段的长度。</para>
		/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
		/// <para>浮点型（32 位浮点型）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para>双精度型（64 位浮点型）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>短整型（16 位整型）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>长整型（32 位整型）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
		/// <para>Blob（二进制数据）—此字段类型将为 BLOB。 BLOB 字段支持存储为长度较长的一系列二进制数的数据。 您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
		/// <para>栅格影像—此字段类型将为栅格。 栅格字段格可在地理数据库中存储栅格数据或者将该数据与地理数据库一同存储。 可以存储 ArcGIS 软件支持的所有栅格数据集格式，但建议您仅使用小影像。</para>
		/// <para>GUID（全局唯一标识符）—此字段类型将为 GUID。 GUID 字段可存储注册表样式的字符串，该字符串包含用大括号括起来的 36 个字符。</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FieldType { get; set; } = "TEXT";

		/// <summary>
		/// <para>Enforce Domains</para>
		/// <para>指定是否将强制执行字段属性域规则。</para>
		/// <para>选中 - 将强制执行字段属性域规则。 如果某个字段无法更新，则该字段值将保持不变，并且工具消息中将包含一条警告消息。</para>
		/// <para>未选中 - 将不会强制执行字段属性域规则。 这是默认设置</para>
		/// <para><see cref="EnforceDomainsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnforceDomains { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateField SetEnviroment(object? extent = null, bool? transferDomains = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Expression Type</para>
		/// </summary>
		public enum ExpressionTypeEnum 
		{
			/// <summary>
			/// <para>Python 3—将使用 Python 表达式类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("PYTHON3")]
			[Description("Python 3")]
			Python_3,

			/// <summary>
			/// <para>Arcade—将使用 Arcade 表达式类型。</para>
			/// </summary>
			[GPValue("ARCADE")]
			[Description("Arcade")]
			Arcade,

			/// <summary>
			/// <para>SQL—将使用 SQL 表达式类型。</para>
			/// </summary>
			[GPValue("SQL")]
			[Description("SQL")]
			SQL,

		}

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>文本—此字段类型将为文本类型。 文本字段支持字符串。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本")]
			Text,

			/// <summary>
			/// <para>浮点型（32 位浮点型）—此字段类型将为浮点型。 浮点型字段支持介于 -3.4E38 和 1.2E38 之间的小数。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型（32 位浮点型）")]
			FLOAT,

			/// <summary>
			/// <para>双精度型（64 位浮点型）—此字段类型将为双精度型。 双精度型字段支持介于 -2.2E308 和 1.8E308 之间的小数。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型（64 位浮点型）")]
			DOUBLE,

			/// <summary>
			/// <para>短整型（16 位整型）—此字段类型将为短整型。 短整型字段支持介于 -32,768 和 32,767 之间的整数。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（16 位整型）")]
			SHORT,

			/// <summary>
			/// <para>长整型（32 位整型）—此字段类型将为长整型。 长整型字段支持介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（32 位整型）")]
			LONG,

			/// <summary>
			/// <para>日期—此字段类型将为日期类型。 日期字段支持日期和时间值。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>Blob（二进制数据）—此字段类型将为 BLOB。 BLOB 字段支持存储为长度较长的一系列二进制数的数据。 您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob（二进制数据）")]
			BLOB,

			/// <summary>
			/// <para>栅格影像—此字段类型将为栅格。 栅格字段格可在地理数据库中存储栅格数据或者将该数据与地理数据库一同存储。 可以存储 ArcGIS 软件支持的所有栅格数据集格式，但建议您仅使用小影像。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格影像")]
			Raster_imagery,

			/// <summary>
			/// <para>GUID（全局唯一标识符）—此字段类型将为 GUID。 GUID 字段可存储注册表样式的字符串，该字符串包含用大括号括起来的 36 个字符。</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID（全局唯一标识符）")]
			GUID,

		}

		/// <summary>
		/// <para>Enforce Domains</para>
		/// </summary>
		public enum EnforceDomainsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENFORCE_DOMAINS")]
			ENFORCE_DOMAINS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ENFORCE_DOMAINS")]
			NO_ENFORCE_DOMAINS,

		}

#endregion
	}
}
