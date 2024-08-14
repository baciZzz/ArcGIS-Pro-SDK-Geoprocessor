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
	/// <para>Add Subtype</para>
	/// <para>Adds a new subtype to the subtypes in the input table.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddSubtype : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The feature class or table containing the subtype definition to be updated.</para>
		/// </param>
		/// <param name="SubtypeCode">
		/// <para>Subtype Code</para>
		/// <para>A unique integer value for the subtype to be added.</para>
		/// </param>
		/// <param name="SubtypeDescription">
		/// <para>Subtype Name</para>
		/// <para>A description of the subtype code.</para>
		/// </param>
		public AddSubtype(object InTable, object SubtypeCode, object SubtypeDescription)
		{
			this.InTable = InTable;
			this.SubtypeCode = SubtypeCode;
			this.SubtypeDescription = SubtypeDescription;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Subtype</para>
		/// </summary>
		public override string DisplayName => "Add Subtype";

		/// <summary>
		/// <para>Tool Name : AddSubtype</para>
		/// </summary>
		public override string ToolName => "AddSubtype";

		/// <summary>
		/// <para>Tool Excute Name : management.AddSubtype</para>
		/// </summary>
		public override string ExcuteName => "management.AddSubtype";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, SubtypeCode, SubtypeDescription, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The feature class or table containing the subtype definition to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Subtype Code</para>
		/// <para>A unique integer value for the subtype to be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object SubtypeCode { get; set; }

		/// <summary>
		/// <para>Subtype Name</para>
		/// <para>A description of the subtype code.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SubtypeDescription { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSubtype SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
