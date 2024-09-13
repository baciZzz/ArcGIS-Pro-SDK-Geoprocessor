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
	/// <para>Remove Attribute Index</para>
	/// <para>Remove Attribute Index</para>
	/// <para>This tool deletes an attribute index from an existing table, feature class, shapefile, or attributed relationship class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the index or indexes to be deleted. Table can refer to an actual table, a feature class attribute table, or an attributed relationship class.</para>
		/// </param>
		/// <param name="IndexName">
		/// <para>Index Name or Indexed Item</para>
		/// <para>The name of the index or indexes to be deleted.</para>
		/// </param>
		public RemoveIndex(object InTable, object IndexName)
		{
			this.InTable = InTable;
			this.IndexName = IndexName;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Attribute Index</para>
		/// </summary>
		public override string DisplayName() => "Remove Attribute Index";

		/// <summary>
		/// <para>Tool Name : RemoveIndex</para>
		/// </summary>
		public override string ToolName() => "RemoveIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveIndex";

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
		public override object[] Parameters() => new object[] { InTable, IndexName, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the index or indexes to be deleted. Table can refer to an actual table, a feature class attribute table, or an attributed relationship class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Index Name or Indexed Item</para>
		/// <para>The name of the index or indexes to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object IndexName { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveIndex SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
