using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Type</para>
	/// <para>栅格类型</para>
	/// <para>Raster data is added to a mosaic dataset by specifying a raster type. The raster type identifies metadata, such as georeferencing, acquisition date, and sensor type, with a raster format.</para>
	/// <para>栅格数据是通过指定栅格类型的方式添加到镶嵌数据集中的。 栅格类型可与栅格格式一起识别元数据，例如地理配准、采集日期和传感器类型。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRasterBuilderAttribute : DataTypeAttribute
	{

	}
}
