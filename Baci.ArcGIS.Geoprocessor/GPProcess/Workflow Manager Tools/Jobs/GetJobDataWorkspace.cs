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
	/// <para>Get Job Data Workspace</para>
	/// <para>获取作业数据的工作空间</para>
	/// <para>获取作业数据工作空间作为企业级地理数据库连接文件。该工具通常在 ModelBuilder 中用于检索连接文件，以便用作模型中其他工具（例如协调版本）的输入。</para>
	/// </summary>
	public class GetJobDataWorkspace : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>要检索数据工作空间连接的作业的 ID。</para>
		/// </param>
		public GetJobDataWorkspace(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取作业数据的工作空间</para>
		/// </summary>
		public override string DisplayName() => "获取作业数据的工作空间";

		/// <summary>
		/// <para>Tool Name : GetJobDataWorkspace</para>
		/// </summary>
		public override string ToolName() => "GetJobDataWorkspace";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobDataWorkspace</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobDataWorkspace";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath!, InputSdefilelocation!, OutputJobdataworkspace! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>要检索数据工作空间连接的作业的 ID。</para>
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
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Save a copy of the Job Data Workspace in</para>
		/// <para>作业的数据工作空间连接文件将写入到指定文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? InputSdefilelocation { get; set; }

		/// <summary>
		/// <para>Output Job Data Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object? OutputJobdataworkspace { get; set; }

	}
}
