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
	/// <para>Delete Terminal Configuration</para>
	/// <para>Delete Terminal Configuration</para>
	/// <para>Deletes a terminal configuration from a utility network.</para>
	/// </summary>
	public class DeleteTerminalConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the terminal configuration to be deleted.</para>
		/// </param>
		/// <param name="TerminalConfigurationName">
		/// <para>Name</para>
		/// <para>The name of the terminal configuration to delete.</para>
		/// </param>
		public DeleteTerminalConfiguration(object InUtilityNetwork, object TerminalConfigurationName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TerminalConfigurationName = TerminalConfigurationName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Terminal Configuration</para>
		/// </summary>
		public override string DisplayName() => "Delete Terminal Configuration";

		/// <summary>
		/// <para>Tool Name : DeleteTerminalConfiguration</para>
		/// </summary>
		public override string ToolName() => "DeleteTerminalConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteTerminalConfiguration</para>
		/// </summary>
		public override string ExcuteName() => "un.DeleteTerminalConfiguration";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TerminalConfigurationName, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the terminal configuration to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the terminal configuration to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TerminalConfigurationName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

	}
}
