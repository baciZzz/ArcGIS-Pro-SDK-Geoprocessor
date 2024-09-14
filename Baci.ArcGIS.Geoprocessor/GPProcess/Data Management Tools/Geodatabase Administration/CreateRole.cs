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
	/// <para>Create Role</para>
	/// <para>创建角色</para>
	/// <para>创建数据库角色，以允许在角色中添加用户或移除用户。</para>
	/// </summary>
	public class CreateRole : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>到数据库或企业级地理数据库的连接文件。数据库管理员用户的身份进行连接。</para>
		/// </param>
		/// <param name="Role">
		/// <para>Role</para>
		/// <para>要创建的数据库角色的名称。如果该角色是现有角色，输入要在其中添加用户或一处用户的角色的名称。</para>
		/// </param>
		public CreateRole(object InputDatabase, object Role)
		{
			this.InputDatabase = InputDatabase;
			this.Role = Role;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建角色</para>
		/// </summary>
		public override string DisplayName() => "创建角色";

		/// <summary>
		/// <para>Tool Name : CreateRole</para>
		/// </summary>
		public override string ToolName() => "CreateRole";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRole</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRole";

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
		public override object[] Parameters() => new object[] { InputDatabase, Role, GrantRevoke, UserName, OutResult };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>到数据库或企业级地理数据库的连接文件。数据库管理员用户的身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Role</para>
		/// <para>要创建的数据库角色的名称。如果该角色是现有角色，输入要在其中添加用户或一处用户的角色的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Role { get; set; }

		/// <summary>
		/// <para>Grant To or Revoke From User(s)</para>
		/// <para>指定是将角色添加到用户或用户列表，还是从角色中移除用户或用户列表。</para>
		/// <para>授予角色—该角色将授予指定的一个或多个用户，使其成为角色的成员。这是默认设置。</para>
		/// <para>撤消角色—该角色将从指定的一个或多个用户中撤消，以将其从角色中移除。</para>
		/// <para><see cref="GrantRevokeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GrantRevoke { get; set; } = "GRANT";

		/// <summary>
		/// <para>User Name(s)</para>
		/// <para>要更改角色成员资格的用户的名称。要指定多个用户，请输入以逗号（无空格）分隔的用户名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object UserName { get; set; }

		/// <summary>
		/// <para>Create Role Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResult { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRole SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Grant To or Revoke From User(s)</para>
		/// </summary>
		public enum GrantRevokeEnum 
		{
			/// <summary>
			/// <para>授予角色—该角色将授予指定的一个或多个用户，使其成为角色的成员。这是默认设置。</para>
			/// </summary>
			[GPValue("GRANT")]
			[Description("授予角色")]
			Grant_role,

			/// <summary>
			/// <para>撤消角色—该角色将从指定的一个或多个用户中撤消，以将其从角色中移除。</para>
			/// </summary>
			[GPValue("REVOKE")]
			[Description("撤消角色")]
			Revoke_role,

		}

#endregion
	}
}
