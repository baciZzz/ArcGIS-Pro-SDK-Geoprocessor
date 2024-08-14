using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Layers And Tables Domain
    /// </summary>
    public class GPLayersAndTablesDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPLayersAndTablesDomain;

        /// <summary>
        /// Must Have Joins
        /// </summary>
        public object MustHaveJoins { get; set; } = false;

        /// <summary>
        /// Must Have Relates
        /// </summary>
        public object MustHaveRelates  { get; set; } = false;

    }
}
