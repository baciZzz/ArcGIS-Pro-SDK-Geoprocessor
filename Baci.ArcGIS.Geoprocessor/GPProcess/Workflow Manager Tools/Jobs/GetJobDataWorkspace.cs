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
	/// <para>Get Job Data Workspace</para>
	/// <para>Gets the job data workspace as an enterprise geodatabase connection file. This tool is typically used in ModelBuilder to retrieve the connection file for use as an input to other tools such as Reconcile Versions in the model.</para>
	/// </summary>
	public class GetJobDataWorkspace : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>The ID for the job whose data workspace connection is to be retrieved.</para>
		/// </param>
		public GetJobDataWorkspace(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Job Data Workspace</para>
		/// </summary>
		public override string DisplayName => "Get Job Data Workspace";

		/// <summary>
		/// <para>Tool Name : GetJobDataWorkspace</para>
		/// </summary>
		public override string ToolName => "GetJobDataWorkspace";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobDataWorkspace</para>
		/// </summary>
		public override string ExcuteName => "wmx.GetJobDataWorkspace";

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
		public override object[] Parameters => new object[] { InputJobid, InputDatabasepath!, InputSdefilelocation!, OutputJobdataworkspace! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>The ID for the job whose data workspace connection is to be retrieved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database in the project is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Save a copy of the Job Data Workspace in</para>
		/// <para>The job's data workspace connection file will be written to the specified folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? InputSdefilelocation { get; set; }

		/// <summary>
		/// <para>Output Job Data Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object? OutputJobdataworkspace { get; set; }

	}
}
