using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes
{
    public class ParamTypeAttribute : Attribute
    {
        public ParamTypeEnum Type { get; set; }

        public ParamTypeAttribute(ParamTypeEnum Type)
        {
            this.Type = Type;
        }
    }
}
