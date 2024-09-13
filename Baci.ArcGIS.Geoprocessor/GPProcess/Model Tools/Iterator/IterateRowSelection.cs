using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Row Selection</para>
	/// <para>迭代行选择</para>
	/// <para>迭代表中的所有行。</para>
	/// </summary>
	public class IterateRowSelection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要迭代的记录所在的表。</para>
		/// </param>
		public IterateRowSelection(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代行选择</para>
		/// </summary>
		public override string DisplayName() => "迭代行选择";

		/// <summary>
		/// <para>Tool Name : IterateRowSelection</para>
		/// </summary>
		public override string ToolName() => "IterateRowSelection";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateRowSelection</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateRowSelection";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Fields!, SkipNulls!, Selection!, Value! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要迭代的记录所在的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Group By Fields</para>
		/// <para>用于对可供选择的要素进行分组的一个或多个输入字段。可定义多个输入字段，以根据字段的唯一组合进行选择。如果未指定字段，则使用“对象 ID”迭代要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Text", "OID", "Float", "Double", "Date", "GUID", "GlobalID", "XML")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Skip Null Values</para>
		/// <para>指定是否在选择过程中跳过分组字段中的空值。</para>
		/// <para>选中 - 选择过程中跳过分组字段中的所有空值。</para>
		/// <para>未选中 - 选择过程中包含分组字段中的所有空值。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? SkipNulls { get; set; } = "false";

		/// <summary>
		/// <para>Selected Rows</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? Selection { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object? Value { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IterateRowSelection SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
