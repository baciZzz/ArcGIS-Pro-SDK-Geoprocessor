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
	/// <para>Set Task Group Dependencies</para>
	/// <para>Set Task Group Dependencies</para>
	/// <para>Creates dependencies between a job and other existing Task Group jobs based on the criteria defined in the extended properties.</para>
	/// </summary>
	public class SetTaskGroupDependencies : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the Workflow Manager (Classic) job that will have dependencies set.</para>
		/// </param>
		public SetTaskGroupDependencies(object JobId)
		{
			this.JobId = JobId;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Task Group Dependencies</para>
		/// </summary>
		public override string DisplayName() => "Set Task Group Dependencies";

		/// <summary>
		/// <para>Tool Name : SetTaskGroupDependencies</para>
		/// </summary>
		public override string ToolName() => "SetTaskGroupDependencies";

		/// <summary>
		/// <para>Tool Excute Name : topographic.SetTaskGroupDependencies</para>
		/// </summary>
		public override string ExcuteName() => "topographic.SetTaskGroupDependencies";

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
		public override object[] Parameters() => new object[] { JobId, DatabasePath!, OutJobIds! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the Workflow Manager (Classic) job that will have dependencies set.</para>
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
