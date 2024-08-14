using ArcGIS.Desktop.Core.Geoprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models
{
    public abstract class AbstractGPProcess : IGPProcess
    {
        protected Dictionary<string, string> environments = new Dictionary<string, string>();

        public abstract string DisplayName { get; }

        public abstract string ToolName { get; }

        public abstract string ExcuteName { get; }

        public abstract string ToolboxDisplayName { get; }

        public abstract string ToolboxAlise { get; }

        public abstract string[] ValidEnvironments { get; }

        public abstract object[] Parameters { get; }

        //public IEnumerable<KeyValuePair<string, string>> Environments { get { return environments; } }
        public Dictionary<string, string> Environments { get { return environments; } }

        public IGPResult GPResult { get ; set ; }

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
