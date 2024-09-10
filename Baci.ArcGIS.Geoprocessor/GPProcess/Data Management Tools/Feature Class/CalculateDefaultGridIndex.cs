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
	/// <para>Calculate Default Spatial Grid Index</para>
	/// <para>Calculate the default spatial grid index.</para>
	/// </summary>
	[Obsolete()]
	public class CalculateDefaultGridIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// </param>
		public CalculateDefaultGridIndex(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Default Spatial Grid Index</para>
		/// </summary>
		public override string DisplayName() => "Calculate Default Spatial Grid Index";

		/// <summary>
		/// <para>Tool Name : CalculateDefaultGridIndex</para>
		/// </summary>
		public override string ToolName() => "CalculateDefaultGridIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateDefaultGridIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateDefaultGridIndex";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, GridIndex1, GridIndex2, GridIndex3 };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Spatial Grid Index</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object GridIndex1 { get; set; } = "0";

		/// <summary>
		/// <para>Spatial Grid Index2</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object GridIndex2 { get; set; } = "0";

		/// <summary>
		/// <para>Spatial Grid Index3</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object GridIndex3 { get; set; } = "0";

	}
}
