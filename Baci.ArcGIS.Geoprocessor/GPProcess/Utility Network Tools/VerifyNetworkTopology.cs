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
	/// <para>Verify Network Topology</para>
	/// <para>验证网络拓扑</para>
	/// <para>用于验证网络拓扑系统表并将不一致情况记录到输出日志文件中。</para>
	/// </summary>
	public class VerifyNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将验证公共设施网络的一致性。</para>
		/// </param>
		public VerifyNetworkTopology(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 验证网络拓扑</para>
		/// </summary>
		public override string DisplayName() => "验证网络拓扑";

		/// <summary>
		/// <para>Tool Name : VerifyNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "VerifyNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : un.VerifyNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "un.VerifyNetworkTopology";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutLogFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将验证公共设施网络的一致性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>包含所发现问题的输出日志文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutLogFile { get; set; }

	}
}
