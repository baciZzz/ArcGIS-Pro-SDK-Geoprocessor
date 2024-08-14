using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Tile Size</para>
	/// <para>切片大小</para>
	/// <para>Specifies the width and the height of data stored in a block.</para>
	/// <para>指定存储在块中的数据的宽度和高度。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAGDBEnvTileSizeAttribute : DataTypeAttribute
	{

	}
}
