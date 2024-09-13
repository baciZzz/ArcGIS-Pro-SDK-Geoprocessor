using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Table Select</para>
	/// <para>表筛选</para>
	/// <para>筛选与结构化查询语言 (SQL) 表达式匹配的表记录并将其写入输出表。</para>
	/// </summary>
	public class TableSelect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含与指定表达式匹配的记录的表，匹配记录将被写入输出表。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>该输出表包含输入表中与指定表达式相匹配的记录。</para>
		/// </param>
		public TableSelect(object InTable, object OutTable)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 表筛选</para>
		/// </summary>
		public override string DisplayName() => "表筛选";

		/// <summary>
		/// <para>Tool Name : TableSelect</para>
		/// </summary>
		public override string ToolName() => "TableSelect";

		/// <summary>
		/// <para>Tool Excute Name : analysis.TableSelect</para>
		/// </summary>
		public override string ExcuteName() => "analysis.TableSelect";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutTable, WhereClause };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含与指定表达式匹配的记录的表，匹配记录将被写入输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>该输出表包含输入表中与指定表达式相匹配的记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// <para>用于选择记录子集的 SQL 表达式。有关 SQL 语法的详细信息，请参阅在查询表达式中使用的元素的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableSelect SetEnviroment(object configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

	}
}
