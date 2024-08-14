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
	/// <para>Mosaic Dataset To Mobile Mosaic Dataset</para>
	/// <para>Converts a mosaic dataset into a mobile mosaic dataset compatible with ArcGIS Runtime SDK. A mobile mosaic dataset resides in a mobile geodatabase.</para>
	/// </summary>
	public class MosaicDatasetToMobileMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset to be converted to a mobile mosaic dataset.</para>
		/// </param>
		/// <param name="OutMobileGdb">
		/// <para>Mobile Geodatabase</para>
		/// <para>The geodatabase where the converted mosaic dataset will be created.</para>
		/// </param>
		/// <param name="MosaicDatasetName">
		/// <para>Mosaic Dataset Name</para>
		/// <para>The name of the mobile mosaic dataset to be created.</para>
		/// </param>
		public MosaicDatasetToMobileMosaicDataset(object InMosaicDataset, object OutMobileGdb, object MosaicDatasetName)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutMobileGdb = OutMobileGdb;
			this.MosaicDatasetName = MosaicDatasetName;
		}

		/// <summary>
		/// <para>Tool Display Name : Mosaic Dataset To Mobile Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName => "Mosaic Dataset To Mobile Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : MosaicDatasetToMobileMosaicDataset</para>
		/// </summary>
		public override string ToolName => "MosaicDatasetToMobileMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.MosaicDatasetToMobileMosaicDataset</para>
		/// </summary>
		public override string ExcuteName => "management.MosaicDatasetToMobileMosaicDataset";

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
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, OutMobileGdb, MosaicDatasetName, WhereClause, SelectionFeature, OutDataFolder, ConvertRasters, OutNamePrefix, Format, CompressionMethod, CompressionQuality, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset to be converted to a mobile mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Mobile Geodatabase</para>
		/// <para>The geodatabase where the converted mosaic dataset will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutMobileGdb { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset Name</para>
		/// <para>The name of the mobile mosaic dataset to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MosaicDatasetName { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select specific items to add to the mobile mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Search Options")]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Selection Feature</para>
		/// <para>The mosaic dataset items to be included in the output based on the extent of another image or feature class. Items that lay along the defined extent will be included in the mosaic dataset. They will not be clipped.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Search Options")]
		public object SelectionFeature { get; set; }

		/// <summary>
		/// <para>Output Data Folder</para>
		/// <para>If specified, the tool will create a copy of the source data in this folder. If Convert Rasters is checked, any raster functions associated with the mosaic dataset are processed before creating the copy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Output Data Options")]
		public object OutDataFolder { get; set; }

		/// <summary>
		/// <para>Convert Rasters</para>
		/// <para>Applies the raster functions associated with the input mosaic dataset before creating the mobile mosaic dataset. If checked and you have raster functions that are not supported by ArcGIS Runtime SDK, the tool will apply the raster function chain and save the output as converted raster items. If left unchecked, the tool will not convert raster items. If you have raster functions that are not supported by ArcGIS Runtime SDK, the tool will return the appropriate error message.</para>
		/// <para>Unchecked—Do not convert raster items with functions that are not supported by ArcGIS Runtime SDK. This is the default.</para>
		/// <para>Checked—Apply the raster function chain and save the output as converted raster items.</para>
		/// <para><see cref="ConvertRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output Data Options")]
		public object ConvertRasters { get; set; } = "false";

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>Appends a prefix to each item, which is copied or converted into the output data folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output Data Options")]
		public object OutNamePrefix { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>The format for the rasters written to the output data folder.</para>
		/// <para>TIFF—TIFF format</para>
		/// <para>PNG—PNG format</para>
		/// <para>JPEG—JPEG format</para>
		/// <para>JPEG2000—JPEG2000 format</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Data Options")]
		public object Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>The method of compression for transmitting the mosaicked image from the computer to the display (or from the server to the client).</para>
		/// <para>None—No compression will be used.</para>
		/// <para>JPEG—Compresses up to 8:1 and is suitable for backdrops.</para>
		/// <para>LZ77—Compresses approximately 2:1. Suitable for analysis.</para>
		/// <para>RLE—Lossless compression. Suitable for categorical datasets.</para>
		/// <para><see cref="CompressionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Data Options")]
		public object CompressionMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>A value from 0 to 100. A higher number means better image quality but less compression. Only enabled when JPEG or JP2000 is specified as the compression method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Data Options")]
		public object CompressionQuality { get; set; }

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEMosaicDataset()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MosaicDatasetToMobileMosaicDataset SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert Rasters</para>
		/// </summary>
		public enum ConvertRastersEnum 
		{
			/// <summary>
			/// <para>Checked—Apply the raster function chain and save the output as converted raster items.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALWAYS")]
			ALWAYS,

			/// <summary>
			/// <para>Unchecked—Do not convert raster items with functions that are not supported by ArcGIS Runtime SDK. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("AS_REQUIRED")]
			AS_REQUIRED,

		}

		/// <summary>
		/// <para>Output Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>TIFF—TIFF format</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

			/// <summary>
			/// <para>PNG—PNG format</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG")]
			PNG,

			/// <summary>
			/// <para>JPEG—JPEG format</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>JPEG2000—JPEG2000 format</para>
			/// </summary>
			[GPValue("JP2")]
			[Description("JPEG2000")]
			JPEG2000,

		}

		/// <summary>
		/// <para>Compression Method</para>
		/// </summary>
		public enum CompressionMethodEnum 
		{
			/// <summary>
			/// <para>None—No compression will be used.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>JPEG—Compresses up to 8:1 and is suitable for backdrops.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>LZ77—Compresses approximately 2:1. Suitable for analysis.</para>
			/// </summary>
			[GPValue("LZW")]
			[Description("LZ77")]
			LZ77,

			/// <summary>
			/// <para>RLE—Lossless compression. Suitable for categorical datasets.</para>
			/// </summary>
			[GPValue("RLE")]
			[Description("RLE")]
			RLE,

		}

#endregion
	}
}
