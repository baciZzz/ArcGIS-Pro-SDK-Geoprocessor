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
	/// <para>Create Jobs</para>
	/// <para>Create Jobs</para>
	/// <para>Creates one or more jobs of the selected job type and assigns the jobs to a user.  The created jobs can be prioritized and have an area of interest (AOI) defined from a feature layer or feature class.</para>
	/// </summary>
	[Obsolete()]
	public class CreateJobs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabasepath">
		/// <para>Input Database Path (.jtc)</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job type information. If no connection file is specified, the current default Workflow Manager (Classic) database is used.</para>
		/// </param>
		/// <param name="JobTypes">
		/// <para>Job Type</para>
		/// <para>The job type to be used for creating the new job.</para>
		/// </param>
		/// <param name="NumberOfJobs">
		/// <para>Number of Jobs To Create</para>
		/// <para>The number of jobs to be created. This input is ignored if AOI Extent has a value or if Merge features to create one AOI is checked.</para>
		/// </param>
		public CreateJobs(object InputDatabasepath, object JobTypes, object NumberOfJobs)
		{
			this.InputDatabasepath = InputDatabasepath;
			this.JobTypes = JobTypes;
			this.NumberOfJobs = NumberOfJobs;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Jobs</para>
		/// </summary>
		public override string DisplayName() => "Create Jobs";

		/// <summary>
		/// <para>Tool Name : CreateJobs</para>
		/// </summary>
		public override string ToolName() => "CreateJobs";

		/// <summary>
		/// <para>Tool Excute Name : wmx.CreateJobs</para>
		/// </summary>
		public override string ExcuteName() => "wmx.CreateJobs";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise() => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabasepath, JobTypes, NumberOfJobs, Users, PriorityOfJobs, FeatureLayerAOI, UnionOption, JobID };

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job type information. If no connection file is specified, the current default Workflow Manager (Classic) database is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Job Type</para>
		/// <para>The job type to be used for creating the new job.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object JobTypes { get; set; }

		/// <summary>
		/// <para>Number of Jobs To Create</para>
		/// <para>The number of jobs to be created. This input is ignored if AOI Extent has a value or if Merge features to create one AOI is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfJobs { get; set; }

		/// <summary>
		/// <para>Assigned User</para>
		/// <para>The user to whom the new jobs will be assigned. If no value is specified, the default value configured in the job type is used.</para>
		/// <para>The user or group the new jobs will be assigned to. If no value is specified, the default value configured in the job type is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Users { get; set; }

		/// <summary>
		/// <para>Job Priority</para>
		/// <para>The priority of the jobs that will be created. If no priority is specified, the default value configured in the job type is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object PriorityOfJobs { get; set; }

		/// <summary>
		/// <para>AOI Extent</para>
		/// <para>The polygon features whose geometry will be used to create the AOI of the new jobs. One job will be created for each feature in the layer unless Merge features to create one AOI is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object FeatureLayerAOI { get; set; }

		/// <summary>
		/// <para>Merge features to create one AOI</para>
		/// <para>Specifies whether one job will be created with the union of all AOI polygons.</para>
		/// <para>Checked—One union polygon will be generated from the AOI polygons and one job will be created regardless of the input number of jobs.</para>
		/// <para>Unchecked—Each AOI polygon will be used to generate one job. The total number of jobs created is equal to the total number of polygons in the feature layer. This is the default.</para>
		/// <para><see cref="UnionOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UnionOption { get; set; }

		/// <summary>
		/// <para>Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object JobID { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Merge features to create one AOI</para>
		/// </summary>
		public enum UnionOptionEnum 
		{
			/// <summary>
			/// <para>Checked—One union polygon will be generated from the AOI polygons and one job will be created regardless of the input number of jobs.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UNION")]
			UNION,

			/// <summary>
			/// <para>Unchecked—Each AOI polygon will be used to generate one job. The total number of jobs created is equal to the total number of polygons in the feature layer. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UNION")]
			NO_UNION,

		}

#endregion
	}
}
