using ArcGIS.Core.CIM;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Map Domain
    /// </summary>
    public class GPMapDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPMapDomain;

        /// <summary>
        /// Map Type
        /// </summary>
        public List<string> MapType { get; set; }=new List<string>();

    }
}

