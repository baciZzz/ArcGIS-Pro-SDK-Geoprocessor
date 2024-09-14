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
	/// <para>Get Job Version</para>
	/// <para>获取作业版本</para>
	/// <para>获取作业版本作为企业级地理数据库连接文件，以在某一版本中处理数据。</para>
	/// </summary>
	public class GetJobVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>要检索版本的作业的 ID。</para>
		/// </param>
		public GetJobVersion(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取作业版本</para>
		/// </summary>
		public override string DisplayName() => "获取作业版本";

		/// <summary>
		/// <para>Tool Name : GetJobVersion</para>
		/// </summary>
		public override string ToolName() => "GetJobVersion";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobVersion</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobVersion";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath, OutputJobversion, OutputJobversionexists };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>要检索版本的作业的 ID。</para>
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
		/// <para>Job Version</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputJobversion { get; set; }

		/// <summary>
		/// <para>Job Version Exists</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutputJobversionexists { get; set; }

	}
}
