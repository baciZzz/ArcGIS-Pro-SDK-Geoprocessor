using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Data Element</para>
	/// <para>数据元素</para>
	/// <para>A dataset visible in ArcCatalog.</para>
	/// <para>ArcCatalog 中可见的数据集。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DETypeAttribute : DataTypeAttribute
	{

	}
}
