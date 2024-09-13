using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>VPF Table</para>
	/// <para>VPF 表</para>
	/// <para>Attribute data stored in Vector Product Format.</para>
	/// <para>以矢量产品格式存储的属性数据。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEVPFTableAttribute : BaseDataTypeAttribute
	{

	}
}
