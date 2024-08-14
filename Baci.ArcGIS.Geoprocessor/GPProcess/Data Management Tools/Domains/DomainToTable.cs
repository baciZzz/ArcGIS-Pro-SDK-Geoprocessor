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
	/// <para>Creates a table from an attribute domain.</para>
	/// </summary>
	public class DomainToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The workspace containing the attribute domain to be converted to a table.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the existing attribute domain.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The table to be created.</para>
		/// </param>
		/// <param name="CodeField">
		/// <para>Code Field</para>
		/// <para>The name of the field in the created table that will store code values.</para>
		/// </param>
		/// <param name="DescriptionField">
		/// <para>Field Description</para>
		/// <para>The name of the field in the created table that will store code value descriptions.</para>
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
		/// <para>Tool Display Name : Domain To Table</para>
		/// </summary>
		public override string DisplayName => "Domain To Table";

		/// <summary>
		/// <para>Tool Name : DomainToTable</para>
		/// </summary>
		public override string ToolName => "DomainToTable";

		/// <summary>
		/// <para>Tool Excute Name : management.DomainToTable</para>
		/// </summary>
		public override string ExcuteName => "management.DomainToTable";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, DomainName, OutTable, CodeField, DescriptionField, ConfigurationKeyword! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The workspace containing the attribute domain to be converted to a table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the existing attribute domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Code Field</para>
		/// <para>The name of the field in the created table that will store code values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CodeField { get; set; }

		/// <summary>
		/// <para>Field Description</para>
		/// <para>The name of the field in the created table that will store code value descriptions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DescriptionField { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>For geodatabase tables, the custom storage keywords for creating the table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ConfigurationKeyword { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DomainToTable SetEnviroment(int? autoCommit = null , object? configKeyword = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
