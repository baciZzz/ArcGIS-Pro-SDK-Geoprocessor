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
	/// <para>Duplicate Dataset From Big Data Connection</para>
	/// <para>Duplicate Dataset From Big Data Connection</para>
	/// <para>Creates a duplicate of a big data connection (BDC) dataset.</para>
	/// </summary>
	public class DuplicateDatasetFromBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDataset">
		/// <para>Big Data Connection Dataset</para>
		/// <para>The BDC dataset to be duplicated.</para>
		/// </param>
		public DuplicateDatasetFromBDC(object BdcDataset)
		{
			this.BdcDataset = BdcDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Duplicate Dataset From Big Data Connection</para>
		/// </summary>
		public override string DisplayName() => "Duplicate Dataset From Big Data Connection";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcDataset, DuplicateName, UpdatedBdc };

		/// <summary>
		/// <para>Big Data Connection Dataset</para>
		/// <para>The BDC dataset to be duplicated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object BdcDataset { get; set; }

		/// <summary>
		/// <para>Duplicate Name</para>
		/// <para>The name of the output BDC dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DuplicateName { get; set; }

		/// <summary>
		/// <para>Updated BDC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("bdc")]
		public object UpdatedBdc { get; set; }

	}
}
