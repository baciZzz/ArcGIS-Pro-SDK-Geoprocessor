using ArcGIS.Desktop.Core.Geoprocessing;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models
{
    /// <summary>
    /// The interface required by processes intended for use with the Geoprocessor.
    /// </summary>
    public interface IGPProcess
    {
        string DisplayName();

        string ToolName();

        string ExcuteName();

        string ToolboxDisplayName();

        string ToolboxAlise();

        string[] ValidEnvironments();

        object[] Parameters();

        /// <summary>
        /// Get GPResult
        /// </summary>
        /// <returns></returns>
        IGPResult GPResult();

        /// <summary>
        /// Set GPResult
        /// </summary>
        /// <param name="gPResult"></param>
        void SetGPResult(IGPResult gPResult);

        /// <summary>
        /// Get The Accept Environment Params
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> Environments();
    }
}
