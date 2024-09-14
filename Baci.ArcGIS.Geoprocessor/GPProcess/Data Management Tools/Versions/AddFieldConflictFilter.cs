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
	/// <para>Add Field Conflict Filter</para>
	/// <para>Add Field Conflict Filter</para>
	/// <para>Adds a field conflict filter for a given field in a geodatabase table or feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFieldConflictFilter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Table">
		/// <para>Input Table</para>
		/// <para>Table or feature class containing the field or fields to which conflict filters will be applied.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field Name</para>
		/// <para>Field or list of fields that will have conflict filters applied.</para>
		/// </param>
		public AddFieldConflictFilter(object Table, object Fields)
		{
			this.Table = Table;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Field Conflict Filter</para>
		/// </summary>
		public override string DisplayName() => "Add Field Conflict Filter";

		/// <summary>
		/// <para>Tool Name : AddFieldConflictFilter</para>
		/// </summary>
		public override string ToolName() => "AddFieldConflictFilter";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFieldConflictFilter</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFieldConflictFilter";

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
		public override object[] Parameters() => new object[] { Table, Fields, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>Table or feature class containing the field or fields to which conflict filters will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object Table { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>Field or list of fields that will have conflict filters applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFieldConflictFilter SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
