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
	/// <para>Diagnose Version Metadata</para>
	/// <para>Identifies inconsistencies in the system tables used to manage traditional versions and states in a geodatabase.</para>
	/// </summary>
	public class DiagnoseVersionMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which traditional versioning system table inconsistencies may exist.</para>
		/// <para>The connection must be made as the geodatabase administrator.</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Diagnostic Version Metadata Log</para>
		/// <para>The name and location of the output log file.</para>
		/// <para>The log file is an ASCII file containing a list of the system tables in the specified version that contain inconsistent records, as well as the database connection file used.</para>
		/// </param>
		public DiagnoseVersionMetadata(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : Diagnose Version Metadata</para>
		/// </summary>
		public override string DisplayName => "Diagnose Version Metadata";

		/// <summary>
		/// <para>Tool Name : DiagnoseVersionMetadata</para>
		/// </summary>
		public override string ToolName => "DiagnoseVersionMetadata";

		/// <summary>
		/// <para>Tool Excute Name : management.DiagnoseVersionMetadata</para>
		/// </summary>
		public override string ExcuteName => "management.DiagnoseVersionMetadata";

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
		public override object[] Parameters => new object[] { InputDatabase, OutLog, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which traditional versioning system table inconsistencies may exist.</para>
		/// <para>The connection must be made as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Diagnostic Version Metadata Log</para>
		/// <para>The name and location of the output log file.</para>
		/// <para>The log file is an ASCII file containing a list of the system tables in the specified version that contain inconsistent records, as well as the database connection file used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DiagnoseVersionMetadata SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
