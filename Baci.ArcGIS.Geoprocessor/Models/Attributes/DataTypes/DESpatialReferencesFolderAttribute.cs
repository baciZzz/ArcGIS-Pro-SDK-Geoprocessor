using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Coordinate Systems Folder</para>
	/// <para>坐标系文件夹</para>
	/// <para>A folder on disk storing coordinate systems.</para>
	/// <para>磁盘上用于存储坐标系的文件夹。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DESpatialReferencesFolderAttribute : DataTypeAttribute
	{

	}
}
