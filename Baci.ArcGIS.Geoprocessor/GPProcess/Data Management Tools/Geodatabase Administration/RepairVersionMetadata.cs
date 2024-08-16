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
	/// <para>Repair Version Metadata</para>
	/// <para>Repairs inconsistencies in the versioning system tables of a geodatabase that contains traditional versions.</para>
	/// </summary>
	public class RepairVersionMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which versioning system table inconsistencies exist. The connection must be made as the geodatabase administrator.</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Repair Version Metadata Log</para>
		/// <para>The output log file. The log file is an ASCII file containing the results of the repair operation.</para>
		/// </param>
		public RepairVersionMetadata(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Version Metadata</para>
		/// </summary>
		public override string DisplayName => "Repair Version Metadata";

		/// <summary>
		/// <para>Tool Name : RepairVersionMetadata</para>
		/// </summary>
		public override string ToolName => "RepairVersionMetadata";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairVersionMetadata</para>
		/// </summary>
		public override string ExcuteName => "management.RepairVersionMetadata";

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
		public override object[] Parameters => new object[] { InputDatabase, OutLog, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The database connection (.sde file) to the enterprise geodatabase in which versioning system table inconsistencies exist. The connection must be made as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Repair Version Metadata Log</para>
		/// <para>The output log file. The log file is an ASCII file containing the results of the repair operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairVersionMetadata SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
