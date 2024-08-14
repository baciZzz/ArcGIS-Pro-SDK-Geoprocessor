using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Range Domain
    /// </summary>
    public class GPRangeDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPRangeDomain;

        /// <summary>
        /// Min
        /// </summary>
        public string Min  { get; set; }

        /// <summary>
        /// Max
        /// </summary>
        public string Max  { get; set; }

	}
}
