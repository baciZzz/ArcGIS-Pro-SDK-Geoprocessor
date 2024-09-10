using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum DataTypeEnum
    {
        /// <summary>
        /// 
        /// </summary>
        analysis_cell_size,
        /// <summary>
        /// 
        /// </summary>
        DEAddressLocator,
        /// <summary>
        /// 
        /// </summary>
        DEBimFileWorkspace,
        /// <summary>
        /// 
        /// </summary>
        DECadDrawingDataset,
        /// <summary>
        /// 
        /// </summary>
        DEDatasetType,
        /// <summary>
        /// 
        /// </summary>
        DEDbaseTable,
        /// <summary>
        /// 
        /// </summary>
        DEFeatureClass,
        /// <summary>
        /// 
        /// </summary>
        DEFeatureDataset,
        /// <summary>
        /// 
        /// </summary>
        DEFile,
        /// <summary>
        /// 
        /// </summary>
        DEFolder,
        /// <summary>
        /// 
        /// </summary>
        DEGeoDataServer,
        /// <summary>
        /// 
        /// </summary>
        DEGeoDatasetType,
        /// <summary>
        /// 
        /// </summary>
        DEGeometricNetwork,
        /// <summary>
        /// 
        /// </summary>
        DEImageServer,
        /// <summary>
        /// 
        /// </summary>
        DELasDataset,
        /// <summary>
        /// 
        /// </summary>
        DELayer,
        /// <summary>
        /// 
        /// </summary>
        DEMapServer,
        /// <summary>
        /// 
        /// </summary>
        DEMosaicDataset,
        /// <summary>
        /// 
        /// </summary>
        DENetworkDataset,
        /// <summary>
        /// 
        /// </summary>
        DEParcelDataset,
        /// <summary>
        /// 
        /// </summary>
        DERasterDataset,
        /// <summary>
        /// 
        /// </summary>
        DERelationshipClass,
        /// <summary>
        /// 
        /// </summary>
        DEServerConnection,
        /// <summary>
        /// 
        /// </summary>
        DEShapeFile,
        /// <summary>
        /// 
        /// </summary>
        DETable,
        /// <summary>
        /// 
        /// </summary>
        DETerrain,
        /// <summary>
        /// 
        /// </summary>
        DETextFile,
        /// <summary>
        /// 
        /// </summary>
        DETin,
        /// <summary>
        /// 
        /// </summary>
        DEToolbox,
        /// <summary>
        /// 
        /// </summary>
        DETopology,
        /// <summary>
        /// 
        /// </summary>
        DETraceNetwork,
        /// <summary>
        /// 
        /// </summary>
        DEType,
        /// <summary>
        /// 
        /// </summary>
        DEUtilityNetwork,
        /// <summary>
        /// 
        /// </summary>
        DEWCSCoverage,
        /// <summary>
        /// 
        /// </summary>
        DEWMSMap,
        /// <summary>
        /// 
        /// </summary>
        DEWorkspace,
        /// <summary>
        /// 
        /// </summary>
        Field,
        /// <summary>
        /// 
        /// </summary>
        FMEDestDatasetType,
        /// <summary>
        /// 
        /// </summary>
        FMESourceDatasetType,
        /// <summary>
        /// 
        /// </summary>
        GP3DAInterpolate,
        /// <summary>
        /// 
        /// </summary>
        GPAnnotationLayer,
        /// <summary>
        /// 
        /// </summary>
        GPArealUnit,
        /// <summary>
        /// 
        /// </summary>
        GPBoolean,
        /// <summary>
        /// 
        /// </summary>
        GPBuildingLayer,
        /// <summary>
        /// 
        /// </summary>
        GPBuildingSceneLayer,
        /// <summary>
        /// 
        /// </summary>
        GPCadastralFabricLayer,
        /// <summary>
        /// 
        /// </summary>
        GPCalculatorExpression,
        /// <summary>
        /// 
        /// </summary>
        GPCellSizeXY,
        /// <summary>
        /// 
        /// </summary>
        GPComposite,
        /// <summary>
        /// 
        /// </summary>
        GPCompositeLayer,
        /// <summary>
        /// 
        /// </summary>
        GPCoordinateSystem,
        /// <summary>
        /// 
        /// </summary>
        GPDate,
        /// <summary>
        /// 
        /// </summary>
        GPDiagramLayer,
        /// <summary>
        /// 
        /// </summary>
        GPDimensionLayer,
        /// <summary>
        /// 
        /// </summary>
        GPDouble,
        /// <summary>
        /// 
        /// </summary>
        GPEncryptedString,
        /// <summary>
        /// 
        /// </summary>
        GPEnvelope,
        /// <summary>
        /// 
        /// </summary>
        GPExtent,
        /// <summary>
        /// 
        /// </summary>
        GPFeatureLayer,
        /// <summary>
        /// 
        /// </summary>
        GPFeatureRecordSetLayer,
        /// <summary>
        /// 
        /// </summary>
        GPFieldInfo,
        /// <summary>
        /// 
        /// </summary>
        GPFieldMapping,
        /// <summary>
        /// 
        /// </summary>
        GPGALayer,
        /// <summary>
        /// 
        /// </summary>
        GPGASearchNeighborhood,
        /// <summary>
        /// 
        /// </summary>
        GPGAValueTable,
        /// <summary>
        /// 
        /// </summary>
        GPGraph,
        /// <summary>
        /// 
        /// </summary>
        GPGraphicsLayer,
        /// <summary>
        /// 
        /// </summary>
        GPGroupLayer,
        /// <summary>
        /// 
        /// </summary>
        GPInternetTiledLayer,
        /// <summary>
        /// 
        /// </summary>
        GPKMLLayer,
        /// <summary>
        /// 
        /// </summary>
        GPLasDatasetLayer,
        /// <summary>
        /// 
        /// </summary>
        GPLayer,
        /// <summary>
        /// 
        /// </summary>
        GPLayout,
        /// <summary>
        /// 
        /// </summary>
        GPLinearUnit,
        /// <summary>
        /// 
        /// </summary>
        GPLong,
        /// <summary>
        /// 
        /// </summary>
        GPMap,
        /// <summary>
        /// 
        /// </summary>
        GPMapServerLayer,
        /// <summary>
        /// 
        /// </summary>
        GPMosaicLayer,
        /// <summary>
        /// 
        /// </summary>
        GPMultiValue,
        /// <summary>
        /// 
        /// </summary>
        GPNAHierarchySettings,
        /// <summary>
        /// 
        /// </summary>
        GPNALayer,
        /// <summary>
        /// 
        /// </summary>
        GPNetworkDatasetLayer,
        /// <summary>
        /// 
        /// </summary>
        GPNetworkDataSource,
        /// <summary>
        /// 
        /// </summary>
        GPParcelLayer,
        /// <summary>
        /// 
        /// </summary>
        GPPoint,
        /// <summary>
        /// 
        /// </summary>
        GPRasterBuilder,
        /// <summary>
        /// 
        /// </summary>
        GPRasterCalculatorExpression,
        /// <summary>
        /// 
        /// </summary>
        GPRasterCatalogLayer,
        /// <summary>
        /// 
        /// </summary>
        GPRasterFormulated,
        /// <summary>
        /// 
        /// </summary>
        GPRasterLayer,
        /// <summary>
        /// 
        /// </summary>
        GPRecordSet,
        /// <summary>
        /// 
        /// </summary>
        GPReport,
        /// <summary>
        /// 
        /// </summary>
        GPRouteMeasureEventProperties,
        /// <summary>
        /// 
        /// </summary>
        GPSAExtractValues,
        /// <summary>
        /// 
        /// </summary>
        GPSAFuzzyFunction,
        /// <summary>
        /// 
        /// </summary>
        GPSAGDBEnvCompression,
        /// <summary>
        /// 
        /// </summary>
        GPSAGDBEnvPyramid,
        /// <summary>
        /// 
        /// </summary>
        GPSAGDBEnvTileSize,
        /// <summary>
        /// 
        /// </summary>
        GPSAGeoData,
        /// <summary>
        /// 
        /// </summary>
        GPSAHorizontalFactor,
        /// <summary>
        /// 
        /// </summary>
        GPSAMapAlgebraExp,
        /// <summary>
        /// 
        /// </summary>
        GPSANeighborhood,
        /// <summary>
        /// 
        /// </summary>
        GPSARadius,
        /// <summary>
        /// 
        /// </summary>
        GPSARemap,
        /// <summary>
        /// GPSASemiVariogram
        /// </summary>
        GPSASemiVariogram,
        /// <summary>
        /// GP SA Time Configuration
        /// </summary>
        GPSATimeConfiguration,
        /// <summary>
        /// GP SA Topo Features
        /// </summary>
        GPSATopoFeatures,
        /// <summary>
        /// GP SA Transformation Function
        /// </summary>
        GPSATransformationFunction,
        /// <summary>
        /// GP SA Vertical Factor
        /// </summary>
        GPSAVerticalFactor,
        /// <summary>
        /// GP SA Weighted Overlay Table
        /// </summary>
        GPSAWeightedOverlayTable,
        /// <summary>
        /// GP SA Weighted Sum
        /// </summary>
        GPSAWeightedSum,
        /// <summary>
        /// GP Scene Service Layer
        /// </summary>
        GPSceneServiceLayer,
        /// <summary>
        /// GP Spatial Reference
        /// </summary>
        GPSpatialReference,
        /// <summary>
        /// GP SQL Expression
        /// </summary>
        GPSQLExpression,
        /// <summary>
        /// GP String
        /// </summary>
        GPString,
        /// <summary>
        /// GP String Hidden
        /// </summary>
        GPStringHidden,
        /// <summary>
        /// GP Table View
        /// </summary>
        GPTableView,
        /// <summary>
        /// GP Terrain Layer
        /// </summary>
        GPTerrainLayer,
        /// <summary>
        /// GP Time Unit
        /// </summary>
        GPTimeUnit,
        /// <summary>
        /// GP Tin Layer
        /// </summary>
        GPTinLayer,
        /// <summary>
        /// GP Topology Layer
        /// </summary>
        GPTopologyLayer,
        /// <summary>
        /// GP Trace Network Layer
        /// </summary>
        GPTraceNetworkLayer,
        /// <summary>
        /// GP Type
        /// </summary>
        GPType,
        /// <summary>
        /// GP Utility Network Layer
        /// </summary>
        GPUtilityNetworkLayer,
        /// <summary>
        /// GP Value Table
        /// </summary>
        GPValueTable,
        /// <summary>
        /// GP Variant
        /// </summary>
        GPVariant,
        /// <summary>
        /// GP Vector Layer
        /// </summary>
        GPVectorLayer,
        /// <summary>
        /// GP Voxel Layer
        /// </summary>
        GPVoxelLayer,
        /// <summary>
        /// NA Class Field Map
        /// </summary>
        NAClassFieldMap,
        /// <summary>
        /// Network Travel Mode
        /// </summary>
        NetworkTravelMode,

    }
}
