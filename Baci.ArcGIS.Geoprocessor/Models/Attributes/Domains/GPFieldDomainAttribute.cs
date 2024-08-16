using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// 
    /// </summary>
    public class GPFieldDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPFieldDomain;

        /// <summary>
        /// Field Type
        /// </summary>
        public List<string> FieldType { get; set; } = new List<string>();

        /// <summary>
        /// Exclude Fields like shape_area,shape_length or Predicted,StdError,Error,Stdd_Error,NormValue,Source_ID,Included
        /// </summary>
        [JsonProperty("Exclude.Field")]
        public List<string> ExcludeField { get; set; } = new List<string>();

        /// <summary>
        /// Key Fields (EMPTY or NONE or Shape.Z) Auto Add to the Combox or TextBox
        /// </summary>
        [JsonProperty("Key.Field")]
        public List<string> KeyField { get; set; } = new List<string>();

        /// <summary>
        /// GUID {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}
        /// </summary>
        public string GUID { get; set; } = string.Empty;

        /// <summary>
        /// Use Raster Fields
        /// </summary>
        public bool UseRasterFields { get; set; } = false;

    }
}
