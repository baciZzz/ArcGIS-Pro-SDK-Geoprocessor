using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Geostatistical Layer</para>
	/// <para>地统计图层</para>
	/// <para>A reference to a geostatistical data source, including symbology and rendering properties.</para>
	/// <para>对地统计数据源的引用，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPGALayerAttribute : BaseDataTypeAttribute
	{

	}
}
