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
	/// <para>Clip Raster</para>
	/// <para>Cuts out a portion of a raster dataset, mosaic dataset, or image service layer.</para>
	/// </summary>
	public class Clip : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset, mosaic dataset, or image service to be clipped.</para>
		/// </param>
		/// <param name="Rectangle">
		/// <para>Rectangle</para>
		/// <para>The four coordinates that define the extent of the bounding box used to clip the raster.</para>
		/// <para>If the clip extent specified is not aligned with the input raster dataset, the clip tool verifies that the proper alignment is used. This may cause the output to have a slightly different extent than specified in the tool.</para>
		/// <para>Use the Clear button to reset the rectangle extent to the extent of the input raster dataset.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format of the dataset being created. Make sure that it can support the necessary bit depth.</para>
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
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </param>
		public Clip(object InRaster, object Rectangle, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Rectangle = Rectangle;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Clip Raster</para>
		/// </summary>
		public override string DisplayName => "Clip Raster";

		/// <summary>
		/// <para>Tool Name : Clip</para>
		/// </summary>
		public override string ToolName => "Clip";

		/// <summary>
		/// <para>Tool Excute Name : management.Clip</para>
		/// </summary>
		public override string ExcuteName => "management.Clip";

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
		public override object[] Parameters => new object[] { InRaster, Rectangle, OutRaster, InTemplateDataset, NodataValue, ClippingGeometry, MaintainClippingExtent };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset, mosaic dataset, or image service to be clipped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Rectangle</para>
		/// <para>The four coordinates that define the extent of the bounding box used to clip the raster.</para>
		/// <para>If the clip extent specified is not aligned with the input raster dataset, the clip tool verifies that the proper alignment is used. This may cause the output to have a slightly different extent than specified in the tool.</para>
		/// <para>Use the Clear button to reset the rectangle extent to the extent of the input raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Rectangle { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location, and format of the dataset being created. Make sure that it can support the necessary bit depth.</para>
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
		/// <para>When storing your raster dataset to a JPEG file, a JPEG 2000 file, a TIFF file, or a geodatabase, you can specify a Compression Type and Compression Quality in the geoprocessing Environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Extent</para>
		/// <para>A raster dataset or feature class to use as the extent. The clip output includes any pixels that intersect the minimum bounding rectangle.</para>
		/// <para>If a feature class is used as the output extent and you want to clip the raster based on the polygon features, check the Use Input Features for Clipping Geometry parameter. When this parameter is checked, the pixel depth of the output may be promoted. Therefore, make sure that the output format can support the proper pixel depth.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InTemplateDataset { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>The value for pixels to be considered as NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Use Input Features for Clipping Geometry</para>
		/// <para>Specifies whether the data will be clipped to the minimum bounding rectangle or to the geometry of the feature class.</para>
		/// <para>Unchecked—The minimum bounding rectangle is used to clip the data.</para>
		/// <para>Checked—The geometry of the selected feature class is used to clip the data. The pixel depth of the output may be increased; therefore, make sure that the output format can support the proper pixel depth.</para>
		/// <para><see cref="ClippingGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClippingGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Maintain Clipping Extent</para>
		/// <para>Specifies the extent to use in the clipping output.</para>
		/// <para>Checked—The number of columns and rows will be adjusted and the pixels will be resampled to exactly match the clipping extent specified.</para>
		/// <para>Unchecked—The cell alignment of the input raster will be maintained and the output extent will be adjusted accordingly.</para>
		/// <para><see cref="MaintainClippingExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MaintainClippingExtent { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Clip SetEnviroment(object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use Input Features for Clipping Geometry</para>
		/// </summary>
		public enum ClippingGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—The geometry of the selected feature class is used to clip the data. The pixel depth of the output may be increased; therefore, make sure that the output format can support the proper pixel depth.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ClippingGeometry")]
			ClippingGeometry,

			/// <summary>
			/// <para>Unchecked—The minimum bounding rectangle is used to clip the data.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Maintain Clipping Extent</para>
		/// </summary>
		public enum MaintainClippingExtentEnum 
		{
			/// <summary>
			/// <para>Checked—The number of columns and rows will be adjusted and the pixels will be resampled to exactly match the clipping extent specified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_EXTENT")]
			MAINTAIN_EXTENT,

			/// <summary>
			/// <para>Unchecked—The cell alignment of the input raster will be maintained and the output extent will be adjusted accordingly.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAINTAIN_EXTENT")]
			NO_MAINTAIN_EXTENT,

		}

#endregion
	}
}
