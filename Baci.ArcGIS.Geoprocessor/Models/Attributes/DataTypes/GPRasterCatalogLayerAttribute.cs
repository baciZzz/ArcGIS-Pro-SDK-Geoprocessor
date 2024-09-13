using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Catalog Layer</para>
	/// <para>栅格目录图层</para>
	/// <para>A reference to a raster catalog, including symbology and rendering properties.</para>
	/// <para>对栅格目录的引用，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRasterCatalogLayerAttribute : BaseDataTypeAttribute
	{

	}
}
