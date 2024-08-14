using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Field Info</para>
	/// <para>字段信息</para>
	/// <para>The details about a field in a FieldMap.</para>
	/// <para>FieldMap 中字段的详细信息。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPFieldInfoAttribute : DataTypeAttribute
	{

	}
}
