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
	/// <para>Append To Diagram</para>
	/// <para>Appends network elements to a network diagram.</para>
	/// </summary>
	public class AppendToDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram layer to which network elements will be appended.</para>
		/// </param>
		/// <param name="Map">
		/// <para>Input Map</para>
		/// <para>The map with selected network elements to append to the network diagram.</para>
		/// </param>
		public AppendToDiagram(object InNetworkDiagramLayer, object Map)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.Map = Map;
		}

		/// <summary>
		/// <para>Tool Display Name : Append To Diagram</para>
		/// </summary>
		public override string DisplayName() => "Append To Diagram";

		/// <summary>
		/// <para>Tool Name : AppendToDiagram</para>
		/// </summary>
		public override string ToolName() => "AppendToDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.AppendToDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.AppendToDiagram";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, Map, OutNetworkDiagramLayer };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram layer to which network elements will be appended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map with selected network elements to append to the network diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		[GPMapDomain()]
		[MapType("0", "4")]
		public object Map { get; set; }

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

	}
}
