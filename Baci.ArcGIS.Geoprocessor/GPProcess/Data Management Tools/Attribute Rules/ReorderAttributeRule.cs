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
	/// <para>Reorder Attribute Rule</para>
	/// <para>重新排序属性规则</para>
	/// <para>重新排列属性规则的赋值顺序。</para>
	/// </summary>
	public class ReorderAttributeRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含属性规则的表。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Calculation Rule Name</para>
		/// <para>将更改其赋值顺序的计算规则的名称。</para>
		/// </param>
		/// <param name="EvaluationOrder">
		/// <para>Evaluation Order</para>
		/// <para>规则的新赋值顺序值。例如，如果您有 5 个规则，且此规则被安排最后一个执行（第五个位置），但您希望在第二个位置对其进行赋值，请输入值 2。对于位置 2 之后的规则，其赋值顺序值将被重新分配以遵循该规则（例如，位置 2 变为位置 3，位置 3 变为位置 4，位置 4 变为位置 5）。</para>
		/// </param>
		public ReorderAttributeRule(object InTable, object Name, object EvaluationOrder)
		{
			this.InTable = InTable;
			this.Name = Name;
			this.EvaluationOrder = EvaluationOrder;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新排序属性规则</para>
		/// </summary>
		public override string DisplayName() => "重新排序属性规则";

		/// <summary>
		/// <para>Tool Name : ReorderAttributeRule</para>
		/// </summary>
		public override string ToolName() => "ReorderAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : management.ReorderAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "management.ReorderAttributeRule";

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
		public override object[] Parameters() => new object[] { InTable, Name, EvaluationOrder, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含属性规则的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Calculation Rule Name</para>
		/// <para>将更改其赋值顺序的计算规则的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Evaluation Order</para>
		/// <para>规则的新赋值顺序值。例如，如果您有 5 个规则，且此规则被安排最后一个执行（第五个位置），但您希望在第二个位置对其进行赋值，请输入值 2。对于位置 2 之后的规则，其赋值顺序值将被重新分配以遵循该规则（例如，位置 2 变为位置 3，位置 3 变为位置 4，位置 4 变为位置 5）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object EvaluationOrder { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReorderAttributeRule SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
