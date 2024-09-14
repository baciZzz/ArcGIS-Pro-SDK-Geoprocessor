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
	/// <para>Domain To Table</para>
	/// <para>属性域转表</para>
	/// <para>根据属性域创建表。</para>
	/// </summary>
	public class DomainToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>包含要转换为表的属性域的工作空间。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>现有属性域的名称。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>要创建的表。</para>
		/// </param>
		/// <param name="CodeField">
		/// <para>Code Field</para>
		/// <para>已创建表中用于储存编码值的字段的名称。</para>
		/// </param>
		/// <param name="DescriptionField">
		/// <para>Field Description</para>
		/// <para>已创建表中用于储存编码值描述的字段的名称。</para>
		/// </param>
		public DomainToTable(object InWorkspace, object DomainName, object OutTable, object CodeField, object DescriptionField)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
			this.OutTable = OutTable;
			this.CodeField = CodeField;
			this.DescriptionField = DescriptionField;
		}

		/// <summary>
		/// <para>Tool Display Name : 属性域转表</para>
		/// </summary>
		public override string DisplayName() => "属性域转表";

		/// <summary>
		/// <para>Tool Name : DomainToTable</para>
		/// </summary>
		public override string ToolName() => "DomainToTable";

		/// <summary>
		/// <para>Tool Excute Name : management.DomainToTable</para>
		/// </summary>
		public override string ExcuteName() => "management.DomainToTable";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, OutTable, CodeField, DescriptionField, ConfigurationKeyword! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含要转换为表的属性域的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>现有属性域的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>要创建的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Code Field</para>
		/// <para>已创建表中用于储存编码值的字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CodeField { get; set; }

		/// <summary>
		/// <para>Field Description</para>
		/// <para>已创建表中用于储存编码值描述的字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DescriptionField { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>用于创建地理数据库表的自定义存储关键字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ConfigurationKeyword { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DomainToTable SetEnviroment(int? autoCommit = null, object? configKeyword = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
