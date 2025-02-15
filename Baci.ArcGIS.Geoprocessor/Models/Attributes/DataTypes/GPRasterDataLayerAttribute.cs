using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Data Layer</para>
	/// <para>栅格数据图层</para>
	/// <para>A raster data layer.</para>
	/// <para>栅格数据图层。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRasterDataLayerAttribute : BaseDataTypeAttribute
	{

	}
}
