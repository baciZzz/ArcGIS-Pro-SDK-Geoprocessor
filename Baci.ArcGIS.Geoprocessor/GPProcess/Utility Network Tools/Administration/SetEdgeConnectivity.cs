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
	/// <para>Defines how features will connect to a line or edge object of a given asset type.</para>
	/// </summary>
	public class SetEdgeConnectivity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the asset type with the edge connectivity to set.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the asset type with the edge connectivity to set.</para>
		/// </param>
		/// <param name="LineFeatureclass">
		/// <para>Input Table</para>
		/// <para>The name of the input feature class or table that contains the asset type with the edge connectivity to set.</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>The asset group that contains the asset type with the edge connectivity to set.</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>The asset type that requires the edge connectivity to set.</para>
		/// </param>
		/// <param name="EdgeConnectivity">
		/// <para>Edge Connectivity</para>
		/// <para>Specifies the edge connectivity type that will be assigned to the asset type.</para>
		/// <para>Any vertex—Features will connect anywhere along the edge including end vertices.</para>
		/// <para>End vertex—Features will only connect to the end vertex of an edge.</para>
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
		/// <para>Tool Display Name : Set Edge Connectivity</para>
		/// </summary>
		public override string DisplayName => "Set Edge Connectivity";

		/// <summary>
		/// <para>Tool Name : SetEdgeConnectivity</para>
		/// </summary>
		public override string ToolName => "SetEdgeConnectivity";

		/// <summary>
		/// <para>Tool Excute Name : un.SetEdgeConnectivity</para>
		/// </summary>
		public override string ExcuteName => "un.SetEdgeConnectivity";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, DomainNetwork, LineFeatureclass, Assetgroup, Assettype, EdgeConnectivity, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the asset type with the edge connectivity to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the asset type with the edge connectivity to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The name of the input feature class or table that contains the asset type with the edge connectivity to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LineFeatureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>The asset group that contains the asset type with the edge connectivity to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>The asset type that requires the edge connectivity to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Edge Connectivity</para>
		/// <para>Specifies the edge connectivity type that will be assigned to the asset type.</para>
		/// <para>Any vertex—Features will connect anywhere along the edge including end vertices.</para>
		/// <para>End vertex—Features will only connect to the end vertex of an edge.</para>
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
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetEdgeConnectivity SetEnviroment(object? workspace = null )
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
			/// <para>Any vertex—Features will connect anywhere along the edge including end vertices.</para>
			/// </summary>
			[GPValue("ANY_VERTEX")]
			[Description("Any vertex")]
			Any_vertex,

			/// <summary>
			/// <para>End vertex—Features will only connect to the end vertex of an edge.</para>
			/// </summary>
			[GPValue("END_VERTEX")]
			[Description("End vertex")]
			End_vertex,

		}

#endregion
	}
}
