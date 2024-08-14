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
	/// <para>Assigns a network category to a feature class or table at the asset type level to be used during tracing operations.</para>
	/// </summary>
	public class SetNetworkCategory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the network category.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network in the utility network that contains the network category.</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Input Table</para>
		/// <para>The utility network feature class or table to which the asset type belongs.</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>The asset group to which the asset type belongs.</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>The asset type to alter the category configuration.</para>
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
		/// <para>Tool Display Name : Set Network Category</para>
		/// </summary>
		public override string DisplayName => "Set Network Category";

		/// <summary>
		/// <para>Tool Name : SetNetworkCategory</para>
		/// </summary>
		public override string ToolName => "SetNetworkCategory";

		/// <summary>
		/// <para>Tool Excute Name : un.SetNetworkCategory</para>
		/// </summary>
		public override string ExcuteName => "un.SetNetworkCategory";

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
		public override object[] Parameters => new object[] { InUtilityNetwork, DomainNetwork, Featureclass, Assetgroup, Assettype, Category!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the network category.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network in the utility network that contains the network category.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The utility network feature class or table to which the asset type belongs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>The asset group to which the asset type belongs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>The asset type to alter the category configuration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Categories</para>
		/// <para>The categories to be assigned to the asset type. The categories that are specified for this parameter will replace the current categories that are assigned to the asset type. To unassign a network category from an asset type, do not specify a category for this parameter.</para>
		/// <para>The Subnetwork Controller system-provided network category is only available for asset types in the device feature class and junction object table. In a domain network with a partitioned tier definition, the selected asset type must also have a directional terminal configuration assigned with a minimum of one upstream and one downstream terminal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Category { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetNetworkCategory SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
