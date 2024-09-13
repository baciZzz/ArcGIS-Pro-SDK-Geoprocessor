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
	/// <para>Delete Database Sequence</para>
	/// <para>Deletes a database sequence from a geodatabase.</para>
	/// </summary>
	public class DeleteDatabaseSequence : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The full path to the location of the file geodatabase from which you want to delete a sequence or the database connection file (.sde) to connect to the enterprise geodatabase from which you want to delete a sequence. The user specified in the database connection must have the following permissions in the database:</para>
		/// <para>Db2—DBADM authority</para>
		/// <para>Oracle—Must be the sequence owner or have the DROP ANY SEQUENCE system privilege</para>
		/// <para>PostgreSQL—Must be the sequence owner</para>
		/// <para>SAP HANA—Must be a standard user</para>
		/// <para>SQL Server—ALTER OR CONTROL permission on the database schema where the sequence is stored</para>
		/// </param>
		/// <param name="SeqName">
		/// <para>Sequence Name</para>
		/// <para>The name of the database sequence you want to delete. Once deleted, the sequence cannot be used to generate sequence IDs when called from existing custom applications or expressions.</para>
		/// </param>
		public DeleteDatabaseSequence(object InWorkspace, object SeqName)
		{
			this.InWorkspace = InWorkspace;
			this.SeqName = SeqName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Database Sequence</para>
		/// </summary>
		public override string DisplayName() => "Delete Database Sequence";

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
		public override object[] Parameters() => new object[] { InWorkspace, SeqName, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The full path to the location of the file geodatabase from which you want to delete a sequence or the database connection file (.sde) to connect to the enterprise geodatabase from which you want to delete a sequence. The user specified in the database connection must have the following permissions in the database:</para>
		/// <para>Db2—DBADM authority</para>
		/// <para>Oracle—Must be the sequence owner or have the DROP ANY SEQUENCE system privilege</para>
		/// <para>PostgreSQL—Must be the sequence owner</para>
		/// <para>SAP HANA—Must be a standard user</para>
		/// <para>SQL Server—ALTER OR CONTROL permission on the database schema where the sequence is stored</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Sequence Name</para>
		/// <para>The name of the database sequence you want to delete. Once deleted, the sequence cannot be used to generate sequence IDs when called from existing custom applications or expressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SeqName { get; set; }

		/// <summary>
		/// <para>Deleted sequence from geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteDatabaseSequence SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
