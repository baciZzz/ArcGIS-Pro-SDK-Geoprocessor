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
	/// <para>Delete Schema Geodatabase</para>
	/// <para>删除方案地理数据库</para>
	/// <para>从 Oracle 用户方案中删除地理数据库。</para>
	/// </summary>
	public class DeleteSchemaGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>将删除用户方案地理数据库的数据库连接文件 (.sde)。您必须以方案所有者的身份进行连接。</para>
		/// </param>
		public DeleteSchemaGeodatabase(object InputDatabase)
		{
			this.InputDatabase = InputDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除方案地理数据库</para>
		/// </summary>
		public override string DisplayName() => "删除方案地理数据库";

		/// <summary>
		/// <para>Tool Name : DeleteSchemaGeodatabase</para>
		/// </summary>
		public override string ToolName() => "DeleteSchemaGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteSchemaGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteSchemaGeodatabase";

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
		public override object[] Parameters() => new object[] { InputDatabase, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>将删除用户方案地理数据库的数据库连接文件 (.sde)。您必须以方案所有者的身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteSchemaGeodatabase SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
