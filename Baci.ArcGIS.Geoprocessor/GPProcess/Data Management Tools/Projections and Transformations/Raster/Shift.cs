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
	/// <para>Shift</para>
	/// <para>Shift</para>
	/// <para>Moves (slides) the raster to a new geographic location based on x and y shift values. This tool is helpful if your raster dataset needs to be shifted to align with another data file.</para>
	/// </summary>
	public class Shift : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster dataset.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset.</para>
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
		/// <para>.mrf—MRF</para>
		/// <para>.crf—CRF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG format file, a JPEG 2000 format file, a TIFF format file, or a geodatabase, you can specify Compression Type and Compression Quality values in the geoprocessing environments.</para>
		/// </param>
		/// <param name="XValue">
		/// <para>Shift X Coordinates by</para>
		/// <para>The value used to shift the x-coordinates.</para>
		/// </param>
		/// <param name="YValue">
		/// <para>Shift Y Coordinates by</para>
		/// <para>The value used to shift the y-coordinates.</para>
		/// </param>
		public Shift(object InRaster, object OutRaster, object XValue, object YValue)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.XValue = XValue;
			this.YValue = YValue;
		}

		/// <summary>
		/// <para>Tool Display Name : Shift</para>
		/// </summary>
		public override string DisplayName() => "Shift";

		/// <summary>
		/// <para>Tool Name : Shift</para>
		/// </summary>
		public override string ToolName() => "Shift";

		/// <summary>
		/// <para>Tool Excute Name : management.Shift</para>
		/// </summary>
		public override string ExcuteName() => "management.Shift";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, XValue, YValue, InSnapRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset.</para>
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
		/// <para>.mrf—MRF</para>
		/// <para>.crf—CRF</para>
		/// <para>No extension for Esri Grid</para>
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing a raster dataset to a JPEG format file, a JPEG 2000 format file, a TIFF format file, or a geodatabase, you can specify Compression Type and Compression Quality values in the geoprocessing environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Shift X Coordinates by</para>
		/// <para>The value used to shift the x-coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object XValue { get; set; }

		/// <summary>
		/// <para>Shift Y Coordinates by</para>
		/// <para>The value used to shift the y-coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object YValue { get; set; }

		/// <summary>
		/// <para>Input Snap Raster</para>
		/// <para>The raster dataset used to align the cells of the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		public object? InSnapRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Shift SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
