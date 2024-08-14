using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Band</para>
	/// <para>栅格波段</para>
	/// <para>A layer in a raster dataset.</para>
	/// <para>栅格数据集中的图层。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DERasterBandAttribute : DataTypeAttribute
	{

	}
}
