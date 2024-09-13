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
	/// <para>Make Table View</para>
	/// <para>Make Table View</para>
	/// <para>Creates a table view from an input table or feature class. The table view that is created by the tool is temporary and will not persist after the session ends unless the document is saved.</para>
	/// </summary>
	public class MakeTableView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or feature class.</para>
		/// </param>
		/// <param name="OutView">
		/// <para>Table Name</para>
		/// <para>The name of the table view to be created.</para>
		/// </param>
		public MakeTableView(object InTable, object OutView)
		{
			this.InTable = InTable;
			this.OutView = OutView;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Table View</para>
		/// </summary>
		public override string DisplayName() => "Make Table View";

		/// <summary>
		/// <para>Tool Name : MakeTableView</para>
		/// </summary>
		public override string ToolName() => "MakeTableView";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeTableView</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeTableView";

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
		public override object[] Parameters() => new object[] { InTable, OutView, WhereClause!, Workspace!, FieldInfo! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Table Name</para>
		/// <para>The name of the table view to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutView { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// <para>The input workspace used to validate the field names. If the input is a geodatabase table and the output workspace is a dBASE table, the field names may be truncated, since dBASE fields can only have names of ten characters or less.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		public object? Workspace { get; set; }

		/// <summary>
		/// <para>Field Info</para>
		/// <para>Specifies which fields from the input table to make visible in the output table view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldInfo()]
		public object? FieldInfo { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeTableView SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
