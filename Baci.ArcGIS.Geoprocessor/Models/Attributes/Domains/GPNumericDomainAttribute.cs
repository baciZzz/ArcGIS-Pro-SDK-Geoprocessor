using Baci.ArcGIS.Geoprocessor.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Numeric Domain
    /// </summary>
    [GPNumericDomainAttribute()]
    public class GPNumericDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPNumericDomain;

        /// <summary>
        /// Allow Empty
        /// </summary>
        public bool AllowEmpty { get; set; } = false;

        /// <summary>
        /// Low Condition
        /// </summary>
        private LowCondtion Low { get; set; }

        /// <summary>
        /// High Condition
        /// </summary>
        public HighCondition High { get; set; }


    }

    /// <summary>
    /// Low Condtion
    /// </summary>
    public class LowCondtion
    {
        /// <summary>
        /// Inclusive
        /// </summary>
        public bool Inclusive { get; set; } = false;

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty("val")]
        public string Value { get; set; } = "0";
    }

    /// <summary>
    /// High Condition
    /// </summary>
    public class HighCondition
    {
        /// <summary>
        /// Allow
        /// </summary>
        public bool Allow { get; set; } = false;

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty("val")]
        public string Value { get; set; } = "0";
    }
}
