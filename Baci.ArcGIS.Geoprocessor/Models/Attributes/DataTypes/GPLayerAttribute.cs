using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Layer</para>
	/// <para>图层</para>
	/// <para>A reference to a data source, such as a shapefile, coverage, geodatabase feature class, or raster, including symbology and rendering properties.</para>
	/// <para>对数据源的引用，例如 shapefile、coverage、地理数据库要素类或栅格，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPLayerAttribute : DataTypeAttribute
	{

	}
}
