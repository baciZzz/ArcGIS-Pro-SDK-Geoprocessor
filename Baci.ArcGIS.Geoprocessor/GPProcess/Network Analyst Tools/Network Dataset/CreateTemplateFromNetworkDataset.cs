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
	/// <para>Create Template From Network Dataset</para>
	/// <para>通过网络数据集创建模板</para>
	/// <para>创建包含现有网络数据集方案的文件。然后即可使用该模板文件来创建具有相同方案的新网络数据集。</para>
	/// </summary>
	public class CreateTemplateFromNetworkDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataset">
		/// <para>Network Dataset</para>
		/// <para>该网络数据集的方案将被写入输出模板文件。</para>
		/// </param>
		/// <param name="OutputNetworkDatasetTemplate">
		/// <para>Output Network Dataset Template</para>
		/// <para>输出文件 (.xml) 中将包含输入网络数据集的方案。</para>
		/// </param>
		public CreateTemplateFromNetworkDataset(object NetworkDataset, object OutputNetworkDatasetTemplate)
		{
			this.NetworkDataset = NetworkDataset;
			this.OutputNetworkDatasetTemplate = OutputNetworkDatasetTemplate;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过网络数据集创建模板</para>
		/// </summary>
		public override string DisplayName() => "通过网络数据集创建模板";

		/// <summary>
		/// <para>Tool Name : CreateTemplateFromNetworkDataset</para>
		/// </summary>
		public override string ToolName() => "CreateTemplateFromNetworkDataset";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateTemplateFromNetworkDataset</para>
		/// </summary>
		public override string ExcuteName() => "na.CreateTemplateFromNetworkDataset";

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
		public override object[] Parameters() => new object[] { NetworkDataset, OutputNetworkDatasetTemplate };

		/// <summary>
		/// <para>Network Dataset</para>
		/// <para>该网络数据集的方案将被写入输出模板文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object NetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Network Dataset Template</para>
		/// <para>输出文件 (.xml) 中将包含输入网络数据集的方案。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutputNetworkDatasetTemplate { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTemplateFromNetworkDataset SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
