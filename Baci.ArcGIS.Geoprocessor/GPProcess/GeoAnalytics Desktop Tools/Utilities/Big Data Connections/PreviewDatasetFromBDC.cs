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
	/// <para>Preview Dataset From Big Data Connection</para>
	/// <para>从大数据连接预览数据集</para>
	/// <para>用于创建大数据连接 (BDC) 数据集中前十个要素的预览。</para>
	/// </summary>
	public class PreviewDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDataset">
		/// <para>Big Data Connection Dataset</para>
		/// <para>要从 BDC 文件预览的数据集。</para>
		/// </param>
		public PreviewDatasetFromBDC(object BdcDataset)
		{
			this.BdcDataset = BdcDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 从大数据连接预览数据集</para>
		/// </summary>
		public override string DisplayName() => "从大数据连接预览数据集";

		/// <summary>
		/// <para>Tool Name : PreviewDatasetFromBDC</para>
		/// </summary>
		public override string ToolName() => "PreviewDatasetFromBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.PreviewDatasetFromBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.PreviewDatasetFromBDC";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcDataset, OutPreviewFile };

		/// <summary>
		/// <para>Big Data Connection Dataset</para>
		/// <para>要从 BDC 文件预览的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object BdcDataset { get; set; }

		/// <summary>
		/// <para>Output Preview File</para>
		/// <para>输出代表您的 BDC 数据集预览的 .csv 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("csv")]
		public object OutPreviewFile { get; set; }

	}
}
