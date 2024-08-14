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
	/// <para>Split Raster</para>
	/// <para>Divides a raster dataset  into smaller pieces, by tiles or features from a polygon.</para>
	/// </summary>
	public class SplitRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster to split.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>The destination for the new raster datasets.</para>
		/// </param>
		/// <param name="OutBaseName">
		/// <para>Output Base Name</para>
		/// <para>The prefix for each of the raster datasets you will create. A number will be appended to each prefix, starting with 0.</para>
		/// </param>
		/// <param name="SplitMethod">
		/// <para>Split Method</para>
		/// <para>Determines how to split the raster dataset.</para>
		/// <para>Size of tile—Specify the width and height of the tile.</para>
		/// <para>Number of tiles— Specify the number of raster tiles to create by breaking the dataset into a number of columns and rows.</para>
		/// <para>Polygon features— Use the individual polygon geometries in a feature class to split the raster.</para>
		/// <para><see cref="SplitMethodEnum"/></para>
		/// </param>
		/// <param name="Format">
		/// <para>Output Format</para>
		/// <para>The format for the output raster datasets.</para>
		/// <para>Geotiff (*.tif)—Tagged Image File Format. This is the default.</para>
		/// <para>Bitmap (*.bmp)—Microsoft Bitmap.</para>
		/// <para>ENVI (*.dat)—ENVI DAT.</para>
		/// <para>Esri BIL (*.bil)—Esri Band Interleaved by Line.</para>
		/// <para>Esri BIP (*.bip)—Esri Band Interleaved by Pixel.</para>
		/// <para>Esri BSQ (*.bsq)—Esri Band Sequential.</para>
		/// <para>GIF (*.gif)—Graphic Interchange Format.</para>
		/// <para>Esri GRID—Esri Grid.</para>
		/// <para>ERDAS IMAGINE (*.img)—ERDAS IMAGINE.</para>
		/// <para>JPEG 2000 (*.jp2)—JPEG 2000.</para>
		/// <para>JPEG (*.jpeg)—Joint Photographic Experts Group.</para>
		/// <para>PNG (*.png)—Portable Network Graphics.</para>
		/// </param>
		public SplitRaster(object InRaster, object OutFolder, object OutBaseName, object SplitMethod, object Format)
		{
			this.InRaster = InRaster;
			this.OutFolder = OutFolder;
			this.OutBaseName = OutBaseName;
			this.SplitMethod = SplitMethod;
			this.Format = Format;
		}

		/// <summary>
		/// <para>Tool Display Name : Split Raster</para>
		/// </summary>
		public override string DisplayName => "Split Raster";

		/// <summary>
		/// <para>Tool Name : SplitRaster</para>
		/// </summary>
		public override string ToolName => "SplitRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.SplitRaster</para>
		/// </summary>
		public override string ExcuteName => "management.SplitRaster";

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
		public override string[] ValidEnvironments => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "snapRaster", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutFolder, OutBaseName, SplitMethod, Format, ResamplingType!, NumRasters!, TileSize!, Overlap!, Units!, CellSize!, Origin!, SplitPolygonFeatureClass!, ClipType!, TemplateExtent!, NodataValue!, DerivedOutFolder! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster to split.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The destination for the new raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>The prefix for each of the raster datasets you will create. A number will be appended to each prefix, starting with 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Split Method</para>
		/// <para>Determines how to split the raster dataset.</para>
		/// <para>Size of tile—Specify the width and height of the tile.</para>
		/// <para>Number of tiles— Specify the number of raster tiles to create by breaking the dataset into a number of columns and rows.</para>
		/// <para>Polygon features— Use the individual polygon geometries in a feature class to split the raster.</para>
		/// <para><see cref="SplitMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitMethod { get; set; } = "SIZE_OF_TILE";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>The format for the output raster datasets.</para>
		/// <para>Geotiff (*.tif)—Tagged Image File Format. This is the default.</para>
		/// <para>Bitmap (*.bmp)—Microsoft Bitmap.</para>
		/// <para>ENVI (*.dat)—ENVI DAT.</para>
		/// <para>Esri BIL (*.bil)—Esri Band Interleaved by Line.</para>
		/// <para>Esri BIP (*.bip)—Esri Band Interleaved by Pixel.</para>
		/// <para>Esri BSQ (*.bsq)—Esri Band Sequential.</para>
		/// <para>GIF (*.gif)—Graphic Interchange Format.</para>
		/// <para>Esri GRID—Esri Grid.</para>
		/// <para>ERDAS IMAGINE (*.img)—ERDAS IMAGINE.</para>
		/// <para>JPEG 2000 (*.jp2)—JPEG 2000.</para>
		/// <para>JPEG (*.jpeg)—Joint Photographic Experts Group.</para>
		/// <para>PNG (*.png)—Portable Network Graphics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "TIFF";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>Choose an appropriate technique based on the type of data you have.</para>
		/// <para>Nearest—The fastest resampling method, and it minimizes changes to pixel values. Suitable for discrete data, such as land cover.</para>
		/// <para>Bilinear—Calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding 4 pixels. Suitable for continuous data.</para>
		/// <para>Cubic—Calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. Produces the smoothest image, but can create values outside of the range found in the source data. Suitable for continuous data.</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Number of Output Rasters</para>
		/// <para>The number of columns (x) and rows (y) to split the raster dataset into. The X coordinate is the number of columns and the Y coordinate is number of rows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? NumRasters { get; set; } = "1 1";

		/// <summary>
		/// <para>Size of Output Rasters</para>
		/// <para>The x and y dimensions of the output tiles. The default unit of measurement is in pixels. You can change this with the Units for Output Raster Size and Overlap parameter. The X coordinate is the X (horizontal) dimension the output tiles and the Y coordinate is the Y (vertical) dimension of output tiles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? TileSize { get; set; } = "2048 2048";

		/// <summary>
		/// <para>Overlap</para>
		/// <para>The tiles do not have to line up perfectly; set the amount of overlap between tiles with this parameter. The default unit of measurement is in pixels. You can change this with the Units for Output Raster Size and Overlap parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Other Options")]
		public object? Overlap { get; set; } = "0";

		/// <summary>
		/// <para>Units for Output Raster Size and Overlap</para>
		/// <para>Set the units of measurement for the Size of Output Rasters parameter and the Overlap parameter.</para>
		/// <para>Pixels—The unit is in pixels. This is the default.</para>
		/// <para>Meters—The unit is in meters.</para>
		/// <para>Feet—The unit is in feet.</para>
		/// <para>Degrees—The unit is in decimal degrees.</para>
		/// <para>Miles—The unit is in miles.</para>
		/// <para>Kilometers—The unit is in kilometers.</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Other Options")]
		public object? Units { get; set; } = "PIXELS";

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The spatial resolution of the output raster. If left blank, the output cell size will match the input raster. When you change the cell size values, the tile size is reset to the image size and the tile count is reset to 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Other Options")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Lower left origin</para>
		/// <para>Change the coordinates for the lower left origin point, where the tiling scheme will begin. If left blank, the lower left origin would be the same as the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Other Options")]
		public object? Origin { get; set; }

		/// <summary>
		/// <para>Split Polygon Feature Class</para>
		/// <para>A feature class that will be used to split the raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? SplitPolygonFeatureClass { get; set; }

		/// <summary>
		/// <para>Clip Type</para>
		/// <para>Limits the extent of your raster dataset before you split it.</para>
		/// <para>None— Use the full extent of the input raster dataset.</para>
		/// <para>Extent—Specify bounding box as your clipping boundary.</para>
		/// <para>Feature class—Specify a feature class to clip the extent.</para>
		/// <para><see cref="ClipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Clipping Options")]
		public object? ClipType { get; set; } = "NONE";

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>An extent or a dataset used to define the clipping boundary. The dataset can be a raster or feature class.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Clipping Options")]
		public object? TemplateExtent { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>All the pixels with the specified value will be set to NoData in the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Other Options")]
		public object? NodataValue { get; set; }

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedOutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitRaster SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? snapRaster = null , object? tileSize = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, snapRaster: snapRaster, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Split Method</para>
		/// </summary>
		public enum SplitMethodEnum 
		{
			/// <summary>
			/// <para>Size of tile—Specify the width and height of the tile.</para>
			/// </summary>
			[GPValue("SIZE_OF_TILE")]
			[Description("Size of tile")]
			Size_of_tile,

			/// <summary>
			/// <para>Number of tiles— Specify the number of raster tiles to create by breaking the dataset into a number of columns and rows.</para>
			/// </summary>
			[GPValue("NUMBER_OF_TILES")]
			[Description("Number of tiles")]
			Number_of_tiles,

			/// <summary>
			/// <para>Polygon features— Use the individual polygon geometries in a feature class to split the raster.</para>
			/// </summary>
			[GPValue("POLYGON_FEATURES")]
			[Description("Polygon features")]
			Polygon_features,

		}

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>Nearest—The fastest resampling method, and it minimizes changes to pixel values. Suitable for discrete data, such as land cover.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Bilinear—Calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding 4 pixels. Suitable for continuous data.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic—Calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. Produces the smoothest image, but can create values outside of the range found in the source data. Suitable for continuous data.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

		}

		/// <summary>
		/// <para>Units for Output Raster Size and Overlap</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>Pixels—The unit is in pixels. This is the default.</para>
			/// </summary>
			[GPValue("PIXELS")]
			[Description("Pixels")]
			Pixels,

			/// <summary>
			/// <para>Meters—The unit is in meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Feet—The unit is in feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Degrees—The unit is in decimal degrees.</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("Degrees")]
			Degrees,

			/// <summary>
			/// <para>Kilometers—The unit is in kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Miles—The unit is in miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Clip Type</para>
		/// </summary>
		public enum ClipTypeEnum 
		{
			/// <summary>
			/// <para>None— Use the full extent of the input raster dataset.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Extent—Specify bounding box as your clipping boundary.</para>
			/// </summary>
			[GPValue("EXTENT")]
			[Description("Extent")]
			Extent,

			/// <summary>
			/// <para>Feature class—Specify a feature class to clip the extent.</para>
			/// </summary>
			[GPValue("FEATURE_CLASS")]
			[Description("Feature class")]
			Feature_class,

		}

#endregion
	}
}
