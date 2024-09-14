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
	/// <para>Insert Task Group</para>
	/// <para>Insert Task Group</para>
	/// <para>Adds tasks from the chosen task group to a job when required by workflow execution.</para>
	/// </summary>
	public class InsertTaskGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The ID of the Workflow Manager (Classic) job that will be updated. This is the ID for the parent task group job, not the task job.</para>
		/// </param>
		/// <param name="TaskGroupId">
		/// <para>Task Group ID</para>
		/// <para>The ID of the task group that defines the tasks that will be inserted into the selected job’s task list.</para>
		/// </param>
		public InsertTaskGroup(object JobId, object TaskGroupId)
		{
			this.JobId = JobId;
			this.TaskGroupId = TaskGroupId;
		}

		/// <summary>
		/// <para>Tool Display Name : Insert Task Group</para>
		/// </summary>
		public override string DisplayName() => "Insert Task Group";

		/// <summary>
		/// <para>Tool Name : InsertTaskGroup</para>
		/// </summary>
		public override string ToolName() => "InsertTaskGroup";

		/// <summary>
		/// <para>Tool Excute Name : topographic.InsertTaskGroup</para>
		/// </summary>
		public override string ExcuteName() => "topographic.InsertTaskGroup";

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
		public override object[] Parameters() => new object[] { JobId, TaskGroupId, DatabasePath, UpdateJobId };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The ID of the Workflow Manager (Classic) job that will be updated. This is the ID for the parent task group job, not the task job.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Task Group ID</para>
		/// <para>The ID of the task group that defines the tasks that will be inserted into the selected job’s task list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object TaskGroupId { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object DatabasePath { get; set; }

		/// <summary>
		/// <para>Update Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object UpdateJobId { get; set; } = "-1";

	}
}
