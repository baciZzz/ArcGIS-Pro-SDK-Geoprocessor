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
	/// <para>Delete Version</para>
	/// <para>删除版本</para>
	/// <para>可从输入企业级、工作组或桌面地理数据库中删除指定的版本。</para>
	/// </summary>
	public class DeleteVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>指定要删除的版本所在的企业级、工作组和桌面地理数据库的数据库连接文件。</para>
		/// <para>对于分支版本化，可以使用要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）或要素图层门户项目。当以地理数据库管理员用户 (sde) 身份连接时，您还可以通过数据库连接文件（连接到分支版本化工作空间）删除分支版本。</para>
		/// </param>
		/// <param name="VersionName">
		/// <para>Version Name</para>
		/// <para>指定要删除的版本的名称。</para>
		/// <para>对于分支版本化，要删除的分支版本的名称应完全限定。例如 servicename.portaluser.versionname。</para>
		/// </param>
		public DeleteVersion(object InWorkspace, object VersionName)
		{
			this.InWorkspace = InWorkspace;
			this.VersionName = VersionName;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除版本</para>
		/// </summary>
		public override string DisplayName() => "删除版本";

		/// <summary>
		/// <para>Tool Name : DeleteVersion</para>
		/// </summary>
		public override string ToolName() => "DeleteVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteVersion";

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
		public override object[] Parameters() => new object[] { InWorkspace, VersionName, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>指定要删除的版本所在的企业级、工作组和桌面地理数据库的数据库连接文件。</para>
		/// <para>对于分支版本化，可以使用要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）或要素图层门户项目。当以地理数据库管理员用户 (sde) 身份连接时，您还可以通过数据库连接文件（连接到分支版本化工作空间）删除分支版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>指定要删除的版本的名称。</para>
		/// <para>对于分支版本化，要删除的分支版本的名称应完全限定。例如 servicename.portaluser.versionname。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object VersionName { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteVersion SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
