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
	/// <para>Create Pansharpened Raster Dataset</para>
	/// <para>Create Pansharpened Raster Dataset</para>
	/// <para>Combines a high-resolution panchromatic raster dataset with a lower-resolution multiband raster dataset to create a high-resolution multiband  raster dataset for visual analysis.</para>
	/// </summary>
	public class CreatePansharpenedRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset that you want to pan sharpen.</para>
		/// </param>
		/// <param name="RedChannel">
		/// <para>Red Channel</para>
		/// <para>The input raster band that you want to display with the red color channel.</para>
		/// </param>
		/// <param name="GreenChannel">
		/// <para>Green Channel</para>
		/// <para>The input raster band that you want to display with the green color channel.</para>
		/// </param>
		/// <param name="BlueChannel">
		/// <para>Blue Channel</para>
		/// <para>The input raster band that you want to display with the blue color channel.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating.</para>
		/// <para>When storing the raster dataset in a file format, you need to specify the file extension:</para>
		/// <para>When storing a raster dataset in a geodatabase, no file extension should be added to the name of the raster dataset. When storing the raster dataset in a file format, you need to specify the file extension:</para>
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
		/// <para>.mrf for MRF</para>
		/// <para>.crf for CRF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </param>
		/// <param name="InPanchromaticImage">
		/// <para>Panchromatic Image</para>
		/// <para>The higher-resolution panchromatic image.</para>
		/// </param>
		/// <param name="PansharpeningType">
		/// <para>Pan-sharpening Type</para>
		/// <para>The algorithm to fuse the panchromatic and multispectral bands together.</para>
		/// <para>IHS—Uses Intensity, Hue, and Saturation color space for data fusion.</para>
		/// <para>Brovey—Uses the Brovey algorithm based on spectral modeling for data fusion.</para>
		/// <para>Esri—Uses the Esri algorithm based on spectral modeling for data fusion.</para>
		/// <para>Simple mean—Uses the averaged value between the red, green, and blue values and the panchromatic pixel value.</para>
		/// <para>Gram-Schmidt—Uses the Gram-Schmidt spectral-sharpening algorithm to sharpen multispectral data.</para>
		/// <para><see cref="PansharpeningTypeEnum"/></para>
		/// </param>
		public CreatePansharpenedRasterDataset(object InRaster, object RedChannel, object GreenChannel, object BlueChannel, object OutRasterDataset, object InPanchromaticImage, object PansharpeningType)
		{
			this.InRaster = InRaster;
			this.RedChannel = RedChannel;
			this.GreenChannel = GreenChannel;
			this.BlueChannel = BlueChannel;
			this.OutRasterDataset = OutRasterDataset;
			this.InPanchromaticImage = InPanchromaticImage;
			this.PansharpeningType = PansharpeningType;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Pansharpened Raster Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Pansharpened Raster Dataset";

		/// <summary>
		/// <para>Tool Name : CreatePansharpenedRasterDataset</para>
		/// </summary>
		public override string ToolName() => "CreatePansharpenedRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreatePansharpenedRasterDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreatePansharpenedRasterDataset";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, RedChannel, GreenChannel, BlueChannel, InfraredChannel, OutRasterDataset, InPanchromaticImage, PansharpeningType, RedWeight, GreenWeight, BlueWeight, InfraredWeight, Sensor };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset that you want to pan sharpen.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Red Channel</para>
		/// <para>The input raster band that you want to display with the red color channel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object RedChannel { get; set; } = "3";

		/// <summary>
		/// <para>Green Channel</para>
		/// <para>The input raster band that you want to display with the green color channel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object GreenChannel { get; set; } = "2";

		/// <summary>
		/// <para>Blue Channel</para>
		/// <para>The input raster band that you want to display with the blue color channel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object BlueChannel { get; set; } = "1";

		/// <summary>
		/// <para>Infrared Channel</para>
		/// <para>The input raster band that you want to display with the infrared color channel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object InfraredChannel { get; set; } = "1";

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating.</para>
		/// <para>When storing the raster dataset in a file format, you need to specify the file extension:</para>
		/// <para>When storing a raster dataset in a geodatabase, no file extension should be added to the name of the raster dataset. When storing the raster dataset in a file format, you need to specify the file extension:</para>
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
		/// <para>.mrf for MRF</para>
		/// <para>.crf for CRF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Panchromatic Image</para>
		/// <para>The higher-resolution panchromatic image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InPanchromaticImage { get; set; }

		/// <summary>
		/// <para>Pan-sharpening Type</para>
		/// <para>The algorithm to fuse the panchromatic and multispectral bands together.</para>
		/// <para>IHS—Uses Intensity, Hue, and Saturation color space for data fusion.</para>
		/// <para>Brovey—Uses the Brovey algorithm based on spectral modeling for data fusion.</para>
		/// <para>Esri—Uses the Esri algorithm based on spectral modeling for data fusion.</para>
		/// <para>Simple mean—Uses the averaged value between the red, green, and blue values and the panchromatic pixel value.</para>
		/// <para>Gram-Schmidt—Uses the Gram-Schmidt spectral-sharpening algorithm to sharpen multispectral data.</para>
		/// <para><see cref="PansharpeningTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PansharpeningType { get; set; } = "Esri";

		/// <summary>
		/// <para>Red Weight</para>
		/// <para>A value from 0 to 1 to weight the red band.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RedWeight { get; set; } = "0.166";

		/// <summary>
		/// <para>Green Weight</para>
		/// <para>A value from 0 to 1 to weight the green band.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object GreenWeight { get; set; } = "0.167";

		/// <summary>
		/// <para>Blue Weight</para>
		/// <para>A value from 0 to 1 to weight the blue band.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BlueWeight { get; set; } = "0.167";

		/// <summary>
		/// <para>Infrared Weight</para>
		/// <para>A value from 0 to 1 to weight the infrared band.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object InfraredWeight { get; set; } = "0.5";

		/// <summary>
		/// <para>Sensor</para>
		/// <para>When the Gram-Schmidt pan-sharpening method is chosen, you can also specify the sensor of the multiband raster input. Choosing the sensor type will set appropriate band weights.</para>
		/// <para>Unknown—An unknown or unlisted sensor</para>
		/// <para>DubaiSat-2—The DubaiSat-2 satellite sensor</para>
		/// <para>GeoEye-1—The GeoEye-1 and OrbView-3 satellite sensors</para>
		/// <para>GF-1 PMS—The Gao Fen satellite 1, Panchromatic and Multispectral CCD Camera</para>
		/// <para>GF-2 PMS—The Gao Fen 2 satellite, Panchromatic and Multispectral CCD Camera</para>
		/// <para>IKONOS—The IKONOS satellite sensor</para>
		/// <para>Jilin-1—The Jilin-1 satellite sensor</para>
		/// <para>KOMPSAT-2—The KOMPSAT-2 satellite sensor</para>
		/// <para>KOMPSAT-3—The KOMPSAT-3 satellite sensor</para>
		/// <para>Landsat 1-5 MSS—The Landsat MSS satellite sensors</para>
		/// <para>Landsat 7 ETM+—The Landsat 7 satellite sensor</para>
		/// <para>Landsat 8—The Landsat 8 satellite sensor</para>
		/// <para>Pleiades-1—The Pleiades-1 satellite sensor</para>
		/// <para>Quickbird—The QuickBird satellite sensor</para>
		/// <para>SkySat-C—The SkySat-C satellite sensor</para>
		/// <para>SPOT 5—The SPOT 5 satellite sensor</para>
		/// <para>SPOT 6—The SPOT 6 satellite sensor</para>
		/// <para>SPOT 7—The SPOT 7 satellite sensor</para>
		/// <para>Tian Hui 1—The Tian Hui 1 satellite sensor</para>
		/// <para>Ultracam—The UltraCam aerial sensor</para>
		/// <para>WorldView-2—The WorldView-2 satellite sensor</para>
		/// <para>WorldView-3—The WorldView-3 satellite sensor</para>
		/// <para>WorldView-4—The WorldView-4 satellite sensor</para>
		/// <para>ZY-1 PMS—The Ziyuan High Panchromatic Multispectral Sensor</para>
		/// <para>ZY-3 CRESDA—The Ziyuan CRESDA satellite sensor</para>
		/// <para>ZY-3 SASMAC—The Ziyuan SASMAC satellite sensor</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Sensor { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreatePansharpenedRasterDataset SetEnviroment(object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Pan-sharpening Type</para>
		/// </summary>
		public enum PansharpeningTypeEnum 
		{
			/// <summary>
			/// <para>IHS—Uses Intensity, Hue, and Saturation color space for data fusion.</para>
			/// </summary>
			[GPValue("IHS")]
			[Description("IHS")]
			IHS,

			/// <summary>
			/// <para>Brovey—Uses the Brovey algorithm based on spectral modeling for data fusion.</para>
			/// </summary>
			[GPValue("BROVEY")]
			[Description("Brovey")]
			Brovey,

			/// <summary>
			/// <para>Esri—Uses the Esri algorithm based on spectral modeling for data fusion.</para>
			/// </summary>
			[GPValue("Esri")]
			[Description("Esri")]
			Esri,

			/// <summary>
			/// <para>Simple mean—Uses the averaged value between the red, green, and blue values and the panchromatic pixel value.</para>
			/// </summary>
			[GPValue("SIMPLE_MEAN")]
			[Description("Simple mean")]
			Simple_mean,

			/// <summary>
			/// <para>Gram-Schmidt—Uses the Gram-Schmidt spectral-sharpening algorithm to sharpen multispectral data.</para>
			/// </summary>
			[GPValue("Gram-Schmidt")]
			[Description("Gram-Schmidt")]
			Gram_Schmidt,

		}

#endregion
	}
}
