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
	/// <para>Make Query Table</para>
	/// <para>创建查询表</para>
	/// <para>可对数据库应用 SQL 查询，并在图层或表视图中表示结果。 查询可用于连接多个表或返回数据库的原始数据中的字段或行的子集。</para>
	/// </summary>
	public class MakeQueryTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Tables</para>
		/// <para>要在查询中使用的一个表或多个表的名称。 如果列出多个表，表达式参数可用于定义这些表的连接方式。</para>
		/// <para>输入表可来自地理数据库或数据库连接。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Table Name</para>
		/// <para>将创建的图层或表视图的名称。</para>
		/// </param>
		/// <param name="InKeyFieldOption">
		/// <para>Key Field Options</para>
		/// <para>指定将如何针对查询生成 ObjectID 字段（如果存在）。 ArcGIS 中的图层和表视图需要 ObjectID 字段。 ObjectID 字段是一个整型字段，用于唯一标识正在使用的数据中的行。 默认字段是使用关键字段（Python 中的 USE_KEY_FIELDS）。</para>
		/// <para>使用关键字段—在关键字段参数中的指定字段将用于唯一标识输出表中的行。 该字段可以是单一字段也可以是多个字段，合并后可唯一标识输出表中的行。 如果未在关键字段列表中未指定任何字段，则会自动应用生成关键字段选项（Python 中的 ADD VIRTUAL_KEY_FIELD）。</para>
		/// <para>生成关键字段—如果未指定任何关键字段，则将生成唯一标识输出表中每一行的 ObjectID。</para>
		/// <para>无关键字段—不会生成任何 ObjectID 字段。 表视图将不支持选择。如果字段列表中已经存在 ObjectID 类型的字段，那么即使选择此选项，也仍会将该列用作 ObjectID。</para>
		/// <para><see cref="InKeyFieldOptionEnum"/></para>
		/// </param>
		public MakeQueryTable(object InTable, object OutTable, object InKeyFieldOption)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.InKeyFieldOption = InKeyFieldOption;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建查询表</para>
		/// </summary>
		public override string DisplayName() => "创建查询表";

		/// <summary>
		/// <para>Tool Name : MakeQueryTable</para>
		/// </summary>
		public override string ToolName() => "MakeQueryTable";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeQueryTable</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeQueryTable";

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
		public override object[] Parameters() => new object[] { InTable, OutTable, InKeyFieldOption, InKeyField!, InField!, WhereClause! };

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>要在查询中使用的一个表或多个表的名称。 如果列出多个表，表达式参数可用于定义这些表的连接方式。</para>
		/// <para>输入表可来自地理数据库或数据库连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[xmlserialize(Xml = "<GPVirtualTableDomain xsi:type='typens:GPVirtualTableDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPVirtualTableDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Table Name</para>
		/// <para>将创建的图层或表视图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Key Field Options</para>
		/// <para>指定将如何针对查询生成 ObjectID 字段（如果存在）。 ArcGIS 中的图层和表视图需要 ObjectID 字段。 ObjectID 字段是一个整型字段，用于唯一标识正在使用的数据中的行。 默认字段是使用关键字段（Python 中的 USE_KEY_FIELDS）。</para>
		/// <para>使用关键字段—在关键字段参数中的指定字段将用于唯一标识输出表中的行。 该字段可以是单一字段也可以是多个字段，合并后可唯一标识输出表中的行。 如果未在关键字段列表中未指定任何字段，则会自动应用生成关键字段选项（Python 中的 ADD VIRTUAL_KEY_FIELD）。</para>
		/// <para>生成关键字段—如果未指定任何关键字段，则将生成唯一标识输出表中每一行的 ObjectID。</para>
		/// <para>无关键字段—不会生成任何 ObjectID 字段。 表视图将不支持选择。如果字段列表中已经存在 ObjectID 类型的字段，那么即使选择此选项，也仍会将该列用作 ObjectID。</para>
		/// <para><see cref="InKeyFieldOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InKeyFieldOption { get; set; } = "USE_KEY_FIELDS";

		/// <summary>
		/// <para>Key Fields</para>
		/// <para>将用于唯一识别查询中的一行的字段或字段组合。 此参数仅在将关键字段选项参数设置为使用关键字段时使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain(GUID = "{74F6B060-5EB6-4851-8FFD-8B188A845F37}")]
		public object? InKeyField { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>要包含在图层或表视图中的字段。 如果为字段设置了一个别名，则这个别名就是显示的名称。 如果未指定任何字段，则将包含所有表中的所有字段。 如果将 Shape 字段添加到字段列表，结果将为图层，否则将为表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? InField { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeQueryTable SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Key Field Options</para>
		/// </summary>
		public enum InKeyFieldOptionEnum 
		{
			/// <summary>
			/// <para>使用关键字段—在关键字段参数中的指定字段将用于唯一标识输出表中的行。 该字段可以是单一字段也可以是多个字段，合并后可唯一标识输出表中的行。 如果未在关键字段列表中未指定任何字段，则会自动应用生成关键字段选项（Python 中的 ADD VIRTUAL_KEY_FIELD）。</para>
			/// </summary>
			[GPValue("USE_KEY_FIELDS")]
			[Description("使用关键字段")]
			Use_key_fields,

			/// <summary>
			/// <para>生成关键字段—如果未指定任何关键字段，则将生成唯一标识输出表中每一行的 ObjectID。</para>
			/// </summary>
			[GPValue("ADD_VIRTUAL_KEY_FIELD")]
			[Description("生成关键字段")]
			Generate_a_key_field,

			/// <summary>
			/// <para>无关键字段—不会生成任何 ObjectID 字段。 表视图将不支持选择。如果字段列表中已经存在 ObjectID 类型的字段，那么即使选择此选项，也仍会将该列用作 ObjectID。</para>
			/// </summary>
			[GPValue("NO_KEY_FIELD")]
			[Description("无关键字段")]
			No_key_field,

		}

#endregion
	}
}
