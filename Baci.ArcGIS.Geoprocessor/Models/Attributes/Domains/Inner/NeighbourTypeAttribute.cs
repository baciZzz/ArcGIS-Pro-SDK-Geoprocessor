using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Neighbour Type Attribute
    /// </summary>
    public class NeighbourTypeAttribute : Attribute
    {
        /// <summary>
        /// Neighbour Type Attribute
        /// </summary>
        /// <param name="neighbourType"></param>
        public NeighbourTypeAttribute(params string[] neighbourType)
        {
            NeighbourType = neighbourType.ToList();
        }

        /// <summary>
        /// Neighbour Type
        /// </summary>
        public List<string> NeighbourType = new List<string>();
    }
}
