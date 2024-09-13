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
	/// <para>导出逻辑示意图图层定义</para>
	/// <para>用于将当前为输入逻辑示意图图层设置的逻辑示意图图层定义导出为网络逻辑示意图图层定义文件 (.ndld)。</para>
	/// </summary>
	public class ExportDiagramLayerDefinition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将导出图层定义的网络逻辑示意图图层。</para>
		/// </param>
		/// <param name="OutNdldFile">
		/// <para>Output File</para>
		/// <para>要创建的网络逻辑示意图图层定义文件 (.ndld)。</para>
		/// </param>
		public ExportDiagramLayerDefinition(object InNetworkDiagramLayer, object OutNdldFile)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.OutNdldFile = OutNdldFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出逻辑示意图图层定义</para>
		/// </summary>
		public override string DisplayName() => "导出逻辑示意图图层定义";

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
		/// <para>将导出图层定义的网络逻辑示意图图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>要创建的网络逻辑示意图图层定义文件 (.ndld)。</para>
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
