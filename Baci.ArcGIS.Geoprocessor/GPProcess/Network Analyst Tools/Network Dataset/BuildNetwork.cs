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
	/// <para>Build Network</para>
	/// <para>构建网络</para>
	/// <para>重新构建网络数据集的网络连通性和属性信息。对参与源要素类中的属性或要素进行编辑后，必须重新构建网络数据集。如果编辑的是源要素，该工具将仅对执行了编辑操作的区域建立网络连通性以便加快构建过程；但如果编辑的是网络属性，将会重新构建整个范围的网络数据集。对于大型网络数据集来说，这个操作可能会花费很长时间。</para>
	/// </summary>
	public class BuildNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>要构建的网络数据集。</para>
		/// </param>
		public BuildNetwork(object InNetworkDataset)
		{
			this.InNetworkDataset = InNetworkDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建网络</para>
		/// </summary>
		public override string DisplayName() => "构建网络";

		/// <summary>
		/// <para>Tool Name : BuildNetwork</para>
		/// </summary>
		public override string ToolName() => "BuildNetwork";

		/// <summary>
		/// <para>Tool Excute Name : na.BuildNetwork</para>
		/// </summary>
		public override string ExcuteName() => "na.BuildNetwork";

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
		/// <para>要构建的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Updated Input Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNetworkDatasetLayer()]
		public object? OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildNetwork SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
