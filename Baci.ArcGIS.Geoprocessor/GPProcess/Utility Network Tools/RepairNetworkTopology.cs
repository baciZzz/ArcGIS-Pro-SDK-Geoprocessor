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
	/// <para>Repair Network Topology</para>
	/// <para>Verifies and repairs inconsistencies identified in the network topology system tables.</para>
	/// </summary>
	public class RepairNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that will be repaired.</para>
		/// </param>
		public RepairNetworkTopology(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Network Topology</para>
		/// </summary>
		public override string DisplayName() => "Repair Network Topology";

		/// <summary>
		/// <para>Tool Name : RepairNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "RepairNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : un.RepairNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "un.RepairNetworkTopology";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutLogFile, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that will be repaired.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>The folder location and name of the file containing the discovered issues.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutLogFile { get; set; }

		/// <summary>
		/// <para>Output Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
