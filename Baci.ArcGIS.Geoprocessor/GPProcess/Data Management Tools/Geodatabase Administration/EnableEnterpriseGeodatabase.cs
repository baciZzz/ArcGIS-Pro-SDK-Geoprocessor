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
	/// <para>Enable Enterprise Geodatabase</para>
	/// <para>Creates geodatabase system tables, stored procedures, functions, and types in an existing database, thereby enabling geodatabase functionality in the database.</para>
	/// </summary>
	public class EnableEnterpriseGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The path and connection file name for the database in which you want to enable geodatabase functionality. You must connect as a user that qualifies as a geodatabase administrator.</para>
		/// </param>
		/// <param name="AuthorizationFile">
		/// <para>Authorization File</para>
		/// <para>The path and file name of the keycodes file that was created when ArcGIS Server was authorized. This file is in the \\Program Files\ESRI\License&lt;release#&gt;\sysgen folder on Windows or the /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen directory on Linux. If you have not already done so, authorize ArcGIS Server to create this file.</para>
		/// <para>Copy the keycodes file from the ArcGIS Server machine to a location accessible to the tool.</para>
		/// </param>
		public EnableEnterpriseGeodatabase(object InputDatabase, object AuthorizationFile)
		{
			this.InputDatabase = InputDatabase;
			this.AuthorizationFile = AuthorizationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Enterprise Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Enable Enterprise Geodatabase";

		/// <summary>
		/// <para>Tool Name : EnableEnterpriseGeodatabase</para>
		/// </summary>
		public override string ToolName() => "EnableEnterpriseGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableEnterpriseGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableEnterpriseGeodatabase";

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
		public override object[] Parameters() => new object[] { InputDatabase, AuthorizationFile, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The path and connection file name for the database in which you want to enable geodatabase functionality. You must connect as a user that qualifies as a geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Authorization File</para>
		/// <para>The path and file name of the keycodes file that was created when ArcGIS Server was authorized. This file is in the \\Program Files\ESRI\License&lt;release#&gt;\sysgen folder on Windows or the /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen directory on Linux. If you have not already done so, authorize ArcGIS Server to create this file.</para>
		/// <para>Copy the keycodes file from the ArcGIS Server machine to a location accessible to the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object AuthorizationFile { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnableEnterpriseGeodatabase SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
