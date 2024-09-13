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
	/// <para>Add Rasters To Mosaic Dataset</para>
	/// <para>Add Rasters To Mosaic Dataset</para>
	/// <para>Adds raster datasets to a mosaic dataset from many sources, including a file, folder, table, or web service.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddRastersToMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The path and name of the mosaic dataset to which the raster data will be added.</para>
		/// </param>
		/// <param name="RasterType">
		/// <para>Raster Type</para>
		/// <para>The type of raster that will be added. The raster type is specific to imagery products. It identifies metadata, such as georeferencing, acquisition date, and sensor type, along with a raster format.</para>
		/// <para>If you are using a LAS, LAS Dataset, or Terrain raster type, a cell size must be specified on the Raster Type properties page.</para>
		/// <para>The Processing Templates drop-down list contains functions that will be applied to items that are added to the mosaic dataset and how, or in what order, they will be applied. You can use a single function, such as the Stretch function, or you can chain multiple functions together to create a more advanced product. Most raster types have several preexisting functions associated with them. Use this drop-down list to edit existing functions or add new functions to items that will be added to the mosaic dataset.</para>
		/// <para>To edit a template, select it in the Processing Templates drop-down list, and click Edit . Once you finish editing the template, click Save to update the template, or click Save As to save it as a new item in the drop-down list. To export a template to disk for use with other mosaic datasets, click the Export button .</para>
		/// <para>To create a template, click Create New Template in the Processing Templates drop-down list. For more information, see Raster function template.</para>
		/// <para>To import a function chain from disk or from the Raster Function pane, click Import in the Processing Templates drop-down list. If the template was created independently of the raster type template editor, you need to change the name of the primary input raster variable to Dataset. To do this, double-click the first function in the chain and click the Variables tab. Change the value in the Name field of the raster parameter to Dataset.</para>
		/// </param>
		/// <param name="InputPath">
		/// <para>Input Data</para>
		/// <para>Specifies the path and name of the input file, folder, raster dataset, mosaic dataset, table, or service.</para>
		/// <para>Not all input options will be available. The selected raster type determines the available options.</para>
		/// <para>Dataset—An ArcGIS geographic dataset, such as a raster or mosaic dataset in a geodatabase or table, will be used as input.</para>
		/// <para>Workspace—A folder containing multiple raster datasets will be used as input. The folder can contain subfolders.This option is affected by the Include Sub Folders and Input Data Filter parameters.</para>
		/// <para>File—One or more raster datasets stored in a folder on disk, an image service definition file (.ISDef), or a raster process definition file (.RPDef) will be used as input. Files that do not correspond to the raster type being added will be ignored. Do not use this option with file formats that are raster datasets, such as TIFF or MrSID files; use the Dataset input type instead.</para>
		/// <para>Service—A WCS, a map, an image service, or a web service layer file will be used as input.</para>
		/// </param>
		public AddRastersToMosaicDataset(object InMosaicDataset, object RasterType, object InputPath)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.RasterType = RasterType;
			this.InputPath = InputPath;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Rasters To Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName() => "Add Rasters To Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : AddRastersToMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "AddRastersToMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRastersToMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.AddRastersToMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "parallelProcessingFactor", "pyramid", "rasterStatistics", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, RasterType, InputPath, UpdateCellsizeRanges!, UpdateBoundary!, UpdateOverviews!, MaximumPyramidLevels!, MaximumCellSize!, MinimumDimension!, SpatialReference!, Filter!, SubFolder!, DuplicateItemsAction!, BuildPyramids!, CalculateStatistics!, BuildThumbnails!, OperationDescription!, ForceSpatialReference!, EstimateStatistics!, AuxInputs!, EnablePixelCache!, CacheLocation!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The path and name of the mosaic dataset to which the raster data will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Raster Type</para>
		/// <para>The type of raster that will be added. The raster type is specific to imagery products. It identifies metadata, such as georeferencing, acquisition date, and sensor type, along with a raster format.</para>
		/// <para>If you are using a LAS, LAS Dataset, or Terrain raster type, a cell size must be specified on the Raster Type properties page.</para>
		/// <para>The Processing Templates drop-down list contains functions that will be applied to items that are added to the mosaic dataset and how, or in what order, they will be applied. You can use a single function, such as the Stretch function, or you can chain multiple functions together to create a more advanced product. Most raster types have several preexisting functions associated with them. Use this drop-down list to edit existing functions or add new functions to items that will be added to the mosaic dataset.</para>
		/// <para>To edit a template, select it in the Processing Templates drop-down list, and click Edit . Once you finish editing the template, click Save to update the template, or click Save As to save it as a new item in the drop-down list. To export a template to disk for use with other mosaic datasets, click the Export button .</para>
		/// <para>To create a template, click Create New Template in the Processing Templates drop-down list. For more information, see Raster function template.</para>
		/// <para>To import a function chain from disk or from the Raster Function pane, click Import in the Processing Templates drop-down list. If the template was created independently of the raster type template editor, you need to change the name of the primary input raster variable to Dataset. To do this, double-click the first function in the chain and click the Variables tab. Change the value in the Name field of the raster parameter to Dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterBuilder()]
		public object RasterType { get; set; } = "Raster Dataset";

		/// <summary>
		/// <para>Input Data</para>
		/// <para>Specifies the path and name of the input file, folder, raster dataset, mosaic dataset, table, or service.</para>
		/// <para>Not all input options will be available. The selected raster type determines the available options.</para>
		/// <para>Dataset—An ArcGIS geographic dataset, such as a raster or mosaic dataset in a geodatabase or table, will be used as input.</para>
		/// <para>Workspace—A folder containing multiple raster datasets will be used as input. The folder can contain subfolders.This option is affected by the Include Sub Folders and Input Data Filter parameters.</para>
		/// <para>File—One or more raster datasets stored in a folder on disk, an image service definition file (.ISDef), or a raster process definition file (.RPDef) will be used as input. Files that do not correspond to the raster type being added will be ignored. Do not use this option with file formats that are raster datasets, such as TIFF or MrSID files; use the Dataset input type instead.</para>
		/// <para>Service—A WCS, a map, an image service, or a web service layer file will be used as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputPath { get; set; }

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// <para>Specifies whether the cell size ranges of each raster in the mosaic dataset will be calculated. These values are written to the attribute table in the minPS and maxPS fields.</para>
		/// <para>Checked—The cell size ranges will be calculated for all the rasters in the mosaic dataset. This is the default.</para>
		/// <para>Unchecked—The cell size ranges will not be calculated.</para>
		/// <para><see cref="UpdateCellsizeRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? UpdateCellsizeRanges { get; set; } = "true";

		/// <summary>
		/// <para>Update Boundary</para>
		/// <para>Specifies whether the boundary polygon of a mosaic dataset will be generated or updated. By default, the boundary merges all the footprint polygons to create a single boundary representing the extent of the valid pixels.</para>
		/// <para>Checked—The boundary will be generated or updated. This is the default.</para>
		/// <para>Unchecked—The boundary will not be generated or updated.</para>
		/// <para><see cref="UpdateBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? UpdateBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Update Overviews</para>
		/// <para>Specifies whether overviews for a mosaic dataset will be defined and generated.</para>
		/// <para>Checked—Overviews will be defined and generated.</para>
		/// <para>Unchecked—Overviews will not be defined or generated. This is the default.</para>
		/// <para><see cref="UpdateOverviewsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? UpdateOverviews { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Levels</para>
		/// <para>The maximum number of pyramid levels that will be used in the mosaic dataset. For example, a value of 2 will use only the first two pyramid levels from the source raster. Leaving this parameter blank or typing a value of -1 will build pyramids for all levels.</para>
		/// <para>This value can affect the display and number of overviews that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Raster Processing")]
		public object? MaximumPyramidLevels { get; set; }

		/// <summary>
		/// <para>Maximum Cell Size</para>
		/// <para>The maximum pyramid cell size that will be used in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Raster Processing")]
		public object? MaximumCellSize { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Rows or Columns</para>
		/// <para>The minimum dimensions of a raster pyramid that will be used in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Raster Processing")]
		public object? MinimumDimension { get; set; } = "1500";

		/// <summary>
		/// <para>Coordinate System for Input Data</para>
		/// <para>The spatial reference system of the input data.</para>
		/// <para>This should be specified if the data does not have a coordinate system; otherwise, the coordinate system of the mosaic dataset will be used. This can also be used to override the coordinate system of the input data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Input Data Options")]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Input Data Filter</para>
		/// <para>A filter for the data being added to the mosaic dataset. You can use SQL expressions to create the data filter. The wildcards for the filter work on the full path to the input data.</para>
		/// <para>The following SQL statement will select the rows in which the following object IDs match:</para>
		/// <para>OBJECTID IN (19745, 19680, 19681, 19744, 5932, 5931, 5889, 5890, 14551, 14552, 14590, 14591)</para>
		/// <para>To add only a TIFF image, add an asterisk before a file extension.</para>
		/// <para>*.TIF</para>
		/// <para>To add an image with the word sensor in the file path or file name, add an asterisk before and after the word sensor.</para>
		/// <para>*sensor2009*</para>
		/// <para>You can also use PERL syntax to create a data filter.</para>
		/// <para>REGEX:.*1923.*|.*1922.*</para>
		/// <para>REGEX:.*192[34567].*|.*194.*|.*195.*</para>
		/// <para>The following PERL syntax with multiple lexical groupings as part of the expression is not supported:</para>
		/// <para>REGEX:.* map_mean_.*(?:(?:[a-z0-9]*)_pptPct_(?:[0-9]|1[0-2]*?)_2[0-9]_*\w*).img</para>
		/// <para>Alternatively, you can use the following syntax:</para>
		/// <para>REGEX:.*map_mean_*[a-z0-9]*_pptPct_([0-9]|1[0-2])_2[0-9]*_\w*.img</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Input Data Options")]
		public object? Filter { get; set; }

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// <para>Specifies whether subfolders will be recursively explored.</para>
		/// <para>Checked—All subfolders will be explored for data. This is the default.</para>
		/// <para>Unchecked—Only the top-level folder will be explored for data.</para>
		/// <para><see cref="SubFolderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? SubFolder { get; set; } = "true";

		/// <summary>
		/// <para>Add New Datasets Only</para>
		/// <para>Specifies how duplicate rasters will be handled. A check will be performed to determine whether each raster has already been added, using the original path and file name. Choose the action to be performed when a duplicate path and file name are found.</para>
		/// <para>Allow duplicates—All rasters will be added even if they already exist in the mosaic dataset. This is the default.</para>
		/// <para>Exclude duplicates—Duplicate rasters will not be added.</para>
		/// <para>Overwrite duplicates—Duplicate rasters will overwrite existing rasters.</para>
		/// <para><see cref="DuplicateItemsActionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? DuplicateItemsAction { get; set; } = "ALLOW_DUPLICATES";

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// <para>Specifies whether pyramids will be built for each source raster.</para>
		/// <para>Unchecked—Pyramids will not be built. This is the default.</para>
		/// <para>Checked—Pyramids will be built.</para>
		/// <para><see cref="BuildPyramidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Raster Processing")]
		public object? BuildPyramids { get; set; } = "false";

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// <para>Specifies whether statistics will be calculated for each source raster.</para>
		/// <para>Unchecked—Statistics will not be calculated. This is the default.</para>
		/// <para>Checked—Statistics will be calculated.</para>
		/// <para><see cref="CalculateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Raster Processing")]
		public object? CalculateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// <para>Specifies whether thumbnails will be built for each source raster.</para>
		/// <para>Unchecked—Thumbnails will not be built. This is the default.</para>
		/// <para>Checked—Thumbnails will be built.</para>
		/// <para><see cref="BuildThumbnailsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? BuildThumbnails { get; set; } = "false";

		/// <summary>
		/// <para>Operation Description</para>
		/// <para>The description used to represent the operation of adding raster data. It will be added to the raster type table, which can be used as part of a search or as a reference at another time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Post-processing")]
		public object? OperationDescription { get; set; }

		/// <summary>
		/// <para>Force this Coordinate System for Input Data</para>
		/// <para>Specifies whether the Coordinate System for Input Data parameter value will be used for all the rasters when loading data into the mosaic dataset. This option does not reproject the data; it uses the coordinate system defined in the tool to construct items in the mosaic dataset. The extent of the image will be used, but the projection will be overwritten.</para>
		/// <para>Unchecked—The coordinate system of each raster data will be used when loading data. This is the default. If unchecked and the input image does not have a coordinate system (that is, it&apos;s unknown), the mosaic dataset coordinate system will be used in constructing mosaic dataset items. If the image has a coordinate system, that coordinate system will be used.</para>
		/// <para>Checked—The coordinate system specified in the Coordinate System for Input Data parameter will be used for each raster dataset when loading data.</para>
		/// <para><see cref="ForceSpatialReferenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? ForceSpatialReference { get; set; } = "false";

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// <para>Specifies whether statistics will be estimated on the mosaic dataset for faster rendering and processing at the mosaic dataset level.</para>
		/// <para>Unchecked—Statistics will not be estimated. Statistics generated from each item in the mosaic dataset will be used for display and processing. This is the default.</para>
		/// <para>Checked—Statistics will be estimated at the mosaic dataset level. This will use the distribution of pixels to display the mosaic dataset rather than the distribution of the source item in the mosaic dataset.</para>
		/// <para><see cref="EstimateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Mosaic Post-processing")]
		public object? EstimateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>Auxiliary Inputs</para>
		/// <para>The raster type settings that will be defined on the Raster Type Properties page. The settings in this parameter will override the settings defined on the Raster Type Properties page.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Advanced Input Data Options")]
		public object? AuxInputs { get; set; }

		/// <summary>
		/// <para>Enable Pixel Cache</para>
		/// <para>Specifies whether the pixel cache will be generated for faster display and processing of the mosaic dataset.</para>
		/// <para>Unchecked—The pixel cache will not be generated. This is the default.</para>
		/// <para>Checked—The pixel cache will be generated.</para>
		/// <para><see cref="EnablePixelCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? EnablePixelCache { get; set; } = "false";

		/// <summary>
		/// <para>Pixel Cache Location</para>
		/// <para>The location of the pixel cache. If no location is defined, the cache is written to C:\Users\&lt;Username&gt;\AppData\Local\ESRI\rasterproxies\.</para>
		/// <para>Once the location is defined, you do not need to redefine the path when adding new rasters to the mosaic dataset. You only need to check the Enable Pixel Cache parameter (enable_pixel_cache = &quot;USE_PIXEL_CACHE&quot; in Python) when adding the new data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Advanced Input Data Options")]
		public object? CacheLocation { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRastersToMosaicDataset SetEnviroment(object? extent = null , object? geographicTransformations = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Cell Size Ranges</para>
		/// </summary>
		public enum UpdateCellsizeRangesEnum 
		{
			/// <summary>
			/// <para>Checked—The cell size ranges will be calculated for all the rasters in the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_CELL_SIZES")]
			UPDATE_CELL_SIZES,

			/// <summary>
			/// <para>Unchecked—The cell size ranges will not be calculated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CELL_SIZES")]
			NO_CELL_SIZES,

		}

		/// <summary>
		/// <para>Update Boundary</para>
		/// </summary>
		public enum UpdateBoundaryEnum 
		{
			/// <summary>
			/// <para>Checked—The boundary will be generated or updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_BOUNDARY")]
			UPDATE_BOUNDARY,

			/// <summary>
			/// <para>Unchecked—The boundary will not be generated or updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

		/// <summary>
		/// <para>Update Overviews</para>
		/// </summary>
		public enum UpdateOverviewsEnum 
		{
			/// <summary>
			/// <para>Checked—Overviews will be defined and generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_OVERVIEWS")]
			UPDATE_OVERVIEWS,

			/// <summary>
			/// <para>Unchecked—Overviews will not be defined or generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERVIEWS")]
			NO_OVERVIEWS,

		}

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// </summary>
		public enum SubFolderEnum 
		{
			/// <summary>
			/// <para>Checked—All subfolders will be explored for data. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SUBFOLDERS")]
			SUBFOLDERS,

			/// <summary>
			/// <para>Unchecked—Only the top-level folder will be explored for data.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUBFOLDERS")]
			NO_SUBFOLDERS,

		}

		/// <summary>
		/// <para>Add New Datasets Only</para>
		/// </summary>
		public enum DuplicateItemsActionEnum 
		{
			/// <summary>
			/// <para>Allow duplicates—All rasters will be added even if they already exist in the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("ALLOW_DUPLICATES")]
			[Description("Allow duplicates")]
			Allow_duplicates,

			/// <summary>
			/// <para>Exclude duplicates—Duplicate rasters will not be added.</para>
			/// </summary>
			[GPValue("EXCLUDE_DUPLICATES")]
			[Description("Exclude duplicates")]
			Exclude_duplicates,

			/// <summary>
			/// <para>Overwrite duplicates—Duplicate rasters will overwrite existing rasters.</para>
			/// </summary>
			[GPValue("OVERWRITE_DUPLICATES")]
			[Description("Overwrite duplicates")]
			Overwrite_duplicates,

		}

		/// <summary>
		/// <para>Build Raster Pyramids</para>
		/// </summary>
		public enum BuildPyramidsEnum 
		{
			/// <summary>
			/// <para>Checked—Pyramids will be built.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_PYRAMIDS")]
			BUILD_PYRAMIDS,

			/// <summary>
			/// <para>Unchecked—Pyramids will not be built. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PYRAMIDS")]
			NO_PYRAMIDS,

		}

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// </summary>
		public enum CalculateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be calculated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CALCULATE_STATISTICS")]
			CALCULATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be calculated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

		/// <summary>
		/// <para>Build Thumbnails</para>
		/// </summary>
		public enum BuildThumbnailsEnum 
		{
			/// <summary>
			/// <para>Checked—Thumbnails will be built.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_THUMBNAILS")]
			BUILD_THUMBNAILS,

			/// <summary>
			/// <para>Unchecked—Thumbnails will not be built. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_THUMBNAILS")]
			NO_THUMBNAILS,

		}

		/// <summary>
		/// <para>Force this Coordinate System for Input Data</para>
		/// </summary>
		public enum ForceSpatialReferenceEnum 
		{
			/// <summary>
			/// <para>Checked—The coordinate system specified in the Coordinate System for Input Data parameter will be used for each raster dataset when loading data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE_SPATIAL_REFERENCE")]
			FORCE_SPATIAL_REFERENCE,

			/// <summary>
			/// <para>Unchecked—The coordinate system of each raster data will be used when loading data. This is the default. If unchecked and the input image does not have a coordinate system (that is, it&apos;s unknown), the mosaic dataset coordinate system will be used in constructing mosaic dataset items. If the image has a coordinate system, that coordinate system will be used.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FORCE_SPATIAL_REFERENCE")]
			NO_FORCE_SPATIAL_REFERENCE,

		}

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// </summary>
		public enum EstimateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be estimated at the mosaic dataset level. This will use the distribution of pixels to display the mosaic dataset rather than the distribution of the source item in the mosaic dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE_STATISTICS")]
			ESTIMATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be estimated. Statistics generated from each item in the mosaic dataset will be used for display and processing. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STATISTICS")]
			NO_STATISTICS,

		}

		/// <summary>
		/// <para>Enable Pixel Cache</para>
		/// </summary>
		public enum EnablePixelCacheEnum 
		{
			/// <summary>
			/// <para>Checked—The pixel cache will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_PIXEL_CACHE")]
			USE_PIXEL_CACHE,

			/// <summary>
			/// <para>Unchecked—The pixel cache will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PIXEL_CACHE")]
			NO_PIXEL_CACHE,

		}

#endregion
	}
}
