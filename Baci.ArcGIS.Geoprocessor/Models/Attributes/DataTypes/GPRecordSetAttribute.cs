using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Record Set</para>
	/// <para>记录集</para>
	/// <para>Interactive table; type in the table values when the tool is run.</para>
	/// <para>交互表；工具运行时输入表值。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRecordSetAttribute : DataTypeAttribute
	{

	}
}
