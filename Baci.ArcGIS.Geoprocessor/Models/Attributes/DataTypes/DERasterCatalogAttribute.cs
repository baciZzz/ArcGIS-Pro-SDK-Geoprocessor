using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Raster Catalog</para>
	/// <para>栅格目录</para>
	/// <para>A collection of raster datasets defined in a table. Each table record defines an individual raster dataset in the catalog.</para>
	/// <para>以表形式定义的栅格数据集的集合。 每个表记录定义目录中的一个单独栅格数据集。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DERasterCatalogAttribute : DataTypeAttribute
	{

	}
}
