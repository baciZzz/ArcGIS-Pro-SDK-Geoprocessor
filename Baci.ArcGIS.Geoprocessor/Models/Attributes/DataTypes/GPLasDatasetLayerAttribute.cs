using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>LAS Dataset Layer</para>
	/// <para>LAS 数据集图层</para>
	/// <para>A layer that references a LAS dataset on disk. This layer can apply filters on lidar files and surface constraints referenced by a LAS dataset.</para>
	/// <para>引用磁盘上的 LAS 数据集的图层。 此图层可将过滤器应用于 LAS 数据集引用的雷达文件和表面约束。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPLasDatasetLayerAttribute : DataTypeAttribute
	{

	}
}
