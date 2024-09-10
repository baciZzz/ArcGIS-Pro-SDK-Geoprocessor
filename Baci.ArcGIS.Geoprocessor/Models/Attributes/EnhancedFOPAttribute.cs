using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes
{
    /// <summary>
    /// provides enhanced functionality or performance
    /// </summary>
    public class EnhancedFOPAttribute : Attribute
    {
        /// <summary>
        /// Type Which provides enhanced functionality or performance'
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public EnhancedFOPAttribute(Type type)
        {
            Type = type;
        }
    }
}
