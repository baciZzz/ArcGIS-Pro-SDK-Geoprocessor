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
	/// <para>Import Diagram Template Definitions</para>
	/// <para>导入逻辑示意图模板定义</para>
	/// <para>用于将网络逻辑示意图规则与布局定义文件 (.ndbd) 和/或网络逻辑示意图图层定义文件 (.ndld) 导入到现有模板。</para>
	/// </summary>
	public class ImportDiagramTemplateDefinitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>要导入定义的逻辑示意图模板的名称。</para>
		/// </param>
		public ImportDiagramTemplateDefinitions(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入逻辑示意图模板定义</para>
		/// </summary>
		public override string DisplayName() => "导入逻辑示意图模板定义";

		/// <summary>
		/// <para>Tool Name : ImportDiagramTemplateDefinitions</para>
		/// </summary>
		public override string ToolName() => "ImportDiagramTemplateDefinitions";

		/// <summary>
		/// <para>Tool Excute Name : nd.ImportDiagramTemplateDefinitions</para>
		/// </summary>
		public override string ExcuteName() => "nd.ImportDiagramTemplateDefinitions";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, NdbdFile!, NdldFile!, OutUtilityNetwork!, OutTemplateName! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>包含要修改的逻辑示意图模板的公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>要导入定义的逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Rule and Layout Definitions File</para>
		/// <para>要导入的网络逻辑示意图规则和布局定义文件 (.ndbd)。</para>
		/// <para>此文件是在现有模板上执行导出逻辑示意图模板定义工具的结果。</para>
		/// <para>必须至少完成其中一个输入文件参数；即必须完成网络逻辑示意图规则与布局定义文件 (.ndbd) 或网络逻辑示意图图层定义文件 (.ndld)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndbd")]
		public object? NdbdFile { get; set; }

		/// <summary>
		/// <para>Diagram Layer Definition File</para>
		/// <para>要导入的网络逻辑示意图图层定义文件 (.ndld)。</para>
		/// <para>此文件是对现有模板执行导出逻辑示意图模板定义或导出逻辑示意图图层定义地理处理工具的结果。</para>
		/// <para>必须至少完成其中一个输入文件参数；即必须完成网络逻辑示意图规则与布局定义文件 (.ndbd) 或网络逻辑示意图图层定义文件 (.ndld)。</para>
		/// <para>当输入逻辑示意图模板的逻辑示意图图层定义尚不存在，并且未指定此参数或者加载空 .ndld 文件时，将在模板上系统初始化默认逻辑示意图图层定义 。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndld")]
		public object? NdldFile { get; set; }

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
