using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models
{
    public class Param
    {
        public string enabled { get; set; }

        public string type { get; set; }

        public string displayname { get; set; }

        public string description { get; set; }

        public DataTypeEnum datatype { get; set; }

        public List<DataType> datatypes { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public Domain domain { get; set; }

        //public JObject domain { get; set; }

        public object value { get; set; }
    }
}
