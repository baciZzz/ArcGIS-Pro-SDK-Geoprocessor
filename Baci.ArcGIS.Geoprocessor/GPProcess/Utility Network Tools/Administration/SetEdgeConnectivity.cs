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
	/// <para>Set Edge Connectivity</para>
	/// <para>设置边连通性</para>
	/// <para>定义要素与给定资产类型的线或边对象的连接方式。</para>
	/// </summary>
	public class SetEdgeConnectivity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>公共设施网络，其中包含要设置边连通性的资产类型。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>域网络，其中包含要设置边连通性的资产类型。</para>
		/// </param>
		/// <param name="LineFeatureclass">
		/// <para>Input Table</para>
		/// <para>输入要素类或表名称，该要素类或表包含要设置边连通性的资产类型。</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>资产组，其中包含要设置边连通性的资产类型。</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>需要设置边连通性的资产类型。</para>
		/// </param>
		/// <param name="EdgeConnectivity">
		/// <para>Edge Connectivity</para>
		/// <para>指定将分配给资产类型的边连通性类型。</para>
		/// <para>任意折点—要素将连接到边上的任何位置，包括端折点。</para>
		/// <para>端折点—要素将仅连接到边的端折点。</para>
		/// <para><see cref="EdgeConnectivityEnum"/></para>
		/// </param>
		public SetEdgeConnectivity(object InUtilityNetwork, object DomainNetwork, object LineFeatureclass, object Assetgroup, object Assettype, object EdgeConnectivity)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.LineFeatureclass = LineFeatureclass;
			this.Assetgroup = Assetgroup;
			this.Assettype = Assettype;
			this.EdgeConnectivity = EdgeConnectivity;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置边连通性</para>
		/// </summary>
		public override string DisplayName() => "设置边连通性";

		/// <summary>
		/// <para>Tool Name : SetEdgeConnectivity</para>
		/// </summary>
		public override string ToolName() => "SetEdgeConnectivity";

		/// <summary>
		/// <para>Tool Excute Name : un.SetEdgeConnectivity</para>
		/// </summary>
		public override string ExcuteName() => "un.SetEdgeConnectivity";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, LineFeatureclass, Assetgroup, Assettype, EdgeConnectivity, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>公共设施网络，其中包含要设置边连通性的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>域网络，其中包含要设置边连通性的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入要素类或表名称，该要素类或表包含要设置边连通性的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LineFeatureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>资产组，其中包含要设置边连通性的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>需要设置边连通性的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Edge Connectivity</para>
		/// <para>指定将分配给资产类型的边连通性类型。</para>
		/// <para>任意折点—要素将连接到边上的任何位置，包括端折点。</para>
		/// <para>端折点—要素将仅连接到边的端折点。</para>
		/// <para><see cref="EdgeConnectivityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeConnectivity { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetEdgeConnectivity SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Edge Connectivity</para>
		/// </summary>
		public enum EdgeConnectivityEnum 
		{
			/// <summary>
			/// <para>任意折点—要素将连接到边上的任何位置，包括端折点。</para>
			/// </summary>
			[GPValue("ANY_VERTEX")]
			[Description("任意折点")]
			Any_vertex,

			/// <summary>
			/// <para>端折点—要素将仅连接到边的端折点。</para>
			/// </summary>
			[GPValue("END_VERTEX")]
			[Description("端折点")]
			End_vertex,

		}

#endregion
	}
}
