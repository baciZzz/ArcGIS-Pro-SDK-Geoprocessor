using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Fuzzy function</para>
	/// <para>模糊函数</para>
	/// <para>Specifies the algorithm used in fuzzification of an input raster.</para>
	/// <para>指定用于模糊化输入栅格的算法。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAFuzzyFunctionAttribute : DataTypeAttribute
	{

	}
}
