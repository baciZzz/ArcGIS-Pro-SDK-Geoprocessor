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
	/// <para>诊断版本表</para>
	/// <para>用于识别注册传统版本化的数据集增量（A 和 D）表中的不一致。</para>
	/// </summary>
	public class DiagnoseVersionTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中可能存在增量表不一致。 必须由地理数据库管理员建立此连接。</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Diagnose Version Tables Log</para>
		/// <para>输出日志文件的路径和名称。 日志文件是 ASCII 文件，其中包含指定版本的增量表列表，增量表中包含不一致的 记录，以及关于连接文件、数据库版本和运行工具的表的信息。</para>
		/// </param>
		public DiagnoseVersionTables(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : 诊断版本表</para>
		/// </summary>
		public override string DisplayName() => "诊断版本表";

		/// <summary>
		/// <para>Tool Name : DiagnoseVersionTables</para>
		/// </summary>
		public override string ToolName() => "DiagnoseVersionTables";

		/// <summary>
		/// <para>Tool Excute Name : management.DiagnoseVersionTables</para>
		/// </summary>
		public override string ExcuteName() => "management.DiagnoseVersionTables";

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
		public override object[] Parameters() => new object[] { InputDatabase, OutLog, TargetVersion, InputTables, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中可能存在增量表不一致。 必须由地理数据库管理员建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Diagnose Version Tables Log</para>
		/// <para>输出日志文件的路径和名称。 日志文件是 ASCII 文件，其中包含指定版本的增量表列表，增量表中包含不一致的 记录，以及关于连接文件、数据库版本和运行工具的表的信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>包含要检查不一致的增量表的地理数据库版本。 使用为输入数据集连接参数指定的地理数据库中的现有版本填充下拉列表。 如果未选定版本，则将处理所有版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetVersion { get; set; }

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>单个表或文本文件，其中包含要为其相关增量表检查不一致的版本化表列表。 在文本文件中使用完全限定的表名，每个表名占据一行。 如果未指定文件，则将处理地理数据库中的所有表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InputTables { get; set; }

		/// <summary>
		/// <para>Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DiagnoseVersionTables SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
