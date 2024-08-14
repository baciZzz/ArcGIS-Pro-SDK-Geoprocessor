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
	/// <para>Warp From File</para>
	/// <para>Transforms a raster dataset using an existing text file containing source and target control points.</para>
	/// </summary>
	public class WarpFromFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster to be transformed.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a compression type and compression quality using environment settings.</para>
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
		/// </param>
		/// <param name="LinkFile">
		/// <para>Link File</para>
		/// <para>The text, CSV file, or TAB file containing the coordinates to warp the input raster. This can be generated from the Register Raster tool or from the Georeferencing tab.</para>
		/// </param>
		public WarpFromFile(object InRaster, object OutRaster, object LinkFile)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.LinkFile = LinkFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Warp From File</para>
		/// </summary>
		public override string DisplayName => "Warp From File";

		/// <summary>
		/// <para>Tool Name : WarpFromFile</para>
		/// </summary>
		public override string ToolName => "WarpFromFile";

		/// <summary>
		/// <para>Tool Excute Name : management.WarpFromFile</para>
		/// </summary>
		public override string ExcuteName => "management.WarpFromFile";

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
		public override object[] Parameters => new object[] { InRaster, OutRaster, LinkFile, TransformationType!, ResamplingType! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster to be transformed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a compression type and compression quality using environment settings.</para>
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
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Link File</para>
		/// <para>The text, CSV file, or TAB file containing the coordinates to warp the input raster. This can be generated from the Register Raster tool or from the Georeferencing tab.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETextFile()]
		public object LinkFile { get; set; }

		/// <summary>
		/// <para>Transformation Type</para>
		/// <para>Specifies the transformation method for shifting the raster dataset.</para>
		/// <para>Shift only— A zero-order polynomial will be used to shift the data. This is commonly used when the data is georeferenced, but a small shift will better line it up. Only one link is required to perform a zero-order polynomial shift.</para>
		/// <para>Similarity transformation— A first order transformation will be used that attempts to preserve the shape of the original raster. The RMS error tends to be higher than other polynomial transformations because the preservation of shape is more important than the best fit.</para>
		/// <para>Affine transformation—A first-order polynomial (affine) will be used to fit a flat plane to the input points.</para>
		/// <para>Second-order polynomial transformation—A second-order polynomial will be used to fit a somewhat more complicated surface to the input points.</para>
		/// <para>Third-order polynomial transformation—A third-order polynomial will be used to fit a more complicated surface to the input points.</para>
		/// <para>Optimize for global and local accuracy— A polynomial transformation is combined with a triangulated irregular network (TIN) interpolation technique that will optimize for both global and local accuracy.</para>
		/// <para>Spline transformation— The source control points will be transformed precisely to the target control points. In the output, the control points will be accurate, but the raster pixels between the control points will not.</para>
		/// <para>Projective transformation— Lines will be warped so that they remain straight. In doing so, lines that were once parallel may no longer remain parallel. The projective transformation is especially useful for oblique imagery, scanned maps, and for some imagery products.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>The resampling algorithm to be used.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WarpFromFile SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transformation Type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>Shift only— A zero-order polynomial will be used to shift the data. This is commonly used when the data is georeferenced, but a small shift will better line it up. Only one link is required to perform a zero-order polynomial shift.</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("Shift only")]
			Shift_only,

			/// <summary>
			/// <para>Similarity transformation— A first order transformation will be used that attempts to preserve the shape of the original raster. The RMS error tends to be higher than other polynomial transformations because the preservation of shape is more important than the best fit.</para>
			/// </summary>
			[GPValue("POLYSIMILARITY")]
			[Description("Similarity transformation")]
			Similarity_transformation,

			/// <summary>
			/// <para>Affine transformation—A first-order polynomial (affine) will be used to fit a flat plane to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("Affine transformation")]
			Affine_transformation,

			/// <summary>
			/// <para>Second-order polynomial transformation—A second-order polynomial will be used to fit a somewhat more complicated surface to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER2")]
			[Description("Second-order polynomial transformation")]
			POLYORDER2,

			/// <summary>
			/// <para>Third-order polynomial transformation—A third-order polynomial will be used to fit a more complicated surface to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER3")]
			[Description("Third-order polynomial transformation")]
			POLYORDER3,

			/// <summary>
			/// <para>Optimize for global and local accuracy— A polynomial transformation is combined with a triangulated irregular network (TIN) interpolation technique that will optimize for both global and local accuracy.</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("Optimize for global and local accuracy")]
			Optimize_for_global_and_local_accuracy,

			/// <summary>
			/// <para>Spline transformation— The source control points will be transformed precisely to the target control points. In the output, the control points will be accurate, but the raster pixels between the control points will not.</para>
			/// </summary>
			[GPValue("SPLINE")]
			[Description("Spline transformation")]
			Spline_transformation,

			/// <summary>
			/// <para>Projective transformation— Lines will be warped so that they remain straight. In doing so, lines that were once parallel may no longer remain parallel. The projective transformation is especially useful for oblique imagery, scanned maps, and for some imagery products.</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("Projective transformation")]
			Projective_transformation,

		}

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

#endregion
	}
}
