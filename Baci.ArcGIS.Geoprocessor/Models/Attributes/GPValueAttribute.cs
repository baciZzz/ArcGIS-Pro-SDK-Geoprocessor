using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes
{
    /// <summary>
    /// GP Value Attribute
    /// </summary>
    public class GPValueAttribute : Attribute
    {
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public GPValueAttribute(string value) { Value = value; }
    }
}
