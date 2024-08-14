using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Point</para>
	/// <para>点</para>
	/// <para>A pair of x,y-coordinates.</para>
	/// <para>x,y 坐标对。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPPointAttribute : DataTypeAttribute
	{

	}
}
