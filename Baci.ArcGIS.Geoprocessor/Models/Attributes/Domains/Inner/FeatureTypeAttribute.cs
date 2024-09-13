using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Feature Type Attribute
    /// </summary>
    public class FeatureTypeAttribute : Attribute
    {
        /// <summary>
        /// Feature Type Attribute
        /// </summary>
        /// <param name="featureType"></param>
        public FeatureTypeAttribute(params string[] featureType)
        {
            FeatureType = featureType.ToList();
        }
        /// <summary>
        /// Feature Types
        /// </summary>
        public List<string> FeatureType { get; set; } = new List<string>();
    }
}
