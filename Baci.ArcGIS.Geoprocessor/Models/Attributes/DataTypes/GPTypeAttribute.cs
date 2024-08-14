using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Any Value</para>
	/// <para>任意值</para>
	/// <para>A data type that accepts any value.</para>
	/// <para>接受任何值的数据类型。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPTypeAttribute : DataTypeAttribute
	{

	}
}
