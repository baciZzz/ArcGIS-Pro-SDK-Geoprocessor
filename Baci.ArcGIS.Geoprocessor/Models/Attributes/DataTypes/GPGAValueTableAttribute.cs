using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Geostatistical Value Table</para>
	/// <para>地统计值表</para>
	/// <para>A collection of data sources and fields that define a geostatistical layer.</para>
	/// <para>定义地统计图层的数据源和字段的集合。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPGAValueTableAttribute : DataTypeAttribute
	{

	}
}
