using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Compression</para>
	/// <para>压缩</para>
	/// <para>Specifies the type of compression used for a raster.</para>
	/// <para>指定用于栅格的压缩类型。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPSAGDBEnvCompressionAttribute : BaseDataTypeAttribute
	{

	}
}
