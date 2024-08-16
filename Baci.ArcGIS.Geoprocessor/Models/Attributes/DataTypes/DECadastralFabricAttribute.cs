using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Parcel Fabric for ArcMap</para>
	/// <para>ArcMap 宗地结构</para>
	/// <para>A parcel fabric for ArcMap is a dataset for the storage, maintenance, and editing of a continuous surface of connected parcels or parcel network.</para>
	/// <para>ArcMap 的宗地结构是存储、维护和编辑相连宗地或宗地网络的连续表面的数据集。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DECadastralFabricAttribute : BaseDataTypeAttribute
	{

	}
}
