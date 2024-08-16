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
	/// <para>Create Database View</para>
	/// <para>Creates a view in a database based on an SQL expression.</para>
	/// </summary>
	public class CreateDatabaseView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Workspace</para>
		/// <para>The database that contains the tables or feature classes used to construct the view. This database is also where the view will be created.</para>
		/// </param>
		/// <param name="ViewName">
		/// <para>Output View Name</para>
		/// <para>The name of the view that will be created in the database.</para>
		/// </param>
		/// <param name="ViewDefinition">
		/// <para>View Definition</para>
		/// <para>An SQL statement used to construct the view.</para>
		/// </param>
		public CreateDatabaseView(object InputDatabase, object ViewName, object ViewDefinition)
		{
			this.InputDatabase = InputDatabase;
			this.ViewName = ViewName;
			this.ViewDefinition = ViewDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Database View</para>
		/// </summary>
		public override string DisplayName => "Create Database View";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseView</para>
		/// </summary>
		public override string ToolName => "CreateDatabaseView";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseView</para>
		/// </summary>
		public override string ExcuteName => "management.CreateDatabaseView";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputDatabase, ViewName, ViewDefinition, OutLayer };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The database that contains the tables or feature classes used to construct the view. This database is also where the view will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Local Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Output View Name</para>
		/// <para>The name of the view that will be created in the database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ViewName { get; set; }

		/// <summary>
		/// <para>View Definition</para>
		/// <para>An SQL statement used to construct the view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ViewDefinition { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseView SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
