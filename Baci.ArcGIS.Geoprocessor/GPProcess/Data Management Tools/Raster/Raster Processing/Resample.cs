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
	/// <para>Resample</para>
	/// <para>Resample</para>
	/// <para>Changes the spatial resolution of a raster dataset and sets rules for aggregating or interpolating values across the new pixel sizes.</para>
	/// </summary>
	public class Resample : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset with the spatial resolution to be changed.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format of the dataset being created.</para>
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
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing a raster dataset to JPEG, JPEG 2000, or TIFF format, or in a geodatabase, you can specify a compression type and compression quality.</para>
		/// </param>
		public Resample(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Resample</para>
		/// </summary>
		public override string DisplayName() => "Resample";

		/// <summary>
		/// <para>Tool Name : Resample</para>
		/// </summary>
		public override string ToolName() => "Resample";

		/// <summary>
		/// <para>Tool Excute Name : management.Resample</para>
		/// </summary>
		public override string ExcuteName() => "management.Resample";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, CellSize, ResamplingType };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset with the spatial resolution to be changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format of the dataset being created.</para>
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
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing a raster dataset to JPEG, JPEG 2000, or TIFF format, or in a geodatabase, you can specify a compression type and compression quality.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>The cell size of the new raster using an existing raster dataset or by specifying its width (x) and height (y).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCellSizeXY()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>Specifies the resampling technique to be used.</para>
		/// <para>Nearest— Nearest neighbor is the fastest resampling method; it minimizes changes to pixel values since no new values are created. It is suitable for discrete data, such as land cover.</para>
		/// <para>Bilinear— Bilinear interpolation calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding four pixels. It is suitable for continuous data.</para>
		/// <para>Cubic— Cubic convolution calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. This produces the smoothest image but can create values outside of the range found in the source data. It is suitable for continuous data.</para>
		/// <para>Majority—Majority resampling determines the value of each pixel based on the most popular value in a 3 by 3 window. Suitable for discrete data.</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Resample SetEnviroment(object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>Nearest— Nearest neighbor is the fastest resampling method; it minimizes changes to pixel values since no new values are created. It is suitable for discrete data, such as land cover.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Bilinear— Bilinear interpolation calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding four pixels. It is suitable for continuous data.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic— Cubic convolution calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. This produces the smoothest image but can create values outside of the range found in the source data. It is suitable for continuous data.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

			/// <summary>
			/// <para>Majority—Majority resampling determines the value of each pixel based on the most popular value in a 3 by 3 window. Suitable for discrete data.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

		}

#endregion
	}
}
