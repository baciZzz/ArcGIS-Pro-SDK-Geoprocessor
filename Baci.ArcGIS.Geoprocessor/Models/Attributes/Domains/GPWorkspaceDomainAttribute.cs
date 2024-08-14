using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP Workspace Domain
    /// </summary>
    public class GPWorkspaceDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPWorkspaceDomain;

        /// <summary>
        /// Workspace Type (Local Database,Remote Database,Feature Service)
        /// </summary>
        public List<string> WorkspaceType { get; set; } = new List<string>();

	}
}
