using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Composite Domain
    /// </summary>
    public class GPCompositeDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// 
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPCompositeDomain;

        /// <summary>
        /// 
        /// </summary>
        public DomainAttribute[] Items { get; set; }

    }
}
