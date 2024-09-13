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
	/// <para>Add Diagram Template</para>
	/// <para>添加逻辑示意图模板</para>
	/// <para>用于向网络添加新的逻辑示意图模板。可导入网络逻辑示意图规则以及布局定义文件 (.ndbd) 和网络逻辑示意图图层定义文件 (.ndld)。</para>
	/// </summary>
	public class AddDiagramTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>将添加模板的 公共设施网络或追踪网络。</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Diagram Template  Name</para>
		/// <para>输出逻辑示意图模板的名称。</para>
		/// </param>
		public AddDiagramTemplate(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加逻辑示意图模板</para>
		/// </summary>
		public override string DisplayName() => "添加逻辑示意图模板";

		/// <summary>
		/// <para>Tool Name : AddDiagramTemplate</para>
		/// </summary>
		public override string ToolName() => "AddDiagramTemplate";

		/// <summary>
		/// <para>Tool Excute Name : nd.AddDiagramTemplate</para>
		/// </summary>
		public override string ExcuteName() => "nd.AddDiagramTemplate";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, NdbdFile, NdldFile, OutUtilityNetwork, OutTemplateName };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>将添加模板的 公共设施网络或追踪网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Diagram Template  Name</para>
		/// <para>输出逻辑示意图模板的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Rule and Layout Definitions File</para>
		/// <para>要导入的网络逻辑示意图规则和布局定义文件 (.ndbd)。可通过现有模板中的导出逻辑示意图模板定义工具创建此文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndbd")]
		public object NdbdFile { get; set; }

		/// <summary>
		/// <para>Diagram Layer Definition File</para>
		/// <para>要导入的逻辑示意图图层定义文件 (.ndld)。可通过现有模板中的导出逻辑示意图模板定义或导出逻辑示意图图层定义工具创建此文件。</para>
		/// <para>如果未指定此参数或者加载空 .ndld 文件，则将针对输入逻辑示意图模板对默认逻辑示意图图层定义进行系统初始化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ndld")]
		public object NdldFile { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Diagram Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutTemplateName { get; set; }

	}
}
