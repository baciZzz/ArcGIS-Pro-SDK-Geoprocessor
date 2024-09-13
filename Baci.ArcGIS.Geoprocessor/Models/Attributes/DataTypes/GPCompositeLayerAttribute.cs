using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Composite Layer</para>
	/// <para>复合图层</para>
	/// <para>A reference to several children layers, including symbology and rendering properties.</para>
	/// <para>对多个子图层的引用，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPCompositeLayerAttribute : BaseDataTypeAttribute
	{

	}
}
