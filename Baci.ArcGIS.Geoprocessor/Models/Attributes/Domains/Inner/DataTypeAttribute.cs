using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{

    /// <summary>
    /// Data Type Attribute
    /// </summary>
    public class DataTypeAttribute : Attribute
    {
        /// <summary>
        /// Data Type Attribute
        /// </summary>
        /// <param name="dataType"></param>
        public DataTypeAttribute(params string[] dataType)
        {
            DataType = dataType.ToList();
        }

        /// <summary>
        /// Data Types
        /// </summary>
        public List<string> DataType { get; set; } = new List<string>();
    }
}
