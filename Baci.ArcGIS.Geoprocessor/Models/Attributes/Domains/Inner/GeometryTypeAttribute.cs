using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Geometry Type Attribute
    /// </summary>
    public class GeometryTypeAttribute : Attribute
    {
        /// <summary>
        /// Geometry Type Attribute
        /// </summary>
        /// <param name="geometryType"></param>
        public GeometryTypeAttribute(params string[] geometryType)
        {
            GeometryType = geometryType.ToList();
        }

        /// <summary>
        /// Geometry Types
        /// </summary>
        public List<string> GeometryType = new List<string>();
    }
}
