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
	/// <para>Export Geodatabase Configuration Keywords</para>
	/// <para>Exports the configuration keywords, parameters, and values from the specified enterprise geodatabase to an editable file. Change parameter values or add custom configuration keywords to the file and use the Import Geodatabase Configuration Keywords tool to import the changes to the geodatabase.</para>
	/// </summary>
	public class ExportGeodatabaseConfigurationKeywords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The connection file for the enterprise geodatabase from which you want to export configuration keywords, parameters, and values. You must connect as the geodatabase administrator.</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
		/// <para>The full path to and name of the ASCII text file to be created. The file will contain all the configuration keywords, parameters, and values from the enterprise geodatabase's DBTUNE (or SDE_DBTUNE) system table.</para>
		/// </param>
		public ExportGeodatabaseConfigurationKeywords(object InputDatabase, object OutFile)
		{
			this.InputDatabase = InputDatabase;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Geodatabase Configuration Keywords</para>
		/// </summary>
		public override string DisplayName => "Export Geodatabase Configuration Keywords";

		/// <summary>
		/// <para>Tool Name : ExportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ToolName => "ExportGeodatabaseConfigurationKeywords";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportGeodatabaseConfigurationKeywords</para>
		/// </summary>
		public override string ExcuteName => "management.ExportGeodatabaseConfigurationKeywords";

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
		public override object[] Parameters => new object[] { InputDatabase, OutFile, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The connection file for the enterprise geodatabase from which you want to export configuration keywords, parameters, and values. You must connect as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The full path to and name of the ASCII text file to be created. The file will contain all the configuration keywords, parameters, and values from the enterprise geodatabase's DBTUNE (or SDE_DBTUNE) system table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportGeodatabaseConfigurationKeywords SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
