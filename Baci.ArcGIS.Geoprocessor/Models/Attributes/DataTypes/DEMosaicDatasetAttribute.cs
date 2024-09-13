using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Mosaic Dataset</para>
	/// <para>镶嵌数据集</para>
	/// <para>A collection of raster and image data that allows you to store, view, and query the data. It is a data model in the geodatabase used to manage a collection of raster datasets (images) stored as a catalog and viewed as a mosaicked image.</para>
	/// <para>栅格和影像数据的集合，可以存储、查看和查询数据。 镶嵌数据集是地理数据库中的数据模型，用于管理一组以目录形式存储并以镶嵌图像方式查看的栅格数据集（图像）。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEMosaicDatasetAttribute : BaseDataTypeAttribute
	{

	}
}
