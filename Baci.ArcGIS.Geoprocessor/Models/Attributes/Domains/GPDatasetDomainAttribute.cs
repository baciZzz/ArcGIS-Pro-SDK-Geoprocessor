using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Dataset Domain
    /// </summary>
    public class GPDatasetDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPDatasetDomain;

        /// <summary>
        /// Data Set Type
        /// </summary>
        public List<DataSetTypeEnum> DataSetType { get; set; } = new List<DataSetTypeEnum>();

    }
}
