using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Compact</para>
	/// <para>数据库碎片整理</para>
	/// <para>文件地理数据库进行碎片整理。数据库碎片整理操作会重新调整地理数据库在磁盘中的存储方式，因而通常会减小地理数据库的大小并提高性能。</para>
	/// </summary>
	public class Compact : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>要进行碎片整理的文件地理数据库。</para>
		/// </param>
		public Compact(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 数据库碎片整理</para>
		/// </summary>
		public override string DisplayName() => "数据库碎片整理";

		/// <summary>
		/// <para>Tool Name : 数据库碎片整理</para>
		/// </summary>
		public override string ToolName() => "数据库碎片整理";

		/// <summary>
		/// <para>Tool Excute Name : management.Compact</para>
		/// </summary>
		public override string ExcuteName() => "management.Compact";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>要进行碎片整理的文件地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Compact SetEnviroment(object? configKeyword = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
