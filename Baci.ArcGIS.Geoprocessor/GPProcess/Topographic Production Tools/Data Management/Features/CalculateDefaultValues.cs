using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Calculate Default Values</para>
	/// <para>Replaces null values in a feature class or table with the default values from the geodatabase feature class.</para>
	/// </summary>
	public class CalculateDefaultValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDatasets">
		/// <para>Input Dataset</para>
		/// <para>The feature classes and/or tables whose null values will be replaced with the default values from the data model.</para>
		/// </param>
		public CalculateDefaultValues(object InDatasets)
		{
			this.InDatasets = InDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Default Values</para>
		/// </summary>
		public override string DisplayName => "Calculate Default Values";

		/// <summary>
		/// <para>Tool Name : CalculateDefaultValues</para>
		/// </summary>
		public override string ToolName => "CalculateDefaultValues";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CalculateDefaultValues</para>
		/// </summary>
		public override string ExcuteName => "topographic.CalculateDefaultValues";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDatasets, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The feature classes and/or tables whose null values will be replaced with the default values from the data model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutDataset { get; set; }

	}
}
