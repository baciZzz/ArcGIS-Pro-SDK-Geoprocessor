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
	/// <para>Create Version</para>
	/// <para>Creates a new version in the specified geodatabase.</para>
	/// </summary>
	[Obsolete()]
	public class CreateVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The enterprise geodatabase that contains the parent version and will contain the new version.</para>
		/// <para>For branch versioning, use a feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer).</para>
		/// </param>
		/// <param name="ParentVersion">
		/// <para>Parent Version</para>
		/// <para>The geodatabase, or version of a geodatabase, on which the new version will be based.</para>
		/// </param>
		/// <param name="VersionName">
		/// <para>Version Name</para>
		/// <para>The name of the version to be created.</para>
		/// </param>
		public CreateVersion(object InWorkspace, object ParentVersion, object VersionName)
		{
			this.InWorkspace = InWorkspace;
			this.ParentVersion = ParentVersion;
			this.VersionName = VersionName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Version</para>
		/// </summary>
		public override string DisplayName() => "Create Version";

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
		/// <para>The enterprise geodatabase that contains the parent version and will contain the new version.</para>
		/// <para>For branch versioning, use a feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Parent Version</para>
		/// <para>The geodatabase, or version of a geodatabase, on which the new version will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ParentVersion { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>The name of the version to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object VersionName { get; set; }

		/// <summary>
		/// <para>Access Permission</para>
		/// <para>The permission access level for the version to protect it from being edited or viewed by users other than the owner.</para>
		/// <para>Private (owner only)—Only the owner or the geodatabase administrator can view and modify the version or versioned data.</para>
		/// <para>Public (any user)—Any user can view the version. Any user who has been granted read/write (update, insert, and delete) permissions on datasets can modify datasets in the version.</para>
		/// <para>Protected (only the owner can edit)—Any user can view the version, but only the owner or the geodatabase administrator can edit the version or datasets in the version.</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("Private (owner  only)")]
			PRIVATE,

			/// <summary>
			/// <para>Public (any user)—Any user can view the version. Any user who has been granted read/write (update, insert, and delete) permissions on datasets can modify datasets in the version.</para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("Public (any user)")]
			PUBLIC,

			/// <summary>
			/// <para>Protected (only the owner can edit)—Any user can view the version, but only the owner or the geodatabase administrator can edit the version or datasets in the version.</para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("Protected (only the owner can edit)")]
			PROTECTED,

		}

#endregion
	}
}
