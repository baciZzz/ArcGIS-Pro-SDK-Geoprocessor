using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Feature Layer</para>
	/// <para>要素图层</para>
	/// <para>A reference to a feature class, including symbology and rendering properties.</para>
	/// <para>对要素类 的引用，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPFeatureLayerAttribute : BaseDataTypeAttribute
	{

	}
}
