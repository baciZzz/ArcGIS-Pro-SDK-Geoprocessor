using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Network Dataset Layer</para>
	/// <para>网络数据集图层</para>
	/// <para>A reference to a network dataset, including symbology and rendering properties.</para>
	/// <para>对网络数据集的引用，包括符号系统和渲染属性。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPNetworkDatasetLayerAttribute : DataTypeAttribute
	{

	}
}
