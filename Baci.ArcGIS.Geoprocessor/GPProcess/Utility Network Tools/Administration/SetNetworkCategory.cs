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
	/// <para>Set Network Category</para>
	/// <para>设置网络类别</para>
	/// <para>用于将网络类别分配到要在追踪操作中使用的资产类型级别要素类或表。</para>
	/// </summary>
	public class SetNetworkCategory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含网络类别的公共设施网络。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>包含网络类别的公共设施网络内的域网络。</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Input Table</para>
		/// <para>资产类型所属的公共设施网络要素类或表。</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>资产类型所属的资产组。</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>要更改类别配置的资产类型。</para>
		/// </param>
		public SetNetworkCategory(object InUtilityNetwork, object DomainNetwork, object Featureclass, object Assetgroup, object Assettype)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Featureclass = Featureclass;
			this.Assetgroup = Assetgroup;
			this.Assettype = Assettype;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置网络类别</para>
		/// </summary>
		public override string DisplayName() => "设置网络类别";

		/// <summary>
		/// <para>Tool Name : SetNetworkCategory</para>
		/// </summary>
		public override string ToolName() => "SetNetworkCategory";

		/// <summary>
		/// <para>Tool Excute Name : un.SetNetworkCategory</para>
		/// </summary>
		public override string ExcuteName() => "un.SetNetworkCategory";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Featureclass, Assetgroup, Assettype, Category, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含网络类别的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>包含网络类别的公共设施网络内的域网络。</para>
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
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>资产类型所属的资产组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>要更改类别配置的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Categories</para>
		/// <para>要分配到资产类型的类别。为此参数指定的类别会替换分配到资产类型的当前类别。要取消分配资产类型的网络类别，请不要为此参数指定类别。</para>
		/// <para>子网控制器系统提供的网络类别仅适用于设备要素类和交汇点对象表中的资产类型。在具有分区层定义的域网络中，所选资产类型还必须具备分配有最少一个上游和一个下游终端的定向终端配置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Category { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetNetworkCategory SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
