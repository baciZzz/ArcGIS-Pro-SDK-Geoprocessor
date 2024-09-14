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
	/// <para>Create Database Connection</para>
	/// <para>Creates a file that ArcGIS uses to connect to a database or an enterprise geodatabase.</para>
	/// </summary>
	public class CreateDatabaseConnection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>Connection File Location</para>
		/// <para>The folder path where the database connection file (.sde) will be stored.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Connection File Name</para>
		/// <para>The name of the database connection file. The output file will have the extension .sde.</para>
		/// </param>
		/// <param name="DatabasePlatform">
		/// <para>Database Platform</para>
		/// <para>Specifies the database management system platform to which the connection will be made. The following are valid options:</para>
		/// <para>Dameng—Connect to Dameng.</para>
		/// <para>Db2—Connect to IBM Db2 for Linux, UNIX, or Windows.</para>
		/// <para>Oracle—Connect to Oracle, Amazon Relational Database Service (RDS) for Oracle, or Autonomous Transaction Processing database in Oracle Cloud.</para>
		/// <para>PostgreSQL—Connect to PostgreSQL, Amazon Aurora PostgreSQL, Amazon Relational Database Service (RDS) for PostgreSQL, or Microsoft Azure Database for PostgreSQL.</para>
		/// <para>SAP HANA—Connect to SAP HANA or SAP HANA Cloud.</para>
		/// <para>SQL Server—Connect to Microsoft SQL Server, Microsoft Azure SQL Database, Microsoft Azure SQL Managed Instance, or Amazon Relational Database Service (RDS) for SQL Server.</para>
		/// <para>Teradata—Connect to Teradata Data Warehouse Appliance.</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </param>
		/// <param name="Instance">
		/// <para>Instance</para>
		/// <para>The database server or instance to which the connection will be made.</para>
		/// <para>The value you choose from the Database Platform drop-down list indicates the type of database to which you want to connect. The information you provide for the Instance parameter varies, depending on the connection type you choose.</para>
		/// <para>See below for information about what to provide for each database platform.</para>
		/// <para>Dameng—The name of the server where the Dameng database is installed&lt;bold/&gt;</para>
		/// <para>Db2—The name of the cataloged Db2 database</para>
		/// <para>Oracle—Either the TNS name or the Oracle Easy Connection string to connect to the Oracle database or database service</para>
		/// <para>PostgreSQL—The name of the server where PostgreSQL is installed or the name of the PostgreSQL database service instance</para>
		/// <para>SAP HANA—The Open Database Connectivity (ODBC) data source name for the SAP HANA database or database service</para>
		/// <para>SQL Server—The name of the SQL Server database instance or the name of the database service instance.</para>
		/// <para>Teradata—The ODBC data source name for the Teradata database</para>
		/// </param>
		public CreateDatabaseConnection(object OutFolderPath, object OutName, object DatabasePlatform, object Instance)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
			this.DatabasePlatform = DatabasePlatform;
			this.Instance = Instance;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Database Connection</para>
		/// </summary>
		public override string DisplayName() => "Create Database Connection";

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
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, DatabasePlatform, Instance, AccountAuthentication, Username, Password, SaveUserPass, Database, Schema, VersionType, Version, Date, OutWorkspace };

		/// <summary>
		/// <para>Connection File Location</para>
		/// <para>The folder path where the database connection file (.sde) will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Connection File Name</para>
		/// <para>The name of the database connection file. The output file will have the extension .sde.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Database Platform</para>
		/// <para>Specifies the database management system platform to which the connection will be made. The following are valid options:</para>
		/// <para>Dameng—Connect to Dameng.</para>
		/// <para>Db2—Connect to IBM Db2 for Linux, UNIX, or Windows.</para>
		/// <para>Oracle—Connect to Oracle, Amazon Relational Database Service (RDS) for Oracle, or Autonomous Transaction Processing database in Oracle Cloud.</para>
		/// <para>PostgreSQL—Connect to PostgreSQL, Amazon Aurora PostgreSQL, Amazon Relational Database Service (RDS) for PostgreSQL, or Microsoft Azure Database for PostgreSQL.</para>
		/// <para>SAP HANA—Connect to SAP HANA or SAP HANA Cloud.</para>
		/// <para>SQL Server—Connect to Microsoft SQL Server, Microsoft Azure SQL Database, Microsoft Azure SQL Managed Instance, or Amazon Relational Database Service (RDS) for SQL Server.</para>
		/// <para>Teradata—Connect to Teradata Data Warehouse Appliance.</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatabasePlatform { get; set; }

		/// <summary>
		/// <para>Instance</para>
		/// <para>The database server or instance to which the connection will be made.</para>
		/// <para>The value you choose from the Database Platform drop-down list indicates the type of database to which you want to connect. The information you provide for the Instance parameter varies, depending on the connection type you choose.</para>
		/// <para>See below for information about what to provide for each database platform.</para>
		/// <para>Dameng—The name of the server where the Dameng database is installed&lt;bold/&gt;</para>
		/// <para>Db2—The name of the cataloged Db2 database</para>
		/// <para>Oracle—Either the TNS name or the Oracle Easy Connection string to connect to the Oracle database or database service</para>
		/// <para>PostgreSQL—The name of the server where PostgreSQL is installed or the name of the PostgreSQL database service instance</para>
		/// <para>SAP HANA—The Open Database Connectivity (ODBC) data source name for the SAP HANA database or database service</para>
		/// <para>SQL Server—The name of the SQL Server database instance or the name of the database service instance.</para>
		/// <para>Teradata—The ODBC data source name for the Teradata database</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Instance { get; set; }

		/// <summary>
		/// <para>Database Authentication</para>
		/// <para>Specifies the type of authentication that will be used.</para>
		/// <para>Checked—Database authentication will be used. An internal database user name and a password will be used to connect to the database. You aren&apos;t required to type your user name and password to create a connection; however, if you don&apos;t, you will be prompted to enter them when a connection is established.</para>
		/// <para>Unchecked—Operating system authentication will be used. You do not need to type a user name and password. The connection will be made with the user name and password that were used to log in to the operating system. If the login used for the operating system is not a valid geodatabase login, the connection will fail.</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AccountAuthentication { get; set; } = "true";

		/// <summary>
		/// <para>Username</para>
		/// <para>The database user name that will be used for database authentication.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>The database user password that will be used for database authentication.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object Password { get; set; }

		/// <summary>
		/// <para>Save username and password</para>
		/// <para>Specifies whether the user name and password will be saved.</para>
		/// <para>Checked—The user name and password will be saved in the connection file. This is the default. If the connection file you are creating will provide ArcGIS services with access to the geodatabase, you must save the user name and password.</para>
		/// <para>Unchecked—The user name and password will not be saved in the connection file. Every time you attempt to connect using the file, you will be prompted for the user name and password.</para>
		/// <para><see cref="SaveUserPassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SaveUserPass { get; set; } = "true";

		/// <summary>
		/// <para>Database</para>
		/// <para>The name of the database to which the connection will be made. This parameter only applies to PostgreSQL and SQL Server platforms.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Database { get; set; }

		/// <summary>
		/// <para>Schema (Oracle user schema geodatabases only)</para>
		/// <para>The user schema geodatabase to which the connection will be made. The tool will determine if it is connecting to an Oracle database that contains a user–schema geodatabase. If the Oracle database contains a user schema, this option is active; otherwise, it remains inactive. The default option for this parameter is to use the sde schema geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object Schema { get; set; }

		/// <summary>
		/// <para>Version Type</para>
		/// <para>Specifies the type of version to which the connection will be made. This parameter only applies when connecting to a geodatabase.</para>
		/// <para>Transactional—Connect to a transactional version. If Transactional is selected, the The following version will be used parameter will be populated with a list of transactional versions, and the Date and Time parameter will be inactive. This is the default.</para>
		/// <para>Historical—Connect to an historical marker. If Historical is selected, the The following version will be used parameter will be populated with a list of historical markers, and the Date and Time parameter will be inactive.</para>
		/// <para>Point in time—Connect to a specific point in time. If Point in time is selected, the The following version will be used parameter will be inactive, and the Date and Time parameter will become active.</para>
		/// <para>Branch—Connect to the default branch version.</para>
		/// <para>If Historical is selected and a name is not provided, the default transactional version is used. If Point in time is selected and a date is not provided in the Date and Time parameter, the default transactional version is used.</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Connection Properties")]
		public object VersionType { get; set; } = "TRANSACTIONAL";

		/// <summary>
		/// <para>The following version will be used</para>
		/// <para>The geodatabase transactional version or historical marker to which the connect will be made. The default option uses the default transactional version.</para>
		/// <para>If you choose a branch version type, the connection is always to the default branch version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object Version { get; set; }

		/// <summary>
		/// <para>Date and Time</para>
		/// <para>The value representing the date and time that will be used to connect to the database. This option is used with archive-enabled data. Use the time picker to choose the appropriate date.</para>
		/// <para>If manually entering a date, the following formats can be used:</para>
		/// <para>6/9/2011 4:20:15 PM</para>
		/// <para>6/9/2011 16:20:15</para>
		/// <para>6/9/2011</para>
		/// <para>4:20:15 PM</para>
		/// <para>16:20:15</para>
		/// <para>If a time is entered without a date, the default date of December 30, 1899, is used.</para>
		/// <para>If a date is entered without a time, the default time of 12:00:00 AM will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Geodatabase Connection Properties")]
		public object Date { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseConnection SetEnviroment(object workspace = null)
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
			/// <para>SQL Server—Connect to Microsoft SQL Server, Microsoft Azure SQL Database, Microsoft Azure SQL Managed Instance, or Amazon Relational Database Service (RDS) for SQL Server.</para>
			/// </summary>
			[GPValue("SQL_SERVER")]
			[Description("SQL Server")]
			SQL_Server,

			/// <summary>
			/// <para>Oracle—Connect to Oracle, Amazon Relational Database Service (RDS) for Oracle, or Autonomous Transaction Processing database in Oracle Cloud.</para>
			/// </summary>
			[GPValue("ORACLE")]
			[Description("Oracle")]
			Oracle,

			/// <summary>
			/// <para>Db2—Connect to IBM Db2 for Linux, UNIX, or Windows.</para>
			/// </summary>
			[GPValue("DB2")]
			[Description("Db2")]
			Db2,

			/// <summary>
			/// <para>PostgreSQL—Connect to PostgreSQL, Amazon Aurora PostgreSQL, Amazon Relational Database Service (RDS) for PostgreSQL, or Microsoft Azure Database for PostgreSQL.</para>
			/// </summary>
			[GPValue("POSTGRESQL")]
			[Description("PostgreSQL")]
			PostgreSQL,

			/// <summary>
			/// <para>Teradata—Connect to Teradata Data Warehouse Appliance.</para>
			/// </summary>
			[GPValue("TERADATA")]
			[Description("Teradata")]
			Teradata,

			/// <summary>
			/// <para>SAP HANA—Connect to SAP HANA or SAP HANA Cloud.</para>
			/// </summary>
			[GPValue("SAP HANA")]
			[Description("SAP HANA")]
			SAP_HANA,

			/// <summary>
			/// <para>Dameng—Connect to Dameng.</para>
			/// </summary>
			[GPValue("DAMENG")]
			[Description("Dameng")]
			Dameng,

		}

		/// <summary>
		/// <para>Database Authentication</para>
		/// </summary>
		public enum AccountAuthenticationEnum 
		{
			/// <summary>
			/// <para>Checked—Database authentication will be used. An internal database user name and a password will be used to connect to the database. You aren&apos;t required to type your user name and password to create a connection; however, if you don&apos;t, you will be prompted to enter them when a connection is established.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATABASE_AUTH")]
			DATABASE_AUTH,

			/// <summary>
			/// <para>Unchecked—Operating system authentication will be used. You do not need to type a user name and password. The connection will be made with the user name and password that were used to log in to the operating system. If the login used for the operating system is not a valid geodatabase login, the connection will fail.</para>
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
			/// <para>Checked—The user name and password will be saved in the connection file. This is the default. If the connection file you are creating will provide ArcGIS services with access to the geodatabase, you must save the user name and password.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_USERNAME")]
			SAVE_USERNAME,

			/// <summary>
			/// <para>Unchecked—The user name and password will not be saved in the connection file. Every time you attempt to connect using the file, you will be prompted for the user name and password.</para>
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
			/// <para>Transactional—Connect to a transactional version. If Transactional is selected, the The following version will be used parameter will be populated with a list of transactional versions, and the Date and Time parameter will be inactive. This is the default.</para>
			/// </summary>
			[GPValue("TRANSACTIONAL")]
			[Description("Transactional")]
			Transactional,

			/// <summary>
			/// <para>Historical—Connect to an historical marker. If Historical is selected, the The following version will be used parameter will be populated with a list of historical markers, and the Date and Time parameter will be inactive.</para>
			/// </summary>
			[GPValue("HISTORICAL")]
			[Description("Historical")]
			Historical,

			/// <summary>
			/// <para>Point in time—Connect to a specific point in time. If Point in time is selected, the The following version will be used parameter will be inactive, and the Date and Time parameter will become active.</para>
			/// </summary>
			[GPValue("POINT_IN_TIME")]
			[Description("Point in time")]
			Point_in_time,

			/// <summary>
			/// <para>Branch—Connect to the default branch version.</para>
			/// </summary>
			[GPValue("BRANCH")]
			[Description("Branch")]
			Branch,

		}

#endregion
	}
}
