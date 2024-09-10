using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Enable Network Topology</para>
	/// <para>Enables a network topology for a trace network.</para>
	/// </summary>
	public class EnableNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network for which the network topology will be enabled.</para>
		/// </param>
		public EnableNetworkTopology(object InTraceNetwork)
		{
			this.InTraceNetwork = InTraceNetwork;
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
		/// <para>Tool Excute Name : tn.EnableNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "tn.EnableNetworkTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, MaxNumberOfErrors, OnlyGenerateErrors, OutTraceNetwork };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network for which the network topology will be enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Maximum number of errors</para>
		/// <para>The maximum number of errors that can occur before the process of enabling the network topology will stop. Errors will be recorded in the errors table. The default value is 10000.</para>
		/// <para>Increasing the maximum number of errors value will increase the length of time it takes to enable the topology. Setting a value higher than the default value of 10000 is not recommended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object MaxNumberOfErrors { get; set; } = "10000";

		/// <summary>
		/// <para>Only generate errors</para>
		/// <para>Specifies whether the topology will be enabled or only network errors will be generated.</para>
		/// <para>Checked—The trace network will only be evaluated for network errors The topology will not be enabled. This allows you to inspect and fix errors in the network before you enable the topology. If you are working with an enterprise geodatabase, the data cannot be registered as versioned. This allows you to inspect and fix errors in the network until you enable the topology.</para>
		/// <para>Unchecked—The topology will be enabled and any errors that exist will generate error features. This is the default.</para>
		/// <para><see cref="OnlyGenerateErrorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object OnlyGenerateErrors { get; set; } = "false";

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Only generate errors</para>
		/// </summary>
		public enum OnlyGenerateErrorsEnum 
		{
			/// <summary>
			/// <para>Checked—The trace network will only be evaluated for network errors The topology will not be enabled. This allows you to inspect and fix errors in the network before you enable the topology. If you are working with an enterprise geodatabase, the data cannot be registered as versioned. This allows you to inspect and fix errors in the network until you enable the topology.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_ERRORS")]
			ONLY_ERRORS,

			/// <summary>
			/// <para>Unchecked—The topology will be enabled and any errors that exist will generate error features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE_TOPO")]
			ENABLE_TOPO,

		}

#endregion
	}
}
