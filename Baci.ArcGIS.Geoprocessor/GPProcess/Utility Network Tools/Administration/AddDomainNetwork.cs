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
	/// <para>Add Domain Network</para>
	/// <para>Adds a domain network to a utility network.</para>
	/// </summary>
	public class AddDomainNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network to which the domain network will be added.</para>
		/// </param>
		/// <param name="DomainNetworkName">
		/// <para>Domain Network Name</para>
		/// <para>The name of the new domain network. The domain network name will prefix the feature class names that are created. For example, a domain named ElectricDistribution would include a feature class named ElectricDistributionJunction.</para>
		/// </param>
		/// <param name="TierDefinition">
		/// <para>Tier Definition</para>
		/// <para>Specifies the tier definition for the new domain network.</para>
		/// <para>Hierarchical—The tier will be defined as hierarchical. In hierarchical domain networks, tiers are nested within one another, so features existing in subnetworks for a lower tier naturally participate in all higher tiers. For example, in a gas network, a valve isolation zone exists in a pressure zone, which in turn exists in a system zone. A feature in the isolation zone also exists in the pressure zone and in the system zone.</para>
		/// <para>Partitioned— The tier will be defined as partitioned. Features in partitioned domain networks only exist in one tier. The relationship between tiers is ordered and linear. Features can exist in one or multiple subnetworks in one tier.</para>
		/// <para><see cref="TierDefinitionEnum"/></para>
		/// </param>
		/// <param name="SubnetworkControllerType">
		/// <para>Subnetwork Controller Type</para>
		/// <para>Specifies the subnetwork controller type for the new domain network.</para>
		/// <para>Subnetwork source—The subnetwork controller type is a set of sources. A source is an origin of the delivered resource. For example, in an electric system, sources of electricity are power generating stations and substations.</para>
		/// <para>Subnetwork sink—The subnetwork controller type is a set of sinks. A sink is the destination of the gathered resource.</para>
		/// <para><see cref="SubnetworkControllerTypeEnum"/></para>
		/// </param>
		public AddDomainNetwork(object InUtilityNetwork, object DomainNetworkName, object TierDefinition, object SubnetworkControllerType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetworkName = DomainNetworkName;
			this.TierDefinition = TierDefinition;
			this.SubnetworkControllerType = SubnetworkControllerType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Domain Network</para>
		/// </summary>
		public override string DisplayName() => "Add Domain Network";

		/// <summary>
		/// <para>Tool Name : AddDomainNetwork</para>
		/// </summary>
		public override string ToolName() => "AddDomainNetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.AddDomainNetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.AddDomainNetwork";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetworkName, TierDefinition, SubnetworkControllerType, DomainNetworkAliasName, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network to which the domain network will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network Name</para>
		/// <para>The name of the new domain network. The domain network name will prefix the feature class names that are created. For example, a domain named ElectricDistribution would include a feature class named ElectricDistributionJunction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetworkName { get; set; }

		/// <summary>
		/// <para>Tier Definition</para>
		/// <para>Specifies the tier definition for the new domain network.</para>
		/// <para>Hierarchical—The tier will be defined as hierarchical. In hierarchical domain networks, tiers are nested within one another, so features existing in subnetworks for a lower tier naturally participate in all higher tiers. For example, in a gas network, a valve isolation zone exists in a pressure zone, which in turn exists in a system zone. A feature in the isolation zone also exists in the pressure zone and in the system zone.</para>
		/// <para>Partitioned— The tier will be defined as partitioned. Features in partitioned domain networks only exist in one tier. The relationship between tiers is ordered and linear. Features can exist in one or multiple subnetworks in one tier.</para>
		/// <para><see cref="TierDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TierDefinition { get; set; }

		/// <summary>
		/// <para>Subnetwork Controller Type</para>
		/// <para>Specifies the subnetwork controller type for the new domain network.</para>
		/// <para>Subnetwork source—The subnetwork controller type is a set of sources. A source is an origin of the delivered resource. For example, in an electric system, sources of electricity are power generating stations and substations.</para>
		/// <para>Subnetwork sink—The subnetwork controller type is a set of sinks. A sink is the destination of the gathered resource.</para>
		/// <para><see cref="SubnetworkControllerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubnetworkControllerType { get; set; }

		/// <summary>
		/// <para>Domain Network Alias Name</para>
		/// <para>The alias name of the domain network. This optional parameter is used to give a more descriptive name to the domain network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DomainNetworkAliasName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Tier Definition</para>
		/// </summary>
		public enum TierDefinitionEnum 
		{
			/// <summary>
			/// <para>Hierarchical—The tier will be defined as hierarchical. In hierarchical domain networks, tiers are nested within one another, so features existing in subnetworks for a lower tier naturally participate in all higher tiers. For example, in a gas network, a valve isolation zone exists in a pressure zone, which in turn exists in a system zone. A feature in the isolation zone also exists in the pressure zone and in the system zone.</para>
			/// </summary>
			[GPValue("HIERARCHICAL")]
			[Description("Hierarchical")]
			Hierarchical,

			/// <summary>
			/// <para>Partitioned— The tier will be defined as partitioned. Features in partitioned domain networks only exist in one tier. The relationship between tiers is ordered and linear. Features can exist in one or multiple subnetworks in one tier.</para>
			/// </summary>
			[GPValue("PARTITIONED")]
			[Description("Partitioned")]
			Partitioned,

		}

		/// <summary>
		/// <para>Subnetwork Controller Type</para>
		/// </summary>
		public enum SubnetworkControllerTypeEnum 
		{
			/// <summary>
			/// <para>Subnetwork source—The subnetwork controller type is a set of sources. A source is an origin of the delivered resource. For example, in an electric system, sources of electricity are power generating stations and substations.</para>
			/// </summary>
			[GPValue("SOURCE")]
			[Description("Subnetwork source")]
			Subnetwork_source,

			/// <summary>
			/// <para>Subnetwork sink—The subnetwork controller type is a set of sinks. A sink is the destination of the gathered resource.</para>
			/// </summary>
			[GPValue("SINK")]
			[Description("Subnetwork sink")]
			Subnetwork_sink,

		}

#endregion
	}
}
