using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GP CodedValue Domain
    /// </summary>
    [GPCodedValueDomainAttribute()]
    public class GPCodedValueDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPCodedValueDomain;

        /// <summary>
        /// Code-Value
        /// </summary>
        public List<CodedValue> Items { get; set; } = new List<CodedValue>();

    }

    /// <summary>
    /// 
    /// </summary>
    public class CodedValue
    {
        //public DomainTypeEnum Type { get; set; } = DomainTypeEnum.string;
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
