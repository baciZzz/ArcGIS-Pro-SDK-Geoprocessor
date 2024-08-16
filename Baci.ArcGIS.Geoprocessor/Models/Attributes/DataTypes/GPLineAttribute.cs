using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Line</para>
	/// <para>线</para>
	/// <para>A shape, straight or curved, defined by a connected series of unique x,y-coordinate pairs.</para>
	/// <para>由一系列相连的唯一 x,y 坐标对定义的直的或弯曲的形状。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPLineAttribute : BaseDataTypeAttribute
	{

	}
}
