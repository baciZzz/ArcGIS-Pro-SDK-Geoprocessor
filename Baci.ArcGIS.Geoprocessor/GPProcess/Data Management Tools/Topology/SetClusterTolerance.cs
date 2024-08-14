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
	/// <para>Sets the cluster tolerance of a topology.</para>
	/// </summary>
	public class SetClusterTolerance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The topology for which you want to change the cluster tolerance.</para>
		/// </param>
		/// <param name="ClusterTolerance">
		/// <para>Cluster Tolerance</para>
		/// <para>The value to be set as the cluster tolerance property of the selected topology. If you enter a value of zero, the default or minimum cluster tolerance will be applied to the topology.</para>
		/// </param>
		public SetClusterTolerance(object InTopology, object ClusterTolerance)
		{
			this.InTopology = InTopology;
			this.ClusterTolerance = ClusterTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Cluster Tolerance</para>
		/// </summary>
		public override string DisplayName => "Set Cluster Tolerance";

		/// <summary>
		/// <para>Tool Name : SetClusterTolerance</para>
		/// </summary>
		public override string ToolName => "SetClusterTolerance";

		/// <summary>
		/// <para>Tool Excute Name : management.SetClusterTolerance</para>
		/// </summary>
		public override string ExcuteName => "management.SetClusterTolerance";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTopology, ClusterTolerance, OutTopology! };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>The topology for which you want to change the cluster tolerance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>The value to be set as the cluster tolerance property of the selected topology. If you enter a value of zero, the default or minimum cluster tolerance will be applied to the topology.</para>
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
