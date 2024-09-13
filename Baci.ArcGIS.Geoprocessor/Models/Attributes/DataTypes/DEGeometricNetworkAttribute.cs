using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Geometric Network</para>
	/// <para>几何网络</para>
	/// <para>A linear network represented by topologically connected edge and junction features. Feature connectivity is based on their geometric coincidence.</para>
	/// <para>由拓扑连接的边和交汇点要素表示的线状网络。 要素连通性以其几何重叠为基础。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEGeometricNetworkAttribute : BaseDataTypeAttribute
	{

	}
}
