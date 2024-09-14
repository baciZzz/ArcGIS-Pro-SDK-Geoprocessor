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
	/// <para>Import Geodatabase Configuration Keywords</para>
	/// <para>Import Geodatabase Configuration Keywords</para>
	/// <para>Defines data storage parameters for an enterprise geodatabase by importing a file containing configuration keywords, parameters, and values.</para>
	/// </summary>
	public class ImportGeodatabaseConfigurationKeywords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The connection file for the enterprise geodatabase to which you want to import the configuration file. You must connect as the geodatabase administrator.</para>
		/// </param>
		/// <param name="InFile">
		/// <para>Input File</para>
		/// <para>The path to and name of the ASCII text file containing configuration keywords, parameters, and values to import.</para>
		/// </param>
		public ImportGeodatabaseConfigurationKeywords(object InputDatabase, object InFile)
		{
			this.InputDatabase = InputDatabase;
			this.InFile = InFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Geodatabase Configuration Keywords</para>
		/// </summary>
		public override string DisplayName() => "Import Geodatabase Configuration Keywords";

		/// <summary>
		/// <para>Tool Name : ImportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ToolName() => "ImportGeodatabaseConfigurationKeywords";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportGeodatabaseConfigurationKeywords";

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
		public override object[] Parameters() => new object[] { InputDatabase, InFile, OutWorkspace };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The connection file for the enterprise geodatabase to which you want to import the configuration file. You must connect as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Input File</para>
		/// <para>The path to and name of the ASCII text file containing configuration keywords, parameters, and values to import.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InFile { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportGeodatabaseConfigurationKeywords SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
