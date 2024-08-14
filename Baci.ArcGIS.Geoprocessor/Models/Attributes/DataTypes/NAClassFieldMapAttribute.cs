using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Network Analyst Class FieldMap</para>
	/// <para>Network Analyst 类 FieldMap</para>
	/// <para>Mapping between location properties in a Network Analyst layer (such as stops, facilities, and incidents) and a point feature class.</para>
	/// <para>在 Network Analyst 图层（如中转点、设施点和事故点）和点要素类中的位置属性之间建立映射。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class NAClassFieldMapAttribute : DataTypeAttribute
	{

	}
}
