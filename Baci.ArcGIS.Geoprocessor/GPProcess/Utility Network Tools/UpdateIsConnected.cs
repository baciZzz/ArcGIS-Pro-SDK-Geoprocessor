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
	/// <para>Update Is Connected</para>
	/// <para>Update Is Connected</para>
	/// <para>Updates the IsConnected attribute on all the network features for the specified utility network based on connectivity.</para>
	/// </summary>
	public class UpdateIsConnected : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Utility Network</para>
		/// <para>The utility network where the IsConnected attribute will be updated.</para>
		/// </param>
		public UpdateIsConnected(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Is Connected</para>
		/// </summary>
		public override string DisplayName() => "Update Is Connected";

		/// <summary>
		/// <para>Tool Name : UpdateIsConnected</para>
		/// </summary>
		public override string ToolName() => "UpdateIsConnected";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateIsConnected</para>
		/// </summary>
		public override string ExcuteName() => "un.UpdateIsConnected";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutUtilityNetwork! };

		/// <summary>
		/// <para>Utility Network</para>
		/// <para>The utility network where the IsConnected attribute will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

	}
}
