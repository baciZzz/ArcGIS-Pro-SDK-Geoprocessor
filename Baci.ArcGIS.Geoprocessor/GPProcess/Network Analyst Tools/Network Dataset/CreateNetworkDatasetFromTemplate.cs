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
	/// <para>Create Network Dataset From Template</para>
	/// <para>通过模板创建网络数据集</para>
	/// <para>使用输入模板文件 (.xml) 中包含的方案创建新的网络数据集。在执行该工具之前，必须确保创建网络数据集所需的所有要素类和输入表已经存在。</para>
	/// </summary>
	public class CreateNetworkDatasetFromTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDatasetTemplate">
		/// <para>Network Dataset Template</para>
		/// <para>使用从网络数据集创建模板工具创建的模板文件 (.xml) 中包含要创建的输出网络数据集方案。</para>
		/// </param>
		/// <param name="OutputFeatureDataset">
		/// <para>Output Feature Dataset</para>
		/// <para>要素数据集中包含将加入所创建的网络数据集的要素类。将根据网络数据集模板中指定的名称在此数据集中创建网络。</para>
		/// </param>
		public CreateNetworkDatasetFromTemplate(object NetworkDatasetTemplate, object OutputFeatureDataset)
		{
			this.NetworkDatasetTemplate = NetworkDatasetTemplate;
			this.OutputFeatureDataset = OutputFeatureDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过模板创建网络数据集</para>
		/// </summary>
		public override string DisplayName() => "通过模板创建网络数据集";

		/// <summary>
		/// <para>Tool Name : CreateNetworkDatasetFromTemplate</para>
		/// </summary>
		public override string ToolName() => "CreateNetworkDatasetFromTemplate";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateNetworkDatasetFromTemplate</para>
		/// </summary>
		public override string ExcuteName() => "na.CreateNetworkDatasetFromTemplate";

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
		public override object[] Parameters() => new object[] { NetworkDatasetTemplate, OutputFeatureDataset, OutputNetwork! };

		/// <summary>
		/// <para>Network Dataset Template</para>
		/// <para>使用从网络数据集创建模板工具创建的模板文件 (.xml) 中包含要创建的输出网络数据集方案。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object NetworkDatasetTemplate { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// <para>要素数据集中包含将加入所创建的网络数据集的要素类。将根据网络数据集模板中指定的名称在此数据集中创建网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object OutputFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DENetworkDataset()]
		public object? OutputNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateNetworkDatasetFromTemplate SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
