using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes
{
    internal class CategoryAttribute : Attribute
    {
        public string Category { get; set; } = string.Empty;
    }
}
