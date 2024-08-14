using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class EnumExtension
    {
        /// <summary>
        /// Get The Value From GPValueAttribute
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string Value(this Enum @enum)
        {
            if (@enum is null) return string.Empty;

            Type type = @enum.GetType();
            FieldInfo fd = type.GetField(@enum.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(GPValueAttribute), false);
            string name = string.Empty;
            foreach (GPValueAttribute attr in attrs)
            {
                name = attr.Value;
            }
            return name;
        }
    }
}
