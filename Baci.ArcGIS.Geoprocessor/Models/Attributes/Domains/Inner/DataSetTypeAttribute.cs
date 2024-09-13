using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Data Set Type Attribute
    /// </summary>
    internal class DataSetTypeAttribute : Attribute
    {
        /// <summary>
        /// Data Set Type Attribute
        /// </summary>
        /// <param name="dataSetType"></param>
        public DataSetTypeAttribute(params string[] dataSetType)
        {
            DataSetType = dataSetType.ToList();
        }

        /// <summary>
        /// Data Set Type
        /// </summary>
        public List<string> DataSetType { get; set; } = new List<string>();
    }
}
