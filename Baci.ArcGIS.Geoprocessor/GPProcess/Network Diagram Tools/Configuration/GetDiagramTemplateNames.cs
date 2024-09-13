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
	/// <para>Get Diagram Template Names</para>
	/// <para>获取逻辑示意图模板名称</para>
	/// <para>返回与网络相关的所有逻辑示意图模板的名称。</para>
	/// </summary>
	public class GetDiagramTemplateNames : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>与逻辑示意图模板名称相关的 公共设施网络或追踪网络。</para>
		/// </param>
		public GetDiagramTemplateNames(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取逻辑示意图模板名称</para>
		/// </summary>
		public override string DisplayName() => "获取逻辑示意图模板名称";

		/// <summary>
		/// <para>Tool Name : GetDiagramTemplateNames</para>
		/// </summary>
		public override string ToolName() => "GetDiagramTemplateNames";

		/// <summary>
		/// <para>Tool Excute Name : nd.GetDiagramTemplateNames</para>
		/// </summary>
		public override string ExcuteName() => "nd.GetDiagramTemplateNames";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutTemplateNames };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>与逻辑示意图模板名称相关的 公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Templates</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutTemplateNames { get; set; }

	}
}
