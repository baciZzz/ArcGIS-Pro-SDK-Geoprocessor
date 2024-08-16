using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Projection File</para>
	/// <para>投影文件</para>
	/// <para>A file storing coordinate system information for spatial data.</para>
	/// <para>存储空间数据的坐标系统信息的文件。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEPrjFileAttribute : BaseDataTypeAttribute
	{

	}
}
