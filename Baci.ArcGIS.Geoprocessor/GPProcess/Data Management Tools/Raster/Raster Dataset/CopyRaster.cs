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
	/// <para>Copy Raster</para>
	/// <para>Saves a copy of a raster dataset or converts a mosaic dataset into a single raster dataset.</para>
	/// </summary>
	public class CopyRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset or mosaic dataset to be copied.</para>
		/// </param>
		/// <param name="OutRasterdataset">
		/// <para>Output Raster Dataset</para>
		/// <para>The name and format for the raster dataset being created.</para>
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
		/// <para>.mrf—MRF</para>
		/// <para>.crf—CRF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG file, JPEG 2000 file, TIFF file, or geodatabase, you can specify a compression type and compression quality.</para>
		/// </param>
		public CopyRaster(object InRaster, object OutRasterdataset)
		{
			this.InRaster = InRaster;
			this.OutRasterdataset = OutRasterdataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Raster</para>
		/// </summary>
		public override string DisplayName => "Copy Raster";

		/// <summary>
		/// <para>Tool Name : CopyRaster</para>
		/// </summary>
		public override string ToolName => "CopyRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.CopyRaster</para>
		/// </summary>
		public override string ExcuteName => "management.CopyRaster";

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
		public override string[] ValidEnvironments => new string[] { "cellAlignment", "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRasterdataset, ConfigKeyword, BackgroundValue, NodataValue, OnebitToEightbit, ColormapToRGB, PixelType, ScalePixelValue, RGBToColormap, Format, Transform, ProcessAsMultidimensional, BuildMultidimensionalTranspose };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset or mosaic dataset to be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name and format for the raster dataset being created.</para>
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
		/// <para>.mrf—MRF</para>
		/// <para>.crf—CRF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG file, JPEG 2000 file, TIFF file, or geodatabase, you can specify a compression type and compression quality.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRasterdataset { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Specifies the storage parameters (configuration) for a geodatabase. Configuration keywords are set up by your database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Ignore Background Value</para>
		/// <para>Remove the unwanted values created around the raster data. The value specified will be distinguished from other valuable data in the raster dataset. For example, a value of zero along the raster dataset&apos;s borders will be distinguished from zero values in the raster dataset.</para>
		/// <para>The pixel value specified will be set to NoData in the output raster dataset.</para>
		/// <para>For file-based rasters, Ignore Background Value must be set to the same value as NoData for the background value to be ignored. Enterprise and geodatabase rasters will work without this extra step.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BackgroundValue { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>All the pixels with the specified value will be set to NoData in the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// <para>Choose whether the input 1-bit raster dataset will be converted to an 8-bit raster dataset. In this conversion, the value 1 in the input raster dataset will be changed to 255 in the output raster dataset. This is useful when importing a 1-bit raster dataset to a geodatabase. One-bit raster datasets have 8-bit pyramid layers when stored in a file system, but in a geodatabase, 1-bit raster datasets can only have 1-bit pyramid layers, which makes the display unpleasant. By converting the data to 8 bit in a geodatabase, the pyramid layers are built as 8 bit instead of 1 bit, resulting in a proper raster dataset in the display.</para>
		/// <para>Unchecked—No conversion will be done. This is the default.</para>
		/// <para>Checked—The input raster will be converted.</para>
		/// <para><see cref="OnebitToEightbitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OnebitToEightbit { get; set; } = "false";

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// <para>If the input raster dataset has a color map, the output raster dataset can be converted to a three-band output raster dataset. This is useful when mosaicking rasters with different color maps.</para>
		/// <para>Unchecked—No conversion will occur. This is the default.</para>
		/// <para>Checked—The input dataset will be converted.</para>
		/// <para><see cref="ColormapToRGBEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ColormapToRGB { get; set; } = "false";

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>Specifies the bit depth, or radiometric resolution, to use for the raster or mosaic dataset. If not defined, the value will be taken from the first raster dataset.</para>
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
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PixelType { get; set; }

		/// <summary>
		/// <para>Scale Pixel Value</para>
		/// <para>Specifies whether pixel values will be scaled. When the output is a pixel type other than the input (such as 16 bit to 8 bit), you can scale the values to fit into the new range; otherwise, the values that do not fit into the new pixel range will be discarded.</para>
		/// <para>If scaling up, such as 8 bit to 16 bit, the minimum and maximum of the 8-bit values will be scaled to the minimum and maximum in the 16-bit range. If scaling down, such as 16 bit to 8 bit, the minimum and maximum of the 16-bit values will be scaled to the minimum and maximum in the 8-bit range.</para>
		/// <para>Unchecked—The pixel values will remain the same and will not be scaled. Any values that do not fit within the value range will be discarded. This is the default.</para>
		/// <para>Checked—The pixel values will be scaled to the new pixel type. When you scale the pixel depth, your raster will display the same, but the values will be scaled to the new bit depth that was specified.</para>
		/// <para><see cref="ScalePixelValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ScalePixelValue { get; set; } = "false";

		/// <summary>
		/// <para>RGB To Colormap</para>
		/// <para>Specifies whether an 8-bit, 3-band (RGB) raster dataset will be converted to a single-band raster dataset with a color map. This operation suppresses noise that is often found in scanned images and is ideal for screen captures, scanned maps, or scanned documents. This is not recommended for satellite or aerial imagery or thematic raster data.</para>
		/// <para>Unchecked—The RGB raster dataset will not be converted.</para>
		/// <para>Checked—The RGB raster dataset will be converted to a color map.</para>
		/// <para><see cref="RGBToColormapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RGBToColormap { get; set; } = "false";

		/// <summary>
		/// <para>Format</para>
		/// <para>Specifies the output raster format.</para>
		/// <para>TIFF format—The output format will be TIFF.</para>
		/// <para>Cloud Optimized GeoTIFF—The output format will be Cloud Optimized GeoTIFF.</para>
		/// <para>ERDAS IMAGINE format—The output format will be ERDAS IMAGINE.</para>
		/// <para>BMP format—The output format will e BMP.</para>
		/// <para>GIF format—The output format will be GIF.</para>
		/// <para>PNG format—The output format will be PNG.</para>
		/// <para>JPEG format—The output format will be JPEG.</para>
		/// <para>JPEG 2000 format—The output format will be JPEG 2000.</para>
		/// <para>Esri Grid format—The output format will be Esri Grid.</para>
		/// <para>Esri BIL format—The output format will be Esri BIL.</para>
		/// <para>Esri BSQ format—The output format will be Esri BSQ.</para>
		/// <para>Esri BIP format—The output format will be Esri BIP.</para>
		/// <para>ENVI DAT format—The output format will be ENVI.</para>
		/// <para>Cloud raster format—The output format will be CRF.</para>
		/// <para>Meta raster format—The output format will be MRF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; }

		/// <summary>
		/// <para>Apply Transformation</para>
		/// <para>Specifies whether a transformation associated with the input raster will be applied to the output. The input raster can have a transformation associated with it that is not saved in the input, such as a world file or a geometric function.</para>
		/// <para>Unchecked—No associated transformation will be applied to the output.</para>
		/// <para>Checked—Any associated transformation will be applied to the output.</para>
		/// <para><see cref="TransformEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Transform { get; set; } = "false";

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>Specifies whether to process the input mosaic dataset as a multidimensional raster dataset.</para>
		/// <para>Unchecked—The input will not be processed as a multidimensional raster dataset. If the input is multidimensional, only the slice that is currently displayed will be processed. This is the default.</para>
		/// <para>Checked—The input will be processed as a multidimensional raster dataset and all slices will be processed to produce a new multidimensional raster dataset. The output Format must be set to Cloud raster format to use this option.</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Build Multidimensional Transpose</para>
		/// <para>Specifies whether to build the transpose for the input multidimensional raster dataset to optimize data access. The transpose will chunk the multidimensional data along each dimension to optimize performance when accessing pixel values across all slices.</para>
		/// <para>Unchecked—No transpose will be built. This is the default.</para>
		/// <para>Checked—The input multidimensional raster dataset will be transposed. Process as multidimensional must be checked on to use this option.</para>
		/// <para><see cref="BuildMultidimensionalTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildMultidimensionalTranspose { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyRaster SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// </summary>
		public enum OnebitToEightbitEnum 
		{
			/// <summary>
			/// <para>Checked—The input raster will be converted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OneBitTo8Bit")]
			OneBitTo8Bit,

			/// <summary>
			/// <para>Unchecked—No conversion will be done. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// </summary>
		public enum ColormapToRGBEnum 
		{
			/// <summary>
			/// <para>Checked—The input dataset will be converted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ColormapToRGB")]
			ColormapToRGB,

			/// <summary>
			/// <para>Unchecked—No conversion will occur. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Scale Pixel Value</para>
		/// </summary>
		public enum ScalePixelValueEnum 
		{
			/// <summary>
			/// <para>Checked—The pixel values will be scaled to the new pixel type. When you scale the pixel depth, your raster will display the same, but the values will be scaled to the new bit depth that was specified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ScalePixelValue")]
			ScalePixelValue,

			/// <summary>
			/// <para>Unchecked—The pixel values will remain the same and will not be scaled. Any values that do not fit within the value range will be discarded. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>RGB To Colormap</para>
		/// </summary>
		public enum RGBToColormapEnum 
		{
			/// <summary>
			/// <para>Checked—The RGB raster dataset will be converted to a color map.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RGBToColormap")]
			RGBToColormap,

			/// <summary>
			/// <para>Unchecked—The RGB raster dataset will not be converted.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Apply Transformation</para>
		/// </summary>
		public enum TransformEnum 
		{
			/// <summary>
			/// <para>Checked—Any associated transformation will be applied to the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Transform")]
			Transform,

			/// <summary>
			/// <para>Unchecked—No associated transformation will be applied to the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para>Checked—The input will be processed as a multidimensional raster dataset and all slices will be processed to produce a new multidimensional raster dataset. The output Format must be set to Cloud raster format to use this option.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

			/// <summary>
			/// <para>Unchecked—The input will not be processed as a multidimensional raster dataset. If the input is multidimensional, only the slice that is currently displayed will be processed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

		}

		/// <summary>
		/// <para>Build Multidimensional Transpose</para>
		/// </summary>
		public enum BuildMultidimensionalTransposeEnum 
		{
			/// <summary>
			/// <para>Checked—The input multidimensional raster dataset will be transposed. Process as multidimensional must be checked on to use this option.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRANSPOSE")]
			TRANSPOSE,

			/// <summary>
			/// <para>Unchecked—No transpose will be built. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRANSPOSE")]
			NO_TRANSPOSE,

		}

#endregion
	}
}
