using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Mosaic Layer</para>
	/// <para>镶嵌图层</para>
	/// <para>A layer that references a mosaic dataset.</para>
	/// <para>引用镶嵌数据集的图层。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPMosaicLayerAttribute : DataTypeAttribute
	{

	}
}
