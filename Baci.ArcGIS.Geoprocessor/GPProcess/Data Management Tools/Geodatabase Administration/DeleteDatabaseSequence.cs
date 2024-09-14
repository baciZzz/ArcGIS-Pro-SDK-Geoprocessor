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
	/// <para>Delete Database Sequence</para>
	/// <para>删除数据库序列</para>
	/// <para>从地理数据库中删除数据库序列。</para>
	/// </summary>
	public class DeleteDatabaseSequence : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>要从中删除序列的文件地理数据库位置的完整路径，或用于连接到要从中删除序列的企业级地理数据库的数据库连接文件 (.sde)。在数据库连接中指定的用户必须在数据库中具有以下权限：</para>
		/// <para>Db2 - DBADM 权限</para>
		/// <para>Oracle - 必须是序列所有者或具有 DROP ANY SEQUENCE 系统权限</para>
		/// <para>PostgreSQL - 必须是序列所有者</para>
		/// <para>SAP HANA - 必须是标准用户</para>
		/// <para>SQL Server - 在存储序列的数据库方案中具有 ALTER OR CONTROL 权限</para>
		/// </param>
		/// <param name="SeqName">
		/// <para>Sequence Name</para>
		/// <para>要删除的数据库序列的名称。序列删除后，如果从现有自定义应用程序或表达式调用此序列，则其无法用于生成序列 ID。</para>
		/// </param>
		public DeleteDatabaseSequence(object InWorkspace, object SeqName)
		{
			this.InWorkspace = InWorkspace;
			this.SeqName = SeqName;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除数据库序列</para>
		/// </summary>
		public override string DisplayName() => "删除数据库序列";

		/// <summary>
		/// <para>Tool Name : DeleteDatabaseSequence</para>
		/// </summary>
		public override string ToolName() => "DeleteDatabaseSequence";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteDatabaseSequence</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteDatabaseSequence";

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
		public override object[] Parameters() => new object[] { InWorkspace, SeqName, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>要从中删除序列的文件地理数据库位置的完整路径，或用于连接到要从中删除序列的企业级地理数据库的数据库连接文件 (.sde)。在数据库连接中指定的用户必须在数据库中具有以下权限：</para>
		/// <para>Db2 - DBADM 权限</para>
		/// <para>Oracle - 必须是序列所有者或具有 DROP ANY SEQUENCE 系统权限</para>
		/// <para>PostgreSQL - 必须是序列所有者</para>
		/// <para>SAP HANA - 必须是标准用户</para>
		/// <para>SQL Server - 在存储序列的数据库方案中具有 ALTER OR CONTROL 权限</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Sequence Name</para>
		/// <para>要删除的数据库序列的名称。序列删除后，如果从现有自定义应用程序或表达式调用此序列，则其无法用于生成序列 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SeqName { get; set; }

		/// <summary>
		/// <para>Deleted sequence from geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteDatabaseSequence SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
