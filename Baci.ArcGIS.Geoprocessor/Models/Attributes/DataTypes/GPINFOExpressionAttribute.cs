using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>INFO Expression</para>
	/// <para>INFO 表达式</para>
	/// <para>A syntax for defining and manipulating data in an INFO table.</para>
	/// <para>定义和操纵 INFO 表中数据的语法。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPINFOExpressionAttribute : BaseDataTypeAttribute
	{

	}
}
