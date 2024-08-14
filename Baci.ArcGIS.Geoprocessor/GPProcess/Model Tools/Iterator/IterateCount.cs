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
	/// <para>Iterates over a starting and ending value by a given value.</para>
	/// </summary>
	public class IterateCount : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="From">
		/// <para>From Value</para>
		/// <para>The value used to start the iteration.</para>
		/// </param>
		/// <param name="To">
		/// <para>To Value</para>
		/// <para>The value used to run the iteration.</para>
		/// </param>
		/// <param name="Increment">
		/// <para>By Value</para>
		/// <para>The value used to increment.</para>
		/// </param>
		public IterateCount(object From, object To, object Increment)
		{
			this.From = From;
			this.To = To;
			this.Increment = Increment;
		}

		/// <summary>
		/// <para>Tool Display Name : For</para>
		/// </summary>
		public override string DisplayName => "For";

		/// <summary>
		/// <para>Tool Name : IterateCount</para>
		/// </summary>
		public override string ToolName => "IterateCount";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateCount</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateCount";

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
		public override object[] Parameters => new object[] { From, To, Increment, Value! };

		/// <summary>
		/// <para>From Value</para>
		/// <para>The value used to start the iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object From { get; set; } = "0";

		/// <summary>
		/// <para>To Value</para>
		/// <para>The value used to run the iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object To { get; set; }

		/// <summary>
		/// <para>By Value</para>
		/// <para>The value used to increment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object Increment { get; set; } = "1";

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object? Value { get; set; }

	}
}
