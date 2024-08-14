using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>SQL Expression</para>
	/// <para>SQL 表达式</para>
	/// <para>A syntax for defining and manipulating data from a relational database.</para>
	/// <para>定义和操纵关系数据库中的数据的语法。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSQLExpressionAttribute : DataTypeAttribute
	{

	}
}
