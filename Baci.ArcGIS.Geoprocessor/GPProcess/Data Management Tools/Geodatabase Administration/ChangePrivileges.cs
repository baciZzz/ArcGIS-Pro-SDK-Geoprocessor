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
	/// <para>Change Privileges</para>
	/// <para>Establishes or changes user access privileges to the input enterprise database datasets, stand-alone feature classes, or tables.</para>
	/// </summary>
	public class ChangePrivileges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The datasets, feature classes, or tables whose access privileges will be changed.</para>
		/// </param>
		/// <param name="User">
		/// <para>User</para>
		/// <para>The database user name whose privileges are being modified.</para>
		/// </param>
		public ChangePrivileges(object InDataset, object User)
		{
			this.InDataset = InDataset;
			this.User = User;
		}

		/// <summary>
		/// <para>Tool Display Name : Change Privileges</para>
		/// </summary>
		public override string DisplayName() => "Change Privileges";

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
		/// <para>The datasets, feature classes, or tables whose access privileges will be changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>User</para>
		/// <para>The database user name whose privileges are being modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object User { get; set; }

		/// <summary>
		/// <para>View (Select)</para>
		/// <para>Establishes the user&apos;s view privileges.</para>
		/// <para>Do not change to view privileges—No change to the user&apos;s existing view privilege. If the user has view privileges, they will continue to have view privileges. If the user doesn&apos;t have view privileges, they will continue to not have view privileges.</para>
		/// <para>Grant view privileges—Allows user to view datasets.</para>
		/// <para>Revoke view privileges—Removes all user privileges to view datasets.</para>
		/// <para><see cref="ViewEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object View { get; set; }

		/// <summary>
		/// <para>Edit (Update/Insert/Delete)</para>
		/// <para>Establishes the user&apos;s edit privileges.</para>
		/// <para>Do not change edit privileges— No change to the user&apos;s existing edit privilege. If the user has edit privileges, they will continue to have edit privileges. If the user doesn&apos;t have edit privileges, they will continue to not have edit privileges. This is the default.</para>
		/// <para>Grant edit privileges—Allows the user to edit the input datasets.</para>
		/// <para>Revoke edit privileges—Removes the user&apos;s edit privileges. The user may still view the input dataset.</para>
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
			/// <para>Do not change to view privileges—No change to the user&apos;s existing view privilege. If the user has view privileges, they will continue to have view privileges. If the user doesn&apos;t have view privileges, they will continue to not have view privileges.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("Do not change to view privileges")]
			Do_not_change_to_view_privileges,

			/// <summary>
			/// <para>Grant view privileges—Allows user to view datasets.</para>
			/// </summary>
			[GPValue("GRANT")]
			[Description("Grant view privileges")]
			Grant_view_privileges,

			/// <summary>
			/// <para>Revoke view privileges—Removes all user privileges to view datasets.</para>
			/// </summary>
			[GPValue("REVOKE")]
			[Description("Revoke view privileges")]
			Revoke_view_privileges,

		}

		/// <summary>
		/// <para>Edit (Update/Insert/Delete)</para>
		/// </summary>
		public enum EditEnum 
		{
			/// <summary>
			/// <para>Do not change edit privileges— No change to the user&apos;s existing edit privilege. If the user has edit privileges, they will continue to have edit privileges. If the user doesn&apos;t have edit privileges, they will continue to not have edit privileges. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("Do not change edit privileges")]
			Do_not_change_edit_privileges,

			/// <summary>
			/// <para>Grant edit privileges—Allows the user to edit the input datasets.</para>
			/// </summary>
			[GPValue("GRANT")]
			[Description("Grant edit privileges")]
			Grant_edit_privileges,

			/// <summary>
			/// <para>Revoke edit privileges—Removes the user&apos;s edit privileges. The user may still view the input dataset.</para>
			/// </summary>
			[GPValue("REVOKE")]
			[Description("Revoke edit privileges")]
			Revoke_edit_privileges,

		}

#endregion
	}
}
