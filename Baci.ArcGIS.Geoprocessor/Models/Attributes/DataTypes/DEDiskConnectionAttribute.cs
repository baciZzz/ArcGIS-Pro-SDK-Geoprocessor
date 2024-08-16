using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Disk Connection</para>
	/// <para>磁盘连接</para>
	/// <para>An access path to a data storage device.</para>
	/// <para>数据存储设备的访问路径。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEDiskConnectionAttribute : BaseDataTypeAttribute
	{

	}
}
