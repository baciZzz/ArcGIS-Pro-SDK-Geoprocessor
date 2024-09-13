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
	/// <para>Stop</para>
	/// <para>停止</para>
	/// <para>如果输入值设置为 true 或 false，将使模型退出迭代循环。对于一组输入值，如果所有输入为 true，则迭代会继续；如果任何一个输入为 false，则迭代会停止。该工具的功能与 While 工具非常类似，但如果模型中存在一个 While 循环迭代器且没有其他迭代器可添加时，则该工具对于停止模型非常有用。</para>
	/// </summary>
	public class Stop : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InValues">
		/// <para>Input Values</para>
		/// <para>模型迭代之前，待检查的值将停止。</para>
		/// </param>
		public Stop(object InValues)
		{
			this.InValues = InValues;
		}

		/// <summary>
		/// <para>Tool Display Name : 停止</para>
		/// </summary>
		public override string DisplayName() => "停止";

		/// <summary>
		/// <para>Tool Name : 停止</para>
		/// </summary>
		public override string ToolName() => "停止";

		/// <summary>
		/// <para>Tool Excute Name : mb.Stop</para>
		/// </summary>
		public override string ExcuteName() => "mb.Stop";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InValues, Condition!, Continue! };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>模型迭代之前，待检查的值将停止。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InValues { get; set; }

		/// <summary>
		/// <para>Stop when inputs are</para>
		/// <para>指定在所有输入值被设置为 true 或 false 之前是否运行迭代。</para>
		/// <para>True—迭代会一直运行到所有输入值均为 true 时为止 这是默认设置。</para>
		/// <para>False—迭代会一直运行到所有输入值均为 false 时为止。</para>
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
		/// <para>Stop when inputs are</para>
		/// </summary>
		public enum ConditionEnum 
		{
			/// <summary>
			/// <para>True—迭代会一直运行到所有输入值均为 true 时为止 这是默认设置。</para>
			/// </summary>
			[GPValue("TRUE")]
			[Description("True")]
			True,

			/// <summary>
			/// <para>False—迭代会一直运行到所有输入值均为 false 时为止。</para>
			/// </summary>
			[GPValue("FALSE")]
			[Description("False")]
			False,

		}

#endregion
	}
}
