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
	/// <para>Create Task Group Jobs</para>
	/// <para>Create Task Group Jobs</para>
	/// <para>Creates new Task Group jobs based on the properties of an existing job.</para>
	/// </summary>
	public class CreateTaskGroupJobs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the ArcGIS Workflow Manager (Classic) job that will have dependencies set.</para>
		/// </param>
		public CreateTaskGroupJobs(object JobId)
		{
			this.JobId = JobId;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Task Group Jobs</para>
		/// </summary>
		public override string DisplayName() => "Create Task Group Jobs";

		/// <summary>
		/// <para>Tool Name : CreateTaskGroupJobs</para>
		/// </summary>
		public override string ToolName() => "CreateTaskGroupJobs";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CreateTaskGroupJobs</para>
		/// </summary>
		public override string ExcuteName() => "topographic.CreateTaskGroupJobs";

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
		public override object[] Parameters() => new object[] { JobId, DatabasePath!, OutJobIds! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the ArcGIS Workflow Manager (Classic) job that will have dependencies set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? DatabasePath { get; set; }

		/// <summary>
		/// <para>Output Job IDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutJobIds { get; set; } = "-1";

	}
}
