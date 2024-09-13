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
	/// <para>Create Database Sequence</para>
	/// <para>创建数据库序列</para>
	/// <para>在地理数据库中创建数据库序列。可以在访问地理数据库的自定义应用程序中使用序列。</para>
	/// </summary>
	public class CreateDatabaseSequence : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>用于连接到要在其中创建序列的企业级地理数据库的数据库连接文件 (.sde)，或文件地理数据库的路径（包括文件地理数据库名称）。</para>
		/// <para>对于数据库连接，在数据库连接中指定的用户是序列的所有者，因此必须在数据库中具有以下权限：</para>
		/// <para>Db2 - 对其方案的 CREATEIN 权限</para>
		/// <para>Oracle - CREATE SEQUENCE 系统权限</para>
		/// <para>PostgreSQL - 对其方案的权限</para>
		/// <para>SAP HANA - 必须是标准用户</para>
		/// <para>SQL Server - CREATE SEQUENCE 权限以及对其方案的 ALTER OR CONTROL 权限</para>
		/// </param>
		/// <param name="SeqName">
		/// <para>Sequence Name</para>
		/// <para>要分配给数据库序列的名称。对于企业级地理数据库，该名称必须符合当前使用的数据库平台的序列名称要求，并且在数据库中必须唯一。对于文件地理数据库，该名称在文件地理数据库中必须唯一。牢记此名称，因为在自定义应用程序和表达式中调用序列时小使用该名称。</para>
		/// </param>
		public CreateDatabaseSequence(object InWorkspace, object SeqName)
		{
			this.InWorkspace = InWorkspace;
			this.SeqName = SeqName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建数据库序列</para>
		/// </summary>
		public override string DisplayName() => "创建数据库序列";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseSequence</para>
		/// </summary>
		public override string ToolName() => "CreateDatabaseSequence";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseSequence</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateDatabaseSequence";

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
		public override object[] Parameters() => new object[] { InWorkspace, SeqName, SeqStartId!, SeqIncValue!, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>用于连接到要在其中创建序列的企业级地理数据库的数据库连接文件 (.sde)，或文件地理数据库的路径（包括文件地理数据库名称）。</para>
		/// <para>对于数据库连接，在数据库连接中指定的用户是序列的所有者，因此必须在数据库中具有以下权限：</para>
		/// <para>Db2 - 对其方案的 CREATEIN 权限</para>
		/// <para>Oracle - CREATE SEQUENCE 系统权限</para>
		/// <para>PostgreSQL - 对其方案的权限</para>
		/// <para>SAP HANA - 必须是标准用户</para>
		/// <para>SQL Server - CREATE SEQUENCE 权限以及对其方案的 ALTER OR CONTROL 权限</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Sequence Name</para>
		/// <para>要分配给数据库序列的名称。对于企业级地理数据库，该名称必须符合当前使用的数据库平台的序列名称要求，并且在数据库中必须唯一。对于文件地理数据库，该名称在文件地理数据库中必须唯一。牢记此名称，因为在自定义应用程序和表达式中调用序列时小使用该名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SeqName { get; set; }

		/// <summary>
		/// <para>Sequence Start ID</para>
		/// <para>序列的起始编号。如果未提供起始编号，则序列从 1 开始。如果您确实提供了起始编号，则其必须大于 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SeqStartId { get; set; }

		/// <summary>
		/// <para>Sequence Increment Value</para>
		/// <para>描述序号的递增方式。例如，如果序列从 10 开始且增量值为 5，则序列中的下一个值为 15，之后下一个值为 20。如果未指定增量值，则序列增量值将为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SeqIncValue { get; set; }

		/// <summary>
		/// <para>Created sequence in geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseSequence SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
