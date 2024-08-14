using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Vertical Factor</para>
	/// <para>垂直系数</para>
	/// <para>Specifies the relationship between the vertical cost factor and the vertical, relative moving angle.</para>
	/// <para>指定垂直成本系数和垂直相对移动角度之间的关系。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAVerticalFactorAttribute : DataTypeAttribute
	{

	}
}
