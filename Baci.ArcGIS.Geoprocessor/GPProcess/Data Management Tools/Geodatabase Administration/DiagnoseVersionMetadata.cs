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
	/// <para>诊断版本元数据</para>
	/// <para>用于标识地理数据库中用于管理传统版本和状态的系统表中的不一致。</para>
	/// </summary>
	public class DiagnoseVersionMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中可能存在传统版本化系统表不一致。</para>
		/// <para>必须由地理数据库管理员建立此连接。</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Diagnostic Version Metadata Log</para>
		/// <para>输出日志文件的名称和位置。</para>
		/// <para>日志文件是 ASCII 文件，其中包含指定版本的系统表列表，这些系统表中包含不一致的 记录，以及所使用的数据库连接文件。</para>
		/// </param>
		public DiagnoseVersionMetadata(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : 诊断版本元数据</para>
		/// </summary>
		public override string DisplayName() => "诊断版本元数据";

		/// <summary>
		/// <para>Tool Name : DiagnoseVersionMetadata</para>
		/// </summary>
		public override string ToolName() => "DiagnoseVersionMetadata";

		/// <summary>
		/// <para>Tool Excute Name : management.DiagnoseVersionMetadata</para>
		/// </summary>
		public override string ExcuteName() => "management.DiagnoseVersionMetadata";

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
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中可能存在传统版本化系统表不一致。</para>
		/// <para>必须由地理数据库管理员建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Diagnostic Version Metadata Log</para>
		/// <para>输出日志文件的名称和位置。</para>
		/// <para>日志文件是 ASCII 文件，其中包含指定版本的系统表列表，这些系统表中包含不一致的 记录，以及所使用的数据库连接文件。</para>
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
		public DiagnoseVersionMetadata SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
