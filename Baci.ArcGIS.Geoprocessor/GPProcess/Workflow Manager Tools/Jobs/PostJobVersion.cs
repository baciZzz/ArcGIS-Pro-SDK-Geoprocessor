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
	/// <para>Post Job Version</para>
	/// <para>提交作业版本</para>
	/// <para>将当前版本中的编辑内容提交到作业的父版本。</para>
	/// </summary>
	public class PostJobVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>要将其作业版本的编辑内容提交到父版本的作业 ID。</para>
		/// </param>
		public PostJobVersion(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : 提交作业版本</para>
		/// </summary>
		public override string DisplayName() => "提交作业版本";

		/// <summary>
		/// <para>Tool Name : PostJobVersion</para>
		/// </summary>
		public override string ToolName() => "PostJobVersion";

		/// <summary>
		/// <para>Tool Excute Name : wmx.PostJobVersion</para>
		/// </summary>
		public override string ExcuteName() => "wmx.PostJobVersion";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath!, OutputStatus! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>要将其作业版本的编辑内容提交到父版本的作业 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>包含作业信息的 Workflow Manager (Classic) 数据库连接文件。如果未指定连接文件，将使用当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Post Job Version Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

	}
}
