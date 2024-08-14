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
	/// <para>Repair Version Tables</para>
	/// <para>Repairs inconsistencies in the delta (A and D) tables of datasets that are registered for traditional versioning.</para>
	/// </summary>
	public class RepairVersionTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which delta table inconsistencies exist. The connection must be made as the geodatabase administrator.</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Repair Version Tables Log</para>
		/// <para>The location where the log file will be written and the name of the log file. The log file is an ASCII file containing the results of the repair operation.</para>
		/// </param>
		public RepairVersionTables(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Version Tables</para>
		/// </summary>
		public override string DisplayName => "Repair Version Tables";

		/// <summary>
		/// <para>Tool Name : RepairVersionTables</para>
		/// </summary>
		public override string ToolName => "RepairVersionTables";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairVersionTables</para>
		/// </summary>
		public override string ExcuteName => "management.RepairVersionTables";

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
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which delta table inconsistencies exist. The connection must be made as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Repair Version Tables Log</para>
		/// <para>The location where the log file will be written and the name of the log file. The log file is an ASCII file containing the results of the repair operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>The geodatabase version to be repaired. The drop-down list is populated with the existing versions in the geodatabase specified for the Input Database Connection parameter. If no version is selected, all versions are processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetVersion { get; set; }

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>A single table or a text file containing a list of versioned tables with the associated delta tables to be repaired. Use fully-qualified table names in the text file, and place one table name per line. If no table or file is specified, all tables are processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InputTables { get; set; }

		/// <summary>
		/// <para>Repaired Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairVersionTables SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
