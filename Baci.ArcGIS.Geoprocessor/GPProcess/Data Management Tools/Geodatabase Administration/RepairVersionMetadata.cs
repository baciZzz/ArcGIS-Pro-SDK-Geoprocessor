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
	/// <para>修复版本元数据</para>
	/// <para>修复包含传统版本的地理数据库的版本化系统表中的不一致。</para>
	/// </summary>
	public class RepairVersionMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中存在版本化系统表不一致。 必须由地理数据库管理员建立此连接。</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Repair Version Metadata Log</para>
		/// <para>输出日志文件。 日志文件是包含修复操作结果的 ASCII 文件。</para>
		/// </param>
		public RepairVersionMetadata(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : 修复版本元数据</para>
		/// </summary>
		public override string DisplayName() => "修复版本元数据";

		/// <summary>
		/// <para>Tool Name : RepairVersionMetadata</para>
		/// </summary>
		public override string ToolName() => "RepairVersionMetadata";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairVersionMetadata</para>
		/// </summary>
		public override string ExcuteName() => "management.RepairVersionMetadata";

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
		public override object[] Parameters() => new object[] { InputDatabase, OutLog, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中存在版本化系统表不一致。 必须由地理数据库管理员建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Repair Version Metadata Log</para>
		/// <para>输出日志文件。 日志文件是包含修复操作结果的 ASCII 文件。</para>
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
