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
	/// <para>Delete Diagram</para>
	/// <para>删除逻辑示意图</para>
	/// <para>用于删除一个或多个与给定网络相关的存储的网络逻辑示意图，可根据其逻辑示意图模板名称进行过滤。</para>
	/// </summary>
	public class DeleteDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>要删除的输入网络逻辑示意图图层或在删除指定输入逻辑示意图名称集时所基于的 utility network or trace network 图层。</para>
		/// </param>
		public DeleteDiagram(object InDiagrams)
		{
			this.InDiagrams = InDiagrams;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除逻辑示意图</para>
		/// </summary>
		public override string DisplayName() => "删除逻辑示意图";

		/// <summary>
		/// <para>Tool Name : DeleteDiagram</para>
		/// </summary>
		public override string ToolName() => "DeleteDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.DeleteDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.DeleteDiagram";

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
		public override object[] Parameters() => new object[] { InDiagrams, TemplateNames!, DiagramNames!, OutDiagrams! };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>要删除的输入网络逻辑示意图图层或在删除指定输入逻辑示意图名称集时所基于的 utility network or trace network 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Template Names</para>
		/// <para>要处理的相关逻辑示意图的模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? TemplateNames { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// <para>要处理的逻辑示意图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DiagramNames { get; set; }

		/// <summary>
		/// <para>Output Diagrams</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDiagrams { get; set; }

	}
}
