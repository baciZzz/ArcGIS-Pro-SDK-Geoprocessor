using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>String Hidden</para>
	/// <para>隐藏字符串</para>
	/// <para>A string that is masked by * characters.</para>
	/// <para>以 * 字符进行掩膜的字符串。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPStringHiddenAttribute : BaseDataTypeAttribute
	{

	}
}
