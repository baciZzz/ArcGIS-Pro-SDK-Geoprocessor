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
	/// <para>If Expression Is</para>
	/// <para>Evaluates whether a given Python expression is True or False.</para>
	/// </summary>
	public class ExpressionIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>The Python expression to be evaluated.</para>
		/// </param>
		public ExpressionIfThenElse(object Expression)
		{
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : If Expression Is</para>
		/// </summary>
		public override string DisplayName => "If Expression Is";

		/// <summary>
		/// <para>Tool Name : ExpressionIfThenElse</para>
		/// </summary>
		public override string ToolName => "ExpressionIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.ExpressionIfThenElse</para>
		/// </summary>
		public override string ExcuteName => "mb.ExpressionIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Expression, CodeBlock!, True!, False! };

		/// <summary>
		/// <para>Expression</para>
		/// <para>The Python expression to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Code Block</para>
		/// <para>A Python code block. The code in the code block must be referenced in the Expression parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? CodeBlock { get; set; }

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? False { get; set; } = "false";

	}
}
