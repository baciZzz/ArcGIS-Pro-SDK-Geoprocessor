using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Statistics</para>
	/// <para>栅格统计</para>
	/// <para>Specifies if raster statistics build.</para>
	/// <para>指定是否构建栅格统计。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAGDBEnvStatisticsAttribute : DataTypeAttribute
	{

	}
}
