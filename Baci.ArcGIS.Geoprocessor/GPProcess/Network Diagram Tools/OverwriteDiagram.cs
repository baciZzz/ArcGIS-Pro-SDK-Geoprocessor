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
	/// <para>Overwrite Diagram</para>
	/// <para>Overwrite Diagram</para>
	/// <para>Overwrites the contents of a network diagram with the network elements currently selected in the specified map. These network elements become the new initial content of the diagram.</para>
	/// </summary>
	public class OverwriteDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to overwrite.</para>
		/// </param>
		/// <param name="Map">
		/// <para>Input Map</para>
		/// <para>The map referencing the set of selected network elements to use to overwrite the input network diagram.</para>
		/// </param>
		public OverwriteDiagram(object InNetworkDiagramLayer, object Map)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.Map = Map;
		}

		/// <summary>
		/// <para>Tool Display Name : Overwrite Diagram</para>
		/// </summary>
		public override string DisplayName() => "Overwrite Diagram";

		/// <summary>
		/// <para>Tool Name : OverwriteDiagram</para>
		/// </summary>
		public override string ToolName() => "OverwriteDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.OverwriteDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.OverwriteDiagram";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, Map, OutNetworkDiagramLayer! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram to overwrite.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map referencing the set of selected network elements to use to overwrite the input network diagram.</para>
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
		public object? OutNetworkDiagramLayer { get; set; }

	}
}
