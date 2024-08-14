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
	public class GPFileDomainAttribute : DomainAttribute
	{

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type  { get; set; } = DomainTypeEnum.GPFileDomain;

        /// <summary>
        /// File Types
        /// </summary>
        public List<string> FileTypes { get; set; } = new List<string>();

	}
}
