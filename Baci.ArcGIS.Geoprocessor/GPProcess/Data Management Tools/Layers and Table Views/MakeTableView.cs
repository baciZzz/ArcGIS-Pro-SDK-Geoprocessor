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
	/// <para>Make Table View</para>
	/// <para>创建表视图</para>
	/// <para>根据输入表或要素类创建表视图。由于此工具创建的表视图是临时性的，如果不保存文档，该图层将在会话结束后消失。</para>
	/// </summary>
	public class MakeTableView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入表或要素类。</para>
		/// </param>
		/// <param name="OutView">
		/// <para>Table Name</para>
		/// <para>要创建的表视图的名称。</para>
		/// </param>
		public MakeTableView(object InTable, object OutView)
		{
			this.InTable = InTable;
			this.OutView = OutView;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建表视图</para>
		/// </summary>
		public override string DisplayName() => "创建表视图";

		/// <summary>
		/// <para>Tool Name : MakeTableView</para>
		/// </summary>
		public override string ToolName() => "MakeTableView";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeTableView</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeTableView";

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
		public override object[] Parameters() => new object[] { InTable, OutView, WhereClause, Workspace, FieldInfo };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Table Name</para>
		/// <para>要创建的表视图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutView { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// <para>用于验证字段名的输入工作空间。如果输入是地理数据库表，而输出工作空间是 dBASE 表，则字段名可能会被截断，这是由于 dBASE 字段名最多只能具有十个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		public object Workspace { get; set; }

		/// <summary>
		/// <para>Field Info</para>
		/// <para>指定输入表中的哪些字段在输出表视图中可见</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldInfo()]
		public object FieldInfo { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeTableView SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
