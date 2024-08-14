using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Address Locator</para>
	/// <para>地址定位器</para>
	/// <para>A dataset used for geocoding that stores the address attributes, associated indexes, and rules that define the process for translating nonspatial descriptions of places to spatial data.</para>
	/// <para>用于地理编码的数据集，存储地址属性、关联的索引以及用于定义将地点的非空间描述转换为空间数据这一过程的规则。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEAddressLocatorAttribute : DataTypeAttribute
	{

	}
}
