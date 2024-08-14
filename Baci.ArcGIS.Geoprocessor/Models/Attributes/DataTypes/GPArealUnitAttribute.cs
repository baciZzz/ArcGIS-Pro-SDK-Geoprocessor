using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Areal Unit</para>
	/// <para>面积单位</para>
	/// <para>An areal unit type and value, such as square meter or acre.</para>
	/// <para>面积单位类型和值，例如平方米或英亩。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPArealUnitAttribute : DataTypeAttribute
	{

	}
}
