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
	/// <para>Make Diagram Layer</para>
	/// <para>Creates a network diagram layer from a  network diagram.</para>
	/// </summary>
	public class MakeDiagramLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network the diagram is related to.</para>
		/// </param>
		/// <param name="NetworkDiagramName">
		/// <para>Network Diagram Name</para>
		/// <para>The network diagram name.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The name of the diagram layer to be created.</para>
		/// <para>The output diagram layer can be used as input to any geoprocessing tool that accepts a diagram layer as input, including the Store Diagram, Update Diagram, and Apply Smart Tree Layout tools.</para>
		/// </param>
		public MakeDiagramLayer(object InUtilityNetwork, object NetworkDiagramName, object OutLayer)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkDiagramName = NetworkDiagramName;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Diagram Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Diagram Layer";

		/// <summary>
		/// <para>Tool Name : MakeDiagramLayer</para>
		/// </summary>
		public override string ToolName() => "MakeDiagramLayer";

		/// <summary>
		/// <para>Tool Excute Name : nd.MakeDiagramLayer</para>
		/// </summary>
		public override string ExcuteName() => "nd.MakeDiagramLayer";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, NetworkDiagramName, OutLayer };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network the diagram is related to.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>The network diagram name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkDiagramName { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The name of the diagram layer to be created.</para>
		/// <para>The output diagram layer can be used as input to any geoprocessing tool that accepts a diagram layer as input, including the Store Diagram, Update Diagram, and Apply Smart Tree Layout tools.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object OutLayer { get; set; }

	}
}
