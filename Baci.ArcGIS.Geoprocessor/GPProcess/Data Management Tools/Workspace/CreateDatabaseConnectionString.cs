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
	/// <para>Create Database Connection String</para>
	/// <para>Creates a connection string that geoprocessing tools can use to connect to a database or an enterprise geodatabase.</para>
	/// </summary>
	public class CreateDatabaseConnectionString : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="DatabasePlatform">
		/// <para>Database Platform</para>
		/// <para>Specifies the database platform to which the connection will be made.</para>
		/// <para>SQL Server—Connect to Microsoft SQL Server or Microsoft Azure SQL Database.</para>
		/// <para>Oracle—Connect to Oracle.</para>
		/// <para>DB2—Connect to IBM DB2 for Linux, UNIX, or Windows.</para>
		/// <para>PostgreSQL—Connect to PostgreSQL.</para>
		/// <para>Teradata—Connect to Teradata Data Warehouse Appliance.</para>
		/// <para>SAP HANA—Connect to SAP HANA.</para>
		/// <para>Dameng—Connect to Dameng.</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </param>
		/// <param name="Instance">
		/// <para>Instance</para>
		/// <para>The database server or instance to which the connection will be made.</para>
		/// <para>This parameter value depends on the Database Platform parameter value chosen.</para>
		/// </param>
		public CreateDatabaseConnectionString(object DatabasePlatform, object Instance)
		{
			this.DatabasePlatform = DatabasePlatform;
			this.Instance = Instance;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Database Connection String</para>
		/// </summary>
		public override string DisplayName() => "Create Database Connection String";

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
		public override object[] Parameters() => new object[] { DatabasePlatform, Instance, AccountAuthentication!, Username!, Password!, Database!, ObjectName!, DataType!, FeatureDataset!, Schema!, VersionType!, Version!, Date!, OutConnectionString! };

		/// <summary>
		/// <para>Database Platform</para>
		/// <para>Specifies the database platform to which the connection will be made.</para>
		/// <para>SQL Server—Connect to Microsoft SQL Server or Microsoft Azure SQL Database.</para>
		/// <para>Oracle—Connect to Oracle.</para>
		/// <para>DB2—Connect to IBM DB2 for Linux, UNIX, or Windows.</para>
		/// <para>PostgreSQL—Connect to PostgreSQL.</para>
		/// <para>Teradata—Connect to Teradata Data Warehouse Appliance.</para>
		/// <para>SAP HANA—Connect to SAP HANA.</para>
		/// <para>Dameng—Connect to Dameng.</para>
		/// <para><see cref="DatabasePlatformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatabasePlatform { get; set; }

		/// <summary>
		/// <para>Instance</para>
		/// <para>The database server or instance to which the connection will be made.</para>
		/// <para>This parameter value depends on the Database Platform parameter value chosen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Instance { get; set; }

		/// <summary>
		/// <para>Database Authentication</para>
		/// <para>Specifies the type of authentication that will be used.</para>
		/// <para>Checked—Database authentication will be used. An internal database user name and password are used to connect to the database. You aren&apos;t required to type your user name and password to create a connection; however, if you don&apos;t, you will be prompted to enter them when a connection is established. This is the default</para>
		/// <para>Unchecked—Operating system authentication will be used. You do not need to type a user name and password. The connection will be made with the user name and password that were used to log in to the operating system. If the login used for the operating system is not a valid geodatabase login, the connection will fail.</para>
		/// <para><see cref="AccountAuthenticationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AccountAuthentication { get; set; } = "true";

		/// <summary>
		/// <para>Username</para>
		/// <para>The database user name that will be used when using database authentication.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>The database user password that will be used when using database authentication.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		public object? Password { get; set; }

		/// <summary>
		/// <para>Database</para>
		/// <para>The name of the database to which you will connect. This parameter only applies to PostgreSQL and SQL Server platforms.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Database { get; set; }

		/// <summary>
		/// <para>Dataset Object Name</para>
		/// <para>The name of the dataset or object in the database to which the connection string will point. This connection string can be used as a path to the specified dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ObjectName { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>The type of dataset or object referred to in the dataset object name. If there are multiple objects with the same name in the database, you may need to specify the data type of the object for which you want to make a connection string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The name of the feature dataset containing the dataset or object for which you want to make a connection string. If the dataset is not in a feature dataset (for example, if it's at the root of the database), do not specify a target feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FeatureDataset { get; set; }

		/// <summary>
		/// <para>Schema (Oracle user schema geodatabases only)</para>
		/// <para>The user schema geodatabase to which you will connect. The tool will determine if it is connecting to an Oracle database that contains a user-schema geodatabase. If the Oracle database contains a user schema, this option is active; otherwise, it remains inactive. The default option for this parameter is to use the sde schema (master) geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object? Schema { get; set; }

		/// <summary>
		/// <para>Version Type</para>
		/// <para>Specifies the type of version to which you will connect. This parameter only applies when connecting to a geodatabase.</para>
		/// <para>Transactional—Connect to a transactional version. If Transactional is selected, the The following version will be used parameter will be populated with a list of transactional versions, and the Date and Time parameter will be inactive. This is the Default.</para>
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
		public object? VersionType { get; set; } = "TRANSACTIONAL";

		/// <summary>
		/// <para>The following version will be used</para>
		/// <para>The geodatabase transactional version or historical marker to connect to. The default option uses the default transactional version.</para>
		/// <para>If you choose a branch version type, the connection is always to the default branch version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Connection Properties")]
		public object? Version { get; set; }

		/// <summary>
		/// <para>Date and Time</para>
		/// <para>The value representing the date and time that will be used to connect to the database. This parameter is used with archive-enabled data. Use the time picker to choose the appropriate date.</para>
		/// <para>If manually entering a date, the following formats can be used:</para>
		/// <para>6/9/2011 4:20:15 PM</para>
		/// <para>6/9/2011 16:20:15</para>
		/// <para>6/9/2011</para>
		/// <para>4:20:15 PM</para>
		/// <para>16:20:15</para>
		/// <para>If a time is entered without a date, the default date of December 30, 1899, will be used.</para>
		/// <para>If a date is entered without a time, the default time of 12:00:00 AM will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Geodatabase Connection Properties")]
		public object? Date { get; set; }

		/// <summary>
		/// <para>CIMDATA Connection String</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutConnectionString { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseConnectionString SetEnviroment(object? workspace = null )
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
			/// <para>SQL Server—Connect to Microsoft SQL Server or Microsoft Azure SQL Database.</para>
			/// </summary>
			[GPValue("SQL_SERVER")]
			[Description("SQL Server")]
			SQL_Server,

			/// <summary>
			/// <para>Oracle—Connect to Oracle.</para>
			/// </summary>
			[GPValue("ORACLE")]
			[Description("Oracle")]
			Oracle,

			/// <summary>
			/// <para>DB2—Connect to IBM DB2 for Linux, UNIX, or Windows.</para>
			/// </summary>
			[GPValue("DB2")]
			[Description("DB2")]
			DB2,

			/// <summary>
			/// <para>PostgreSQL—Connect to PostgreSQL.</para>
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
			/// <para>SAP HANA—Connect to SAP HANA.</para>
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
			/// <para>Checked—Database authentication will be used. An internal database user name and password are used to connect to the database. You aren&apos;t required to type your user name and password to create a connection; however, if you don&apos;t, you will be prompted to enter them when a connection is established. This is the default</para>
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
		/// <para>Version Type</para>
		/// </summary>
		public enum VersionTypeEnum 
		{
			/// <summary>
			/// <para>Transactional—Connect to a transactional version. If Transactional is selected, the The following version will be used parameter will be populated with a list of transactional versions, and the Date and Time parameter will be inactive. This is the Default.</para>
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
