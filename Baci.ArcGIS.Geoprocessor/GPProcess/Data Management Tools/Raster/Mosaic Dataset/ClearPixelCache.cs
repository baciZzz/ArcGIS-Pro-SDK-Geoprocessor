using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Clear Pixel Cache</para>
	/// <para>Clears the pixel cache associated with a mosaic dataset.</para>
	/// </summary>
	public class ClearPixelCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The input mosaic dataset with the pixel cache to be deleted.</para>
		/// </param>
		public ClearPixelCache(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Clear Pixel Cache</para>
		/// </summary>
		public override string DisplayName => "Clear Pixel Cache";

		/// <summary>
		/// <para>Tool Name : ClearPixelCache</para>
		/// </summary>
		public override string ToolName => "ClearPixelCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ClearPixelCache</para>
		/// </summary>
		public override string ExcuteName => "management.ClearPixelCache";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, GeneratedBefore!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The input mosaic dataset with the pixel cache to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Generated Before</para>
		/// <para>All cache generated before this date will be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? GeneratedBefore { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

	}
}
