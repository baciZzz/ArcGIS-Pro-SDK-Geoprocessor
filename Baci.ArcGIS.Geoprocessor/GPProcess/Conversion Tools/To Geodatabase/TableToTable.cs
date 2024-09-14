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
	/// <para>Table To Table</para>
	/// <para>表至表</para>
	/// <para>将表格、表视图、要素图层、要素类或带有属性表的栅格的行导出到新的地理数据库、.csv、.txt 或 .dbf 表中。</para>
	/// </summary>
	public class TableToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>要导出到新表格的输入表。</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>写入输出表的目标位置。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Name</para>
		/// <para>输出表的名称。</para>
		/// <para>如果输出位置为文件夹，则需要包含扩展名，例如 .csv、.txt 或 .dbf，以将表格导出为该格式。如果输出位置为地理数据库，则无需指定扩展名。</para>
		/// </param>
		public TableToTable(object InRows, object OutPath, object OutName)
		{
			this.InRows = InRows;
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 表至表</para>
		/// </summary>
		public override string DisplayName() => "表至表";

		/// <summary>
		/// <para>Tool Name : TableToTable</para>
		/// </summary>
		public override string ToolName() => "TableToTable";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToTable</para>
		/// </summary>
		public override string ExcuteName() => "conversion.TableToTable";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "maintainAttachments", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRows, OutPath, OutName, WhereClause, FieldMapping, ConfigKeyword, OutTable };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>要导出到新表格的输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRows { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>写入输出表的目标位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出表的名称。</para>
		/// <para>如果输出位置为文件夹，则需要包含扩展名，例如 .csv、.txt 或 .dbf，以将表格导出为该格式。如果输出位置为地理数据库，则无需指定扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>控制输出中要包含的属性字段。默认情况下，将包括输入的所有字段。</para>
		/// <para>可以添加、删除、重命名和重新排序字段，且可以更改其属性。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。有多种合并规则可用于确定如何用值填充输出字段。</para>
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
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Config Keyword</para>
		/// <para>指定关系数据库管理系统 (RDBMS) 中的地理数据库的默认存储参数（配置）。此设置仅在使用企业级地理数据库表时可用。</para>
		/// <para>配置关键字由数据库管理员进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Settings (optional)")]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToTable SetEnviroment(object configKeyword = null, object extent = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, bool? transferDomains = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
