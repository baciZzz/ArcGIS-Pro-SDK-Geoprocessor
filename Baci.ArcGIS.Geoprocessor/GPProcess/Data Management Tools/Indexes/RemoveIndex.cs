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
	/// <para>移除属性索引</para>
	/// <para>此工具可从现有的表、要素类、shapefile 或属性关系类中删除属性索引。</para>
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
		/// <para>包含待删除索引（一个或多个）的表。此处的表可指代实际的表、要素类属性表或属性关系类。</para>
		/// </param>
		/// <param name="IndexName">
		/// <para>Index Name or Indexed Item</para>
		/// <para>待删除索引（一个或多个）的名称。</para>
		/// </param>
		public RemoveIndex(object InTable, object IndexName)
		{
			this.InTable = InTable;
			this.IndexName = IndexName;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除属性索引</para>
		/// </summary>
		public override string DisplayName() => "移除属性索引";

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
		/// <para>包含待删除索引（一个或多个）的表。此处的表可指代实际的表、要素类属性表或属性关系类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Index Name or Indexed Item</para>
		/// <para>待删除索引（一个或多个）的名称。</para>
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
		public RemoveIndex SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
