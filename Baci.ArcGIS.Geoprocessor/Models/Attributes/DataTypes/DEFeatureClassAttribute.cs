using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Feature Class</para>
	/// <para>要素类</para>
	/// <para>A collection of spatial data with the same shape type: point, multipoint, polyline, and polygon.</para>
	/// <para>具有相同形状类型的空间数据集合: 点、多点、线和面。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEFeatureClassAttribute : DataTypeAttribute
	{

	}
}
