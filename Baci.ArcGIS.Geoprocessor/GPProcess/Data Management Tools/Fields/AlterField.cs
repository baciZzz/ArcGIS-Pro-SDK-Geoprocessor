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
	/// <para>Alter Field</para>
	/// <para>更改字段</para>
	/// <para>重命名字段和字段别名，或更改字段属性。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含待更改字段的输入表或要素类。</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field Name</para>
		/// <para>待更改字段的名称。如果字段为必填字段 (isRequired=true)，则只有字段别名是可更改的。</para>
		/// </param>
		public AlterField(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改字段</para>
		/// </summary>
		public override string DisplayName() => "更改字段";

		/// <summary>
		/// <para>Tool Name : AlterField</para>
		/// </summary>
		public override string ToolName() => "AlterField";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterField</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterField";

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
		public override object[] Parameters() => new object[] { InTable, Field, NewFieldName, NewFieldAlias, FieldType, FieldLength, FieldIsNullable, ClearFieldAlias, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含待更改字段的输入表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain(HideJoinedLayers = true, ShowOnlyStandaloneTables = false)]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>待更改字段的名称。如果字段为必填字段 (isRequired=true)，则只有字段别名是可更改的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object Field { get; set; }

		/// <summary>
		/// <para>New Field Name</para>
		/// <para>字段的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewFieldName { get; set; }

		/// <summary>
		/// <para>New Field Alias</para>
		/// <para>字段的新字段别名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewFieldAlias { get; set; }

		/// <summary>
		/// <para>New Field Type</para>
		/// <para>指定字段的新字段类型。此属性仅在输入表为空（不包括记录）的情况下适用。</para>
		/// <para>文本—任何字符串。</para>
		/// <para>浮点型（单精度）— 在 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para>双精度型（双精度）— 在 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>短整型（小整数）— 在 -32,768 和 32,767 之间的整数。</para>
		/// <para>长整型（大整数）— 在 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>日期类型—日期和/或时间。</para>
		/// <para>Blob（二进制数据）—长二进制数序列。您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
		/// <para>栅格影像—栅格影像。可以存储 ArcGIS 软件支持的所有栅格数据集格式，但强烈建议您仅使用小影像。</para>
		/// <para>GUID（全局唯一标识符）—全局唯一标识符。</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>New Field Length</para>
		/// <para>字段的新长度。它为字段的每条记录设置最大允许字符数。此选项仅适用于 Text 或 Blob（二进制数据）类型的字段。如果表为空，则可以增加或减少字段长度。如果表不为空，则仅可在当前值的基础上增加长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object FieldLength { get; set; }

		/// <summary>
		/// <para>New Field IsNullable</para>
		/// <para>指定该字段是否可包含空值。只有地理数据库中的字段支持空值。此选项仅在表为空（不包括记录）的情况下适用。</para>
		/// <para>选中 - 字段将允许空值。这是默认设置。</para>
		/// <para>取消选中 - 字段不允许空值。</para>
		/// <para><see cref="FieldIsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FieldIsNullable { get; set; } = "true";

		/// <summary>
		/// <para>Clear Alias</para>
		/// <para>指定是否清除输入字段的别名。要清除字段别名，字段别名参数必须为空。</para>
		/// <para>选中 - 将清除字段别名（设为空值）。字段别名参数必须为空。</para>
		/// <para>未选中 - 不会清除字段别名。这是默认设置。</para>
		/// <para><see cref="ClearFieldAliasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClearFieldAlias { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterField SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>New Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>文本—任何字符串。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本")]
			Text,

			/// <summary>
			/// <para>浮点型（单精度）— 在 -3.4E38 和 1.2E38 之间的小数。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型（单精度）")]
			FLOAT,

			/// <summary>
			/// <para>双精度型（双精度）— 在 -2.2E308 和 1.8E308 之间的小数。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型（双精度）")]
			DOUBLE,

			/// <summary>
			/// <para>短整型（小整数）— 在 -32,768 和 32,767 之间的整数。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("短整型（小整数）")]
			SHORT,

			/// <summary>
			/// <para>长整型（大整数）— 在 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("长整型（大整数）")]
			LONG,

			/// <summary>
			/// <para>日期类型—日期和/或时间。</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期类型")]
			Date,

			/// <summary>
			/// <para>Blob（二进制数据）—长二进制数序列。您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob（二进制数据）")]
			BLOB,

			/// <summary>
			/// <para>栅格影像—栅格影像。可以存储 ArcGIS 软件支持的所有栅格数据集格式，但强烈建议您仅使用小影像。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格影像")]
			Raster_imagery,

			/// <summary>
			/// <para>GUID（全局唯一标识符）—全局唯一标识符。</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID（全局唯一标识符）")]
			GUID,

		}

		/// <summary>
		/// <para>New Field IsNullable</para>
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
		/// <para>Clear Alias</para>
		/// </summary>
		public enum ClearFieldAliasEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_ALIAS")]
			CLEAR_ALIAS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR")]
			DO_NOT_CLEAR,

		}

#endregion
	}
}
