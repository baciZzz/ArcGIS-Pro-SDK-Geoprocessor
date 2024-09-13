using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Filters Attribute
    /// </summary>
    internal class FiltersAttribute:Attribute
    {
        /// <summary>
        /// Filters Attribute
        /// </summary>
        /// <param name="filters"></param>
        public FiltersAttribute(params string[] filters)
        {
            Filters=filters.ToList();
        }

        /// <summary>
        /// Filters
        /// </summary>
        public List<string> Filters { get; set; } = new List<string>();
    }
}
