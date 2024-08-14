using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Upgrade Workflow Database</para>
	/// <para>Upgrades an existing Workflow Manager (Classic) database with the latest  schema and configuration. The Workflow Manager (Classic) database is used to store the job and configuration information for your work management system and one feature class that is used to store the geometries for the location of interest (LOI) for your jobs.</para>
	/// </summary>
	public class UpgradeWorkflowDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabaseConnection">
		/// <para>Input Database Connection</para>
		/// <para>The location of the enterprise geodatabase connection file to the Workflow Manager (Classic) database, which contains Workflow Manager (Classic) system tables. The connection file must connect directly to the database, and the connection should be made as a database owner.</para>
		/// </param>
		public UpgradeWorkflowDatabase(object InputDatabaseConnection)
		{
			this.InputDatabaseConnection = InputDatabaseConnection;
		}

		/// <summary>
		/// <para>Tool Display Name : Upgrade Workflow Database</para>
		/// </summary>
		public override string DisplayName => "Upgrade Workflow Database";

		/// <summary>
		/// <para>Tool Name : UpgradeWorkflowDatabase</para>
		/// </summary>
		public override string ToolName => "UpgradeWorkflowDatabase";

		/// <summary>
		/// <para>Tool Excute Name : wmx.UpgradeWorkflowDatabase</para>
		/// </summary>
		public override string ExcuteName => "wmx.UpgradeWorkflowDatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputDatabaseConnection, UserStore!, OutputDatabasepath! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The location of the enterprise geodatabase connection file to the Workflow Manager (Classic) database, which contains Workflow Manager (Classic) system tables. The connection file must connect directly to the database, and the connection should be made as a database owner.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabaseConnection { get; set; }

		/// <summary>
		/// <para>User Store</para>
		/// <para>Specifies the user store from which the users and roles will be retrieved. The users can be imported from a portal and are assigned to roles created in the Workflow Manager (Classic) repository. The portal user profile information cannot be edited using ArcGIS Workflow Manager (Classic) Administrator. The users and roles can be created in the Workflow Manager (Classic) repository using the Traditional option. When using the Traditional option, the users and roles can be imported from the Active Directory in ArcGIS Workflow Manager (Classic) Administrator.</para>
		/// <para>Portal—The users will be imported from the portal you are currently signed in to.</para>
		/// <para>Traditional—The users and roles will be created in the Workflow Manager (Classic) repository using ArcGIS Workflow Manager (Classic) Administrator. Users and roles can be imported from the Active Directory when this option is used. This is the default.</para>
		/// <para><see cref="UserStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? UserStore { get; set; }

		/// <summary>
		/// <para>Output Database Path (.jtc)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		public object? OutputDatabasepath { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpgradeWorkflowDatabase SetEnviroment(object? configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>User Store</para>
		/// </summary>
		public enum UserStoreEnum 
		{
			/// <summary>
			/// <para>Traditional—The users and roles will be created in the Workflow Manager (Classic) repository using ArcGIS Workflow Manager (Classic) Administrator. Users and roles can be imported from the Active Directory when this option is used. This is the default.</para>
			/// </summary>
			[GPValue("TRADITIONAL")]
			[Description("Traditional")]
			Traditional,

			/// <summary>
			/// <para>Portal—The users will be imported from the portal you are currently signed in to.</para>
			/// </summary>
			[GPValue("PORTAL")]
			[Description("Portal")]
			Portal,

		}

#endregion
	}
}
