using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Topology</para>
	/// <para>拓扑</para>
	/// <para>A topology that defines and enforces data integrity rules for spatial data.</para>
	/// <para>定义并强制空间数据的完整性规则的拓扑。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DETopologyAttribute : BaseDataTypeAttribute
	{

	}
}
