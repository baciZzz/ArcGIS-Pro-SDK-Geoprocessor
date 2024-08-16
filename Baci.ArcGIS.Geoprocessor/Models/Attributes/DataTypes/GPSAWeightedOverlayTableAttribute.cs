using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Weighted Overlay Table</para>
	/// <para>加权叠加表</para>
	/// <para>A table with data to combine multiple rasters by applying a common measurement scale of values to each raster, weighing each according to its importance.</para>
	/// <para>包含数据的表，可以通过对每一个栅格值使用同一测量尺度并根据其重要性对其进行加权来合并多个栅格。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAWeightedOverlayTableAttribute : BaseDataTypeAttribute
	{

	}
}
