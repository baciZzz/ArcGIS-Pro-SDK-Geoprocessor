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
	/// <para>升级网络</para>
	/// <para>升级网络数据集的方案。 升级网络数据集可以允许网络数据集利用当前软件版本中可用的新功能。</para>
	/// <para>此工具已弃用。 要了解有关此工具工作原理的详细信息，请查看归档文档。 “地理数据库管理”工具集中的升级数据集工具已代替了此功能。 升级数据集具有将网络数据集以及其他类型的数据集（例如宗地结构）升级到当前 ArcGIS 版本的功能。</para>
	/// </summary>
	[Obsolete()]
	public class UpgradeNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>要升级的网络数据集。 网络数据集必须是基于地理数据库的网络数据集。</para>
		/// </param>
		public UpgradeNetwork(object InNetworkDataset)
		{
			this.InNetworkDataset = InNetworkDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级网络</para>
		/// </summary>
		public override string DisplayName() => "升级网络";

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
		/// <para>要升级的网络数据集。 网络数据集必须是基于地理数据库的网络数据集。</para>
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
