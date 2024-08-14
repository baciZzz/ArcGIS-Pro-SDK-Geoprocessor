using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Horizontal Factor</para>
	/// <para>水平系数</para>
	/// <para>The relationship between the horizontal cost factor and the horizontal relative moving angle.</para>
	/// <para>水平成本系数和水平相对移动角度之间的关系。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAHorizontalFactorAttribute : DataTypeAttribute
	{

	}
}
