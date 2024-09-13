using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Portal Type Attribute
    /// </summary>
    public class PortalTypeAttribute : Attribute
    {
        /// <summary>
        /// Portal Type Attribute
        /// </summary>
        /// <param name="portalType"></param>
        public PortalTypeAttribute(params string[] portalType)
        {
            PortalType = portalType.ToList();
        }

        /// <summary>
        /// Portal Type
        /// </summary>
        public List<string> PortalType { get; set; }=new List<string>();
    }
}
