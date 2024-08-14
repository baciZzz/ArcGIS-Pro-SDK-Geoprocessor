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
	/// <para>Create Ortho Corrected Raster Dataset</para>
	/// <para>Creates an orthocorrected raster dataset by incorporating  elevation data and the rational polynomial coefficients (RPC) associated with satellite data  to accurately line up imagery.</para>
	/// </summary>
	public class CreateOrthoCorrectedRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to orthorectify. The raster must have RPCs in its metadata.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format of the dataset to be created.</para>
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
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, or a geodatabase, you can specify a Compression Type and Compression Quality in the Environments.</para>
		/// </param>
		/// <param name="OrthoType">
		/// <para>Orthorectification Type</para>
		/// <para>The DEM or specified value that represents the average elevation across the image.</para>
		/// <para>Constant elevation—A specified elevation value will be used.</para>
		/// <para>DEM—A specified digital elevation model raster will be used.</para>
		/// <para><see cref="OrthoTypeEnum"/></para>
		/// </param>
		/// <param name="ConstantElevation">
		/// <para>Constant Elevation (Meters)</para>
		/// <para>The constant elevation value to be used when the Orthorectification Type parameter is Constant elevation.</para>
		/// <para>If a DEM is used in the orthocorrection process, this value is not used.</para>
		/// </param>
		public CreateOrthoCorrectedRasterDataset(object InRaster, object OutRasterDataset, object OrthoType, object ConstantElevation)
		{
			this.InRaster = InRaster;
			this.OutRasterDataset = OutRasterDataset;
			this.OrthoType = OrthoType;
			this.ConstantElevation = ConstantElevation;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Ortho Corrected Raster Dataset</para>
		/// </summary>
		public override string DisplayName => "Create Ortho Corrected Raster Dataset";

		/// <summary>
		/// <para>Tool Name : CreateOrthoCorrectedRasterDataset</para>
		/// </summary>
		public override string ToolName => "CreateOrthoCorrectedRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateOrthoCorrectedRasterDataset</para>
		/// </summary>
		public override string ExcuteName => "management.CreateOrthoCorrectedRasterDataset";

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
		public override string[] ValidEnvironments => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRasterDataset, OrthoType, ConstantElevation, InDEMRaster, Zfactor, Zoffset, Geoid };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to orthorectify. The raster must have RPCs in its metadata.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format of the dataset to be created.</para>
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
		/// <para>When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset.</para>
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, or a geodatabase, you can specify a Compression Type and Compression Quality in the Environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Orthorectification Type</para>
		/// <para>The DEM or specified value that represents the average elevation across the image.</para>
		/// <para>Constant elevation—A specified elevation value will be used.</para>
		/// <para>DEM—A specified digital elevation model raster will be used.</para>
		/// <para><see cref="OrthoTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OrthoType { get; set; }

		/// <summary>
		/// <para>Constant Elevation (Meters)</para>
		/// <para>The constant elevation value to be used when the Orthorectification Type parameter is Constant elevation.</para>
		/// <para>If a DEM is used in the orthocorrection process, this value is not used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConstantElevation { get; set; }

		/// <summary>
		/// <para>DEM Raster</para>
		/// <para>The DEM raster to be used for orthorectification when the Orthorectification Type parameter is DEM</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InDEMRaster { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The scaling factor used to convert the elevation values in the DEM.</para>
		/// <para>If your vertical units are meters, set the Z Factor to 1. If your vertical units are feet, set the Z Factor to 0.3048. If any other vertical units are used, use the Z Factor to scale the units to meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Zfactor { get; set; } = "1";

		/// <summary>
		/// <para>Z Offset</para>
		/// <para>The base value to be added to the elevation value in the DEM. This can be used to offset elevation values that do not start at sea level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Zoffset { get; set; } = "0";

		/// <summary>
		/// <para>Geoid</para>
		/// <para>Specifies whether the geoid correction required by RPCs that reference ellipsoidal heights will be made. Most elevation datasets are referenced to sea level orthometric heights, so this correction is required in these cases to convert to ellipsoidal heights.</para>
		/// <para>Unchecked—No geoid correction is made. Use this option only if your DEM is already expressed in ellipsoidal heights.</para>
		/// <para>Checked—A geoid correction will be made to convert orthometric heights to ellipsoidal heights (based on EGM96 geoid).</para>
		/// <para><see cref="GeoidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Geoid { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateOrthoCorrectedRasterDataset SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Orthorectification Type</para>
		/// </summary>
		public enum OrthoTypeEnum 
		{
			/// <summary>
			/// <para>Constant elevation—A specified elevation value will be used.</para>
			/// </summary>
			[GPValue("CONSTANT_ELEVATION")]
			[Description("Constant elevation")]
			Constant_elevation,

			/// <summary>
			/// <para>DEM—A specified digital elevation model raster will be used.</para>
			/// </summary>
			[GPValue("DEM")]
			[Description("DEM")]
			DEM,

		}

		/// <summary>
		/// <para>Geoid</para>
		/// </summary>
		public enum GeoidEnum 
		{
			/// <summary>
			/// <para>Checked—A geoid correction will be made to convert orthometric heights to ellipsoidal heights (based on EGM96 geoid).</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOID")]
			GEOID,

			/// <summary>
			/// <para>Unchecked—No geoid correction is made. Use this option only if your DEM is already expressed in ellipsoidal heights.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
