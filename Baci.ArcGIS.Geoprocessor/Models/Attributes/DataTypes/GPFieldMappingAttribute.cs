using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Field Mappings</para>
	/// <para>字段映射</para>
	/// <para>A collection of fields in one or more input tables.</para>
	/// <para>一个或多个输入表中的字段集合。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPFieldMappingAttribute : DataTypeAttribute
	{

	}
}
