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
	/// <para>Compress</para>
	/// <para>压缩</para>
	/// <para>通过移除版本未引用的状态和冗余行来压缩企业级地理数据库。</para>
	/// </summary>
	public class Compress : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Database Connection</para>
		/// <para>连接到要压缩的企业级地理数据库的数据库连接文件。以地理数据库管理员身份进行连接。</para>
		/// </param>
		public Compress(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 压缩</para>
		/// </summary>
		public override string DisplayName() => "压缩";

		/// <summary>
		/// <para>Tool Name : 压缩</para>
		/// </summary>
		public override string ToolName() => "压缩";

		/// <summary>
		/// <para>Tool Excute Name : management.Compress</para>
		/// </summary>
		public override string ExcuteName() => "management.Compress";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>连接到要压缩的企业级地理数据库的数据库连接文件。以地理数据库管理员身份进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Compressed Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Compress SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
