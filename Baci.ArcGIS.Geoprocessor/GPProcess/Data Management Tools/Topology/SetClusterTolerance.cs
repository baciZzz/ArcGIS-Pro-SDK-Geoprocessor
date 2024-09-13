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
	/// <para>Set Cluster Tolerance</para>
	/// <para>设置拓扑容差</para>
	/// <para>设置拓扑的拓扑容差。</para>
	/// </summary>
	public class SetClusterTolerance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>要更改拓扑容差的拓扑。</para>
		/// </param>
		/// <param name="ClusterTolerance">
		/// <para>Cluster Tolerance</para>
		/// <para>要设置为所选拓扑的拓扑容差属性的值。如果输入值为零，则将对拓扑应用默认拓扑容差或最小拓扑容差。</para>
		/// </param>
		public SetClusterTolerance(object InTopology, object ClusterTolerance)
		{
			this.InTopology = InTopology;
			this.ClusterTolerance = ClusterTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置拓扑容差</para>
		/// </summary>
		public override string DisplayName() => "设置拓扑容差";

		/// <summary>
		/// <para>Tool Name : SetClusterTolerance</para>
		/// </summary>
		public override string ToolName() => "SetClusterTolerance";

		/// <summary>
		/// <para>Tool Excute Name : management.SetClusterTolerance</para>
		/// </summary>
		public override string ExcuteName() => "management.SetClusterTolerance";

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
		public override object[] Parameters() => new object[] { InTopology, ClusterTolerance, OutTopology! };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>要更改拓扑容差的拓扑。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>要设置为所选拓扑的拓扑容差属性的值。如果输入值为零，则将对拓扑应用默认拓扑容差或最小拓扑容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object? OutTopology { get; set; }

	}
}
