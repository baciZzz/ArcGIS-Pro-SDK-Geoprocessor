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
	/// <para>Export Diagram Layer Definition</para>
	/// <para>Export Diagram Layer Definition</para>
	/// <para>Export a diagram template layer definition to a file</para>
	/// </summary>
	[Obsolete()]
	public class ExportDiagramLayerDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// </param>
		/// <param name="OutNdldFile">
		/// <para>Output Diagram Layer Definition File</para>
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
		/// <para>Tool Excute Name : un.ExportDiagramLayerDefinition</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportDiagramLayerDefinition";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutNdldFile, OutNetworkDiagramLayer };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Output Diagram Layer Definition File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndld")]
		public object OutNdldFile { get; set; }

		/// <summary>
		/// <para>Altered Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object OutNetworkDiagramLayer { get; set; }

	}
}
