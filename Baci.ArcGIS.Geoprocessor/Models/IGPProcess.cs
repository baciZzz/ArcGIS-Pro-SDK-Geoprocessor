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
        string DisplayName { get; }

        string ToolName { get; }

        string ExcuteName { get; }

        string ToolboxDisplayName { get; }

        string ToolboxAlise { get; }

        string[] ValidEnvironments { get; }

        object[] Parameters { get; }

        IGPResult GPResult { get; set; }

        Dictionary<string, string> Environments { get; }
    }
}
