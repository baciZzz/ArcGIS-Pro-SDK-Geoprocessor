using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Network Analyst Layer</para>
	/// <para>网络分析图层</para>
	/// <para>A special group layer used to express and solve network routing problems. Each sublayer held in memory in a Network Analyst layer represents some aspect of the routing problem and the routing solution.</para>
	/// <para>用于表达和解决网络路径问题的特殊图层组。 Network Analyst 图层中存储的各子图层代表路径问题和解决方案的某些方面。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPNALayerAttribute : DataTypeAttribute
	{

	}
}
