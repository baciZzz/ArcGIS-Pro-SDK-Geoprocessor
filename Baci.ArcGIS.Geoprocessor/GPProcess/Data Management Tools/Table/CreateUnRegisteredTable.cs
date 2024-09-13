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
	/// <para>Create Unregistered Table</para>
	/// <para>创建未注册表</para>
	/// <para>在数据库或企业级地理数据库中创建空表。此表未注册到地理数据库。</para>
	/// </summary>
	public class CreateUnRegisteredTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Table Location</para>
		/// <para>将创建输出表的企业级地理数据库或数据库。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Table Name</para>
		/// <para>要创建的表的名称。</para>
		/// </param>
		public CreateUnRegisteredTable(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建未注册表</para>
		/// </summary>
		public override string DisplayName() => "创建未注册表";

		/// <summary>
		/// <para>Tool Name : CreateUnRegisteredTable</para>
		/// </summary>
		public override string ToolName() => "CreateUnRegisteredTable";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateUnRegisteredTable</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateUnRegisteredTable";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, Template, ConfigKeyword, OutTable };

		/// <summary>
		/// <para>Table Location</para>
		/// <para>将创建输出表的企业级地理数据库或数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Table Name</para>
		/// <para>要创建的表的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Template Table Name</para>
		/// <para>现有表或者具有用于定义输出表中字段的字段和属性方案的表列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>指定关系数据库管理系统 (RDBMS) 中的地理数据库的默认存储参数（配置）。此设置仅在使用企业级地理数据库表时可用。</para>
		/// <para>配置关键字由数据库管理员进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateUnRegisteredTable SetEnviroment(object configKeyword = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
