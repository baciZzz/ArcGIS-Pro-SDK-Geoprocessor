using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Coverage Feature Class</para>
	/// <para>Coverage 要素类</para>
	/// <para>A coverage feature class, such as point, arc, node, route, route system, section, polygon, and region.</para>
	/// <para>Coverage 要素类，例如点、弧线、节点、路线、路线系统、弧段、面和区域。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DECoverageFeatureClassAttribute : BaseDataTypeAttribute
	{

	}
}
