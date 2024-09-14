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
	/// <para>Make Network Dataset Layer</para>
	/// <para>构建网络数据集图层</para>
	/// <para>从网络数据集创建网络数据集图层。</para>
	/// </summary>
	public class MakeNetworkDatasetLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>从中创建新图层的网络数据集。</para>
		/// </param>
		/// <param name="OutputLayer">
		/// <para>Output Layer</para>
		/// <para>要创建的网络数据集图层的名称。</para>
		/// <para>该图层可用作任何可接受网络数据集图层作为输入的地理处理工具的输入。</para>
		/// <para>创建的输出图层是临时图层，该图层在会话结束后将不会继续存在。要将该图层保存到磁盘，请运行保存至图层文件工具。</para>
		/// </param>
		public MakeNetworkDatasetLayer(object InNetworkDataset, object OutputLayer)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutputLayer = OutputLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建网络数据集图层</para>
		/// </summary>
		public override string DisplayName() => "构建网络数据集图层";

		/// <summary>
		/// <para>Tool Name : MakeNetworkDatasetLayer</para>
		/// </summary>
		public override string ToolName() => "MakeNetworkDatasetLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeNetworkDatasetLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeNetworkDatasetLayer";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutputLayer, DrawElements };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>从中创建新图层的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>要创建的网络数据集图层的名称。</para>
		/// <para>该图层可用作任何可接受网络数据集图层作为输入的地理处理工具的输入。</para>
		/// <para>创建的输出图层是临时图层，该图层在会话结束后将不会继续存在。要将该图层保存到磁盘，请运行保存至图层文件工具。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Network Elements to Draw</para>
		/// <para>ArcGIS Pro 尚不支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object DrawElements { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetworkDatasetLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
