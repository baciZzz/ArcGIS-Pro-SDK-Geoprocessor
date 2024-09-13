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
	/// <para>Export Diagram Layer Definition</para>
	/// <para>Export Diagram Layer Definition</para>
	/// <para>Exports the diagram layer definition  currently set up for the input diagram layer into a network diagram layer definition file (.ndld).</para>
	/// </summary>
	public class ExportDiagramLayerDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram layer from which the layer definition will be exported.</para>
		/// </param>
		/// <param name="OutNdldFile">
		/// <para>Output File</para>
		/// <para>The network diagram layer definition file (.ndld) to be created.</para>
		/// </param>
		public ExportDiagramLayerDefinition(object InNetworkDiagramLayer, object OutNdldFile)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.OutNdldFile = OutNdldFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Diagram Layer Definition</para>
		/// </summary>
		public override string DisplayName() => "Export Diagram Layer Definition";

		/// <summary>
		/// <para>Tool Name : ExportDiagramLayerDefinition</para>
		/// </summary>
		public override string ToolName() => "ExportDiagramLayerDefinition";

		/// <summary>
		/// <para>Tool Excute Name : nd.ExportDiagramLayerDefinition</para>
		/// </summary>
		public override string ExcuteName() => "nd.ExportDiagramLayerDefinition";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutNdldFile, OutNetworkDiagramLayer! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>The network diagram layer from which the layer definition will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The network diagram layer definition file (.ndld) to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndld")]
		public object OutNdldFile { get; set; }

		/// <summary>
		/// <para>Output Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

	}
}
