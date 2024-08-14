using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Export Job Data</para>
	/// <para>This tool will export the Workflow Manager (Classic) repository to a .jxl file in the specified folder location. The .jxl file will contain all the configuration information for the repository as well as information about all the jobs. The .jxl file can be imported into another Workflow Manager (Classic) repository using the Import Job Data  tool.</para>
	/// </summary>
	public class ExportJobData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFolder">
		/// <para>Folder To Export To</para>
		/// <para>The location of the JXL file output from the tool. This folder can be on a local or a network drive.</para>
		/// </param>
		public ExportJobData(object InputFolder)
		{
			this.InputFolder = InputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Job Data</para>
		/// </summary>
		public override string DisplayName => "Export Job Data";

		/// <summary>
		/// <para>Tool Name : ExportJobData</para>
		/// </summary>
		public override string ToolName => "ExportJobData";

		/// <summary>
		/// <para>Tool Excute Name : wmx.ExportJobData</para>
		/// </summary>
		public override string ExcuteName => "wmx.ExportJobData";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFolder, InputDatabasepath!, InputRepositoryName!, InputExportSince!, InputExportUntil!, OutputStatus! };

		/// <summary>
		/// <para>Folder To Export To</para>
		/// <para>The location of the JXL file output from the tool. This folder can be on a local or a network drive.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InputFolder { get; set; }

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>The Workflow Manager (Classic) connection file for the database to be exported. If no connection file is specified, the current default Workflow Manager (Classic) database in the project is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Repository Name</para>
		/// <para>The name of the Workflow Manager (Classic) repository that contains the configuration to be shared. If repository name is not specified, the current default Workflow Manager (Classic) repository name is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InputRepositoryName { get; set; }

		/// <summary>
		/// <para>Export Since</para>
		/// <para>By specifying a date, the JXL exported will only contain changes that occurred between the specified time and the current date. The input should be in UTC time format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? InputExportSince { get; set; }

		/// <summary>
		/// <para>Export Until</para>
		/// <para>By specifying a date, the JXL exported will only contain changes that occurred between Export Since and the specified time. The input should be in UTC time format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? InputExportUntil { get; set; }

		/// <summary>
		/// <para>Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

	}
}
