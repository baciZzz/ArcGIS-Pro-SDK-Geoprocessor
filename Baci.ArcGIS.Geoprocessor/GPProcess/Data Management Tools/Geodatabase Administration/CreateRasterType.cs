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
	/// <para>Create Raster Type</para>
	/// <para>Create Raster Type</para>
	/// <para>Create Raster Type</para>
	/// </summary>
	[Obsolete()]
	public class CreateRasterType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>Specify the database connection (.sde) file for the geodatabase in which you want to install the ST_Raster data type. You must connect as the geodatabase administrator.</para>
		/// </param>
		public CreateRasterType(object InputDatabase)
		{
			this.InputDatabase = InputDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Raster Type</para>
		/// </summary>
		public override string DisplayName() => "Create Raster Type";

		/// <summary>
		/// <para>Tool Name : CreateRasterType</para>
		/// </summary>
		public override string ToolName() => "CreateRasterType";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRasterType</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRasterType";

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
		/// <para>Specify the database connection (.sde) file for the geodatabase in which you want to install the ST_Raster data type. You must connect as the geodatabase administrator.</para>
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
		public CreateRasterType SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
