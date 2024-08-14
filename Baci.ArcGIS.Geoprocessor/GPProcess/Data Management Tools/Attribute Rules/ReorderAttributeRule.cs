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
	/// <para>Reorders the evaluation order of an attribute rule.</para>
	/// </summary>
	public class ReorderAttributeRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table that contains the attribute rule.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Calculation Rule Name</para>
		/// <para>The name of the calculation rule that will have its evaluation order altered.</para>
		/// </param>
		/// <param name="EvaluationOrder">
		/// <para>Evaluation Order</para>
		/// <para>The new evaluation order value for the rule. For example, if you have 5 rules and this rule is ordered to execute last (the fifth position) but you want it to be evaluated in the second position, enter the value 2. The evaluation order values for the rules after position 2 will be reassigned to follow this rule (for example, position 2 becomes position 3, position 3 becomes position 4, and position 4 becomes position 5).</para>
		/// </param>
		public ReorderAttributeRule(object InTable, object Name, object EvaluationOrder)
		{
			this.InTable = InTable;
			this.Name = Name;
			this.EvaluationOrder = EvaluationOrder;
		}

		/// <summary>
		/// <para>Tool Display Name : Reorder Attribute Rule</para>
		/// </summary>
		public override string DisplayName => "Reorder Attribute Rule";

		/// <summary>
		/// <para>Tool Name : ReorderAttributeRule</para>
		/// </summary>
		public override string ToolName => "ReorderAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : management.ReorderAttributeRule</para>
		/// </summary>
		public override string ExcuteName => "management.ReorderAttributeRule";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, Name, EvaluationOrder, UpdatedTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table that contains the attribute rule.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Calculation Rule Name</para>
		/// <para>The name of the calculation rule that will have its evaluation order altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Evaluation Order</para>
		/// <para>The new evaluation order value for the rule. For example, if you have 5 rules and this rule is ordered to execute last (the fifth position) but you want it to be evaluated in the second position, enter the value 2. The evaluation order values for the rules after position 2 will be reassigned to follow this rule (for example, position 2 becomes position 3, position 3 becomes position 4, and position 4 becomes position 5).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object EvaluationOrder { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReorderAttributeRule SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
