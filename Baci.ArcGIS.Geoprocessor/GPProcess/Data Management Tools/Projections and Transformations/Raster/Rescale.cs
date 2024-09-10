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
	/// <para>Rescale</para>
	/// <para>Resizes a raster by the specified x and y scale factors.</para>
	/// </summary>
	public class Rescale : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset.</para>
		/// <para>When storing the raster dataset in a file format, you need to specify the file extension:</para>
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
		/// <para>When storing a raster dataset in a geodatabase, no file extension should be added to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </param>
		/// <param name="XScale">
		/// <para>X Scale Factor</para>
		/// <para>The factor by which to scale the cell size in the x direction.</para>
		/// <para>The factor must be greater than zero.</para>
		/// </param>
		/// <param name="YScale">
		/// <para>Y Scale Factor</para>
		/// <para>The factor by which to scale the cell size in the y direction.</para>
		/// <para>The factor must be greater than zero.</para>
		/// </param>
		public Rescale(object InRaster, object OutRaster, object XScale, object YScale)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.XScale = XScale;
			this.YScale = YScale;
		}

		/// <summary>
		/// <para>Tool Display Name : Rescale</para>
		/// </summary>
		public override string DisplayName() => "Rescale";

		/// <summary>
		/// <para>Tool Name : Rescale</para>
		/// </summary>
		public override string ToolName() => "Rescale";

		/// <summary>
		/// <para>Tool Excute Name : management.Rescale</para>
		/// </summary>
		public override string ExcuteName() => "management.Rescale";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, XScale, YScale };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The output raster dataset.</para>
		/// <para>When storing the raster dataset in a file format, you need to specify the file extension:</para>
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
		/// <para>When storing a raster dataset in a geodatabase, no file extension should be added to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>X Scale Factor</para>
		/// <para>The factor by which to scale the cell size in the x direction.</para>
		/// <para>The factor must be greater than zero.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object XScale { get; set; }

		/// <summary>
		/// <para>Y Scale Factor</para>
		/// <para>The factor by which to scale the cell size in the y direction.</para>
		/// <para>The factor must be greater than zero.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object YScale { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Rescale SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
