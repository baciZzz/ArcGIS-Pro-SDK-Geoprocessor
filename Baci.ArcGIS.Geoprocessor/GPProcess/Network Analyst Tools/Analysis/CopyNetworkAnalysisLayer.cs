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
	/// <para>Copy Network Analysis Layer</para>
	/// <para>复制网络分析图层</para>
	/// <para>将网络分析图层复制到复本图层。 新图层将具有与原始图层相同的分析设置和网络数据源以及原始图层分析数据的复本。</para>
	/// </summary>
	public class CopyNetworkAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>要复制的网络分析图层。</para>
		/// </param>
		public CopyNetworkAnalysisLayer(object InNetworkAnalysisLayer)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制网络分析图层</para>
		/// </summary>
		public override string DisplayName() => "复制网络分析图层";

		/// <summary>
		/// <para>Tool Name : CopyNetworkAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "CopyNetworkAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.CopyNetworkAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.CopyNetworkAnalysisLayer";

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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, OutLayerName!, OutNetworkAnalysisLayer! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>要复制的网络分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>要创建的网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutLayerName { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyNetworkAnalysisLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
