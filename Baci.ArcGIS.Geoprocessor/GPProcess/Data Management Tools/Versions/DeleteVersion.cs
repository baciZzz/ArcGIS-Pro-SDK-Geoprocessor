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
	/// <para>Deletes the specified version from the input enterprise, workgroup, or desktop geodatabase.</para>
	/// </summary>
	public class DeleteVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>Specifies the database connection file to the enterprise, workgroup, or desktop geodatabase containing the version to be deleted.</para>
		/// <para>For branch versioning, you can use a feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer) or a feature layer portal item. You can also delete a branch version via a database connection file (connected to a branch versioned workspace) when connected as the geodatabase admin user (sde).</para>
		/// </param>
		/// <param name="VersionName">
		/// <para>Version Name</para>
		/// <para>Specifies the name of the version to be deleted.</para>
		/// <para>For branch versioning, the name of the branch version to delete should be fully qualified. E.g. servicename.portaluser.versionname.</para>
		/// </param>
		public DeleteVersion(object InWorkspace, object VersionName)
		{
			this.InWorkspace = InWorkspace;
			this.VersionName = VersionName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Version</para>
		/// </summary>
		public override string DisplayName() => "Delete Version";

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
		/// <para>Specifies the database connection file to the enterprise, workgroup, or desktop geodatabase containing the version to be deleted.</para>
		/// <para>For branch versioning, you can use a feature service URL (that is, https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer) or a feature layer portal item. You can also delete a branch version via a database connection file (connected to a branch versioned workspace) when connected as the geodatabase admin user (sde).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>Specifies the name of the version to be deleted.</para>
		/// <para>For branch versioning, the name of the branch version to delete should be fully qualified. E.g. servicename.portaluser.versionname.</para>
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
		public DeleteVersion SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
