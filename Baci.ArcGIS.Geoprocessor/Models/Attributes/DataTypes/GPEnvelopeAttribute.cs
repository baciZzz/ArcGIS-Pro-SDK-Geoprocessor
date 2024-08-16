using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Envelope</para>
	/// <para>包络矩形</para>
	/// <para>The coordinate pairs that define the minimum bounding rectangle in which the data source falls.</para>
	/// <para>定义数据源所在的最小外接矩形的坐标对。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPEnvelopeAttribute : BaseDataTypeAttribute
	{

	}
}
