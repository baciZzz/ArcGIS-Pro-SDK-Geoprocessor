using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// ArcGIS Pro IGPProcess Param Domain
    /// </summary>
    public abstract class DomainAttribute : Attribute
    {
        public abstract DomainTypeEnum Type { get; set; }
    }


}
