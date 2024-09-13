using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Remap Type Attribute
    /// </summary>
    public class RemapTypeAttribute:Attribute
    {
        /// <summary>
        /// Remap Type Attribute
        /// </summary>
        /// <param name="remapType"></param>
        public RemapTypeAttribute(params string[] remapType)
        {
            RemapType=remapType.ToList();
        }

        /// <summary>
        /// Remap Type
        /// </summary>
        public List<string> RemapType { get; set; }= new List<string>();
    }
}
