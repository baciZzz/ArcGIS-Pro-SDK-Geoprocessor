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
	/// <para>Create New Jobs</para>
	/// <para>Creates one or more jobs of the selected job type and assigns the jobs to a user or user group. The created jobs can be prioritized and assigned a polygon or point location of interest (LOI).</para>
	/// </summary>
	public class CreateNewJobs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabasepath">
		/// <para>Input Database Path (.jtc)</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job type information. If no connection file is specified, the current default Workflow Manager (Classic) database is used.</para>
		/// </param>
		/// <param name="JobType">
		/// <para>Job Type</para>
		/// <para>The job type to be used for creating the new job.</para>
		/// </param>
		/// <param name="NumberOfJobs">
		/// <para>Number of Jobs</para>
		/// <para>The number of jobs to be created. This input is ignored if LOI Extent has a value or if Merge features to create one LOI is checked.</para>
		/// </param>
		public CreateNewJobs(object InputDatabasepath, object JobType, object NumberOfJobs)
		{
			this.InputDatabasepath = InputDatabasepath;
			this.JobType = JobType;
			this.NumberOfJobs = NumberOfJobs;
		}

		/// <summary>
		/// <para>Tool Display Name : Create New Jobs</para>
		/// </summary>
		public override string DisplayName => "Create New Jobs";

		/// <summary>
		/// <para>Tool Name : CreateNewJobs</para>
		/// </summary>
		public override string ToolName => "CreateNewJobs";

		/// <summary>
		/// <para>Tool Excute Name : wmx.CreateNewJobs</para>
		/// </summary>
		public override string ExcuteName => "wmx.CreateNewJobs";

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
		public override object[] Parameters => new object[] { InputDatabasepath, JobType, NumberOfJobs, AssignmentType, AssignTo, Priority, FeatureLayerLOI, Union, JobID };

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job type information. If no connection file is specified, the current default Workflow Manager (Classic) database is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Job Type</para>
		/// <para>The job type to be used for creating the new job.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object JobType { get; set; }

		/// <summary>
		/// <para>Number of Jobs</para>
		/// <para>The number of jobs to be created. This input is ignored if LOI Extent has a value or if Merge features to create one LOI is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfJobs { get; set; }

		/// <summary>
		/// <para>Assignment Type</para>
		/// <para>Specifies the assignment type to use to assign new jobs. If no value is specified, the default value configured in the job type is used.</para>
		/// <para>Groups—The new jobs will be assigned to a group.</para>
		/// <para>Users— The new jobs will be assigned to a user.</para>
		/// <para>Unassigned—The new jobs will be unassigned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object AssignmentType { get; set; }

		/// <summary>
		/// <para>Assigned To</para>
		/// <para>The user or group to whom the new jobs will be assigned. The value is restricted to a user or group based on the selected assignment type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object AssignTo { get; set; }

		/// <summary>
		/// <para>Priority</para>
		/// <para>The priority of the jobs that will be created. If no priority is specified, the default value configured in the job type is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Priority { get; set; }

		/// <summary>
		/// <para>LOI Extent</para>
		/// <para>The polygon, point, or multipoint features whose geometry will be used to create the LOI of the new jobs. One job will be created for each feature in the layer unless Merge features to create one LOI is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object FeatureLayerLOI { get; set; }

		/// <summary>
		/// <para>Merge features to create one LOI</para>
		/// <para>Specifies whether one job will be created with the union of all polygons, point, or multipoint in the input feature layer as the LOI of the job.</para>
		/// <para>Checked—One union polygon or multipont feature will be generated from the LOI features and one job will be created regardless of the input number of jobs.</para>
		/// <para>Unchecked—Each feature in the input layer will be used to generate the LOI of one job. The total number of jobs created is equal to the total number of input features. This is the default.</para>
		/// <para><see cref="UnionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Union { get; set; }

		/// <summary>
		/// <para>Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object JobID { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Merge features to create one LOI</para>
		/// </summary>
		public enum UnionEnum 
		{
			/// <summary>
			/// <para>Checked—One union polygon or multipont feature will be generated from the LOI features and one job will be created regardless of the input number of jobs.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UNION")]
			UNION,

			/// <summary>
			/// <para>Unchecked—Each feature in the input layer will be used to generate the LOI of one job. The total number of jobs created is equal to the total number of input features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UNION")]
			NO_UNION,

		}

#endregion
	}
}
