using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Extent</para>
	/// <para>范围</para>
	/// <para>Specifies the coordinate pairs that define the minimum bounding rectangle (xmin, ymin and xmax, ymax) of a data source. All coordinates for the data source fall in this boundary.</para>
	/// <para>指定用于定义数据源的最小外接矩形的坐标对（xmin, ymin and xmax, ymax）。 所有数据源的坐标都在此边界内。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPExtentAttribute : DataTypeAttribute
	{

	}
}
