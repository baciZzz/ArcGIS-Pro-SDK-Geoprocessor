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
	/// <para>Define Mosaic Dataset NoData</para>
	/// <para>Define Mosaic Dataset NoData</para>
	/// <para>Specifies one or more values to be represented as NoData.</para>
	/// </summary>
	public class DefineMosaicDatasetNoData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset where you want to update the NoData values.</para>
		/// </param>
		/// <param name="NumBands">
		/// <para>Number of Bands</para>
		/// <para>The number of bands in the mosaic dataset.</para>
		/// </param>
		public DefineMosaicDatasetNoData(object InMosaicDataset, object NumBands)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.NumBands = NumBands;
		}

		/// <summary>
		/// <para>Tool Display Name : Define Mosaic Dataset NoData</para>
		/// </summary>
		public override string DisplayName() => "Define Mosaic Dataset NoData";

		/// <summary>
		/// <para>Tool Name : DefineMosaicDatasetNoData</para>
		/// </summary>
		public override string ToolName() => "DefineMosaicDatasetNoData";

		/// <summary>
		/// <para>Tool Excute Name : management.DefineMosaicDatasetNoData</para>
		/// </summary>
		public override string ExcuteName() => "management.DefineMosaicDatasetNoData";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, NumBands, BandsForNodataValue, BandsForValidDataRange, WhereClause, CompositeNodataValue, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset where you want to update the NoData values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>The number of bands in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumBands { get; set; }

		/// <summary>
		/// <para>Bands for NoData Value</para>
		/// <para>Specify the NoData value for each band. Each band can have a unique NoData value defined, or you can use the same value for all bands. Choose the band from the drop-down list and then enter a value or multiple values. If you choose multiple NoData values, separate each value with a space.</para>
		/// <para>If the function chain for each raster within the mosaic dataset contains the Composite Bands function, or if your raster data was added with a raster type that adds the Composite Bands function to each raster&apos;s function chain, then any value you specify will apply to all bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object BandsForNodataValue { get; set; }

		/// <summary>
		/// <para>Bands For Valid Data Range</para>
		/// <para>Specify a range of values to display for each band. Values outside of this range will be classified as NoData. When working with composite bands, the range will apply to all bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object BandsForValidDataRange { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL statement to select specific raster in the mosaic dataset. Only the selected rasters will have their NoData values changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Composite NoData value from each band</para>
		/// <para>Choose whether all bands must be NoData in order for the pixel to be classified as NoData.</para>
		/// <para>Unchecked—If any band has pixels of NoData, then the pixel is classified as NoData. This is the default.</para>
		/// <para>Checked—All bands must have pixels of NoData for the pixel to be classified as NoData.</para>
		/// <para><see cref="CompositeNodataValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompositeNodataValue { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DefineMosaicDatasetNoData SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Composite NoData value from each band</para>
		/// </summary>
		public enum CompositeNodataValueEnum 
		{
			/// <summary>
			/// <para>Checked—All bands must have pixels of NoData for the pixel to be classified as NoData.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPOSITE_NODATA")]
			COMPOSITE_NODATA,

			/// <summary>
			/// <para>Unchecked—If any band has pixels of NoData, then the pixel is classified as NoData. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPOSITE_NODATA")]
			NO_COMPOSITE_NODATA,

		}

#endregion
	}
}
