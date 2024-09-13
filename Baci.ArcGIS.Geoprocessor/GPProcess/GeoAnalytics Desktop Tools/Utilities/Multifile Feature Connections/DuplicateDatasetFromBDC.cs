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
	/// <para>Duplicate Dataset From Multifile Feature Connection</para>
	/// <para>从多文件要素连接复制数据集</para>
	/// <para>用于创建多文件要素连接 (MFC) 数据集的副本。</para>
	/// </summary>
	public class DuplicateDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDataset">
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>要复制的 MFC 数据集。</para>
		/// </param>
		public DuplicateDatasetFromBDC(object BdcDataset)
		{
			this.BdcDataset = BdcDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 从多文件要素连接复制数据集</para>
		/// </summary>
		public override string DisplayName() => "从多文件要素连接复制数据集";

		/// <summary>
		/// <para>Tool Name : DuplicateDatasetFromBDC</para>
		/// </summary>
		public override string ToolName() => "DuplicateDatasetFromBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.DuplicateDatasetFromBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.DuplicateDatasetFromBDC";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcDataset, DuplicateName!, UpdatedBdc! };

		/// <summary>
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>要复制的 MFC 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object BdcDataset { get; set; }

		/// <summary>
		/// <para>Duplicate Name</para>
		/// <para>输出 MFC 数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DuplicateName { get; set; }

		/// <summary>
		/// <para>Updated MFC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("bdc", "mfc")]
		public object? UpdatedBdc { get; set; }

	}
}
