using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Map Type Attribute
    /// </summary>
    public class MapTypeAttribute : Attribute
    {
        /// <summary>
        /// Map Type Attribute
        /// </summary>
        /// <param name="mapType"></param>
        public MapTypeAttribute(params string[] mapType)
        {
            MapType = mapType.ToList();
        }

        /// <summary>
        /// Map Type
        /// </summary>
        public List<string> MapType { get; set; } = new List<string>();
    }
}
