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
	/// <para>Diagnose Version Tables</para>
	/// <para>Identifies inconsistencies in the delta (A and D) tables of datasets that are registered for traditional versioning.</para>
	/// </summary>
	public class DiagnoseVersionTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which delta table inconsistencies may exist. The connection must be made as the geodatabase administrator.</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Diagnose Version Tables Log</para>
		/// <para>The path and name of the output log file. The log file is an ASCII file containing a list of the tables in the specified version that contain inconsistent records, as well as information about the connection file, geodatabase version, and tables for which the tool was run.</para>
		/// </param>
		public DiagnoseVersionTables(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : Diagnose Version Tables</para>
		/// </summary>
		public override string DisplayName => "Diagnose Version Tables";

		/// <summary>
		/// <para>Tool Name : DiagnoseVersionTables</para>
		/// </summary>
		public override string ToolName => "DiagnoseVersionTables";

		/// <summary>
		/// <para>Tool Excute Name : management.DiagnoseVersionTables</para>
		/// </summary>
		public override string ExcuteName => "management.DiagnoseVersionTables";

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
		public override object[] Parameters => new object[] { InputDatabase, OutLog, TargetVersion!, InputTables!, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which delta table inconsistencies may exist. The connection must be made as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Diagnose Version Tables Log</para>
		/// <para>The path and name of the output log file. The log file is an ASCII file containing a list of the tables in the specified version that contain inconsistent records, as well as information about the connection file, geodatabase version, and tables for which the tool was run.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>The geodatabase version with the delta tables that will be checked for inconsistencies. The drop-down list is populated with the existing versions in the geodatabase specified for the Input Database Connection parameter. If no version is selected, all versions will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetVersion { get; set; }

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>A single table or a text file containing a list of versioned tables with the associated delta tables to be checked for inconsistencies. Use fully-qualified table names in the text file, and place one table name per line. If no file is specified, all tables in the geodatabase are processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InputTables { get; set; }

		/// <summary>
		/// <para>Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DiagnoseVersionTables SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
