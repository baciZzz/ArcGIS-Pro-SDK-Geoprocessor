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
	/// <para>Validate Network Topology</para>
	/// <para>Validate Network Topology</para>
	/// <para>Validates the network topology of a trace network.  Validation of  the network topology is necessary after edits have been made to network attributes or the geometry of features in the network.</para>
	/// </summary>
	public class ValidateNetworkTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network for which the network topology will be validated.</para>
		/// <para>When working with an enterprise geodatabase, the input trace network must be from a trace network service.</para>
		/// </param>
		public ValidateNetworkTopology(object InTraceNetwork)
		{
			this.InTraceNetwork = InTraceNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Validate Network Topology</para>
		/// </summary>
		public override string DisplayName() => "Validate Network Topology";

		/// <summary>
		/// <para>Tool Name : ValidateNetworkTopology</para>
		/// </summary>
		public override string ToolName() => "ValidateNetworkTopology";

		/// <summary>
		/// <para>Tool Excute Name : tn.ValidateNetworkTopology</para>
		/// </summary>
		public override string ExcuteName() => "tn.ValidateNetworkTopology";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, Extent, OutTraceNetwork };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network for which the network topology will be validated.</para>
		/// <para>When working with an enterprise geodatabase, the input trace network must be from a trace network service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>The geographical extent used to validate the network topology.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Validated Network Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object OutTraceNetwork { get; set; }

	}
}
