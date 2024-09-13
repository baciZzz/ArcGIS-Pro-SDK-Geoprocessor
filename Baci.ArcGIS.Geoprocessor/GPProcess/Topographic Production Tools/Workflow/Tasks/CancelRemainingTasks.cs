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
	/// <para>Cancel Remaining Tasks</para>
	/// <para>Cancel Remaining Tasks</para>
	/// <para>Prevents the remaining tasks in a job from starting or being created. The active task and its  task group job will still complete.</para>
	/// </summary>
	public class CancelRemainingTasks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the parent ArcGIS Workflow Manager (Classic) task group job that contains the task list derived from the Set Task List tool.</para>
		/// </param>
		public CancelRemainingTasks(object JobId)
		{
			this.JobId = JobId;
		}

		/// <summary>
		/// <para>Tool Display Name : Cancel Remaining Tasks</para>
		/// </summary>
		public override string DisplayName() => "Cancel Remaining Tasks";

		/// <summary>
		/// <para>Tool Name : CancelRemainingTasks</para>
		/// </summary>
		public override string ToolName() => "CancelRemainingTasks";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CancelRemainingTasks</para>
		/// </summary>
		public override string ExcuteName() => "topographic.CancelRemainingTasks";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { JobId, DatabasePath!, UpdatedJobId! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the parent ArcGIS Workflow Manager (Classic) task group job that contains the task list derived from the Set Task List tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The ArcGIS Workflow Manager (Classic) database connection file that contains the job information. If a connection is not specified, the current default ArcGIS Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? UpdatedJobId { get; set; } = "-1";

	}
}
