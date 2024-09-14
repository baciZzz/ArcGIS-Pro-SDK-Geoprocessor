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
	/// <para>Collect Values</para>
	/// <para>Collects output values from an iterator or converts a list of values into a single input with multiple values.</para>
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
		/// <para>Tool Display Name : Collect Values</para>
		/// </summary>
		public override string DisplayName() => "Collect Values";

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
		public override object[] Parameters() => new object[] { InValue!, OutValue!, OutTable! };

		/// <summary>
		/// <para>Input Value</para>
		/// <para>The input values to be collected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InValue { get; set; }

		/// <summary>
		/// <para>Output Values</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutValue { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table with the collected values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

	}
}
