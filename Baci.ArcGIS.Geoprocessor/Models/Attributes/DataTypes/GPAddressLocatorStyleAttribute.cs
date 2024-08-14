using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Address Locator Style</para>
	/// <para>地址定位器样式</para>
	/// <para>A template on which to base a new address locator.</para>
	/// <para>用于创建新地址定位器的模板。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPAddressLocatorStyleAttribute : DataTypeAttribute
	{

	}
}
