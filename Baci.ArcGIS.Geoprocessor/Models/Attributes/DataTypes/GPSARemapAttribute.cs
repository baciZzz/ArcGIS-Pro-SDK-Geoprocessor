using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Remap</para>
	/// <para>重映射</para>
	/// <para>A table that defines how raster cell values are reclassified.</para>
	/// <para>定义栅格像元值重分类方法的表。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSARemapAttribute : BaseDataTypeAttribute
	{

	}
}
