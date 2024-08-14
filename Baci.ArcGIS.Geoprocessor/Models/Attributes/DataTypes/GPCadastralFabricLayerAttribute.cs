using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Parcel Fabric Layer for ArcMap</para>
	/// <para>ArcMap 宗地结构图层</para>
	/// <para>A layer referencing a parcel fabric for ArcMap on disk. This layer works as a group layer organizing a set of related layers under a single layer.</para>
	/// <para>引用磁盘上 ArcMap 宗地结构的图层。 此图层作为图层组，将一组相关图层组织到单个图层下。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPCadastralFabricLayerAttribute : DataTypeAttribute
	{

	}
}
