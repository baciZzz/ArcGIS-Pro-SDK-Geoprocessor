using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Time configuration</para>
	/// <para>时间配置</para>
	/// <para>Specifies the time periods used for calculating solar radiation at specific locations.</para>
	/// <para>指定用于计算特定位置太阳辐射的时间段。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSATimeConfigurationAttribute : BaseDataTypeAttribute
	{

	}
}
