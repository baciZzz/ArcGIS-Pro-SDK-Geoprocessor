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
	/// <para>Clear Workspace Cache</para>
	/// <para>清除工作空间缓存</para>
	/// <para>清除企业级地理数据库工作空间缓存中的全部企业级地理数据库工作空间。</para>
	/// </summary>
	public class ClearWorkspaceCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public ClearWorkspaceCache()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : 清除工作空间缓存</para>
		/// </summary>
		public override string DisplayName() => "清除工作空间缓存";

		/// <summary>
		/// <para>Tool Name : ClearWorkspaceCache</para>
		/// </summary>
		public override string ToolName() => "ClearWorkspaceCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ClearWorkspaceCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ClearWorkspaceCache";

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
		public override object[] Parameters() => new object[] { InData, OutResults };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>企业级地理数据库连接文件代表要从缓存中移除的企业级地理数据库工作空间。指定在运行地理处理工具时使用的企业级地理数据库连接路径，以从缓存中移除特定的企业级地理数据库工作空间。不给出任何输入数据将会清除该缓存中的所有企业级地理数据库工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Operation succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResults { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClearWorkspaceCache SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
