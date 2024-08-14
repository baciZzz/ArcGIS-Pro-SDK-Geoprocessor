using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GPGA Search Neighborhood Domain
    /// </summary>
    public class GPGASearchNeighborhoodDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPGASearchNeighborhoodDomain;

		/// <summary>
		/// Chordal Distance
		/// </summary>
		public object ChordalDistance { get; set; } = false;

        /// <summary>
        /// Neighbour Type
        /// </summary>
        public List<string> NeighbourType  { get; set; }=new List<string>();

	}
}
