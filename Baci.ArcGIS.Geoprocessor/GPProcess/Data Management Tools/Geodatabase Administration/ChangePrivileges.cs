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
	/// <para>Change Privileges</para>
	/// <para>更改权限</para>
	/// <para>建立或更改输入企业级数据库数据集、独立要素类或表的用户访问权限。</para>
	/// </summary>
	public class ChangePrivileges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>将更改访问权限的数据集、要素类或表。</para>
		/// </param>
		/// <param name="User">
		/// <para>User</para>
		/// <para>要修改其权限的数据库用户名。</para>
		/// </param>
		public ChangePrivileges(object InDataset, object User)
		{
			this.InDataset = InDataset;
			this.User = User;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改权限</para>
		/// </summary>
		public override string DisplayName() => "更改权限";

		/// <summary>
		/// <para>Tool Name : ChangePrivileges</para>
		/// </summary>
		public override string ToolName() => "ChangePrivileges";

		/// <summary>
		/// <para>Tool Excute Name : management.ChangePrivileges</para>
		/// </summary>
		public override string ExcuteName() => "management.ChangePrivileges";

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
		public override object[] Parameters() => new object[] { InDataset, User, View, Edit, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>将更改访问权限的数据集、要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>User</para>
		/// <para>要修改其权限的数据库用户名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object User { get; set; }

		/// <summary>
		/// <para>View (Select)</para>
		/// <para>建立用户的查看权限。</para>
		/// <para>不更改查看权限—不更改用户现有查看权限。如果用户具有查看权限，则将继续持有查看权限。如果用户不具备查看权限，则将继续不持有查看权限。</para>
		/// <para>授予查看权限—允许用户查看数据集。</para>
		/// <para>撤消查看权限—撤消用户查看数据集的所有权限。</para>
		/// <para><see cref="ViewEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object View { get; set; }

		/// <summary>
		/// <para>Edit (Update/Insert/Delete)</para>
		/// <para>建立用户的编辑权限。</para>
		/// <para>不更改编辑权限— 不更改用户现有编辑权限。如果用户具有编辑权限，则将继续持有编辑权限。如果用户不具备编辑权限，则将继续不持有编辑权限。这是默认设置。</para>
		/// <para>授予编辑权限—允许用户编辑输入数据集。</para>
		/// <para>撤消编辑权限—撤消用户的编辑权限。用户仍然可以查看输入数据集。</para>
		/// <para><see cref="EditEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Edit { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ChangePrivileges SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>View (Select)</para>
		/// </summary>
		public enum ViewEnum 
		{
			/// <summary>
			/// <para>不更改查看权限—不更改用户现有查看权限。如果用户具有查看权限，则将继续持有查看权限。如果用户不具备查看权限，则将继续不持有查看权限。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("不更改查看权限")]
			Do_not_change_to_view_privileges,

			/// <summary>
			/// <para>授予查看权限—允许用户查看数据集。</para>
			/// </summary>
			[GPValue("GRANT")]
			[Description("授予查看权限")]
			Grant_view_privileges,

			/// <summary>
			/// <para>撤消查看权限—撤消用户查看数据集的所有权限。</para>
			/// </summary>
			[GPValue("REVOKE")]
			[Description("撤消查看权限")]
			Revoke_view_privileges,

		}

		/// <summary>
		/// <para>Edit (Update/Insert/Delete)</para>
		/// </summary>
		public enum EditEnum 
		{
			/// <summary>
			/// <para>不更改编辑权限— 不更改用户现有编辑权限。如果用户具有编辑权限，则将继续持有编辑权限。如果用户不具备编辑权限，则将继续不持有编辑权限。这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("不更改编辑权限")]
			Do_not_change_edit_privileges,

			/// <summary>
			/// <para>授予编辑权限—允许用户编辑输入数据集。</para>
			/// </summary>
			[GPValue("GRANT")]
			[Description("授予编辑权限")]
			Grant_edit_privileges,

			/// <summary>
			/// <para>撤消编辑权限—撤消用户的编辑权限。用户仍然可以查看输入数据集。</para>
			/// </summary>
			[GPValue("REVOKE")]
			[Description("撤消编辑权限")]
			Revoke_edit_privileges,

		}

#endregion
	}
}
