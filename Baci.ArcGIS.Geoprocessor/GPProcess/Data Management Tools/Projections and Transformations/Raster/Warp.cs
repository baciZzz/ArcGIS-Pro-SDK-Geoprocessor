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
	/// <para>Warp</para>
	/// <para>Transforms a raster dataset using source and target control points. This is similar to georeferencing.</para>
	/// </summary>
	public class Warp : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster to be transformed.</para>
		/// </param>
		/// <param name="SourceControlPoints">
		/// <para>Source Control Points</para>
		/// <para>The coordinates of the raster to be warped.</para>
		/// </param>
		/// <param name="TargetControlPoints">
		/// <para>Target Control Points</para>
		/// <para>The coordinates to which the source raster will be warped.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, JPEG 2000 file, TIFF file, or geodatabase, you can specify a compression type and compression quality.</para>
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
		/// </param>
		public Warp(object InRaster, object SourceControlPoints, object TargetControlPoints, object OutRaster)
		{
			this.InRaster = InRaster;
			this.SourceControlPoints = SourceControlPoints;
			this.TargetControlPoints = TargetControlPoints;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Warp</para>
		/// </summary>
		public override string DisplayName => "Warp";

		/// <summary>
		/// <para>Tool Name : Warp</para>
		/// </summary>
		public override string ToolName => "Warp";

		/// <summary>
		/// <para>Tool Excute Name : management.Warp</para>
		/// </summary>
		public override string ExcuteName => "management.Warp";

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
		public override object[] Parameters => new object[] { InRaster, SourceControlPoints, TargetControlPoints, OutRaster, TransformationType, ResamplingType };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster to be transformed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Source Control Points</para>
		/// <para>The coordinates of the raster to be warped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object SourceControlPoints { get; set; }

		/// <summary>
		/// <para>Target Control Points</para>
		/// <para>The coordinates to which the source raster will be warped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TargetControlPoints { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, JPEG 2000 file, TIFF file, or geodatabase, you can specify a compression type and compression quality.</para>
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
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Transformation Type</para>
		/// <para>Specifies the transformation method for shifting the raster dataset.</para>
		/// <para>Shift only— This method uses a zero-order polynomial to shift your data. This is commonly used when your data is already georeferenced, but a small shift will better line up your data. Only one link is required to perform a zero-order polynomial shift.</para>
		/// <para>Similarity transformation— This is a first order transformation that attempts to preserve the shape of the original raster. The RMS error tends to be higher than other polynomial transformations because the preservation of shape is more important than the best fit.</para>
		/// <para>Affine transformation—A first-order polynomial (affine) fits a flat plane to the input points.</para>
		/// <para>Second-order polynomial transformation—A second-order polynomial fits a somewhat more complicated surface to the input points.</para>
		/// <para>Third-order polynomial transformation—A third-order polynomial fits a more complicated surface to the input points.</para>
		/// <para>Optimize for global and local accuracy— This method combines a polynomial transformation and uses a triangulated irregular network (TIN) interpolation technique to optimize for both global and local accuracy.</para>
		/// <para>Spline transformation— This method transforms the source control points precisely to the target control points. In the output, the control points will be accurate, but the raster pixels between the control points are not.</para>
		/// <para>Projective transformation— This method warps lines so they remain straight. In doing so, lines that were once parallel may no longer remain parallel. The projective transformation is especially useful for oblique imagery, scanned maps, and for some imagery products.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>The resampling algorithm to be used. The default is Nearest.</para>
		/// <para>Nearest neighbor— Nearest neighbor is the fastest resampling method; it minimizes changes to pixel values since no new values are created. It is suitable for discrete data, such as land cover.</para>
		/// <para>Bilinear interpolation— Bilinear interpolation calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding four pixels. It is suitable for continuous data.</para>
		/// <para>Cubic convolution— Cubic convolution calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. This produces the smoothest image but can create values outside of the range found in the source data. It is suitable for continuous data.</para>
		/// <para>Majority resampling—Majority resampling determines the value of each pixel based on the most popular value in a 3 by 3 window. Suitable for discrete data.</para>
		/// <para>The Nearest and Majority options are used for categorical data, such as a land-use classification. The Nearest option is the default since it is the quickest and also because it will not change the cell values. Do not use either of these for continuous data, such as elevation surfaces.</para>
		/// <para>The Bilinear option and the Cubic option are most appropriate for continuous data. It is recommended that neither of these be used with categorical data because the cell values may be altered.</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Warp SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
			/// <para>Shift only— This method uses a zero-order polynomial to shift your data. This is commonly used when your data is already georeferenced, but a small shift will better line up your data. Only one link is required to perform a zero-order polynomial shift.</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("Shift only")]
			Shift_only,

			/// <summary>
			/// <para>Similarity transformation— This is a first order transformation that attempts to preserve the shape of the original raster. The RMS error tends to be higher than other polynomial transformations because the preservation of shape is more important than the best fit.</para>
			/// </summary>
			[GPValue("POLYSIMILARITY")]
			[Description("Similarity transformation")]
			Similarity_transformation,

			/// <summary>
			/// <para>Affine transformation—A first-order polynomial (affine) fits a flat plane to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("Affine transformation")]
			Affine_transformation,

			/// <summary>
			/// <para>Second-order polynomial transformation—A second-order polynomial fits a somewhat more complicated surface to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER2")]
			[Description("Second-order polynomial transformation")]
			POLYORDER2,

			/// <summary>
			/// <para>Third-order polynomial transformation—A third-order polynomial fits a more complicated surface to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER3")]
			[Description("Third-order polynomial transformation")]
			POLYORDER3,

			/// <summary>
			/// <para>Optimize for global and local accuracy— This method combines a polynomial transformation and uses a triangulated irregular network (TIN) interpolation technique to optimize for both global and local accuracy.</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("Optimize for global and local accuracy")]
			Optimize_for_global_and_local_accuracy,

			/// <summary>
			/// <para>Spline transformation— This method transforms the source control points precisely to the target control points. In the output, the control points will be accurate, but the raster pixels between the control points are not.</para>
			/// </summary>
			[GPValue("SPLINE")]
			[Description("Spline transformation")]
			Spline_transformation,

			/// <summary>
			/// <para>Projective transformation— This method warps lines so they remain straight. In doing so, lines that were once parallel may no longer remain parallel. The projective transformation is especially useful for oblique imagery, scanned maps, and for some imagery products.</para>
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
			/// <para>Nearest neighbor— Nearest neighbor is the fastest resampling method; it minimizes changes to pixel values since no new values are created. It is suitable for discrete data, such as land cover.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest neighbor")]
			Nearest_neighbor,

			/// <summary>
			/// <para>Bilinear interpolation— Bilinear interpolation calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding four pixels. It is suitable for continuous data.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear interpolation")]
			Bilinear_interpolation,

			/// <summary>
			/// <para>Cubic convolution— Cubic convolution calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. This produces the smoothest image but can create values outside of the range found in the source data. It is suitable for continuous data.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic convolution")]
			Cubic_convolution,

			/// <summary>
			/// <para>Majority resampling—Majority resampling determines the value of each pixel based on the most popular value in a 3 by 3 window. Suitable for discrete data.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority resampling")]
			Majority_resampling,

		}

#endregion
	}
}
