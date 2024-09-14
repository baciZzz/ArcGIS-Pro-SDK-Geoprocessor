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
	/// <para>Import Geodatabase Configuration Keywords</para>
	/// <para>导入地理数据库配置关键字</para>
	/// <para>此工具可用于通过导入包含配置关键字、参数和值的文件来定义企业级地理数据库的数据存储参数。</para>
	/// </summary>
	public class ImportGeodatabaseConfigurationKeywords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>要导入配置文件的企业级地理数据库的连接文件。您必须以地理数据库管理员身份进行连接。</para>
		/// </param>
		/// <param name="InFile">
		/// <para>Input File</para>
		/// <para>包含要导入的配置关键字、参数和值的 ASCII 文本文件的路径和名称。</para>
		/// </param>
		public ImportGeodatabaseConfigurationKeywords(object InputDatabase, object InFile)
		{
			this.InputDatabase = InputDatabase;
			this.InFile = InFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入地理数据库配置关键字</para>
		/// </summary>
		public override string DisplayName() => "导入地理数据库配置关键字";

		/// <summary>
		/// <para>Tool Name : ImportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ToolName() => "ImportGeodatabaseConfigurationKeywords";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportGeodatabaseConfigurationKeywords";

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
		public override object[] Parameters() => new object[] { InputDatabase, InFile, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>要导入配置文件的企业级地理数据库的连接文件。您必须以地理数据库管理员身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Input File</para>
		/// <para>包含要导入的配置关键字、参数和值的 ASCII 文本文件的路径和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InFile { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportGeodatabaseConfigurationKeywords SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
