using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Variant</para>
	/// <para>变量</para>
	/// <para>A data value that can contain any basic type: Boolean, date, double, long, and string.</para>
	/// <para>可包含任意基本类型的数据值：布尔型、日期、双精度、长整型和字符串。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPVariantAttribute : BaseDataTypeAttribute
	{

	}
}
