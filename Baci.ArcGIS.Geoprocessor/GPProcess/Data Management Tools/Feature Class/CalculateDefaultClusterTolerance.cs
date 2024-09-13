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
	/// <para>Calculate Default XY Tolerance</para>
	/// <para>Calculate Default XY Tolerance</para>
	/// <para>Calculates the default xy tolerance.</para>
	/// </summary>
	[Obsolete()]
	public class CalculateDefaultClusterTolerance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// </param>
		public CalculateDefaultClusterTolerance(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Default XY Tolerance</para>
		/// </summary>
		public override string DisplayName() => "Calculate Default XY Tolerance";

		/// <summary>
		/// <para>Tool Name : CalculateDefaultClusterTolerance</para>
		/// </summary>
		public override string ToolName() => "CalculateDefaultClusterTolerance";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateDefaultClusterTolerance</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateDefaultClusterTolerance";

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
		public override object[] Parameters() => new object[] { InFeatures, ClusterTolerance };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Default XY Tolerance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object ClusterTolerance { get; set; } = "0";

	}
}
