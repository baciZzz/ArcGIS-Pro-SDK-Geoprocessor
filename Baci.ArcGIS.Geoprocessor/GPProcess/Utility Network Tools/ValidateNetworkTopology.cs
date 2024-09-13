using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Validate Network Topology</para>
	/// <para>验证网络拓扑</para>
	/// <para>对网络中的要素进行编辑后，用于验证公共设施网络的网络拓扑。</para>
	/// </summary>
	public class ValidateNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将验证网络拓扑的公共设施网络。</para>
		/// </param>
		public ValidateNetworkTopology(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
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
		/// <para>Tool Excute Name : un.ValidateNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "un.ValidateNetworkTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, Extent, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将验证网络拓扑的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

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
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
