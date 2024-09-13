using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Group Layer</para>
	/// <para>分组图层</para>
	/// <para>A collection of layers that appear and act as a single layer. Group layers make it easier to organize a map, assign advanced drawing order options, and share layers for use in other maps.</para>
	/// <para>显示为单个图层，并按照单个图层处理的图层集合。 图层组使组织地图、指定高级绘制顺序选项和共享图层以用于其他地图变得更加容易。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPGroupLayerAttribute : BaseDataTypeAttribute
	{

	}
}
