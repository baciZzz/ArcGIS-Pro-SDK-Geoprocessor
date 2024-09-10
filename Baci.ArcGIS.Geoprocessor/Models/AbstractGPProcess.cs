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


        /// <summary>
        /// SetEnv
        /// </summary>
        /// <param name="autoCommit"></param>
        /// <param name="XYResolution"></param>
        /// <param name="XYDomain"></param>
        /// <param name="scratchWorkspace"></param>
        /// <param name="cartographicPartitions"></param>
        /// <param name="terrainMemoryUsage"></param>
        /// <param name="MTolerance"></param>
        /// <param name="compression"></param>
        /// <param name="coincidentPoints"></param>
        /// <param name="randomGenerator"></param>
        /// <param name="outputCoordinateSystem"></param>
        /// <param name="overwriteoutput"></param>
        /// <param name="rasterStatistics"></param>
        /// <param name="ZDomain"></param>
        /// <param name="transferDomains"></param>
        /// <param name="resamplingMethod"></param>
        /// <param name="snapRaster"></param>
        /// <param name="cartographicCoordinateSystem"></param>
        /// <param name="configKeyword"></param>
        /// <param name="outputZFlag"></param>
        /// <param name="qualifiedFieldNames"></param>
        /// <param name="tileSize"></param>
        /// <param name="parallelProcessingFactor"></param>
        /// <param name="pyramid"></param>
        /// <param name="referenceScale"></param>
        /// <param name="extent"></param>
        /// <param name="XYTolerance"></param>
        /// <param name="tinSaveVersion"></param>
        /// <param name="nodata"></param>
        /// <param name="MDomain"></param>
        /// <param name="cellSize"></param>
        /// <param name="outputZValue"></param>
        /// <param name="outputMFlag"></param>
        /// <param name="geographicTransformations"></param>
        /// <param name="ZResolution"></param>
        /// <param name="mask"></param>
        /// <param name="maintainSpatialIndex"></param>
        /// <param name="workspace"></param>
        /// <param name="MResolution"></param>
        /// <param name="ZTolerance"></param>
        protected void SetEnv(int? autoCommit = null, object XYResolution = null, object XYDomain = null, object scratchWorkspace = null,
            object cartographicPartitions = null, object terrainMemoryUsage = null, object MTolerance = null, object compression = null,
            object coincidentPoints = null, object randomGenerator = null, object outputCoordinateSystem = null, bool? overwriteoutput = null,
            object rasterStatistics = null, object ZDomain = null, bool? transferDomains = null, object resamplingMethod = null, object snapRaster = null,
            object cartographicCoordinateSystem = null, object configKeyword = null, object outputZFlag = null, bool? qualifiedFieldNames = null,
            double[] tileSize = null, object parallelProcessingFactor = null, object pyramid = null, object referenceScale = null, object extent = null,
            object XYTolerance = null, object tinSaveVersion = null, object nodata = null, object MDomain = null, object cellSize = null,
            object outputZValue = null, object outputMFlag = null, object geographicTransformations = null, object ZResolution = null,
            object mask = null, bool? maintainSpatialIndex = null, object workspace = null, object MResolution = null, object ZTolerance = null)
        {
            var env = Geoprocessing.MakeEnvironmentArray(autoCommit, XYResolution, XYDomain, scratchWorkspace,
                cartographicPartitions, terrainMemoryUsage, MTolerance, compression,
                coincidentPoints, randomGenerator, outputCoordinateSystem, overwriteoutput,
                rasterStatistics, ZDomain, transferDomains, resamplingMethod, snapRaster,
                cartographicCoordinateSystem, configKeyword, outputZFlag, qualifiedFieldNames,
                tileSize, parallelProcessingFactor, pyramid, referenceScale, extent,
                XYTolerance, tinSaveVersion, nodata, MDomain, cellSize,
                outputZValue, outputMFlag, geographicTransformations, ZResolution,
                mask, maintainSpatialIndex, workspace, MResolution, ZTolerance);

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
