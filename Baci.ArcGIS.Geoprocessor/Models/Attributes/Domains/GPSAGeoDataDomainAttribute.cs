using ArcGIS.Core.Geometry;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains
{
    /// <summary>
    /// GPSA Geo Data Domain
    /// </summary>
    public class GPSAGeoDataDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPSAGeoDataDomain;

        /// <summary>
        /// Check Field
        /// </summary>
        public bool CheckField { get; set; } = false;

        /// <summary>
        /// Single Band
        /// </summary>
        public bool SingleBand { get; set; } = true;

        /// <summary>
        /// Data Type
        /// </summary>
        public List<string> DataType { get; set; } = new List<string>();

        /// <summary>
        /// Field Type
        /// </summary>
        public List<FieldTypeEnum> FieldType { get; set; } = new List<FieldTypeEnum>();

        /// <summary>
        /// Geometry Type
        /// </summary>
        public List<GeometryType> GeometryType { get; set; } = new List<GeometryType>();

        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; } = string.Empty;

    }

}
