using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Coverage</para>
	/// <para>Coverage</para>
	/// <para>A coverage dataset, a proprietary data model for storing geographic features as points, arcs, and polygons with associated feature attribute tables.</para>
	/// <para>Coverage 数据集，用于存储地理要素，如点、弧线和面以及相关要素属性表的专有数据模型。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DECoverageAttribute : DataTypeAttribute
	{

	}
}
