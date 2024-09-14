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
	/// <para>Create Version</para>
	/// <para>创建版本</para>
	/// <para>在指定的地理数据库中创建新版本。</para>
	/// </summary>
	[Obsolete()]
	public class CreateVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>包含父版本并将包含新版本的企业级地理数据库。</para>
		/// <para>对于分支版本化，请使用要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）。</para>
		/// </param>
		/// <param name="ParentVersion">
		/// <para>Parent Version</para>
		/// <para>新版本所基于的地理数据库或地理数据库的版本。</para>
		/// </param>
		/// <param name="VersionName">
		/// <para>Version Name</para>
		/// <para>要创建的版本的名称。</para>
		/// </param>
		public CreateVersion(object InWorkspace, object ParentVersion, object VersionName)
		{
			this.InWorkspace = InWorkspace;
			this.ParentVersion = ParentVersion;
			this.VersionName = VersionName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建版本</para>
		/// </summary>
		public override string DisplayName() => "创建版本";

		/// <summary>
		/// <para>Tool Name : CreateVersion</para>
		/// </summary>
		public override string ToolName() => "CreateVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateVersion";

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
		public override object[] Parameters() => new object[] { InWorkspace, ParentVersion, VersionName, AccessPermission, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含父版本并将包含新版本的企业级地理数据库。</para>
		/// <para>对于分支版本化，请使用要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Parent Version</para>
		/// <para>新版本所基于的地理数据库或地理数据库的版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ParentVersion { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>要创建的版本的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object VersionName { get; set; }

		/// <summary>
		/// <para>Access Permission</para>
		/// <para>版本的访问权限级别可防止版本被所有者以外的用户编辑或查看。</para>
		/// <para>私有（仅限所有者）—只有所有者或地理数据库管理员可以查看和修改版本或已版本化的数据。</para>
		/// <para>公共（任意用户）—任何用户都可查看版本。任何具有数据集读/写（更新、插入和删除）权限的用户都可以修改版本中的数据集。</para>
		/// <para>受保护的（仅所有者可编辑）—任何用户都可以查看版本，但只有所有者或地理数据库管理员可以编辑版本或版本中的数据集。</para>
		/// <para><see cref="AccessPermissionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AccessPermission { get; set; } = "PRIVATE";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateVersion SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Access Permission</para>
		/// </summary>
		public enum AccessPermissionEnum 
		{
			/// <summary>
			/// <para>私有（仅限所有者）—只有所有者或地理数据库管理员可以查看和修改版本或已版本化的数据。</para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("私有（仅限所有者）")]
			PRIVATE,

			/// <summary>
			/// <para>公共（任意用户）—任何用户都可查看版本。任何具有数据集读/写（更新、插入和删除）权限的用户都可以修改版本中的数据集。</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("公共（任意用户）")]
			PUBLIC,

			/// <summary>
			/// <para>受保护的（仅所有者可编辑）—任何用户都可以查看版本，但只有所有者或地理数据库管理员可以编辑版本或版本中的数据集。</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("受保护的（仅所有者可编辑）")]
			PROTECTED,

		}

#endregion
	}
}
