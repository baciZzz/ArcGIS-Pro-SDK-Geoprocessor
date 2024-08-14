using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GPSA Remap Domain
    /// </summary>
    public class GPSARemapDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPSARemapDomain;

        /// <summary>
        /// Remap Type
        /// </summary>
        public List<string> Remaptype  { get; set; }=new List<string>();

	}
}
