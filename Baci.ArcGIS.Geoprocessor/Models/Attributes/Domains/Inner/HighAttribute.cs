using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// High Attribute
    /// </summary>
    public class HighAttribute : Attribute
    {
        /// <summary>
        /// Allow
        /// </summary>
        public bool Allow { get; set; } = false;

        /// <summary>
        /// Value
        /// </summary>
        public double Value { get; set; }
    }
}
