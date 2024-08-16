using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>dBASE Table</para>
	/// <para>dBASE 表</para>
	/// <para>Attribute data stored in dBASE format.</para>
	/// <para>以 dBASE 格式存储的属性数据。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEDbaseTableAttribute : BaseDataTypeAttribute
	{

	}
}
