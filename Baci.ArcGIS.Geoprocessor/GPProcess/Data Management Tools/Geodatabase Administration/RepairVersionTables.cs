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
	/// <para>修复版本表</para>
	/// <para>用于修复注册传统版本化的数据集增量（A 和 D）表中的不一致。</para>
	/// </summary>
	public class RepairVersionTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中存在增量表不一致。 必须由地理数据库管理员建立此连接。</para>
		/// </param>
		/// <param name="OutLog">
		/// <para>Repair Version Tables Log</para>
		/// <para>日志文件的写入位置和日志文件名称。 日志文件是包含修复操作结果的 ASCII 文件。</para>
		/// </param>
		public RepairVersionTables(object InputDatabase, object OutLog)
		{
			this.InputDatabase = InputDatabase;
			this.OutLog = OutLog;
		}

		/// <summary>
		/// <para>Tool Display Name : 修复版本表</para>
		/// </summary>
		public override string DisplayName() => "修复版本表";

		/// <summary>
		/// <para>Tool Name : RepairVersionTables</para>
		/// </summary>
		public override string ToolName() => "RepairVersionTables";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairVersionTables</para>
		/// </summary>
		public override string ExcuteName() => "management.RepairVersionTables";

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
		/// <para>与企业级地理数据库的数据库连接（.sde 文件），其中存在增量表不一致。 必须由地理数据库管理员建立此连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Repair Version Tables Log</para>
		/// <para>日志文件的写入位置和日志文件名称。 日志文件是包含修复操作结果的 ASCII 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>待修复的地理数据库版本。 使用为输入数据集连接参数指定的地理数据库中的现有版本填充下拉列表。 如果未选定版本，则将处理所有版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetVersion { get; set; }

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>单个表或文本文件，其中包含其关联增量表待修复的版本化表的列表。 在文本文件中使用完全限定的表名，每个表名占据一行。 如果未指定表或文件，则将处理所有表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InputTables { get; set; }

		/// <summary>
		/// <para>Repaired Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairVersionTables SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
