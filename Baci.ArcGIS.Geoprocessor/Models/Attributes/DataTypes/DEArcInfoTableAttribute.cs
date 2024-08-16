using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>INFO Table</para>
	/// <para>INFO 表</para>
	/// <para>A table in an INFO database.</para>
	/// <para>INFO 数据库中的表。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEArcInfoTableAttribute : BaseDataTypeAttribute
	{

	}
}
