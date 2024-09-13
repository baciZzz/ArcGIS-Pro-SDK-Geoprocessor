using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Update Analysis Layer Attribute Parameter</para>
	/// <para>更新分析图层属性参数</para>
	/// <para>更新网络分析图层的网络属性参数值。在使用求解工具求解前，应使用该工具更新网络分析图层的属性参数值。此操作将确保求解操作使用属性参数的特定值生成恰当的结果。</para>
	/// </summary>
	[Obsolete()]
	public class UpdateAnalysisLayerAttributeParameter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>要更新属性参数值的网络分析图层。</para>
		/// </param>
		/// <param name="ParameterizedAttribute">
		/// <para>Attribute</para>
		/// <para>要更新属性参数的网络属性。</para>
		/// </param>
		/// <param name="AttributeParameterName">
		/// <para>Parameter</para>
		/// <para>要更新的网络属性的参数。“对象”类型的参数不能使用该工具进行更新。</para>
		/// </param>
		public UpdateAnalysisLayerAttributeParameter(object InNetworkAnalysisLayer, object ParameterizedAttribute, object AttributeParameterName)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.ParameterizedAttribute = ParameterizedAttribute;
			this.AttributeParameterName = AttributeParameterName;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新分析图层属性参数</para>
		/// </summary>
		public override string DisplayName() => "更新分析图层属性参数";

		/// <summary>
		/// <para>Tool Name : UpdateAnalysisLayerAttributeParameter</para>
		/// </summary>
		public override string ToolName() => "UpdateAnalysisLayerAttributeParameter";

		/// <summary>
		/// <para>Tool Excute Name : na.UpdateAnalysisLayerAttributeParameter</para>
		/// </summary>
		public override string ExcuteName() => "na.UpdateAnalysisLayerAttributeParameter";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, ParameterizedAttribute, AttributeParameterName, AttributeParameterValue!, OutputLayer! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>要更新属性参数值的网络分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Attribute</para>
		/// <para>要更新属性参数的网络属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ParameterizedAttribute { get; set; }

		/// <summary>
		/// <para>Parameter</para>
		/// <para>要更新的网络属性的参数。“对象”类型的参数不能使用该工具进行更新。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AttributeParameterName { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// <para>要为属性参数设置的值。该值可以是字符串、数值、日期或布尔值（True 和 False）。如果未指定值，则属性参数值将被设置为空。</para>
		/// <para>如果属性参数为限制使用类型，则参数值可被指定为字符串关键字或数值。字符串关键字或数值决定了限制属性是否禁止、避开或优先选择与之关联的网络元素。并且，网络元素避开或优先选择的程度可通过选择 HIGH、MEDIUM、或 LOW 关键字来定义。可支持的关键字如下：</para>
		/// <para>PROHIBITED</para>
		/// <para>AVOID_HIGH</para>
		/// <para>AVOID_MEDIUM</para>
		/// <para>AVOID_LOW</para>
		/// <para>PREFER_LOW</para>
		/// <para>PREFER_MEDIUM</para>
		/// <para>PREFER_HIGH</para>
		/// <para>大于一的数值会避开限制元素；数值越大，避开的元素就越多。零和一之间的数值会导致优先选择限制元素；数值越小，优先选择的限制元素就越多。负值会禁止限制元素。</para>
		/// <para>如果参数值包含一个数组，则使用本地分隔符分隔数组中的各项。例如，在美国，倾向于使用逗号分隔项目。因此，表示包含三个数值的数组时可以显示为：&quot;5,10,15&quot;。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AttributeParameterValue { get; set; }

		/// <summary>
		/// <para>Updated Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateAnalysisLayerAttributeParameter SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
