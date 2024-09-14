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
	/// <para>Validate Network Topology</para>
	/// <para>验证网络拓扑</para>
	/// <para>验证追踪网络的网络拓扑。在对网络属性或网络中要素的几何进行编辑之后，必须对网络拓扑进行验证。</para>
	/// </summary>
	public class ValidateNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>将验证网络拓扑的追踪网络。</para>
		/// <para>使用企业级地理数据库时，输入追踪网络必须来自追踪网络服务。</para>
		/// </param>
		public ValidateNetworkTopology(object InTraceNetwork)
		{
			this.InTraceNetwork = InTraceNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 验证网络拓扑</para>
		/// </summary>
		public override string DisplayName() => "验证网络拓扑";

		/// <summary>
		/// <para>Tool Name : ValidateNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "ValidateNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : tn.ValidateNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "tn.ValidateNetworkTopology";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, Extent, OutTraceNetwork };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>将验证网络拓扑的追踪网络。</para>
		/// <para>使用企业级地理数据库时，输入追踪网络必须来自追踪网络服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>用于验证网络拓扑的地理范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Validated Network Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

	}
}
