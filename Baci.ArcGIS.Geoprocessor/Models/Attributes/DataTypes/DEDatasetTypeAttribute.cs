using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Dataset</para>
	/// <para>数据集</para>
	/// <para>A collection of related data, usually grouped or stored together.</para>
	/// <para>相关数据的集合，通常被分组或存储在一起。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEDatasetTypeAttribute : BaseDataTypeAttribute
	{

	}
}
