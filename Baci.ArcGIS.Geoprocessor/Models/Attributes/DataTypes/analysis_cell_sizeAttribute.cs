using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Analysis Cell Size</para>
	/// <para>分析像元大小</para>
	/// <para>The cell size used by raster tools.</para>
	/// <para>栅格工具使用的像元大小。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class analysis_cell_sizeAttribute : DataTypeAttribute
	{

	}
}
