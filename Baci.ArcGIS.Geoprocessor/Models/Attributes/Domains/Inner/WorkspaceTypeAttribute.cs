using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// Workspace Type Attribute
    /// </summary>
    public class WorkspaceTypeAttribute:Attribute
    {
        /// <summary>
        /// Workspace Type Attribute
        /// </summary>
        /// <param name="workspaceType"></param>
        public WorkspaceTypeAttribute(params string[] workspaceType)
        {
            WorkspaceType= workspaceType.ToList();
        }

        /// <summary>
        /// Workspace Type
        /// </summary>
        public List<string> WorkspaceType { get; set; } = new List<string>();
    }
}
