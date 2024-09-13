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
	/// <para>Remove Contingent Value</para>
	/// <para>移除条件值</para>
	/// <para>从字段组中移除条件值。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveContingentValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>输入地理数据库要素类或表，其中包含将要移除的条件值。</para>
		/// </param>
		/// <param name="Id">
		/// <para>Contingent Value ID</para>
		/// <para>唯一的条件值 ID。</para>
		/// <para>要在条件值视图中查看条件值 ID，请单击功能区上的切换值 ID 按钮。在 Python 中，可以使用 arcpy.da.ListContingentValues 函数访问此值。</para>
		/// </param>
		public RemoveContingentValue(object TargetTable, object Id)
		{
			this.TargetTable = TargetTable;
			this.Id = Id;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除条件值</para>
		/// </summary>
		public override string DisplayName() => "移除条件值";

		/// <summary>
		/// <para>Tool Name : RemoveContingentValue</para>
		/// </summary>
		public override string ToolName() => "RemoveContingentValue";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveContingentValue</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveContingentValue";

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
		public override object[] Parameters() => new object[] { TargetTable, Id, OutTable! };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>输入地理数据库要素类或表，其中包含将要移除的条件值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Contingent Value ID</para>
		/// <para>唯一的条件值 ID。</para>
		/// <para>要在条件值视图中查看条件值 ID，请单击功能区上的切换值 ID 按钮。在 Python 中，可以使用 arcpy.da.ListContingentValues 函数访问此值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Id { get; set; }

		/// <summary>
		/// <para>Updated Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveContingentValue SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
