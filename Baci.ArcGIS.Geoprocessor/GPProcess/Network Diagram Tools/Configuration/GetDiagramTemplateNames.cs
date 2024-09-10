using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Get Diagram Template Names</para>
	/// <para>Returns the names of all diagram templates related to a network.</para>
	/// </summary>
	public class GetDiagramTemplateNames : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network to which the diagram template names are related.</para>
		/// </param>
		public GetDiagramTemplateNames(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Diagram Template Names</para>
		/// </summary>
		public override string DisplayName() => "Get Diagram Template Names";

		/// <summary>
		/// <para>Tool Name : GetDiagramTemplateNames</para>
		/// </summary>
		public override string ToolName() => "GetDiagramTemplateNames";

		/// <summary>
		/// <para>Tool Excute Name : nd.GetDiagramTemplateNames</para>
		/// </summary>
		public override string ExcuteName() => "nd.GetDiagramTemplateNames";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutTemplateNames };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network to which the diagram template names are related.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Templates</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutTemplateNames { get; set; }

	}
}
