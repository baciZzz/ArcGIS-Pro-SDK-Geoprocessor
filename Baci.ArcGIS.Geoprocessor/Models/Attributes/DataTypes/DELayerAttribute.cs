using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Layer File</para>
	/// <para>图层文件</para>
	/// <para>A layer file stores a layer definition, including symbology and rendering properties.</para>
	/// <para>图层文件存储图层定义，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DELayerAttribute : DataTypeAttribute
	{

	}
}
