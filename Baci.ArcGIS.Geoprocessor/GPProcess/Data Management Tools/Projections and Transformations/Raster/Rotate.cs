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
	/// <para>Rotate</para>
	/// <para>Turns a raster dataset around a specified pivot point.</para>
	/// </summary>
	public class Rotate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to rotate.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a compression type and compression quality.</para>
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
		/// </param>
		/// <param name="Angle">
		/// <para>Angle</para>
		/// <para>Specify a value between 0 and 360 degrees the raster will be rotated in the clockwise direction. To rotate the raster in the counterclockwise direction, specify the angle as a negative value. The angle can be specified as an integer or a floating-point value.</para>
		/// </param>
		public Rotate(object InRaster, object OutRaster, object Angle)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.Angle = Angle;
		}

		/// <summary>
		/// <para>Tool Display Name : Rotate</para>
		/// </summary>
		public override string DisplayName => "Rotate";

		/// <summary>
		/// <para>Tool Name : Rotate</para>
		/// </summary>
		public override string ToolName => "Rotate";

		/// <summary>
		/// <para>Tool Excute Name : management.Rotate</para>
		/// </summary>
		public override string ExcuteName => "management.Rotate";

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
		public override object[] Parameters => new object[] { InRaster, OutRaster, Angle, PivotPoint!, ResamplingType!, ClippingExtent! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to rotate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a compression type and compression quality.</para>
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
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Angle</para>
		/// <para>Specify a value between 0 and 360 degrees the raster will be rotated in the clockwise direction. To rotate the raster in the counterclockwise direction, specify the angle as a negative value. The angle can be specified as an integer or a floating-point value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object Angle { get; set; }

		/// <summary>
		/// <para>Pivot Point</para>
		/// <para>The point the raster will rotate around. If left blank, the lower left corner of the input raster dataset will serve as the pivot.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? PivotPoint { get; set; }

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
		/// <para>Clipping Extent</para>
		/// <para>The processing extent of the raster dataset. The source data will be clipped to the specified extent before rotation.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? ClippingExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Rotate SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
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
