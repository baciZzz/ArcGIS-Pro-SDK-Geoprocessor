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
	/// <para>Create Database Connection</para>
	/// <para>创建数据库连接</para>
	/// <para>创建一个 ArcGIS 用来连接到数据库或企业级地理数据库的文件。</para>
	/// </summary>
	public class CreateDatabaseConnection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>Connection File Location</para>
		/// <para>存储数据库连接文件 (.sde) 的文件夹路径。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Connection File Name</para>
		/// <para>数据库连接文件的名称。 输出文件的扩展名将为 .sde。</para>
		/// </param>
		/// <param name="DatabasePlatform">
		/// <para>Database Platform</para>
		/// <para>指定要建立连接的数据库管理系统平台。 有效选项如下：</para>
		/// <para>DAMENG—连接到 Dameng。</para>
		/// <para>Db2—连接至 Linux、UNIX 或 Windows 上的 IBM Db2。</para>
		/// <para>Oracle—连接到 Oracle、Amazon Relational Database Service (RDS) for Oracle 或 Autonomous Transaction Processing。</para>
		/// <para>PostgreSQL—连接到 PostgreSQL、Amazon Aurora (PostgreSQL-compatible edition)、Amazon Relational Database Service (RDS) for PostgreSQL、Microsoft Azure Database for PostgreSQL 或 Google Cloud SQL for PostgreSQL。</para>
		/// <para>SAP HANA—连接到 SAP HANA 或 SAP HANA Cloud。</para>
		/// <para>SQL Server—连接到 Microsoft SQL Server, Microsoft Azure SQL Database、Microsoft Azure SQL Managed Instance、Amazon Relational Database Service (RDS) for SQL Server 或 Google Cloud SQL for SQL Server。</para>
		/// <para>Teradata—连接到 Teradata Data Warehouse Appliance。</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </param>
		/// <param name="Instance">
		/// <para>Instance</para>
		/// <para>要连接的数据库服务器或实例。</para>
		/// <para>从数据库平台下拉列表中选择的值表示将连接的数据库的类型。 根据所选择的连接类型，可为实例参数提供不同的信息。</para>
		/// <para>有关为各个数据库平台提供的内容的详细信息，请参阅下文。</para>
		/// <para>Dameng - 安装 Dameng 数据库的服务器的名称&lt;bold/&gt;</para>
		/// <para>Db2 - 编入目录的 Db2 数据库的名称</para>
		/// <para>Oracle - TNS 名称或用于连接 Oracle 数据库或数据库服务的 Oracle Easy Connection 字符串</para>
		/// <para>PostgreSQL - 安装 PostgreSQL 的服务器名称或 PostgreSQL 数据库服务实例的名称</para>
		/// <para>SAP HANA - SAP HANA 数据库或数据库服务的开放式数据库连通性 (ODBC) 数据源名称</para>
		/// <para>SQL Server - SQL Server 数据库实例的名称或数据库服务实例的名称。</para>
		/// <para>Teradata - Teradata 数据库的 ODBC 数据源名称。</para>
		/// </param>
		public CreateDatabaseConnection(object OutFolderPath, object OutName, object DatabasePlatform, object Instance)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
			this.DatabasePlatform = DatabasePlatform;
			this.Instance = Instance;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建数据库连接</para>
		/// </summary>
		public override string DisplayName() => "创建数据库连接";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseConnection</para>
		/// </summary>
		public override string ToolName() => "CreateDatabaseConnection";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseConnection</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateDatabaseConnection";

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
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, DatabasePlatform, Instance, AccountAuthentication!, Username!, Password!, SaveUserPass!, Database!, Schema!, VersionType!, Version!, Date!, OutWorkspace! };

		/// <summary>
		/// <para>Connection File Location</para>
		/// <para>存储数据库连接文件 (.sde) 的文件夹路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Connection File Name</para>
		/// <para>数据库连接文件的名称。 输出文件的扩展名将为 .sde。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Database Platform</para>
		/// <para>指定要建立连接的数据库管理系统平台。 有效选项如下：</para>
		/// <para>DAMENG—连接到 Dameng。</para>
		/// <para>Db2—连接至 Linux、UNIX 或 Windows 上的 IBM Db2。</para>
		/// <para>Oracle—连接到 Oracle、Amazon Relational Database Service (RDS) for Oracle 或 Autonomous Transaction Processing。</para>
		/// <para>PostgreSQL—连接到 PostgreSQL、Amazon Aurora (PostgreSQL-compatible edition)、Amazon Relational Database Service (RDS) for PostgreSQL、Microsoft Azure Database for PostgreSQL 或 Google Cloud SQL for PostgreSQL。</para>
		/// <para>SAP HANA—连接到 SAP HANA 或 SAP HANA Cloud。</para>
		/// <para>SQL Server—连接到 Microsoft SQL Server, Microsoft Azure SQL Database、Microsoft Azure SQL Managed Instance、Amazon Relational Database Service (RDS) for SQL Server 或 Google Cloud SQL for SQL Server。</para>
		/// <para>Teradata—连接到 Teradata Data Warehouse Appliance。</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatabasePlatform { get; set; }

		/// <summary>
		/// <para>Instance</para>
		/// <para>要连接的数据库服务器或实例。</para>
		/// <para>从数据库平台下拉列表中选择的值表示将连接的数据库的类型。 根据所选择的连接类型，可为实例参数提供不同的信息。</para>
		/// <para>有关为各个数据库平台提供的内容的详细信息，请参阅下文。</para>
		/// <para>Dameng - 安装 Dameng 数据库的服务器的名称&lt;bold/&gt;</para>
		/// <para>Db2 - 编入目录的 Db2 数据库的名称</para>
		/// <para>Oracle - TNS 名称或用于连接 Oracle 数据库或数据库服务的 Oracle Easy Connection 字符串</para>
		/// <para>PostgreSQL - 安装 PostgreSQL 的服务器名称或 PostgreSQL 数据库服务实例的名称</para>
		/// <para>SAP HANA - SAP HANA 数据库或数据库服务的开放式数据库连通性 (ODBC) 数据源名称</para>
		/// <para>SQL Server - SQL Server 数据库实例的名称或数据库服务实例的名称。</para>
		/// <para>Teradata - Teradata 数据库的 ODBC 数据源名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Instance { get; set; }

		/// <summary>
		/// <para>Database Authentication</para>
		/// <para>指定要使用的身份验证类型。</para>
		/// <para>选中 - 将使用数据库身份验证。 将使用内部数据库用户名和密码连接到数据库。 创建连接无需输入用户名和密码；但是，如果不输入用户名和密码，系统将在连接建立好之后提示您输入用户名和密码。</para>
		/// <para>未选中 - 将使用操作系统身份验证。 不必输入用户名和密码。 将用登录操作系统时所使用的用户名和密码建立连接。 如果操作系统使用的登录信息不能用作地理数据库的登录信息，连接将失败。</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AccountAuthentication { get; set; } = "true";

		/// <summary>
		/// <para>Username</para>
		/// <para>将用于数据库身份验证的数据库用户名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>将用于数据库身份验证的数据库用户密码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? Password { get; set; }

		/// <summary>
		/// <para>Save username and password</para>
		/// <para>指定是否将保存用户名和密码。</para>
		/// <para>选中 - 用户名和密码将保存在连接文件中。 这是默认设置。 如果 ArcGIS 服务可通过您所创建的连接文件来对数据库或地理数据库进行访问，或者您想使用目录搜索来查找通过此连接文件访问的数据，您都必须保存用户名和密码。</para>
		/// <para>未选中 - 用户名和密码将不会保存在该连接文件中。 每次试图使用文件进行连接时，系统都将提示您输入用户名和密码。</para>
		/// <para><see cref="SaveUserPassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SaveUserPass { get; set; } = "true";

		/// <summary>
		/// <para>Database</para>
		/// <para>要建立连接的数据库名称。 此参数仅适用于 PostgreSQL 和 SQL Server 平台。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Database { get; set; }

		/// <summary>
		/// <para>Schema (Oracle user schema geodatabases only)</para>
		/// <para>将与之建立连接的用户方案地理数据库。 工具将决定是否连接到包含用户方案地理数据库的 Oracle 数据库。 如果 Oracle 数据库包含用户方案，此选项将激活；否则，将保持非活动状态。 此参数的默认选项为使用 sde 方案理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object? Schema { get; set; }

		/// <summary>
		/// <para>Version Type</para>
		/// <para>指定要建立连接的版本类型。 此参数仅在连接到地理数据库时适用。</para>
		/// <para>事务—连接到事务版本。 如果选择事务，则将使用事务版本的列表填充将使用以下版本参数，而日期和时间参数将禁用。 这是默认设置。</para>
		/// <para>历史—连接到历史标记。 如果选择历史，则将使用历史标记的列表填充将使用以下版本参数，而日期和时间参数将禁用。</para>
		/// <para>时间点—连接到特定时间点。 如果选择时间点，则将使用以下版本参数将禁用，而日期和时间参数将变为活动状态。</para>
		/// <para>分支—连接到默认分支版本。</para>
		/// <para>如果选择历史并提供了名称，将使用默认的事务版本。 如果选择时间点并且未在日期和时间参数中提供日期，将使用默认的事务版本。</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Connection Properties")]
		public object? VersionType { get; set; } = "TRANSACTIONAL";

		/// <summary>
		/// <para>The following version will be used</para>
		/// <para>要与之建立连接的地理数据库事务版本或历史标记。 默认选项将使用默认事务版本。</para>
		/// <para>如果选择分支版本类型，则会始终连接到默认分支版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object? Version { get; set; }

		/// <summary>
		/// <para>Date and Time</para>
		/// <para>此值表示将用于连接到数据库的日期和时间。 此选项用于启用存档的数据。 利用时间选取器选择相应的日期。</para>
		/// <para>如果手动输入日期，可以使用以下格式：</para>
		/// <para>6/9/2011 4:20:15 PM</para>
		/// <para>6/9/2011 16:20:15</para>
		/// <para>6/9/2011</para>
		/// <para>4:20:15 PM</para>
		/// <para>16:20:15</para>
		/// <para>如果所输入的时间无日期，则将使用默认日期 1899 年 12 月 30 日。</para>
		/// <para>如果所输入的日期无时间，则将使用默认时间 12:00:00 AM。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Geodatabase Connection Properties")]
		public object? Date { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseConnection SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Database Platform</para>
		/// </summary>
		public enum DatabasePlatformEnum 
		{
			/// <summary>
			/// <para>SQL Server—连接到 Microsoft SQL Server, Microsoft Azure SQL Database、Microsoft Azure SQL Managed Instance、Amazon Relational Database Service (RDS) for SQL Server 或 Google Cloud SQL for SQL Server。</para>
			/// </summary>
			[GPValue("SQL_SERVER")]
			[Description("SQL Server")]
			SQL_Server,

			/// <summary>
			/// <para>Oracle—连接到 Oracle、Amazon Relational Database Service (RDS) for Oracle 或 Autonomous Transaction Processing。</para>
			/// </summary>
			[GPValue("ORACLE")]
			[Description("Oracle")]
			Oracle,

			/// <summary>
			/// <para>Db2—连接至 Linux、UNIX 或 Windows 上的 IBM Db2。</para>
			/// </summary>
			[GPValue("DB2")]
			[Description("Db2")]
			Db2,

			/// <summary>
			/// <para>PostgreSQL—连接到 PostgreSQL、Amazon Aurora (PostgreSQL-compatible edition)、Amazon Relational Database Service (RDS) for PostgreSQL、Microsoft Azure Database for PostgreSQL 或 Google Cloud SQL for PostgreSQL。</para>
			/// </summary>
			[GPValue("POSTGRESQL")]
			[Description("PostgreSQL")]
			PostgreSQL,

			/// <summary>
			/// <para>Teradata—连接到 Teradata Data Warehouse Appliance。</para>
			/// </summary>
			[GPValue("TERADATA")]
			[Description("Teradata")]
			Teradata,

			/// <summary>
			/// <para>SAP HANA—连接到 SAP HANA 或 SAP HANA Cloud。</para>
			/// </summary>
			[GPValue("SAP HANA")]
			[Description("SAP HANA")]
			SAP_HANA,

			/// <summary>
			/// <para>DAMENG—连接到 Dameng。</para>
			/// </summary>
			[GPValue("DAMENG")]
			[Description("DAMENG")]
			Dameng,

		}

		/// <summary>
		/// <para>Database Authentication</para>
		/// </summary>
		public enum AccountAuthenticationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATABASE_AUTH")]
			DATABASE_AUTH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("OPERATING_SYSTEM_AUTH")]
			OPERATING_SYSTEM_AUTH,

		}

		/// <summary>
		/// <para>Save username and password</para>
		/// </summary>
		public enum SaveUserPassEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_USERNAME")]
			SAVE_USERNAME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SAVE_USERNAME")]
			DO_NOT_SAVE_USERNAME,

		}

		/// <summary>
		/// <para>Version Type</para>
		/// </summary>
		public enum VersionTypeEnum 
		{
			/// <summary>
			/// <para>事务—连接到事务版本。 如果选择事务，则将使用事务版本的列表填充将使用以下版本参数，而日期和时间参数将禁用。 这是默认设置。</para>
			/// </summary>
			[GPValue("TRANSACTIONAL")]
			[Description("事务")]
			Transactional,

			/// <summary>
			/// <para>历史—连接到历史标记。 如果选择历史，则将使用历史标记的列表填充将使用以下版本参数，而日期和时间参数将禁用。</para>
			/// </summary>
			[GPValue("HISTORICAL")]
			[Description("历史")]
			Historical,

			/// <summary>
			/// <para>时间点—连接到特定时间点。 如果选择时间点，则将使用以下版本参数将禁用，而日期和时间参数将变为活动状态。</para>
			/// </summary>
			[GPValue("POINT_IN_TIME")]
			[Description("时间点")]
			Point_in_time,

			/// <summary>
			/// <para>分支—连接到默认分支版本。</para>
			/// </summary>
			[GPValue("BRANCH")]
			[Description("分支")]
			Branch,

		}

#endregion
	}
}
