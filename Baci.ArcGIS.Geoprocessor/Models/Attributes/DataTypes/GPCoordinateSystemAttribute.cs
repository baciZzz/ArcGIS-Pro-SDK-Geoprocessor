using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Coordinate System</para>
	/// <para>坐标系</para>
	/// <para>A reference framework, such as the UTM system, consisting of a set of points, lines, or surfaces, and a set of rules used to define the positions of points in two- and three-dimensional space.</para>
	/// <para>参考框架，例如 UTM 系统，由一组点、线或面，以及一组用于定义二维和三维空间中点的位置的规则组成。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPCoordinateSystemAttribute : DataTypeAttribute
	{

	}
}
