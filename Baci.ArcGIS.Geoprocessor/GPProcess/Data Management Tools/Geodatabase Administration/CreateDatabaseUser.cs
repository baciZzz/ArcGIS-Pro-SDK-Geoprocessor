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
	/// <para>Creates a database user with privileges sufficient to create data in the database.</para>
	/// </summary>
	public class CreateDatabaseUser : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The connection file to an enterprise geodatabase in Oracle, PostgreSQL, or SQL Server. Be sure the connection is made as a database administrator user. When connecting to Oracle, you must connect as the sys user.</para>
		/// </param>
		/// <param name="UserName">
		/// <para>Database User</para>
		/// <para>The name of the new database user.</para>
		/// <para>If you chose to create a database user for an operating system login, the user name must match the login name.</para>
		/// </param>
		public CreateDatabaseUser(object InputDatabase, object UserName)
		{
			this.InputDatabase = InputDatabase;
			this.UserName = UserName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Database User</para>
		/// </summary>
		public override string DisplayName => "Create Database User";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseUser</para>
		/// </summary>
		public override string ToolName => "CreateDatabaseUser";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseUser</para>
		/// </summary>
		public override string ExcuteName => "management.CreateDatabaseUser";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputDatabase, UserAuthenticationType, UserName, UserPassword, Role, TablespaceName, OutResult };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The connection file to an enterprise geodatabase in Oracle, PostgreSQL, or SQL Server. Be sure the connection is made as a database administrator user. When connecting to Oracle, you must connect as the sys user.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Create Operating System Authenticated User</para>
		/// <para>Specifies the authentication type for the user. Use this parameter only if an operating system login exists for which you want to create a database user. This option is only supported for SQL Server and Oracle databases, as those are the only two databases for which ArcGIS supports operating system authentication.</para>
		/// <para>Checked—An operating system-authenticated user is created. The corresponding login must already exist.</para>
		/// <para>Unchecked—A database-authenticated user is created. This is the default.</para>
		/// <para><see cref="UserAuthenticationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UserAuthenticationType { get; set; } = "false";

		/// <summary>
		/// <para>Database User</para>
		/// <para>The name of the new database user.</para>
		/// <para>If you chose to create a database user for an operating system login, the user name must match the login name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object UserName { get; set; }

		/// <summary>
		/// <para>Database User Password</para>
		/// <para>The password for the new user. The password policy of the underlying database is enforced.</para>
		/// <para>If you chose to create a database user for an operating system login, no input is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object UserPassword { get; set; }

		/// <summary>
		/// <para>Role</para>
		/// <para>To add the new user to an existing database role, specify the name of the role.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Role { get; set; }

		/// <summary>
		/// <para>Tablespace Name</para>
		/// <para>When creating a user in an Oracle database, type the name of the tablespace to be used as the default tablespace for the user. You can specify a preconfigured tablespace, or, if the tablespace does not yet exist, it will be created in the Oracle default storage location with its size set to 400 MB. If no tablespace is specified, the user's default tablespace will be set to the Oracle default tablespace.</para>
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
			/// <para>Checked—An operating system-authenticated user is created. The corresponding login must already exist.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OPERATING_SYSTEM_USER")]
			OPERATING_SYSTEM_USER,

			/// <summary>
			/// <para>Unchecked—A database-authenticated user is created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DATABASE_USER")]
			DATABASE_USER,

		}

#endregion
	}
}
