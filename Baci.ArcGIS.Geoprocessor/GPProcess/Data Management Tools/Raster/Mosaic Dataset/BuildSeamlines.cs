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
	/// <para>Build Seamlines</para>
	/// <para>Build Seamlines</para>
	/// <para>Generate or update seamlines for your mosaic dataset. Seamlines are used to sort overlapping imagery and produce a smoother-looking mosaic.</para>
	/// </summary>
	public class BuildSeamlines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>Select the mosaic dataset on which to build seamlines.</para>
		/// </param>
		public BuildSeamlines(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Seamlines</para>
		/// </summary>
		public override string DisplayName() => "Build Seamlines";

		/// <summary>
		/// <para>Tool Name : BuildSeamlines</para>
		/// </summary>
		public override string ToolName() => "BuildSeamlines";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildSeamlines</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildSeamlines";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, CellSize!, SortMethod!, SortOrder!, OrderByAttribute!, OrderByBaseValue!, ViewPoint!, ComputationMethod!, BlendWidth!, BlendType!, RequestSize!, RequestSizeType!, BlendWidthUnits!, AreaOfInterest!, WhereClause!, UpdateExisting!, OutMosaicDataset!, MinRegionSize!, MinThinnessRatio!, MaxSliverSize! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>Select the mosaic dataset on which to build seamlines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>Generate seamlines for raster datasets that fall within the following range of spatial resolutions.</para>
		/// <para>You can leave this parameter empty and the tool will automatically create seamlines at the appropriate levels.</para>
		/// <para>The units for this parameter are the same as the spatial reference of the input mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Advanced Options")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Sort Method</para>
		/// <para>Set a rule to determine which raster will be used to generate seamlines when images overlap.</para>
		/// <para>Northwest— Select the raster datasets that have center points closest to the northwest corner of the boundary. This is the default.</para>
		/// <para>Closest to viewpoint— Select raster datasets based on a user-defined location and a nadir location for the raster datasets using the Viewpoint tool.</para>
		/// <para>By attribute— Select raster datasets based on an attribute from the footprint attribute table. Commonly used attributes include acquisition date, cloud cover, or viewing angle.</para>
		/// <para><see cref="SortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SortMethod { get; set; } = "NORTH_WEST";

		/// <summary>
		/// <para>Sort Ascending</para>
		/// <para>Sort the raster datasets in ascending or descending order.</para>
		/// <para>Checked—Sort the rasters in ascending order. This is the default.</para>
		/// <para>Unchecked—Sort the rasters in descending order.</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SortOrder { get; set; } = "true";

		/// <summary>
		/// <para>Sort Attribute</para>
		/// <para>Order the raster datasets based on this field when the sort method is By Attribute. The default attribute is ObjectID.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Date", "OID")]
		public object? OrderByAttribute { get; set; }

		/// <summary>
		/// <para>Sort Base Value</para>
		/// <para>Sort the rasters by their difference between this value and their value in the Sort Attribute parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPVariant()]
		public object? OrderByBaseValue { get; set; }

		/// <summary>
		/// <para>View Point</para>
		/// <para>Set the coordinate location to use when Sort Method is Closest to viewpoint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? ViewPoint { get; set; }

		/// <summary>
		/// <para>Computation Method</para>
		/// <para>Choose how to build seamlines.</para>
		/// <para>Geometry—Generate seamlines for overlapping areas based on the intersection of footprints. Areas with no overlapping imagery will merge the footprints. This is the default.</para>
		/// <para>Radiometry—Generate seamlines based on the spectral patterns of features within the imagery.</para>
		/// <para>Copy footprint—Generate seamlines directly from the footprints.</para>
		/// <para>Copy to sibling—Apply the seamlines from another mosaic dataset. The mosaic datasets have to be in the same group. For example, the extent of the panchromatic band does not always match the extent of the multispectral band. This option makes sure they share the same seamline.</para>
		/// <para>Edge detection—Generate seamlines over intersecting areas based on the edges of features in the area.</para>
		/// <para>Voronoi—Generate seamlines using the area Voronoi diagram.</para>
		/// <para>Disparity—Generate seamlines based on the disparity images of stereo pairs. This method can avoid seamlines cutting through buildings.</para>
		/// <para>The Sort Method parameter applies to each computation method.</para>
		/// <para><see cref="ComputationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComputationMethod { get; set; } = "RADIOMETRY";

		/// <summary>
		/// <para>Blend Width</para>
		/// <para>Blending (feathering) occurs along a seamline between pixels where there are overlapping rasters. The blend width defines how many pixels will be blended.</para>
		/// <para>If the blend width value is 10, and you use Both as the blend type, then 5 pixels will be blended on the inside and outside of the seamline. If the value is 10, and the blend type is Inside, then 10 pixels will be blended on the inside of the seamline.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Processing")]
		public object? BlendWidth { get; set; }

		/// <summary>
		/// <para>Blend Type</para>
		/// <para>Determine how to blend one image into another, over the seamlines. Options are to blend inside the seamlines, outside the seamlines, or both inside and outside.</para>
		/// <para>Both— Blend using pixels on either side of the seamlines. For example, if the Blend Width is 10 pixels, then five pixels will be blended on the inside and outside of the seamline. This is the default.</para>
		/// <para>Inside—Blend inside of the seamline.</para>
		/// <para>Outside—Blend outside of the seamline.</para>
		/// <para><see cref="BlendTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Processing")]
		public object? BlendType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Request Size</para>
		/// <para>Specify the number of columns and rows for resampling. The maximum value is 5,000. Increase or decrease this value based on the complexity of your raster data. Greater image resolution provides more detail in the raster dataset but also increases the processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 25000000)]
		[Category("Processing")]
		public object? RequestSize { get; set; } = "1000";

		/// <summary>
		/// <para>Request Size Type</para>
		/// <para>Set the units for the Request Size.</para>
		/// <para>Pixels—Modify the request size based on the pixel size.This is the default option and resamples the closest image based on the raster pixel size.</para>
		/// <para>Pixel scaling factor—Modify the request size by specifying a scaling factor. This option resamples the closest image by multiplying the raster pixel size (from cell size level table) with the pixel size factor.</para>
		/// <para><see cref="RequestSizeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Processing")]
		public object? RequestSizeType { get; set; } = "PIXELS";

		/// <summary>
		/// <para>Blend Width Units</para>
		/// <para>Specify the unit of measurement for blend width.</para>
		/// <para>Pixels—Measure using the number of pixels. This is the default.</para>
		/// <para>Ground units—Measure using the same units as the mosaic dataset.</para>
		/// <para><see cref="BlendWidthUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Processing")]
		public object? BlendWidthUnits { get; set; } = "PIXELS";

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>Build seamlines on all the rasters that intersect this polygon. To specify an area of interest, browse to a feature class, or create a polygon graphic on the display.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>SQL expression to build seamlines on specific raster datasets within the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Update Existing Seamlines</para>
		/// <para>Update seamlines that are affected by the addition or deletion of mosaic dataset items. This option is enabled only if seamlines were generated previously and it will use the existing sort method and sort order to generate seamlines.</para>
		/// <para>Unchecked—Regenerates seamlines for all items and ignores existing seamlines, if any. This is the default.</para>
		/// <para>Checked—Only update items without seamlines. If any new items overlap with the previously created seamlines, the existing seamlines may be affected.</para>
		/// <para>This parameter is disabled if seamlines do not exist.</para>
		/// <para><see cref="UpdateExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateExisting { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Minimum Region Size</para>
		/// <para>Specify the minimum region size, in pixel units. Any polygons smaller than this specified threshold will be removed in the seamline result. The default is 100 pixels.</para>
		/// <para>This parameter value should be smaller than the sliver area, which is defined as (Maximum Sliver Size) * (Maximum Sliver Size).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Advanced Options")]
		public object? MinRegionSize { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Thinness Ratio</para>
		/// <para>Define how thin a polygon can be, before it is considered a sliver. This is based on a scale from 0 to 1.0, where a value of 0.0 represents a polygon that is almost a straight line, and a value of 1.0 represents a polygon that is a circle.</para>
		/// <para>Slivers are removed when building seamlines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Sliver Removal Options")]
		public object? MinThinnessRatio { get; set; } = "0.05";

		/// <summary>
		/// <para>Maximum Sliver Size</para>
		/// <para>Specify the maximum size a polygon can be to still be considered a sliver. This parameter is specified in pixels and is based on the Request Size, not the spatial resolution of the source raster. Any polygon that is less than the square of this value is considered a sliver. Any regions that are less than (Maximum Sliver Size)2 are considered slivers.</para>
		/// <para>Slivers are removed when building seamlines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Sliver Removal Options")]
		public object? MaxSliverSize { get; set; } = "20";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildSeamlines SetEnviroment(object? parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort Method</para>
		/// </summary>
		public enum SortMethodEnum 
		{
			/// <summary>
			/// <para>Northwest— Select the raster datasets that have center points closest to the northwest corner of the boundary. This is the default.</para>
			/// </summary>
			[GPValue("NORTH_WEST")]
			[Description("Northwest")]
			Northwest,

			/// <summary>
			/// <para>Closest to viewpoint— Select raster datasets based on a user-defined location and a nadir location for the raster datasets using the Viewpoint tool.</para>
			/// </summary>
			[GPValue("CLOSEST_TO_VIEWPOINT")]
			[Description("Closest to viewpoint")]
			Closest_to_viewpoint,

			/// <summary>
			/// <para>By attribute— Select raster datasets based on an attribute from the footprint attribute table. Commonly used attributes include acquisition date, cloud cover, or viewing angle.</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("By attribute")]
			By_attribute,

		}

		/// <summary>
		/// <para>Sort Ascending</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para>Checked—Sort the rasters in ascending order. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ASCENDING")]
			ASCENDING,

			/// <summary>
			/// <para>Unchecked—Sort the rasters in descending order.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DESCENDING")]
			DESCENDING,

		}

		/// <summary>
		/// <para>Computation Method</para>
		/// </summary>
		public enum ComputationMethodEnum 
		{
			/// <summary>
			/// <para>Geometry—Generate seamlines for overlapping areas based on the intersection of footprints. Areas with no overlapping imagery will merge the footprints. This is the default.</para>
			/// </summary>
			[GPValue("GEOMETRY")]
			[Description("Geometry")]
			Geometry,

			/// <summary>
			/// <para>Radiometry—Generate seamlines based on the spectral patterns of features within the imagery.</para>
			/// </summary>
			[GPValue("RADIOMETRY")]
			[Description("Radiometry")]
			Radiometry,

			/// <summary>
			/// <para>Copy footprint—Generate seamlines directly from the footprints.</para>
			/// </summary>
			[GPValue("COPY_FOOTPRINT")]
			[Description("Copy footprint")]
			Copy_footprint,

			/// <summary>
			/// <para>Copy to sibling—Apply the seamlines from another mosaic dataset. The mosaic datasets have to be in the same group. For example, the extent of the panchromatic band does not always match the extent of the multispectral band. This option makes sure they share the same seamline.</para>
			/// </summary>
			[GPValue("COPY_TO_SIBLING")]
			[Description("Copy to sibling")]
			Copy_to_sibling,

			/// <summary>
			/// <para>Edge detection—Generate seamlines over intersecting areas based on the edges of features in the area.</para>
			/// </summary>
			[GPValue("EDGE_DETECTION")]
			[Description("Edge detection")]
			Edge_detection,

			/// <summary>
			/// <para>Voronoi—Generate seamlines using the area Voronoi diagram.</para>
			/// </summary>
			[GPValue("VORONOI")]
			[Description("Voronoi")]
			Voronoi,

			/// <summary>
			/// <para>Disparity—Generate seamlines based on the disparity images of stereo pairs. This method can avoid seamlines cutting through buildings.</para>
			/// </summary>
			[GPValue("DISPARITY")]
			[Description("Disparity")]
			Disparity,

		}

		/// <summary>
		/// <para>Blend Type</para>
		/// </summary>
		public enum BlendTypeEnum 
		{
			/// <summary>
			/// <para>Both— Blend using pixels on either side of the seamlines. For example, if the Blend Width is 10 pixels, then five pixels will be blended on the inside and outside of the seamline. This is the default.</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("Both")]
			Both,

			/// <summary>
			/// <para>Inside—Blend inside of the seamline.</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("Inside")]
			Inside,

			/// <summary>
			/// <para>Outside—Blend outside of the seamline.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

		/// <summary>
		/// <para>Request Size Type</para>
		/// </summary>
		public enum RequestSizeTypeEnum 
		{
			/// <summary>
			/// <para>Pixels—Modify the request size based on the pixel size.This is the default option and resamples the closest image based on the raster pixel size.</para>
			/// </summary>
			[GPValue("PIXELS")]
			[Description("Pixels")]
			Pixels,

			/// <summary>
			/// <para>Pixel scaling factor—Modify the request size by specifying a scaling factor. This option resamples the closest image by multiplying the raster pixel size (from cell size level table) with the pixel size factor.</para>
			/// </summary>
			[GPValue("PIXELSIZE_FACTOR")]
			[Description("Pixel scaling factor")]
			Pixel_scaling_factor,

		}

		/// <summary>
		/// <para>Blend Width Units</para>
		/// </summary>
		public enum BlendWidthUnitsEnum 
		{
			/// <summary>
			/// <para>Pixels—Measure using the number of pixels. This is the default.</para>
			/// </summary>
			[GPValue("PIXELS")]
			[Description("Pixels")]
			Pixels,

			/// <summary>
			/// <para>Ground units—Measure using the same units as the mosaic dataset.</para>
			/// </summary>
			[GPValue("GROUND_UNITS")]
			[Description("Ground units")]
			Ground_units,

		}

		/// <summary>
		/// <para>Update Existing Seamlines</para>
		/// </summary>
		public enum UpdateExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Only update items without seamlines. If any new items overlap with the previously created seamlines, the existing seamlines may be affected.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_EXISTING")]
			UPDATE_EXISTING,

			/// <summary>
			/// <para>Unchecked—Regenerates seamlines for all items and ignores existing seamlines, if any. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_EXISTING")]
			IGNORE_EXISTING,

		}

#endregion
	}
}
