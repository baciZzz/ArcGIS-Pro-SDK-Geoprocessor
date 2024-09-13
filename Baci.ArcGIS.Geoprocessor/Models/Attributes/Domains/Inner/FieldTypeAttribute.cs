using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Field Type Attribute
    /// </summary>
    public class FieldTypeAttribute : Attribute
    {
        /// <summary>
        /// Field Type Attribute
        /// </summary>
        /// <param name="fieldType"></param>
        public FieldTypeAttribute(params string[] fieldType)
        {
            FieldType = fieldType.ToList();
        }

        /// <summary>
        /// Field Types
        /// </summary>
        public List<string> FieldType { get; set; } = new List<string>();
    }
}
