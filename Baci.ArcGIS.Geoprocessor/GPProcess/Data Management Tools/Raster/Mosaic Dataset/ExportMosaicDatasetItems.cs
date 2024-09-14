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
	/// <para>Export Mosaic Dataset Items</para>
	/// <para>Export Mosaic Dataset Items</para>
	/// <para>Saves a copy of processed images within a mosaic dataset to a specified folder and raster file format.</para>
	/// </summary>
	public class ExportMosaicDatasetItems : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that contains the images you want to export.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>The folder where you want to save your images.</para>
		/// </param>
		public ExportMosaicDatasetItems(object InMosaicDataset, object OutFolder)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Mosaic Dataset Items</para>
		/// </summary>
		public override string DisplayName() => "Export Mosaic Dataset Items";

		/// <summary>
		/// <para>Tool Name : ExportMosaicDatasetItems</para>
		/// </summary>
		public override string ToolName() => "ExportMosaicDatasetItems";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportMosaicDatasetItems</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportMosaicDatasetItems";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "snapRaster", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFolder, OutBaseName, WhereClause, Format, NodataValue, ClipType, TemplateDataset, CellSize, DerivedOutFolder };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that contains the images you want to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The folder where you want to save your images.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>A prefix to name each item after it is copied. The prefix will be followed by the Object ID from the mosaic dataset footprints table.</para>
		/// <para>If no base name is set, the text in the Name field of the mosaic dataset item will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to save selected images in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>Specifies the format for the output raster datasets.</para>
		/// <para>TIFF—TIFF format. This is the default.</para>
		/// <para>Cloud Optimized GeoTIFF—Cloud Optimized GeoTIFF format.</para>
		/// <para>BMP—BMP format.</para>
		/// <para>ENVI DAT—ENVI DAT format.</para>
		/// <para>Esri BIL—Esri BIL format.</para>
		/// <para>Esri BIP—Esri BIP format.</para>
		/// <para>Esri BSQ—Esri BSQ format.</para>
		/// <para>GIF—GIF format.</para>
		/// <para>Esri Grid—Esri Grid format.</para>
		/// <para>ERDAS IMAGINE—ERDAS IMAGINE format.</para>
		/// <para>JPEG 2000—JPEG 2000 format.</para>
		/// <para>JPEG—JPEG format.</para>
		/// <para>PNG—PNG format.</para>
		/// <para>Cloud raster format—Cloud raster format.</para>
		/// <para>Meta raster format—Meta raster format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>All the pixels with the specified value will be set to NoData in the output raster dataset.</para>
		/// <para>It is recommended that you specify a NoData value if the output images will be clipped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Clip Type</para>
		/// <para>Specifies the output extent of the raster datasets. If you choose an extent or feature class that covers an area larger than the raster data, the output will have the larger extent.</para>
		/// <para>No clipping—The output will not be clipped. This is the default.</para>
		/// <para>Clip to extent—An extent will be used to clip the output.</para>
		/// <para>Clip to feature class—A feature class extent will be used to clip the output.</para>
		/// <para><see cref="ClipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object ClipType { get; set; } = "NONE";

		/// <summary>
		/// <para>Clipping Template</para>
		/// <para>A feature class or a bounding box to limit the extent.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Advanced Setting")]
		public object TemplateDataset { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The horizontal (x) and vertical (y) dimensions of the output cells.</para>
		/// <para>If not specified, the spatial resolution of the input will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Advanced Setting")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Updated Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetItems SetEnviroment(object compression = null, object geographicTransformations = null, object nodata = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object pyramid = null, object rasterStatistics = null, object resamplingMethod = null, object snapRaster = null, double[] tileSize = null)
		{
			base.SetEnv(compression: compression, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, snapRaster: snapRaster, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip Type</para>
		/// </summary>
		public enum ClipTypeEnum 
		{
			/// <summary>
			/// <para>No clipping—The output will not be clipped. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No clipping")]
			No_clipping,

			/// <summary>
			/// <para>Clip to extent—An extent will be used to clip the output.</para>
			/// </summary>
			[GPValue("EXTENT")]
			[Description("Clip to extent")]
			Clip_to_extent,

			/// <summary>
			/// <para>Clip to feature class—A feature class extent will be used to clip the output.</para>
			/// </summary>
			[GPValue("FEATURE_CLASS")]
			[Description("Clip to feature class")]
			Clip_to_feature_class,

		}

#endregion
	}
}
