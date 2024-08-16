using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Topo Features</para>
	/// <para>拓扑要素</para>
	/// <para>Features that are input to the interpolation.</para>
	/// <para>输入到插值中的要素。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSATopoFeaturesAttribute : BaseDataTypeAttribute
	{

	}
}
