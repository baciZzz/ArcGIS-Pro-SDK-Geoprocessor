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
	/// <para>Add Tier</para>
	/// <para>Creates a new tier for a domain network in a utility network.</para>
	/// </summary>
	public class AddTier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the domain network where the tier will be added.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network where the tier will be created.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>The name of the new tier. The name must be unique in the entire utility network.</para>
		/// </param>
		/// <param name="Rank">
		/// <para>Rank</para>
		/// <para>The rank of the tier being added. The highest rank is the number 1.</para>
		/// </param>
		public AddTier(object InUtilityNetwork, object DomainNetwork, object Name, object Rank)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Name = Name;
			this.Rank = Rank;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Tier</para>
		/// </summary>
		public override string DisplayName() => "Add Tier";

		/// <summary>
		/// <para>Tool Name : AddTier</para>
		/// </summary>
		public override string ToolName() => "AddTier";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTier</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTier";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Name, Rank, TopologyType, TierGroupName, SubnetworkFieldName, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the domain network where the tier will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network where the tier will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the new tier. The name must be unique in the entire utility network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Rank</para>
		/// <para>The rank of the tier being added. The highest rank is the number 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object Rank { get; set; }

		/// <summary>
		/// <para>Topology Type</para>
		/// <para>Specifies the topology type for the new tier. Subnetworks with radial and mesh topology types both support one or more subnetwork controllers. This parameter is disabled on the tool dialog box if the input domain network was created with a hierarchical tier definition and the topology type defaults to mesh. If the domain network was created with a partitioned tier definition, this parameter will have all topology types available in the drop-down list.</para>
		/// <para>For tracing or subnetwork management, this parameter does not currently provide a difference in behavior. The functionality of this parameter is under development and will be applicable in a future release.</para>
		/// <para><see cref="TopologyTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TopologyType { get; set; }

		/// <summary>
		/// <para>Tier Group Name</para>
		/// <para>The existing tier group to which the new tier will be added. This parameter is required for domain networks with a hierarchical tier definition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TierGroupName { get; set; }

		/// <summary>
		/// <para>Subnetwork Field Name</para>
		/// <para>The name of the field where the subnetwork names for this tier will be stored. This is a system-maintained field that will be created the first time a tier is added to a tier group and reused for any additional tiers. For example, you have two tier groups: Distribution and Transmission. When you add a tier named system to the Distribution group and specify the subnetwork field name to be systemsubnet, the field is created. Next, you add a second tier named system to the Transmission group. This parameter will detect that the systemsubnet field should be used as the subnetwork field name. This parameter is required for hierarchical tier types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SubnetworkFieldName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Topology Type</para>
		/// </summary>
		public enum TopologyTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RADIAL")]
			[Description("Radial")]
			Radial,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MESH")]
			[Description("Mesh")]
			Mesh,

		}

#endregion
	}
}
