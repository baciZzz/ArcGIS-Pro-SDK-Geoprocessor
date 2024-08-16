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
	/// <para>Remove Dataset From Big Data Connection</para>
	/// <para>Removes one or more datasets from an existing big data connection (BDC). This tool only removes the dataset from the BDC file, the source data is not modified.</para>
	/// </summary>
	public class RemoveDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDatasets">
		/// <para>Big Data Connection Datasets</para>
		/// <para>The datasets to remove from the .bdc file.</para>
		/// </param>
		public RemoveDatasetFromBDC(object BdcDatasets)
		{
			this.BdcDatasets = BdcDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Dataset From Big Data Connection</para>
		/// </summary>
		public override string DisplayName => "Remove Dataset From Big Data Connection";

		/// <summary>
		/// <para>Tool Name : RemoveDatasetFromBDC</para>
		/// </summary>
		public override string ToolName => "RemoveDatasetFromBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.RemoveDatasetFromBDC</para>
		/// </summary>
		public override string ExcuteName => "gapro.RemoveDatasetFromBDC";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { BdcDatasets, UpdatedBdc };

		/// <summary>
		/// <para>Big Data Connection Datasets</para>
		/// <para>The datasets to remove from the .bdc file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object BdcDatasets { get; set; }

		/// <summary>
		/// <para>Updated BDC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		[GPFileDomain()]
		[FileTypes("bdc")]
		public object UpdatedBdc { get; set; }

	}
}
