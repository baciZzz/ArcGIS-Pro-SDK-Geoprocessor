using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// xmlserialize
    /// </summary>
    public class xmlserializeAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.xmlserialize;

        /// <summary>
        /// Xml
        /// </summary>
        public string Xml  { get; set; }=string.Empty;

	}
}
