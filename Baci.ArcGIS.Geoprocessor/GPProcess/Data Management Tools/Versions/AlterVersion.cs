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
	/// <para>Alters the properties of a geodatabase version.</para>
	/// </summary>
	public class AlterVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The database connection file to the enterprise, workgroup, or desktop geodatabase where the version to be altered is located.</para>
		/// <para>For branch versioning, use a feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer) or the feature layer portal item.</para>
		/// </param>
		/// <param name="InVersion">
		/// <para>Input Version</para>
		/// <para>The name of the version to be altered. If altering a branch version from a database connection connected as the geodatabase administrator, the version name must also include the service name, for example, myservice.versionowner.versionname.</para>
		/// </param>
		public AlterVersion(object InWorkspace, object InVersion)
		{
			this.InWorkspace = InWorkspace;
			this.InVersion = InVersion;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Version</para>
		/// </summary>
		public override string DisplayName => "Alter Version";

		/// <summary>
		/// <para>Tool Name : AlterVersion</para>
		/// </summary>
		public override string ToolName => "AlterVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterVersion</para>
		/// </summary>
		public override string ExcuteName => "management.AlterVersion";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, InVersion, Name, Description, Access, OutWorkspace, TargetOwner };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The database connection file to the enterprise, workgroup, or desktop geodatabase where the version to be altered is located.</para>
		/// <para>For branch versioning, use a feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer) or the feature layer portal item.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Input Version</para>
		/// <para>The name of the version to be altered. If altering a branch version from a database connection connected as the geodatabase administrator, the version name must also include the service name, for example, myservice.versionowner.versionname.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InVersion { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>The new name of the version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Version Description</para>
		/// <para>The new description of the version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Access Permission</para>
		/// <para>Specifies the access permission for the version. If no value is specified, the access permission will not be updated.</para>
		/// <para>Private—Only the owner can view the version and modify available feature classes.</para>
		/// <para>Public— Any user can view the version and modify available feature classes.</para>
		/// <para>Protected—Any user can view the version, but only the owner can modify available feature classes.</para>
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
		/// <para>The name of the portal user to which the version ownership will be transferred. Ensure that the target owner user exists; the tool does not check the validity of the owner name specified. This parameter is only applicable for branch versions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TargetOwner { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterVersion SetEnviroment(object workspace = null )
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
			/// <para>Private—Only the owner can view the version and modify available feature classes.</para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("Private")]
			Private,

			/// <summary>
			/// <para>Public— Any user can view the version and modify available feature classes.</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("Public")]
			Public,

			/// <summary>
			/// <para>Protected—Any user can view the version, but only the owner can modify available feature classes.</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("Protected")]
			Protected,

		}

#endregion
	}
}
