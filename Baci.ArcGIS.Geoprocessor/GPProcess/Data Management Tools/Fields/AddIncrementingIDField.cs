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
	/// <para>Add Incrementing ID Field</para>
	/// <para>添加递增 ID 字段</para>
	/// <para>将向 Dameng、IBM Db2、Microsoft Azure SQL Database、Microsoft SQL Server、Oracle 或 PostgreSQL 数据库中的现有表或要素类中添加由数据库维护的 ID 字段。计划通过要素服务编辑的所有要素类或表都需要数据库维护的 ID 字段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddIncrementingIDField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>将添加 ID 字段的表或要素类的位置和名称。</para>
		/// </param>
		public AddIncrementingIDField(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加递增 ID 字段</para>
		/// </summary>
		public override string DisplayName() => "添加递增 ID 字段";

		/// <summary>
		/// <para>Tool Name : AddIncrementingIDField</para>
		/// </summary>
		public override string ToolName() => "AddIncrementingIDField";

		/// <summary>
		/// <para>Tool Excute Name : management.AddIncrementingIDField</para>
		/// </summary>
		public override string ExcuteName() => "management.AddIncrementingIDField";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, FieldName!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将添加 ID 字段的表或要素类的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPTablesDomain(HideJoinedLayers = true, ShowOnlyStandaloneTables = false)]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>将要用于 ID 字段的名称。如果未提供输入，则将使用默认值 ObjectID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FieldName { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

	}
}
