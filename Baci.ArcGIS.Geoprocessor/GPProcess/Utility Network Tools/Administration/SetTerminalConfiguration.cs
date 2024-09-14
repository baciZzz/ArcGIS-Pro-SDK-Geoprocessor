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
	/// <para>Set Terminal Configuration</para>
	/// <para>设置终端配置</para>
	/// <para>用于为资产类型级别要素类分配终端配置。</para>
	/// </summary>
	public class SetTerminalConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含将针对特定资产类型设置的终端配置的公共设施网络。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>资产类型所属的域网络。</para>
		/// </param>
		/// <param name="DeviceFeatureclass">
		/// <para>Input Table</para>
		/// <para>资产类型所属的公共设施网络要素类或表。</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>资产类型所属的资产组。</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>接收终端配置的资产类型。</para>
		/// </param>
		/// <param name="TerminalConfiguration">
		/// <para>Terminal Configuration</para>
		/// <para>要分配到资产类型的终端配置。</para>
		/// </param>
		public SetTerminalConfiguration(object InUtilityNetwork, object DomainNetwork, object DeviceFeatureclass, object Assetgroup, object Assettype, object TerminalConfiguration)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.DeviceFeatureclass = DeviceFeatureclass;
			this.Assetgroup = Assetgroup;
			this.Assettype = Assettype;
			this.TerminalConfiguration = TerminalConfiguration;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置终端配置</para>
		/// </summary>
		public override string DisplayName() => "设置终端配置";

		/// <summary>
		/// <para>Tool Name : SetTerminalConfiguration</para>
		/// </summary>
		public override string ToolName() => "SetTerminalConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : un.SetTerminalConfiguration</para>
		/// </summary>
		public override string ExcuteName() => "un.SetTerminalConfiguration";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, DeviceFeatureclass, Assetgroup, Assettype, TerminalConfiguration, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含将针对特定资产类型设置的终端配置的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>资产类型所属的域网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>资产类型所属的公共设施网络要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DeviceFeatureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>资产类型所属的资产组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>接收终端配置的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Terminal Configuration</para>
		/// <para>要分配到资产类型的终端配置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TerminalConfiguration { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetTerminalConfiguration SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
