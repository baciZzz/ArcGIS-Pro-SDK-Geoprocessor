using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Cell Size XY</para>
	/// <para>像元大小 XY</para>
	/// <para>Defines the two sides of a raster cell.</para>
	/// <para>定义栅格像元的两侧。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPCellSizeXYAttribute : BaseDataTypeAttribute
	{

	}
}
