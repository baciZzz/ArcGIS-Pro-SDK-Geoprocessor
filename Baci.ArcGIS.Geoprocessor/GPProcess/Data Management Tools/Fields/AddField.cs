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
	/// <para>Add Field</para>
	/// <para>添加字段</para>
	/// <para>将新字段添加到表、要素类或要素图层表以及带属性表的栅格。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要添加指定字段的输入表。 字段将被添加到现有输入表，并且不会创建新的输出表。</para>
		/// <para>可将字段添加到地理数据库中的要素类、shapefile、coverage、独立表、栅格目录、带属性表的栅格和图层。</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>将添加到输入表的字段的名称。</para>
		/// </param>
		/// <param name="FieldType">
		/// <para>Field Type</para>
		/// <para>指定新字段的字段类型。</para>
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
		/// </param>
		public AddField(object InTable, object FieldName, object FieldType)
		{
			this.InTable = InTable;
			this.FieldName = FieldName;
			this.FieldType = FieldType;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加字段</para>
		/// </summary>
		public override string DisplayName() => "添加字段";

		/// <summary>
		/// <para>Tool Name : AddField</para>
		/// </summary>
		public override string ToolName() => "AddField";

		/// <summary>
		/// <para>Tool Excute Name : management.AddField</para>
		/// </summary>
		public override string ExcuteName() => "management.AddField";

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
		public override object[] Parameters() => new object[] { InTable, FieldName, FieldType, FieldPrecision!, FieldScale!, FieldLength!, FieldAlias!, FieldIsNullable!, FieldIsRequired!, FieldDomain!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要添加指定字段的输入表。 字段将被添加到现有输入表，并且不会创建新的输出表。</para>
		/// <para>可将字段添加到地理数据库中的要素类、shapefile、coverage、独立表、栅格目录、带属性表的栅格和图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>将添加到输入表的字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定新字段的字段类型。</para>
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
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>Field Precision</para>
		/// <para>可存储在字段中的位数。 所有位数都被计算在内，无论其位于小数点的哪一侧。</para>
		/// <para>此参数仅适用于 float、double、short 或 long 类型的字段。</para>
		/// <para>如果输入表是文件地理数据库，则将忽略字段精度值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldPrecision { get; set; }

		/// <summary>
		/// <para>Field Scale</para>
		/// <para>可存储在字段中的小数位数。</para>
		/// <para>此参数仅适用于 float 或 double 类型的字段。</para>
		/// <para>如果输入表是文件地理数据库，则将忽略字段小数位数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldScale { get; set; }

		/// <summary>
		/// <para>Field Length</para>
		/// <para>字段长度。 它为字段的每条记录设置最大允许字符数。</para>
		/// <para>此参数仅适用于文本类型的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldLength { get; set; }

		/// <summary>
		/// <para>Field Alias</para>
		/// <para>字段名称的备用名称。 此名称用于描述含义隐晦的字段名称。 此参数仅适用于地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FieldAlias { get; set; }

		/// <summary>
		/// <para>Field supports null values</para>
		/// <para>指定该字段是否可包含空值。 空值不同于零字段或空字段，仅支持地理数据库中的字段。</para>
		/// <para>选中 - 字段可包含空值。 这是默认设置。</para>
		/// <para>未选中 - 字段不可包含空值。</para>
		/// <para><see cref="FieldIsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FieldIsNullable { get; set; } = "true";

		/// <summary>
		/// <para>Field is required</para>
		/// <para>指定要创建的字段是否是表的必填字段。 必填字段仅在地理数据库中受支持。</para>
		/// <para>选中 – 此字段是必填字段。 必填字段具有永久性，不能删除。</para>
		/// <para>取消选中 – 此字段不是必填字段。 这是默认设置。</para>
		/// <para><see cref="FieldIsRequiredEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FieldIsRequired { get; set; } = "false";

		/// <summary>
		/// <para>Field Domain</para>
		/// <para>约束地理数据库中的表、要素类或子类型的任何特定属性的允许值。 您必须指定现有属性域的名称才能将其应用于该字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FieldDomain { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddField SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

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
		/// <para>Field supports null values</para>
		/// </summary>
		public enum FieldIsNullableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NULLABLE")]
			NULLABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_NULLABLE")]
			NON_NULLABLE,

		}

		/// <summary>
		/// <para>Field is required</para>
		/// </summary>
		public enum FieldIsRequiredEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRED")]
			REQUIRED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_REQUIRED")]
			NON_REQUIRED,

		}

#endregion
	}
}
