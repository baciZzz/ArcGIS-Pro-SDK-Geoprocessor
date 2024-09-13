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
	/// <para>Delete Rows</para>
	/// <para>删除行</para>
	/// <para>从输入中删除所有行或所选行子集。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteRows : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>各行将被删除的要素类、图层、表或表视图。</para>
		/// </param>
		public DeleteRows(object InRows)
		{
			this.InRows = InRows;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除行</para>
		/// </summary>
		public override string DisplayName() => "删除行";

		/// <summary>
		/// <para>Tool Name : DeleteRows</para>
		/// </summary>
		public override string ToolName() => "DeleteRows";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteRows</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteRows";

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
		public override object[] Parameters() => new object[] { InRows, OutTable! };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>各行将被删除的要素类、图层、表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InRows { get; set; }

		/// <summary>
		/// <para>Updated Input With Rows Removed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteRows SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
