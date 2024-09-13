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
	/// <para>Create Database User</para>
	/// <para>创建数据库用户</para>
	/// <para>在数据库中创建具有足够权限可创建数据的数据库用户。</para>
	/// </summary>
	public class CreateDatabaseUser : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>Oracle、PostgreSQL 或 SQL Server 中的企业级地理数据库的连接文件。请确保以数据库管理员用户身份建立连接。连接到 Oracle 时，必须以系统用户身份进行连接。</para>
		/// </param>
		/// <param name="UserName">
		/// <para>Database User</para>
		/// <para>新数据库用户的名称。</para>
		/// <para>如果选择为操作系统登录帐户创建数据库用户，则用户名必须与登录名匹配。</para>
		/// </param>
		public CreateDatabaseUser(object InputDatabase, object UserName)
		{
			this.InputDatabase = InputDatabase;
			this.UserName = UserName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建数据库用户</para>
		/// </summary>
		public override string DisplayName() => "创建数据库用户";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseUser</para>
		/// </summary>
		public override string ToolName() => "CreateDatabaseUser";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseUser</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateDatabaseUser";

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
		public override object[] Parameters() => new object[] { InputDatabase, UserAuthenticationType, UserName, UserPassword, Role, TablespaceName, OutResult };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>Oracle、PostgreSQL 或 SQL Server 中的企业级地理数据库的连接文件。请确保以数据库管理员用户身份建立连接。连接到 Oracle 时，必须以系统用户身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Create Operating System Authenticated User</para>
		/// <para>指定用户的身份验证类型。仅当要为其创建数据库用户的操作系统登录存在时，才使用此参数。仅 SQL Server 和 Oracle 数据库支持此选项，因为 ArcGIS 仅支持对这两个数据库进行操作系统身份验证。</para>
		/// <para>选中 - 将创建经过操作系统身份验证的用户。相应的登录帐户必须已存在。</para>
		/// <para>未选中 - 将创建经过数据库身份验证的用户。这是默认设置。</para>
		/// <para><see cref="UserAuthenticationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UserAuthenticationType { get; set; } = "false";

		/// <summary>
		/// <para>Database User</para>
		/// <para>新数据库用户的名称。</para>
		/// <para>如果选择为操作系统登录帐户创建数据库用户，则用户名必须与登录名匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object UserName { get; set; }

		/// <summary>
		/// <para>Database User Password</para>
		/// <para>新用户的密码。强制实行基础数据库的密码策略。</para>
		/// <para>如果选择为操作系统登录创建数据库用户，则不需要输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object UserPassword { get; set; }

		/// <summary>
		/// <para>Role</para>
		/// <para>要将新用户添加到现有数据库角色，指定角色的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Role { get; set; }

		/// <summary>
		/// <para>Tablespace Name</para>
		/// <para>在 Oracle 数据库中创建用户时，输入要用作用户的默认表空间的表空间名称。可指定预配置表空间，如果表空间不存在，则将在 Oracle 默认存储位置创建大小设置为 400 MB 的表空间。如果未指定表空间，则用户的默认表空间将设置为 Oracle 默认表空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TablespaceName { get; set; }

		/// <summary>
		/// <para>Database User Created</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResult { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseUser SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Operating System Authenticated User</para>
		/// </summary>
		public enum UserAuthenticationTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OPERATING_SYSTEM_USER")]
			OPERATING_SYSTEM_USER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DATABASE_USER")]
			DATABASE_USER,

		}

#endregion
	}
}
