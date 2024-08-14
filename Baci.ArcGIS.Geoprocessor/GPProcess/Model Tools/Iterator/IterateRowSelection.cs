using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Row Selection</para>
	/// <para>Iterates over rows in a table.</para>
	/// </summary>
	public class IterateRowSelection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing records to iterate through.</para>
		/// </param>
		public IterateRowSelection(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Row Selection</para>
		/// </summary>
		public override string DisplayName => "Iterate Row Selection";

		/// <summary>
		/// <para>Tool Name : IterateRowSelection</para>
		/// </summary>
		public override string ToolName => "IterateRowSelection";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateRowSelection</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateRowSelection";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, Fields!, SkipNulls!, Selection!, Value! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing records to iterate through.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Group By Fields</para>
		/// <para>The input field or fields used to group the features for selection. Any number of input fields can be defined, resulting in a selection based on a unique combination of the fields. If a field is not specified, the Object ID is used to iterate over features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Skip Null Values</para>
		/// <para>Specifies if null values in the grouping fields are skipped during selection.</para>
		/// <para>Checked—Skip through all the null values in the grouping fields during selection.</para>
		/// <para>Unchecked—Include all the null values in the grouping fields during selection. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? SkipNulls { get; set; } = "false";

		/// <summary>
		/// <para>Selected Rows</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? Selection { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object? Value { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IterateRowSelection SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
