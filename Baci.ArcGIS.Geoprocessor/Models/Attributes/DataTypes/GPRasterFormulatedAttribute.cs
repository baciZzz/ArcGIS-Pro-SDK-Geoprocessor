using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Formulated Raster</para>
	/// <para>格式化栅格</para>
	/// <para>A raster surface whose cell values are represented by a formula or constant.</para>
	/// <para>栅格表面，其像元值由公式或常量表示。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPRasterFormulatedAttribute : BaseDataTypeAttribute
	{

	}
}
