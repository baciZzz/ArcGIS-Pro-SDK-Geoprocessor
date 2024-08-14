using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Text File</para>
	/// <para>文本文件</para>
	/// <para>Data stored in ASCII format.</para>
	/// <para>以 ASCII 格式存储的数据。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DETextFileAttribute : DataTypeAttribute
	{

	}
}
