﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes
{
    public class GPValueAttribute : Attribute
    {
        public string Value { get; set; }
        public GPValueAttribute(string value) { Value = value; }
    }
}
