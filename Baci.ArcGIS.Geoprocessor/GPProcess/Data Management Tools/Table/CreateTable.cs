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
	/// <para>Creates a geodatabase table or a dBASE table.</para>
	/// </summary>
	public class CreateTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Table Location</para>
		/// <para>The workspace in which the output table will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Table Name</para>
		/// <para>The name of the table to be created.</para>
		/// </param>
		public CreateTable(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Table</para>
		/// </summary>
		public override string DisplayName() => "Create Table";

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
		/// <para>The workspace in which the output table will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Table Name</para>
		/// <para>The name of the table to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Template Table Name</para>
		/// <para>A table with an attribute schema that is used to define the output table. Fields in the template tables will be added to the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The configuration keyword that determines the storage parameters of the table in an enterprise geodatabase.</para>
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
		/// <para>The alternate name of the output table that will be created.</para>
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
