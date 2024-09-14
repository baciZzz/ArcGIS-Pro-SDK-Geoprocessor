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
	/// <para>For</para>
	/// <para>对于</para>
	/// <para>按照给定的增量从起始值迭代至终止值。</para>
	/// </summary>
	public class IterateCount : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="From">
		/// <para>From Value</para>
		/// <para>用于开始迭代的值。</para>
		/// </param>
		/// <param name="To">
		/// <para>To Value</para>
		/// <para>用于运行迭代的值。</para>
		/// </param>
		/// <param name="Increment">
		/// <para>By Value</para>
		/// <para>用于递增的值。</para>
		/// </param>
		public IterateCount(object From, object To, object Increment)
		{
			this.From = From;
			this.To = To;
			this.Increment = Increment;
		}

		/// <summary>
		/// <para>Tool Display Name : 对于</para>
		/// </summary>
		public override string DisplayName() => "对于";

		/// <summary>
		/// <para>Tool Name : IterateCount</para>
		/// </summary>
		public override string ToolName() => "IterateCount";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateCount</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateCount";

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
		public override object[] Parameters() => new object[] { From, To, Increment, Value };

		/// <summary>
		/// <para>From Value</para>
		/// <para>用于开始迭代的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object From { get; set; } = "0";

		/// <summary>
		/// <para>To Value</para>
		/// <para>用于运行迭代的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object To { get; set; }

		/// <summary>
		/// <para>By Value</para>
		/// <para>用于递增的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object Increment { get; set; } = "1";

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object Value { get; set; }

	}
}
