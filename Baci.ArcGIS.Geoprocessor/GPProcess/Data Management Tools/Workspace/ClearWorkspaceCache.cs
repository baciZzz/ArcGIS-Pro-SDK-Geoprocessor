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
	/// <para>Clear Workspace Cache</para>
	/// <para>Clears any enterprise geodatabase workspaces from the enterprise geodatabase workspace cache.</para>
	/// </summary>
	public class ClearWorkspaceCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public ClearWorkspaceCache()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : Clear Workspace Cache</para>
		/// </summary>
		public override string DisplayName => "Clear Workspace Cache";

		/// <summary>
		/// <para>Tool Name : ClearWorkspaceCache</para>
		/// </summary>
		public override string ToolName => "ClearWorkspaceCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ClearWorkspaceCache</para>
		/// </summary>
		public override string ExcuteName => "management.ClearWorkspaceCache";

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
		public override object[] Parameters => new object[] { InData, OutResults };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The enterprise geodatabase database connection file representing the enterprise geodatabase workspace to be removed from the cache. Specify the path to the enterprise geodatabase connection file that was used in running your geoprocessing tools in order to remove the specific enterprise geodatabase workspace from the cache. Passing no input parameter will clear all enterprise geodatabase workspaces from the cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Operation succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResults { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClearWorkspaceCache SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
