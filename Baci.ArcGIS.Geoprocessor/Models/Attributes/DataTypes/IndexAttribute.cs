using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Index</para>
	/// <para>Index</para>
	/// <para>A data structure used to speed the search for records in geographic datasets and databases.</para>
	/// <para>该数据结构用于加快在地理数据集和数据库中搜索记录的速度。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class IndexAttribute : BaseDataTypeAttribute
	{

	}
}
