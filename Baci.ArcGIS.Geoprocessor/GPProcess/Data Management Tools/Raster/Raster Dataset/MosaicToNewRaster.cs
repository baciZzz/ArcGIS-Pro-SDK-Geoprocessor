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
	/// <para>Mosaic To New Raster</para>
	/// <para>Mosaic To New Raster</para>
	/// <para>Merges multiple raster datasets into a new raster dataset.</para>
	/// </summary>
	public class MosaicToNewRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasters">
		/// <para>Input Rasters</para>
		/// <para>The raster datasets that you want to merge together. The inputs must have the same number of bands and same bit depth.</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase to store the raster.</para>
		/// </param>
		/// <param name="RasterDatasetNameWithExtension">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name of the dataset you are creating.</para>
		/// <para>When storing the raster dataset in a file format, specify the file extension as follows:</para>
		/// <para>.bil—Esri BIL</para>
		/// <para>.bip—Esri BIP</para>
		/// <para>.bmp—BMP</para>
		/// <para>.bsq—Esri BSQ</para>
		/// <para>.dat—ENVI DAT</para>
		/// <para>.gif—GIF</para>
		/// <para>.img—ERDAS IMAGINE</para>
		/// <para>.jpg—JPEG</para>
		/// <para>.jp2—JPEG 2000</para>
		/// <para>.png—PNG</para>
		/// <para>.tif—TIFF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG format file, a JPEG 2000 format file, a TIFF format file, or a geodatabase, you can specify Compression Type and Compression Quality values in the geoprocessing environments.</para>
		/// </param>
		/// <param name="NumberOfBands">
		/// <para>Number of Bands</para>
		/// <para>The number of bands that the output raster will have.</para>
		/// </param>
		public MosaicToNewRaster(object InputRasters, object OutputLocation, object RasterDatasetNameWithExtension, object NumberOfBands)
		{
			this.InputRasters = InputRasters;
			this.OutputLocation = OutputLocation;
			this.RasterDatasetNameWithExtension = RasterDatasetNameWithExtension;
			this.NumberOfBands = NumberOfBands;
		}

		/// <summary>
		/// <para>Tool Display Name : Mosaic To New Raster</para>
		/// </summary>
		public override string DisplayName() => "Mosaic To New Raster";

		/// <summary>
		/// <para>Tool Name : MosaicToNewRaster</para>
		/// </summary>
		public override string ToolName() => "MosaicToNewRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.MosaicToNewRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.MosaicToNewRaster";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "nodata", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasters, OutputLocation, RasterDatasetNameWithExtension, CoordinateSystemForTheRaster!, PixelType!, Cellsize!, NumberOfBands, MosaicMethod!, MosaicColormapMode!, OutputRasterDataset! };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The raster datasets that you want to merge together. The inputs must have the same number of bands and same bit depth.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasters { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase to store the raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name of the dataset you are creating.</para>
		/// <para>When storing the raster dataset in a file format, specify the file extension as follows:</para>
		/// <para>.bil—Esri BIL</para>
		/// <para>.bip—Esri BIP</para>
		/// <para>.bmp—BMP</para>
		/// <para>.bsq—Esri BSQ</para>
		/// <para>.dat—ENVI DAT</para>
		/// <para>.gif—GIF</para>
		/// <para>.img—ERDAS IMAGINE</para>
		/// <para>.jpg—JPEG</para>
		/// <para>.jp2—JPEG 2000</para>
		/// <para>.png—PNG</para>
		/// <para>.tif—TIFF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG format file, a JPEG 2000 format file, a TIFF format file, or a geodatabase, you can specify Compression Type and Compression Quality values in the geoprocessing environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RasterDatasetNameWithExtension { get; set; }

		/// <summary>
		/// <para>Spatial Reference for  Raster</para>
		/// <para>The coordinate system for the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystemForTheRaster { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>The bit depth, or radiometric resolution of the mosaic dataset.</para>
		/// <para>If you do not set the pixel type, the 8-bit default will be used and your output may be incorrect.</para>
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
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PixelType { get; set; } = "8_BIT_UNSIGNED";

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The pixel size that will be used for the new raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>The number of bands that the output raster will have.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfBands { get; set; }

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>The method used to mosaic overlapping areas.</para>
		/// <para>First—The output cell value of the overlapping areas will be the value from the first raster dataset mosaicked into that location.</para>
		/// <para>Last—The output cell value of the overlapping areas will be the value from the last raster dataset mosaicked into that location. This is the default.</para>
		/// <para>Blend—The output cell value of the overlapping areas will be a horizontally weighted calculation of the values of the cells in the overlapping area.</para>
		/// <para>Mean—The output cell value of the overlapping areas will be the average value of the overlapping cells.</para>
		/// <para>Minimum—The output cell value of the overlapping areas will be the minimum value of the overlapping cells.</para>
		/// <para>Maximum—The output cell value of the overlapping areas will be the maximum value of the overlapping cells.</para>
		/// <para>Sum—The output cell value of the overlapping areas will be the total sum of the overlapping cells.</para>
		/// <para>For more information about each mosaic operator, refer to the Mosaic Operator help topic.</para>
		/// <para><see cref="MosaicMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MosaicMethod { get; set; } = "LAST";

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// <para>Applies when the input raster datasets have a colormap.</para>
		/// <para>Specifies the method that will be used to choose which color map from the input rasters will be applied to the mosaic output.</para>
		/// <para>First—The color map from the first raster dataset in the list will be applied to the output raster mosaic. This is the default.</para>
		/// <para>Last—The color map from the last raster dataset in the list will be applied to the output raster mosaic.</para>
		/// <para>Match—All the color maps will be considered when mosaicking. If all possible values are already used (for the bit depth), the tool will match the value with the closest available color.</para>
		/// <para>Reject—Only the raster datasets that do not have a color map associated with them will be mosaicked.</para>
		/// <para>For more information about each colormap mode, see the Mosaic colormap mode help topic.</para>
		/// <para><see cref="MosaicColormapModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MosaicColormapMode { get; set; } = "FIRST";

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutputRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MosaicToNewRaster SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? nodata = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? tileSize = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, nodata: nodata, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// </summary>
		public enum MosaicMethodEnum 
		{
			/// <summary>
			/// <para>First—The output cell value of the overlapping areas will be the value from the first raster dataset mosaicked into that location.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The output cell value of the overlapping areas will be the value from the last raster dataset mosaicked into that location. This is the default.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Blend—The output cell value of the overlapping areas will be a horizontally weighted calculation of the values of the cells in the overlapping area.</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("Blend")]
			Blend,

			/// <summary>
			/// <para>Mean—The output cell value of the overlapping areas will be the average value of the overlapping cells.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Minimum—The output cell value of the overlapping areas will be the minimum value of the overlapping cells.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The output cell value of the overlapping areas will be the maximum value of the overlapping cells.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Sum—The output cell value of the overlapping areas will be the total sum of the overlapping cells.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

		}

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// </summary>
		public enum MosaicColormapModeEnum 
		{
			/// <summary>
			/// <para>Reject—Only the raster datasets that do not have a color map associated with them will be mosaicked.</para>
			/// </summary>
			[GPValue("REJECT")]
			[Description("Reject")]
			Reject,

			/// <summary>
			/// <para>First—The color map from the first raster dataset in the list will be applied to the output raster mosaic. This is the default.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The color map from the last raster dataset in the list will be applied to the output raster mosaic.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Match—All the color maps will be considered when mosaicking. If all possible values are already used (for the bit depth), the tool will match the value with the closest available color.</para>
			/// </summary>
			[GPValue("MATCH")]
			[Description("Match")]
			Match,

		}

#endregion
	}
}
