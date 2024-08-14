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
	/// <para>Set Task Status</para>
	/// <para>Updates the status of a task based on the state of the Workflow Manager (Classic) job created for the task.</para>
	/// </summary>
	public class SetTaskStatus : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the task job that has a change in status.</para>
		/// </param>
		/// <param name="ParentId">
		/// <para>Parent Job ID</para>
		/// <para>The job ID of the task group job that is the parent to the task job.</para>
		/// </param>
		/// <param name="Status">
		/// <para>Status</para>
		/// <para>Specifies the status of the selected task.</para>
		/// <para>Working—Work has begun for the task.</para>
		/// <para>Complete—Work has been completed for the task.</para>
		/// <para><see cref="StatusEnum"/></para>
		/// </param>
		public SetTaskStatus(object JobId, object ParentId, object Status)
		{
			this.JobId = JobId;
			this.ParentId = ParentId;
			this.Status = Status;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Task Status</para>
		/// </summary>
		public override string DisplayName => "Set Task Status";

		/// <summary>
		/// <para>Tool Name : SetTaskStatus</para>
		/// </summary>
		public override string ToolName => "SetTaskStatus";

		/// <summary>
		/// <para>Tool Excute Name : topographic.SetTaskStatus</para>
		/// </summary>
		public override string ExcuteName => "topographic.SetTaskStatus";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { JobId, ParentId, Status, DatabasePath!, UpdatedJobId! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the task job that has a change in status.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Parent Job ID</para>
		/// <para>The job ID of the task group job that is the parent to the task job.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object ParentId { get; set; }

		/// <summary>
		/// <para>Status</para>
		/// <para>Specifies the status of the selected task.</para>
		/// <para>Working—Work has begun for the task.</para>
		/// <para>Complete—Work has been completed for the task.</para>
		/// <para><see cref="StatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Status { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? UpdatedJobId { get; set; } = "-1";

		#region InnerClass

		/// <summary>
		/// <para>Status</para>
		/// </summary>
		public enum StatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WORKING")]
			[Description("WORKING")]
			WORKING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("COMPLETE")]
			[Description("COMPLETE")]
			COMPLETE,

		}

#endregion
	}
}
