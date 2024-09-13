using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Dataset</para>
	/// <para>栅格数据集</para>
	/// <para>A single dataset built from one or more rasters.</para>
	/// <para>根据一个或多个栅格构建的单个数据集。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DERasterDatasetAttribute : BaseDataTypeAttribute
	{

	}
}
