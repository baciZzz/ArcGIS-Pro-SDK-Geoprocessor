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
	/// <para>Batch Update Fields</para>
	/// <para>批量更新字段</para>
	/// <para>用于根据定义表中定义的方案来转换表或要素类中的字段并创建新的表或要素类。</para>
	/// </summary>
	public class BatchUpdateFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入表或要素类。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>包含已更新字段的输出表或要素类。</para>
		/// </param>
		/// <param name="FieldDefinitionTable">
		/// <para>Output Schema Definition Table</para>
		/// <para>包含将用于创建输出的字段定义和计算的表。</para>
		/// </param>
		public BatchUpdateFields(object InTable, object OutTable, object FieldDefinitionTable)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.FieldDefinitionTable = FieldDefinitionTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 批量更新字段</para>
		/// </summary>
		public override string DisplayName() => "批量更新字段";

		/// <summary>
		/// <para>Tool Name : BatchUpdateFields</para>
		/// </summary>
		public override string ToolName() => "BatchUpdateFields";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchUpdateFields</para>
		/// </summary>
		public override string ExcuteName() => "management.BatchUpdateFields";

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
		public override object[] Parameters() => new object[] { InTable, OutTable, FieldDefinitionTable, ScriptFile!, OutputFieldName!, SourceFieldName!, OutputFieldType!, OutputFieldDecimalsOrLength!, OutputFieldAlias!, OutputFieldScript! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含已更新字段的输出表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Schema Definition Table</para>
		/// <para>包含将用于创建输出的字段定义和计算的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object FieldDefinitionTable { get; set; }

		/// <summary>
		/// <para>Script File</para>
		/// <para>存储多行 Python 函数的 Python 文件，用于对输出表参数字段执行计算。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("py")]
		public object? ScriptFile { get; set; }

		/// <summary>
		/// <para>Output Field Name</para>
		/// <para>定义表中的字段名称，其中包含输出表的目标字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldName { get; set; }

		/// <summary>
		/// <para>Source Field  Name</para>
		/// <para>定义表中的字段名称，其中包含输入表的源字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? SourceFieldName { get; set; }

		/// <summary>
		/// <para>Output Field Type</para>
		/// <para>定义表中的字段名称，用于定义输出表的数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldType { get; set; }

		/// <summary>
		/// <para>Output Field Decimals or Length</para>
		/// <para>定义表中的字段名称，用于定义输出字段的小数位数或字段长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldDecimalsOrLength { get; set; }

		/// <summary>
		/// <para>Output Field Alias</para>
		/// <para>定义表中的字段名称，用于定义输出表字段的别名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldAlias { get; set; }

		/// <summary>
		/// <para>Output Field Script</para>
		/// <para>定义表中的字段名称，用于定义输出字段的计算。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldScript { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchUpdateFields SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
