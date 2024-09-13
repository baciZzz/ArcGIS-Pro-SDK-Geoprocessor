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
	/// <para>获取计数</para>
	/// <para>返回表的总行数。</para>
	/// </summary>
	public class GetCount : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>输入表视图或栅格图层。如果对输入定义了选择内容，则只会返回所选行的计数。</para>
		/// </param>
		public GetCount(object InRows)
		{
			this.InRows = InRows;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取计数</para>
		/// </summary>
		public override string DisplayName() => "获取计数";

		/// <summary>
		/// <para>Tool Name : GetCount</para>
		/// </summary>
		public override string ToolName() => "GetCount";

		/// <summary>
		/// <para>Tool Excute Name : management.GetCount</para>
		/// </summary>
		public override string ExcuteName() => "management.GetCount";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRows, RowCount! };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>输入表视图或栅格图层。如果对输入定义了选择内容，则只会返回所选行的计数。</para>
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
