using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    public class GPGraphicsLayerAttribute : DomainAttribute
    {
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPGraphicsLayer;
    }
}
