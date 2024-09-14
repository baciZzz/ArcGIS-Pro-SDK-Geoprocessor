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
	/// <para>Enable Network Topology</para>
	/// <para>Enable Network Topology</para>
	/// <para>Enables a network topology for a utility network.</para>
	/// </summary>
	public class EnableNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network for which the network topology will be enabled.</para>
		/// </param>
		public EnableNetworkTopology(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Network Topology</para>
		/// </summary>
		public override string DisplayName() => "Enable Network Topology";

		/// <summary>
		/// <para>Tool Name : EnableNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "EnableNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : un.EnableNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "un.EnableNetworkTopology";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, MaxNumberOfErrors!, OnlyGenerateErrors!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network for which the network topology will be enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Maximum number of errors</para>
		/// <para>The maximum number of errors before the process of enabling the network topology will stop. Errors will be recorded in the dirty areas sublayer. The default value is 10000.</para>
		/// <para>Increasing the maximum number of errors value will increase the length of time to enable the topology. Setting a value higher than the default value of 10000 is not recommended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object? MaxNumberOfErrors { get; set; } = "10000";

		/// <summary>
		/// <para>Only generate errors</para>
		/// <para>Specifies whether the topology will be enabled or only network errors will be generated.</para>
		/// <para>Checked—The utility network will only be evaluated for network errors. The topology will not be enabled. If you are working with an enterprise geodatabase, the data cannot be registered as versioned. This allows you to inspect and fix errors in the network until you are ready to enable the topology.</para>
		/// <para>Unchecked—The topology will be enabled and any existing errors will generate dirty areas with errors. This is the default.</para>
		/// <para><see cref="OnlyGenerateErrorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? OnlyGenerateErrors { get; set; } = "false";

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Only generate errors</para>
		/// </summary>
		public enum OnlyGenerateErrorsEnum 
		{
			/// <summary>
			/// <para>Checked—The utility network will only be evaluated for network errors. The topology will not be enabled. If you are working with an enterprise geodatabase, the data cannot be registered as versioned. This allows you to inspect and fix errors in the network until you are ready to enable the topology.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_ERRORS")]
			ONLY_ERRORS,

			/// <summary>
			/// <para>Unchecked—The topology will be enabled and any existing errors will generate dirty areas with errors. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE_TOPO")]
			ENABLE_TOPO,

		}

#endregion
	}
}
