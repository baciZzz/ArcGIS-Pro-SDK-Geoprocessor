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
		/// <para>The folder or geodatabase to store the raster dataset.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name, location and format for the dataset you are creating.</para>
		/// <para>When storing the raster dataset in a file format, you need to specify the file extension:</para>
		/// <para>.bil for Esri BIL</para>
		/// <para>.bip for Esri BIP</para>
		/// <para>.bmp for BMP</para>
		/// <para>.bsq for Esri BSQ</para>
		/// <para>.dat for ENVI DAT</para>
		/// <para>.gif for GIF</para>
		/// <para>.img for ERDAS IMAGINE</para>
		/// <para>.jpg for JPEG</para>
		/// <para>.jp2 for JPEG 2000</para>
		/// <para>.png for PNG</para>
		/// <para>.tif for TIFF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </param>
		/// <param name="PixelType">
		/// <para>Pixel Type</para>
		/// <para>The bit-depth (radiometric resolution) of the output raster dataset. If this is not specified, your raster dataset will be created with a default pixel type of 8-bit unsigned integer.</para>
		/// <para>Not all data types are supported by all raster formats. Check the List of supported sensors help topic to be sure the format you are using will support the data type you need.</para>
		/// <para>1 bit—A 1-bit unsigned integer. The values can be 0 or 1.</para>
		/// <para>2 bit—A 2-bit unsigned integer. The values supported can be from 0 to 3.</para>
		/// <para>4 bit—A 4-bit unsigned integer. The values supported can be from 0 to 15.</para>
		/// <para>8 bit unsigned—An unsigned 8-bit data type. The values supported can be from 0 to 255.</para>
		/// <para>8 bit signed—A signed 8-bit data type. The values supported can be from -128 to 127.</para>
		/// <para>16 bit unsigned—A 16-bit unsigned data type. The values can range from 0 to 65,535.</para>
		/// <para>16 bit signed—A 16-bit signed data type. The values can range from -32,768 to 32,767.</para>
		/// <para>32 bit unsigned—A 32-bit unsigned data type. The values can range from 0 to 4,294,967,295.</para>
		/// <para>32 bit signed—A 32-bit signed data type. The values can range from -2,147,483,648 to 2,147,483,647.</para>
		/// <para>32 bit float—A 32-bit data type supporting decimals.</para>
		/// <para>64 bit—A 64-bit data type supporting decimals.</para>
		/// </param>
		/// <param name="NumberOfBands">
		/// <para>Number of Bands</para>
		/// <para>The number of bands that the output raster dataset will have.</para>
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
		public override string DisplayName() => "Create Raster Dataset";

		/// <summary>
		/// <para>Tool Name : CreateRasterDataset</para>
		/// </summary>
		public override string ToolName() => "CreateRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRasterDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRasterDataset";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "pyramid", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, Cellsize, PixelType, RasterSpatialReference, NumberOfBands, ConfigKeyword, Pyramids, TileSize, Compression, PyramidOrigin, OutRasterDataset };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase to store the raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name, location and format for the dataset you are creating.</para>
		/// <para>When storing the raster dataset in a file format, you need to specify the file extension:</para>
		/// <para>.bil for Esri BIL</para>
		/// <para>.bip for Esri BIP</para>
		/// <para>.bmp for BMP</para>
		/// <para>.bsq for Esri BSQ</para>
		/// <para>.dat for ENVI DAT</para>
		/// <para>.gif for GIF</para>
		/// <para>.img for ERDAS IMAGINE</para>
		/// <para>.jpg for JPEG</para>
		/// <para>.jp2 for JPEG 2000</para>
		/// <para>.png for PNG</para>
		/// <para>.tif for TIFF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The cell size for the new raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Cellsize { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>The bit-depth (radiometric resolution) of the output raster dataset. If this is not specified, your raster dataset will be created with a default pixel type of 8-bit unsigned integer.</para>
		/// <para>Not all data types are supported by all raster formats. Check the List of supported sensors help topic to be sure the format you are using will support the data type you need.</para>
		/// <para>1 bit—A 1-bit unsigned integer. The values can be 0 or 1.</para>
		/// <para>2 bit—A 2-bit unsigned integer. The values supported can be from 0 to 3.</para>
		/// <para>4 bit—A 4-bit unsigned integer. The values supported can be from 0 to 15.</para>
		/// <para>8 bit unsigned—An unsigned 8-bit data type. The values supported can be from 0 to 255.</para>
		/// <para>8 bit signed—A signed 8-bit data type. The values supported can be from -128 to 127.</para>
		/// <para>16 bit unsigned—A 16-bit unsigned data type. The values can range from 0 to 65,535.</para>
		/// <para>16 bit signed—A 16-bit signed data type. The values can range from -32,768 to 32,767.</para>
		/// <para>32 bit unsigned—A 32-bit unsigned data type. The values can range from 0 to 4,294,967,295.</para>
		/// <para>32 bit signed—A 32-bit signed data type. The values can range from -2,147,483,648 to 2,147,483,647.</para>
		/// <para>32 bit float—A 32-bit data type supporting decimals.</para>
		/// <para>64 bit—A 64-bit data type supporting decimals.</para>
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
		public object RasterSpatialReference { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>The number of bands that the output raster dataset will have.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfBands { get; set; } = "1";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Specifies the storage parameters (configuration) for a file or enterprise geodatabase. Configuration keywords are set up by your database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Settings (optional)")]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Create pyramids</para>
		/// <para>Creates pyramids.</para>
		/// <para>For Pyramid Levels, specify a number of -1 or higher. A value of 0 will not build any pyramids, and a value of -1 will automatically determine the correct number of pyramid layers to create.</para>
		/// <para>The Pyramid Resampling Technique defines how the data will be resampled when building the pyramids.</para>
		/// <para>NEAREST—Nearest neighbor should be used for nominal data or raster datasets with color maps, such as land-use or pseudo color images.</para>
		/// <para>BILINEAR—Bilinear interpolation is best used with continuous data, such as satellite imagery or aerial photography.</para>
		/// <para>CUBIC—Cubic convolution is best used with continuous data, such as satellite imagery or aerial photography. It is similar to bilinear interpolation; however, it resamples the data using a larger matrix.</para>
		/// <para>The Pyramid Compression Type defines the method used when compressing the pyramids.</para>
		/// <para>DEFAULT—This uses the compression that is normally used by the raster dataset format.</para>
		/// <para>LZ77—A lossless compression. The values of the cells in the raster will not be changed.</para>
		/// <para>JPEG—A lossy compression.</para>
		/// <para>NONE—No data compression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvPyramid()]
		[Category("Geodatabase Settings (optional)")]
		public object Pyramids { get; set; } = "PYRAMIDS -1 NEAREST DEFAULT 75 NO_SKIP NO_SIPS";

		/// <summary>
		/// <para>Tile size</para>
		/// <para>Specifies the size of the tiles.</para>
		/// <para>The tile width controls the number of pixels you can store in each tile. This is specified as a number of pixels in x. The default tile width is 128.</para>
		/// <para>The tile height controls the number of pixels you can store in each tile. This is specified as a number of pixels in y. The default tile height is 128.</para>
		/// <para>Only geodatabases and enterprise geodatabases use tile size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvTileSize()]
		[Category("Geodatabase Settings (optional)")]
		public object TileSize { get; set; } = "128 128";

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies the type of compression to store the raster dataset.</para>
		/// <para>LZ77—Lossless compression that preserves all raster cell values.</para>
		/// <para>Jpeg—Lossy compression that uses the public JPEG compression algorithm. If you choose JPEG, you can also specify the compression quality. The valid compression quality value ranges are from 0 to 100. This compression can be used for JPEG files and TIFF files.</para>
		/// <para>Jpeg 2000—Lossy compression.</para>
		/// <para>Packbits—PackBits compression for TIFF files.</para>
		/// <para>Lzw—Lossless compression that preserves all raster cell values.</para>
		/// <para>Rle—Run-length encoding for IMG files.</para>
		/// <para>Ccitt Group 3—Lossless compression for 1-bit data.</para>
		/// <para>Ccitt Group 4—Lossless compression for 1-bit data.</para>
		/// <para>Ccitt 1D—Lossless compression for 1-bit data.</para>
		/// <para>None—No compression will occur. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGDBEnvCompression()]
		[Category("Geodatabase Settings (optional)")]
		public object Compression { get; set; } = "LZ77";

		/// <summary>
		/// <para>Pyramid Reference Point</para>
		/// <para>The origination location of the raster pyramid. It is recommended that you specify this point if you plan on building large mosaics in a file geodatabase or enterprise geodatabase, especially if you plan on mosaicking to them over time (for example, for updating).</para>
		/// <para>The pyramid reference point should be set to the upper left corner of your raster dataset.</para>
		/// <para>In setting this point for a file geodatabase or enterprise geodatabase, partial pyramiding will be used when updating with a new mosaicked raster dataset. Partial pyramiding updated the parts of the pyramid that do not exist due to the new mosaicked datasets. Therefore, it is good practice to set your pyramid reference point so that your entire raster mosaic will be below and to the right of this point. However, a pyramid reference point should not be set too large either.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Geodatabase Settings (optional)")]
		public object PyramidOrigin { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRasterDataset SetEnviroment(object compression = null , object configKeyword = null , object pyramid = null , double[] tileSize = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, pyramid: pyramid, tileSize: tileSize);
			return this;
		}

	}
}
