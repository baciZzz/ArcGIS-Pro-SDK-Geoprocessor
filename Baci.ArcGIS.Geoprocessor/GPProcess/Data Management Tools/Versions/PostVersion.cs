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
	/// <para>Post Version</para>
	/// <para>Post Version</para>
	/// <para>Posting is the process of applying the current edit session to the reconciled target version during version geodatabase editing. Before a version can be posted, it must be reconciled with a target version and all conflicts must be resolved.</para>
	/// </summary>
	[Obsolete()]
	public class PostVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The ArcSDE geodatabase containing the edit version to be posted.</para>
		/// </param>
		/// <param name="VersionName">
		/// <para>Version Name</para>
		/// <para>Name of the edit version to be posted to the target version.</para>
		/// </param>
		public PostVersion(object InWorkspace, object VersionName)
		{
			this.InWorkspace = InWorkspace;
			this.VersionName = VersionName;
		}

		/// <summary>
		/// <para>Tool Display Name : Post Version</para>
		/// </summary>
		public override string DisplayName() => "Post Version";

		/// <summary>
		/// <para>Tool Name : PostVersion</para>
		/// </summary>
		public override string ToolName() => "PostVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.PostVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.PostVersion";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, VersionName, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The ArcSDE geodatabase containing the edit version to be posted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Version Name</para>
		/// <para>Name of the edit version to be posted to the target version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object VersionName { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PostVersion SetEnviroment(object? configKeyword = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
