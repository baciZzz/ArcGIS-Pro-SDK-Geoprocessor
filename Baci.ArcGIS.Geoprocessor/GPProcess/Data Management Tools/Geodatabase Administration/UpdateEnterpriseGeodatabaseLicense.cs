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
	/// <para>Update Enterprise Geodatabase License</para>
	/// <para>更新企业级地理数据库许可</para>
	/// <para>更新企业级地理数据库中的 ArcGIS Server 许可。</para>
	/// </summary>
	public class UpdateEnterpriseGeodatabaseLicense : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>可利用新的 ArcGIS Server 企业级授权文件为想要授权的企业级数据库提供数据库连接（.sde 文件）。</para>
		/// <para>您必须以地理数据库管理员的身份连接到数据库。</para>
		/// </param>
		/// <param name="AuthorizationFile">
		/// <para>Authorization File</para>
		/// <para>提供授权企业级 ArcGIS Server 时生成的密钥代码文件的路径和文件名。 如有必要，请将文件从 ArcGIS Server 计算机复制到此工具可访问的目录。</para>
		/// <para>ArcGIS Server 将在以下位置上创建密钥代码文件：\\Program Files\ESRI\License&lt;release#&gt;\sysgen（Microsoft Windows 服务器）或 /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen（Linux 服务器）。</para>
		/// </param>
		public UpdateEnterpriseGeodatabaseLicense(object InputDatabase, object AuthorizationFile)
		{
			this.InputDatabase = InputDatabase;
			this.AuthorizationFile = AuthorizationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新企业级地理数据库许可</para>
		/// </summary>
		public override string DisplayName() => "更新企业级地理数据库许可";

		/// <summary>
		/// <para>Tool Name : UpdateEnterpriseGeodatabaseLicense</para>
		/// </summary>
		public override string ToolName() => "UpdateEnterpriseGeodatabaseLicense";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateEnterpriseGeodatabaseLicense</para>
		/// </summary>
		public override string ExcuteName() => "management.UpdateEnterpriseGeodatabaseLicense";

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
		/// <para>可利用新的 ArcGIS Server 企业级授权文件为想要授权的企业级数据库提供数据库连接（.sde 文件）。</para>
		/// <para>您必须以地理数据库管理员的身份连接到数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Authorization File</para>
		/// <para>提供授权企业级 ArcGIS Server 时生成的密钥代码文件的路径和文件名。 如有必要，请将文件从 ArcGIS Server 计算机复制到此工具可访问的目录。</para>
		/// <para>ArcGIS Server 将在以下位置上创建密钥代码文件：\\Program Files\ESRI\License&lt;release#&gt;\sysgen（Microsoft Windows 服务器）或 /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen（Linux 服务器）。</para>
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
		public UpdateEnterpriseGeodatabaseLicense SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
