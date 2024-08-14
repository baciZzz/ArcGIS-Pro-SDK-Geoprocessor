using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Tool</para>
	/// <para>工具</para>
	/// <para>A geoprocessing tool.</para>
	/// <para>地理处理工具。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEToolAttribute : DataTypeAttribute
	{

	}
}
