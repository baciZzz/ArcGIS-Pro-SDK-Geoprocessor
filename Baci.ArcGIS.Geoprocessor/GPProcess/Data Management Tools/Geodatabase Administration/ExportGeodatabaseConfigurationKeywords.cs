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
	/// <para>Export Geodatabase Configuration Keywords</para>
	/// <para>导出地理数据库配置关键字</para>
	/// <para>此工具可用于将指定企业级地理数据库中的配置关键字、参数和值导出为可编辑文件。更改参数值或向文件添加自定义配置关键字，然后使用导入地理数据库配置关键字工具将更改导入到地理数据库。</para>
	/// </summary>
	public class ExportGeodatabaseConfigurationKeywords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>要从中导出配置关键字、参数和值的企业地理数据库的连接文件。您必须以地理数据库管理员身份进行连接。</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
		/// <para>待创建的 ASCII 文本文件的名称和完整路径。文件将包含企业级地理数据库的 DBTUNE（或 SDE_DBTUNE）系统表中的所有配置关键字、参数和值。</para>
		/// </param>
		public ExportGeodatabaseConfigurationKeywords(object InputDatabase, object OutFile)
		{
			this.InputDatabase = InputDatabase;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出地理数据库配置关键字</para>
		/// </summary>
		public override string DisplayName() => "导出地理数据库配置关键字";

		/// <summary>
		/// <para>Tool Name : ExportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ToolName() => "ExportGeodatabaseConfigurationKeywords";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportGeodatabaseConfigurationKeywords";

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
		public override object[] Parameters() => new object[] { InputDatabase, OutFile, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>要从中导出配置关键字、参数和值的企业地理数据库的连接文件。您必须以地理数据库管理员身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>待创建的 ASCII 文本文件的名称和完整路径。文件将包含企业级地理数据库的 DBTUNE（或 SDE_DBTUNE）系统表中的所有配置关键字、参数和值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportGeodatabaseConfigurationKeywords SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
