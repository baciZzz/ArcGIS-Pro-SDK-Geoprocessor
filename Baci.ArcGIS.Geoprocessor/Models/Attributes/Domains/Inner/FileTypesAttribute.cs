using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// File Types Attribute
    /// </summary>
    internal class FileTypesAttribute : Attribute
    {
        /// <summary>
        /// File Types Attribute
        /// </summary>
        /// <param name="fileTypes"></param>
        public FileTypesAttribute(params string[] fileTypes)
        {
            FileTypes = fileTypes.ToList();
        }

        /// <summary>
        /// File Types
        /// </summary>
        public List<string> FileTypes { get; set; } = new List<string>();
    }
}
