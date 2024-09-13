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
	/// <para>创建新作业</para>
	/// <para>创建一个或多个选定作业类型的作业并将作业分配给用户或用户群组。可为创建的作业设置优先级，并为其分配面或点感兴趣位置 (LOI)。</para>
	/// </summary>
	public class CreateNewJobs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabasepath">
		/// <para>Input Database Path (.jtc)</para>
		/// <para>包含作业类型信息的 Workflow Manager (Classic) 数据库连接文件。如果未指定连接文件，将使用当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </param>
		/// <param name="JobType">
		/// <para>Job Type</para>
		/// <para>用于创建新作业的作业类型。</para>
		/// </param>
		/// <param name="NumberOfJobs">
		/// <para>Number of Jobs</para>
		/// <para>要创建的作业数。如果 LOI 范围具有值或如果选中合并要素创建一个 LOI，则将忽略此输入。</para>
		/// </param>
		public CreateNewJobs(object InputDatabasepath, object JobType, object NumberOfJobs)
		{
			this.InputDatabasepath = InputDatabasepath;
			this.JobType = JobType;
			this.NumberOfJobs = NumberOfJobs;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建新作业</para>
		/// </summary>
		public override string DisplayName() => "创建新作业";

		/// <summary>
		/// <para>Tool Name : CreateNewJobs</para>
		/// </summary>
		public override string ToolName() => "CreateNewJobs";

		/// <summary>
		/// <para>Tool Excute Name : wmx.CreateNewJobs</para>
		/// </summary>
		public override string ExcuteName() => "wmx.CreateNewJobs";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabasepath, JobType, NumberOfJobs, AssignmentType, AssignTo, Priority, FeatureLayerLOI, Union, JobID };

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>包含作业类型信息的 Workflow Manager (Classic) 数据库连接文件。如果未指定连接文件，将使用当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Job Type</para>
		/// <para>用于创建新作业的作业类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object JobType { get; set; }

		/// <summary>
		/// <para>Number of Jobs</para>
		/// <para>要创建的作业数。如果 LOI 范围具有值或如果选中合并要素创建一个 LOI，则将忽略此输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfJobs { get; set; }

		/// <summary>
		/// <para>Assignment Type</para>
		/// <para>指定用于分配新作业的分配类型。如果未指定任何值，则使用作业类型中配置的默认值。</para>
		/// <para>组织—新作业将分配至群组。</para>
		/// <para>用户— 新作业将分配给用户。</para>
		/// <para>未分配—新作业将不进行分配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object AssignmentType { get; set; }

		/// <summary>
		/// <para>Assigned To</para>
		/// <para>向其分配新作业的用户或群组。该值仅限基于所选分配类型的用户或群组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object AssignTo { get; set; }

		/// <summary>
		/// <para>Priority</para>
		/// <para>要创建的作业的优先级。如果未指定优先级，则使用作业类型中配置的默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Priority { get; set; }

		/// <summary>
		/// <para>LOI Extent</para>
		/// <para>几何将用于创建新作业的 LOI 的面、点或多点要素。选中合并要素创建一个 LOI 后，则会为图层中的每个要素创建一个作业。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Multipoint", "Point")]
		public object FeatureLayerLOI { get; set; }

		/// <summary>
		/// <para>Merge features to create one LOI</para>
		/// <para>指定是否将输入要素图层中所有面、点或多点的并集作为作业的 LOI 创建一个作业。</para>
		/// <para>选中 - 将通过 LOI 要素生成一个并集面或多点要素，并且将创建一个作业，无论输入作业数为何。</para>
		/// <para>未选中 - 将使用输入图层中的每个要素生成一个作业的 LOI。创建作业的总数等于输入要素的总数。这是默认设置。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UNION")]
			UNION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UNION")]
			NO_UNION,

		}

#endregion
	}
}
