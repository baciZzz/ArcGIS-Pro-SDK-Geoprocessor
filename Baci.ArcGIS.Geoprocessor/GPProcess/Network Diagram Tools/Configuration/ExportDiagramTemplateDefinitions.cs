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
	/// <para>Export Diagram Template Definitions</para>
	/// <para>导出逻辑示意图模板定义</para>
	/// <para>将网络逻辑示意图规则、布局定义和网络逻辑示意图图层定义分别导出到 .ndbd 和 .ndld 文件。</para>
	/// </summary>
	public class ExportDiagramTemplateDefinitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>参考要导出的逻辑示意图模板定义的 utility network or trace network。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>具有要导出的定义的逻辑示意图模板的名称。</para>
		/// </param>
		public ExportDiagramTemplateDefinitions(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出逻辑示意图模板定义</para>
		/// </summary>
		public override string DisplayName() => "导出逻辑示意图模板定义";

		/// <summary>
		/// <para>Tool Name : ExportDiagramTemplateDefinitions</para>
		/// </summary>
		public override string ToolName() => "ExportDiagramTemplateDefinitions";

		/// <summary>
		/// <para>Tool Excute Name : nd.ExportDiagramTemplateDefinitions</para>
		/// </summary>
		public override string ExcuteName() => "nd.ExportDiagramTemplateDefinitions";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, OutNdbdFile!, OutNdldFile!, OutUtilityNetwork!, OutTemplateName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>参考要导出的逻辑示意图模板定义的 utility network or trace network。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>具有要导出的定义的逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Output Rule and Layout Definitions File</para>
		/// <para>要创建的网络逻辑示意图规则和布局定义文件 (.ndbd)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndbd")]
		public object? OutNdbdFile { get; set; }

		/// <summary>
		/// <para>Output Diagram Layer Definition File</para>
		/// <para>要创建的网络逻辑示意图图层定义文件 (.ndld)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndld")]
		public object? OutNdldFile { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutTemplateName { get; set; }

	}
}
