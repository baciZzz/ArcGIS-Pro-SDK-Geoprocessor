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


        private LowCondtion low = null;

        /// <summary>
        /// Low Condtion
        /// </summary>
        public LowCondtion Low { get { return low; } set { low = value; } }

        public bool Inclusive
        {
            set
            {
                if (low == null) low = new LowCondtion();
                low.Inclusive = value;
            }
        }

        public string MixVlaue
        {
            set
            {
                if (low == null) low = new LowCondtion();
                low.Value = value;
            }
        }

        private HighCondition high = null;

        /// <summary>
        /// High Condition
        /// </summary>
        public HighCondition High { get { return high; } set { high = value; } }


        public bool Allow
        {
            set
            {
                if (high == null) high = new HighCondition();
                high.Allow = value;
            }
        }
        public string MaxVlaue
        {
            set
            {
                if (high == null) high = new HighCondition();
                high.Value = value;
            }
        }


    }

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
