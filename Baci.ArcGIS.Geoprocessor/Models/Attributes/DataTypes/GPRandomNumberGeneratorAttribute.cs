using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Random Number Generator</para>
	/// <para>随机数生成器</para>
	/// <para>Specifies the seed and the generator to use when creating random values.</para>
	/// <para>指定创建随机值时使用的种子和生成器。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRandomNumberGeneratorAttribute : DataTypeAttribute
	{

	}
}
