using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Cell Size</para>
	/// <para>像元大小</para>
	/// <para>The cell size used by the ArcGIS Spatial Analyst extension.</para>
	/// <para>ArcGIS Spatial Analyst extension 使用的像元大小。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSACellSizeAttribute : DataTypeAttribute
	{

	}
}
