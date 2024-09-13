using ArcGIS.Desktop.Core.Geoprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models
{
    /// <summary>
    /// AbstractGPProcess
    /// </summary>
    public abstract class AbstractGPProcess : IGPProcess
    {
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, string> environments = new Dictionary<string, string>();

        /// <summary>
        /// Display Name
        /// </summary>
        /// <returns></returns>
        public abstract string DisplayName();

        /// <summary>
        /// Tool Name
        /// </summary>
        /// <returns></returns>
        public abstract string ToolName();

        /// <summary>
        /// Excute Name
        /// </summary>
        /// <returns></returns>
        public abstract string ExcuteName();

        /// <summary>
        /// Toolbox Display Name
        /// </summary>
        /// <returns></returns>
        public abstract string ToolboxDisplayName();

        /// <summary>
        /// Toolbox Alise
        /// </summary>
        /// <returns></returns>
        public abstract string ToolboxAlise();

        /// <summary>
        /// Valid Environments
        /// </summary>
        /// <returns></returns>
        public abstract string[] ValidEnvironments();

        /// <summary>
        /// Parameters
        /// </summary>
        /// <returns></returns>
        public abstract object[] Parameters();

        /// <summary>
        /// Environments
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> Environments() => environments;

        private IGPResult result = null;

        /// <summary>
        /// GPResult
        /// </summary>
        /// <returns></returns>
        public IGPResult GPResult() => result;

        /// <summary>
        /// Set GPResult
        /// </summary>
        /// <returns></returns>
        public void SetGPResult(IGPResult gPResult)
        {
            result = gPResult;
        }

        protected void SetEnv(object? workspace = null, object? packageWorkspace = null, object? scratchFolder = null, object? scratchGDB = null,
            object? scratchWorkspace = null, object? outputCoordinateSystem = null, object? geographicTransformations = null, object? extent = null,
            int? retryOnFailures = null, object? parallelProcessingFactor = null, int? recycleProcessingWorkers = null, object? cellAlignment = null,
            object? cellSize = null, object? cellSizeProjectionMethod = null, object? mask = null, object? snapRaster = null, object? configKeyword = null,
            int? autoCommit = null, bool? maintainAttachments = null, bool? maintainSpatialIndex = null, bool? preserveGlobalIds = null, bool? transferGDBAttributeProperties = null,
            bool? qualifiedFieldNames = null, bool? transferDomains = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null,
            object? MDomain = null, object? outputMFlag = null, double? MTolerance = null, double? MResolution = null, object? ZDomain = null, double? outputZValue = null,
            object? outputZFlag = null, object? ZResolution = null, object? ZTolerance = null, object? randomGenerator = null, object? cartographicCoordinateSystem = null,
            double? referenceScale = null, object? cartographicPartitions = null, int? annotationTextStringFieldLength = null, object? pyramid = null,
            object? rasterStatistics = null, object? compression = null, object? tileSize = null, object? resamplingMethod = null, object? nodata = null,
            bool? terrainMemoryUsage = null, object? tinSaveVersion = null, object? coincidentPoints = null, object? S100FeatureCatalogueFile = null,
            object? processorType = null, int? gpuId = null, string? processingServer = null, string? processingServerUser = null, object? processingServerPassword = null,
            bool? matchMultidimensionalVariable = null, bool? unionDimension = null, object? baDataSource = null, object? baNetworkSource = null,
            bool? baUseDetailedAggregation = null, bool? maintainCurveSegments = null, bool? overwriteoutput = null)
        {
            var env = Geoprocessing.MakeEnvironmentArray(workspace, packageWorkspace, scratchFolder, scratchGDB,
             scratchWorkspace, outputCoordinateSystem, geographicTransformations, extent,
             retryOnFailures, parallelProcessingFactor, recycleProcessingWorkers, cellAlignment,
             cellSize, cellSizeProjectionMethod, mask, snapRaster, configKeyword,
             autoCommit, maintainAttachments, maintainSpatialIndex, preserveGlobalIds, transferGDBAttributeProperties,
             qualifiedFieldNames, transferDomains, XYDomain, XYResolution, XYTolerance,
             MDomain, outputMFlag, MTolerance, MResolution, ZDomain, outputZValue,
             outputZFlag, ZResolution, ZTolerance, randomGenerator, cartographicCoordinateSystem,
             referenceScale, cartographicPartitions, annotationTextStringFieldLength, pyramid,
             rasterStatistics, compression, tileSize, resamplingMethod, nodata,
             terrainMemoryUsage, tinSaveVersion, coincidentPoints, S100FeatureCatalogueFile,
             processorType, gpuId, processingServer, processingServerUser, processingServerPassword,
             matchMultidimensionalVariable, unionDimension, baDataSource, baNetworkSource,
             baUseDetailedAggregation, maintainCurveSegments, overwriteoutput);

            foreach (var item in env)
            {
                if (!environments.ContainsKey(item.Key))
                    environments.Add(item.Key, item.Value);
                else
                    environments[item.Key] = item.Value;
            }
        }
    }
}
