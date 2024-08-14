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
	/// <para>Get Count</para>
	/// <para>Returns the total number of rows for a table.</para>
	/// </summary>
	public class GetCount : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>The input table view or raster layer. If a selection is defined on the input, the count of the selected rows is returned.</para>
		/// </param>
		public GetCount(object InRows)
		{
			this.InRows = InRows;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Count</para>
		/// </summary>
		public override string DisplayName => "Get Count";

		/// <summary>
		/// <para>Tool Name : GetCount</para>
		/// </summary>
		public override string ToolName => "GetCount";

		/// <summary>
		/// <para>Tool Excute Name : management.GetCount</para>
		/// </summary>
		public override string ExcuteName => "management.GetCount";

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
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRows, RowCount! };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>The input table view or raster layer. If a selection is defined on the input, the count of the selected rows is returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRows { get; set; }

		/// <summary>
		/// <para>Row Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? RowCount { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GetCount SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
