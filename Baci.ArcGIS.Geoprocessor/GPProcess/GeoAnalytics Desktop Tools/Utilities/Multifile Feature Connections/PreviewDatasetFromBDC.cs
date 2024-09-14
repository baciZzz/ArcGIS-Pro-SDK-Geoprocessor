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
	/// <para>Preview Dataset From Multifile Feature Connection</para>
	/// <para>Preview Dataset From Multifile Feature Connection</para>
	/// <para>Creates a preview of the first ten features in  a multifile feature connection (MFC) dataset.</para>
	/// </summary>
	public class PreviewDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDataset">
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>The dataset to preview from the MFC file.</para>
		/// </param>
		public PreviewDatasetFromBDC(object BdcDataset)
		{
			this.BdcDataset = BdcDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Preview Dataset From Multifile Feature Connection</para>
		/// </summary>
		public override string DisplayName() => "Preview Dataset From Multifile Feature Connection";

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
		public override object[] Parameters() => new object[] { BdcDataset, OutPreviewFile! };

		/// <summary>
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>The dataset to preview from the MFC file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object BdcDataset { get; set; }

		/// <summary>
		/// <para>Output Preview File</para>
		/// <para>The output .csv file that represents a preview of your MFC dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("csv")]
		public object? OutPreviewFile { get; set; }

	}
}
