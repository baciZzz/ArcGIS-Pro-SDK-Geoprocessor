using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Network Dataset</para>
	/// <para>网络数据集</para>
	/// <para>A collection of topologically connected network elements (edges, junctions, and turns), derived from network sources and associated with a collection of network attributes.</para>
	/// <para>拓扑连接网络元素（边、交汇点和转弯）的集合，源于网络源并与网络属性的集合相关联。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DENetworkDatasetAttribute : DataTypeAttribute
	{

	}
}
