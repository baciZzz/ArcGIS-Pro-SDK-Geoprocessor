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
	/// <para>Verifies the network topology system tables and logs inconsistencies to an output log file.</para>
	/// </summary>
	public class VerifyNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that will be verified for consistency.</para>
		/// </param>
		public VerifyNetworkTopology(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Verify Network Topology</para>
		/// </summary>
		public override string DisplayName => "Verify Network Topology";

		/// <summary>
		/// <para>Tool Name : VerifyNetworkTopology</para>
		/// </summary>
		public override string ToolName => "VerifyNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : un.VerifyNetworkTopology</para>
		/// </summary>
		public override string ExcuteName => "un.VerifyNetworkTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, OutLogFile! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that will be verified for consistency.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>The output log file containing the discovered issues.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutLogFile { get; set; }

	}
}
