using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.Net.ToolKit.ArcGISProGeoprocessor.Models
{
    /// <summary>
    /// ArcGIS Engine 10.2迁移 未进行兼容校验
    /// GP环境参数 => 及其接受的值
    /// .Net不区分大小写
    /// https://resources.arcgis.com/en/help/arcobjects-net/conceptualHelp/index.html#/Using_environment_settings/0001000001n5000000/
    /// https://resources.arcgis.com/en/help/arcobjects-net/conceptualHelp/#/Using_environment_settings/0001000001n5000000/
    /// </summary>
    public partial class GPEnviement
    {
        public const string Auto_Commit = "autoCommit";//"autoCommit";

        public const string Cartographic_Coordinate_System = "cartographicCoordinateSystem";//"cartographicCoordinateSystem";

        public const string Cell_size = "cellSize";//"cellSize";

        public const string Coincident_points = "coincidentPoints";//"coincidentPoints";

        public const string Compression = "compression";//"compression";

        public const string Output_CONFIG_Keyword = "configKeyword";//"configKeyword";

        public const string Precision_For_Derived_Coverages = "derivedPrecision";//"derivedPrecision";

        public const string Extent = "extent";//"extent";

        public const string Geographic_Transformations = "geographicTransformations";//"geographicTransformations";

        public const string Maintain_Spatial_Index = "maintainSpatialIndex";//"maintainSpatialIndex";

        public const string Mask = "mask";//"mask";

        public const string Output_M_Domain = "MDomain";//"MDomain";

        public const string M_Resolution = "MResolution";//"MResolution";

        public const string M_Tolerance = "MTolerance";//"MTolerance";

        public const string Precision_For_New_Coverages = "newPrecision";//"newPrecision";

        public const string Output_Coordinate_System = "outputCoordinateSystem";//"outputCoordinateSystem";

        public const string Output_has_M_Values = "outputMFlag";//"outputMFlag";

        public const string Output_has_Z_values = "outputZFlag";//"outputZFlag";

        public const string Default_output_Z_value = "outputZValue";//"outputZValue";

        public const string Level_Of_Comparison_Between_Projection_Files = "projectCompare";//"projectCompare";

        public const string Pyramid = "pyramid";//"pyramid";

        public const string Maintain_fully_qualified_field_names = "qualifiedFieldNames";//"qualifiedFieldNames";

        public const string Random_number_generator = "randomGenerator";//"randomGenerator";

        public const string Raster_statistics = "rasterStatistics";//"rasterStatistics";

        public const string Reference_Scale = "referenceScale";//"referenceScale";

        public const string Scratch_Workspace = "scratchWorkspace";//"scratchWorkspace";

        public const string Snap_Raster = "snapRaster";//"snapRaster";

        public const string Output_Spatial_Grid_1 = "spatialGrid1";//"spatialGrid1";

        public const string Output_Spatial_Grid_2 = "spatialGrid2";//"spatialGrid2";

        public const string Output_Spatial_Grid_3 = "spatialGrid3";//"spatialGrid3";

        public const string Terrain_Memory_Usage = "terrainMemoryUsage";//"terrainMemoryUsage";

        public const string Tile_size = "tileSize";//"tileSize";

        public const string TIN_storage_version = "tinSaveVersion";//"tinSaveVersion";

        public const string Current_Workspace = "workspace";//"workspace";

        public const string Output_XY_Domain = "XYDomain";//"XYDomain";

        public const string XY_Resolution = "XYResolution";//"XYResolution";

        public const string XY_Tolerance = "XYTolerance";//"XYTolerance";

        public const string Output_Z_Domain = "ZDomain";//"ZDomain";

        public const string Z_Resolution = "ZResolution";//"ZResolution";

        public const string Z_Tolerance = "ZTolerance";//"ZTolerance";




    }
}
