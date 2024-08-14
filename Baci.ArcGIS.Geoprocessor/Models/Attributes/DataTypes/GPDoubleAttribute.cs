using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Double</para>
	/// <para>双精度型</para>
	/// <para>Any floating-point number stored as a double precision, 64-bit value.</para>
	/// <para>所有浮点数都存储为双精度 64 位值。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPDoubleAttribute : DataTypeAttribute
	{

	}
}
