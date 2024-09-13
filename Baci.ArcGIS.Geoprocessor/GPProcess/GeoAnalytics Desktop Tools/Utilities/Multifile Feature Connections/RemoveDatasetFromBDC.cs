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
	/// <para>Remove Dataset From Multifile Feature Connection</para>
	/// <para>从多文件要素连接移除数据集</para>
	/// <para>用于从现有多文件要素连接 (MFC) 中移除一个或多个数据集。 此工具仅从 MFC 文件中移除数据集，而不会修改源数据。</para>
	/// </summary>
	public class RemoveDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDatasets">
		/// <para>Multifile Feature Connection Datasets</para>
		/// <para>要从 .mfc 文件移除的数据集。</para>
		/// </param>
		public RemoveDatasetFromBDC(object BdcDatasets)
		{
			this.BdcDatasets = BdcDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : 从多文件要素连接移除数据集</para>
		/// </summary>
		public override string DisplayName() => "从多文件要素连接移除数据集";

		/// <summary>
		/// <para>Tool Name : RemoveDatasetFromBDC</para>
		/// </summary>
		public override string ToolName() => "RemoveDatasetFromBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.RemoveDatasetFromBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.RemoveDatasetFromBDC";

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
		public override object[] Parameters() => new object[] { BdcDatasets, UpdatedBdc! };

		/// <summary>
		/// <para>Multifile Feature Connection Datasets</para>
		/// <para>要从 .mfc 文件移除的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object BdcDatasets { get; set; }

		/// <summary>
		/// <para>Updated MFC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		[GPFileDomain()]
		[FileTypes("bdc", "mfc")]
		public object? UpdatedBdc { get; set; }

	}
}
