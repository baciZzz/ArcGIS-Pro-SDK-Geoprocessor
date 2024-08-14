using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// 
    /// </summary>
    public class GPTablesDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPTablesDomain;

        /// <summary>
        /// HideJoinedLayers
        /// </summary>
        public bool HideJoinedLayers { get; set; } = false;

        /// <summary>
        /// Show Only Standalone Tables
        /// </summary>
        public bool ShowOnlyStandaloneTables { get; set; } = true;

        /// <summary>
        /// Portal Type
        /// </summary>
        public List<string> PortalType { get; set; } = new List<string>();

    }
}
