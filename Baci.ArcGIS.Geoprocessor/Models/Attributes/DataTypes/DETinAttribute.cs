using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>TIN</para>
	/// <para>TIN</para>
	/// <para>A vector data structure that partitions geographic space into contiguous, nonoverlapping triangles. The vertices of each triangle are sample data points with x-, y-, and z-values.</para>
	/// <para>一种将地理空间分割为连续的不重叠三角形的矢量数据结构。 每个三角形的折点都是具有 x、y 和 z 值的采样数据点。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DETinAttribute : DataTypeAttribute
	{

	}
}
