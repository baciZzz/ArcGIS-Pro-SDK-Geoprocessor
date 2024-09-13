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
	/// <para>Project Raster</para>
	/// <para>Project Raster</para>
	/// <para>Transforms a raster dataset from one coordinate system to another.</para>
	/// </summary>
	public class ProjectRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset that will be transformed into a new projection.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The raster dataset with the new projection that will be created.</para>
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
		/// <param name="OutCoorSystem">
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system of the new raster dataset.</para>
		/// </param>
		public ProjectRaster(object InRaster, object OutRaster, object OutCoorSystem)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.OutCoorSystem = OutCoorSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Project Raster</para>
		/// </summary>
		public override string DisplayName() => "Project Raster";

		/// <summary>
		/// <para>Tool Name : ProjectRaster</para>
		/// </summary>
		public override string ToolName() => "ProjectRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.ProjectRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.ProjectRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, OutCoorSystem, ResamplingType!, CellSize!, GeographicTransform!, RegistrationPoint!, InCoorSystem!, Vertical! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset that will be transformed into a new projection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The raster dataset with the new projection that will be created.</para>
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
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system of the new raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoorSystem { get; set; }

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>Specifies the resampling technique that will be used. The default is Nearest.</para>
		/// <para>Nearest neighbor— The nearest neighbor technique will be used. It minimizes changes to pixel values since no new values are created and is the fastest resampling technique. It is suitable for discrete data, such as land cover.</para>
		/// <para>Bilinear interpolation— The bilinear interpolation technique will be used. It calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding four pixels. It is suitable for continuous data.</para>
		/// <para>Cubic convolution—The cubic convolution technique will be used. It calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. This produces the smoothest image but can create values outside of the range found in the source data. It is suitable for continuous data.</para>
		/// <para>Majority resampling—The majority resampling technique will be used. It determines the value of each pixel based on the most popular value in a 3 by 3 window. It is suitable for discrete data.</para>
		/// <para>The Nearest and Majority options are used for categorical data, such as a land-use classification. The Nearest option is the default. It is the quickest and does not change the pixel values. Do not use either of these options for continuous data, such as elevation surfaces.</para>
		/// <para>The Bilinear and Cubic options are most appropriate for continuous data. It is recommended that you do not use either of these with categorical data because the pixel values may be altered.</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>The cell size of the new raster using an existing raster dataset or by specifying its width (x) and height (y).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCellSizeXY()]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>The geographic transformation when projecting from one geographic system or datum to another. A transformation is required when the input and output coordinate systems have different datums.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? GeographicTransform { get; set; }

		/// <summary>
		/// <para>Registration Point</para>
		/// <para>The lower left point for anchoring the output cells. This point does not have to be a corner coordinate or fall within the raster dataset.</para>
		/// <para>The Snap Raster Environment setting will take priority over the Registration Point parameter. To set the registration point, make sure Snap Raster is not set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? RegistrationPoint { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system of the input raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InCoorSystem { get; set; }

		/// <summary>
		/// <para>Vertical</para>
		/// <para>Specifies whether a vertical transformation will be applied.</para>
		/// <para>This option is active when the input and output coordinate systems have a vertical coordinate system and the input raster&apos;s coordinates have z-values.</para>
		/// <para>When Vertical is checked, the Geographic Transformation parameter can include ellipsoidal transformations and transformations between vertical datums. For example, ~NAD_1983_To_NAVD88_CONUS_GEOID12B_Height + NAD_1983_To_WGS_1984_1 transforms geometry vertices that are defined on NAD 1983 datum with NAVD 1988 heights into vertices on the WGS 1984 ellipsoid (with z-values representing ellipsoidal heights). The tilde (~) indicates reversed direction of transformation.</para>
		/// <para>Unchecked—No vertical transformation is applied. The z-values of geometry coordinates will be ignored and the z-values will not be modified. This is the default.</para>
		/// <para>Checked—The transformation specified in the Geographic Transformation parameter is applied. The Project Raster tool transforms x-, y-, and z-values of geometry coordinates.</para>
		/// <para>Many vertical transformations require additional data files that must be installed using the ArcGIS Coordinate Systems Data installation package.</para>
		/// <para><see cref="VerticalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Vertical { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ProjectRaster SetEnviroment(object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>Nearest neighbor— The nearest neighbor technique will be used. It minimizes changes to pixel values since no new values are created and is the fastest resampling technique. It is suitable for discrete data, such as land cover.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest neighbor")]
			Nearest_neighbor,

			/// <summary>
			/// <para>Bilinear interpolation— The bilinear interpolation technique will be used. It calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding four pixels. It is suitable for continuous data.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear interpolation")]
			Bilinear_interpolation,

			/// <summary>
			/// <para>Cubic convolution—The cubic convolution technique will be used. It calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. This produces the smoothest image but can create values outside of the range found in the source data. It is suitable for continuous data.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic convolution")]
			Cubic_convolution,

			/// <summary>
			/// <para>Majority resampling—The majority resampling technique will be used. It determines the value of each pixel based on the most popular value in a 3 by 3 window. It is suitable for discrete data.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority resampling")]
			Majority_resampling,

		}

		/// <summary>
		/// <para>Vertical</para>
		/// </summary>
		public enum VerticalEnum 
		{
			/// <summary>
			/// <para>Checked—The transformation specified in the Geographic Transformation parameter is applied. The Project Raster tool transforms x-, y-, and z-values of geometry coordinates.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VERTICAL")]
			VERTICAL,

			/// <summary>
			/// <para>Unchecked—No vertical transformation is applied. The z-values of geometry coordinates will be ignored and the z-values will not be modified. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VERTICAL")]
			NO_VERTICAL,

		}

#endregion
	}
}
