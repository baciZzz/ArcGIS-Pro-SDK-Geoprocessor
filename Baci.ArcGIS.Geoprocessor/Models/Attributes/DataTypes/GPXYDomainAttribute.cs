using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>XY Domain</para>
	/// <para>XY 范围域</para>
	/// <para>A range of lowest and highest possible values for x,y-coordinates.</para>
	/// <para>x,y 坐标的最低和最高可能值的范围。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPXYDomainAttribute : BaseDataTypeAttribute
	{

	}
}
