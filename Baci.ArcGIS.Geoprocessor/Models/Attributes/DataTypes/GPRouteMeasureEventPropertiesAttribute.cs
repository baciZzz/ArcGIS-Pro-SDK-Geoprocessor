using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Route Measure Event Properties</para>
	/// <para>路径测量事件属性</para>
	/// <para>Specifies the fields on a table that describe events measured by a linear referencing route system.</para>
	/// <para>在表中指定一个字段来描述由线性参考路径系统测量的事件。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRouteMeasureEventPropertiesAttribute : DataTypeAttribute
	{

	}
}
