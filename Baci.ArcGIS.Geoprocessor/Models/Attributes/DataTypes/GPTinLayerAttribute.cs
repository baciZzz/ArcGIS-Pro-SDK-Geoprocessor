using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>TIN Layer</para>
	/// <para>TIN 图层</para>
	/// <para>A reference to a TIN, including topological relationships, symbology, and rendering properties.</para>
	/// <para>对 TIN 的引用，包括拓扑关系、符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPTinLayerAttribute : DataTypeAttribute
	{

	}
}
