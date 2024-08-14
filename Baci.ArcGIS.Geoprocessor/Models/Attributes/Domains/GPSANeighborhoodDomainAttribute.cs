using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GPSA Neighborhood Domain
    /// </summary>
    public class GPSANeighborhoodDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPSANeighborhoodDomain;

        /// <summary>
        /// Neighbour Type
        /// </summary>
        public List<string> NeighbourType { get; set; } = new List<string>();

	}
}
