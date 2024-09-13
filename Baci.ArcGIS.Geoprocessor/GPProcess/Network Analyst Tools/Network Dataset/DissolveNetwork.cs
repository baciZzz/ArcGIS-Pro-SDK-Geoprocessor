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
	/// <para>Dissolve Network</para>
	/// <para>融合网络</para>
	/// <para>创建可最大程度减少正确构建输入网络数据集模型所需线要素数目的网络数据集。提高输出网络数据集的效率，便可减少求解分析、绘制结果和生成驾车指示所需的时间。此工具将输出新网络数据集和源要素类；输入网络数据集及其源要素保持不变。</para>
	/// </summary>
	public class DissolveNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>要融合的网络数据集。</para>
		/// <para>输入网络数据集必须是只有一个边源的文件地理数据库或个人地理数据库网络数据集。允许任意数目的交汇点源和转弯源。边源必须具有：</para>
		/// <para>端点连通性策略</para>
		/// <para>包括“无”或“高程字段”的高程策略</para>
		/// <para>必须先构建输入网络数据集，之后才能在此工具中使用。</para>
		/// </param>
		/// <param name="OutWorkspaceLocation">
		/// <para>Output Geodatabase Workspace</para>
		/// <para>要创建融合的网络数据集的地理数据库工作空间。工作空间必须为 ArcGIS 10 或更高版本地理数据库，并且必须是与输入网络数据集所在的地理数据库不同的地理数据库。</para>
		/// </param>
		public DissolveNetwork(object InNetworkDataset, object OutWorkspaceLocation)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutWorkspaceLocation = OutWorkspaceLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : 融合网络</para>
		/// </summary>
		public override string DisplayName() => "融合网络";

		/// <summary>
		/// <para>Tool Name : DissolveNetwork</para>
		/// </summary>
		public override string ToolName() => "DissolveNetwork";

		/// <summary>
		/// <para>Tool Excute Name : na.DissolveNetwork</para>
		/// </summary>
		public override string ExcuteName() => "na.DissolveNetwork";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutWorkspaceLocation, OutNetworkDataset! };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>要融合的网络数据集。</para>
		/// <para>输入网络数据集必须是只有一个边源的文件地理数据库或个人地理数据库网络数据集。允许任意数目的交汇点源和转弯源。边源必须具有：</para>
		/// <para>端点连通性策略</para>
		/// <para>包括“无”或“高程字段”的高程策略</para>
		/// <para>必须先构建输入网络数据集，之后才能在此工具中使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Geodatabase Workspace</para>
		/// <para>要创建融合的网络数据集的地理数据库工作空间。工作空间必须为 ArcGIS 10 或更高版本地理数据库，并且必须是与输入网络数据集所在的地理数据库不同的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutWorkspaceLocation { get; set; }

		/// <summary>
		/// <para>Output Dissolved Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DENetworkDataset()]
		public object? OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveNetwork SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
