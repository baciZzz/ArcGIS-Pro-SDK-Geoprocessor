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
	/// <para>Create Diagram</para>
	/// <para>创建逻辑示意图</para>
	/// <para>用于根据当前在活动地图中选择的网络元素或根据通过 Python 脚本创建的图层来创建临时网络逻辑示意图。</para>
	/// </summary>
	public class CreateDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>将从中创建逻辑示意图的公共设施网络或追踪网络。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Template Name</para>
		/// <para>将用于创建逻辑示意图的模板名称。</para>
		/// </param>
		public CreateDiagram(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "创建逻辑示意图";

		/// <summary>
		/// <para>Tool Name : CreateDiagram</para>
		/// </summary>
		public override string ToolName() => "CreateDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.CreateDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.CreateDiagram";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, Features!, OutUtilityNetwork!, OutName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>将从中创建逻辑示意图的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Template Name</para>
		/// <para>将用于创建逻辑示意图的模板名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Features</para>
		/// <para>将用作生成逻辑示意图时的输入的一个或多个要素图层。</para>
		/// <para>如果指定了要素图层并且在活动地图中选择了网络元素，则将忽略所选元素集，并且指定图层中的所有要素将用作创建逻辑示意图时的输入。</para>
		/// <para>如果未指定任何要素图层，则该过程将搜索在活动地图中选择的网络元素，然后根据这些元素创建逻辑示意图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Features { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutName { get; set; }

	}
}
