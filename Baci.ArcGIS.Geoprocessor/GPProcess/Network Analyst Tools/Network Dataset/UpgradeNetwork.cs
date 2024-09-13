using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Upgrade Network</para>
	/// <para>Upgrade Network</para>
	/// <para>Upgrades the schema of the network dataset. Upgrading the network dataset allows the network dataset to make use of the new functionality available in the current software release. </para>
	/// <para>This is a deprecated tool. To learn more about how this tool works, view the  archived documentation. This functionality has been replaced by the Upgrade Dataset tool in the Geodatabase Administration toolset. Upgrade Dataset has the ability to upgrade network datasets as well as other types of datasets, such as parcel fabrics, to the current ArcGIS release.</para>
	/// </summary>
	[Obsolete()]
	public class UpgradeNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset to be upgraded. The network dataset must be a geodatabase-based network dataset.</para>
		/// </param>
		public UpgradeNetwork(object InNetworkDataset)
		{
			this.InNetworkDataset = InNetworkDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Upgrade Network</para>
		/// </summary>
		public override string DisplayName() => "Upgrade Network";

		/// <summary>
		/// <para>Tool Name : UpgradeNetwork</para>
		/// </summary>
		public override string ToolName() => "UpgradeNetwork";

		/// <summary>
		/// <para>Tool Excute Name : na.UpgradeNetwork</para>
		/// </summary>
		public override string ExcuteName() => "na.UpgradeNetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDataset, OutNetworkDataset! };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset to be upgraded. The network dataset must be a geodatabase-based network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Network Dataset Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNetworkDatasetLayer()]
		public object? OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpgradeNetwork SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
