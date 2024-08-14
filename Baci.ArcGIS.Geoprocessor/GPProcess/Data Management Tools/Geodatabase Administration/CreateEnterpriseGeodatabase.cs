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
	/// <para>Create Enterprise Geodatabase</para>
	/// <para>Creates a database, storage locations, and a database user to act as the geodatabase administrator and owner of the geodatabase. Functionality varies depending on the database management system used. The tool grants the geodatabase administrator the privileges required to create a geodatabase; it then creates a geodatabase in the database.</para>
	/// </summary>
	public class CreateEnterpriseGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="DatabasePlatform">
		/// <para>Database Platform</para>
		/// <para>Specifies the type of database management system to which a connection will be made to create a geodatabase.</para>
		/// <para>Oracle—Connect to an Oracle instance.</para>
		/// <para>PostgreSQL—Connect to a PostgreSQL database cluster.</para>
		/// <para>SQL Server— Connect to a Microsoft SQL Server instance.</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </param>
		/// <param name="InstanceName">
		/// <para>Instance</para>
		/// <para>The name of the instance.</para>
		/// <para>For SQL Server, provide the SQL Server instance name. Case-sensitive or binary collation SQL Server instances are not supported.</para>
		/// <para>For Oracle, provide either the TNS name or the Oracle Easy Connection string.</para>
		/// <para>For PostgreSQL, provide the name of the server where PostgreSQL is installed.</para>
		/// </param>
		/// <param name="AuthorizationFile">
		/// <para>Authorization File</para>
		/// <para>The path and file name of the keycodes file that was created when ArcGIS Server was authorized. This file is in the \\Program Files\ESRI\License&lt;release#&gt;\sysgen folder on Windows or the /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen directory on Linux. If you have not already done so, authorize ArcGIS Server to create this file.</para>
		/// <para>You will likely need to copy the keycodes file from the ArcGIS Server machine to a location accessible to the tool.</para>
		/// </param>
		public CreateEnterpriseGeodatabase(object DatabasePlatform, object InstanceName, object AuthorizationFile)
		{
			this.DatabasePlatform = DatabasePlatform;
			this.InstanceName = InstanceName;
			this.AuthorizationFile = AuthorizationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Enterprise Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Create Enterprise Geodatabase";

		/// <summary>
		/// <para>Tool Name : CreateEnterpriseGeodatabase</para>
		/// </summary>
		public override string ToolName => "CreateEnterpriseGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateEnterpriseGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "management.CreateEnterpriseGeodatabase";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { DatabasePlatform, InstanceName, DatabaseName, AccountAuthentication, DatabaseAdmin, DatabaseAdminPassword, SdeSchema, GdbAdminName, GdbAdminPassword, TablespaceName, AuthorizationFile, OutResult };

		/// <summary>
		/// <para>Database Platform</para>
		/// <para>Specifies the type of database management system to which a connection will be made to create a geodatabase.</para>
		/// <para>Oracle—Connect to an Oracle instance.</para>
		/// <para>PostgreSQL—Connect to a PostgreSQL database cluster.</para>
		/// <para>SQL Server— Connect to a Microsoft SQL Server instance.</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatabasePlatform { get; set; } = "SQL_Server";

		/// <summary>
		/// <para>Instance</para>
		/// <para>The name of the instance.</para>
		/// <para>For SQL Server, provide the SQL Server instance name. Case-sensitive or binary collation SQL Server instances are not supported.</para>
		/// <para>For Oracle, provide either the TNS name or the Oracle Easy Connection string.</para>
		/// <para>For PostgreSQL, provide the name of the server where PostgreSQL is installed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InstanceName { get; set; }

		/// <summary>
		/// <para>Database</para>
		/// <para>The name of the database.</para>
		/// <para>This parameter is valid for PostgreSQL and SQL Server. You can provide either the name of an existing, preconfigured database or a name for a database that the tool will create.</para>
		/// <para>If the tool creates the database in SQL Server, the file sizes will either be the same as defined for the SQL Server model database or 500 MB for the MDF file and 125 MB for the LDF file, whichever is greater. Both the MDF and LDF files are created in the default SQL Server location on the database server. Do not name the database sde.</para>
		/// <para>If the tool creates the database in PostgreSQL, it uses the template1 database as the template for your database. If you need a different template—for example, you require a template that is enabled for a PostGIS—you must create the database before running this tool and provide the name of the existing database. Always use lowercase characters for the database name. If you use uppercase letters, the tool will convert them to lowercase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DatabaseName { get; set; }

		/// <summary>
		/// <para>Operating System Authentication</para>
		/// <para>Specifies the type of authentication that will be used for the database connection.</para>
		/// <para>Checked—Operating system authentication will be used. The login information that you provide for the computer where you run the tool is the login that will be used to authenticate the database connection. If your database management system is not configured to allow operating system authentication, authentication will fail.</para>
		/// <para>Unchecked—Database authentication will be used. You must provide a valid database user name and password for authentication in the database. This is the default. If your database management system is not configured to allow database authentication, authentication will fail.</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AccountAuthentication { get; set; } = "false";

		/// <summary>
		/// <para>Database Administrator</para>
		/// <para>If you use database authentication, specify a database administrator user. For Oracle, use the sys user. For PostgreSQL, specify a user with superuser status. For SQL Server, specify any member of the sysadmin fixed server role.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DatabaseAdmin { get; set; } = "sa";

		/// <summary>
		/// <para>Database Administrator Password</para>
		/// <para>If you use database authentication, provide the password for the database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object DatabaseAdminPassword { get; set; }

		/// <summary>
		/// <para>Sde Owned Schema</para>
		/// <para>This parameter is only active for SQL Server and specifies whether the geodatabase will be created in the schema of the sde user or in the dbo schema in the database. .</para>
		/// <para>Checked—The geodatabase will be created in the schema of the sde user.</para>
		/// <para>Unchecked—You must be logged in to the SQL Server instance as a user who is dbo in the instance, and the geodatabase will be created in the dbo schema in the database.</para>
		/// <para><see cref="SdeSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SdeSchema { get; set; } = "true";

		/// <summary>
		/// <para>Geodatabase Administrator</para>
		/// <para>The name of the geodatabase administrator user.</para>
		/// <para>If you are using PostgreSQL, this value must be sde. If the sde login role does not exist, this tool will create it and grant it superuser status in the database cluster. If the sde login role exists, this tool will grant it superuser status if it does not already have it. The tool also creates an sde schema in the database and grants usage on the schema to public.</para>
		/// <para>If you are using Oracle, the value is sde. If the sde user does not exist in the Oracle database, the tool will create it and grant it the privileges required to create and upgrade a geodatabase and disconnect users from the database. If you run this tool in an Oracle 12c or later release database, the tool also grants privileges to allow data imports using Oracle Data Pump. If the sde user exists, the tool will grant these same privileges to the existing user.</para>
		/// <para>Beginning with ArcGIS 10.7 and ArcGIS Pro 2.3, you cannot create user-schema geodatabases in Oracle.</para>
		/// <para>If you are using SQL Server and specified an sde-schema geodatabase, this value must be sde. The tool will create an sde login, database user, and schema and grant it privileges to create a geodatabase and remove connections from the SQL Server instance. If you specified a dbo schema, do not provide a value for this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object GdbAdminName { get; set; } = "sde";

		/// <summary>
		/// <para>Geodatabase Administrator Password</para>
		/// <para>The password for the geodatabase administrator user. If the geodatabase administrator user exists in the database management system, the password you provide must match the existing password. If the geodatabase administrator user does not exist, provide a valid database password for the new user. The password must meet the password policy enforced by your database.</para>
		/// <para>The password is an encrypted string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object GdbAdminPassword { get; set; }

		/// <summary>
		/// <para>Tablespace Name</para>
		/// <para>The name of the tablespace.</para>
		/// <para>This parameter is only valid for Oracle and PostgreSQL DBMS types. For Oracle, do one of the following:</para>
		/// <para>Provide the name of an existing tablespace. This tablespace will be used as the default tablespace for the geodatabase administrator user.</para>
		/// <para>Provide a valid name for a new tablespace. The tool will create a 400 MB tablespace in the Oracle default storage location and set it as the geodatabase administrator&apos;s default tablespace.</para>
		/// <para>Leave the tablespace blank. The tool will create a 400 MB tablespace named SDE_TBS in the Oracle default storage location. The SDE_TBS tablespace will be set as the geodatabase administrator&apos;s default tablespace.</para>
		/// <para>This tool does not create a tablespace in PostgreSQL. You must either provide the name of an existing tablespace to be used as the database&apos;s default tablespace or leave this parameter blank. If you leave the parameter blank, the tool will create a database in the pg_default tablespace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TablespaceName { get; set; }

		/// <summary>
		/// <para>Authorization File</para>
		/// <para>The path and file name of the keycodes file that was created when ArcGIS Server was authorized. This file is in the \\Program Files\ESRI\License&lt;release#&gt;\sysgen folder on Windows or the /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen directory on Linux. If you have not already done so, authorize ArcGIS Server to create this file.</para>
		/// <para>You will likely need to copy the keycodes file from the ArcGIS Server machine to a location accessible to the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object AuthorizationFile { get; set; }

		/// <summary>
		/// <para>Create Enterprise Geodatabase Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResult { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Database Platform</para>
		/// </summary>
		public enum DatabasePlatformEnum 
		{
			/// <summary>
			/// <para>SQL Server— Connect to a Microsoft SQL Server instance.</para>
			/// </summary>
			[GPValue("SQL_Server")]
			[Description("SQL Server")]
			SQL_Server,

			/// <summary>
			/// <para>PostgreSQL—Connect to a PostgreSQL database cluster.</para>
			/// </summary>
			[GPValue("PostgreSQL")]
			[Description("PostgreSQL")]
			PostgreSQL,

			/// <summary>
			/// <para>Oracle—Connect to an Oracle instance.</para>
			/// </summary>
			[GPValue("Oracle")]
			[Description("Oracle")]
			Oracle,

		}

		/// <summary>
		/// <para>Operating System Authentication</para>
		/// </summary>
		public enum AccountAuthenticationEnum 
		{
			/// <summary>
			/// <para>Checked—Operating system authentication will be used. The login information that you provide for the computer where you run the tool is the login that will be used to authenticate the database connection. If your database management system is not configured to allow operating system authentication, authentication will fail.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OPERATING_SYSTEM_AUTH")]
			OPERATING_SYSTEM_AUTH,

			/// <summary>
			/// <para>Unchecked—Database authentication will be used. You must provide a valid database user name and password for authentication in the database. This is the default. If your database management system is not configured to allow database authentication, authentication will fail.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DATABASE_AUTH")]
			DATABASE_AUTH,

		}

		/// <summary>
		/// <para>Sde Owned Schema</para>
		/// </summary>
		public enum SdeSchemaEnum 
		{
			/// <summary>
			/// <para>Checked—The geodatabase will be created in the schema of the sde user.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SDE_SCHEMA")]
			SDE_SCHEMA,

			/// <summary>
			/// <para>Unchecked—You must be logged in to the SQL Server instance as a user who is dbo in the instance, and the geodatabase will be created in the dbo schema in the database.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DBO_SCHEMA")]
			DBO_SCHEMA,

		}

#endregion
	}
}
