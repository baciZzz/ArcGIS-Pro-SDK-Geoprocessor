using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Polygon</para>
	/// <para>面</para>
	/// <para>A connected sequence of x,y-coordinate pairs, where the first and last coordinate pair are the same.</para>
	/// <para>一系列相连的 x,y 坐标对，其中，第一个坐标对和最后一个坐标对相同。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPPolygonAttribute : BaseDataTypeAttribute
	{

	}
}
