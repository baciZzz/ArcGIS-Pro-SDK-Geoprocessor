using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Semivariogram</para>
	/// <para>半变异函数</para>
	/// <para>Specifies the distance and direction representing two locations used to quantify autocorrelation.</para>
	/// <para>指定用于量化自相关的两个地点的距离和方向。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSASemiVariogramAttribute : DataTypeAttribute
	{

	}
}
