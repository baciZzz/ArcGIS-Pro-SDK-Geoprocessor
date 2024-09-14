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
	/// <para>Create Role</para>
	/// <para>Creates a database role, allowing you to add users to or remove them from the role.</para>
	/// </summary>
	public class CreateRole : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The connection file to a database or enterprise geodatabase. Connect as a database administrator user.</para>
		/// </param>
		/// <param name="Role">
		/// <para>Role</para>
		/// <para>The name of the database role to create. If it's an existing role, type the name for the role you want to add users to or remove them from.</para>
		/// </param>
		public CreateRole(object InputDatabase, object Role)
		{
			this.InputDatabase = InputDatabase;
			this.Role = Role;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Role</para>
		/// </summary>
		public override string DisplayName() => "Create Role";

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
		public override object[] Parameters() => new object[] { InputDatabase, Role, GrantRevoke!, UserName!, OutResult! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The connection file to a database or enterprise geodatabase. Connect as a database administrator user.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Role</para>
		/// <para>The name of the database role to create. If it's an existing role, type the name for the role you want to add users to or remove them from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Role { get; set; }

		/// <summary>
		/// <para>Grant To or Revoke From User(s)</para>
		/// <para>Specifies whether the role will be added to a user or list of users or a user or list of users will be removed from the role.</para>
		/// <para>Grant role—The role will be granted to the specified user or users, making them a member of the role. This is the default.</para>
		/// <para>Revoke role—The role will be revoked from the specified user or users, removing them from the role.</para>
		/// <para><see cref="GrantRevokeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GrantRevoke { get; set; } = "GRANT";

		/// <summary>
		/// <para>User Name(s)</para>
		/// <para>The name of the user whose role membership will change. To specify multiple users, type the user names separated by commas (no spaces).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? UserName { get; set; }

		/// <summary>
		/// <para>Create Role Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? OutResult { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRole SetEnviroment(object? workspace = null)
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
			/// <para>Grant role—The role will be granted to the specified user or users, making them a member of the role. This is the default.</para>
			/// </summary>
			[GPValue("GRANT")]
			[Description("Grant role")]
			Grant_role,

			/// <summary>
			/// <para>Revoke role—The role will be revoked from the specified user or users, removing them from the role.</para>
			/// </summary>
			[GPValue("REVOKE")]
			[Description("Revoke role")]
			Revoke_role,

		}

#endregion
	}
}
