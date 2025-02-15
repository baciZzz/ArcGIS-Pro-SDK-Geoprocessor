using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Create Job For Task</para>
	/// <para>Create Job For Task</para>
	/// <para>Automatically creates a Workflow Manager (Classic) job for a task.</para>
	/// </summary>
	public class CreateJobForTask : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the Workflow Manager (Classic) job that will be the parent to the newly created child job. The Current Task extended property value for this job will be used to determine the type of task job that will be created.</para>
		/// </param>
		public CreateJobForTask(object JobId)
		{
			this.JobId = JobId;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Job For Task</para>
		/// </summary>
		public override string DisplayName() => "Create Job For Task";

		/// <summary>
		/// <para>Tool Name : CreateJobForTask</para>
		/// </summary>
		public override string ToolName() => "CreateJobForTask";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CreateJobForTask</para>
		/// </summary>
		public override string ExcuteName() => "topographic.CreateJobForTask";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { JobId, DatabasePath!, ChildJobId! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the Workflow Manager (Classic) job that will be the parent to the newly created child job. The Current Task extended property value for this job will be used to determine the type of task job that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? DatabasePath { get; set; }

		/// <summary>
		/// <para>Child Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? ChildJobId { get; set; } = "-1";

	}
}
