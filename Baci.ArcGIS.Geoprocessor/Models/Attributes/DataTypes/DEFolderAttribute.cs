using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Folder</para>
	/// <para>文件夹</para>
	/// <para>Specifies a location on disk where data is stored.</para>
	/// <para>指定数据在磁盘上的存储位置。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEFolderAttribute : DataTypeAttribute
	{

	}
}
