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
    /// GP Feature Class Domain
    /// </summary>
    public class GPFeatureClassDomainAttribute : DomainAttribute
    {

        /// <summary>
        /// ArcGIS Pro IGPProcess Param Domain Type
        /// </summary>
        public override DomainTypeEnum Type { get; set; } = DomainTypeEnum.GPFeatureClassDomain;

        /// <summary>
        /// Geometry Type
        /// </summary>
        public List<string> GeometryType { get; set; } = new List<string>();

        /// <summary>
        /// Feature Type
        /// </summary>
        public List<string> FeatureType { get; set; } = new List<string>();

        /// <summary>
        /// Has Z
        /// </summary>
        public bool Has_Z { get; set; } = false;

        /// <summary>
        /// Include Z
        /// </summary>
        public bool Include_Z { get; set; } = false;

        /// <summary>
        /// Portal Type
        /// </summary>
        public List<string> Portaltype { get; set; } = new List<string>();

    }


}
namespace ArcGIS.Core.Geometry
{
    /// <summary>
    /// Describes the different types of geometry.
    /// </summary>
    public enum GeometryType
    {
        //
        // ժҪ:
        //     Unknown type. There will be no Geometry instance existing with this type.
        Unknown = 0,
        //
        // ժҪ:
        //     Point geometry. See ArcGIS.Core.Geometry.MapPoint.
        Point = 513,
        //
        // ժҪ:
        //     Envelope geometry. See ArcGIS.Core.Geometry.Envelope.
        Envelope = 3077,
        //
        // ժҪ:
        //     Multipoint geometry. See ArcGIS.Core.Geometry.Multipoint.
        Multipoint = 8710,
        //
        // ժҪ:
        //     Polyline geometry. See ArcGIS.Core.Geometry.Polyline.
        Polyline = 25607,
        //
        // ժҪ:
        //     Polygon geometry. See ArcGIS.Core.Geometry.Polygon.
        Polygon = 27656,
        //
        // ժҪ:
        //     MultiPatch 3D surface. See ArcGIS.Core.Geometry.Multipatch.
        Multipatch = 32777,
        //
        // ժҪ:
        //     Bag of geometries. See ArcGIS.Core.Geometry.GeometryBag.
        GeometryBag = 3594
    }

    public enum FeatureType
    {
        //
        // ժҪ:
        //     Simple Feature.
        Simple,
        //
        // ժҪ:
        //     Simple Junction Feature.
        SimpleJunction,
        //
        // ժҪ:
        //     Simple Edge Feature.
        SimpleEdge,
        //
        // ժҪ:
        //     Complex Junction Feature.
        ComplexJunction,
        //
        // ժҪ:
        //     Complex Edge Feature.
        ComplexEdge,
        //
        // ժҪ:
        //     Annotation Feature.
        Annotation,
        //
        // ժҪ:
        //     Coverage Annotation Feature.
        CoverageAnnotation,
        //
        // ժҪ:
        //     Dimension Feature.
        Dimension,
        //
        // ժҪ:
        //     Raster Catalog Item.
        RasterCatalogItem
    }

    public enum PortalType {

        DataStoreCatalogLayer
    }

}

