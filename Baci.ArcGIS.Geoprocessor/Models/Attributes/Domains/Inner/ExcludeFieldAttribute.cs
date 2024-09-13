using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Exclude Field Attribute
    /// </summary>
    public class ExcludeFieldAttribute : Attribute
    {
        /// <summary>
        /// Exclude Field Attribute
        /// </summary>
        /// <param name="excludeField"></param>
        public ExcludeFieldAttribute(params string[] excludeField)
        {
            ExcludeField = excludeField.ToList();
        }

        /// <summary>
        /// Exclude Field
        /// </summary>
        public List<string> ExcludeField { get; set; } = new List<string>();
    }
}
