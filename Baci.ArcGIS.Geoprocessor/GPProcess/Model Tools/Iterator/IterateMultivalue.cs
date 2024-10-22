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
	/// <para>Iterate Multivalue</para>
	/// <para>Iterate Multivalue</para>
	/// <para>Iterates over a list of values.</para>
	/// </summary>
	public class IterateMultivalue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InValues">
		/// <para>Input Values</para>
		/// <para>Input values to iterate through.</para>
		/// </param>
		public IterateMultivalue(object InValues)
		{
			this.InValues = InValues;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Multivalue</para>
		/// </summary>
		public override string DisplayName() => "Iterate Multivalue";

		/// <summary>
		/// <para>Tool Name : IterateMultivalue</para>
		/// </summary>
		public override string ToolName() => "IterateMultivalue";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateMultivalue</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateMultivalue";

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
		public override object[] Parameters() => new object[] { InValues, Value! };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>Input values to iterate through.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InValues { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? Value { get; set; }

	}
}
