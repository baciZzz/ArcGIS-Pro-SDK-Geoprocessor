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
	/// <para>Create Database Sequence</para>
	/// <para>Creates a database sequence in a geodatabase. You can use the sequences in custom applications that access the geodatabase.</para>
	/// </summary>
	public class CreateDatabaseSequence : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The database connection file (.sde) to connect to the enterprise geodatabase in which you want to create a sequence or the path to the file geodatabase (including the file geodatabase name).</para>
		/// <para>For database connections, the user specified in the database connection will be the owner of the sequence and, therefore, must have the following permissions in the database:</para>
		/// <para>Db2—CREATEIN privilege on their schema</para>
		/// <para>Oracle—CREATE SEQUENCE system privilege</para>
		/// <para>PostgreSQL—Authority on their schema</para>
		/// <para>SAP HANA—Must be a standard user</para>
		/// <para>SQL Server—CREATE SEQUENCE privilege and ALTER OR CONTROL permission on their schema</para>
		/// </param>
		/// <param name="SeqName">
		/// <para>Sequence Name</para>
		/// <para>The name you want to assign to the database sequence. For enterprise geodatabases, the name must meet sequence name requirements for the database platform you're using and must be unique in the database. For file geodatabases, the name must be unique to the file geodatabase. It is important that you remember this name, as it is the name you use in your custom applications and expressions to invoke the sequence.</para>
		/// </param>
		public CreateDatabaseSequence(object InWorkspace, object SeqName)
		{
			this.InWorkspace = InWorkspace;
			this.SeqName = SeqName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Database Sequence</para>
		/// </summary>
		public override string DisplayName() => "Create Database Sequence";

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
		/// <para>The database connection file (.sde) to connect to the enterprise geodatabase in which you want to create a sequence or the path to the file geodatabase (including the file geodatabase name).</para>
		/// <para>For database connections, the user specified in the database connection will be the owner of the sequence and, therefore, must have the following permissions in the database:</para>
		/// <para>Db2—CREATEIN privilege on their schema</para>
		/// <para>Oracle—CREATE SEQUENCE system privilege</para>
		/// <para>PostgreSQL—Authority on their schema</para>
		/// <para>SAP HANA—Must be a standard user</para>
		/// <para>SQL Server—CREATE SEQUENCE privilege and ALTER OR CONTROL permission on their schema</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Sequence Name</para>
		/// <para>The name you want to assign to the database sequence. For enterprise geodatabases, the name must meet sequence name requirements for the database platform you're using and must be unique in the database. For file geodatabases, the name must be unique to the file geodatabase. It is important that you remember this name, as it is the name you use in your custom applications and expressions to invoke the sequence.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SeqName { get; set; }

		/// <summary>
		/// <para>Sequence Start ID</para>
		/// <para>The starting number of the sequence. If you do not provide a starting number, the sequence starts with 1. If you do provide a starting number, it must be greater than 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? SeqStartId { get; set; }

		/// <summary>
		/// <para>Sequence Increment Value</para>
		/// <para>Describes how the sequence numbers will increment. For example, if the sequence starts at 10 and the increment value is 5, the next value in the sequence is 15, and the next value after that is 20. If you do not specify an increment value, sequence values will increment by 1.</para>
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
		public CreateDatabaseSequence SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
