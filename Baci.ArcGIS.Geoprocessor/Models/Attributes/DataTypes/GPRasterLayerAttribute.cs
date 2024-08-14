using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Layer</para>
	/// <para>栅格图层</para>
	/// <para>A reference to a raster, including symbology and rendering properties.</para>
	/// <para>对栅格的引用，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRasterLayerAttribute : DataTypeAttribute
	{

	}
}
