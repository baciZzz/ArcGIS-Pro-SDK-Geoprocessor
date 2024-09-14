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
	/// <para>While</para>
	/// <para>While</para>
	/// <para>用于迭代直至条件变为真或条件变为假。</para>
	/// </summary>
	public class IterateCondition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InValues">
		/// <para>Input Values</para>
		/// <para>要评估的输入值，用于确定是否继续迭代。</para>
		/// </param>
		public IterateCondition(object InValues)
		{
			this.InValues = InValues;
		}

		/// <summary>
		/// <para>Tool Display Name : While</para>
		/// </summary>
		public override string DisplayName() => "While";

		/// <summary>
		/// <para>Tool Name : IterateCondition</para>
		/// </summary>
		public override string ToolName() => "IterateCondition";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateCondition</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateCondition";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InValues, Condition!, Continue! };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>要评估的输入值，用于确定是否继续迭代。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InValues { get; set; }

		/// <summary>
		/// <para>Continue if inputs are</para>
		/// <para>指定是否要迭代直至输入值均为 true 或均为 false。</para>
		/// <para>True—该工具将迭代直至所有输入值均为 true。这是默认设置。</para>
		/// <para>False— 该工具将迭代直至所有输入值均为 false。</para>
		/// <para><see cref="ConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Condition { get; set; } = "TRUE";

		/// <summary>
		/// <para>Continue</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? Continue { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Continue if inputs are</para>
		/// </summary>
		public enum ConditionEnum 
		{
			/// <summary>
			/// <para>True—该工具将迭代直至所有输入值均为 true。这是默认设置。</para>
			/// </summary>
			[GPValue("TRUE")]
			[Description("True")]
			True,

			/// <summary>
			/// <para>False— 该工具将迭代直至所有输入值均为 false。</para>
			/// </summary>
			[GPValue("FALSE")]
			[Description("False")]
			False,

		}

#endregion
	}
}
