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
	/// <para>Creates an empty table in a database or enterprise geodatabase. The table is not registered with the geodatabase.</para>
	/// </summary>
	public class CreateUnRegisteredTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Table Location</para>
		/// <para>The enterprise geodatabase or database in which the output table will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Table Name</para>
		/// <para>The name of the table to be created.</para>
		/// </param>
		public CreateUnRegisteredTable(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Unregistered Table</para>
		/// </summary>
		public override string DisplayName => "Create Unregistered Table";

		/// <summary>
		/// <para>Tool Name : CreateUnRegisteredTable</para>
		/// </summary>
		public override string ToolName => "CreateUnRegisteredTable";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateUnRegisteredTable</para>
		/// </summary>
		public override string ExcuteName => "management.CreateUnRegisteredTable";

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
		public override string[] ValidEnvironments => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutPath, OutName, Template, ConfigKeyword, OutTable };

		/// <summary>
		/// <para>Table Location</para>
		/// <para>The enterprise geodatabase or database in which the output table will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
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
		/// <para>An existing table or list of tables with fields and attribute schema used to define the fields in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Specifies the default storage parameters (configurations) for geodatabases in a relational database management system (RDBMS). This setting is applicable only when using enterprise geodatabase tables.</para>
		/// <para>Configuration keywords are set by the database administrator.</para>
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
