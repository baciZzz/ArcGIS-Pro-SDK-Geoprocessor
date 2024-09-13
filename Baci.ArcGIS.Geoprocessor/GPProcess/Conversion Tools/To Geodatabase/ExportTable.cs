using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Export Table</para>
	/// <para>导出表</para>
	/// <para>将表或表视图的行导出到表中。</para>
	/// </summary>
	public class ExportTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要导出到新表格的包含行的输入表。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>包含导出行的输出表。</para>
		/// </param>
		public ExportTable(object InTable, object OutTable)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出表</para>
		/// </summary>
		public override string DisplayName() => "导出表";

		/// <summary>
		/// <para>Tool Name : ExportTable</para>
		/// </summary>
		public override string ToolName() => "ExportTable";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExportTable</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ExportTable";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "maintainAttachments", "preserveGlobalIds", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutTable, WhereClause!, UseFieldAliasAsName!, FieldMapping!, SortField! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要导出到新表格的包含行的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含导出行的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Filter")]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Use Field Alias as Name</para>
		/// <para>指定是将输入字段名称还是字段别名用作输出字段名称。</para>
		/// <para>未选中 - 将输入字段名称用作输出字段名称。 这是默认设置。</para>
		/// <para>选中 - 将输入字段别名用作输出字段名称。</para>
		/// <para><see cref="UseFieldAliasAsNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Fields")]
		public object? UseFieldAliasAsName { get; set; } = "false";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>输出中将包括的具有相应字段属性和源字段的属性字段。 默认情况下，将包括输入的所有字段。</para>
		/// <para>可以添加、删除、重命名和重新排序字段，且可以更改其属性。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。 有多种合并规则可用于确定如何用值填充输出字段。</para>
		/// <para>First - 使用输入字段的第一个值。</para>
		/// <para>Last - 使用输入字段的最后一个值。</para>
		/// <para>Join - 串连（连接）输入字段的值。</para>
		/// <para>Sum - 计算输入字段值的总和。</para>
		/// <para>Mean - 计算输入字段值的平均值。</para>
		/// <para>Median - 计算输入字段值的中值。</para>
		/// <para>Mode - 使用具有最高频率的值。</para>
		/// <para>Min - 使用所有输入字段值中的最小值。</para>
		/// <para>Max - 使用所有输入字段值中的最大值。</para>
		/// <para>Standard deviation - 对所有输入字段值使用标准差分类方法。</para>
		/// <para>Count - 查找计算中所包含的记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		[Category("Fields")]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>包含对输入记录重新排序所用的值的一个或多个字段，以及记录的排序方向。</para>
		/// <para>升序 - 将按照值从低到高的顺序对记录进行排序。</para>
		/// <para>降序 - 将按照值从高到低的顺序对记录进行排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Sort")]
		public object? SortField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTable SetEnviroment(object? configKeyword = null , object? extent = null , bool? maintainAttachments = null , bool? preserveGlobalIds = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use Field Alias as Name</para>
		/// </summary>
		public enum UseFieldAliasAsNameEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_ALIAS")]
			USE_ALIAS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_USE_ALIAS")]
			NOT_USE_ALIAS,

		}

#endregion
	}
}
