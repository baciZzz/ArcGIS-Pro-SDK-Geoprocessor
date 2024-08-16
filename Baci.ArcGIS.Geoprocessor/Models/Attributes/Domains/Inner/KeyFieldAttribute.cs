using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Key Field Attribute
    /// </summary>
    internal class KeyFieldAttribute:Attribute
    {
        /// <summary>
        /// Key Field Attribute
        /// </summary>
        /// <param name="keyField"></param>
        public KeyFieldAttribute(params string[] keyField)
        {
            KeyField=keyField.ToList();
        }

        /// <summary>
        /// Key Field
        /// </summary>
        public List<string> KeyField = new List<string>();
    }
}
