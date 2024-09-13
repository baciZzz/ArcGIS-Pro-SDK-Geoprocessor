using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Low Attribute
    /// </summary>
    public class LowAttribute : Attribute
    {
        /// <summary>
        /// Inclusive
        /// </summary>
        public bool Inclusive { get; set; } = false;

        /// <summary>
        /// Value
        /// </summary>
        public double Value { get; set; }
    }
}
