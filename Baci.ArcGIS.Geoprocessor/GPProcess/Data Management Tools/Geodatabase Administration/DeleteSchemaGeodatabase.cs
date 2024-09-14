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
	/// <para>Delete Schema Geodatabase</para>
	/// <para>Delete Schema Geodatabase</para>
	/// <para>Deletes a geodatabase</para>
	/// <para>from a user's schema in Oracle.</para>
	/// </summary>
	public class DeleteSchemaGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database connection file (.sde) of the user-schema geodatabase to be deleted. You must connect as the schema owner.</para>
		/// </param>
		public DeleteSchemaGeodatabase(object InputDatabase)
		{
			this.InputDatabase = InputDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Schema Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Delete Schema Geodatabase";

		/// <summary>
		/// <para>Tool Name : DeleteSchemaGeodatabase</para>
		/// </summary>
		public override string ToolName() => "DeleteSchemaGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteSchemaGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteSchemaGeodatabase";

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
		public override object[] Parameters() => new object[] { InputDatabase, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The database connection file (.sde) of the user-schema geodatabase to be deleted. You must connect as the schema owner.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteSchemaGeodatabase SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
