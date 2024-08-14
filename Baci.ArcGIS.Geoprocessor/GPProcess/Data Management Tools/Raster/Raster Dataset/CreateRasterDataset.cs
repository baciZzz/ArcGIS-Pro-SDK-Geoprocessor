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
	/// <para>Create Raster Dataset</para>
	/// <para>Creates an empty raster dataset.</para>
	/// </summary>
	public class CreateRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase where the raster dataset will be stored.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name, location, and format for the newly created dataset.</para>
		/// <para>When storing the raster dataset in a file format, specify the file extension as follows:</para>
		/// <para>.bil for Esri BIL</para>
		/// <para>.bip for Esri BIP</para>
		/// <para>.bmp for BMP</para>
		/// <para>.bsq for Esri BSQ</para>
		/// <para>.crf for CRF</para>
		/// <para>.dat for ENVI DAT</para>
		/// <para>.gif for GIF</para>
		/// <para>.img for ERDAS IMAGINE</para>
		/// <para>.jpg for JPEG</para>
		/// <para>.jp2 for JPEG 2000</para>
		/// <para>.png for PNG</para>
		/// <para>.tif for TIFF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG format file, a JPEG 2000 format file, a TIFF format file, or a geodatabase, you can specify Compression Type and Compression Quality values in the geoprocessing environments.</para>
		/// </param>
		/// <param name="PixelType">
		/// <para>Pixel Type</para>
		/// <para>The bit depth (radiometric resolution) of the output raster dataset. If this is not specified, the raster dataset will be created with a default pixel type of 8-bit unsigned integer.</para>
		/// <para>Not all data types are supported by all raster formats. Check the List of supported sensors help topic to ensure that the format you are using will support the necessary data type.</para>
		/// <para>1 bit—The pixel type will be a 1-bit unsigned integer. The values can be 0 or 1.</para>
		/// <para>2 bit—The pixel type will be a 2-bit unsigned integer. The values supported can range from 0 to 3.</para>
		/// <para>4 bit—The pixel type will be a 4-bit unsigned integer. The values supported can range from 0 to 15.</para>
		/// <para>8 bit unsigned—The pixel type will be an unsigned 8-bit data type. The values supported can range from 0 to 255.</para>
		/// <para>8 bit signed—The pixel type will be a signed 8-bit data type. The values supported can range from -128 to 127.</para>
		/// <para>16 bit unsigned—The pixel type will be a 16-bit unsigned data type. The values can range from 0 to 65,535.</para>
		/// <para>16 bit signed—The pixel type will be a 16-bit signed data type. The values can range from -32,768 to 32,767.</para>
		/// <para>32 bit unsigned—The pixel type will be a 32-bit unsigned data type. The values can range from 0 to 4,294,967,295.</para>
		/// <para>32 bit signed—The pixel type will be a 32-bit signed data type. The values can range from -2,147,483,648 to 2,147,483,647.</para>
		/// <para>32 bit float—The pixel type will be a 32-bit data type supporting decimals.</para>
		/// <para>64 bit—The pixel type will be a 64-bit data type supporting decimals.</para>
		/// </param>
		/// <param name="NumberOfBands">
		/// <para>Number of Bands</para>
		/// <para>The number of bands of the output raster dataset.</para>
		/// </param>
		public CreateRasterDataset(object OutPath, object OutName, object PixelType, object NumberOfBands)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
			this.PixelType = PixelType;
			this.NumberOfBands = NumberOfBands;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Raster Dataset</para>
		/// </summary>
		public override string DisplayName => "Create Raster Dataset";

		/// <summary>
		/// <para>Tool Name : CreateRasterDataset</para>
		/// </summary>
		public override string ToolName => "CreateRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRasterDataset</para>
		/// </summary>
		public override string ExcuteName => "management.CreateRasterDataset";

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
		public override string[] ValidEnvironments => new string[] { "compression", "configKeyword", "pyramid", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutPath, OutName, Cellsize!, PixelType, RasterSpatialReference!, NumberOfBands, ConfigKeyword!, Pyramids!, TileSize!, Compression!, PyramidOrigin!, OutRasterDataset! };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase where the raster dataset will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name, location, and format for the newly created dataset.</para>
		/// <para>When storing the raster dataset in a file format, specify the file extension as follows:</para>
		/// <para>.bil for Esri BIL</para>
		/// <para>.bip for Esri BIP</para>
		/// <para>.bmp for BMP</para>
		/// <para>.bsq for Esri BSQ</para>
		/// <para>.crf for CRF</para>
		/// <para>.dat for ENVI DAT</para>
		/// <para>.gif for GIF</para>
		/// <para>.img for ERDAS IMAGINE</para>
		/// <para>.jpg for JPEG</para>
		/// <para>.jp2 for JPEG 2000</para>
		/// <para>.png for PNG</para>
		/// <para>.tif for TIFF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG format file, a JPEG 2000 format file, a TIFF format file, or a geodatabase, you can specify Compression Type and Compression Quality values in the geoprocessing environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The pixel size that will be used for the new raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>The bit depth (radiometric resolution) of the output raster dataset. If this is not specified, the raster dataset will be created with a default pixel type of 8-bit unsigned integer.</para>
		/// <para>Not all data types are supported by all raster formats. Check the List of supported sensors help topic to ensure that the format you are using will support the necessary data type.</para>
		/// <para>1 bit—The pixel type will be a 1-bit unsigned integer. The values can be 0 or 1.</para>
		/// <para>2 bit—The pixel type will be a 2-bit unsigned integer. The values supported can range from 0 to 3.</para>
		/// <para>4 bit—The pixel type will be a 4-bit unsigned integer. The values supported can range from 0 to 15.</para>
		/// <para>8 bit unsigned—The pixel type will be an unsigned 8-bit data type. The values supported can range from 0 to 255.</para>
		/// <para>8 bit signed—The pixel type will be a signed 8-bit data type. The values supported can range from -128 to 127.</para>
		/// <para>16 bit unsigned—The pixel type will be a 16-bit unsigned data type. The values can range from 0 to 65,535.</para>
		/// <para>16 bit signed—The pixel type will be a 16-bit signed data type. The values can range from -32,768 to 32,767.</para>
		/// <para>32 bit unsigned—The pixel type will be a 32-bit unsigned data type. The values can range from 0 to 4,294,967,295.</para>
		/// <para>32 bit signed—The pixel type will be a 32-bit signed data type. The values can range from -2,147,483,648 to 2,147,483,647.</para>
		/// <para>32 bit float—The pixel type will be a 32-bit data type supporting decimals.</para>
		/// <para>64 bit—The pixel type will be a 64-bit data type supporting decimals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PixelType { get; set; } = "8_BIT_UNSIGNED";

		/// <summary>
		/// <para>Spatial Reference for Raster</para>
		/// <para>The coordinate system for the output raster dataset.</para>
		/// <para>If this is not specified, the coordinate system set in the environment settings will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? RasterSpatialReference { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>The number of bands of the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfBands { get; set; } = "1";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The storage parameters (configuration) for a file or enterprise geodatabase. Configuration keywords are set up by your database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Create pyramids</para>
		/// <para>Creates pyramids.</para>
		/// <para>For Pyramid Levels, specify a number of -1 or higher. A value of 0 will not create pyramids, and a value of -1 will automatically determine the correct number of pyramid layers to create.</para>
		/// <para>Pyramid Resampling Technique defines how the data will be resampled when creating the pyramids.</para>
		/// <para>NEAREST—Use nearest neighbor for nominal data or raster datasets with color maps, such as land-use or pseudo color images.</para>
		/// <para>BILINEAR—Use bilinear interpolation with continuous data, such as satellite imagery or aerial photography.</para>
		/// <para>CUBIC—Use cubic convolution continuous data, such as satellite imagery or aerial photography. It is similar to bilinear interpolation; however, it resamples the data using a larger matrix.</para>
		/// <para>Pyramid Compression Type defines the method used when compressing the pyramids.</para>
		/// <para>DEFAULT—The compression that is normally used by the raster dataset format will be used.</para>
		/// <para>LZ77—A lossless compression will be used. The values of the cells in the raster will not be changed.</para>
		/// <para>JPEG—A lossy compression will be used.</para>
		/// <para>NONE—No data compression will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvPyramid()]
		public object? Pyramids { get; set; } = "PYRAMIDS -1 NEAREST DEFAULT 75 NO_SKIP NO_SIPS";

		/// <summary>
		/// <para>Tile size</para>
		/// <para>The size of the tiles.</para>
		/// <para>The tile width controls the number of pixels that can be stored in each tile. This is specified as a number of pixels in x. The default tile width is 128.</para>
		/// <para>The tile height controls the number of pixels that can be stored in each tile. This is specified as a number of pixels in y. The default tile height is 128.</para>
		/// <para>Only geodatabases and enterprise geodatabases use tile size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvTileSize()]
		public object? TileSize { get; set; } = "128 128";

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies the type of compression that will be used to store the raster dataset.</para>
		/// <para>LZ77—Lossless compression that preserves all raster cell values will be used.</para>
		/// <para>Jpeg—Lossy compression that uses the public JPEG compression algorithm will be used. If you choose JPEG, you can also specify the compression quality. The valid compression quality value ranges are from 0 to 100. This compression can be used for .jpg files and .tif files.</para>
		/// <para>Jpeg 2000—Lossy compression will be used.</para>
		/// <para>Packbits—PackBits compression will be used for .tif files.</para>
		/// <para>Lzw—Lossless compression that preserves all raster cell values will be used.</para>
		/// <para>Rle—Run-length encoding will be used for .img files.</para>
		/// <para>Ccitt Group 3—Lossless compression for 1-bit data will be used.</para>
		/// <para>Ccitt Group 4—Lossless compression for 1-bit data will be used.</para>
		/// <para>Ccitt 1D—Lossless compression for 1-bit data will be used.</para>
		/// <para>None—No compression will be used. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvCompression()]
		public object? Compression { get; set; } = "LZ77";

		/// <summary>
		/// <para>Origin/Pyramid Reference Point</para>
		/// <para>The origination location of the raster pyramid. It is recommended that you specify this point if you plan to build large mosaics in a file geodatabase or enterprise geodatabase, especially if you plan to mosaic them over time (for example, when updating).</para>
		/// <para>The pyramid reference point should be set to the upper left corner of your raster dataset.</para>
		/// <para>In setting this point for a file geodatabase or enterprise geodatabase, partial pyramiding will be used when updating with a new mosaicked raster dataset. Partial pyramiding updates the parts of the pyramid that do not exist due to the new mosaicked datasets. It is a good practice to set a pyramid reference point so that the entire raster mosaic will be below and to the right of this point. However, a pyramid reference point should not be set too large either.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? PyramidOrigin { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRasterDataset SetEnviroment(object? compression = null , object? configKeyword = null , object? pyramid = null , object? tileSize = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, pyramid: pyramid, tileSize: tileSize);
			return this;
		}

	}
}
