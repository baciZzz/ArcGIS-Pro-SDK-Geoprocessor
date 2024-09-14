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
	/// <para>Set Default Subtype</para>
	/// <para>Set Default Subtype</para>
	/// <para>Sets the default value or code for the input table's subtype.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetDefaultSubtype : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or feature class whose subtype default value will be set.</para>
		/// </param>
		/// <param name="SubtypeCode">
		/// <para>Subtype Code</para>
		/// <para>The unique default value for a subtype.</para>
		/// </param>
		public SetDefaultSubtype(object InTable, object SubtypeCode)
		{
			this.InTable = InTable;
			this.SubtypeCode = SubtypeCode;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Default Subtype</para>
		/// </summary>
		public override string DisplayName() => "Set Default Subtype";

		/// <summary>
		/// <para>Tool Name : SetDefaultSubtype</para>
		/// </summary>
		public override string ToolName() => "SetDefaultSubtype";

		/// <summary>
		/// <para>Tool Excute Name : management.SetDefaultSubtype</para>
		/// </summary>
		public override string ExcuteName() => "management.SetDefaultSubtype";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, SubtypeCode, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or feature class whose subtype default value will be set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Subtype Code</para>
		/// <para>The unique default value for a subtype.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object SubtypeCode { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetDefaultSubtype SetEnviroment(int? autoCommit = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
