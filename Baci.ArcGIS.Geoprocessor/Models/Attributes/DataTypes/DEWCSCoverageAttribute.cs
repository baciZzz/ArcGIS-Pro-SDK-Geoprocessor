using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>WCS Coverage</para>
	/// <para>WCS Coverage</para>
	/// <para>Web Coverage Service (WCS) is an open specification for sharing raster datasets on the web.</para>
	/// <para>网络覆盖服务 (WCS) 是网络上共享栅格数据集的开放式规范。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEWCSCoverageAttribute : DataTypeAttribute
	{

	}
}
