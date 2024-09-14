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
	/// <para>Collect Values</para>
	/// <para>收集值</para>
	/// <para>用于从迭代器收集输出值或将一组值转换为单个输入。收集值的输出可用作合并、追加、镶嵌和像元统计工具的输入。</para>
	/// </summary>
	public class CollectValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public CollectValues()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : 收集值</para>
		/// </summary>
		public override string DisplayName() => "收集值";

		/// <summary>
		/// <para>Tool Name : CollectValues</para>
		/// </summary>
		public override string ToolName() => "CollectValues";

		/// <summary>
		/// <para>Tool Excute Name : mb.CollectValues</para>
		/// </summary>
		public override string ExcuteName() => "mb.CollectValues";

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
		public override object[] Parameters() => new object[] { InValue, OutValue };

		/// <summary>
		/// <para>Input Value</para>
		/// <para>要收集的输入值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InValue { get; set; }

		/// <summary>
		/// <para>Output Values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutValue { get; set; }

	}
}
