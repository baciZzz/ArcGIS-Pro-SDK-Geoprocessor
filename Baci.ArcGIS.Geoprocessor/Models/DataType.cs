using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models
{
    public class DataType
    {
        public DataTypeEnum type { get; set; }

        public string displayname { get; set; }

        public string description { get; set; }

        public List<DataType> datatypes { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is DataType dataType)
            {
                if (dataType.type == this.type && dataType.displayname == this.displayname)
                {
                    if (dataType.datatypes == null && this.datatypes == null)
                    {
                        return true;
                    }
                    if (dataType.datatypes.Count == this.datatypes.Count)
                    {
                        foreach (var item in dataType.datatypes.Select(c => c.type))
                        {
                            if (this.datatypes.Where(c => c.type == item).Count() <= 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                return false;

            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
