using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Neighborhood</para>
	/// <para>邻域</para>
	/// <para>The shape of the area around each cell used to calculate statistics.</para>
	/// <para>用于计算统计数据的各像元周围区域的形状。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSANeighborhoodAttribute : BaseDataTypeAttribute
	{

	}
}
