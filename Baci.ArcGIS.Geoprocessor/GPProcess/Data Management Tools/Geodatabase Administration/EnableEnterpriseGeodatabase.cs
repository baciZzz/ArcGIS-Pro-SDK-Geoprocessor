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
	/// <para>Enable Enterprise Geodatabase</para>
	/// <para>启用企业级地理数据库</para>
	/// <para>在现有数据库中创建地理数据库系统表、存储过程、函数和类型，以启用数据库中的地理数据库功能。</para>
	/// </summary>
	public class EnableEnterpriseGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>为数据库（将在其中启用地理数据库功能）提供的路径和连接文件名。 必须以具有地理数据库管理员资格的用户身份进行连接。</para>
		/// </param>
		/// <param name="AuthorizationFile">
		/// <para>Authorization File</para>
		/// <para>授权 ArcGIS Server 时创建的密钥代码文件的路径和文件名。 此文件位于 Linux 的 \\Program Files\ESRI\License&lt;release#&gt;\sysgen 文件夹或 Windows 的 /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen 目录中。 如果尚未执行此操作，则请授权 ArcGIS Server 来创建此文件。</para>
		/// <para>从 ArcGIS Server 计算机将密钥代码文件复制到工具可访问的位置。</para>
		/// </param>
		public EnableEnterpriseGeodatabase(object InputDatabase, object AuthorizationFile)
		{
			this.InputDatabase = InputDatabase;
			this.AuthorizationFile = AuthorizationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用企业级地理数据库</para>
		/// </summary>
		public override string DisplayName() => "启用企业级地理数据库";

		/// <summary>
		/// <para>Tool Name : EnableEnterpriseGeodatabase</para>
		/// </summary>
		public override string ToolName() => "EnableEnterpriseGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableEnterpriseGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableEnterpriseGeodatabase";

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
		public override object[] Parameters() => new object[] { InputDatabase, AuthorizationFile, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>为数据库（将在其中启用地理数据库功能）提供的路径和连接文件名。 必须以具有地理数据库管理员资格的用户身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Authorization File</para>
		/// <para>授权 ArcGIS Server 时创建的密钥代码文件的路径和文件名。 此文件位于 Linux 的 \\Program Files\ESRI\License&lt;release#&gt;\sysgen 文件夹或 Windows 的 /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen 目录中。 如果尚未执行此操作，则请授权 ArcGIS Server 来创建此文件。</para>
		/// <para>从 ArcGIS Server 计算机将密钥代码文件复制到工具可访问的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object AuthorizationFile { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnableEnterpriseGeodatabase SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
