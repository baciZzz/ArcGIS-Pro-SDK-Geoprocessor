using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Spatial Reference</para>
	/// <para>空间参考</para>
	/// <para>The coordinate system used to store a spatial dataset, including the spatial domain.</para>
	/// <para>用于存储空间数据集（包括空间域）的坐标系。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSpatialReferenceAttribute : DataTypeAttribute
	{

	}
}
