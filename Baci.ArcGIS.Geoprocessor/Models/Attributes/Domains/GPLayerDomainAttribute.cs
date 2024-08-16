using ArcGIS.Core.Geometry;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Layer Domain
    /// </summary>
    public class GPLayerDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPLayerDomain;

        /// <summary>
        /// Geometry Type
        /// </summary>
        public List<string> GeometryType { get; set; } = new List<string>();

    }
}
