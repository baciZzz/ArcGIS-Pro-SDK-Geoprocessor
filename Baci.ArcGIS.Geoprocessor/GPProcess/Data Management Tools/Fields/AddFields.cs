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
	/// <para>Add Fields (multiple)</para>
	/// <para>添加字段(多个)</para>
	/// <para>将新字段添加到表格、要素类或栅格。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>将添加字段的输入表。字段将被添加到现有输入表，并且不会创建新的输出表。</para>
		/// <para>可将字段添加到地理数据库中的要素类、shapefile、coverage、独立表、栅格目录、带属性表的栅格和图层。</para>
		/// </param>
		/// <param name="FieldDescription">
		/// <para>Field Properties</para>
		/// <para>将添加到输入表的字段及其属性。</para>
		/// <para>字段名称 - 将添加到输入表的字段的名称。</para>
		/// <para>字段类型 - 新字段的类型。</para>
		/// <para>字段别名 - 指定给字段名称的备用名称。此名称用于为含义隐晦的字段名称指定更具描述性的名称。字段别名参数仅适用于地理数据库。</para>
		/// <para>字段长度 - 要添加的字段的长度。它为字段的每条记录设置最大允许字符数。此选项仅适用于文本类型的字段；默认长度为 255。</para>
		/// <para>默认值 - 字段的默认值。</para>
		/// <para>字段域 - 将分配到字段的地理数据库域。</para>
		/// <para>可用字段类型如下：</para>
		/// <para>TEXT - 任何字符串。</para>
		/// <para>FLOAT - 介于 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para>DOUBLE - 介于 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>SHORT - 介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>LONG - 介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>DATE - 日期和/或时间。</para>
		/// <para>BLOB - 长二进制数序列。您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
		/// <para>RASTER - 栅格影像。可以存储 ArcGIS 软件支持的所有栅格数据集格式，但建议您仅使用小影像。</para>
		/// <para>GUID - 全局唯一标识符。</para>
		/// </param>
		public AddFields(object InTable, object FieldDescription)
		{
			this.InTable = InTable;
			this.FieldDescription = FieldDescription;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加字段(多个)</para>
		/// </summary>
		public override string DisplayName() => "添加字段(多个)";

		/// <summary>
		/// <para>Tool Name : AddFields</para>
		/// </summary>
		public override string ToolName() => "AddFields";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFields</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFields";

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
		public override object[] Parameters() => new object[] { InTable, FieldDescription, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将添加字段的输入表。字段将被添加到现有输入表，并且不会创建新的输出表。</para>
		/// <para>可将字段添加到地理数据库中的要素类、shapefile、coverage、独立表、栅格目录、带属性表的栅格和图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Properties</para>
		/// <para>将添加到输入表的字段及其属性。</para>
		/// <para>字段名称 - 将添加到输入表的字段的名称。</para>
		/// <para>字段类型 - 新字段的类型。</para>
		/// <para>字段别名 - 指定给字段名称的备用名称。此名称用于为含义隐晦的字段名称指定更具描述性的名称。字段别名参数仅适用于地理数据库。</para>
		/// <para>字段长度 - 要添加的字段的长度。它为字段的每条记录设置最大允许字符数。此选项仅适用于文本类型的字段；默认长度为 255。</para>
		/// <para>默认值 - 字段的默认值。</para>
		/// <para>字段域 - 将分配到字段的地理数据库域。</para>
		/// <para>可用字段类型如下：</para>
		/// <para>TEXT - 任何字符串。</para>
		/// <para>FLOAT - 介于 -3.4E38 和 1.2E38 之间的小数。</para>
		/// <para>DOUBLE - 介于 -2.2E308 和 1.8E308 之间的小数。</para>
		/// <para>SHORT - 介于 -32,768 和 32,767 之间的整数。</para>
		/// <para>LONG - 介于 -2,147,483,648 和 2,147,483,647 之间的整数。</para>
		/// <para>DATE - 日期和/或时间。</para>
		/// <para>BLOB - 长二进制数序列。您需要一个自定义的加载器、查看器或第三方应用程序将这些项加载到 BLOB 字段中或者查看 BLOB 字段的内容。</para>
		/// <para>RASTER - 栅格影像。可以存储 ArcGIS 软件支持的所有栅格数据集格式，但建议您仅使用小影像。</para>
		/// <para>GUID - 全局唯一标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object FieldDescription { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFields SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
