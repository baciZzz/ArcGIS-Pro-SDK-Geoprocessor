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
	/// <para>Update Enterprise Geodatabase License</para>
	/// <para>Updates the ArcGIS Server license in an enterprise geodatabase.</para>
	/// </summary>
	public class UpdateEnterpriseGeodatabaseLicense : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>Provide a database connection (.sde file) to the enterprise geodatabase you want to authorize with a new ArcGIS Server enterprise authorization file.</para>
		/// <para>You must connect to the database as the geodatabase administrator.</para>
		/// </param>
		/// <param name="AuthorizationFile">
		/// <para>Authorization File</para>
		/// <para>Provide the path and file name of the keycodes file generated when you authorized ArcGIS Server enterprise. If necessary, copy the file from the ArcGIS Server machine to a directory that the tool can access.</para>
		/// <para>ArcGIS Server creates the keycodes file in the following location: \\Program Files\ESRI\License&lt;release#&gt;\sysgen (Microsoft Windows servers) or /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen (Linux servers).</para>
		/// </param>
		public UpdateEnterpriseGeodatabaseLicense(object InputDatabase, object AuthorizationFile)
		{
			this.InputDatabase = InputDatabase;
			this.AuthorizationFile = AuthorizationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Enterprise Geodatabase License</para>
		/// </summary>
		public override string DisplayName => "Update Enterprise Geodatabase License";

		/// <summary>
		/// <para>Tool Name : UpdateEnterpriseGeodatabaseLicense</para>
		/// </summary>
		public override string ToolName => "UpdateEnterpriseGeodatabaseLicense";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateEnterpriseGeodatabaseLicense</para>
		/// </summary>
		public override string ExcuteName => "management.UpdateEnterpriseGeodatabaseLicense";

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
		public override object[] Parameters => new object[] { InputDatabase, AuthorizationFile, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>Provide a database connection (.sde file) to the enterprise geodatabase you want to authorize with a new ArcGIS Server enterprise authorization file.</para>
		/// <para>You must connect to the database as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Authorization File</para>
		/// <para>Provide the path and file name of the keycodes file generated when you authorized ArcGIS Server enterprise. If necessary, copy the file from the ArcGIS Server machine to a directory that the tool can access.</para>
		/// <para>ArcGIS Server creates the keycodes file in the following location: \\Program Files\ESRI\License&lt;release#&gt;\sysgen (Microsoft Windows servers) or /arcgis/server/framework/runtime/.wine/drive_c/Program Files/ESRI/License&lt;release#&gt;/sysgen (Linux servers).</para>
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
		public UpdateEnterpriseGeodatabaseLicense SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
