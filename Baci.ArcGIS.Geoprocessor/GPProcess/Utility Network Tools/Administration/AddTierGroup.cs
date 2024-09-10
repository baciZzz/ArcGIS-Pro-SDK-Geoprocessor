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
	/// <para>Add Tier Group</para>
	/// <para>Adds a tier group to a domain network in a utility network.</para>
	/// </summary>
	public class AddTierGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the domain network where the tier group will be added.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The name of the domain network to which the tier group will be added. Tier groups can only be added to domain networks that have a hierarchical tier definition.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Tier Group Name</para>
		/// <para>A unique name for the new tier group. The name can be a maximum of 64 characters in length.</para>
		/// </param>
		public AddTierGroup(object InUtilityNetwork, object DomainNetwork, object Name)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Tier Group</para>
		/// </summary>
		public override string DisplayName() => "Add Tier Group";

		/// <summary>
		/// <para>Tool Name : AddTierGroup</para>
		/// </summary>
		public override string ToolName() => "AddTierGroup";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTierGroup</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTierGroup";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Name, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the domain network where the tier group will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The name of the domain network to which the tier group will be added. Tier groups can only be added to domain networks that have a hierarchical tier definition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier Group Name</para>
		/// <para>A unique name for the new tier group. The name can be a maximum of 64 characters in length.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
