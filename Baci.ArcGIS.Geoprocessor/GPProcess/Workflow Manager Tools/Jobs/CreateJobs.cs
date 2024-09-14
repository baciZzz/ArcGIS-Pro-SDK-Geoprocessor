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
	/// <para>创建作业</para>
	/// <para>创建一个或多个选定作业类型的作业并将作业分配给用户。可为创建的作业设置优先级，并通过要素图层或要素类为其定义感兴趣区域 (AOI)。</para>
	/// </summary>
	[Obsolete()]
	public class CreateJobs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabasepath">
		/// <para>Input Database Path (.jtc)</para>
		/// <para>包含作业类型信息的 Workflow Manager (Classic) 数据库连接文件。如果未指定连接文件，将使用当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </param>
		/// <param name="JobTypes">
		/// <para>Job Type</para>
		/// <para>用于创建新作业的作业类型。</para>
		/// </param>
		/// <param name="NumberOfJobs">
		/// <para>Number of Jobs To Create</para>
		/// <para>要创建的作业数。如果 AOI 范围具有值或如果选中合并要素创建一个 AOI，则将忽略此输入。</para>
		/// </param>
		public CreateJobs(object InputDatabasepath, object JobTypes, object NumberOfJobs)
		{
			this.InputDatabasepath = InputDatabasepath;
			this.JobTypes = JobTypes;
			this.NumberOfJobs = NumberOfJobs;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建作业</para>
		/// </summary>
		public override string DisplayName() => "创建作业";

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
		public object JobTypes { get; set; }

		/// <summary>
		/// <para>Number of Jobs To Create</para>
		/// <para>要创建的作业数。如果 AOI 范围具有值或如果选中合并要素创建一个 AOI，则将忽略此输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfJobs { get; set; }

		/// <summary>
		/// <para>Assigned User</para>
		/// <para>向其分配新作业的用户。如果未指定任何值，则使用作业类型中配置的默认值。</para>
		/// <para>将分配新作业的用户或群组。如果未指定任何值，则使用作业类型中配置的默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Users { get; set; }

		/// <summary>
		/// <para>Job Priority</para>
		/// <para>要创建的作业的优先级。如果未指定优先级，则使用作业类型中配置的默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object PriorityOfJobs { get; set; }

		/// <summary>
		/// <para>AOI Extent</para>
		/// <para>几何将用于创建新作业的 AOI 的面要素。只有选中合并要素创建一个 AOI，才会为图层中的每个要素创建一个作业。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object FeatureLayerAOI { get; set; }

		/// <summary>
		/// <para>Merge features to create one AOI</para>
		/// <para>指定是否将使用所有 AOI 面的并集创建一个作业。</para>
		/// <para>选中 - 将根据 AOI 面生成一个并集面，并且将创建一个作业，无论输入作业数为何。</para>
		/// <para>未选中 - 将使用每个 AOI 面生成一个作业。创建作业的总数等于要素图层中面的总数。这是默认设置。</para>
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
