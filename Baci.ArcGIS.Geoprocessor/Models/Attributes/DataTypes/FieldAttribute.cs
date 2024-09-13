using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Field</para>
	/// <para>字段</para>
	/// <para>A column in a table that stores the values for a single attribute.</para>
	/// <para>表中的列，用于存储单个属性的值。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class FieldAttribute : BaseDataTypeAttribute
	{

	}
}
