using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Linear Unit</para>
	/// <para>线性单位</para>
	/// <para>A linear unit type and value such as meter or feet.</para>
	/// <para>线性单位类型和值，例如米或英尺。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPLinearUnitAttribute : DataTypeAttribute
	{

	}
}
