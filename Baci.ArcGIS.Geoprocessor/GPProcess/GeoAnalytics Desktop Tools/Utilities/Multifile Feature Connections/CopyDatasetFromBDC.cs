using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Copy Dataset From Multifile Feature Connection</para>
	/// <para>从多文件要素连接复制数据集</para>
	/// <para>用于将数据集从多文件要素连接 (MFC) 复制到要素类。</para>
	/// </summary>
	public class CopyDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Dataset</para>
		/// <para>要复制的点、线、面或表数据集。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>要从多文件要素连接复制的输出数据集。</para>
		/// </param>
		public CopyDatasetFromBDC(object InputLayer, object Output)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : 从多文件要素连接复制数据集</para>
		/// </summary>
		public override string DisplayName() => "从多文件要素连接复制数据集";

		/// <summary>
		/// <para>Tool Name : CopyDatasetFromBDC</para>
		/// </summary>
		public override string ToolName() => "CopyDatasetFromBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CopyDatasetFromBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.CopyDatasetFromBDC";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, Output };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要复制的点、线、面或表数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>要从多文件要素连接复制的输出数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyDatasetFromBDC SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
