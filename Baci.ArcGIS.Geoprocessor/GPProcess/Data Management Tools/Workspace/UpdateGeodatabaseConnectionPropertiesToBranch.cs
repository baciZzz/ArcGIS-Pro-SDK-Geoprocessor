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
	/// <para>Update Geodatabase Connection Properties To Branch</para>
	/// <para>Updates an enterprise geodatabase connection to work with branch versioning.</para>
	/// </summary>
	public class UpdateGeodatabaseConnectionPropertiesToBranch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Geodatabase Connection</para>
		/// <para>The input enterprise geodatabase connection to update.</para>
		/// </param>
		public UpdateGeodatabaseConnectionPropertiesToBranch(object InputDatabase)
		{
			this.InputDatabase = InputDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Geodatabase Connection Properties To Branch</para>
		/// </summary>
		public override string DisplayName => "Update Geodatabase Connection Properties To Branch";

		/// <summary>
		/// <para>Tool Name : UpdateGeodatabaseConnectionPropertiesToBranch</para>
		/// </summary>
		public override string ToolName => "UpdateGeodatabaseConnectionPropertiesToBranch";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateGeodatabaseConnectionPropertiesToBranch</para>
		/// </summary>
		public override string ExcuteName => "management.UpdateGeodatabaseConnectionPropertiesToBranch";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputDatabase, OutWorkspace! };

		/// <summary>
		/// <para>Input Geodatabase Connection</para>
		/// <para>The input enterprise geodatabase connection to update.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase Connection Properties To Branch</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

	}
}
