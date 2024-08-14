using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Geostatistical Search Neighborhood</para>
	/// <para>地统计搜索邻域</para>
	/// <para>Defines the searching neighborhood parameters for a geostatistical layer.</para>
	/// <para>定义地统计图层的搜索邻域参数。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPGASearchNeighborhoodAttribute : DataTypeAttribute
	{

	}
}
