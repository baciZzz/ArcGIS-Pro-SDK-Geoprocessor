using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Disable Network Topology</para>
	/// <para>禁用网络拓扑</para>
	/// <para>禁用现有追踪网络的网络拓扑。</para>
	/// </summary>
	public class DisableNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>将禁用网络拓扑的追踪网络。</para>
		/// </param>
		public DisableNetworkTopology(object InTraceNetwork)
		{
			this.InTraceNetwork = InTraceNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用网络拓扑</para>
		/// </summary>
		public override string DisplayName() => "禁用网络拓扑";

		/// <summary>
		/// <para>Tool Name : DisableNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "DisableNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : tn.DisableNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "tn.DisableNetworkTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, OutTraceNetwork };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>将禁用网络拓扑的追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

	}
}
