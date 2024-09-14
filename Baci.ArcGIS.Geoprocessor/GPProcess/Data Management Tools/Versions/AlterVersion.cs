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
	/// <para>Alter Version</para>
	/// <para>更改版本</para>
	/// <para>用于更改地理数据库版本的属性。</para>
	/// </summary>
	public class AlterVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>要更改的版本所在的企业级、工作组或桌面地理数据库的数据库连接文件。</para>
		/// <para>对于分支版本化，请使用要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）或要素图层门户项目。</para>
		/// </param>
		/// <param name="InVersion">
		/// <para>Input Version</para>
		/// <para>要更改的版本的名称。如果要更改以地理数据库管理员身份连接的数据库连接的分支版本，则版本名称还必须包含服务名称，例如 myservice.versionowner.versionname。</para>
		/// </param>
		public AlterVersion(object InWorkspace, object InVersion)
		{
			this.InWorkspace = InWorkspace;
			this.InVersion = InVersion;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改版本</para>
		/// </summary>
		public override string DisplayName() => "更改版本";

		/// <summary>
		/// <para>Tool Name : AlterVersion</para>
		/// </summary>
		public override string ToolName() => "AlterVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterVersion";

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
		public override object[] Parameters() => new object[] { InWorkspace, InVersion, Name, Description, Access, OutWorkspace, TargetOwner };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>要更改的版本所在的企业级、工作组或桌面地理数据库的数据库连接文件。</para>
		/// <para>对于分支版本化，请使用要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）或要素图层门户项目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Input Version</para>
		/// <para>要更改的版本的名称。如果要更改以地理数据库管理员身份连接的数据库连接的分支版本，则版本名称还必须包含服务名称，例如 myservice.versionowner.versionname。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InVersion { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>版本的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Version Description</para>
		/// <para>版本的新描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Access Permission</para>
		/// <para>指定版本的访问权限。如果未指定值，则将不会更新访问权限。</para>
		/// <para>私有—只有所有者可以查看该版本并修改可用的要素类。</para>
		/// <para>公共— 任何用户都可以查看该版本并修改可用的要素类。</para>
		/// <para>受保护—任何用户都可以查看该版本，但只有所有者才能修改可用的要素类。</para>
		/// <para><see cref="AccessEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Access { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Target Owner</para>
		/// <para>版本所有权将转移到的门户用户的名称。请确保目标所有者用户已存在；该工具不会检查指定所有者名称的有效性。此参数仅适用于分支版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetOwner { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterVersion SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Access Permission</para>
		/// </summary>
		public enum AccessEnum 
		{
			/// <summary>
			/// <para>私有—只有所有者可以查看该版本并修改可用的要素类。</para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("私有")]
			Private,

			/// <summary>
			/// <para>公共— 任何用户都可以查看该版本并修改可用的要素类。</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("公共")]
			Public,

			/// <summary>
			/// <para>受保护—任何用户都可以查看该版本，但只有所有者才能修改可用的要素类。</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("受保护")]
			Protected,

		}

#endregion
	}
}
