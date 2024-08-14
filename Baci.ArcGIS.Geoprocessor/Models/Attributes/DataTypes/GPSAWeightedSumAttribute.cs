using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Weighted Sum</para>
	/// <para>加权总和</para>
	/// <para>Specifies data for overlaying several rasters, each multiplied by their given weight and summed.</para>
	/// <para>指定用于通过将栅格各自乘以指定的权重并合计在一起来叠加多个栅格的数据。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAWeightedSumAttribute : DataTypeAttribute
	{

	}
}
