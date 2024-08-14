using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Radius</para>
	/// <para>半径</para>
	/// <para>Specifies which surrounding points are used for interpolation.</para>
	/// <para>指定用于插值的周围点。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSARadiusAttribute : DataTypeAttribute
	{

	}
}
