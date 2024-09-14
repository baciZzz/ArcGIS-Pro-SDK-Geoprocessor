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
	/// <para>Delete Field Group</para>
	/// <para>删除字段组</para>
	/// <para>用于从表或要素类中删除字段组。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteFieldGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>将删除字段组的输入地理数据库要素类或表。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Field Group Name</para>
		/// <para>将删除的字段组的名称。</para>
		/// </param>
		public DeleteFieldGroup(object TargetTable, object Name)
		{
			this.TargetTable = TargetTable;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除字段组</para>
		/// </summary>
		public override string DisplayName() => "删除字段组";

		/// <summary>
		/// <para>Tool Name : DeleteFieldGroup</para>
		/// </summary>
		public override string ToolName() => "DeleteFieldGroup";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteFieldGroup</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteFieldGroup";

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
		public override object[] Parameters() => new object[] { TargetTable, Name, OutTable! };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>将删除字段组的输入地理数据库要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Group Name</para>
		/// <para>将删除的字段组的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteFieldGroup SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
