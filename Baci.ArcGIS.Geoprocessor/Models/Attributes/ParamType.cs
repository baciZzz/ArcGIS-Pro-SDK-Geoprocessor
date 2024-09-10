using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes
{
    /// <summary>
    /// Param Type Attribute
    /// </summary>
    public class ParamTypeAttribute : Attribute
    {
        /// <summary>
        /// Param Type
        /// </summary>
        public ParamTypeEnum Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        public ParamTypeAttribute(ParamTypeEnum Type)
        {
            this.Type = Type;
        }
    }
}
