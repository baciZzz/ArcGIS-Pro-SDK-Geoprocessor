using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Geodataset</para>
	/// <para>地理数据集</para>
	/// <para>A collection of data with a common theme in a geodatabase.</para>
	/// <para>地理数据库中具有共同主题的数据集合。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEGeoDatasetTypeAttribute : DataTypeAttribute
	{

	}
}
