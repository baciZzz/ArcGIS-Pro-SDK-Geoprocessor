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
	/// <para>创建逻辑示意图图层</para>
	/// <para>用于在网络逻辑示意图中创建网络逻辑示意图图层。</para>
	/// </summary>
	public class MakeDiagramLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>与逻辑示意图相关的 utility network or trace network。</para>
		/// </param>
		/// <param name="NetworkDiagramName">
		/// <para>Network Diagram Name</para>
		/// <para>网络逻辑示意图名称。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>要创建的逻辑示意图图层的名称。</para>
		/// <para>输出逻辑示意图图层可用作任何可接受逻辑示意图图层作为输入的地理处理工具（包括存储逻辑示意图、更新逻辑示意图以及应用智能树布局工具）的输入。</para>
		/// </param>
		public MakeDiagramLayer(object InUtilityNetwork, object NetworkDiagramName, object OutLayer)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkDiagramName = NetworkDiagramName;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建逻辑示意图图层</para>
		/// </summary>
		public override string DisplayName() => "创建逻辑示意图图层";

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
		/// <para>与逻辑示意图相关的 utility network or trace network。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>网络逻辑示意图名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkDiagramName { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>要创建的逻辑示意图图层的名称。</para>
		/// <para>输出逻辑示意图图层可用作任何可接受逻辑示意图图层作为输入的地理处理工具（包括存储逻辑示意图、更新逻辑示意图以及应用智能树布局工具）的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object OutLayer { get; set; }

	}
}
