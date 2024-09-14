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
	/// <para>Add Field Conflict Filter</para>
	/// <para>添加字段冲突过滤器</para>
	/// <para>为地理数据库表或要素类中的给定字段添加字段冲突过滤器。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFieldConflictFilter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Table">
		/// <para>Input Table</para>
		/// <para>表或要素类，其中包含将应用冲突过滤器的字段。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field Name</para>
		/// <para>应用冲突过滤器的字段或字段列表。</para>
		/// </param>
		public AddFieldConflictFilter(object Table, object Fields)
		{
			this.Table = Table;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加字段冲突过滤器</para>
		/// </summary>
		public override string DisplayName() => "添加字段冲突过滤器";

		/// <summary>
		/// <para>Tool Name : AddFieldConflictFilter</para>
		/// </summary>
		public override string ToolName() => "AddFieldConflictFilter";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFieldConflictFilter</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFieldConflictFilter";

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
		public override object[] Parameters() => new object[] { Table, Fields, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>表或要素类，其中包含将应用冲突过滤器的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object Table { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>应用冲突过滤器的字段或字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFieldConflictFilter SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
