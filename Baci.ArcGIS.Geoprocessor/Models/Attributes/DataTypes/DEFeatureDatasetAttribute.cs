using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Feature Dataset</para>
	/// <para>要素数据集</para>
	/// <para>A collection of feature classes that share a common geographic area and the same spatial reference system.</para>
	/// <para>共享公共的地理区域和相同的空间参考系统的要素类集合。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEFeatureDatasetAttribute : DataTypeAttribute
	{

	}
}
