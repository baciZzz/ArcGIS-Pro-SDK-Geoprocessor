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
	/// <para>Create Database Connection String</para>
	/// <para>创建数据库连接字符串</para>
	/// <para>创建连接字符串，以供地理处理工具连接到数据库或企业级地理数据库。</para>
	/// </summary>
	public class CreateDatabaseConnectionString : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="DatabasePlatform">
		/// <para>Database Platform</para>
		/// <para>指定要建立连接的数据库平台。</para>
		/// <para>SQL Server—连接至 Microsoft SQL Server 或 Microsoft Azure SQL Database。</para>
		/// <para>Oracle—连接到 Oracle。</para>
		/// <para>DB2—连接至 Linux、UNIX 或 Windows 上的 IBM DB2。</para>
		/// <para>PostgreSQL—连接至 PostgreSQL。</para>
		/// <para>Teradata—连接至 Teradata Data Warehouse Appliance。</para>
		/// <para>SAP HANA—连接至 SAP HANA。</para>
		/// <para>DAMENG—连接至 Dameng。</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </param>
		/// <param name="Instance">
		/// <para>Instance</para>
		/// <para>要连接的数据库服务器或实例。</para>
		/// <para>此参数值取决于选择的数据库平台参数值。</para>
		/// </param>
		public CreateDatabaseConnectionString(object DatabasePlatform, object Instance)
		{
			this.DatabasePlatform = DatabasePlatform;
			this.Instance = Instance;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建数据库连接字符串</para>
		/// </summary>
		public override string DisplayName() => "创建数据库连接字符串";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseConnectionString</para>
		/// </summary>
		public override string ToolName() => "CreateDatabaseConnectionString";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseConnectionString</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateDatabaseConnectionString";

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
		public override object[] Parameters() => new object[] { DatabasePlatform, Instance, AccountAuthentication, Username, Password, Database, ObjectName, DataType, FeatureDataset, Schema, VersionType, Version, Date, OutConnectionString };

		/// <summary>
		/// <para>Database Platform</para>
		/// <para>指定要建立连接的数据库平台。</para>
		/// <para>SQL Server—连接至 Microsoft SQL Server 或 Microsoft Azure SQL Database。</para>
		/// <para>Oracle—连接到 Oracle。</para>
		/// <para>DB2—连接至 Linux、UNIX 或 Windows 上的 IBM DB2。</para>
		/// <para>PostgreSQL—连接至 PostgreSQL。</para>
		/// <para>Teradata—连接至 Teradata Data Warehouse Appliance。</para>
		/// <para>SAP HANA—连接至 SAP HANA。</para>
		/// <para>DAMENG—连接至 Dameng。</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatabasePlatform { get; set; }

		/// <summary>
		/// <para>Instance</para>
		/// <para>要连接的数据库服务器或实例。</para>
		/// <para>此参数值取决于选择的数据库平台参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Instance { get; set; }

		/// <summary>
		/// <para>Database Authentication</para>
		/// <para>指定要使用的身份验证类型。</para>
		/// <para>选中 - 将使用数据库身份验证。 使用内部数据库用户名和密码连接到数据库。 创建连接无需输入用户名和密码；但是，如果不输入用户名和密码，系统将在连接建立好之后提示您输入用户名和密码。 这是默认设置</para>
		/// <para>未选中 - 将使用操作系统身份验证。 不必输入用户名和密码。 将用登录操作系统时所使用的用户名和密码建立连接。 如果操作系统使用的登录信息不能用作地理数据库的登录信息，连接将失败。</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AccountAuthentication { get; set; } = "true";

		/// <summary>
		/// <para>Username</para>
		/// <para>采用数据库身份验证时将使用的数据库用户名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>采用数据库身份验证时将使用的数据库用户密码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object Password { get; set; }

		/// <summary>
		/// <para>Database</para>
		/// <para>将连接的数据库的名称。 此参数仅适用于 PostgreSQL 和 SQL Server 平台。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Database { get; set; }

		/// <summary>
		/// <para>Dataset Object Name</para>
		/// <para>数据库中连接字符串指向的数据集或对象名称。 此连接字符串可用作指定数据集的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ObjectName { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>数据集对象名称中引用的数据集或对象的类型。 如果数据库中存在多个同名对象，则可能需要指定要为其创建连接字符串的对象的数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DataType { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>包含要为其创建连接字符串的数据集或对象的要素数据集名称。 如果数据集不在要素数据集中（例如，如果它位于数据库的根目录下），请不要指定目标要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FeatureDataset { get; set; }

		/// <summary>
		/// <para>Schema (Oracle user schema geodatabases only)</para>
		/// <para>将连接到的用户方案地理数据库。 工具将决定是否连接到包含用户方案地理数据库的 Oracle 数据库。 如果 Oracle 数据库包含用户方案，此选项将激活；否则，将保持非活动状态。 此参数的默认选项为使用 SDE 方案（主）地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object Schema { get; set; }

		/// <summary>
		/// <para>Version Type</para>
		/// <para>指定将连接的版本类型。 此参数仅在连接到地理数据库时适用。</para>
		/// <para>事务—连接到事务版本。 如果选择事务，则将使用事务版本列表填充将使用以下版本参数，而日期和时间参数将处于非活动状态。 这是默认设置。</para>
		/// <para>历史—连接到历史标记。 如果选择历史，则将使用历史标记列表填充将使用以下版本参数，而日期和时间参数将处于非活动状态。</para>
		/// <para>时间点—连接到特定时间点。 如果选择时间点，则将使用以下版本参数将禁用，而日期和时间参数将变为活动状态。</para>
		/// <para>分支—连接到默认分支版本。</para>
		/// <para>如果选择历史并提供了名称，将使用默认的事务版本。 如果选择时间点并且未在日期和时间参数中提供日期，将使用默认的事务版本。</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Connection Properties")]
		public object VersionType { get; set; } = "TRANSACTIONAL";

		/// <summary>
		/// <para>The following version will be used</para>
		/// <para>要连接到的地理数据库事务版本或历史标记。 默认选项将使用默认事务版本。</para>
		/// <para>如果选择分支版本类型，则会始终连接到默认分支版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object Version { get; set; }

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
		public object Date { get; set; }

		/// <summary>
		/// <para>CIMDATA Connection String</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutConnectionString { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseConnectionString SetEnviroment(object workspace = null )
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
			/// <para>SQL Server—连接至 Microsoft SQL Server 或 Microsoft Azure SQL Database。</para>
			/// </summary>
			[GPValue("SQL_SERVER")]
			[Description("SQL Server")]
			SQL_Server,

			/// <summary>
			/// <para>Oracle—连接到 Oracle。</para>
			/// </summary>
			[GPValue("ORACLE")]
			[Description("Oracle")]
			Oracle,

			/// <summary>
			/// <para>DB2—连接至 Linux、UNIX 或 Windows 上的 IBM DB2。</para>
			/// </summary>
			[GPValue("DB2")]
			[Description("DB2")]
			DB2,

			/// <summary>
			/// <para>PostgreSQL—连接至 PostgreSQL。</para>
			/// </summary>
			[GPValue("POSTGRESQL")]
			[Description("PostgreSQL")]
			PostgreSQL,

			/// <summary>
			/// <para>Teradata—连接至 Teradata Data Warehouse Appliance。</para>
			/// </summary>
			[GPValue("TERADATA")]
			[Description("Teradata")]
			Teradata,

			/// <summary>
			/// <para>SAP HANA—连接至 SAP HANA。</para>
			/// </summary>
			[GPValue("SAP HANA")]
			[Description("SAP HANA")]
			SAP_HANA,

			/// <summary>
			/// <para>DAMENG—连接至 Dameng。</para>
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
		/// <para>Version Type</para>
		/// </summary>
		public enum VersionTypeEnum 
		{
			/// <summary>
			/// <para>事务—连接到事务版本。 如果选择事务，则将使用事务版本列表填充将使用以下版本参数，而日期和时间参数将处于非活动状态。 这是默认设置。</para>
			/// </summary>
			[GPValue("TRANSACTIONAL")]
			[Description("事务")]
			Transactional,

			/// <summary>
			/// <para>历史—连接到历史标记。 如果选择历史，则将使用历史标记列表填充将使用以下版本参数，而日期和时间参数将处于非活动状态。</para>
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
