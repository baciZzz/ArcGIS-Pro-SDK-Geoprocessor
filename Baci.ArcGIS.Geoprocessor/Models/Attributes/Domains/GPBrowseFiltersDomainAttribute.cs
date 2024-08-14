using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Browse Filters Domain
    /// </summary>
    public class GPBrowseFiltersDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPBrowseFiltersDomain;

        /// <summary>
        /// Browse Filters
        /// </summary>
        public List<string> Filters { get; set; } = new List<string>();

    }
}
