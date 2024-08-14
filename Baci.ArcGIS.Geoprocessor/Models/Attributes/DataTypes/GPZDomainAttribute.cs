using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Z Domain</para>
	/// <para>Z 范围域</para>
	/// <para>A range of lowest and highest possible values for z-coordinates.</para>
	/// <para>z 坐标的最低和最高可能值的范围。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPZDomainAttribute : DataTypeAttribute
	{

	}
}
