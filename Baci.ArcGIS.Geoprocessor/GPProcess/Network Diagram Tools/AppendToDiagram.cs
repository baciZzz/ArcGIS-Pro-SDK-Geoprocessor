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
	/// <para>追加到逻辑示意图</para>
	/// <para>将网络元素追加到网络逻辑示意图。</para>
	/// </summary>
	public class AppendToDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// <para>将追加网络元素的网络逻辑示意图图层。</para>
		/// </param>
		/// <param name="Map">
		/// <para>Input Map</para>
		/// <para>包含要追加到网络逻辑示意图的所选网络要素的地图。</para>
		/// </param>
		public AppendToDiagram(object InNetworkDiagramLayer, object Map)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.Map = Map;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加到逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "追加到逻辑示意图";

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
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, Map, OutNetworkDiagramLayer! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// <para>将追加网络元素的网络逻辑示意图图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Input Map</para>
		/// <para>包含要追加到网络逻辑示意图的所选网络要素的地图。</para>
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
