using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Terrain Layer</para>
	/// <para>Terrain 图层</para>
	/// <para>A reference to a terrain, including symbology and rendering properties. It’s used to draw a terrain.</para>
	/// <para>对 terrain 的引用，包括符号系统和渲染属性。 用于绘制 terrain。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPTerrainLayerAttribute : DataTypeAttribute
	{

	}
}
