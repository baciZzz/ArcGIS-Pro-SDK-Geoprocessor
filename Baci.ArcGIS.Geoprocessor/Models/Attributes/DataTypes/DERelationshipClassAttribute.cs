using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Relationship Class</para>
	/// <para>关系类</para>
	/// <para>The details about the relationship between objects in the geodatabase.</para>
	/// <para>地理数据库中对象间关系的详细信息。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DERelationshipClassAttribute : DataTypeAttribute
	{

	}
}
