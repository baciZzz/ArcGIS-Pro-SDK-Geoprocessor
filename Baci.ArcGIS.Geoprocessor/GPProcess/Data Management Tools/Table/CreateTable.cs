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
	/// <para>Create Table</para>
	/// <para>创建表</para>
	/// <para>创建地理数据库表或 dBASE 表。</para>
	/// </summary>
	public class CreateTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Table Location</para>
		/// <para>用于创建输出表的工作空间。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Table Name</para>
		/// <para>要创建的表的名称。</para>
		/// </param>
		public CreateTable(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建表</para>
		/// </summary>
		public override string DisplayName() => "创建表";

		/// <summary>
		/// <para>Tool Name : CreateTable</para>
		/// </summary>
		public override string ToolName() => "CreateTable";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateTable</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateTable";

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
		public override object[] Parameters() => new object[] { OutPath, OutName, Template, ConfigKeyword, OutTable, OutAlias };

		/// <summary>
		/// <para>Table Location</para>
		/// <para>用于创建输出表的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
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
		/// <para>属性方案用于定义输出表的表。模板表中的字段将被添加到输出表中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>用于确定企业级地理数据库中表的存储参数的配置关键字。</para>
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
		/// <para>Table Alias Name</para>
		/// <para>将创建的输出表的备用名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutAlias { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTable SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
