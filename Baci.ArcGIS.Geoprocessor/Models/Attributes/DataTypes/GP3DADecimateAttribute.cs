using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Decimate</para>
	/// <para>抽取</para>
	/// <para>Specifies a subset of nodes of a TIN to create a generalized version of that TIN.</para>
	/// <para>指定 TIN 的节点子集，以创建该 TIN 的概化版本。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GP3DADecimateAttribute : DataTypeAttribute
	{

	}
}
