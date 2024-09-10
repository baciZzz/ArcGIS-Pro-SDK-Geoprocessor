using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Feature Class Domain
    /// </summary>
    public class GPFeatureClassDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPFeatureClassDomain;

        /// <summary>
        /// Geometry Type
        /// </summary>
        public List<string> GeometryType { get; set; } = new List<string>();

        /// <summary>
        /// Feature Type
        /// </summary>
        public List<string> FeatureType { get; set; } = new List<string>();

        /// <summary>
        /// Has Z
        /// </summary>
        public bool Has_Z { get; set; } = false;

        /// <summary>
        /// Include Z
        /// </summary>
        public bool Include_Z { get; set; } = false;

        /// <summary>
        /// Portal Type
        /// </summary>
        public List<string> Portaltype { get; set; } = new List<string>();

    }


}

