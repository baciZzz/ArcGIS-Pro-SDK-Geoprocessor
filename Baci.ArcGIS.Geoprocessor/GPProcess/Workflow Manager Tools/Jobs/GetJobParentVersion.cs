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
	/// <para>Get Job Parent Version</para>
	/// <para>获取作业父版本</para>
	/// <para>获取作业父版本作为企业级地理数据库连接文件，用于在地理处理模型中将编辑内容提交到正确的父版本。</para>
	/// </summary>
	public class GetJobParentVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>要检索的作业父版本的 ID。</para>
		/// </param>
		public GetJobParentVersion(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取作业父版本</para>
		/// </summary>
		public override string DisplayName() => "获取作业父版本";

		/// <summary>
		/// <para>Tool Name : GetJobParentVersion</para>
		/// </summary>
		public override string ToolName() => "GetJobParentVersion";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobParentVersion</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobParentVersion";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath, OutputJobparentversion };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>要检索的作业父版本的 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>包含作业信息的 Workflow Manager (Classic) 数据库连接文件。如果未指定连接文件，将使用项目中当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Job Parent Version</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputJobparentversion { get; set; }

	}
}
